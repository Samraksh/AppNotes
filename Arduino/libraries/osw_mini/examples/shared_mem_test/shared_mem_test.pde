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

osw_task Hz5, sec1, sec5;
osw_shared_mem<50> mem1;
char buffer[50];

void* go5Hz(void* _pData)
{
  Serial.print('.');
  int i;
  mem1.read(&i, sizeof(i));
  ++i;
  mem1.write(&i, sizeof(i));
  Serial.print(i);
  return OSW_NULL;
}

void* go1sec(void* _pData)
{
  Serial.print('s');
  int i;
  mem1.read(&i, sizeof(i));
  ++i;
  mem1.write(&i, sizeof(i));
  Serial.print(i);
  return OSW_NULL;
}

void* go5sec(void* _pData)
{
  Serial.println('S');
  int i;
  mem1.read(&i, sizeof(i));
  ++i;
  mem1.write(&i, sizeof(i));
  Serial.print(i);
  return OSW_NULL;
}


void setup() {                
  Serial.begin(9600); 
  int i = 7;
  mem1.write(&i, sizeof(i));
  Hz5.taskCreate("5Hz", go5Hz, OSW_NULL, 200); 
  sec1.taskCreate("1sec", go1sec, OSW_NULL, 1000); 
  sec5.taskCreate("5sec", go5sec, OSW_NULL, 5000); 
}

void loop() {
  osw_tasks_go();
}
