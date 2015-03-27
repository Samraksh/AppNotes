os_wrap

The idea is of a wrapper for some operating system components, hence the name os wrap.  It came from an embedded project that ran on a board with a multitasking operating system with tasks, message queues, and semaphores.  The problem was there were not enough boards for the developers so os_wrap was developed so that the same code could be run in DOS as a single threaded, standalone program.  As a result it needed the basic functionality of tasking, message queues, and semaphores.

It made switching between single-threaded DOS and multitasking VxWorks totally transparent to the developer (as long as they stayed in the framework).

Development could continue with tasks, message queues and semaphores, but when running in a single-threaded operating system, it is really running in a "cooperative multitasking" system.  The tasks have to voluntarily give up the processor so that other tasks could run.

Now, it is ported to Arduino so the real concepts of message queues, semaphores, and tasks can lay-out the archetecture as it would be in a real multi-tasking system.  But it runs on Arduino as a single threaded system.

Development note: I tried os_wrap on a Duemilanove Board, and it failed.  So I started stripping stuff out until I got something that worked.  That's when I coded up osw_min, and even that still had problems with malloc and free, so then I stripped it down to osw_mini.

Then I got the Arduino Cookbook, and found out about PROGMEM and putting all my strings into program memory (especially the splash-screen banner), and that solved nearly all my memory problems.  So now, even the full os_wrap works on the Duemilanove board, even if it doesn't leave much room for anything else.  Since I had already done the work of creating osw_min and osw_mini, they are available as well.

osw_mini: has tasks, semaphores, counting semaphore, events, and odometer, but message queues, and shared memory are implemented as templates to avoid using malloc() and free().  Also, timouts of semaphores and message queues are removed from this implementation to save space.  (But the paramenters remain in the interface, for seamless transition to the other versions of os_wrap.)

osw_min: has tasks, semaphores, counting semaphores, message queues, events, odometer, and shared memory.  Has message queues for fixed message sizes, as well as packed message queues.  Semaphores, and message queues have timeout values implemented.  Uses malloc() and free(), recommended for boards with more memory.

os_wrap: The complete package, with semaphores, counting semaphores, message queues, packed message queues, priority message queues, (all with timeouts, and wait times for elements in the queues), semTee's and message queue Tee's for multiple destinations, odometer, memory management, events, tasks, syslog capabilities, and an OS trace and loging capability for debug post-mortums.  Uses malloc() and free() or os_wrap memory management, recommended for boards with more memory.

All of these were tested on the Duemilanove Board.  It's true that os_wrap uses up to 15K of program memory and up to 1.5 K of ram, not leaving much room for anything else.  But with the announcement of an ARM version of Arduino coming soon, there will be plenty of room on those boards.

These are the source code files:
[[image:os_wrap.zip]]
[[image:osw_min.zip]]
[[image:osw_mini.zip]]

Simply unzip one (or any or all) of these zip files under .../libriries/ 
After restarting the Arduino IDE they should appear a libraries, with their corresponding example code.


Tasks

On the embedded board running a multitasking OS, each task was easy to code up.  Each task was an infinite loop that waited for something to happen, then it responded.  For example:

void task1(void)
{
  // Do task1 init stuff here.

  while (!done) { // main loop
    semTake(sem1, 10);  //  wait for the semaphore
    
    //  Do task1 stuff here
  }
}

void task2(void)
{
  // Do task2 init stuff here.

  while(!done) {  // main loop
    //  wait for a message to come.
    msgQReceive(msgQ1, buf, size, WAIT_FOREVER); 

    //  Do task2 stuff here.
  }
}

The startup code was simple as well, create all the semaphore and message queues that would be used then perform any initialization code that needed to be done.  After that, start all the tasks and let it run until the system was reset.  

void Main(void)  // entry point
{
  // declare the semaphores and message queues.
  SEM_ID sem1;
  MSGQ_ID msgQ1;

  semCreate(sem1);  //  initial it.
  msgQCreate(msgQ1, 100, 10);  // up to 100 bytes per message 
                               // up to 10 messages in the Queue

  // create and start tasks.
  taskCreate("task1", 240, 0x7fff, (FUNCPTR)task1);
  taskCreate("task2", 250, 0x7fff, (FUNCPTR)task2);
}

A call to the function Main, would initialize and start up everything.  That's how it was done on the embedded board.  To write a wrapper to DOS, the tricky part was to make the system run as a single thread of execution.  This wrapper also needed to provide the functionality of semaphores, message queues, and some limited timing functions.  Pre-processor definitions were used depending on the operating system being used.  

When porting to the PC in a DOS environment, using just a single thread of execution, it was necessary to make changes in the multitasking code.  The tasks couldn't just enter an infinite loop forever, they need to be cooperative and need to return in a single thread system, so that the next task can be executed.  To accomplish this a new variable osw_SINGLE_THREAD was introduced.  In single thread systems, every semTake and msgQReceive would need to return immediately, with the data or with an error, or with the osw_SINGLE_THREAD value.  This makes task1 just a little more complicated:

void task1(void)
{
  while(!done) {
    int result = sem1.semtake(WAIT_FOREVER);
    if (result == osw_SINGLE_THREAD) return;
    if (result == 0) continue;

    // Do task1 stuff here.
  } // endwhile.
}

The WAIT_FOREVER will be used and the call to semtake will return when the semaphore is received.  When running as single threaded, the call to semtake returns immediately, either with a semaphore or with the osw_SINGLE_TREAD value.  So in a single thread system, if the semaphore is not available, the task will return so that other tasks can be executed.  Task2 is adjusted the same way.

The only changes to the Main function are to use the new handles (for tasks too) and calls, and a tasks_go call at the end.  Another aspect is that the task initialization work that needs to be done once before the infinite loop is entered needs to be moved out of the task body.  Since we are exiting and re-calling each task in the single thread system, the task initialization needs to be moved into Main before the tasks start running.  The additions needed to run with the OS wrapper are in bold font below:

