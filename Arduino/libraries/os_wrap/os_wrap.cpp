///////////////////////////////////////////////////////////////////////////
// os_wrap.cc
///////////////////////////////////////////////////////////////////////////
//
//  ########   #  ####   ######    ######  ######    #####    #####  ######
//  #   #   #  #  #   #  #     #  #        #     #  #     #  #       #
//  #   #   #  #  #   #  #     #   #####   ######   #######  #       ######
//  #   #   #  #  #   #  #     #        #  #        #     #  #       #
//  #   #   #  #  #   #  ######   ######   #        #     #   #####  ######
//  R=========E=========S=========E=========A=========R=========C=========H
//
//                        Computing the World Within
//
//  MindSpace Research, Est. September 24, 1999
//
///////////////////////////////////////////////////////////////////////////
// 990223  dwendel Initial Wapper for VxWorks to work in DOS.
// 070821  dwendel Wrapper for UNIX POSIX functions.
// 080808  dwendel Created a Safety Critical version of os_wrap.cpp/h.
// 110430  dwendel Ported to Arduino, limited space, strip to min funcs.
///////////////////////////////////////////////////////////////////////////


#include"os_wrap.h"

/////////////////////////////////////////////////
//  Version string of os_wrap, and error reporting
/////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_version
//  Description: Returns the version string of os_wrap
//
//  Inputs: none.
//  Outputs: The version string.
//////////////////////////////////////////////////////////////////////////////
char* osw_version(void) {
  return OS_WRAP_VERSION;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_error
//  Description: Generic error routines for os_wrap.  Takes an error number
//  and prints out it's corresponding string.
//
//  Inputs: errno (predefined error numbers)
//  Outputs: Prints the error string to Serial port.
//////////////////////////////////////////////////////////////////////////////
void osw_error(int _errorno)
{
#ifdef OSW_PRINT_ERRORS
#ifdef OSW_USE_SERIAL_IO
  Serial.println(err2str(_errorno));
#endif
#endif
}

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_error
//  Description: Generic error routines for os_wrap.
//
//  Inputs: User defined string.
//  Outputs: Prints the string to Serial port.
//////////////////////////////////////////////////////////////////////////////
void osw_error(char* _errstr)
{
#ifdef OSW_PRINT_ERRORS
#ifdef OSW_USE_SERIAL_IO
  Serial.println(_errstr);
#endif
#endif
}

/////////////////////////////////////////////////
//  Arduino Specific Functions
/////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////////////
//  function:  memoryFree
//  Description: The memoryFree() function return how much free RAM is
//    currently available on the board.  Was taken from Arduino Cookbook,
//    by Michael Margolis, pg 535
//
//  Inputs: none.
//  Outputs: Value of free memory on the board.
//////////////////////////////////////////////////////////////////////////////
extern int __bss_end;
extern void* __brkval;

int memoryFree(void)
{
  int freeValue;
  if ((int)__brkval == 0) {
    freeValue = ((int)&freeValue) - ((int)&__bss_end);
  } else {
    freeValue = ((int)&freeValue) - ((int)__brkval);
  }
  return freeValue;  
}

//  Put as many string constants in program memory as possible.
const unsigned char err5001P[] PROGMEM = "OSW_MEM_ALLOC_FAILED";     //(-5001)
const unsigned char err5002P[] PROGMEM = "OSW_UNALLOCATED_MEM";      //(-5002)
const unsigned char err5003P[] PROGMEM = "OSW_EXCEED_MAX_SIZE";      //(-5003)
const unsigned char err5004P[] PROGMEM = "OSW_TOO_MANY_TEES";        //(-5004)
const unsigned char err5005P[] PROGMEM = "OSW_UNTEE_ERROR";          //(-5005)
const unsigned char err5006P[] PROGMEM = "OSW_MSG_Q_FULL_BUMP";      //(-5006)
const unsigned char err5007P[] PROGMEM = "OSW_MSG_Q_FULL_REJECT";    //(-5007)
const unsigned char err5008P[] PROGMEM = "OSW_PKD_Q_FULL";           //(-5008)
const unsigned char err5009P[] PROGMEM = "OSW_TOO_MANY_TASKS";       //(-5009)
const unsigned char err5010P[] PROGMEM = "OSW_TASK_NOT_FOUND";       //(-5010)
const unsigned char err5011P[] PROGMEM = "OSW_UNDER_MIN_SIZE";       //(-5011)
const unsigned char err5012P[] PROGMEM = "OSW_INVALID_PARAMETER";    //(-5012)
const unsigned char err5013P[] PROGMEM = "OSW_TOO_MANY_EVENT_PAIRS"; //(-5013)
const unsigned char err5014P[] PROGMEM = "OSW_MEM_VALID_FAIL";       //(-5014)
const unsigned char err5015P[] PROGMEM = "OSW_TIMEOUT";              //(-5015)
const unsigned char err5016P[] PROGMEM = "OSW_ALREADY_INITIALIZED";  //(-5016)
const unsigned char err5017P[] PROGMEM = "OSW_SHARED_MEM_NULL";      //(-5017)
const unsigned char err5018P[] PROGMEM = "OSW_SHARED_MEM_BUSY";      //(-5018)
const unsigned char err5019P[] PROGMEM = "OSW_EVENT_SEND_FAIL";      //(-5019)
const unsigned char err5020P[] PROGMEM = "OSW_PRI_Q_FULL_REJECT";    //(-5020)
const unsigned char err5021P[] PROGMEM = "OSW_PRI_Q_PRI_NOT_FOUND";  //(-5021)
const unsigned char err5022P[] PROGMEM = "OSW_PRI_Q_FREE_NOT_FOUND"; //(-5022)
const unsigned char err5023P[] PROGMEM = "OSW_PRI_Q_BUMP_PRI_HEAD";  //(-5023)
const unsigned char err5024P[] PROGMEM = "OSW_PRI_Q_BUMP_LOW_HEAD";  //(-5024)
const unsigned char err5025P[] PROGMEM = "OSW_PRI_Q_BUMP_LOW_TAIL";  //(-5025)
const unsigned char err5026P[] PROGMEM = "OSW_PRI_Q_TOO_MANY_PRI";   //(-5026)
const unsigned char err5027P[] PROGMEM = "OSW_GENERAL_ERROR";        //(-5027)

//  Seriously ugly, but Arduino and C don't give you a choice,
//  double maintenance, if you ever want to change the list of errors.
#define err2pMsg(x) ((x==OSW_MEM_ALLOC_FAILED)     ? err5001P : \
                    (x==OSW_UNALLOCATED_MEM)      ?  err5002P : \
                    (x==OSW_EXCEED_MAX_SIZE)      ?  err5003P : \
                    (x==OSW_TOO_MANY_TEES)        ?  err5004P : \
                    (x==OSW_UNTEE_ERROR)          ?  err5005P : \
                    (x==OSW_MSG_Q_FULL_BUMP)      ?  err5006P : \
                    (x==OSW_MSG_Q_FULL_REJECT)    ?  err5007P : \
                    (x==OSW_PKD_Q_FULL)           ?  err5008P : \
                    (x==OSW_TOO_MANY_TASKS)       ?  err5009P : \
                    (x==OSW_TASK_NOT_FOUND)       ?  err5010P : \
                    (x==OSW_UNDER_MIN_SIZE)       ?  err5011P : \
                    (x==OSW_INVALID_PARAMETER)    ?  err5012P : \
                    (x==OSW_TOO_MANY_EVENT_PAIRS) ?  err5013P : \
                    (x==OSW_MEM_VALID_FAIL)       ?  err5014P : \
                    (x==OSW_TIMEOUT)              ?  err5015P : \
                    (x==OSW_ALREADY_INITIALIZED)  ?  err5016P : \
                    (x==OSW_SHARED_MEM_NULL)      ?  err5017P : \
                    (x==OSW_SHARED_MEM_BUSY)      ?  err5018P : \
                    (x==OSW_EVENT_SEND_FAIL)      ?  err5019P : \
                    (x==OSW_PRI_Q_FULL_REJECT)    ?  err5020P : \
                    (x==OSW_PRI_Q_PRI_NOT_FOUND)  ?  err5021P : \
                    (x==OSW_PRI_Q_FREE_NOT_FOUND) ?  err5022P : \
                    (x==OSW_PRI_Q_BUMP_PRI_HEAD)  ?  err5023P : \
                    (x==OSW_PRI_Q_BUMP_LOW_HEAD)  ?  err5024P : \
                    (x==OSW_PRI_Q_BUMP_LOW_TAIL)  ?  err5025P : \
                    (x==OSW_PRI_Q_TOO_MANY_PRI)   ?  err5026P : \
                    err5027P)

//////////////////////////////////////////////////////////////////////////////
//  function:  printP
//  Description: The printP() function prints a string that has been
//    stored in program memory (instead of RAM), using Serial.
//    The _new_line parameter implements putting a new line at the
//    end of the string or not.  Was taken from Arduino Cookbook, by
//    Michaael Margolis, pg 540
//
//  Inputs: Program memory error string, and new line.
//  Outputs: Prints the string to the serial port.
//////////////////////////////////////////////////////////////////////////////
void printP(const unsigned char* _str, bool _new_line)
{
#ifdef OSW_USE_SERIAL_IO
  char c;
  while ((c = pgm_read_byte(_str++)))
    //Serial.print(c, BYTE);
    Serial.print(c);
  if (_new_line) Serial.print('\n');
#endif
}

//////////////////////////////////////////////////////////////////////////////
//  function:  err2str
//  Description: Utility function to take error messages stored in
//    program memory and deliver them as strings.
//
//    Note that this function uses 40 bytes static memory for the string.
//    I didn't see any way around that.  For Arduino 40 bytes is a lot.
//
//  Inputs: Program memory error number.
//  Outputs: The usable string out of program memory.
//////////////////////////////////////////////////////////////////////////////
char* err2str(int _errorno)
{
  const unsigned char* _str = err2pMsg(_errorno);
  static char c[40];
  int i = 0;
  while ((i < 40) && (c[i] = pgm_read_byte(_str++))) ++i;
  return c;
}

/////////////////////////////////////////////////
//  The Odometer  (total time powered on)
/////////////////////////////////////////////////

//  Odometer uses two 4-byte int's to double buffer the odometer value.
//  So, for example, if the OSW_ODOMETER_EEPROM_ADDRESS is 1016, the
//  odometer will use the addresses from [1016..1023].  It's up to the
//  user not to overwrite the odometer.  (There's no way to protect it.)

//  This is the number of tenths of hours that the odometer
//  has been running. If included in every sketch, it measures how long
//  the board has been used.  uptime measures how much time has
//  elapsed since the last reboot.
unsigned long uptime_tenths_of_hours = 0;
unsigned long odometer_tenths_of_hours = 0;

#ifdef OSW_USE_ODOMETER_ARDUINO
class odometer
{
  //osw_dt_timer min6_;
  unsigned long min6_;
  osw_task odem_task_;
  int addr_;
  bool first_time_;
  const int base_addr_;
  public:
    odometer();
    //  If you want an odometer but are not using os_wrap tasks,
    //  you can use this class, but the odom.odometer_main_loop() call
    //  needs to be added to the loop() function of the sketch.
    void main_loop(void);
    void print_uptime(void);
    //  Actually, for a new ardrino board, the EEPROM defaults to all f's,
    //  i.e. 0xff,0xff,0xff,0xff so the first increment rolls over and takes
    //  it to all zeros.
    //  Mostly, it's used to manually restore odometer value when
    //  they've been walked on by other code.
    void set_odem_memory(unsigned long _tenths_of_hours);
} odom;

