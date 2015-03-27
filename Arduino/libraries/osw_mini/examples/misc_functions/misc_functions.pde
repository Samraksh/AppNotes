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
#include <osw_mini.h>

osw_task Hz5, sec1, sec5, exec;
osw_packed_q<10> Hz5mq;
osw_packed_q<20> sec1mq;
osw_packed_q<6> sec5mq;
osw_dt_timer dt5Hz, dt1sec, dt5sec;


struct gomsg {
  int value;
};

void* go5Hz(void* _pData)
{
  gomsg test1;
  
  while (1) {
    
    int result = Hz5mq.pkdQreceive((char*)&test1, sizeof(test1));
    if (result == OSW_SINGLE_THREAD) return OSW_NULL;
    
    Serial.print('.');
  }
  return OSW_NULL;
}

void* go1sec(void* _pData)
{
  gomsg test1;
  
  while (1) {
    
    int result = sec1mq.pkdQreceive((char*)&test1, sizeof(test1));
    if (result == OSW_SINGLE_THREAD) return OSW_NULL;
    
    Serial.print('s');
  }
  return OSW_NULL;
}

void* go5sec(void* _pData)
{
  gomsg test1;
  
  while (1) {
    
    int result = sec5mq.pkdQreceive((char*)&test1, sizeof(test1));
    if (result == OSW_SINGLE_THREAD) return OSW_NULL;
    
    Serial.print(test1.value);
    Serial.print(" memFree: ");
    Serial.println(memoryFree());
    Serial.print(osw_ttoa(osw_getTick()));
  }
  return OSW_NULL;
}

void executive_init(void)
{
  if (Hz5mq.pkdQcreate("Hz5mq", sizeof(gomsg)) != OSW_OK) {
    Serial.println("Hz5mq create failed"); }
  if (sec1mq.pkdQcreate("sec1mq", sizeof(gomsg)) != OSW_OK) {
    Serial.println("sec1mq create failed"); }
  if (sec5mq.pkdQcreate("sec5mq", sizeof(gomsg)) != OSW_OK) {
    Serial.println("sec5mq create failed"); }
  dt5sec.start(5000);
  dt1sec.start(1311);
  dt5Hz.start(227);
}

void* executive(void* _pData)
{
  gomsg test1;
  static int count = 0;
  if (dt5Hz.timedOut()) {
    if (Hz5mq.pkdQsend((char*)&test1, sizeof(test1)) != OSW_OK) {
      Serial.println("Hz5mq msgQsend failed"); }
    dt5Hz.start();
  }
  if (dt1sec.timedOut()) {
    if (sec1mq.pkdQsend((char*)&test1, sizeof(test1)) != OSW_OK) {
      Serial.println("sec1mq msgQsend failed"); }
    dt1sec.start();
  }
  if (dt5sec.timedOut()) {
    test1.value = count;
    ++count;
    if (sec5mq.pkdQsend((char*)&test1, sizeof(test1)) != OSW_OK) {
      Serial.println("sec5mq msgQsend failed"); }
    dt5sec.start();
  }
}


void setup() {                
  Serial.begin(9600); 
  Serial.print("memFree: ");
  Serial.println(memoryFree());
  executive_init();
  Hz5.taskCreate("5Hz", go5Hz); 
  sec1.taskCreate("1sec", go1sec); 
  sec5.taskCreate("5sec", go5sec); 
  exec.taskCreate("exec", executive); 
  osw_list_tasks();

  Serial.println("EEPROM:");
  xdumpEEPROM();
}

void loop() {
  osw_tasks_go();
}
