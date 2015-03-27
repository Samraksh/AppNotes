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
#include <osw_min.h>

osw_task exec;
osw_dt_timer dt1sec, dt5sec;

void evt1hdlr1(int _evt)
{
  Serial.print("A ");
}

void evt1hdlr2(int _evt)
{
  Serial.print("B ");
}

void evt2hdlr(int _evt)
{
  osw_evt_publish(1);
  Serial.println('2');
}

void executive_init(void)
{
  dt5sec.start(5000);
  dt1sec.start(1000);
  osw_evt_register(1, evt1hdlr1);
  osw_evt_register(1, evt1hdlr2);
  osw_evt_register(2, evt2hdlr);
}

void* executive(void* _pData)
{
  static int count = 0;
  if (dt1sec.timedOut()) {
    osw_evt_publish(1);
    dt1sec.start();
  }
  if (dt5sec.timedOut()) {
    osw_evt_publish(2);
    dt5sec.start();
  }
}


void setup() {                
  Serial.begin(9600); 
  executive_init();
  exec.taskCreate("exec", executive); 
}

void loop() {
  osw_tasks_go();
}