void Main(void)
{
  // declare the semaphores and message queues.
  osw_semaphore sem1;
  osw_message_q msgQ1;
  osw_task task1;
  osw_task task2;

  sem1.semcreate();   //  initial it.
  msgQ1.msgQcreate(10, 100);  // up to 10 messages of 
                              // up to 100 bytes each.

  //  Do task1 init stuff here.
  //  Do task2 init stuff here.

  // create and start tasks.
  task1.taskcreate("task1", 240, 0x7fff, (FUNCPTR)task1);
  task2.taskcreate("task2", 250, 0x7fff, (FUNCPTR)task2);

  // Now make it all go.
  osw_tasks_go();
}

In the multitasking OS, the osw_tasks_go call does nothing since the tasks start executing at taskcreate().  In the single threaded version, the osw_tasks_go function will cycle through the tasks and call each one in turn, and does so the same way each time the program is run, so it is completely deterministic. 

If the tasks are coded up to this standard framework all that the unit tests have to do is set semaphores and fill message queues to fully exercise the units as written.  Unit testing became much easier because the specifications between units were reduced to just those two mechanisms.

The task class API provided by os_wrap is:

class osw_task
{
  public:
    osw_task(void) {}
    ~osw_task() {taskdelete();}
    int taskcreate(char *_name,
                   osw_funcptr _the_func,
                   void* _data = OSW_NULL,
                   unsigned int _interval_ms = 0,  // task interval
                   bool _osw_trace = true,
                   bool _active = true);
    int taskdelete();
    friend int osw_tasks_go(void);
    void deactivateTask(void) {active_ = false;}
    void activateTask(void) {active_ = true;}
    char* getName(void) {return name_;}
};   
 
//  exit with an exit code.
void osw_exit(int _code = 0);
//  returns the version string of os_wrap
char* osw_version(void) {return OSW_VERSION;}

//  This is the function that runs the tasks.  It is totally 
//  deterministic in how it runs things.
int osw_tasks_go(void);


Tasks are created with the taskcreate function call:

int taskcreate(char *_name,
               osw_funcptr _the_func,
               void* _data = OSW_NULL,
               unsigned int _interval_ms = 0,  // task interval
               bool _osw_trace = true,
               bool _active = true);


_name is a character string that is associated with the task.  _the_func is the pointer to the function that will be run.  _data is a pointer to data passed to _the_func function.  _evt_trace is a flag to determine if event-log events will be logged in the event log.  This is helpful if a task that runs at a high frequency is debugged and is bloating the event log with its events.   

This version does not deal with priorities.  It probably can be done, but instead of priority this os_wrap version uses _interval_ms.  If _interval_ms  is set to zero, then it will be called as often as it can.  It _interval_ms is non-zero then it will run periodically as specified.

The _active parameter determines if a task can be set to active or not-active.  It is often helpful to "switch off" tasks during parts a run, or to bring up a task in a non-active state but ready to run at a later time.

The taskCreate() function returns OSW_TOO_MANY_TASKS if the number of tasks exceeds OSW_MAX_TASKS, or returns 0 on success.

As tasks are created they are added to the task list, and the task_idx is the number of the task that is currently running.

static bool osw_done_val = false;
static osw_task *tasklist[OSW_MAX_TASKS] = {OSW_NULL};    // max tasks
static int task_idx = 0; // the task we are currently performing
static int numTasks = 0; // total number of tasks

With these structures the actual logic to execute the tasks is simply a "for" loop, that is executed each iteration when the time tic happens, or they are run "flat-out" if the task's interval is set to zero.  

Other functions are provided to manipulate the tasks and task list.  The taskdelete() function removes a task from the task list.  A task can delete itself.  The taskDelete() function returns 0 upon completion.  The deactivateTask() and activateTask() clear and set the active flag for a task.  The osw_exit() function sets the osw_done_val to true and breaks out of the iteration loop that contains the for loop going through the task list.

The osw_tasks_go() function is the function that is called from loop() that runs the tasks in the task list. The osw_tasks_go() return osw_done_val upon completion.

Interrupts

The osw_interrupt_enable() and osw_interrupt_disable() functions are just wrappers for Arduino's interrupts() and noInterrupts() calls.  

Turning off the OSW_USE_INTERRUPTS_ARDUINO switch will make these functions do nothing.

Watchdog Timer

There are two watchdog timer functions for the API:

void osw_watchdog_enable(int _value);  // Set up and start the watchdog
void osw_watchdog_reset(void);      //  pet the dog

For Arduino, the implementation is taken from  Semyon Tushev's Web Site: tushev.org, "Arduino and watchdog timer".

valid call values are:
  WDTO_8S    (8 secs) (ATmega 168, 328, 1280, 2560 only)
  WDTO_4S    (4 secs) (ATmega 168, 328, 1280, 2560 only)
  WDTO_2S    (2 secs)
  WDTO_1S    (1 sec)
  WDTO_500MS (500 ms)
  WDTO_250MS (250 ms)
  WDTO_120MS (120 ms)
  WDTO_60MS  (60 ms)
  WDTO_30MS  (30 ms)
  WDTO_15MS  (15 ms)

While having a watchdog timer seems like a really good idea, if/when it expires it only resets the chip not the board.  So the serial line dies and requires a power-cycle to come back.  Or worst case, it bricks the board.

So, the watchdog timer should be the last thing added to the software because it's somewhat dangerous to use it for day to day development.

Turning off the OSW_USE_HW_WATCHDOG_ARDUINO switch will make these functions do nothing.

The Safety Critical Paradigm

For safety critical systems (this is a legacy hold over from pre-Arduino days), no code is executed in a different order from run to run.  No tasks are run "flat-out".  The task loop is triggered by a time tick. The tasks are executed with interrupts disabled.  So however long that loop takes to execute is added to the interrupt latency.  This is for the paradigm that tasks should be "atomic" functions.  

