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

#include <os_wrap.h>

osw_task Hz5, sec1, sec5, exec;
osw_message_q sec5mq;
osw_message_q Hz5mq, sec1mq; 
osw_dt_timer dt5Hz, dt1sec, dt5sec;

struct gomsg {
  int dummy;
};

void* go5Hz(void* _pData)
{
  gomsg test1;
  
  int result = Hz5mq.msgQreceive((char*)&test1, sizeof(test1));
  if (result == OSW_SINGLE_THREAD) return NULL;
  
  Serial.print('.');
  return OSW_NULL;
}

void* go1sec(void* _pData)
{
  gomsg test1;
  
  int result = sec1mq.msgQreceive((char*)&test1, sizeof(test1));
  if (result == OSW_SINGLE_THREAD) return NULL;
  
  Serial.print('s');
  return OSW_NULL;
}

void* go5sec(void* _pData)
{
  gomsg test1;
  
  int result = sec5mq.msgQreceive((char*)&test1, sizeof(test1));
  if (result == OSW_SINGLE_THREAD) return NULL;
  
  Serial.println(test1.dummy);
  return OSW_NULL;
}

void executive_init(void)
{
  if (Hz5mq.msgQcreate("Hz5mq", sizeof(gomsg), 3) != OSW_OK) {
    Serial.println("Hz5mq create failed"); }
  if (sec1mq.msgQcreate("sec1mq", sizeof(gomsg), 3) != OSW_OK) {
    Serial.println("sec1mq create failed"); }
  if (sec5mq.msgQcreate("sec5mq", sizeof(gomsg), 3) != OSW_OK) {
    Serial.println("sec5mq create failed"); }
  dt5sec.start(5000);
  dt1sec.start(1000);
  dt5Hz.start(200);
}

void* executive(void* _pData)
{
  gomsg test1;
  static int count = 0;
  test1.dummy = count;
  if (dt5Hz.timedOut()) {
    if (Hz5mq.msgQsend((char*)&test1, sizeof(test1)) != OSW_OK) {
      Serial.println("Hz5mq msgQsend failed"); }
    dt5Hz.start();
  }
  if (dt1sec.timedOut()) {
    if (sec1mq.msgQsend((char*)&test1, sizeof(test1)) != OSW_OK) {
      Serial.println("sec1mq msgQsend failed"); }
    dt1sec.start();
  }
  if (dt5sec.timedOut()) {
    ++count;
    if (sec5mq.msgQsend((char*)&test1, sizeof(test1)) != OSW_OK) {
      Serial.println("sec5mq msgQsend failed"); }
    dt5sec.start();
  }
}


void setup() {                
  Serial.begin(9600);
  executive_init();
  Hz5.taskCreate("5Hz", go5Hz);
  sec1.taskCreate("1sec", go1sec); 
  sec5.taskCreate("5sec", go5sec); 
  exec.taskCreate("exec", executive); 
  osw_list_tasks();
}

void loop() {
  osw_tasks_go();
}
