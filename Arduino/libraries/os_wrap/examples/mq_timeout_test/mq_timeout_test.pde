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

osw_task readPkdQTask, readMsgQTask, sendMsgsTask;
osw_packed_q pkdQ;
osw_message_q msgQ;

struct gomsg {
  int the_int;
};

void* readPkdQ(void* _pData)
{
  gomsg test1;
  
  while (1) {
  int result = pkdQ.pkdQreceive((char*)&test1, sizeof(gomsg), 200);
  if (result == OSW_SINGLE_THREAD) return OSW_NULL;
  if (result == OSW_TIMEOUT) {
    Serial.print('.');
    return OSW_NULL;
  }
  // User code here:
  // We got a message from the queue.
  Serial.print("pkdQ:");
  Serial.print(test1.the_int);
  Serial.print(' ');
  }
    
  return OSW_NULL;
}

void* readMsgQ(void* _pData)
{
  gomsg test1;
  
  while (1) {
  int result = msgQ.msgQreceive((char*)&test1, sizeof(gomsg), 1000);
  if (result == OSW_SINGLE_THREAD) return OSW_NULL;
  if (result == OSW_TIMEOUT) {
    Serial.print('s');
    return OSW_NULL;
  }
  // User code here:
  // We got a message from the queue.
  Serial.print("msgQ:");
  Serial.print(test1.the_int);
  Serial.print(' ');
  }
    
  return OSW_NULL;
}

void* sendMsgs(void* _pData)
{
  static int count = 0;
  gomsg test1;
  
  ++count;  
  test1.the_int = count;  
  if (pkdQ.pkdQsend((char*)&test1, sizeof(gomsg)) != OSW_OK) {
    Serial.print("pkdQ.pkdQsend failed to send:");
    Serial.println(count);
  } 
  
  ++count;  
  test1.the_int = count;  
  if (msgQ.msgQsend((char*)&test1, sizeof(gomsg)) != OSW_OK) {
    Serial.print("msgQ.magQsend failed to send:");
    Serial.println(count);
  }
 
  Serial.print("memFree:");
  Serial.println(memoryFree());
  
  return OSW_NULL;
}


void setup() {                
  Serial.begin(9600);
  
  if (pkdQ.pkdQcreate("pkdQ", 10) != OSW_OK) {
    Serial.println("pkdQ create failed"); }
  if (msgQ.msgQcreate("msgQ", 10, 3) != OSW_OK) {
    Serial.println("msgQ create failed"); }
    
  if (readPkdQTask.taskCreate("tReadPkdQ", readPkdQ, OSW_NULL, 10) != OSW_OK) {
    Serial.println("tReadPkdQ create failed"); }
  if (readMsgQTask.taskCreate("tReadMsgQ", readMsgQ, OSW_NULL, 10) != OSW_OK) {
    Serial.println("tReadMsgQ create failed"); }
  if (sendMsgsTask.taskCreate("tSendMsgs", sendMsgs, OSW_NULL, 5000) != OSW_OK) {
    Serial.println("tSendMsgs create failed"); }
}

void loop() {
  osw_tasks_go();
}