Turning off the OSW_SAFETY_CRITICAL_PARADIGM switch will allow tasks to be run "flat-out" and interrupts will happen when they happen.  

Semaphores

Semaphores are instantiated and created, then they are available to use with semGive() and semTake() functions. 

The semaphore class API provided by os_wrap is:

class osw_semaphore
{
  public:
    osw_semaphore(char* _name = OSW_NULL, int _full = 0);
    ~osw_semaphore();
    int semCreate(char* _name = OSW_NULL, int _full = 0);
    // Semtake will return a 1 if it got the semaphore.
    // 0 if it timed out waiting.
    // osw_SINGLE_THREAD otherwise.
    // Warning: to_wait = 0 can cause an infinite loop in the
    // calling routine if it waits for OSW_SINGLE_THREAD to return 
    // control, since OSW_SINGLE_THREAD will never be returned.
    int semTake(int _to_wait_ms = OSW_WAIT_FOREVER);
    int semGive(void);
    int semTee(osw_semaphore &tee_from);
    int semUntee(osw_semaphore &tee_from);
};

In the constructor, a name for the semaphore can be provided.  The semaphore is accessed by the handle returned by the semCreate() function.  The semaphore can be initialized to be empty or full.  If full then a semTake() can take if without a semGive() call the first time through.

The semTake() function also can have a timeout specified.  The return of the semTake() function will be 1 if the semaphore is obtained, 0 if the semaphore times out, or OSW_SINGLE_THREAD if the semTake() is still waiting for the semaphore.  Specifying OSW_WAIT_FOREVER, the default value, means that semTake() will return OSW_SINGLE_THREAD until the semaphore is obtained, and then it will return 1 one time.  Specifying OSW_NO_WAIT means that semTake() will return 1 if the semaphore was waiting to be taken, or return 0, because it timed out.  If the tasks are written following the frame work above, care should be taken when using OSW_NO_WAIT, since OSW_SINGLE_THREAD will never be returned, the task needs to note that and return control for cooperative multitasking on it's own.

This semaphore is a binary semaphore, multiple calls to semGive() will result in only one semTake() receiving the semaphore.  For multiple semGive()s and semTake()s a counting semaphore is provided (see below).

Semaphores can be tee-ed, which is an option that allows many tasks to wait for the same semaphore.  Each task can declare it's own semaphore, then call semTee() with the semaphore they want to trigger off of, and tee off it with their semaphore.  When a semGive() is called the function calls semGive() for every semaphore that has tee-ed off of it.  In a sense, semTee() is a registration to call semGive()s to their semaphore when the other semGive() is called.  The semUntee() function removes the semaphore from the tee-list of the other semaphore.  

The os_wrap defines OSW_MAX_TEES that is the upper limit of the tee that can be attached to a semaphore or queue.  The user can adjust this value to his needs.  

If the maximum tees is exceeded semTee() will return OSW_TOO_MANY_TEES.  If semUntee() is called on an empty tee list, the function return OSW_UNTEE_ERROR.


Counting Semaphores

The API for the counting semaphores is:

class osw_counting_sem
{
  public:
    osw_counting_sem(void);
    int semCreate(char* _name = OSW_NULL);
    // Semtake will return a 1 if it got the semaphore.
    int getCount(void);
    int semTake(int _to_wait_ms = OSW_WAIT_FOREVER);
    int semGive(void);
};

As with the binary semaphores, the name is set during the semCreate() call.  Multiple semGive()s and semTake()s can be called in a row, every semGive() will increment an internal counter.  Each semTake will decrement the internal counter, if the counter reaches 0, then semTake will wait for the interval specified.  See the binary semaphores (above) for a discussion of how waiting times are specified and the behavior of the different values.

The getCount() function return the internal counter for the semaphore, it is the count of how many semTake()s can be called with immediate responses.  


Message Queues

Message Queues are instantiated and created, and they are then available through the msgQsend() and msgQreceive() functions.

The API for the message queue class is:

class osw_message_q
{
  public:
    osw_message_q();
    ~osw_message_q();
    int msgQcreate(char* _name, int _max_msg_size, int _max_msgs);
    int msgQtee(osw_message_q& _tee_from);
    int msgQuntee(osw_message_q& _tee_from);
    // msgQreceive will return a >0 if it got a message.
    // 0 if it timed out waiting, OSW_SINGLE_THREAD otherwise.
    int msgQreceive(char *_in_msg,
                    int _size = 0,
                    int _to_wait_ms = OSW_WAIT_FOREVER,
                    int* _tick = OSW_NULL);
    int msgQsend(char *_in_msg,
                 int _size,
                 int _control = OSW_REJECT_ON_FULL);
    int msgQcount(void) {return Qsem_.getCount();}
};
    

The message queue needs to be created with a call to msgQcreate().  The name holds the name of the queue, and _max_msg_size and _max_msgs needs to be filled in with the size of the biggest message being sent through the queue and the number of messages the queue will hold, respectively.  

Messages are sent with the msgQsend() function.  This function adds the message to the queue.  If the queue is full, it will return an error code based on the control parameter.  The control parameter will determine how the message queue should work with a full queue.  If the control set to OSW_BUMP_ON_FULL the send function will throw away the oldest message for the new message and return OSW_MSG_Q_FULL_BUMP.  If the control is set to OSW_REJECT_ON_FULL, the new message will not be added to the full queue and it will return OSW_MSG_Q_FULL_REJECT.  If _size exceeds the max_msg_size, then an error OSW_EXCEED_MAX_SIZE is returned and the message is not added to the queue.  If _size is less than or equal to max_msg_size then _size bytes will be copied from _in_msg to the message queue.

