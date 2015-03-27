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

#include "osw_mini.h"

osw_task Hz5, sec1, sec5, exec;
osw_packed_q<20> sec5mq;
osw_packed_q<10> Hz5mq, sec1mq; 
osw_dt_timer dt5Hz, dt1sec, dt5sec;

struct gomsg {
  int dummy;
};

void* go5Hz(void* _pData)
{
  gomsg test1;
  
  int result = Hz5mq.pkdQreceive((char*)&test1, sizeof(test1));
  if (result == OSW_SINGLE_THREAD) return NULL;
  
  Serial.print('.');
  return OSW_NULL;
}

void* go1sec(void* _pData)
{
  gomsg test1;
  
  int result = sec1mq.pkdQreceive((char*)&test1, sizeof(test1));
  if (result == OSW_SINGLE_THREAD) return NULL;
  
  Serial.print('s');
  return OSW_NULL;
}

void* go5sec(void* _pData)
{
  gomsg test1;
  
  int result = sec5mq.pkdQreceive((char*)&test1, sizeof(test1));
  if (result == OSW_SINGLE_THREAD) return NULL;
  
  Serial.println(test1.dummy);
  return OSW_NULL;
}

void executive_init(void)
{
  if (Hz5mq.pkdQcreate("Hz5mq", sizeof(gomsg)) != OSW_OK) {
    Serial.println("Hz5mq create failed"); }
  if (sec1mq.pkdQcreate("sec1mq", sizeof(gomsg)) != OSW_OK) {
    Serial.println("sec1mq create failed"); }
  if (sec5mq.pkdQcreate("sec5mq", 42) != OSW_OK) {
    Serial.println("sec5mq create failed"); }
  dt5sec.start(5000);
  dt1sec.start(1000);
  dt5Hz.start(200);
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
    test1.dummy = count;
    ++count;
    if (sec5mq.pkdQsend((char*)&test1, sizeof(test1)) != OSW_OK) {
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
