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

osw_task tsrc, tdest;
osw_priority_q priQ;
#define MAX_NUM_PRI (4)

struct gomsg {
  int value;
};

void* src(void* _pData)
{
  static int val = 0;
  static int pri = 0;
  gomsg test1;
  
  test1.value = val;
  
  //int result = priQ.priQsend(pri, (char*)&test1, sizeof(test1), OSW_PRIQ_BUMP_LOW_HEAD_FULL);
  int result = priQ.priQsend(pri, (char*)&test1, sizeof(test1), OSW_PRIQ_BUMP_LOW_TAIL_FULL);
  //int result = priQ.priQsend(pri, (char*)&test1, sizeof(test1), OSW_PRIQ_BUMP_PRI_HEAD_FULL);
  //int result = priQ.priQsend(pri, (char*)&test1, sizeof(test1), OSW_PRIQ_REJECT_ON_FULL);
  
  Serial.print(val);
  Serial.print('.');
  Serial.print(pri);
  Serial.print(' ');
  
  ++val;
  ++pri;
  pri %= MAX_NUM_PRI;

  return OSW_NULL;
}

void* dest(void* _pData)
{
  gomsg test1;
  int val,pri;
  
  Serial.println('S');
  
  while (1) {
  int result = priQ.priQreceive(&pri, (char*)&test1, sizeof(test1));
  if (result == OSW_SINGLE_THREAD) break; //return OSW_NULL;
  val = test1.value;
  
  Serial.print(val);
  Serial.print('.');
  Serial.print(pri);
  Serial.print(' ');
  }
  
  Serial.println('R');
  
  return OSW_NULL;
}

void setup() {                
  Serial.begin(9600);
  if (priQ.priQcreate("priQ", 6, 10, MAX_NUM_PRI) != OSW_OK) {
    Serial.println("priQ create failed"); }
  tsrc.taskCreate("tsrc", src, OSW_OK, 142); // 7 Hz
  tdest.taskCreate("tdest", dest, OSW_OK, 1800); 
  osw_list_tasks();
}

void loop() {
  osw_tasks_go();
}