Messages are received with the msgQreceive() function.  The received message is placed in _in_msg, up to _size bytes.  If _size is the default 0 value, then the message is copied into _in_msg is the size of the message in the queue, it is then the user's responsibility that a buffer overflow doesn't happen.  The _tick field will provide the clock tick of when the message was added to the queue.  The amount of time the message was waiting in the queue can be computed from this, and is useful for debugging and statistics.  The function will return the number of bytes actually copied into _in_msg.  The msgQreceive() function will return 0 if it timed out waiting, or OSW_SINGLE_THREAD otherwise.  

Message queue tee-ing is provided through the msgQtee() and msgQuntee functions.  Sometimes if one task was acting as the source of data, more than one other task needs to receive it.  Without tee-ing, the source task would need to know about every receiving task and send the data to each receiver task separately.  With the message queue tee mechanism, each source task would just spew its data out of a message queue and any other task that wanted to use it could just tee off of that message queue.

The message queue tee is very nice for debugging and recording.  A generic data recording routine could be created and it would just tee off the message queues it wanted to record while leaving the sending and receiving tasks untouched.  Since any task could write to any message queue it has access to, a routine that used previously recorded data could then spew into the message queues to spoof the sources.  The receiving routines wouldn't know the difference.  This is an enormous help to unit testing and creating testing scenarios that will provide the same message queue input in a repeatable way.

The message queue tees also provide a publish and subscribe functionality. By creating a message Q with max_msgs set to 0 the message will dead end.  But any other Q tee-ing off of this Q will receive it.  So events can be generated, subscription is accomplished by tee-ing off the Q, and publish is accomplished by the message Q send.

Packed Message Queues

Sometimes a message queue is receiving messages of different sizes.  Using a standard message queue, the max_message_size would be set to the size of the largest message with no problem.  The smaller messages can still use the queue.  But what if most messages are small (like < 100 bytes), then there is one message that is very large (like 4K for example), For small messages, it is a waste of space to allocate 4K for each message.  A packed message queue will pack the messages into a chunk of memory, in this way the queue could hold a large number of small messages, or a few big messages, or some combination.

The project that spawned this idea was using a message queue to communication between two tasks.  There were about twenty messages a second that were 100 bytes or less, and one message per second that was 4K.  So there were 21 messages a second, if standard message queues were used, it would have be 21*4K = 84K of memory for the message queue.  The packed message queue could perform the same function with 7K (or round it up to 10K for good measure).  The message queue is one-tenth the size in this example (obviously not Arduino).

The API for the packed message queue class is:

class osw_packed_q
{
  public:
    osw_packed_q();
    ~osw_packed_q();
    int pkdQcreate(char* _name, int _size_bytes);
    int pkdQtee(osw_packed_q &_tee_from);
    int pkdQuntee(osw_packed_q &_tee_from);
    // msgQreceive will return a >0 if it got a message.
    // 0 if it timed out waiting, OSW_SINGLE_THREAD otherwise.
    //  _tick will return the tick value when the element was entered
    //  into the queue.  The caller can see how long it was in the Q.
    int pkdQreceive(char *_in_msg,
                    int _size = 0,
                    int _to_wait_ms = OSW_WAIT_FOREVER,
                    int* _tick = OSW_NULL);
    int pkdQsend(char *_in_msg,
                 int _size);
    int pkdQcount(void) {return Qsem_.getCount();}
};

The message queue needs to be created with a call to pkdQCreate().  The name parameter holds the name of the queue, but _size_bytes needs to be the size allocated for the message queue.  Note that there is not a message size or a number of messages.  The number messages the queue can hold depends on the size of the messages, not a predefined maximum.  

Messages are sent with the pdkQsend() function.  This function adds the message to the queue.  If there is insufficient space for the message of the size given in the parameter it will return the error OSW_PKD_Q_FULL.  If the message _in_msg of size _size, can be placed in the message queue buffer, _size bytes will be copied from _in_msg to the message queue.

It should be noted that message queue size should be at least twice as big as the largest anticipated message.  If small messages are waiting to be received and they are located in the middle of the memory block allocated for the message queue, only a message of the size of the free contiguous space on either side of the small messages is available.  This means that unfavorable "fragmentation" could happen in this scenario.  The algorithm adds messages as a ring buffer, and uses a ROLLOVER_VALUE, added to the message queue to indicate that the next message is at the beginning of the allocated buffer.  This means that a large message that just barely exceeds the end of the buffer will be placed at the beginning of the buffer if there is room, but that could leave a large chunk at the end of the buffer that is unusable until messages leaving the buffer wrap around.

Messages are received with the pkdQreceive() function.  The received message is placed in _in_msg, up to _size bytes.  The function will return the number of bytes actually copied into _in_msg.  The pkdQreceive() function will return 0 if it timed out waiting, or OSW_SINGLE_THREAD otherwise.  If the _size parameter is 0, then the message in the queue will be copied to _in_msg.  Care should be taken to avoid buffer overruns.  The _tick field will provide the clock tick of when the message was added to the queue.  The amount of time the message was waiting in the queue can be computed from this, and is useful for debugging and statistics.

Message queue tee-ing is provided through the pkdQtee() and pkdQuntee functions.  The Semaphore section above explains what tee-ing is and how they are used.  Teeing isn't really preferred with packed message queues.  But the functions are added for consistency with the normal message queues.

Priority Message Queues

The priority message queue allows messages to be sent at a priority, the messages are then received in the order of highest priority messages first.  For a given priority the message are retrieved in FIFO order.  The bigger the priority number the higher the priority.  Usually 0 is the lowest priority, and no upper limit to highest priority.  

If negative priorities are needed, just ensure that the value of OSW_ALL_PRIOIRITIES is different than a needed priority.

#define OSW_ALL_PRIOIRITIES (-1)

The priority queue is a single array to hold all the data.  Then for every priority there is a linked list of data inside the data array.  There is also a free list that keeps track of the memory as it's read out.  The bookkeeping to hold the data contains heads and tails of the data for each priority.  That is held in another array and it's size is determined by the number of different priorities that is being used.