//////////////////////////////////////////////////////////////////////////////
//  function:  odometer_main_loop
//  Description: The odometer_main_loop can be called manually,
//    periodically, if tasks are not used.  No harm in calling it,
//    even with it's performed by a task.
//
//  Inputs: Program memory error string.
//  Outputs: The usable string out of program memory.
//////////////////////////////////////////////////////////////////////////////
void* odometer_main_loop(void* _pNotUsed)
{
  odom.main_loop();
  return NULL;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  odometer
//  Description: Constructor.
//
//  Inputs: None.
//  Outputs: None.
//////////////////////////////////////////////////////////////////////////////
odometer::odometer():base_addr_(OSW_ODOMETER_EEPROM_ADDRESS)
{
  min6_ = millis();
  first_time_ = true;
  addr_ = base_addr_;
#ifdef OSW_ODOMETER_USE_TASK
  odem_task_.taskCreate("tOdometer", odometer_main_loop, OSW_NULL, 100);
#endif
  //set_odem_memory(4000); // manual restore to 400.0 hours.
}

//////////////////////////////////////////////////////////////////////////////
//  function:  print_uptime
//  Description: Prints uptime and odometer values to Serial port.
//
//  Inputs: None.
//  Outputs: None.
//////////////////////////////////////////////////////////////////////////////
void odometer::print_uptime(void)
{
#ifdef OSW_USE_SERIAL_IO
  Serial.print("uptime: ");
  Serial.print(uptime_tenths_of_hours / 10);
  Serial.print('.');
  Serial.print(uptime_tenths_of_hours % 10);
  Serial.print("  ");
  Serial.print(odometer_tenths_of_hours / 10);
  Serial.print('.');
  Serial.println(odometer_tenths_of_hours % 10);
#endif
}

//////////////////////////////////////////////////////////////////////////////
//  function:  main_loop
//  Description: Odometer's main loop, needs to be called periodically.
//    Either run as a periodic task, or can be called manually.  But
//    both ways it is called through the c function odometer_main_loop(),
//    above.
//
//  Inputs: None.
//  Outputs: None.
//////////////////////////////////////////////////////////////////////////////
void odometer::main_loop(void)
{
  if (first_time_) {
    //  Read both buffers and see which one is biggest.
    unsigned long tmp;
    tmp = eepromRead32(base_addr_);
    odometer_tenths_of_hours = eepromRead32(base_addr_ + 4);
    //  Set biggest value, and the address of where to write next.
    if (tmp > odometer_tenths_of_hours) odometer_tenths_of_hours = tmp;
    else addr_ = base_addr_ + 4;
    first_time_ = false;
#ifdef OSW_ODOMETER_PRINT_6MIN
    print_uptime();
#endif
  }
  //  if 6 minutes has past (1/10 of an hour).
  if ((millis() - min6_) < 360000) return;
  //  reset timestamp, and increment the odometer.
  min6_ = millis();
  ++uptime_tenths_of_hours;
  ++odometer_tenths_of_hours;
  // Toggle which buffer to write to, (double buffer or ping-pong buffer)
  if (addr_ == base_addr_) addr_ = base_addr_ + 4;
  else addr_ = base_addr_;
  //  Write it to EEPROM.
  eepromWrite32(addr_, odometer_tenths_of_hours);
#ifdef OSW_ODOMETER_PRINT_6MIN
  print_uptime();
#endif
}

//////////////////////////////////////////////////////////////////////////////
//  function:  set_odem_memory
//  Description:  Manually set the odometer value.  Useful if the odometer
//    was accidentally overwritten by other code using EEPROM. It is not
//    necessary to set a new board to 0, because for a new arduino boards,
//    it comes with EEPROM cleared to all 0xff's.  So the very first
//    increment will rollover to zero.
//
//  Inputs: None.
//  Outputs: None.
//////////////////////////////////////////////////////////////////////////////
void odometer::set_odem_memory(unsigned long _tenths_of_hours)
{
  eepromWrite32(base_addr_, _tenths_of_hours);
  eepromWrite32(base_addr_ + 4, _tenths_of_hours);
}

#endif  //OSW_USE_ODOMETER_ARDUINO


/////////////////////////////////////////////////
//  The EEPROM routines.  (Use instead of EEPROM.h)
/////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////////////
//  function:  xdumpEEPROM
//  Description: dumps the EEPROM buffer to the serial port.
//  Inputs: none
//  Outputs: none.
//////////////////////////////////////////////////////////////////////////////
void xdumpEEPROM(void)
{
#ifdef OSW_USE_SERIAL_IO
  int val;
  char ascii[20] = {0};
  int idx = 0;
  Serial.println();
  for (int i=0; i<1024; ++i) {
    val = eeprom_read_byte((uint8_t*)i);
    // See if val is a printable ASCII character.
    if ((val >= ' ') && (val <= 'z')) ascii[idx] = val;
    else ascii[idx] = '.';
    ++idx;
    // print val as a hex value
    if (val < 16) Serial.print('0');  // leading zero
    Serial.print(val, HEX);
    // take care of spaces and new lines.
    if (!((i+1) %4)) Serial.print(' ');
    if (!((i+1) %16)) {
      Serial.print("  ");
      Serial.println(ascii);
      idx = 0;
    }
  }
  Serial.println();
#endif
}

//////////////////////////////////////////////////////////////////////////////
//  function:  clearEEPROM
//  Description: resets the EEPROM memory to all 0xff's.
//
//  Inputs: none
//  Outputs: none.
//////////////////////////////////////////////////////////////////////////////
void clearEEPROM(void)
{
  for (int i=0; i<1024; ++i) {
    eeprom_write_byte((uint8_t*)i, 0xff);
  }
}

//////////////////////////////////////////////////////////////////////////////
//  function:  eepromRead8
//             eepromWrite8
//             eepromRead16
//             eepromWrite16
//             eepromRead32
//             eepromWrite32
//  Description: Some EEPROM routines.  Can use these instead of the
//    EEPROM.h that is included with Arduino.
//
//  Inputs: Addresses and values to write.
//  Outputs: value that have been read.
//////////////////////////////////////////////////////////////////////////////
//  Some EEPROM routines.  Can use these instead of the EEPROM.h that
//  is included with Arduino.
int eepromRead8(int _addr)
{
  int retval;
  retval = eeprom_read_byte((uint8_t*)_addr);
  return retval;
}

void eepromWrite8(int _addr, int _value)
{
  eeprom_write_byte((uint8_t*)_addr, (_value & 0xff));
}

int eepromRead16(int _addr)
{
  int retval;
  char* tmp = (char*)&retval;
  tmp[0] = eeprom_read_byte((uint8_t*)_addr);
  tmp[1] = eeprom_read_byte((uint8_t*)_addr+1);
  return retval;
}

void eepromWrite16(int _addr, int _value)
{
  //  see logic note in eepromWrite32(), below.
  char* tmp = (char*)&_value;
  eeprom_write_byte((uint8_t*)_addr,   tmp[0]);
  eeprom_write_byte((uint8_t*)_addr+1, tmp[1]);
}

long eepromRead32(int _addr)
{
  long retval;
  char* tmp = (char*)&retval;
  tmp[0] = eeprom_read_byte((uint8_t*)_addr);
  tmp[1] = eeprom_read_byte((uint8_t*)_addr+1);
  tmp[2] = eeprom_read_byte((uint8_t*)_addr+2);
  tmp[3] = eeprom_read_byte((uint8_t*)_addr+3);
  return retval;
}

void eepromWrite32(int _addr, long _value)
{
  //  Logic note:  Write the least significant byte first.  That way
  //  if power goes out half way through this sequence, the value will
  //  jump back instead of jumping forward.
  //
  //  For example:
  //  If the old value was 0x1ff and the new value is 0x200 if we wrote
  //  most significant byte first, then power could to out when the
  //  value in EEPROM is 0x2ff, jumping head by 255.  If we write
  //  the least signicant byte first, then the power could go out
  //  with the EEPROM value of 0x100.  Jumping back by 255.
  //
  //  This is why applications that use EEPROM, like the Odometer,
  //  should always double buffer variables stored in EEPROM, and
  //  depend on any incomplete writes to be less than (jumping back)
  //  the desired value.
  char* tmp = (char*)&_value;
  eeprom_write_byte((uint8_t*)_addr,   tmp[0]);
  eeprom_write_byte((uint8_t*)_addr+1, tmp[1]);
  eeprom_write_byte((uint8_t*)_addr+2, tmp[2]);
  eeprom_write_byte((uint8_t*)_addr+3, tmp[3]);
}

/////////////////////////////////////////////////
//  Trace Declaration, out of the .h file but
//  needs to be delared close to the top here
//  so that everyone can use it.
/////////////////////////////////////////////////

enum osw_trace_enum {
   OSW_TASK_CREATE, OSW_TASK_DELETE, OSW_TASK_START, OSW_TASK_STOP,
   OSW_Q_CREATE, OSW_Q_TEE, OSW_Q_UNTEE, OSW_Q_RECEIVE, OSW_Q_SEND, OSW_Q_FLUSH,
   OSW_CSEM_CREATE, OSW_CSEM_TAKE, OSW_CSEM_GIVE, OSW_CSEM_FLUSH,
   OSW_BSEM_CREATE, OSW_BSEM_TAKE, OSW_BSEM_GIVE, OSW_BSEM_TEE, OSW_BSEM_UNTEE,
   OSW_EVT_PUBLISH, OSW_EVT_REGISTER,
   OSW_SHARED_WRITE, OSW_SHARED_READ,
   OSW_MEM_MALLOC, OSW_MEM_FREE,
   OSW_WAIT_TIMEOUT,
   OSW_EXIT};

void osw_put_trace(osw_trace_enum _event, int _val = 0);

/////////////////////////////////////////////////
//  memory manager.
//  based on the K&R example pg 185-189
/////////////////////////////////////////////////

#ifdef OSW_USE_STDMEM
//  Here the memory manager will use standare malloc and free.

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_malloc
//  Description: Calls malloc().
//
//  Inputs: Number of bytes.
//  Outputs: Pointer to memory buffer.
//////////////////////////////////////////////////////////////////////////////
osw_mem_t osw_malloc(int _num_bytes) {
  osw_put_trace(OSW_MEM_MALLOC, _num_bytes);
  return malloc(_num_bytes);
}

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_free
//  Description: Calls free().
//
//  Inputs: Pointer to memory buffer.
//  Outputs: OSW_OK.
//////////////////////////////////////////////////////////////////////////////
int osw_free(osw_mem_t _location) {
  osw_put_trace(OSW_MEM_FREE, (int)_location);
  free(_location);
  _location = OSW_NULL;
  return OSW_OK;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_mem_check
//  Description: Does nothing.  There is no stdlib.h counterpart for
//    this function.
//
//  Inputs: Pointer to memory buffer.
//  Outputs: OSW_OK.
//////////////////////////////////////////////////////////////////////////////
int osw_mem_check(osw_mem_t _location) {
  return OSW_OK;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_print_mem_free
//  Description: Prints memoryFree() to the serial port.
//
//  Inputs: none.
//  Outputs: none.
//////////////////////////////////////////////////////////////////////////////
void osw_print_mem_free(void) {
#ifdef OSW_USE_SERIAL_IO
  //  The Arduino memoryFree();
  Serial.print("memFree: ");
  Serial.println(memoryFree());
#endif
}

#else

class osw_memory
{
  public:
    osw_memory(void* _address = OSW_NULL, int _size = 0);
    ~osw_memory();
    osw_mem_t malloc(int _num_bytes);
    int free(osw_mem_t _location);
    int checkMem(osw_mem_t _location);
    void printFreeList(void);
  private:
    struct free_rec {
      unsigned long size;
      union {
        unsigned long integrity;
        free_rec* pNext;
      };
    };
    free_rec* pBase_;
    free_rec* pFree_;
    unsigned long* find_end_int(free_rec* _pRec);
};

const unsigned long MEM_INTEGRITY_VAL = 0xAA55AA55;

//  This is an example of setting up the memory manager to manage
//  a block of contiguous memory.

static char osw_mem_block[OSW_HEAP_SIZE];
static osw_memory mem((void*)osw_mem_block, OSW_HEAP_SIZE);

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_malloc
//             osw_free
//             osw_mem_check
//             osw_print_mem_free
//  Description: c wrapper functions for the call in the osw_memory class.
//
//  Inputs: Number of bytes.
//  Outputs: Pointer to memory buffer.
//////////////////////////////////////////////////////////////////////////////
osw_mem_t osw_malloc(int _num_bytes) {return mem.malloc(_num_bytes);}
int osw_free(osw_mem_t _location) {return mem.free(_location);}
int osw_mem_check(osw_mem_t _location) {return mem.checkMem(_location);}
void osw_print_mem_free(void) {mem.printFreeList();}

//////////////////////////////////////////////////////////////////////////////
//  function:  find_end_int
//  Description: internal function, find the start of the next memory block.
//    Returns a pointer to the address of memory immediatly folling
//    this _pRec.
//
//  Inputs: Pointer to memory buffer.
//  Outputs: Pointer to memory buffer.
//////////////////////////////////////////////////////////////////////////////
unsigned long* osw_memory::find_end_int(free_rec* _pRec)
{
  return ((unsigned long*)((char*)_pRec + _pRec->size + sizeof(free_rec)));
}

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_memory
//  Description: Constructor. If using stdlib, this does nothing.
//  Inputs: none
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
osw_memory::osw_memory(void* _address, int _size)
{
  if (_address == OSW_NULL) return;
  pBase_ = (free_rec*)_address; //osw_mem_block;
  //pBase_ = (free_rec*)align4((int)pBase_);
  pBase_->pNext = OSW_NULL;  // closes the loop
  //  compute the usable aligned space:
  if ((_size - 4) < sizeof(free_rec)) pBase_->size = 0;
  else pBase_->size = /*align4*/(_size - sizeof(free_rec) - 4);
  pFree_ = pBase_;
} // osw_memory::osw_memory()

osw_memory::~osw_memory() {}

//////////////////////////////////////////////////////////////////////////////
//  function:  malloc
//  Description: allocates a block of memory
//
//  Inputs: the number of bytes to get.
//  Outputs:
//    The address of the block of memory allocated.
//    OSW_NULL: allocation failed or out of memory.
//////////////////////////////////////////////////////////////////////////////
osw_mem_t osw_memory::malloc(int _num_bytes)
{
  osw_put_trace(OSW_MEM_MALLOC, _num_bytes);
  free_rec *p, *prevp;
  
  // allocate at least one byte.
  if (_num_bytes == 0) ++_num_bytes;
  //_num_bytes = align4(_num_bytes);
  p = pFree_;
  prevp = pFree_;
  
  //  search for a place in the free list big enough for user space + the
  //  end int-val word + the next record
  while ((sizeof(free_rec) + _num_bytes + 4 + sizeof(free_rec) > p->size) &&
         (p->pNext != OSW_NULL)) {
    prevp = p;
    p = p->pNext;
  }
  
  if (sizeof(free_rec) + _num_bytes + 4 + sizeof(free_rec) > p->size) { // out of memory
    // post error
    osw_error(OSW_MEM_ALLOC_FAILED);
    osw_trace_inject(err2str(OSW_MEM_ALLOC_FAILED));
    return OSW_NULL;
  }
  
  //  if execution reaches here, p contains the free space we want.
  free_rec* retval = p;
  int size = _num_bytes +        // user space
             sizeof(free_rec) +  // size, and int-val words before user space
             4;                  // int-val at end of user space
  
  // tmp is the location of where the free record starts now.
  free_rec* tmp = (free_rec*)((char*)p + size);
  if (tmp == p->pNext) { // perfect fit
    prevp->pNext = p->pNext;
  } else {
    tmp->size = p->size - size;
    tmp->pNext = p->pNext;
    if (prevp != p) prevp->pNext = tmp;
    if (p == pFree_) pFree_ = tmp;
  }
  
  // fill the record for
  retval->size = _num_bytes;
  retval->integrity = MEM_INTEGRITY_VAL;
  *find_end_int(retval) = MEM_INTEGRITY_VAL;
  return (osw_mem_t) ((long*)&(retval->pNext)+1);
} //osw_memory::get()

//////////////////////////////////////////////////////////////////////////////
//  function:  free
//  Description: frees a block of memory
//
//  Inputs: the pointer to the block of memory.
//  Outputs:
//    OSW_OK: success
//    OSW_INVALID_PARAMETER: if _location is invalid
//    OSW_MEM_VALID_FAIL: if memory bounds were overwritten.
//////////////////////////////////////////////////////////////////////////////
int osw_memory::free(osw_mem_t _location)
{
  osw_put_trace(OSW_MEM_FREE, (int)_location);
  if (_location == OSW_NULL) return OSW_INVALID_PARAMETER;
  
  int retval = checkMem(_location);
  if (retval != OSW_OK) return retval;
  
  free_rec* new_rec = (free_rec*)((long*)_location - 2); //long* arithmetic
  //  clear the location.
  _location = OSW_NULL;
  unsigned long* end = find_end_int(new_rec);
  
  new_rec->size = sizeof(free_rec) + new_rec->size  + 4;
  new_rec->pNext = OSW_NULL;
  
  free_rec* next_rec = (free_rec*)(end + 1);
  free_rec *p, *prevp;
  free_rec* prev_end = OSW_NULL;
  p = pFree_;
  prevp = OSW_NULL; //pFree_;
  
  //  find the place in the free list.
  while ((p != OSW_NULL) && (next_rec > p) && (prev_end != new_rec)) {
    prevp = p;
    p = p->pNext;
    prev_end = (free_rec*)((char*)(prevp) + prevp->size);
  }
  
  // if the new rec is butted up agaist the prev record.
  if (new_rec == prev_end) {
    prevp->size = prevp->size + new_rec->size;
    new_rec = prevp;
  } else {
    if (prevp != OSW_NULL) {
      new_rec->pNext = prevp->pNext;
      prevp->pNext = new_rec;
    }
  }
  
  //  if the new rec is butted up against the next record.
  if (next_rec == p) {
    new_rec->size = new_rec->size + p->size;
    new_rec->pNext = p->pNext;
    if (p == pFree_) pFree_ = new_rec;
  } else {
    //  if the new rec is NOT butted agaist the next record.
    if (new_rec->pNext == OSW_NULL) new_rec->pNext = p;
    if (p == pFree_) pFree_ = new_rec;
  }
  return OSW_OK;
} //osw_memory::cancel()

//////////////////////////////////////////////////////////////////////////////
//  function:  checkMem
//  Description: Checks to see if the memory block bounds are still valid.
//               Used for debugging.
//
//  Inputs: the pointer to the block of memory.
//  Outputs:
//    OSW_OK: success
//    OSW_INVALID_PARAMETER: if _location is invalid
//    OSW_MEM_VALID_FAIL: if memory bounds were overwritten.
//////////////////////////////////////////////////////////////////////////////
int osw_memory::checkMem(osw_mem_t _location)
{
  if (_location == OSW_NULL) return OSW_INVALID_PARAMETER;
  
  free_rec* new_rec = (free_rec*)((long*)_location - 2); //long* arithmetic
  unsigned long* end = find_end_int(new_rec);
  
  if (new_rec->integrity != MEM_INTEGRITY_VAL) {
    osw_error(OSW_MEM_VALID_FAIL);
    osw_trace_inject(err2str(OSW_MEM_VALID_FAIL));
    return OSW_MEM_VALID_FAIL;
  }
  if (*end != MEM_INTEGRITY_VAL) {
    osw_error(OSW_MEM_VALID_FAIL);
    osw_trace_inject(err2str(OSW_MEM_VALID_FAIL));
    return OSW_MEM_VALID_FAIL;
  }
  return OSW_OK;
} //osw_memory::checkMem()

//////////////////////////////////////////////////////////////////////////////
//  function:  printFreeList
//  Description: Prints the records in the free list to the console.
//               Used for debugging.
//
//  Inputs: none
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
void osw_memory::printFreeList(void)
{
#ifdef OSW_USE_SERIAL_IO
  free_rec* p = pFree_;
  
  while (p != OSW_NULL) {
    //printf("%08x: Next:%08x: Size: %i\n", p, p->pNext, p->size);
    Serial.print("pFree:0x");
    Serial.print((int)p, HEX);
    Serial.print(": Next:0x");
    Serial.print((int)p->pNext, HEX);
    Serial.print(": Size: ");
    Serial.println(p->size);
    p = p->pNext;
  }
  //printf("\n");
#endif
} //osw_memory::printFreeList()


#endif  // ifndef OSW_USE_STDMEM


/////////////////////////////////////////////////
//  Time Functions
/////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_getTick
//  Description: This is the function that is the basis of all timing
//               functions.  This will be implementation specific for
//               each board and clock chip.  It is a polled function
//               that returns the number of millisecs form an arbitrary
//               point of time, either realtime, time since boot, or
//               time since program start.
//  Inputs: none
//  Outputs: tick count in ms.
//////////////////////////////////////////////////////////////////////////////
osw_tick_t osw_getTick(void) // ms
{
  return millis();
}

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_diffTime_ms
//  Description: This is the fundamental function to determine how much
//               time has passed.  Two ticks are passed in and the time
//               between them is returned in millisecs.  If the second
//               tick is 0 (default) the time between the old tick and
//               current time is returned.
//  Inputs: oldtime in ticks, and newtime in ticks (default 0)
//  Outputs: returns the time between old and new ticks.
//           if the newtick is 0 (default) then returns the time
//           between oldtime and current time.
//
//           Some extra logic was added to not return a negative number
//           when diffing time with current time.  This was necessary
//           for a project that had a clock that occasionally jumped backward.
//////////////////////////////////////////////////////////////////////////////
osw_tick_t osw_diffTime_ms(osw_tick_t _oldTime, osw_tick_t _newTime)
{
  if (_newTime == 0) {
    osw_tick_t tmp = osw_getTick() - _oldTime;
    if (tmp < 0) return 0;
    return tmp; // * OSW_MS_PER_TIC;  // Arduino doesn't need this conversion
  }
  return (_newTime - _oldTime);   // * OSW_MS_PER_TIC;  
}

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_ttoa
//  Description: Convert time (osw_getTick()) to a string.
//  Inputs: osw_tick_t type.
//  Outputs: The string "hh:mm:ss.sss"
//////////////////////////////////////////////////////////////////////////////
char* osw_ttoa(osw_tick_t _time)
{
  static char sysStr[20];
  //Serial.print(_time);
  //Serial.print(" ");
  int ms = _time % 1000;
  long secs = _time / 1000;
  long days = secs / 86400;
  secs %= 86400;
  long hrs = secs / 3600;
  secs %= 3600;
  long minutes = secs / 60;
  secs %= 60;
  //  sprintf uses a lot of resources (on Arduino), code around it.
  
  //  sprintf(sysStr, "%ldD:%02ld:%02ld:%02ld.%03d", days, hrs, minutes, secs, ms);
  //  return sysStr;
  
  //  The above single call to sprintf() is replaced with all the code below,
  //  it's a lot of lines of code, but it saves about 1K in program size.
  
  //  build the string in reverse, then reverse it.
  int idx = 0;
  long tmp = ms;
  // thousandth's of seconds
  int digit = tmp % 10;
  sysStr[idx] = digit + '0';
  ++idx;
  tmp /= 10;
  // hundreth's of seconds.
  digit = tmp % 10;
  sysStr[idx] = digit + '0';
  ++idx;
  tmp /= 10;
  // tenth's of seconds.
  //digit = tmp % 10;
  //sysStr[idx] = digit + '0';
  sysStr[idx] = tmp + '0';
  ++idx;
  //  '.'
  sysStr[idx] = '.';
  ++idx;
  //  seconds
  tmp = secs;
  digit = tmp % 10;
  sysStr[idx] = digit + '0';
  ++idx;
  tmp /= 10;
  //  tens of secs
  //digit = tmp % 10;
  //sysStr[idx] = digit + '0';
  sysStr[idx] = tmp + '0';
  ++idx;
  // ':'
  sysStr[idx] = ':';
  ++idx;
  //  minutes
  tmp = minutes;
  digit = tmp % 10;
  sysStr[idx] = digit + '0';
  ++idx;
  tmp /= 10;
  //  tens of minutes
  //digit = tmp % 10;
  //sysStr[idx] = digit + '0';
  sysStr[idx] = tmp + '0';
  ++idx;
  // ':'
  sysStr[idx] = ':';
  ++idx;
  //  hours
  tmp = hrs;
  digit = tmp % 10;
  sysStr[idx] = digit + '0';
  ++idx;
  tmp /= 10;
  //  tens of hours
  //digit = tmp % 10;
  //sysStr[idx] = digit + '0';
  sysStr[idx] = tmp + '0';
  ++idx;
  // 'D:'
  sysStr[idx] = ':';
  ++idx;
  sysStr[idx] = 'D';
  ++idx;
  //  days
  tmp = days;
  digit = tmp % 10;
  sysStr[idx] = digit + '0';
  ++idx;
  tmp /= 10;
  while (tmp != 0) {
    //  tens of days, hundreds of days, thousands of days, etc...
    digit = tmp % 10;
    sysStr[idx] = digit + '0';
    ++idx;
    tmp /= 10;
  }
  // finish up
  sysStr[idx] = '\0';
  reverse(sysStr);/**/
  
  return sysStr;
}


//////////////////////////////////////////////////////////////////////////////
//  function:  osw_delay class
//  Description: Used as a delay within the execution of a task.
//  Inputs:
//  Outputs:
//////////////////////////////////////////////////////////////////////////////
//  A delay class to do a delay in a task.  It is a non-blocking call that
//  will return 0 if the delay has not expired, or it will return
//  OSW_SINGLE_THREAD if it is not expired on a single threaded system.
//  It will return 1 and reset itself when the time has expired.
//
//  Example snippet:
//
//  void task1(void)
//  {
//    static osw_delay delay;
//    while(!done) {
//      if (delay.Delay(3000) != OSW_OK) {
//        return OSW_SINGLE_THREAD;
//      }
//
//      // Do task1 stuff here, every 3000 ms.
//    } // endwhile.
//  }
//
osw_delay::osw_delay():time(osw_getTick()), first_call(true)
{
}

int osw_delay::delay(osw_tick_t _ms)
{
  if (first_call) {
    time = osw_getTick();
    first_call = false;
  } else if (osw_diffTime_ms(time) > _ms) {
    first_call = true;
    return OSW_OK;
  }
  return OSW_SINGLE_THREAD;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_dt_timer class
//  Description: Used as a timer within the execution of a task.
//  Inputs:
//  Outputs:
//////////////////////////////////////////////////////////////////////////////
//  This is a timer that stays 'engaged' for a period of time,
//  then becomes 'timedOut' when it times out.
//
//  Uses osw_getTick() and osw_diffTime_ms() from os_wrap.
//
//  Set the timeout value in ms.
//  then after start(), engaged() will return true until timeout
//  is reached, then it will return false.
//  stop() makes engaged() timeout immediately, returning false.
//
//
//  time--> _________________________________
//  _______|                                 |____________________
//         <---msAge()---><---msTimeLeft()--->
//         <--constructor()                  <--engaged() == 0
//         <--start()                        <--timedOut() == 1
//         <--engaged() == 1                 <--stop()
//         <--timedOut() == 0
//
//  msTimeLeft() return the amount of time (ms) before the timer
//  times out and goes to false.  msAge() returns the amount of time
//  since the constructor, or the most recent call to start().
//  msAge() continues counting even after the boolean has timed out, and
//  thus can be used as an elapsed timer.
//
//  osw_dt_timer value;
//  value.start(5000);                       //  resets timer to 5 secs
//  if (value.engaged()) printf("engaged");  //  check if value is engaged
//  else printf("timed out");
//
//  value.start();                          //  resets timer to 5 secs
//  if (value.timedOut()) printf("timed out");
//

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_dt_timer
//  Description: constructor
//
//  Inputs:  time-out value, of default to 0, (timed out).
//  Outputs:  none.
//////////////////////////////////////////////////////////////////////////////
osw_dt_timer::osw_dt_timer(int _msTimeout):
                           msTimeout_(_msTimeout),
                           engaged_(true),
                           tick_(osw_getTick())
{
  clearPause();
}

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_dt_timer
//  Description: copy constructor
//
//  Inputs:  copied osw_dt_timer.
//  Outputs:  none.
//////////////////////////////////////////////////////////////////////////////
osw_dt_timer::osw_dt_timer(const osw_dt_timer& _source): // copy constructor
                           tick_(_source.tick_),
                           msTimeout_(_source.msTimeout_),
                           engaged_(_source.engaged_),
                           tickAtPause_(_source.tickAtPause_)
{
}

//////////////////////////////////////////////////////////////////////////////
//  function:  getDuration
//  Description: Returns what the time-out duration is.
//
//  Inputs:  none.
//  Outputs:  Returns what the time-out duration is.
//////////////////////////////////////////////////////////////////////////////
inline int osw_dt_timer::getDuration(void)
{
  return msTimeout_;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  setDuration
//  Description: Sets a new time-out duration, even if the timer is running.
//
//  Inputs:  New duration.
//  Outputs:  none.
//////////////////////////////////////////////////////////////////////////////
inline void osw_dt_timer::setDuration(int _msTimeout)
{
  msTimeout_ = _msTimeout;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  isPaused
//  Description: Indicates if this timer is paused.
//
//  Inputs:  none.
//  Outputs:  true == is paused.
//////////////////////////////////////////////////////////////////////////////
inline bool osw_dt_timer::isPaused(void)
{
  return (tickAtPause_ != -1);
}

//////////////////////////////////////////////////////////////////////////////
//  function:  clearPause
//  Description: Internal function, more bookkeeping has to happen when
//    the user pauses a timer.
//
//  Inputs:  none.
//  Outputs:  none.
//////////////////////////////////////////////////////////////////////////////
inline void osw_dt_timer::clearPause(void)
{
  tickAtPause_ = -1;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  operator=
//  Description: Set two timer instances to be the same.
//
//  Inputs:  source timer.
//  Outputs:  target timer.
//////////////////////////////////////////////////////////////////////////////
osw_dt_timer& osw_dt_timer::operator=(osw_dt_timer& _source)
{
  engaged_     = _source.engaged_;
  tick_        = _source.tick_;
  msTimeout_   = _source.msTimeout_;
  tickAtPause_ = _source.tickAtPause_;
  return *this;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  start
//  Description: Starts the timer running.
//
//  Inputs:  time-out value in milisecs.
//  Outputs:  none.
//////////////////////////////////////////////////////////////////////////////
void osw_dt_timer::start(int _msTimeout)
{
  clearPause();
  //  if _msTimeout is zero we want to force-expire the timer
  //  but not overwrite the restart value. 
  if (_msTimeout && (_msTimeout != OSW_USE_PREVIOUS_VALUE))
    msTimeout_ = _msTimeout;
  engaged_ = (msTimeout_ != 0) ;
  tick_ = osw_getTick();
  //printf("start: timeout:%i tick:%i\n", msTimeout_, tick_);
}

//////////////////////////////////////////////////////////////////////////////
//  function:  stop
//  Description: Forces the timer to time-out immediatly.
//
//  Inputs:  none.
//  Outputs:  none.
//////////////////////////////////////////////////////////////////////////////
void osw_dt_timer::stop(void)
{
  if (isPaused()) { resume(); }
  engaged_ = false;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  pause
//  Description: pauses the timer, keeps track of how much time is left
//    before time-out.
//
//  Inputs:  none.
//  Outputs:  none.
//////////////////////////////////////////////////////////////////////////////
void osw_dt_timer::pause(void)
{
  if (isPaused()) return;
  tickAtPause_ = osw_getTick() - tick_;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  resume
//  Description: Resumes a paused timer.  If timer is not paused, this
//    functions has no effect.
//
//  Inputs:  none.
//  Outputs:  none.
//////////////////////////////////////////////////////////////////////////////
void osw_dt_timer::resume(void)
{
  if (!isPaused()) return;
  tick_ = osw_getTick() - tickAtPause_;
  clearPause();
}

//////////////////////////////////////////////////////////////////////////////
//  function:  engaged
//  Description: Checks to see if the timer has timed-out or is still
//    engaged.
//
//  Inputs:  none.
//  Outputs:  true == engaged (not timed-out).
//////////////////////////////////////////////////////////////////////////////
bool osw_dt_timer::engaged(void)
{
  if (isPaused()) return engaged_;  // if we're paused
  if (engaged_ == false) return false;
  if (msTimeout_ == OSW_WAIT_FOREVER) return true;
  if (osw_diffTime_ms(tick_) >= msTimeout_) {
    //printf("tick_:%i gettick:%i\n", tick_, osw_getTick());
    engaged_ = false;
    return false;
  }
  return true;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  timedOut
//  Description: Checks to see if the timer has timed-out.
//
//  Inputs:  none.
//  Outputs:  true == timed-out (not engaged).
//////////////////////////////////////////////////////////////////////////////
bool osw_dt_timer::timedOut(void)
{
  return !engaged();
}

//////////////////////////////////////////////////////////////////////////////
//  function:  msTimeLeft
//  Description: How much time (in milisecs) is left before time-out.
//
//  Inputs:  none.
//  Outputs:  time left on timer in milisecs.
//////////////////////////////////////////////////////////////////////////////
int osw_dt_timer::msTimeLeft(void)
{
  if (engaged_ == false) return 0;
  //  If it's waiting forever, it's always 1 ms from timing out.
  if (msTimeout_ == OSW_WAIT_FOREVER) return 1;
  //  If it's paused.
  if (isPaused()) return msTimeout_ - msAge();
  int delta_t = msTimeout_ - msAge();
  if (delta_t <= 0) {
    engaged_ = false;
    return 0;
  }
  return delta_t;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  msAge
//  Description: How long it's been since the timer started (in milisecs).
//    This value is independent of whether the timer is timed out or not.
//    But it will pause and resume.
//
//  Inputs:  none.
//  Outputs:  time since start in milisecs.
//////////////////////////////////////////////////////////////////////////////
int osw_dt_timer::msAge(void)
{
  if (isPaused()) return osw_diffTime_ms(osw_getTick() - tickAtPause_);  // if we're paused
  return osw_diffTime_ms(tick_);
}

/////////////////////////////////////////////////
//  interrupt enble/disable
/////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////////////
//  function:  interrupt_enable
//  Description: Contains the code to enable interrupts.
//  Inputs: none
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
void osw_interrupt_enable(void)
{
  //  assembly call for enabling interrupts here:
#ifdef OSW_USE_INTERRUPTS_ARDUINO
  interrupts();
#endif
}

//////////////////////////////////////////////////////////////////////////////
//  function:  interrupt_disable
//  Description: Contains the code to disable interrupts.
//  Inputs: none
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
void osw_interrupt_disable(void)
{
  //  assmebly call for disabling interrupts here:
#ifdef OSW_USE_INTERRUPTS_ARDUINO
  noInterrupts();
#endif
}


/////////////////////////////////////////////////
//  hardware watchdog
/////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_watchdog_enable
//  Description: Contains the code enable the watchdog.
//  Inputs: Value of timeout time, implementation specific.
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
void osw_watchdog_enable(int _value)
{
#ifdef OSW_USE_HW_WATCHDOG_ARDUINO
  wdt_enable(_value);
#endif
}

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_watchdog_reset
//  Description: Contains the code reset the watchdog. (pet the dog)
//  Inputs: none
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
void osw_watchdog_reset(void)
{
#ifdef OSW_USE_HW_WATCHDOG_ARDUINO
  wdt_reset();
#endif
}


/////////////////////////////////////////////////
//  A Binary Semaphore
/////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_semaphore
//  Description: Constructor.
//  Inputs: none
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
osw_semaphore::osw_semaphore()
{
  sem_ = false;
  sem_tick_ = 0;
  name_ = OSW_NULL;
  for (int i=0; i<OSW_MAX_TEES; i++)
    the_list_[i] = OSW_NULL;
  the_list_[0] = this;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  ~osw_semaphore
//  Description: Destructor.
//  Inputs: none
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
osw_semaphore::~osw_semaphore()
{
}

//////////////////////////////////////////////////////////////////////////////
//  function:  semCreate
//  Description: Initializes the semaphore.
//  Inputs: The name of the semaphore (necessary if this is a POSIX wrapper).
//          _full indicates if the semaphore is initially full or not.
//  Outputs:
//     returns OSW_OK.
//////////////////////////////////////////////////////////////////////////////
int osw_semaphore::semCreate(char* _name, int _full)
{
  sem_ = (_full != 0);
  sem_tick_ = 0;
  name_ = _name;
  for (int i=0; i<OSW_MAX_TEES; i++)
    the_list_[i] = OSW_NULL;
  the_list_[0] = this;
  osw_put_trace(OSW_BSEM_CREATE, (int)name_);
  return OSW_OK;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  semTake
//  Description: Take the semaphore.
//  Inputs: time to wait in millisecs.
//  Outputs:
//     value: the time that the sem has been waiting. (non-zero, positive val)
//     OSW_TIMEOUT: if timed out waiting.
//     OSW_SINGLE_THREAD: if still waiting the semaphore.
//////////////////////////////////////////////////////////////////////////////
int osw_semaphore::semTake(int _to_wait_ms)
{
  // take the semaphore if it's available.
  if (sem_ == true) {
    sem_ = false;
    osw_put_trace(OSW_BSEM_TAKE, 1);
    return osw_diffTime_ms(sem_tick_) + 1; // force non-zero
  }
  
  if (_to_wait_ms == OSW_WAIT_FOREVER) return OSW_SINGLE_THREAD;
  if (_to_wait_ms == OSW_NO_WAIT) {
    osw_put_trace(OSW_WAIT_TIMEOUT);
    osw_put_trace(OSW_BSEM_TAKE, 0);
    return OSW_TIMEOUT;
  }
  
  // If the semaphore's not available, see if we expired.
  if (osw_diffTime_ms(sem_tick_) > _to_wait_ms) {
    sem_tick_ = osw_getTick();
    osw_put_trace(OSW_WAIT_TIMEOUT);
    osw_put_trace(OSW_BSEM_TAKE, 0);
    return OSW_TIMEOUT;
  }
  return OSW_SINGLE_THREAD;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  semGive
//               semSend (called only by semGive)
//  Description: Give the semaphore, and give the semaphore to all
//               semaphores that are tee-ed off of this semaphore.
//  Inputs: none.
//  Outputs:
//     returns OSW_OK.
//////////////////////////////////////////////////////////////////////////////
int osw_semaphore::semGive()
{
  osw_put_trace(OSW_BSEM_GIVE);
  for (int i=0; i<OSW_MAX_TEES; i++) {
    if (the_list_[i] == OSW_NULL) break;
    semSend(the_list_[i]);
  }
  return OSW_OK;
}

int osw_semaphore::semSend(osw_semaphore* _node)
{
  _node->sem_ = true;
  _node->sem_tick_ = osw_getTick();
  return OSW_OK;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  semTee
//  Description: Tee's the semaphore off of another semaphore.
//  Inputs: The semaphore to tee off of.
//  Outputs:
//     returns OSW_OK: on success
//     OSW_TOO_MANY_TEES: if OSW_MAX_TEES has been exceeded.
//////////////////////////////////////////////////////////////////////////////
int osw_semaphore::semTee(osw_semaphore &tee_from)
{
  int i;
  osw_put_trace(OSW_BSEM_TEE, (int)name_);
  
  for (i=1; i<OSW_MAX_TEES; i++)
    if (tee_from.the_list_[i] == OSW_NULL) break;
  if (i==OSW_MAX_TEES) {
    osw_error(OSW_TOO_MANY_TEES);
    osw_trace_inject(err2str(OSW_TOO_MANY_TEES));
    return OSW_TOO_MANY_TEES;
  }
  tee_from.the_list_[i] = this;
  return OSW_OK;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  semUntee
//  Description: Removes the semaphore from another semaphore's tee list.
//  Inputs: The semaphore that will remove this semaphore from it's list.
//  Outputs:
//     returns OSW_OK: on success
//     OSW_UNTEE_ERROR: if this semaphore was not part of it's list.
//////////////////////////////////////////////////////////////////////////////
int osw_semaphore::semUntee(osw_semaphore &tee_from)
{
  int i,j;
  osw_put_trace(OSW_BSEM_UNTEE, (int)name_);
  
  //  find the element
  for (i=1; i<OSW_MAX_TEES; i++)
    if (tee_from.the_list_[i] == this) break;
  if (i==OSW_MAX_TEES) {
    osw_error(OSW_UNTEE_ERROR);
    osw_trace_inject(err2str(OSW_UNTEE_ERROR));
    return OSW_UNTEE_ERROR;
  }
  // find the end of the list
  for (j=OSW_MAX_TEES-1; j>i; j--)
    if (tee_from.the_list_[j] != OSW_NULL) break;
  
  // replace the deleted element and shrink the list.  (works even when j==i)
  tee_from.the_list_[i] = tee_from.the_list_[j];
  tee_from.the_list_[j] = OSW_NULL;
  return OSW_OK;
}

/////////////////////////////////////////////////
//  A Counting Semaphore
/////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_counting_sem
//  Description: Constructor.
//  Inputs: none
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
osw_counting_sem::osw_counting_sem(void)
{
  count_ = 0;
  name_ = OSW_NULL;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  semCreate
//  Description: Initializes the semaphore.
//  Inputs: The name of the semaphore (necessary if this is a POSIX wrapper).
//  Outputs:
//     returns OSW_OK.
//////////////////////////////////////////////////////////////////////////////
int osw_counting_sem::semCreate(char* _name)
{
  count_ = 0;
  name_ = _name;
  osw_trace_off();
  semSem_.semCreate(_name, 0);
  osw_trace_on();
  osw_put_trace(OSW_CSEM_CREATE, (int)name_);
  return OSW_OK;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  getCount
//  Description: Returns the count value of the semaphore
//  Inputs: none.
//  Outputs:
//     returns the count.
//////////////////////////////////////////////////////////////////////////////
int osw_counting_sem::getCount(void)
{
  return count_;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  semTake
//  Description: Take the semaphore.
//  Inputs: time to wait in millisecs.
//  Outputs:
//     value: the count of the semaphore
//     OSW_TIMEOUT: if timed out waiting.
//     OSW_SINGLE_THREAD: if still waiting the semaphore.
//////////////////////////////////////////////////////////////////////////////
int osw_counting_sem::semTake(int _to_wait_ms)
{
  int retval;
  if (count_ > 0) --count_;
  
  if (count_ <= 0) {
    osw_trace_off();
    retval =  semSem_.semTake(_to_wait_ms);  // block here.
    osw_trace_on();
    if (retval < 0) return retval;
  }
  
  //os_trace.log(name_, count_, "Count semTake");
  osw_put_trace(OSW_CSEM_TAKE, count_);
  return count_ + 1;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  semGive
//  Description: Give the semaphore.
//  Inputs: none.
//  Outputs:
//     value: the count of the semaphore
//////////////////////////////////////////////////////////////////////////////
int osw_counting_sem::semGive()
{
  ++count_;
  osw_trace_off();
  semSem_.semGive();
  osw_trace_on();
  osw_put_trace(OSW_CSEM_GIVE, count_);
  return count_;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  semFlush
//  Description: Flush the semaphore, count goes to zero with empty sem.
//  Inputs: none.
//  Outputs: none.
//////////////////////////////////////////////////////////////////////////////
void osw_counting_sem::semFlush()
{
  count_ = 0;
  osw_trace_off();
  semSem_.semTake(OSW_NO_WAIT);
  osw_trace_on();
  osw_put_trace(OSW_CSEM_FLUSH);
}

/////////////////////////////////////////////////
//  Message Queue
/////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_message_q
//  Description: Constructor.  Initizes the tee list to OSW_NULL.
//  Inputs: none
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
osw_message_q::osw_message_q()
{
  msg_array_ = OSW_NULL;
  for (int i=0; i<OSW_MAX_TEES; i++)
    the_list_[i] = OSW_NULL;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  ~osw_message_q
//  Description: Destructor.  Frees the tee list.
//  Inputs: none
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
osw_message_q::~osw_message_q()
{
  for (int i=0; i<OSW_MAX_TEES; i++)
    the_list_[i] = OSW_NULL;
  if (msg_array_ != OSW_NULL) {
    //delete [] msg_array_;
    osw_free(msg_array_);
    msg_array_ = OSW_NULL;
  }
}

//////////////////////////////////////////////////////////////////////////////
//  function:  msgQcreate
//  Description: Initializes the message queue.
//  Inputs: The name of the queue,
//          maximum size of a message for the queue.  This is only allowed to
//            be zero if maximum number of messages is zero.  This means that
//            the queue is being used as an endpoint, and messages will only
//            be sent to other queues that tee off of this one.
//          maximum number of messages for the queue.
//  Outputs:
//     OSW_OK on success.
//     OSW_INVALID_PARAMETER if name is null or if the sizes are less than 0.
//     OSW_UNDER_MIN_SIZE if _max_msg_size is 0 but _max_msgs is not 0.
//     OSW_MEM_ALLOC_FAILED if memory failed to allocate.
//     OSW_ALREADY_INITIALIZED if the Q was already created.
//////////////////////////////////////////////////////////////////////////////
int osw_message_q::msgQcreate(char* _name, int _max_msg_size, int _max_msgs)
{
  //  if max_msgs is 0 then it's being set up as a tee point.
  //  This is a spiffy way to do "subscription/publish" of
  //  messages, without a separate event mechanism.
  
  // sanity checks:
  if (msg_array_ != OSW_NULL) {
    osw_error(OSW_ALREADY_INITIALIZED);
    osw_trace_inject(err2str(OSW_ALREADY_INITIALIZED));
    return OSW_ALREADY_INITIALIZED;
  }
  if ((_max_msg_size < 0) || (_max_msgs < 0)) {
    osw_error(OSW_INVALID_PARAMETER);
    osw_trace_inject(err2str(OSW_INVALID_PARAMETER));
    return OSW_INVALID_PARAMETER;
  }
  if (_name == OSW_NULL) {
    osw_error(OSW_INVALID_PARAMETER);
    osw_trace_inject(err2str(OSW_INVALID_PARAMETER));
    return OSW_INVALID_PARAMETER;
  }
  
  // initialize.
  max_msg_size_ = sizeof(Qheader)+_max_msg_size;
  max_msgs_ = _max_msgs;
  tail_ = 0;
  head_ = 0;
  name_ = _name;
  for (int i=0; i<OSW_MAX_TEES; i++)
    the_list_[i] = OSW_NULL;
  
  if (_max_msgs == 0) {  // don't need to do anything else here.
    osw_put_trace(OSW_Q_CREATE, (int)name_);
    return OSW_OK;
  }
  if ((_max_msg_size < 1) && (_max_msgs > 0)) {
    osw_error(OSW_UNDER_MIN_SIZE);
    osw_trace_inject(err2str(OSW_UNDER_MIN_SIZE));
    return OSW_UNDER_MIN_SIZE;
  }
  
  osw_trace_off();
  Qsem_.semCreate(_name);
  osw_trace_on();
  // allocate the message queue.
  //  Allocate space for the message size and the message.
  //msg_array_ = new(char[_max_msgs * max_msg_size_]);
  if (max_msgs_ != 0) {
    msg_array_ = (char*)osw_malloc(_max_msgs * max_msg_size_);
    if (msg_array_ == OSW_NULL) {
      // POST ERROR
      osw_error(OSW_MEM_ALLOC_FAILED);
      osw_trace_inject(err2str(OSW_MEM_ALLOC_FAILED));
      return OSW_MEM_ALLOC_FAILED;
    }
  }
  the_list_[0] = this;
  osw_put_trace(OSW_Q_CREATE, (int)name_);
  return OSW_OK;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  msgQtee
//  Description: Tee's the queue off of another queue.
//  Inputs: The queue to tee off of.
//  Outputs:
//     returns OSW_OK: on success
//     OSW_TOO_MANY_TEES: if OSW_MAX_TEES has been exceeded.
//////////////////////////////////////////////////////////////////////////////
int osw_message_q::msgQtee(osw_message_q &_tee_from)
{
  int i;
  osw_put_trace(OSW_Q_TEE, (int)name_);
  
  for (i=0; i<OSW_MAX_TEES; i++)
    if (_tee_from.the_list_[i] == OSW_NULL) break;
  if (i >= OSW_MAX_TEES) {
    osw_error(OSW_TOO_MANY_TEES);
    osw_trace_inject(err2str(OSW_TOO_MANY_TEES));
    return OSW_TOO_MANY_TEES;
  }
  _tee_from.the_list_[i] = this;
  return OSW_OK;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  msgQuntee
//  Description: Removes the queue from another queue's tee list.
//  Inputs: The queue that will remove this queue from it's list.
//  Outputs:
//     returns OSW_OK: on success
//     OSW_UNTEE_ERROR: if this queue was not part of it's list.
//////////////////////////////////////////////////////////////////////////////
int osw_message_q::msgQuntee(osw_message_q &_tee_from)
{
  int i,j;
  osw_put_trace(OSW_Q_UNTEE, (int)name_);
  if (msg_array_ == OSW_NULL) return 0;
  
  //  find the element
  for (i=1; i<OSW_MAX_TEES; i++)
    if (_tee_from.the_list_[i] == this) break;
  if (i==OSW_MAX_TEES) {
    osw_error(OSW_UNTEE_ERROR);
    osw_trace_inject(err2str(OSW_UNTEE_ERROR));
    return OSW_UNTEE_ERROR;
  }
  // find the end of the list
  for (j=OSW_MAX_TEES-1; j>i; j--)
    if (_tee_from.the_list_[j] != OSW_NULL) break;
  
  // replace the deleted element and shrink the list.  (works even when j==i)
  _tee_from.the_list_[i] = _tee_from.the_list_[j];
  _tee_from.the_list_[j] = OSW_NULL;
  return OSW_OK;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  msgQreceive
//  Description: gets a message from the Q
//  Parameters:
//    _in_msg: buffer for the message,
//    _size: size of the buffer.  If it is too small, the incoming message
//           will be truncated,
//    _to_wait_ms: time to wait in millisecs.
//    _tick: If _tick is not OSW_NULL, it will be filled with
//           the tick value of when the message was sent.  That
//           can be used to determine how long the message was
//           sitting in the Q.
//  Return value:
//    positive value: the size of the message received.
//              returned message size <= _size.   If _size is smaller
//              than the message in the Q then the message will be
//              truncated to fit _size, the truncated part is lost.
//    OSW_SINGLE_THREAD: if still waiting for a message to arrive.
//    OSW_TIMEOUT: if timed out waiting (including OSW_NO_WAIT).
//    OSW_UNALLOCATED_MEM: if calling msgQreceive before msgQcreate
//    OSW_EXCEED_MAX_SIZE: if receiving message from 0-sized Q.
//////////////////////////////////////////////////////////////////////////////
int osw_message_q::msgQreceive(char *_in_msg,
    int _size,
    int _to_wait_ms,
    int* _tick)
{
  if (max_msgs_ == 0) {
    osw_error(OSW_EXCEED_MAX_SIZE);
    osw_trace_inject(err2str(OSW_EXCEED_MAX_SIZE));
    return OSW_EXCEED_MAX_SIZE; // should never happen.
  }
  // are there any messages?
  osw_trace_off();
  int retval = Qsem_.semTake(_to_wait_ms);
  osw_trace_on();
  if (retval == OSW_SINGLE_THREAD) return OSW_SINGLE_THREAD;
  if (retval == OSW_TIMEOUT) {
    osw_put_trace(OSW_WAIT_TIMEOUT);
    osw_put_trace(OSW_Q_RECEIVE);
    return OSW_TIMEOUT;
  }
  if (retval < 0) {
    // post error
    osw_error(OSW_GENERAL_ERROR);
    osw_trace_inject(err2str(OSW_GENERAL_ERROR));
    return retval;
  }
  
  // sanity check
  if (msg_array_ == OSW_NULL) {
    osw_error(OSW_UNALLOCATED_MEM);
    osw_trace_inject(err2str(OSW_UNALLOCATED_MEM));
    return OSW_UNALLOCATED_MEM;
  }
  
  // get the message.
  Qheader* tmp = (Qheader*)&msg_array_[head_*max_msg_size_];
  int retsize = tmp->size;               // get the size.
  if (retsize > _size) retsize = _size;  // check the size.
  if (_tick != OSW_NULL) *_tick = tmp->tick;
  memcpy(_in_msg, &msg_array_[head_*max_msg_size_+sizeof(Qheader)], retsize);
  ++head_;
  head_ %= max_msgs_;
  osw_put_trace(OSW_Q_RECEIVE, retsize);
  return retsize;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  msgQsend
//               Qsend  (called only by msgQsend)
//  Description: puts a message on the Q
//  Parameters: the message, message size, and control.
//    Control is either OSW_REJECT_ON_FULL (default) or  OSW_BUMP_ON_FULL.
//    With OSW_REJECT_ON_FULL, when the Q is full the new message
//    will be thrown away.  With OSW_BUMP_ON_FULL, when the Q is
//    full the oldest message is thrown away, and the new message
//    is added.
//  Return value:
//    Returns the status the this Q, other Q's that are tee-ed off
//      of this Q may have errors in the os_trace log.
//    OSW_OK: on success.
//    OSW_MSG_Q_FULL_BUMP: if Q is full and the oldest message was bumped.
//    OSW_MSG_Q_FULL_REJECT: if Q is full and message was rejected.
//    OSW_UNALLOCATED_MEM: if msgQsend was called before msgQcreate.
//    OSW_EXCEED_MAX_SIZE: if the message exceeds Q allocation for it.
//////////////////////////////////////////////////////////////////////////////
int osw_message_q::msgQsend(char *_in_msg, int _size, int _control)
{
  osw_put_trace(OSW_Q_SEND, _size);
  osw_trace_off();
  int retval, tmp;
  for (int i=0; i<OSW_MAX_TEES; i++) {
    if (the_list_[i] == OSW_NULL) break;
    tmp = Qsend(the_list_[i], _in_msg, _size, _control);
    if (i == 0) retval = tmp;
  }
  osw_trace_on();
  return retval;
}

int osw_message_q::Qsend(osw_message_q *_node,
                         char *_in_msg,
                         int _size,
                         int _control)
{
  if (_node == OSW_NULL) {
    osw_error(OSW_UNALLOCATED_MEM);
    osw_trace_inject(err2str(OSW_UNALLOCATED_MEM));
    return OSW_UNALLOCATED_MEM;
  }
  if (_node->max_msgs_ == 0) return 0; // don't send to this queue.
  if (_node->msg_array_ == OSW_NULL) {
    osw_error(OSW_UNALLOCATED_MEM);
    osw_trace_inject(err2str(OSW_UNALLOCATED_MEM));
    return OSW_UNALLOCATED_MEM;
  }
  // sanity check.
  if (_size > _node->max_msg_size_-(int)sizeof(Qheader)) {
    //  POST ERROR
    osw_error(OSW_EXCEED_MAX_SIZE);
    osw_trace_inject(err2str(OSW_EXCEED_MAX_SIZE));
    return OSW_EXCEED_MAX_SIZE;
  }
  
  // check for a full Q:
  //  head_ equals tail_ when Q is empty, or when Q is full.
  if ((_node->tail_ == _node->head_) && _node->Qsem_.getCount()) {
    if (_control == OSW_REJECT_ON_FULL) {
      osw_error(OSW_MSG_Q_FULL_REJECT);
      osw_trace_inject(err2str(OSW_MSG_Q_FULL_REJECT));
      return OSW_MSG_Q_FULL_REJECT;
    }
    if (_control ==  OSW_BUMP_ON_FULL) {
      // put the message.
      Qheader *tmp = (Qheader*)&_node->msg_array_[_node->tail_ * _node->max_msg_size_];
      tmp->size = _size;
      tmp->tick = osw_getTick();
      memcpy(&_node->msg_array_[(_node->tail_ * _node->max_msg_size_)+sizeof(Qheader)], _in_msg, _size);
      ++_node->tail_;
      _node->tail_ %= _node->max_msgs_;
      ++_node->head_;
      _node->head_ %= _node->max_msgs_;
      osw_error(OSW_MSG_Q_FULL_BUMP);
      osw_trace_inject(err2str(OSW_MSG_Q_FULL_BUMP));
      return OSW_MSG_Q_FULL_BUMP;
    }
  }
  
  // put the message.
  Qheader *tmp = (Qheader*)&_node->msg_array_[_node->tail_ * _node->max_msg_size_];
  tmp->size = _size;
  tmp->tick = osw_getTick();
  memcpy(&_node->msg_array_[_node->tail_ * _node->max_msg_size_+sizeof(Qheader)], _in_msg, _size);
  ++_node->tail_;
  _node->tail_ %= _node->max_msgs_;
  // everything's OK.
  _node->Qsem_.semGive();
  return OSW_OK;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  msgQflush
//  Description: Empties the Q
//  Parameters: none.
//  Return value: none.
//////////////////////////////////////////////////////////////////////////////
void osw_message_q::msgQflush(void)
{
  tail_ = 0;
  head_ = 0;
  osw_trace_off();
  Qsem_.semFlush();
  osw_trace_on();
  osw_put_trace(OSW_Q_FLUSH);
}

/////////////////////////////////////////////////
//  Packed Message Queue
/////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_packed_q
//  Description: Constructor.  Initizes the tee list to NULL.
//  Inputs: none
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
osw_packed_q::osw_packed_q():ROLLOVER_VALUE(0xffffffffL)
{
  msg_array_ = OSW_NULL;
  for (int i=0; i<OSW_MAX_TEES; i++)
    the_list_[i] = OSW_NULL;
}

osw_packed_q::~osw_packed_q()
{
  for (int i=0; i<OSW_MAX_TEES; i++)
    the_list_[i] = OSW_NULL;
  if (msg_array_ != OSW_NULL) {
    //osw_print_mem_free();
    osw_free(msg_array_);
    msg_array_ = OSW_NULL;
  }
}

//////////////////////////////////////////////////////////////////////////////
//  function:  pkdQcreate
//  Description: Initializes the message queue.
//  Inputs: The name of the queue, size to be allocated for this queue
//  Outputs:
//     OSW_OK on success.
//     OSW_UNDER_MIN_SIZE if queue size is 0 or less.
//     OSW_INVALID_PARAMETER if name is null.
//     OSW_MEM_ALLOC_FAILED if memory failed to allocate.
//     OSW_ALREADY_INITIALIZED if the Q was already created.
//////////////////////////////////////////////////////////////////////////////
int osw_packed_q::pkdQcreate(char* _name, int _size_bytes)
{
  //  if max_msgs is 0 then it's being set up as a tee point.
  //  This is a spiffy way to do "subscription/publish" of
  //  messages, without a separate event mechanism.
  // sanity checks:
  if (msg_array_ != OSW_NULL) {
    osw_error(OSW_ALREADY_INITIALIZED);
    osw_trace_inject(err2str(OSW_ALREADY_INITIALIZED));
    return OSW_ALREADY_INITIALIZED;
  }
  if (_size_bytes < sizeof(Qheader) + 1) {
    osw_error(OSW_UNDER_MIN_SIZE);
    osw_trace_inject(err2str(OSW_UNDER_MIN_SIZE));
    return OSW_UNDER_MIN_SIZE;
  }
  if (_name == OSW_NULL) {
    osw_error(OSW_INVALID_PARAMETER);
    osw_trace_inject(err2str(OSW_INVALID_PARAMETER));
    return OSW_INVALID_PARAMETER;
  }
  
  // initialize.
  buf_size_ = _size_bytes;
  name_ = _name;
  for (int i=0; i<OSW_MAX_TEES; i++)
    the_list_[i] = OSW_NULL;
  
  osw_trace_off();
  Qsem_.semCreate(_name);
  osw_trace_on();
  // allocate the message queue.
  msg_array_ = (char*)osw_malloc(buf_size_);
  if (msg_array_ == OSW_NULL) {
    osw_error(OSW_MEM_ALLOC_FAILED);
    osw_trace_inject(err2str(OSW_MEM_ALLOC_FAILED));
    return OSW_MEM_ALLOC_FAILED;
  }
  buf_end_ = msg_array_ + _size_bytes;
  tail_ = msg_array_;
  head_ = msg_array_;
  the_list_[0] = this;
  osw_put_trace(OSW_Q_CREATE, (int)name_);
  return OSW_OK;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  pkdQtee
//  Description: Tee's the queue off of another queue.
//  Inputs: The queue to tee off of.
//  Outputs:
//     returns OSW_OK: on success
//     OSW_TOO_MANY_TEES: if OSW_MAX_TEES has been exceeded.
//     OSW_UNALLOCATED_MEM if memory has not been allocated for this queue.
//            (i.e. pkdQcreate has not been called yet.)
//////////////////////////////////////////////////////////////////////////////
int osw_packed_q::pkdQtee(osw_packed_q &_tee_from)
{
  int i;
  osw_put_trace(OSW_Q_TEE, (int)name_);
  if (msg_array_ == OSW_NULL) return OSW_UNALLOCATED_MEM;
  
  for (i=0; i<OSW_MAX_TEES; i++)
    if (_tee_from.the_list_[i] == OSW_NULL) break;
  if (i >= OSW_MAX_TEES) {
    osw_error(OSW_TOO_MANY_TEES);
    osw_trace_inject(err2str(OSW_TOO_MANY_TEES));
    return OSW_TOO_MANY_TEES;
  }
  _tee_from.the_list_[i] = this;
  return OSW_OK;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  pkdQuntee
//  Description: Removes the queue from another queue's tee list.
//  Inputs: The queue that will remove this queue from it's list.
//  Outputs:
//     returns OSW_OK: on success
//     OSW_UNTEE_ERROR: if this queue was not part of it's list.
//////////////////////////////////////////////////////////////////////////////
int osw_packed_q::pkdQuntee(osw_packed_q &_tee_from)
{
  int i,j;
  osw_put_trace(OSW_Q_UNTEE, (int)name_);
  if (msg_array_ == OSW_NULL) return OSW_OK;
  
  //  find the element
  for (i=1; i<OSW_MAX_TEES; i++)
    if (_tee_from.the_list_[i] == this) break;
  if (i==OSW_MAX_TEES) {
    osw_error(OSW_UNTEE_ERROR);
    osw_trace_inject(err2str(OSW_UNTEE_ERROR));
    return OSW_UNTEE_ERROR;
  }
  // find the end of the list
  for (j=OSW_MAX_TEES-1; j>i; j--)
    if (_tee_from.the_list_[j] != OSW_NULL) break;
  
  // replace the deleted element and shrink the list.  (works even when j==i)
  _tee_from.the_list_[i] = _tee_from.the_list_[j];
  _tee_from.the_list_[j] = OSW_NULL;
  return OSW_OK;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  pkdQreceive
//  Description: gets a message from the Q
//  Parameters:
//    _in_msg: buffer for the message,
//    _size: size of the buffer.  If it is too small, the incoming message
//           will be truncated,
//    _to_wait_ms: time to wait in millisecs.
//    _tick: If _tick is not OSW_NULL, it will be filled with
//           the tick value of when the message was sent.  That
//           can be used to determine how long the message was
//           sitting in the Q.
//  Return value:
//    positive value: the size of the message received.
//              returned message size <= _size.   If _size is smaller
//              than the message in the Q then the message will be
//              truncated to fit _size, the truncated part is lost.
//    OSW_SINGLE_THREAD: if still waiting for a message to arrive.
//    OSW_TIMEOUT: if timed out waiting (including OSW_NO_WAIT).
//    OSW_UNALLOCATED_MEM: if calling msgQreceive before msgQcreate
//////////////////////////////////////////////////////////////////////////////
int osw_packed_q::pkdQreceive(char *_buf,
                              int _buf_size,
                              int _to_wait_ms,
                              int* _tick)
{
  // sanity check
  if (msg_array_ == OSW_NULL) {
    osw_error(OSW_UNALLOCATED_MEM);
    osw_trace_inject(err2str(OSW_UNALLOCATED_MEM));
    return OSW_UNALLOCATED_MEM;
  }
  
  // are there any messages?
  osw_trace_off();
  int retval = Qsem_.semTake(_to_wait_ms);
  osw_trace_on();
  if (retval == OSW_SINGLE_THREAD) return OSW_SINGLE_THREAD;
  if (retval == OSW_TIMEOUT) {
    osw_put_trace(OSW_WAIT_TIMEOUT);
    osw_put_trace(OSW_Q_RECEIVE);
    return OSW_TIMEOUT;
  }
  if (retval < 0) {
    // post error
    osw_error(OSW_GENERAL_ERROR);
    osw_trace_inject(err2str(OSW_GENERAL_ERROR));
    return retval;
  }
  
  // get the message.
  Qheader* tmp = (Qheader*)(head_);
  if (tmp->size == ROLLOVER_VALUE) {
    head_ = msg_array_;
    tmp = (Qheader*)(head_);
  }
  int retsize = tmp->size;               // get the size.
  if (retsize > _buf_size) {
    osw_error(OSW_EXCEED_MAX_SIZE);
    osw_trace_inject(err2str(OSW_EXCEED_MAX_SIZE));
    return OSW_EXCEED_MAX_SIZE;  // sanity check.
  }
  if (_tick != OSW_NULL) *_tick = tmp->tick;
  memcpy(_buf, head_ + sizeof(Qheader), retsize);
  head_ += tmp->size + sizeof(Qheader);
  osw_put_trace(OSW_Q_RECEIVE, retsize);
  return retsize;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  pkdQsend
//               Qsend  (called only by pkdQsend)
//  Description: puts a message on the Q
//  Parameters: the message, message size.
//  Return value:
//    Returns the status this Q, other Q's that are tee-ed off
//      of this Q may have errors in the os_trace log.
//    OSW_OK: on success.
//    OSW_MSG_Q_FULL_PACK: not enought space for this message.
//    OSW_UNALLOCATED_MEM: if pkdQsend was called before pkdQcreate.
//////////////////////////////////////////////////////////////////////////////
int osw_packed_q::pkdQsend(char *_in_msg, int _size)
{
  int retval = OSW_OK;
  osw_put_trace(OSW_Q_SEND, _size);
  osw_trace_off();
  for (int i=0; i<OSW_MAX_TEES; i++) {
    if (the_list_[i] == OSW_NULL) break;
    int err = Qsend(the_list_[i], _in_msg, _size);
    if (i == 0) retval = err;
  }
  osw_trace_on();
  return retval;
}

int osw_packed_q::Qsend(osw_packed_q *_node,
                        char *_in_msg,
                        int _size)
{
  if (_node == OSW_NULL) {
    osw_error(OSW_UNALLOCATED_MEM);
    osw_trace_inject(err2str(OSW_UNALLOCATED_MEM));
    return OSW_UNALLOCATED_MEM;
  }
  if (_node->buf_size_ == 0) return 0; // don't send to this queue.
  if (_node->msg_array_ == OSW_NULL) {
    osw_error(OSW_UNALLOCATED_MEM);
    osw_trace_inject(err2str(OSW_UNALLOCATED_MEM));
    return OSW_UNALLOCATED_MEM;
  }
  
  // printf("sndQ%02x ", (unsigned char)the_handle);
  
  // put the message.
  if (_node->head_ > _node->tail_) {
    if (_size + (int)sizeof(Qheader) <= (int)(_node->head_ - _node->tail_)) {
      Qheader *tmp = (Qheader*)_node->tail_;
      tmp->size = _size;
      tmp->tick = osw_getTick();
      memcpy((_node->tail_+sizeof(Qheader)), _in_msg, _size);
      _node->tail_ += (_size + sizeof(Qheader));
    } else {
      osw_error(OSW_PKD_Q_FULL);
      osw_trace_inject(err2str(OSW_PKD_Q_FULL));
      return OSW_PKD_Q_FULL;
    }
  } else {
    if (_size + (int)sizeof(Qheader) <= ((int)(_node->buf_end_ - _node->tail_))) {
      Qheader *tmp = (Qheader*)_node->tail_;
      tmp->size = _size;
      tmp->tick = osw_getTick();
      memcpy((_node->tail_+sizeof(Qheader)), _in_msg, _size);
      _node->tail_ += (_size + sizeof(Qheader));
    } else if (_size + (int)sizeof(Qheader) <= (int)(_node->head_ - _node->msg_array_)) {
      // rollover.
      Qheader *tmp = (Qheader*)_node->tail_;
      tmp->size = ROLLOVER_VALUE;
      tmp->tick = osw_getTick();
      tmp = (Qheader*)_node->msg_array_;
      tmp->size = _size;
      tmp->tick = osw_getTick();
      memcpy((_node->msg_array_+sizeof(Qheader)), _in_msg, _size);
      _node->tail_ = _node->msg_array_ + (_size + sizeof(Qheader));
    } else {
      osw_error(OSW_PKD_Q_FULL);
      osw_trace_inject(err2str(OSW_PKD_Q_FULL));
      return OSW_PKD_Q_FULL;
    }
  }
  // everything's OK.
  _node->Qsem_.semGive();
  return OSW_OK;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  pkdQflush
//  Description: Empties the Q
//  Parameters: none.
//  Return value: none.
//////////////////////////////////////////////////////////////////////////////
void osw_packed_q::pkdQflush(void)
{
  tail_ = msg_array_;
  head_ = msg_array_;
  osw_trace_off();
  Qsem_.semFlush();
  osw_trace_on();
  osw_put_trace(OSW_Q_FLUSH);
}

/////////////////////////////////////////////////
//  Priority Message Queue
/////////////////////////////////////////////////

/////////////////////////////////////////////////////////////////////////
//  This is the osw_priority_q.  It uses time and a counting
//  semaphore from the os_wrap routines.  It provides a tick to see how
//  long a message was in the queue before it was retrieved.
//
//  This uses fixed length arrays, and if a queue fills up then there is
//  the bump logic explained in the .h file.
/////////////////////////////////////////////////////////////////////////

#define OSW_PRIQ_FREE_IDX (OSW_ALL_PRIOIRITIES)

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_priority_q
//  Description: Constructor.
//  Inputs: none
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
osw_priority_q::osw_priority_q():
    name_(NULL),
    max_msg_size_(0),
    max_msgs_(0),
    max_num_priorities_(0),
    initialized_(false),
    msgs_(NULL),
    msgs_used_(0),
    priList_(NULL),
    priCount_(0)
{
}

osw_priority_q::~osw_priority_q() {}

//////////////////////////////////////////////////////////////////////////////
//  function:  priQcreate
//  Description: Initializes the message queue.
//  Inputs: The name of the queue, size to be allocated for this queue
//  Outputs:
//     OSW_OK on success.
//     OSW_UNDER_MIN_SIZE if queue size is 0 or less.
//     OSW_INVALID_PARAMETER if name is null.
//     OSW_MEM_ALLOC_FAILED if memory failed to allocate.
//     OSW_ALREADY_INITIALIZED if the Q was already created.
//////////////////////////////////////////////////////////////////////////////
int osw_priority_q::priQcreate(char* _name,
    int _max_msg_size,
    int _max_msgs,
    int _max_num_priorities)
{
  // Sanity Checks.
  if (msgs_ != OSW_NULL) {
    osw_error(OSW_ALREADY_INITIALIZED);
    osw_trace_inject(err2str(OSW_ALREADY_INITIALIZED));
    return OSW_ALREADY_INITIALIZED;
  }
  if (_name == NULL) {
    osw_error(OSW_INVALID_PARAMETER);
    osw_trace_inject(err2str(OSW_INVALID_PARAMETER));
    return OSW_INVALID_PARAMETER;
  }
  if ((_max_msg_size < 1) ||
      (_max_msgs < 1) ||
      (_max_num_priorities < 1)) {
    osw_error(OSW_UNDER_MIN_SIZE);
    osw_trace_inject(err2str(OSW_UNDER_MIN_SIZE));
    return OSW_UNDER_MIN_SIZE;
  }
  
  // initialize
  name_ = _name;
  max_msg_size_ = _max_msg_size + sizeof(Qheader);
  max_msgs_ = _max_msgs;
  max_num_priorities_ = _max_num_priorities;
  
  msgs_ = (char*)osw_malloc(max_msg_size_ * max_msgs_);
  if (msgs_ == NULL) {
    // POST ERROR
    osw_error(OSW_MEM_ALLOC_FAILED);
    osw_trace_inject(err2str(OSW_MEM_ALLOC_FAILED));
    return OSW_MEM_ALLOC_FAILED;
  }
  priList_ = (priListStruct*)osw_malloc(sizeof(priListStruct) * max_num_priorities_);
  if (priList_ == NULL) {
    // POST ERROR
    osw_error(OSW_MEM_ALLOC_FAILED);
    osw_trace_inject(err2str(OSW_MEM_ALLOC_FAILED));
    return OSW_MEM_ALLOC_FAILED;
  }
  
  osw_trace_off();
  int retval = Qsem_.semCreate(_name);
  osw_trace_on();
  if (retval != OSW_OK) return retval;
  
  initialized_ = true;
  osw_put_trace(OSW_Q_CREATE, (int)name_);
  return OSW_OK;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  priQsend
//  Description: puts a message on the Q
//  Parameters: the message, message size, and control.
//
//  When the Q fills up:
//  OSW_PRIQ_BUMP_LOW_HEAD_FULL finds the lowest priority queue, and removes
//    the head of the queue (oldest) and uses the space for the niew element.
//  OSW_PRIQ_BUMP_LOW_TAIL_FULL find the lowest priority queue, and removes
//    the tail of the queue.  This is useful for some network implementations.
//    If the network protocol calls for retransmission after a missed
//    message, bumping off the end of the queue means more sequenced messages
//    get through reducing the messages needed for retransmit.
//  OSW_PRIQ_BUMP_PRI_HEAD_FULL bumps the head (oldest) message of the same
//    priority as the new message, if there are no previos messages at that
//    priority, the new message is rejected.
//  OSW_PRIQ_REJECT_ON_FULL if the queue is full, reject the new message.
//
//  Return value:
//    Returns the status.
//    OSW_OK: on success.
//    OSW_MSG_Q_FULL_BUMP: if Q is full and the oldest message was bumped.
//    OSW_MSG_Q_FULL_REJECT: if Q is full and message was rejected.
//    OSW_UNALLOCATED_MEM: if msgQsend was called before msgQcreate.
//    OSW_EXCEED_MAX_SIZE: if the message exceeds Q allocation for it.
//////////////////////////////////////////////////////////////////////////////
int osw_priority_q::priQsend(int _priority,  // 0=lowest priority
                             char* _in_msg,
                             int _size,
                             int _control)
{
  osw_put_trace(OSW_Q_SEND, _size);
  //  sanity checks
  if (!initialized_) {
    osw_error(OSW_UNALLOCATED_MEM);
    osw_trace_inject(err2str(OSW_UNALLOCATED_MEM));
    return OSW_UNALLOCATED_MEM;
  }
  if (_size > max_msg_size_-(int)sizeof(Qheader)) {
    osw_error(OSW_EXCEED_MAX_SIZE);
    osw_trace_inject(err2str(OSW_EXCEED_MAX_SIZE));
    return OSW_EXCEED_MAX_SIZE;
  }
  Qheader hdr;
  priListStruct ptmp;
  // printf("sndQ%02x ", (unsigned char)the_handle);
  
  int retval = OSW_OK;
  int data_idx = pop_pri_head(OSW_PRIQ_FREE_IDX); //get_next_free();
  if (data_idx == -1) {
    data_idx = msgs_used_;
    ++msgs_used_;
    if (data_idx >= max_msgs_) {
      --msgs_used_;
      if (_control == OSW_PRIQ_REJECT_ON_FULL) {
        //printf("OSW_PRIQ_REJECT_ON_FULL\n");
        osw_error(OSW_PRI_Q_FULL_REJECT);
        osw_trace_inject(err2str(OSW_PRI_Q_FULL_REJECT));
        return OSW_PRI_Q_FULL_REJECT;
        
      } else if (_control == OSW_PRIQ_BUMP_LOW_HEAD_FULL) {
        //printf("OSW_PRIQ_BUMP_LOW_HEAD_FULL\n");
        osw_error(OSW_PRI_Q_BUMP_LOW_HEAD);
        osw_trace_inject(err2str(OSW_PRI_Q_BUMP_LOW_HEAD));
        retval = OSW_PRI_Q_BUMP_LOW_HEAD;
        int low_pri = get_lowest_pri();
        if (low_pri == OSW_PRIQ_FREE_IDX) {
          osw_error(OSW_PRI_Q_PRI_NOT_FOUND);
          osw_trace_inject(err2str(OSW_PRI_Q_PRI_NOT_FOUND));
          return OSW_PRI_Q_PRI_NOT_FOUND;
        }
        data_idx = pop_pri_head(low_pri);
        if (data_idx == -1) {
          osw_error(OSW_PRI_Q_FREE_NOT_FOUND);
          osw_trace_inject(err2str(OSW_PRI_Q_FREE_NOT_FOUND));
          return OSW_PRI_Q_FREE_NOT_FOUND;
        }
        
      } else if (_control == OSW_PRIQ_BUMP_LOW_TAIL_FULL) {
        //printf("OSW_PRIQ_BUMP_LOW_TAIL_FULL\n");
        osw_error(OSW_PRI_Q_BUMP_LOW_TAIL);
        osw_trace_inject(err2str(OSW_PRI_Q_BUMP_LOW_TAIL));
        retval = OSW_PRI_Q_BUMP_LOW_TAIL;
        int low_pri = get_lowest_pri();
        if (low_pri == OSW_PRIQ_FREE_IDX) {
          osw_error(OSW_PRI_Q_PRI_NOT_FOUND);
          osw_trace_inject(err2str(OSW_PRI_Q_PRI_NOT_FOUND));
          return OSW_PRI_Q_PRI_NOT_FOUND;
        }
        //  One final check.  If the message is lowest
        //  priority, then it is the "LOW_TAIL", and it's the
        //  message that needs to be dropped.
        if (low_pri == _priority) {
          //  Just bail out right here.  Message will be dropped.
          return OSW_PRI_Q_BUMP_LOW_TAIL;
        }
        data_idx = pop_pri_tail(low_pri);
        if (data_idx == -1) {
          osw_error(OSW_PRI_Q_FREE_NOT_FOUND);
          osw_trace_inject(err2str(OSW_PRI_Q_FREE_NOT_FOUND));
          return OSW_PRI_Q_FREE_NOT_FOUND;
        }
        
      } else if (_control == OSW_PRIQ_BUMP_PRI_HEAD_FULL) {
        //printf("OSW_PRIQ_BUMP_PRI_HEAD_FULL\n");
        osw_error(OSW_PRI_Q_BUMP_PRI_HEAD);
        osw_trace_inject(err2str(OSW_PRI_Q_BUMP_PRI_HEAD));
        retval = OSW_PRI_Q_BUMP_PRI_HEAD;
        data_idx = pop_pri_head(_priority);
        if (data_idx == -1) {
          osw_error(OSW_PRI_Q_FREE_NOT_FOUND);
          osw_trace_inject(err2str(OSW_PRI_Q_FREE_NOT_FOUND));
          return OSW_PRI_Q_FREE_NOT_FOUND;
        }
      }
    }
  }
  int prev_last_idx = push_pri_struct(data_idx, _priority);
  
  hdr.size = _size;
  hdr.tick = osw_getTick();
  hdr.prev = prev_last_idx;
  hdr.next = -1;
  // put the message.
  memcpy(&msgs_[max_msg_size_*data_idx], &hdr, (long)sizeof(Qheader));
  memcpy(&msgs_[(max_msg_size_*data_idx)+sizeof(Qheader)], _in_msg, _size);
  
  //bumped_msg
  if (retval != OSW_OK) return retval;
  
  osw_trace_off();
  Qsem_.semGive();
  osw_trace_on();
  return OSW_OK;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  priQreceive
//  Description: gets a message from the Q
//  Parameters:
//    _in_msg: buffer for the message,
//    _size: size of the buffer.  If it is too small, the incoming message
//           will be truncated,
//    _to_wait_ms: time to wait in millisecs.
//    _tick: If _tick is not OSW_NULL, it will be filled with
//           the tick value of when the message was sent.  That
//           can be used to determine how long the message was
//           sitting in the Q.
//  Return value:
//    positive value: the size of the message received.
//              returned message size <= _size.   If _size is smaller
//              than the message in the Q then the message will be
//              truncated to fit _size, the truncated part is lost.
//    OSW_SINGLE_THREAD: if still waiting for a message to arrive.
//    OSW_TIMEOUT: if timed out waiting (including OSW_NO_WAIT).
//    OSW_UNALLOCATED_MEM: if calling msgQreceive before msgQcreate
//    OSW_EXCEED_MAX_SIZE: if receiving message from 0-sized Q.
//////////////////////////////////////////////////////////////////////////////
int osw_priority_q::priQreceive(int* _priority,
    char* _in_msg,
    int _size,
    int _to_wait_ms,
    osw_tick_t* _tick)
{
  // sanity check
  if (!initialized_) {
    osw_error(OSW_UNALLOCATED_MEM);
    osw_trace_inject(err2str(OSW_UNALLOCATED_MEM));
    return OSW_UNALLOCATED_MEM;
  }
  if ((_priority == NULL) ||
      (_in_msg == NULL)) {
    osw_error(OSW_INVALID_PARAMETER);
    osw_trace_inject(err2str(OSW_INVALID_PARAMETER));
    return OSW_INVALID_PARAMETER;
  }
  // are there any messages?
  osw_trace_off();
  int retval = Qsem_.semTake(_to_wait_ms);
  osw_trace_on();
  if (retval == OSW_SINGLE_THREAD) return OSW_SINGLE_THREAD;
  if (retval == OSW_TIMEOUT) {
    osw_put_trace(OSW_WAIT_TIMEOUT);
    osw_put_trace(OSW_Q_RECEIVE);
    return OSW_TIMEOUT;
  }
  if (retval < 0) {
    // post error
    osw_error(OSW_GENERAL_ERROR);
    osw_trace_inject(err2str(OSW_GENERAL_ERROR));
    return retval;
  }
  
  //  Get the priority structure.
  int priority = get_highest_pri();
  if (priority == OSW_PRIQ_FREE_IDX) {
    osw_error(OSW_PRI_Q_PRI_NOT_FOUND);
    osw_trace_inject(err2str(OSW_PRI_Q_PRI_NOT_FOUND));
    return OSW_PRI_Q_PRI_NOT_FOUND;
  }
  *_priority = priority;
  int data_idx = pop_pri_head(priority);
  if (data_idx == -1) {
    osw_error(OSW_PRI_Q_FREE_NOT_FOUND);
    osw_trace_inject(err2str(OSW_PRI_Q_FREE_NOT_FOUND));
    return OSW_PRI_Q_FREE_NOT_FOUND;
  }
  
  // get the message.
  osw_tick_t tick = get_hdr_tick(data_idx);
  //int next = get_hdr_next(data_idx);
  if (_tick != NULL) *_tick = tick;
  int size = get_hdr_size(data_idx);
  if (size > _size) size = _size;
  memcpy(_in_msg, get_msg_data(data_idx), size);
  
  // do the bookkeeping.
  push_pri_struct(data_idx, OSW_PRIQ_FREE_IDX);
  
  osw_put_trace(OSW_Q_RECEIVE, size);
  return size;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  priQcount
//  Description: Returns the count of the Q entries of the specified priority.
//  Parameters: priority.
//  Return value: the count.
//////////////////////////////////////////////////////////////////////////////
int osw_priority_q::priQcount(int _priority)
{
  int count = 0;
  for (int i=0; i<priCount_; i++) {
    if (priList_[i].priority == OSW_PRIQ_FREE_IDX) continue;
    if (priList_[i].priority == _priority) return priList_[i].count;
    count += priList_[i].count;
  }
  if (_priority != OSW_ALL_PRIOIRITIES) return 0;
  return count;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  priQflush
//  Description: Empties all the Q entries of the specified priority.
//  Parameters: priority.
//  Return value: none.
//////////////////////////////////////////////////////////////////////////////
void osw_priority_q::priQflush(int _priority)
{
  for (int i=0; i<priCount_; i++) {
    if (priList_[i].priority == OSW_PRIQ_FREE_IDX) continue;
    if ((priList_[i].priority != _priority) &&
        (_priority != OSW_ALL_PRIOIRITIES)) continue;
    int data_idx;
    int pri = priList_[i].priority;
    while (1) {
      data_idx = pop_pri_head(pri);
      if (data_idx == -1) break;
      osw_trace_off();
      Qsem_.semTake();
      osw_trace_on();
      push_pri_struct(data_idx, OSW_PRIQ_FREE_IDX);
    }
    i = -1;  // go back to the beginning of the list.
  }
}

//////////////////////////////////////////////////////////////////////////////
//  priQ utilities, used internally by the priority message Q.
//////////////////////////////////////////////////////////////////////////////

inline int& osw_priority_q::get_hdr_size(int _idx)
{
  return ((Qheader*)(&msgs_[max_msg_size_ * _idx]))->size;
}

inline osw_tick_t& osw_priority_q::get_hdr_tick(int _idx)
{
  return ((Qheader*)(&msgs_[max_msg_size_ * _idx]))->tick;
}

inline int& osw_priority_q::get_hdr_prev(int _idx)
{
  return ((Qheader*)(&msgs_[max_msg_size_ * _idx]))->prev;
}

inline int& osw_priority_q::get_hdr_next(int _idx)
{
  return ((Qheader*)(&msgs_[max_msg_size_ * _idx]))->next;
}

inline char* osw_priority_q::get_msg_data(int _idx)
{
  return (char*)&msgs_[(max_msg_size_ * _idx) + sizeof(Qheader)];
}

int osw_priority_q::get_highest_pri(void)
{
  int max_pri = OSW_PRIQ_FREE_IDX;
  for (int i=0; i<priCount_; i++) {
    if (priList_[i].priority == OSW_PRIQ_FREE_IDX) continue;
    if (max_pri == OSW_PRIQ_FREE_IDX) max_pri = priList_[i].priority;
    if (priList_[i].priority > max_pri) {
      max_pri = priList_[i].priority;
    }
  }
  return max_pri;
}

int osw_priority_q::get_lowest_pri(void)
{
  int min_pri = OSW_PRIQ_FREE_IDX;
  for (int i=0; i<priCount_; i++) {
    if (priList_[i].priority == OSW_PRIQ_FREE_IDX) continue;
    if (min_pri == OSW_PRIQ_FREE_IDX) min_pri = priList_[i].priority;
    if (priList_[i].priority < min_pri) {
      min_pri = priList_[i].priority;
    }
  }
  return min_pri;
}

int osw_priority_q::get_pri_struct_idx(int _priority)
{
  for (int i=0; i<priCount_; i++) {
    if (priList_[i].priority == _priority) return i;
  }
  return -1;
}

int osw_priority_q::push_pri_struct(int _data_idx, int _priority)
{
  priListStruct sPri;
  int pri_idx = get_pri_struct_idx(_priority);
  if (pri_idx == -1) {
    if (priCount_ > max_num_priorities_) {
      // post error.
      osw_error(OSW_PRI_Q_TOO_MANY_PRI);
      osw_trace_inject(err2str(OSW_PRI_Q_TOO_MANY_PRI));
      return -1;
    }
    sPri.priority = _priority;
    sPri.count = 1;
    sPri.head = _data_idx;
    sPri.tail = _data_idx;
    priList_[priCount_] = sPri;
    ++priCount_;
    return -1;
  }
  //  take care of the priority structure.
  sPri = priList_[pri_idx];
  ++sPri.count;
  get_hdr_next(sPri.tail) = _data_idx;
  //  This is some really gnarly code here.
  //  Need to return the tail idx of what used to be
  //  the last "node".  Otherwise it get's overwitten when the
  //  hdr is written in the code calling this function. So now it's
  //  returned as the function's retval.
  //
  //get_hdr_prev(_data_idx) = sPri.tail; <-- got overwritten later
  int retval = sPri.tail;
  sPri.tail = _data_idx;
  priList_[pri_idx] = sPri;
  return retval;
}

int osw_priority_q::pop_pri_head(int _priority)
{
  priListStruct sPri;
  int pri_idx = get_pri_struct_idx(_priority);
  if (pri_idx == -1) return -1;
  sPri = priList_[pri_idx];
  --sPri.count;
  int data_idx = sPri.head;
  if (sPri.head == sPri.tail) {
    //  if head == tail then this is the final link for this priority.
    //  remove the element
    --priCount_;
    priList_[pri_idx] = priList_[priCount_];
    return data_idx;
  }
  sPri.head = get_hdr_next(data_idx);
  priList_[pri_idx] = sPri;
  return data_idx;
}

int osw_priority_q::pop_pri_tail(int _priority)
{
  priListStruct sPri;
  int pri_idx = get_pri_struct_idx(_priority);
  if (pri_idx == -1) return -1;
  sPri = priList_[pri_idx];
  --sPri.count;
  int data_idx = sPri.tail;
  if (sPri.head == sPri.tail) {
    //  if head == tail then this is the final link for this priority.
    //  remove the element
    --priCount_;
    priList_[pri_idx] = priList_[priCount_];
    return data_idx;
  }
  sPri.tail = get_hdr_prev(data_idx);
  priList_[pri_idx] = sPri;
  return data_idx;
}


/////////////////////////////////////////////////
//  Events
/////////////////////////////////////////////////

#ifdef OSW_USE_EVENTS

struct osw_event_pair {
  int event;
  osw_eventFucnPtr eventHandler;
};

static osw_event_pair osw_evt_event[OSW_MAX_EVENT_PAIRS];
static int osw_evt_pairCount;
static osw_message_q osw_event_q;
static bool osw_event_q_inited = false;
static osw_task osw_event_serivce_task;

void* osw_event_service_loop(void* _data)
{
  if (!osw_event_q_inited) {
    if (osw_event_q.msgQcreate("osw_eventQ", sizeof(int), OSW_EVENT_Q_DEPTH) != OSW_OK) {
      osw_error(OSW_MEM_ALLOC_FAILED);
      osw_trace_inject(err2str(OSW_MEM_ALLOC_FAILED));
    }
    osw_event_q_inited = true;
  }
  while (1) {
    int event;
    osw_trace_off();
    int result = osw_event_q.msgQreceive((char*)&event, sizeof(event));
    osw_trace_on();
    if (result == OSW_SINGLE_THREAD) return OSW_NULL;
    for (int i=0; i< osw_evt_pairCount; i++) {
      if (osw_evt_event[i].event == event) {
        osw_evt_event[i].eventHandler(event);
      }
    }
  }
  return OSW_NULL;
}

#ifdef OSW_EVENT_USE_TASK

//  Creates task when the constructors are run.  (even before the
//  Arduino setup() routine is called.
class osw_event_service_startup {
  public:
    osw_event_service_startup() {
      osw_event_serivce_task.taskCreate("tEventSv", osw_event_service_loop);
    }
} osw_event_service_start;

#endif

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_evt_register
//  Description: Set up an event/eventHandler pair to be activated when
//               the event is published.
//  Parameters: the event, and the eventHandler to be called.
//  Return value:
//      OSW_OK on success.
//      OSW_TOO_MANY_EVENT_PAIRS if OSW_MAX_EVENT_PAIRS is exceeded.
//////////////////////////////////////////////////////////////////////////////
int osw_evt_register(int _event, osw_eventFucnPtr _eventHandler)
{
  if (osw_evt_pairCount == OSW_MAX_EVENT_PAIRS) {
    osw_error(OSW_TOO_MANY_EVENT_PAIRS);
    osw_trace_inject(err2str(OSW_TOO_MANY_EVENT_PAIRS));
    return OSW_TOO_MANY_EVENT_PAIRS;
  }
  
  osw_evt_event[osw_evt_pairCount].event = _event;
  osw_evt_event[osw_evt_pairCount].eventHandler = _eventHandler;
  ++osw_evt_pairCount;
  
  osw_put_trace(OSW_EVT_REGISTER, _event);
  return OSW_OK;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_evt_publish
//  Description: Scans every event/eventHandler pair and call the
//               eventHandler for matching events.
//  Parameters: the event to publish
//  Return value:  none
//////////////////////////////////////////////////////////////////////////////
int osw_evt_publish(int _event)
{
  osw_trace_off();
  int retval = osw_event_q.msgQsend((char*)&_event, sizeof(_event));
  osw_trace_on();
  if (retval != OSW_OK) {
    osw_error(OSW_EVENT_SEND_FAIL);
    osw_trace_inject(err2str(OSW_EVENT_SEND_FAIL));
    return OSW_EVENT_SEND_FAIL;
  }
  osw_put_trace(OSW_EVT_PUBLISH, _event);
  return OSW_OK;
}

#endif  //OSW_USE_EVENTS

/////////////////////////////////////////////////
//  Shared Memory
/////////////////////////////////////////////////

//  A class used to set up a region of memory and then limit access so
//  that only one task writes or reads memory at a time.  Mostly useful
//  for interrupt handlers that need to read data and place it somewhere
//  for the application code to use.  This takes care of the flags and
//  latches so that no other task writes or reads while a task or interrupt
//  handler is writing or reading.
//  A pointer to the memory region needs to be provided, as well as a pointer
//  to an integer to be used as the controlling flag.  Usually the flag
//  integer is either the first or last word of the common region provided.
//  But the user is free to use something else.

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_shared_mem
//  Description: Constructor.
//  Parameters: none.
//  Return value: none.
//////////////////////////////////////////////////////////////////////////////
osw_shared_mem::osw_shared_mem(void):data_(OSW_NULL), flag_(OSW_NULL) {}

//////////////////////////////////////////////////////////////////////////////
//  function:  init_mem
//  Description: Needs to be called once before using read()'s and write()'s.
//               Set up the pointer to the shared memory space. And the
//               pointer to the integer field used as a control.
//  Parameters: pointer to the memory region.
//              pointer to the integer control field.
//  Return value:
//      OSW_OK on success.
//      OSW_TRANSFER_MEM_NULL if either parameter is OSW_NULL
//      OSW_ALREADY_INITIALIZED if the shared memory was already created.
//////////////////////////////////////////////////////////////////////////////
int osw_shared_mem::init_mem(unsigned char* _data, unsigned int* _flag) {
  if ((data_ != OSW_NULL) && (flag_ != OSW_NULL)) {
    osw_error(OSW_ALREADY_INITIALIZED);
    return OSW_ALREADY_INITIALIZED;
  }
  data_ = _data;
  flag_ = _flag;
  if ((data_ == OSW_NULL) || (flag_ == OSW_NULL)) {
    osw_error(OSW_SHARED_MEM_NULL);
    return OSW_SHARED_MEM_NULL;
  }
  *flag_ = 0;
  return OSW_OK;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  write
//  Description: Writes the data to the shared location, if possible.
//               Size is not checked.
//  Parameters: pointer to the data to write.
//              size of the data to write.
//  Return value:
//      OSW_OK on success.
//      OSW_TRANSFER_MEM_NULL if pointers have not be set up with a
//                            call to init_mem() first.
//      OSW_TRANSFER_MEM_BUSY if another thread is in the process of
//                            reading or writing to the shared memory.
//////////////////////////////////////////////////////////////////////////////
int osw_shared_mem::write(void* _data, int _size, bool _trace) {
  if (_trace) osw_put_trace(OSW_SHARED_WRITE, _size);
  if ((data_ == OSW_NULL) || (flag_ == OSW_NULL)) {
    osw_error(OSW_SHARED_MEM_NULL);
    osw_trace_inject(err2str(OSW_SHARED_MEM_NULL));
    return OSW_SHARED_MEM_NULL;
  }
  do {
    *flag_ &= 0x3fff; // clear the interrupt flag, atomic hopefully
    ++*flag_;  //  atomic, hopefully
    if ((*flag_ & 0x3fff) != 1) {
      --*flag_;   //  atomic, hopefully
      if ((*flag_ & 0x3fff) == 0x3fff) // something went wrong, flag went neg.
        *flag_ = 0x4000; // should never happen
      osw_error(OSW_SHARED_MEM_BUSY);
      osw_trace_inject(err2str(OSW_SHARED_MEM_BUSY));
      return OSW_SHARED_MEM_BUSY;
    }
    memcpy(data_, _data, _size);
    --*flag_;   //  atomic, hopefully
    if ((*flag_ & 0x3fff) == 0x3fff) // something went wrong
      *flag_ = 0x4000; // should never happen
  } while (*flag_ & 0x4000); // if an interrupt happened between time.
  return OSW_OK;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  read
//  Description: Reads the data from the shared location, if possible.
//               Size is not checked.
//  Parameters: pointer to the data to read.
//              size of the data to read.
//  Return value:
//      OSW_OK on success.
//      OSW_TRANSFER_MEM_NULL if pointers have not be set up with a
//                            call to init_mem() first.
//      OSW_TRANSFER_MEM_BUSY if another thread is in the process of
//                            reading or writing to the shared memory.
//////////////////////////////////////////////////////////////////////////////
int osw_shared_mem::read(void* _data, int _size, bool _trace) {
  if (_trace) osw_put_trace(OSW_SHARED_READ, _size);
  if ((data_ == OSW_NULL) || (flag_ == OSW_NULL)) {
    osw_error(OSW_SHARED_MEM_NULL);
    osw_trace_inject(err2str(OSW_SHARED_MEM_NULL));
    return OSW_SHARED_MEM_NULL;
  }
  do {
    *flag_ &= 0x3fff; // clear the interrupt flag, atomic hopefully
    ++*flag_;   //  atomic, hopefully
    if ((*flag_ & 0x3fff) != 1) {
      --*flag_;   //  atomic, hopefully
      if ((*flag_ & 0x3fff) == 0x3fff) // something went wrong, flag went neg.
        *flag_ = 0x4000; // should never happen
      osw_error(OSW_SHARED_MEM_BUSY);
      osw_trace_inject(err2str(OSW_SHARED_MEM_BUSY));
      return OSW_SHARED_MEM_BUSY;
    }
    memcpy(_data, data_, _size);
    --*flag_;   //  atomic, hopefully
    if ((*flag_ & 0x3fff) == 0x3fff) // something went wrong
      *flag_ = 0x4000; // should never happen
  } while (*flag_ & 0x4000); // if an interrupt happened between time.
  return OSW_OK;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  int_write
//  Description: This is the function to call from inside an interrupt 
//               handler.  To pass data out from an interrupt handler
//               to the application code. 
//               Writes the data to the shared location.
//               Size is not checked.
//  Parameters: pointer to the data to write.
//              size of the data to write.
//  Return value:
//      OSW_OK on success.
//      OSW_TRANSFER_MEM_NULL if pointers have not be set up with a
//                            call to init_mem() first.
//////////////////////////////////////////////////////////////////////////////
void osw_shared_mem::int_write(void* _data, int _size) {
  if ((data_ == OSW_NULL) || (flag_ == OSW_NULL)) return;
  
  //  Don't want to deal with the sign bit, so use the next highest 
  //  bit.  Different cpu/implementations handle sign bits vs unsigned
  //  int's differently.  Just don't use it, for maximum portability.
  //  Also, don't know if int is 16 or 32 bits, just use bit 14 (0-15)
  //  to avoid that problem too.  That still leaves a count up to 16K
  //  and if you have more than 16k threads trying to use the same
  //  memory, you've got bigger problems.
  *flag_ |= 0x4000;
  memcpy(data_, _data, _size);
}

/////////////////////////////////////////////////
//  Tasks
/////////////////////////////////////////////////

static bool osw_done_val = false;
static osw_task *tasklist[OSW_MAX_TASKS] = {OSW_NULL};    // max tasks
static int task_idx = 0; // the task we are currently performing
static int numTasks = 0; // total number of tasks

//////////////////////////////////////////////////////////////////////////////
//  function:  taskCreate
//  Description: Initializes the task.
//  Inputs:
//     _name is the name of the task
//     _the_func is the function ptr to the function that is the task.
//     _data is the parameter that is passed to the function when it's called.
//     _Hz is the Hz rate to run this task.  If this valude is nonzero
//         it will compute the number of ticks, and overwrite the _mod
//         parameter with the computed value.
//     _mod is a modulus of how often this task should be run modded off
//         the tick count.  Note that _Hz needs to be zero, or else the _Hz
//         calculation will overwrite the _mod value.
//     If both _Hz and _mod are zero (defaults) the task will be run every
//         time though the executive loop, (currently every tick).
//     _osw_trace (default true), traces the task in the trace log.
//         Note:  If it is a high frequency event that is hindering
//         debugging of other tasks in the trace log, that is when
//         it's a good idea to turn it off.
//     _active set the task active (default) or not.  Task will not be run
//         if it is inactive.  During run time a task can be activated or
//         deactivated by calling activateTask() and deactivateTask().
//  Outputs:
//     OSW_OK on success.
//     OSW_INVALID_PARAMETER if _name or _the_func are null.
//     OSW_TOO_MANY_TASKS if OSW_MAX_TASKS is exceeded.
//////////////////////////////////////////////////////////////////////////////
int osw_task::taskCreate(char *_name,
                         osw_funcptr _the_func,
                         void* _data,
                         unsigned int _interval_ms,  // call interval of the task.
                         bool _osw_trace,
                         bool _active)
{
  // sanity checks
  if ((_name == OSW_NULL) ||
      (_the_func == OSW_NULL)) {
    osw_error(OSW_INVALID_PARAMETER);
    osw_trace_inject(err2str(OSW_INVALID_PARAMETER));
    return OSW_INVALID_PARAMETER;
  }
  name_ = _name;
  the_func_ = _the_func;
  data_ = _data;
  osw_trace_ = _osw_trace;
  active_ = _active;
  tid_ = numTasks;
  mod_ = _interval_ms / OSW_MS_PER_TIC;
  tasklist[numTasks] = this;
  ++numTasks;
  if (numTasks >= OSW_MAX_TASKS) {
    //  post error
    numTasks = OSW_MAX_TASKS-1;
    osw_error(OSW_TOO_MANY_TASKS);
    osw_trace_inject(err2str(OSW_TOO_MANY_TASKS));
    return OSW_TOO_MANY_TASKS;
  }
  osw_put_trace(OSW_TASK_CREATE, (int)name_);
  return OSW_OK;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  taskDelete
//  Description: Removes the task from the task list.
//  Inputs:  none
//  Outputs:
//     OSW_OK on success.
//     OSW_TASK_NOT_FOUND if task not found (possibly already deleted)
//////////////////////////////////////////////////////////////////////////////
int osw_task::taskDelete()
{
  osw_put_trace(OSW_TASK_DELETE);
  for (int i=0; i < numTasks; i++) {
    if (tasklist[i] == this) {
      --numTasks;
      tasklist[i] = tasklist[numTasks];
      return OSW_OK;
    }
  }
  osw_error(OSW_TASK_NOT_FOUND);
  osw_trace_inject(err2str(OSW_TASK_NOT_FOUND));
  return OSW_TASK_NOT_FOUND;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_task_name
//  Description: Returns the name of task that is currently running.
//  Inputs:  none
//  Outputs: Returns the name of task that is currently running.
//////////////////////////////////////////////////////////////////////////////
char* osw_task_name(void)
{
  if (tasklist[task_idx] == OSW_NULL) return OSW_NULL;
  return tasklist[task_idx]->getName();
}

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_list_tasks
//  Description: Prints a list of all tasks and status, currently in the
//               task list.
//  Inputs:  none
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
void osw_list_tasks(void)
{
  char retstr[80];
  Serial.println("\ntid  Name       FuncPtr    Mod Active");
  for (int i=0; i < numTasks; i++) {
    //  Make the fixed size name str: tmps
    char tmps[] = "          ";
    int j = 0;
    while (tasklist[i]->name_[j] != '\0' && tmps[j] != '\0') {
      tmps[j] = tasklist[i]->name_[j];
      ++j;
    }
    //  sprintf() uses 2k of program memory, so doing it ourselves
    //  saves at least half that.
    //sprintf(retstr, "%i %s 0x%08x %5d %s", i, tmp, tasklist[i]->the_func_,
    //  tasklist[i]->mod_, (tasklist[i]->active_) ? "ACTIVE" : "INACTIVE");

    //  Write the tid:
    Serial.print(i);
    if      (i < 10) Serial.print("    ");
    else if (i < 100) Serial.print("   ");
    else if (i < 1000) Serial.print("  ");
    //  Write the Task name: tmps
    strcpy(retstr, tmps);
    strcat(retstr, " ");
    //  Write the Task function pointer, in base 10.
    int tmpi = (int)(tasklist[i]->the_func_);
    for (int i=0; i<8; i++) {
      tmps[i] = (tmpi % 10) + '0';
      tmpi /= 10;
    }
    tmps[8] = '\0';
    reverse(tmps);
    strcat(retstr, tmps);
    strcat(retstr, " ");
    // Write the task mod number
    tmpi = tasklist[i]->mod_;
    tmps[0] = (tmpi % 10) + '0';
    tmpi /= 10;
    for (int i=1; i<5; i++) {
      if (tmpi) tmps[i] = (tmpi % 10) + '0';
      else tmps[i] = ' ';
      tmpi /= 10;
    }
    tmps[5] = '\0';
    reverse(tmps);
    strcat(retstr, tmps);
    strcat(retstr, " ");
    //  write if the task is active or not.
    strcat(retstr, (tasklist[i]->active_) ? "ACTIVE" : "INACTIVE");
    Serial.println(retstr);
  }
}

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_tasks_go
//               osw_first_time_thru  (called only by osw_tasks_go)
//  Description: Runs the main executive loop.
//  Inputs:  none
//  Outputs: Returns the exit value for the program.
//////////////////////////////////////////////////////////////////////////////

//  Yes, arduino has its setup() routine.  But there's stuff
//  That has to happen after that, but before the rest of the run.
//  Use the setup() to do the Serial.begin()  but use this for
//  the banner, and the watch dog timer setup.
void osw_first_time_thru(void)
{
#ifdef OSW_TRACE_DUMP_PREV_RUN
  //  This dumps the previous run's trace sitting in EEPROM
  //  before this current run overwrites it.
  osw_dump_EEPROM_trace();
#endif
  
#ifdef OSW_STARTUP_BANNER
  //  this mean that the user is using the serial line for his work
  //  and is probably calling Serial.begin() from inside of the setup()
  //  routine.  If not, calling osw_banner() without calling Serial.begion()
  //  first will cause undefined behavior.
  osw_banner();
#endif
  
#ifdef OSW_USE_IDLE_TASK
#ifdef OSW_USE_PIN13_ARDUINO
  pinMode(13, OUTPUT);
#endif
#endif
  
#ifdef OSW_USE_HW_WATCHDOG_ARDUINO
  // valid call values are:
  //  WDTO_8S    (8 secs) (ATmega 168, 328, 1280, 2560 only)
  //  WDTO_4S    (4 secs) (ATmega 168, 328, 1280, 2560 only)
  //  WDTO_2S    (2 secs)
  //  WDTO_1S    (1 sec)
  //  WDTO_500MS (500 ms)
  //  WDTO_250MS (250 ms)
  //  WDTO_120MS (120 ms)
  //  WDTO_60MS  (60 ms)
  //  WDTO_30MS  (30 ms)
  //  WDTO_15MS  (15 ms)
  //
  //  While having a watchdog timer seems like a really good idea,
  //  if/when it expires it only resets the chip not the board
  //  So the serial line dies and requires a power-cycle to come back.
  //  Or worst case, it bricks the board.
  //  So, the watchdog timer should be the last thing added to the software
  //  because it's somewhat dangerous to use it for day to day development.
  osw_watchdog_enable(WDTO_2S);
#else
  osw_watchdog_enable(2000);
#endif
  osw_trace_inject("osw_tasks_go");
}

int osw_tasks_go(void)
{
  static unsigned long task_tic_count = 5;  // may want zero to mean something else.
  static osw_tick_t old_tic = 0;
  osw_tick_t tmp_tic = 0;
  
  static bool osw_first_time_thru_flag = true;
  if (osw_first_time_thru_flag) {
    osw_first_time_thru();
    osw_first_time_thru_flag = false;
  }

  if (osw_done_val) return osw_done_val;
  //  executive loop

#ifndef  OSW_SAFETY_CRITICAL_PARADIGM
  // execute the tasks that need to run as fast as possible (mod_ == 0)
  //  even faster than a system tick.
  osw_task* cur_task;
  for (task_idx = 0; task_idx < numTasks; task_idx++) {
    cur_task = tasklist[task_idx];
    if (cur_task && cur_task->active_) {
      if (!cur_task->mod_) {
        if (cur_task->osw_trace_ == false) osw_trace_off();
        cur_task->the_func_(cur_task->data_);
        if (cur_task->osw_trace_ == false) osw_trace_on();
      }
    }
  } // end for
#endif

  //  check for a system tick:
  tmp_tic = osw_getTick();
  if (tmp_tic == old_tic) {
#ifdef OSW_USE_IDLE_TASK
    osw_idle_task();
#endif
    return 0;
  }
  old_tic = tmp_tic;
  ++task_tic_count;
  osw_watchdog_reset();

  // execute the tasks that run at intervals at a Hz rate (mod_ != 0)
#ifdef  OSW_SAFETY_CRITICAL_PARADIGM
  osw_interrupt_disable();
#endif
  for (task_idx = 0; task_idx < numTasks; task_idx++) {
    osw_task* cur_task = tasklist[task_idx];
    if (cur_task && cur_task->active_) {
      //printf("t%s ", cur_task->name);
      if (!cur_task->mod_ || !(task_tic_count % cur_task->mod_)) {
        if (cur_task->osw_trace_ == false) osw_trace_off();
        //osw_put_trace(task_idx, TASK_START);
        cur_task->the_func_(cur_task->data_);
        //osw_put_trace(OSW_TASK_STOP);
        if (cur_task->osw_trace_ == false) osw_trace_on();
      }
    }
  } // end for

#ifdef  OSW_SAFETY_CRITICAL_PARADIGM
  osw_interrupt_enable();
#endif
  
  //os_trace.printBlock();
  return osw_done_val;
}


//////////////////////////////////////////////////////////////////////////////
//  function:  idle_task
//  Description: The idle task, user implementable.  Best use is to
//               increment a counter to be used as a measure of how
//               much idel time the system has.
//               For the DOS example a spinning twirly is used as an
//               indicator that the program is not hung.
//  Inputs:  none
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////

#ifdef OSW_USE_IDLE_TASK
void osw_idle_task(void)
{
  static unsigned long idle_count = 0;
  static osw_tick_t idle_tick = 0;
  static unsigned long idle_mod = 100;
  osw_tick_t new_tick = 0;
  osw_tick_t delta_t;
  ++idle_count;
  //  User code here:  For example come up with something for the
  //  idle task to do, like toggle a light or print a dot, no more
  //  than 5/sec no less than 1/sec.
  if (idle_count > idle_mod) {
#ifdef OSW_USE_PIN13_ARDUINO
    static bool toggle = false;
    if (toggle) digitalWrite(13, HIGH);
    else digitalWrite(13, LOW);
    toggle = !toggle;
#endif
    //Serial.print('.');
    idle_count = 0;
    new_tick = osw_getTick();
    delta_t = new_tick - idle_tick;
    idle_tick = new_tick;
    if (delta_t > 1000) {
      idle_mod = (idle_mod / 2) + 1;
      //Serial.print('/');
      //Serial.print(idle_mod);
    } else if (delta_t < 200) {
      idle_mod = (idle_mod * 2) + 1;
      //Serial.print('*');
      //Serial.print(idle_mod);
    }
  }
}
#endif

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_done
//  Description: Returns the value of the done flag.  Used to terminate the
//               the program, and that parent programs can have
//               into the operation of os_wrap.
//  Inputs:  none
//  Outputs: returns the osw_done_val.
//////////////////////////////////////////////////////////////////////////////
int osw_done(void)
{
  return osw_done_val;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_done
//  Description: Sets the osw_done_val to non-zero and terminats the os_wrap
//               program.  Any non-zero value can be used, in this way
//               error code can be delivered to parent programs that run
//               os_wrap.
//  Inputs:  exit code.
//  Outputs: none.
//////////////////////////////////////////////////////////////////////////////
void osw_exit(int _code)
{
  osw_put_trace(OSW_EXIT);
  osw_done_val = _code;
  // make sure osw_done_val is non-zero.
  if (osw_done_val == 0) osw_done_val = OSW_SINGLE_THREAD;
}


/////////////////////////////////////////////////
//  OS Trace
/////////////////////////////////////////////////
#ifdef OSW_USE_TRACE

class osw_trace {
  public:
    osw_trace(bool _echo = false,
              void* _address = (void*)-1,
              long _size = 0);
    //  log to a block of memory.
    int init_eeprom(void* _address, long _size);
    //  log to the console.
    int init(bool _echo);
    void trace(osw_trace_enum _event, int _val = 0);
    void traceInject(char* _str);
    void traceOn(void);
    void traceForceOn(void);
    void traceOff(void);
    void printBlock(char* _filename);
    void flush(void);
    void dumpEEPROMTrace(void);
  private:
    osw_log trace_log;
    int seq_no_;
    int trace_off_;
    char* filename_;
    void* address_;
    long size_;
    bool echo_;
};

//  This is an example of setting up the os_trace
#ifdef OSW_TRACE_ECHO
static osw_trace os_trace(true,
                          OSW_TRACE_EEPROM_START,
                          OSW_TRACE_EEPROM_END - OSW_TRACE_EEPROM_START);
#else
static osw_trace os_trace(false,
                          OSW_TRACE_EEPROM_START,
                          OSW_TRACE_EEPROM_END - OSW_TRACE_EEPROM_START);
#endif

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_trace
//               various init functions
//  Description: This sets up the osw event trace that traces when tasks
//               are run, when semaphores are given and when message queues
//               are used.  Useful as a debugging tool.
//  Inputs:  Allow the options to send the osw event trace to a file with
//           _filename.  To echo it to the console (if it exists) with _echo.
//           Or to send it to a block of memory at _address and _size.
//           The init functions allow these to be set at a time later than
//           construction time.  The init function mirror the init functions
//           for the osw_log class.  In fact, this event logger uses the
//           the osw_log to do it.
//  Outputs: none.
//////////////////////////////////////////////////////////////////////////////
osw_trace::osw_trace(bool _echo,
                     void* _address,
                     long _size):
                     address_(_address),
                     size_(_size),
                     echo_(_echo),
                     seq_no_(0),
                     trace_off_(0)
{
  trace_log.init(echo_);
  if ((address_ != (void*)-1) && (size_ > 2)) {
    trace_log.init_eeprom(address_, size_);
  }
}

//////////////////////////////////////////////////////////////////////////////
//  function:  traceOn
//             traceForceOn
//             traceOff
//  Description: Since message queues use semaphores, when a queue event
//               happens, there are corresponding semaphore events.  During
//               a queue event, the trace Off function is called so that
//               the semaphore's redundant information is not also logged.
//
//               traceOn and traceOff can also be nested.  But sometimes
//               the trace needs to be on without knowledge of how deep the
//               nesting is, so traceForceOn turns on the trace regardless
//               of nesting.
//  Inputs:  none.
//  Outputs: none.
//////////////////////////////////////////////////////////////////////////////
void osw_trace::traceOn(void)
{
  if (trace_off_ > 0) --trace_off_;
}

void osw_trace::traceForceOn(void)
{
  trace_off_ = 0;
}

void osw_trace::traceOff(void)
{
  ++trace_off_;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  printBlock
//  Description: This function will dump the address and size of the event
//               log and put it into the specified filename.  Note that the
//               .blk suffix is added to the filename.
//  Inputs:  none.
//  Outputs: none.
//////////////////////////////////////////////////////////////////////////////
void osw_trace::printBlock(char* _filename)
{
  trace_log.mem2file();
}


//////////////////////////////////////////////////////////////////////////////
//  function:  trace
//  Description: This is the function that takes events and values and
//               writes them to the log in ASCII.
//  Inputs:
//       _event: the event that this is recording
//       _val: an optional associated value to provide more information.
//             for example a message queue event may have happened, it would
//             also be helpful to know the size of the message that was
//             passed.  The _val variable can be used for that.
//  Outputs: none.
//////////////////////////////////////////////////////////////////////////////
void osw_trace::trace(osw_trace_enum _event, int _val)
{
  if (trace_off_) return;
  
  ++seq_no_;
  
  //trace_log.logi(seq_no_);    trace_log.logc(' ');
#ifdef OSW_TRACE_TICK
  trace_log.logi(osw_getTick());  trace_log.logc(' ');
#endif
#ifdef OSW_TRACE_TIME
  trace_log.logs(osw_ttoa(osw_getTick()));  trace_log.logc(' ');
#endif
  //if (tasklist[task_idx]->getTrace()) {
  trace_log.logc('T');
  trace_log.logi(task_idx);
  trace_log.logc(' ');
  //}
  switch (_event) {
    case OSW_TASK_CREATE: trace_log.logs("Tc "); trace_log.logs((char*)_val); break;
    case OSW_TASK_DELETE: trace_log.logs("Td"); break;
    case OSW_TASK_START:  trace_log.logs("+"); break;
    case OSW_TASK_STOP:   trace_log.logs("-"); break;
    case OSW_Q_CREATE:    trace_log.logs("Qc "); trace_log.logs((char*)_val); break;
    case OSW_Q_TEE:       trace_log.logs("Qt "); trace_log.logs((char*)_val); break;
    case OSW_Q_UNTEE:     trace_log.logs("Qut "); trace_log.logs((char*)_val); break;
    case OSW_Q_RECEIVE:   trace_log.logs("QR"); trace_log.logi(_val); break;
    case OSW_Q_SEND:      trace_log.logs("QS"); trace_log.logi(_val);  break;
    case OSW_Q_FLUSH:     trace_log.logs("QF");  break;
    case OSW_SHARED_WRITE:trace_log.logs("SW"); trace_log.logi(_val); break;
    case OSW_SHARED_READ: trace_log.logs("SR"); trace_log.logi(_val);  break;
    case OSW_BSEM_CREATE: trace_log.logs("Sc "); trace_log.logs((char*)_val); break;
    case OSW_BSEM_TAKE:   trace_log.logs("ST"); break;
    case OSW_BSEM_GIVE:   trace_log.logs("SG"); break;
    case OSW_BSEM_TEE:    trace_log.logs("St "); trace_log.logs((char*)_val); break;
    case OSW_BSEM_UNTEE:  trace_log.logs("Sut "); trace_log.logs((char*)_val); break;
    case OSW_CSEM_CREATE: trace_log.logs("SCc "); trace_log.logs((char*)_val); break;
    case OSW_CSEM_TAKE:   trace_log.logs("SCT"); trace_log.logi(_val);  break;
    case OSW_CSEM_GIVE:   trace_log.logs("SCG"); trace_log.logi(_val);  break;
    case OSW_CSEM_FLUSH:  trace_log.logs("SCF");  break;
    case OSW_EVT_PUBLISH: trace_log.logs("EVP"); trace_log.logi(_val);  break;
    case OSW_EVT_REGISTER:trace_log.logs("EVR"); trace_log.logi(_val);  break;
    case OSW_MEM_MALLOC:  trace_log.logs("Mget"); trace_log.logi(_val);  break;
    case OSW_MEM_FREE:    trace_log.logs("Mfree0x"); trace_log.logx(_val);  break;
    case OSW_WAIT_TIMEOUT:trace_log.logs("TimeOut"); break;
    case OSW_EXIT:        trace_log.logs("exit"); break;
  }
  trace_log.logc('\n');
}

//////////////////////////////////////////////////////////////////////////////
//  function:  traceInject
//  Description: Inject a string directly into the trace log.
//  Inputs: _str: the string to write to the log.
//  Outputs: none.
//////////////////////////////////////////////////////////////////////////////
void osw_trace::traceInject(char* _str)
{
  ++seq_no_;
  
  //trace_log.logi(seq_no_);    trace_log.logc(' ');
#ifdef OSW_TRACE_TICK
  trace_log.logi(osw_getTick());  trace_log.logc(' ');
#endif
#ifdef OSW_TRACE_TIME
  trace_log.logs(osw_ttoa(osw_getTick()));  trace_log.logc(' ');
#endif
  if (_str != OSW_NULL) trace_log.logs(_str);
  trace_log.logc('\n');
}

//////////////////////////////////////////////////////////////////////////////
//  function:  flush
//  Description: Flushes file buffers to the file (if there are any)
//  Inputs: none
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
void osw_trace::flush(void)
{
  trace_log.flush();
}

//////////////////////////////////////////////////////////////////////////////
//  function:  dumpTrace
//  Description: Dumps the log in EEPROM
//  Inputs: none
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
void osw_trace::dumpEEPROMTrace(void)
{
  trace_log.dumpLog();
}

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_put_trace
//             osw_trace_inject
//             osw_trace_on
//             osw_trace_off
//             osw_dump_EEPROM_trace
//             osw_trace_flush
//  Description: C function wrapper functions.  This is the user API.
//  Inputs: various
//  Outputs: various
//////////////////////////////////////////////////////////////////////////////
void osw_put_trace(osw_trace_enum _event, int _val)
{
  os_trace.trace(_event, _val);
}

//  The user can inject a string into the osw trace.
void osw_trace_inject(char* _str)
{
  os_trace.traceInject(_str);
}

void osw_trace_on(void)
{
  os_trace.traceOn();
}

void osw_trace_off(void)
{
  os_trace.traceOff();
}

//  Dumps the memory to the serial port.
void osw_dump_EEPROM_trace(void)
{
  os_trace.dumpEEPROMTrace();
}

//  Flushes the trace buffers (if they exist) (i.e. to a file).
void osw_trace_flush(void)
{
  os_trace.flush();
}


#else

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_put_trace
//             osw_trace_inject
//             osw_trace_on
//             osw_trace_off
//             osw_dump_EEPROM_trace
//             osw_trace_flush
//  Description: C functions.  This is the user API.  If OSW_USE_TRACE
//               is not defined, these fuctions are empty.
//  Inputs: various
//  Outputs: various
//////////////////////////////////////////////////////////////////////////////
void osw_put_trace(osw_trace_enum _event, int _val){}
//  The user can inject a string into the osw trace.
void osw_trace_inject(char* _str) {}
void osw_trace_on(void){}
void osw_trace_off(void){}
//  Dumps the memory to the serial port.
void osw_dump_EEPROM_trace(void){}
//  Flushes the trace buffers (if they exist) (i.e. to a file).
void osw_trace_flush(void){}

#endif

/////////////////////////////////////////////////
//  Logging service.
/////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_log
//  Description: Constructor. If using stdio, can setup a file for syslog.
//  Inputs: none
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
osw_log::osw_log():
                 base_(OSW_NULL),
                 curptr_(OSW_NULL),
                 size_(0),
                 end_(OSW_NULL),
                 echo_(false)
{
} //osw_log::osw_log()

//////////////////////////////////////////////////////////////////////////////
//  function:  ~osw_log
//  Description: Destructor.
//  Inputs: none
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
osw_log::~osw_log()
{
} //osw_log::~osw_log()

//////////////////////////////////////////////////////////////////////////////
//  function:  init
//  Description: Initializes a log of a specified size at a specified
//               location.
//  Inputs: The address and size of the memory where to place the log.
//  Outputs:
//     OSW_OK on success
//     OSW_ALREADY_INITIALIZED if the log is already initialized
//////////////////////////////////////////////////////////////////////////////
int osw_log::init_eeprom(void* _address, long _size)
{
  if (base_ != OSW_NULL) return OSW_ALREADY_INITIALIZED;
  if (curptr_ != OSW_NULL) return OSW_ALREADY_INITIALIZED;
  if (size_ != 0) return OSW_ALREADY_INITIALIZED;
  if (end_ != OSW_NULL) return OSW_ALREADY_INITIALIZED;
  
  base_ = (char*)_address;
  curptr_ = base_;
  base_ +=2;
  size_ = _size - 3;
  end_ = (char*)((long)base_ + size_);
  //  unsigned because new boards are all 0xff.
  unsigned int addr = eepromRead16((int)curptr_);
  if ((addr > (unsigned int)end_) ||
      (addr < (unsigned int)base_))
    eepromWrite16((int)curptr_, (int)base_);
  return OSW_OK;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  init
//  Description: This init function is used to turn on and off sending
//               the log to the console.  This init function can be used
//               in conjuction with sending the log to memory, a file,
//               or a socket.
//  Inputs: The true/false, send the log to the console.
//  Outputs:
//     OSW_OK on success
//////////////////////////////////////////////////////////////////////////////
int osw_log::init(bool _echo)
{
  echo_ = _echo;
#ifndef OSW_USE_SERIAL_IO
  echo_ = false;
#endif
  return OSW_OK;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  logc
//  Description: Writes a single character to the log.
//  Inputs: The char to write.
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
void osw_log::logc(char _c)
{
  //  if we are writing to a memory block:
  if (base_ != OSW_NULL) {
    int addr = eepromRead16((int)curptr_);
    eepromWrite8(addr, _c);
    ++addr;
    if (addr > (int)end_) addr = (int)base_;
    eepromWrite16((int)curptr_, addr);
  }
  
  //  we we re spitting this out to a console useing <stdio.h>
  if (echo_ == true) {
    if (_c != '\0')
      Serial.print(_c);
  }
}

//////////////////////////////////////////////////////////////////////////////
//  function:  logs
//  Description: Writes a string to the log.
//  Inputs: The string to write.
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
void osw_log::logs(char* _s)
{
  // sanity check
  if (_s == OSW_NULL) return;
  
  while (*_s) {
    logc(*_s);
    ++_s;
  }
  //  do we write the trailing '\0' or not?
  //logc(*_s);
}

//////////////////////////////////////////////////////////////////////////////
//  function:  logi
//  Description: Writes an integer in base 10 to the log.
//  Inputs: The integer to write.
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
//  K&R pg 64
void osw_log::logi(long _n)
{
  logs(itoa(_n));
}

//////////////////////////////////////////////////////////////////////////////
//  function:  logi
//  Description: Writes an integer in hex (base 16) to the log.
//  Inputs: The integer to write.
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
void osw_log::logx(long _i)
{
  logs(itoa(_i, 16));
}

//////////////////////////////////////////////////////////////////////////////
//  function:  mem2file
//  Description: Post mortum function.  After the run is complete this
//               function can be used to write the log saved in a block
//               of memory to a specified file.
//  Inputs: The filename to write.
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
void osw_log::mem2file(void)
{
  if (base_ == OSW_NULL) return;
  
  int addr = eepromRead16((int)curptr_);
  for (int i = 0; i<size_; i++) {
    char c = eepromRead8((int)addr);
    ++addr;
    if (addr > (int)end_) addr = (int)base_;
    if (c == 0) Serial.println();
    Serial.print(c, BYTE);
  }
} /**/

void osw_log::dumpLog(void)
{
#ifndef OSW_USE_SERIAL_IO
  return;
#endif
  if (base_ == OSW_NULL) return;
  int addr = eepromRead16((int)curptr_);
  int start_addr = addr;
  for (int i = 0; i<size_+5; i++) {
    char c = eepromRead8(addr);
    if (c == '\n') Serial.println();
    else if (c < ' ') Serial.print(' ');
    else if (c > 'z') Serial.print(' ');
    else Serial.print(c);
    ++addr;
    if (addr > (int)end_) addr = (int)base_;
    if (addr == start_addr) break;
  }
  Serial.println("END\n");
}


/////////////////////////////////////////////////
//  Utility library functions needed by others.
/////////////////////////////////////////////////


//////////////////////////////////////////////////////////////////////////////
//  function:  align4
//  Description: Pushes the value up to the next multiple of 4.
//      Not needed for Arduino.  But it's a simple spiffy function.
//  Inputs: The value to align.
//  Outputs: The aligned value.
//////////////////////////////////////////////////////////////////////////////
inline int align4(int _val)
{
  _val += 3;
  _val &= ~3;
  return _val;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  xdump
//  Description: dumps a buffer to the serial port.
//  Inputs: Buffer and size.
//  Outputs: none.
//////////////////////////////////////////////////////////////////////////////
void xdump(unsigned char* _buf, int _size)
{
#ifdef OSW_USE_SERIAL_IO
  Serial.println();
  for (int i=0; i<_size; ++i) {
    if (_buf[i] < 16) Serial.print('0');  // leading zero
    Serial.print(_buf[i], HEX);
    if (!((i+1) %4)) Serial.print(' ');
    if (!((i+1) %16)) Serial.println();
  }
  Serial.println();
#endif
}

//////////////////////////////////////////////////////////////////////////////
//  function:  reverse
//  Description: reverse string s in place.  K&R pg 62
//  Inputs: The string to reverse.
//  Outputs: none.
//////////////////////////////////////////////////////////////////////////////
void reverse(char s[])
{
  int c, i, j;
  for(i=0, j=strlen(s)-1; i<j; i++, j--) {
    c = s[i];
    s[i] = s[j];
    s[j] = c;
  }
}

//////////////////////////////////////////////////////////////////////////////
//  function:  itoa
//  Description: Convert an integer to a string.  K&R pg 64
//  Inputs: The number n, and the base b to convert it to.
//          should work from base 2 - 36 (at 36 all the letters
//          of the alphabit are used).
//  Outputs: The string digits of the number.
//////////////////////////////////////////////////////////////////////////////
char* itoa(long n, int base)
{
  static char tmp[255];
  int i = 0;
  long sign = n;
  if (n < 0)
    n = -n;
  do {
    tmp[i] = (n % base);
    if (tmp[i] < 10) tmp[i] += '0';
    else tmp[i] += 'a' - 10;
    n /= base;
    ++i;
  } while (n > 0);
  if (sign < 0) {
    tmp[i] = '-';
    ++i;
  }
  tmp[i] = '\0';
  reverse(tmp);
  return tmp;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  stdlib functions:
//                 strlen()
//                 strcpy()
//                 strncpy()
//                 strcat()
//                 strncat()
//                 memcpy()
//
//  Description: Since os_wrap was meant to operate without access to the
//               standard libraries, these are the library functions that
//               are used, and need to be provided by hand.
//////////////////////////////////////////////////////////////////////////////
#ifndef OSW_USE_STDSTRING
int strlen(char* _s)
{
  int i = 0;
  while (*_s != 0) {
    ++i;
    ++_s;
  }
  return i;
}

void strcpy(char* _dest, char* _source)
{
  while (*_source != 0) {
    *_dest = *_source;
    ++_dest;
    ++_source;
  }
  *_dest = *_source;
}

void strncpy(char* _dest, char* _source, int _len)
{
  while ((*_source != 0) && _len) {
    *_dest = *_source;
    ++_dest;
    ++_source;
    --_len;
  }
  *_dest = *_source;
}

void strcat(char* _dest, char* _source)
{
  while (*_dest != 0) {
    ++_dest;
  }
  while (*_source != 0) {
    *_dest = *_source;
    ++_dest;
    ++_source;
  }
  *_dest = *_source;
}

void strncat(char* _dest, char* _source, int _len)
{
  while (*_dest != 0) {
    ++_dest;
  }
  while ((*_source != 0) && _len) {
    *_dest = *_source;
    ++_dest;
    ++_source;
    --_len;
  }
  *_dest = '\0';
}

int memcpy(void* _dest, void* _source, long _size)
{
  char* d = (char*)_dest;
  char* s = (char*)_source;
  int i;
  
  for (i=0; i<_size; ++i) {
    *d = *s;
    ++d;
    ++s;
  }
  return i;
}
#endif  //OSW_USE_STDSTRING

//  We want these to be in program memory whether the banner
//  is printed or not.
const unsigned char copywriteP[] PROGMEM =
    "OS Wrap, multitaking wrapper\n"
    "MindSpace Research (c) 1999-2011\n";

const unsigned char versionP[] PROGMEM = "Version: " OS_WRAP_VERSION;
const unsigned char compiledP[] PROGMEM = "Compiled: " __DATE__ "  " __TIME__;


#ifdef OSW_STARTUP_BANNER
const unsigned char bannerP[] PROGMEM =
    "\n########   #  ####   ######    ######  ######    #####    #####  ######\n"
    "#   #   #  #  #   #  #     #  #        #     #  #     #  #       #\n"
    "#   #   #  #  #   #  #     #   #####   ######   #######  #       ######\n"
    "#   #   #  #  #   #  #     #        #  #        #     #  #       #\n"
    "#   #   #  #  #   #  ######   ######   #        #     #   #####  ######\n"
    "R=========E=========S=========E=========A=========R=========C=========H\n\n"
    
    "                      Computing the World Within\n\n";

void osw_banner(void)
{
#ifdef OSW_USE_SERIAL_IO
  printP(bannerP);
  printP(copywriteP);
  printP(versionP);
  printP(compiledP);
  Serial.println();
#endif
}
#endif  //OSW_STARTUP_BANNER



/////////////////////////////////////////////////
//  End of os_wrap
/////////////////////////////////////////////////


