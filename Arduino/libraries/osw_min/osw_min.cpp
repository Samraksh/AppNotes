///////////////////////////////////////////////////////////////////////////
// osw_min.cc
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


#include"osw_min.h"

/////////////////////////////////////////////////
//  This version of osw_min
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
//    by Michaael Margolis, pg 535
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
const prog_uchar err5001P[] PROGMEM = "OSW_MEM_ALLOC_FAILED";     //(-5001)
const prog_uchar err5002P[] PROGMEM = "OSW_UNALLOCATED_MEM";      //(-5002)
const prog_uchar err5003P[] PROGMEM = "OSW_EXCEED_MAX_SIZE";      //(-5003)
const prog_uchar err5004P[] PROGMEM = "OSW_TOO_MANY_TEES";        //(-5004)
const prog_uchar err5005P[] PROGMEM = "OSW_UNTEE_ERROR";          //(-5005)
const prog_uchar err5006P[] PROGMEM = "OSW_MSG_Q_FULL_BUMP";      //(-5006)
const prog_uchar err5007P[] PROGMEM = "OSW_MSG_Q_FULL_REJECT";    //(-5007)
const prog_uchar err5008P[] PROGMEM = "OSW_PKD_Q_FULL";           //(-5008)
const prog_uchar err5009P[] PROGMEM = "OSW_TOO_MANY_TASKS";       //(-5009)
const prog_uchar err5010P[] PROGMEM = "OSW_TASK_NOT_FOUND";       //(-5010)
const prog_uchar err5011P[] PROGMEM = "OSW_UNDER_MIN_SIZE";       //(-5011)
const prog_uchar err5012P[] PROGMEM = "OSW_INVALID_PARAMETER";    //(-5012)
const prog_uchar err5013P[] PROGMEM = "OSW_TOO_MANY_EVENT_PAIRS"; //(-5013)
const prog_uchar err5014P[] PROGMEM = "OSW_MEM_VALID_FAIL";       //(-5014)
const prog_uchar err5015P[] PROGMEM = "OSW_TIMEOUT";              //(-5015)
const prog_uchar err5016P[] PROGMEM = "OSW_ALREADY_INITIALIZED";  //(-5016)
const prog_uchar err5017P[] PROGMEM = "OSW_SHARED_MEM_NULL";      //(-5017)
const prog_uchar err5018P[] PROGMEM = "OSW_SHARED_MEM_BUSY";      //(-5018)
const prog_uchar err5019P[] PROGMEM = "OSW_EVENT_SEND_FAIL";      //(-5019)
const prog_uchar err5020P[] PROGMEM = "OSW_PRI_Q_FULL_REJECT";    //(-5020)
const prog_uchar err5021P[] PROGMEM = "OSW_PRI_Q_PRI_NOT_FOUND";  //(-5021)
const prog_uchar err5022P[] PROGMEM = "OSW_PRI_Q_FREE_NOT_FOUND"; //(-5022)
const prog_uchar err5023P[] PROGMEM = "OSW_PRI_Q_BUMP_PRI_HEAD";  //(-5023)
const prog_uchar err5024P[] PROGMEM = "OSW_PRI_Q_BUMP_LOW_HEAD";  //(-5024)
const prog_uchar err5025P[] PROGMEM = "OSW_PRI_Q_BUMP_LOW_TAIL";  //(-5025)
const prog_uchar err5026P[] PROGMEM = "OSW_PRI_Q_TOO_MANY_PRI";   //(-5026)
const prog_uchar err5027P[] PROGMEM = "OSW_GENERAL_ERROR";        //(-5027)

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
void printP(const prog_uchar* _str, bool _new_line)
{
#ifdef OSW_USE_SERIAL_IO
  char c;
  while ((c = pgm_read_byte(_str++)))
    Serial.print(c, BYTE);
  if (_new_line) Serial.print('\n');
#endif
}