If n is the number of elements in the Q, and p is the number of different priorities that are used, then store and retrive is O(log(p+1)).  Note that it's based on p not n.  For most routing applications p is only 3 or 4 and so for that few of priorities, or if p is a fixed number, this algorithm is ~= O(constant).

And the class API is:

#define OSW_PRIQ_BUMP_LOW_HEAD_FULL   (1)
#define OSW_PRIQ_BUMP_LOW_TAIL_FULL   (2)
#define OSW_PRIQ_BUMP_PRI_HEAD_FULL   (3)
#define OSW_PRIQ_REJECT_ON_FULL       (4)

class osw_priority_q
{
  public:
    osw_priority_q();
    ~osw_priority_q();
    int priQcreate(char* _name,
                   int _max_msg_size,
                   int _max_msgs,
                   int _max_num_priorities);
    // msgQreceive will return a >0 if it got a message.
    // 0 if it timed out waiting, OSW_SINGLE_THREAD otherwise.
    //  _tick will return the tick value when the element was entered
    //  into the queue.  The caller can see how long it was in the Q.
    int priQreceive(int* _priority,
                    char* _in_msg,
                    int _size, // sizeof _in_msg array
                    int _to_wait_ms = OSW_WAIT_FOREVER,
                    osw_tick_t* _tick = OSW_NULL);
    int priQsend(int _priority,  // 0=lowest priority
                 char* _in_msg,
                 int _size,
                 int _control = OSW_PRIQ_REJECT_ON_FULL);
    int priQcount(int _priority = OSW_ALL_PRIOIRITIES);
    void priQflush(int _priority = OSW_ALL_PRIOIRITIES);
};

The message queue needs to be created with a call to priQCreate().  The name parameter holds the name of the queue, _max_msg_size is the maximum message size, and _max_msgs is total count of messages regardless of priority, and _max_num_priorities is how many distict priority (including free list) that can be used by this queue.  (The prioity list is an allocated array, hence max size is needed.  Maybe in the future the priority list will be implemented as a linked list and the parameter will not be needed.)

Messages are sent with the priQsend() function.  This function adds the message of priority _priority, size _size, and a control selection _control, to the queue.  If the queue is full, then the _control parameter dictates what to do.  

When the Q fills up:
* OSW_PRIQ_BUMP_LOW_HEAD_FULL finds the lowest priority queue, and removes the head of the queue (oldest) and uses the space for the new element.  The priQsend() function will return the value: OSW_PRI_Q_BUMP_LOW_HEAD.
* OSW_PRIQ_BUMP_LOW_TAIL_FULL find the lowest priority queue, and removes the tail of the queue.  This is useful for some network implementations.  If the network protocol calls for retransmission after a missed message, bumping off the end of the queue means more sequenced messages get through reducing the number of messages that need to be retransmitted. The priQsend() function will return the value: OSW_PRI_Q_BUMP_LOW_TAIL.
* OSW_PRIQ_BUMP_PRI_HEAD_FULL bumps the head (oldest) message of the same priority as the new message, if there are no previous messages at that priority, the new message is rejected. The priQsend() function will return the value: OSW_PRI_Q_BUMP_PRI_HEAD.
* OSW_PRIQ_REJECT_ON_FULL if the queue is full, reject the new message regardless of its priority. The priQsend() function will return the value: OSW_PRI_Q_FULL_REJECT.

Messages are received with the priQreceive() function.  The received message is placed in _in_msg, up to _size bytes, and _priority will be filled with the priority of the received message.  The function will return the number of bytes actually copied into _in_msg.  The priQreceive() function will return 0 if it timed out waiting, or OSW_SINGLE_THREAD otherwise.  If the _size parameter is 0, then the message in the queue will be copied to _in_msg.  Care should be taken to avoid buffer overruns.  The _tick field will provide the clock tick of when the message was added to the queue.  The amount of time the message was waiting in the queue can be computed from this, and is useful for debugging and statistics.

Message queue tee-ing is not provided for priority message queues.  But an implementation similar to the normal message queue can be implemented.


Events

While message queues can be used for subscribing to and publishing data records to various tasks, events provide the ability to execute code of those that subscribe to it.  

The event routines API consist of:

typedef void (*osw_eventFucnPtr) (int);

void osw_evt_publish(int _event);
int osw_evt_register(int _event, osw_eventFucnPtr _eventHandler);

All events are user defined and implemented as an integer.  With a call to osw_evt_register() the caller defines the event number and the function that should be called upon that event being published.

Any task can call osw_evt_publish() with any event number.  On the publish call, all the functions that have been registered with that number are called.  With the event number being passed to the eventHandler as a parameter.  In this way a single handler can be registered for multiple events and when it is called the parameter will tell it which event was published.  

This is a very dangerous mechanism.  Since this is a single threaded system with cooperative multitasking, it is important that the evenHandler be as short as possible, or deterministic as per project design.  The event handlers are executed as subfunctions from the publish call.  Care should be taken not to publish more events within an event handler.  If two event handlers publish each other's events it will result in an infinite calling-loop between them.

The pairs of events to functions are kept in an array with maximum size of OSW_MAX_EVENT_PAIRS.  This value can be user adjusted in the header file.  The call to osw_evt_register() will return 0 on success, but will return OSW_TOO_MANY_EVENT_PAIRS if the maximum has been reached.


Time

The time functions are the most changeable part of the implementation.  Each system will have it's own method had handling timers, timestamps and how the processor is made aware of the passage of time.  The time functions are the ones that will need to be redesigned and rewritten for each implementation, and each computer system.  

The basic function is getTick().  This function will return a monotonic increasing integer, that is the number of "ticks" that the system has had since power-up (VxWorks) or since the program began executing (Solaris), or absolute time (DOS/Windows), or from a particular time in history (GPS).  For the example code here, it is a DOS/Windows code and it looks like this:

