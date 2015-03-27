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

osw_task Hz5, sec1, OnSemTask;
osw_semaphore sem1;
osw_counting_sem semCnt;

void* go5Hz(void* _pData)
{
  semCnt.semGive();
  Serial.print('.');
  return OSW_NULL;
}

void* go1sec(void* _pData)
{
  while (semCnt.getCount()) {
    Serial.print(semCnt.getCount());
    semCnt.semTake();
  }
  sem1.semGive();
  
  return OSW_NULL;
}

void* OnSem(void* _pData)
{
  if (sem1.semTake() == OSW_SINGLE_THREAD) {
    //  Sem hasn't been given
    return OSW_NULL;
  }
  
  Serial.println("Sem");
  return OSW_NULL;
}

void setup() {                
  Serial.begin(9600); 
  Hz5.taskCreate("5Hz", go5Hz, OSW_NULL, 200); 
  sec1.taskCreate("1sec", go1sec, OSW_NULL, 1000); 
  OnSemTask.taskCreate("OnSem", OnSem); 
  sem1.semCreate("sem1");
  semCnt.semCreate("semCnt");
}

void loop() {
  osw_tasks_go();
}