//////////////////////////////////////////////////////////////////////////////
//  function:  err2str
//  Description: Utility function to take error messages stored in
//    program memory and deliver them as strings.
//
//  Inputs: Program memory error string.
//  Outputs: The usable string out of program memory.
//////////////////////////////////////////////////////////////////////////////
char* err2str(int _error)
{
  const prog_uchar* _str = err2pMsg(_error);
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
#ifdef OSW_USE_TASKS
  odem_task_.taskCreate("tOdometer", odometer_main_loop, OSW_NULL, 100);
#endif
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
//    necessary to set a new board to 0, because for a new arduino board,
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
//  memory manager.
/////////////////////////////////////////////////

//  Here the memory manager will use standare malloc and free.

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_malloc
//  Description: Calls malloc().
//
//  Inputs: Number of bytes.
//  Outputs: Pointer to memory buffer.
//////////////////////////////////////////////////////////////////////////////
osw_mem_t osw_malloc(int _num_bytes) {
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
    //  tens of days
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
//  Uses getTick() and diffTime_ms() from os_wrap.
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
osw_dt_timer::osw_dt_timer(osw_tick_t _msTimeout):
                           msTimeout_(_msTimeout),
                           engaged_(true),
                           tick_(osw_getTick())
{
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
                           engaged_(_source.engaged_)
{
}

//////////////////////////////////////////////////////////////////////////////
//  function:  getDuration
//  Description: Returns what the time-out duration is.
//
//  Inputs:  none.
//  Outputs:  Returns what the time-out duration is.
//////////////////////////////////////////////////////////////////////////////
inline osw_tick_t osw_dt_timer::getDuration(void)
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
inline void osw_dt_timer::setDuration(osw_tick_t _msTimeout)
{
  msTimeout_ = _msTimeout;
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
  return *this;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  start
//  Description: Starts the timer running.
//
//  Inputs:  time-out value in milisecs.
//  Outputs:  none.
//////////////////////////////////////////////////////////////////////////////
void osw_dt_timer::start(osw_tick_t _msTimeout)
{
  if (_msTimeout != OSW_USE_PREVIOUS_VALUE)
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
  engaged_ = false;
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
  if (engaged_ == false) return false;
  if (msTimeout_ == OSW_WAIT_FOREVER) return true;
  if (osw_diffTime_ms(tick_) >= msTimeout_) {
    //printf("tick_:%i gettick:%i\n", tick_, getTick());
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
osw_tick_t osw_dt_timer::msTimeLeft(void)
{
  if (engaged_ == false) return 0;
  //  If it's waiting forever, it's always 1 ms from timing out.
  if (msTimeout_ == OSW_WAIT_FOREVER) return 1;
  //  If it's paused.
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
osw_tick_t osw_dt_timer::msAge(void)
{
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
  interrupts();
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
  noInterrupts();
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
    return osw_diffTime_ms(sem_tick_) + 1; // force non-zero
  }
  
  if (_to_wait_ms == OSW_WAIT_FOREVER) return OSW_SINGLE_THREAD;
  if (_to_wait_ms == OSW_NO_WAIT) {
    return OSW_TIMEOUT;
  }
  
  // If the semaphore's not available, see if we expired.
  if (osw_diffTime_ms(sem_tick_) > _to_wait_ms) {
    sem_tick_ = osw_getTick();
    return OSW_TIMEOUT;
  }
  return OSW_SINGLE_THREAD;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  semGive
//               semSend
//  Description: Give the semaphore, and give the semaphore to all
//               semaphores that are tee-ed off of this semaphore.
//  Inputs: none.
//  Outputs:
//     returns OSW_OK.
//////////////////////////////////////////////////////////////////////////////
int osw_semaphore::semGive()
{
  sem_ = true;
  sem_tick_ = osw_getTick();
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
//  function:  ~osw_semaphore
//  Description: Destructor.
//  Inputs: none
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
osw_counting_sem::~osw_counting_sem()
{
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
  semSem_.semCreate(_name, 0);
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
    retval =  semSem_.semTake(_to_wait_ms);  // block here.
    if (retval < 0) return retval;
  }
  
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
  semSem_.semGive();
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
  semSem_.semTake(OSW_NO_WAIT);
}

/////////////////////////////////////////////////
//  Message Queue
/////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_message_q
//  Description: Constructor.  Initizes the tee list to NULL.
//  Inputs: none
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
osw_message_q::osw_message_q()
{
  msg_array_ = OSW_NULL;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  ~osw_message_q
//  Description: Destructor.  Frees the tee list.
//  Inputs: none
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
osw_message_q::~osw_message_q()
{
  if (msg_array_ != OSW_NULL) {
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
    return OSW_ALREADY_INITIALIZED;
  }
  if ((_max_msg_size < 0) || (_max_msgs < 0)) {
    osw_error(OSW_INVALID_PARAMETER);
    return OSW_INVALID_PARAMETER;
  }
  if (_name == OSW_NULL) {
    osw_error(OSW_INVALID_PARAMETER);
    return OSW_INVALID_PARAMETER;
  }
  
  // initialize.
  max_msg_size_ = sizeof(Qheader)+_max_msg_size;
  max_msgs_ = _max_msgs;
  tail_ = 0;
  head_ = 0;
  name_ = _name;
  
  if (_max_msgs == 0) {  // don't need to do anything else here.
    return OSW_OK;
  }
  if ((_max_msg_size < 1) && (_max_msgs > 0)) {
    osw_error(OSW_UNDER_MIN_SIZE);
    return OSW_UNDER_MIN_SIZE;
  }
  
  Qsem_.semCreate(_name);
  // allocate the message queue.
  //  Allocate space for the message size and the message.
  //msg_array_ = new(char[_max_msgs * max_msg_size_]);
  if (max_msgs_ != 0) {
    msg_array_ = (char*)osw_malloc(_max_msgs * max_msg_size_);
    if (msg_array_ == OSW_NULL) {
      // POST ERROR
      osw_error(OSW_MEM_ALLOC_FAILED);
      return OSW_MEM_ALLOC_FAILED;
    }
  }
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
    osw_tick_t* _tick)
{
  if (max_msgs_ == 0) {
    osw_error(OSW_EXCEED_MAX_SIZE);
    return OSW_EXCEED_MAX_SIZE; // should never happen.
  }
  // are there any messages?
  int retval = Qsem_.semTake(_to_wait_ms);
  if (retval == OSW_SINGLE_THREAD) return OSW_SINGLE_THREAD;
  if (retval == OSW_TIMEOUT) {
    return OSW_TIMEOUT;
  }
  if (retval < 0) {
    // post error
    osw_error(OSW_GENERAL_ERROR);
    return retval;
  }
  
  // sanity check
  if (msg_array_ == OSW_NULL) {
    osw_error(OSW_UNALLOCATED_MEM);
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
  return retsize;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  msgQsend
//  Description: puts a message on the Q
//  Parameters: the message, message size, and control.
//    Control is either OSW_REJECT_ON_FULL (default) or  OSW_BUMP_ON_FULL.
//    With OSW_REJECT_ON_FULL, when the Q is full the new message
//    will be thrown away.  With OSW_BUMP_ON_FULL, when the Q is
//    full the oldest message is thrown away, and the new message
//    is added.
//  Return value:
//    Returns the status the this Q.
//    OSW_OK: on success.
//    OSW_MSG_Q_FULL_BUMP: if Q is full and the oldest message was bumped.
//    OSW_MSG_Q_FULL_REJECT: if Q is full and message was rejected.
//    OSW_UNALLOCATED_MEM: if msgQsend was called before msgQcreate.
//    OSW_EXCEED_MAX_SIZE: if the message exceeds Q allocation for it.
//////////////////////////////////////////////////////////////////////////////
int osw_message_q::msgQsend(char *_in_msg, int _size, int _control)
{
  if (max_msgs_ == 0) return OSW_OK; // don't send to this queue.
  if (msg_array_ == OSW_NULL) {
    osw_error(OSW_UNALLOCATED_MEM);
    return OSW_UNALLOCATED_MEM;
  }
  // sanity check.
  if (_size > max_msg_size_-(int)sizeof(Qheader)) {
    //  POST ERROR
    osw_error(OSW_EXCEED_MAX_SIZE);
    return OSW_EXCEED_MAX_SIZE;
  }

  if (max_msgs_ > 1) {
  // check for a full Q:
  //  head_ equals tail_ when Q is empty, or when Q is full.
  if ((tail_ == head_) && Qsem_.getCount()) {
    if (_control == OSW_REJECT_ON_FULL) {
      osw_error(OSW_MSG_Q_FULL_REJECT);
      return OSW_MSG_Q_FULL_REJECT;
    }
    if (_control ==  OSW_BUMP_ON_FULL) {
      // put the message.
      Qheader *tmp = (Qheader*)&msg_array_[tail_ * max_msg_size_];
      tmp->size = _size;
      tmp->tick = osw_getTick();
      memcpy(&msg_array_[(tail_ * max_msg_size_)+sizeof(Qheader)], _in_msg, _size);
      ++tail_;
      tail_ %= max_msgs_;
      ++head_;
      head_ %= max_msgs_;
      osw_error(OSW_MSG_Q_FULL_BUMP);
      return OSW_MSG_Q_FULL_BUMP;
    }
  }
  }
  // put the message.
  Qheader *tmp = (Qheader*)&msg_array_[tail_ * max_msg_size_];
  tmp->size = _size;
  tmp->tick = osw_getTick();
  memcpy(&msg_array_[(tail_ * max_msg_size_)+sizeof(Qheader)], _in_msg, _size);
  ++tail_;
  tail_ %= max_msgs_;
  // everything's OK.
  Qsem_.semGive();
  return OSW_OK;
} /**/

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
  Qsem_.semFlush();
}

/////////////////////////////////////////////////
//  Packed Message Queue
/////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////////////
//  function:  osw_packed_q
//  Description: Constructor.
//  Inputs: none
//  Outputs: none
//////////////////////////////////////////////////////////////////////////////
osw_packed_q::osw_packed_q():ROLLOVER_VALUE(0xffffffffL)
{
  msg_array_ = OSW_NULL;
}

osw_packed_q::~osw_packed_q()
{
  if (msg_array_ != OSW_NULL) {
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
    return OSW_ALREADY_INITIALIZED;
  }
  if (_size_bytes < sizeof(Qheader) + 1) {
    osw_error(OSW_UNDER_MIN_SIZE);
    return OSW_UNDER_MIN_SIZE;
  }
  if (_name == OSW_NULL) {
    osw_error(OSW_INVALID_PARAMETER);
    return OSW_INVALID_PARAMETER;
  }
  
  // initialize.
  buf_size_ =  _size_bytes;
  name_ = _name;

  Qsem_.semCreate(_name);
  // allocate the message queue.
  msg_array_ = (char*)osw_malloc(buf_size_);
  if (msg_array_ == OSW_NULL) {
    // POST ERROR
    osw_error(OSW_MEM_ALLOC_FAILED);
    return OSW_MEM_ALLOC_FAILED;
  }
  buf_end_ = msg_array_ + _size_bytes;
  tail_ = msg_array_;
  head_ = msg_array_;
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
                              osw_tick_t* _tick)
{
  // sanity check
  if (msg_array_ == OSW_NULL) {
    osw_error(OSW_UNALLOCATED_MEM);
    return OSW_UNALLOCATED_MEM;
  }

  // are there any messages?
  int retval = Qsem_.semTake(_to_wait_ms);
  if (retval == OSW_SINGLE_THREAD) return OSW_SINGLE_THREAD;
  if (retval == OSW_TIMEOUT) {
    return OSW_TIMEOUT;
  }
  if (retval < 0) {
    // post error
    osw_error(OSW_GENERAL_ERROR);
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
    return OSW_EXCEED_MAX_SIZE;  // sanity check.
  }
  if (_tick != OSW_NULL) *_tick = tmp->tick;
  memcpy(_buf, head_ + sizeof(Qheader), retsize);
  head_ += (tmp->size + sizeof(Qheader));
  return retsize;
}

//////////////////////////////////////////////////////////////////////////////
//  function:  pkdQsend
//  Description: puts a message on the Q
//  Parameters: the message, message size.
//  Return value:
//    Returns the status this Q.
//    OSW_OK: on success.
//    OSW_MSG_Q_FULL_PACK: not enought space for this message.
//    OSW_UNALLOCATED_MEM: if pkdQsend was called before pkdQcreate.
//////////////////////////////////////////////////////////////////////////////
int osw_packed_q::pkdQsend(char *_in_msg, int _size)
{
  if (buf_size_ == 0) return 0; // don't send to this queue.
  if (msg_array_ == OSW_NULL) {
    osw_error(OSW_UNALLOCATED_MEM);
    return OSW_UNALLOCATED_MEM;
  }

  // put the message.
  if (head_ > tail_) {
    if (_size + (int)sizeof(Qheader) <= (int)(head_ - tail_)) {
      Qheader *tmp = (Qheader*)tail_;
      tmp->size = _size;
      tmp->tick = osw_getTick();
      memcpy((tail_+sizeof(Qheader)), _in_msg, _size);
      tail_ += (_size + sizeof(Qheader));
    } else {
      osw_error(OSW_PKD_Q_FULL);
      return OSW_PKD_Q_FULL;
    }
  } else {
    if (_size + (int)sizeof(Qheader) <= ((int)(buf_end_ - tail_))) {
      Qheader *tmp = (Qheader*)tail_;
      tmp->size = _size;
      tmp->tick = osw_getTick();
      memcpy((tail_+sizeof(Qheader)), _in_msg, _size);
      tail_ += (_size + sizeof(Qheader));
    } else if (_size + (int)sizeof(Qheader) <= (int)(head_ - msg_array_)) {
      // rollover.
      Qheader *tmp = (Qheader*)tail_;
      tmp->size = ROLLOVER_VALUE;
      tmp->tick = osw_getTick();
      //Serial.print("pkdQRollover");
      tmp = (Qheader*)msg_array_;
      tmp->size = _size;
      tmp->tick = osw_getTick();
      memcpy((msg_array_+sizeof(Qheader)), _in_msg, _size);
      tail_ = msg_array_ + (_size + sizeof(Qheader));
    } else {
      osw_error(OSW_PKD_Q_FULL);
      return OSW_PKD_Q_FULL;
    }
  }
  // everything's OK.
  Qsem_.semGive();
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
  Qsem_.semFlush();
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
    }
    osw_event_q_inited = true;
  }
  while (1) {
    int event;
    int result = osw_event_q.msgQreceive((char*)&event, sizeof(event));
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
    return OSW_TOO_MANY_EVENT_PAIRS;
  }
  
  osw_evt_event[osw_evt_pairCount].event = _event;
  osw_evt_event[osw_evt_pairCount].eventHandler = _eventHandler;
  ++osw_evt_pairCount;
  
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
  if (osw_event_q.msgQsend((char*)&_event, sizeof(_event)) != OSW_OK) {
    osw_error(OSW_EVENT_SEND_FAIL);
    return OSW_EVENT_SEND_FAIL;
  }
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
int osw_shared_mem::init_mem(unsigned int _max_size) {
  if ((data_ != OSW_NULL) && (flag_ != OSW_NULL)) {
    osw_error(OSW_ALREADY_INITIALIZED);
    return OSW_ALREADY_INITIALIZED;
  }
  data_ = (unsigned char*)osw_malloc(_max_size + sizeof(unsigned int));
  if (data_ == OSW_NULL) {
    osw_error(OSW_SHARED_MEM_NULL);
    return OSW_SHARED_MEM_NULL;
  }
  flag_ = (unsigned int*)data_;
  *flag_ = 0;
  data_ += sizeof(unsigned int);
  return OSW_OK;
}

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
//      OSW_SHARED_MEM_NULL if pointers have not be set up with a
//                          call to init_mem() first.
//      OSW_SHARED_MEM_BUSY if another thread is in the process of
//                          reading or writing to the shared memory.
//////////////////////////////////////////////////////////////////////////////
int osw_shared_mem::write(void* _data, int _size) {
  if ((data_ == OSW_NULL) || (flag_ == OSW_NULL)) {
    osw_error(OSW_SHARED_MEM_NULL);
    return OSW_SHARED_MEM_NULL;
  }
  do {
    *flag_ &= 0x3fff; // clear the interrupt flag, atomic hopefully
    ++*flag_;  //  atomic, hopefully
    if ((*flag_ & 0x3fff) != 1) {
      --*flag_;   //  atomic, hopefully
      if ((*flag_ & 0x3fff) == 0x3fff) // something went wrong
        *flag_ = 0x4000; // should never happen
      osw_error(OSW_SHARED_MEM_BUSY);
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
//      OSW_SHARED_MEM_NULL if pointers have not be set up with a
//                          call to init_mem() first.
//      OSW_SHARED_MEM_BUSY if another thread is in the process of
//                          reading or writing to the shared memory.
//////////////////////////////////////////////////////////////////////////////
int osw_shared_mem::read(void* _data, int _size) {
  if ((data_ == OSW_NULL) || (flag_ == OSW_NULL)) {
    osw_error(OSW_SHARED_MEM_NULL);
    return OSW_SHARED_MEM_NULL;
  }
  do {
    *flag_ &= 0x3fff; // clear the interrupt flag, atomic hopefully
    ++*flag_;   //  atomic, hopefully
    if ((*flag_ & 0x3fff) != 1) {
      --*flag_;   //  atomic, hopefully
      if ((*flag_ & 0x3fff) == 0x3fff) // something went wrong
        *flag_ = 0x4000; // should never happen
      osw_error(OSW_SHARED_MEM_BUSY);
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

#ifdef OSW_USE_TASKS

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
//     _interval_ms is how often this task is run.  If interval is 0 then it
//         is exectuted as often as possible.
//     _evt_trace (not used in osw_min), traces the task in the trace log.
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
                         bool _evt_trace,
                         bool _active)
{
  // sanity checks
  if ((_name == OSW_NULL) ||
      (_the_func == OSW_NULL)) {
    osw_error(OSW_INVALID_PARAMETER);
    return OSW_INVALID_PARAMETER;
  }
  name_ = _name;
  the_func_ = _the_func;
  data_ = _data;
  active_ = _active;
  mod_ = _interval_ms / OSW_MS_PER_TIC;
  tasklist[numTasks] = this;
  ++numTasks;
  if (numTasks >= OSW_MAX_TASKS) {
    //  post error
    numTasks = OSW_MAX_TASKS-1;
    osw_error(OSW_TOO_MANY_TASKS);
    return OSW_TOO_MANY_TASKS;
  }
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
  for (int i=0; i < numTasks; i++) {
    if (tasklist[i] == this) {
      --numTasks;
      tasklist[i] = tasklist[numTasks];
      return OSW_OK;
    }
  }
  osw_error(OSW_TASK_NOT_FOUND);
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
  Serial.println("\nName       FuncPtr      Mod Active");
  for (int i=0; i < numTasks; i++) {
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
    int tmpi = (int)(tasklist[i]->the_func_);
    for (int i=0; i<8; i++) {
      tmps[i] = (tmpi % 10) + '0';
      tmpi /= 10;
    }
    tmps[8] = 'x';
    tmps[9] = '0';
    tmps[10] = '\0';
    reverse(tmps);
    strcat(retstr, tmps);
    strcat(retstr, " ");
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

#ifdef OSW_USE_HW_WATCHDOG_ARDUNO
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
}

int osw_tasks_go(void)
{
  static long task_tic_count = 5;  // may want zero to mean something else.
  static osw_tick_t old_tic = 0;
  osw_tick_t tmp_tic = 0;

  static bool osw_first_time_thru_flag = true;
  if (osw_first_time_thru_flag) {
    osw_first_time_thru();
    osw_first_time_thru_flag = false;
  }

  if (osw_done_val) return osw_done_val;
  //  executive loop
  // execute the tasks that need to run as fast as possible (mod_ == 0)
  osw_interrupt_disable();

  //  execute the tasks that need to be run as fast as possible.
  //  even faster than a system tick.
  osw_task* cur_task;
  for (task_idx = 0; task_idx < numTasks; task_idx++) {
    cur_task = tasklist[task_idx];
    if (cur_task && cur_task->active_) {
      if (!cur_task->mod_) {
        cur_task->the_func_(cur_task->data_);
      }
    }
  } // end for

  osw_interrupt_enable();

  //  check for a system tick:
  tmp_tic = osw_getTick();
  if (tmp_tic == old_tic) {
#ifdef OSW_USE_IDLE_TASK
    idle_task();
#endif
    return 0;
  }
  old_tic = tmp_tic;
  ++task_tic_count;
  osw_watchdog_reset();

  // execute the tasks that run at intervals at a Hz rate (mod_ != 0)
  osw_interrupt_disable();
  for (task_idx = 0; task_idx < numTasks; task_idx++) {
    cur_task = tasklist[task_idx];
    if (cur_task && cur_task->active_) {
      if (cur_task->mod_ && !(task_tic_count % cur_task->mod_)) {
        cur_task->the_func_(cur_task->data_);
      }
    }
  } // end for

  osw_interrupt_enable();
  
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
void idle_task(void)
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
  osw_done_val = _code;
  // make sure osw_done_val is non-zero.
  if (osw_done_val == 0) osw_done_val = OSW_SINGLE_THREAD;
}


#endif  // OSW_USE_TASKS

/////////////////////////////////////////////////
//  Utility library functions needed by others.
/////////////////////////////////////////////////


//////////////////////////////////////////////////////////////////////////////
//  function:  align4
//  Description: Pushes the value up to the next multiple of 4.
//      Not needed for Arduino.  But it's a simple, spiffy function.
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
const prog_uchar copywriteP[] PROGMEM =
    "OS Wrap, multitaking wrapper\n"
    "MindSpace Research (c) 1999-2011\n";

const prog_uchar versionP[] PROGMEM = "Version: " OS_WRAP_VERSION;
const prog_uchar compiledP[] PROGMEM = "Compiled: " __DATE__ "  " __TIME__;


#ifdef OSW_STARTUP_BANNER
const prog_uchar bannerP[] PROGMEM =
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
//  End of osw_min
/////////////////////////////////////////////////