//  on this system a tic is at 65.5 Hz.
#define MS_PER_TIC (15.26)

int getTick(void); // ms
int diffTime_ms(int _oldTime, int _newTime = 0);

There is an internal system tic at 65.5 Hz.  But to simplify the math in the rest of the code, the getTick() function converts it and provides milliseconds.  The rest of the code can then be coded to deal with ms and the getTick() can be called directly with further conversions.  This will depend from project to project what is needed, and what resolution there is.

Some systems will provide a clock tic as an interrupt that increments the counter.  Others will have a clock chip where getTick() just reads the tic value without an interrupt to the processor, this setup is preferable for a safety critical system.  Ether way, the getTick() is the fundamental unit that the rest of the time functions build off of.

The diffTime_ms() function provides the difference between two tic values.  The second parameter is defaulted to 0 and if a second parameter is not provided, then the function give the time elapsed from the _oldTime to the present.

In keeping with the task model, a delay function is provided so that a task only executes when the delay has expired:

class osw_delay
{
  public:
    osw_delay();
    int delay(int _ms);
};

The delay() call will return OSW_SINGLE_THREAD until the time is up, then it will return 1, and reset itself to start timing again.  This is yet another way to run the task in a periodic fashion, there is already the _Hz and _mod values in the taskCreate that do this too.  The API is used in a task as follows:

void task1(void)
{
  static osw_delay delay;
  while(!done) {
    if (delay.delay(3000) != 1) {
      return OSW_SINGLE_THREAD;
    }

    // Do task1 stuff here, every 3000 ms.
  } // endwhile.
}

The last item provided with the time functions is a variable type that acts as a polled timer.  The osw_dt_timer is a timer that remains engaged for a period of time then is timed-out.  But it keeps a running time count so that it can also be used as a stopwatch.  The API for osw_dt_timer is:

class osw_dt_timer
{
  public:
    osw_dt_timer(int _msTimeout = 0);
    //  Assign one osw_dt_timer variable to another:
    osw_dt_timer(const osw_dt_timer& _source); // copy constructor
    osw_dt_timer& operator=(osw_dt_timer& _source);
    // Access functions:
    int getDuration(void);
    void setDuration(int _msTimeout);
    bool isPaused(void);
    //  start() and stop() will clear a pause
    //  msAge() continues to count time even after a stop().
    //  stop() does NOT need to be called between successive start()'s.
    //  OSW_WAIT_FOREVER may be used as a timeout value, useful for 
    //  testing.
    void start(int _msTimeout = OSW_USE_PREVIOUS_VALUE);
    void stop(void);
    //  pause() and resume() will pause the passage of time.
    //  msTimeLeft() and msAge() will freeze until unpaused.
    //  engaged() and timedOut() will be unchanged during pause.
    void pause(void);
    void resume(void);
    //  engaged and timedOut are logical opposites.  Both are
    //  provided since the code is more readable one way or another.
    bool engaged(void);
    bool timedOut(void);
    //  TimeLeft and Age since the constructor, or start().
    //  If duration is OSW_WAIT_FOREVER, msTimeLeft() will return 1, 
    //  until stop() is called.
    int msTimeLeft(void);
    //  Running time count since the constructor, or start().
    int msAge(void);

};


The start () sets the amount of time (in milliseconds) that the value should be engaged.  The engaged() call remains true until the time expires then returns false.  The timedOut() function is the logical opposite of engaged().  In application code it is sometimes more readable to check for timeouts, or check if something is engaged, so both are provided.  

When the duration is set to 0 when a timer is declared, it will be timed out.  If a period of time is provided to the constructor, then it will be declared and engaged.  The stop() call sets the timer to timed out.  The start() sets the time interval, if no parameter is passed then the previos duration value is used again.  The msAge () and msTimeLeft () call provide the age and time left for the timer, if the timer is timed out the msTimeLeft () function will return zero.

An assignment operator is also provided.  Often classes will want to declare variables of this type within them, and use them as normal variables.  It is necessary for this type to have it's own assignment operator to handle this usage.


Memory Manager

The os_wrap software provides it own memory manager.  This is to be free of the standard run-time libraries that normally get loaded into a system.  The K&R standard C language reference provides an example of a simple memory manager.  This was the template that was used here.  All the free memory is turned into a free-list which is a linked-list of the blocks of memory that can be used by the application.  The API of the memory manager is:

#ifdef OSW_USE_STDMEM
#include<stdlib.h>  // malloc() and free()
#else
#define OSW_HEAP_SIZE (450)
#endif

typedef void* osw_mem_t;

osw_mem_t osw_malloc(int _num_bytes);
int osw_free(osw_mem_t _location);
int osw_mem_check(osw_mem_t _location);
void osw_print_mem_free(void);


The switch OSW_USE_STDMEM is used to choose between using the standard libraries, or using the os_wrap code for the memory manager.  The OSW_HEAP_SIZE is the number of bytes that will be managed.  For Arduino this is rather small.  This value is unused if the standard libraries are used.  osw_mem_t is the standard type used by the memory manager and needs to be cast as needed.

The osw_malloc() and osw_free() are the user functions to use in place of standard C's malloc() and free(), respectively.  If the standard libraries are used these function are just a wrapper for the standard malloc() and free().  Otherwise, they access the os_wrap memory manager.  Using the os_wrap code, the osw_malloc() function checks the free list until it finds a block of memory with the requested number of bytes in it.  It then adjusts the free list and returns a pointer to the block of memory for the application to use.  The osw_malloc() function also allocates enough space for it to save a size value, and a word before and after the block of memory with a bit pattern written in it.  This bit pattern is used to detect if the application code overruns the allocated memory.  The osw_malloc() function returns a non-null pointer to the block of memory on success, or it will return OSW_NULL if there is an error.  

The osw_free() function uses the size value stored by the osw_malloc() call, and frees up that much memory.  That is to say it adds that block back into the free-list.  The osw_free() function also checks the bit pattern before and after the allocated memory to see if it has be overwritten.  If it has, the osw_free() function will return OSW_MEM_VALID_FAIL.  If osw_free() is called with a OSW_NULL value it will return OSW_INVALID_PARAMETER, if the function succeeds it will return 0.

The osw_mem_check () is a utility function that check the bit pattern before and after the allocated memory.  It will return OSW_MEM_VALID_FAIL if the bit pattern doesn't match, OSW_INVALID_PARAMETER if OSW_NULL is passed to it, or OSW_OK on success.  If the standard libraries are used this function does nothing.

The osw_print_mem_free () is a utility function that prints the free-list to the screen if the standard libraries are not used.  If the standard libraries are used this function prints the memoryFree(), a function taken from Arduino Cookbook, page 535, by Michael Margolis.


System Logging

The standard C libraries provide standard input/output, and that is useful for most cases. os_wrap provides a logging service.  Error messages and other messages can be sent to the system logger.  If the standard libraries are used then the logger can also echo the output to a print statement, or to a file if a file system is provided.  But without the standard libraries, the logger needs to be able to send the output to a block of memory, (flash or RAM) that can be analyzed in a post-mortem. 

The API for the logger is:

class osw_log {
  public:
    osw_log(char* _filename = OSW_NULL,
            bool _echo = false);
    ~osw_log();
    //  log to a block of memory.
    int init(void* _address, long _size);
    //  log to a file.
    int init(char* _filename);
    //  log to a socket.
    int init(long _ip, int _port);
    //  log to the console.
    int init(bool _echo = true);
    //  log a character or a string.
    void logc(char _c);
    void logs(char* _s);
    void logi(long _n);
    void logx(long _n);
    //  write the memory block to a file (post processing).
    void mem2file(char* _filename);
};

For most of development, the standard libraries are available, in which case the osw_log() constructor uses a filename and can echo things to the output console.  Those parameters are included in the constructor for convenience only.  Generally, the main startup will determine where the log messages need to be set, and will set up the osw_log routines through the various init() functions.  

One init() function requires an address and size, to a block of memory, the log message will be placed in that memory, and when that memory is full it will cycle around and overwrite the oldest messages.  In this way it can act as a "black box" containing the most recent messages when something goes bad.  The utility function mem2file() will take the block of memory and write it to a file, during a post-mortem.  

The init() function that takes a filename will open the file and all log messages will be written to the file.  The init() function that asks for an echo value will echo all messages to the output console.  These init() functions can be called in any combination, and the log messages will be routed to all destinations specified.  

The last init() function is for a socket.  Some embedded systems have network connectivity and an entire protocol stack.  If that's the case, it works well to route the log messages to another machine on the network and let it display/save the log messages.  This version is here as a place keeper, the code is not implemented.  While it may be nice to send the log messages out a socket on an embedded system, it is unruly to do so in a safety critical system unless the engineer groks the entire protocol stack.  Currently if a system has a network connection it is not safety critical.  

The logc(), logs(), logi() and logx() functions are provided to actually write the messages to the log on whatever destination has been specified by the init() functions.  The logc() function will write a single character, the logs() function will write a string, the logi() function will write an integer as a base 10 number, and the logx() function will write an integer as a hex value.  

OS Tracing

The trace functionality will record operating system events in a log.  It will specify which tasks originated or utilized the events, and provide a visual way to see how the execution of the program is progressing.  Tracing of the os_wrap events can be turned on and off by defining OSW_USE_EVENT_TRACE.  

Traceing writes a symbolized log to EEPROM, that allows for a post-mortum to see what events traspired prior to the end of the last run.
A sample run may look like:

0 T0 Tc 5Hz
121 T0 Tc 1sec
278 T0 Tc 5sec
2415 osw_tasks_go
2809 T1 Mget80
2809 T1 Qc osw_eventQ

The first column is the time-tick.
The next column is T<xxx>, where xxx is the task_idx.  Note that before tasks start running, it is a zero.  There can also exist a task 0 so they can only be distinguished by context.
The third column is the action that has been preformed, along with any extra information such as strings of values.

These are the abreviations:
T<tid>           Task and task id (tid)
Tc <taskname>    Task create and name
Td               Task delete
Qc <qname>       Message Q create and name
Qt <qname>       Message Q tee and name
Qut <qname>      Message Q un-tee and name
QR <numbytes>    Message Q receive and number of bytes
QS <numbytes>    Message Q send and number of bytes
QF               Message Q flush
SW <numbytes>    Shared memory write and number of bytes
SR <numbytes>    Shared memory read and number of bytes
Sc <semname>     Semaphore create and name
ST               Semaphore take
SG               Semaphore give
St <semname>     Semaphore tee and name
Sut <semname>    Semaphore un-tee and name
SCc <semname>    Counting semaphore create and name
SCT <semcount>   Counting semaphore take and the count
SCG <semcount>   Counting semaphore give and the count
SCF              Counting semaphore flush
EVP <evtnumber>  Event publish and number (event id)
EVR <evtnumber>  Event register and number
Mget <numbytes>  Memory malloc and number of bytes
Mfree0x <ptr>    Memory free call for memory pointer
Timeout          Timer timeout.
exit             Exit and quit.

User defined strings can be "injected" into the log.

The API of the trace capability is:

//  Start and end of EEPROM memory to use for the trace.
//  Does not include end byte.  [start..end)
#define OSW_TRACE_EEPROM_START (0)
#define OSW_TRACE_EEPROM_END (OSW_ODOMETER_EEPROM_ADDRESS) //avoid the odometer

//  The user can inject a string into the osw trace.
void osw_trace_inject(char* _str);
void osw_trace_on(void);
void osw_trace_off(void);
//  Dumps the memory to the serial port.
void osw_dump_EEPROM_trace(void);
//  Flushes the trace buffers (if they exist) (i.e. to a file).
void osw_trace_flush(void);

As with the system log above, the trace can be sent to the console, to a file, to a socket, or to a block of memory.  In fact, the trace system instantiates an osw_log to perform the actual writing of the data.  For Arduino, only writing to EEPROM and echo-ing to the serial port are implemented.  

The osw_trace_inject () function allows for a user defined string to be entered into the trace log.  The trace functionality can be turned on or off by the application code by calling osw_trace_on () and osw_trace_off ().  In this way only the parts of the code that are under investigation can be traced.  One of the parameters in the taskCreate() function is _osw_trace value.  If a task is running at a very high iteration rate, it is better to turn off tracing for that task, so that other less frequent tasks can become apparent.  Or if a task is debugged, the event tracing can be turned off so that the other tasks can be debugged easier.  

The osw_dump_EEPROM_trace () routine is a utility function that can be used during a post-mortem, it dumps the contents of EEPROM used by the trace.  If OSW_TRACE_DUMP_PREV_RUN is defined, then the previous run's EEPROM record will be dumped to the serial port at the beginning of each run.

Three other defines are used by the trace routine. OSW_TRACE_TIME, puts a time stamp, (hours, minutes, seconds, millisecs) since the start of the run on each log entry.  (This consumes a lot of memory, and not recommended for Arduino.) OSW_TRACE_TICK just starts each line with the current time tick, as shown in the example above.  And OSW_TRACE_ECHO will echo the log entries out the serial port as they happen.

The memory is written in ASCII.  Which, for some purists that would sound like an exorbitant waste of space.  But ASCII uses one byte per character.  Writing the trace log in binary would require nearly as much memory.  So the savings is not that much, plus the ASCII output is immediately readable without the need of a post-processing interpreter of some sort. 

Using the trace facilities on the Arduino board significantly slows down the execution of the code.  Be aware of this when tracing code that requires careful timing.  


Utility Functions

Most of the utility functions needed by os_wrap are function that are in the standard libraries.  But to make os_wrap independent of the standard libraries, only the function that are needed were reproduced by hand.  These function include: 

int strlen(char* _s);
void strcpy(char* _dest, char* _source);
void strncpy(char* _dest, char* _source, int _len);
void strcat(char* _dest, char* _source);
void strncat(char* _dest, char* _source, int _len);
int memcpy(void* _dest, void* _source, long _size);

Which are the standard C function for string length, string copy, string concatenation, and memory block copy.

Other functions that are needed are the itoa() that turns any number into a string, and is designed to work for any base 2 .. 36, at which point it runs out of numbers and letters of the alphabet.  If a base is outside that range it will return 0.  As described in K&R, it makes use of a reverse() function that reverses a string in place:

//  K&R pg 62
//  reverse:  reverse string s in place.
void reverse(char s[]);
//  K&R pg 64
char* itoa(long n, int base = 10);

The osw_error() function is used to post an error, and should be updated for each implementation.  

The err2str function allows a translation from os_wrap error numbers to strings.  For Arduino, this is more involved since to save ram, the strings are stored in program memory.  

Arduino Specific Functions

The memoryFree() function is copied from the Arduino Cookbook, page 535, by Michael Margolis.  It give the amount of free ram there is in the Arduino system.  Useful when using the library malloc() and free() commands.

The printP() function allows functions to print strings that are stored in program memory, it is copied from the Arduino Cookbook, page 540, by Michael Margolis.

The following are EEPROM routines that are used by os_wrap.  The routines provided with Arduino in eeprom.h are incomplete:

int eepromRead8(int _addr);
void eepromWrite8(int _addr, int _value);
int eepromRead16(int _addr);
void eepromWrite16(int _addr, int _value);
long eepromRead32(int _addr);
void eepromWrite32(int _addr, long _value);
//  Gives a hex/ascii-dump of the eeprom memory.
void xdumpEEPROM(void);
//  Writes all of EEPROM with 0xff. (as it comes in new boards)
void clearEEPROM(void);

Odometer

The odometer keeps track of uptime, the time since last reboot, and the total time the board has been used.  In order to keep track of total time over power cycles the odometer keeps it's values in EEPROM. OSW_ODOMETER_EEPROM_ADDRESS is the address in EEPROM where the odometer is kept.  

#define OSW_ODOMETER_EEPROM_ADDRESS  (1016)

The odometer uses two 4-byte int's to double buffer the odometer value.  So, for example, if the OSW_ODOMETER_EEPROM_ADDRESS is 1016, the odometer will use the addresses from [1016..1023].  It's up to the user not to overwrite the odometer.  (There's no way to protect it, you can only call dibs for it.)

The tenths of hours that the odometer and uptime has been running. If included in every sketch, it measures how long the board has been used.  uptime measures how long the board's been up since it's last boot.

extern unsigned long uptime_tenths_of_hours;
extern unsigned long odometer_tenths_of_hours;

The odometer_main_loop can be called manually, periodically, if tasks are not used.  No harm in calling it manually, even if it's being called periodically in it's task.

void* odometer_main_loop(void* _pNotUsed = OSW_NULL);

Defining the OSW_USE_ODOMETER_ARDUINO switch will incorporate the odometer into the os_wrap environment.  With the OSW_ODOMETER_USE_TASK switch set,  the odometer_main_loop() will be run as a task with no further user intervention. The OSW_ODOMETER_PRINT_6MIN switch will echo uptime and odometer values to the serial port every 10th of a minute.

Conclusion

The original intent of the os_wrap routines was to develop a framework where the same application code could be run in the multi-tasking VxWorks environment, and the DOS single threaded console environment.  The framework is rich enough with elements like semaphores and message queues so that non-trivial programs could be developed and deployed with it.

