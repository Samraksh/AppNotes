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

//  This uses the os_wrap memory manager: comment out OSW_USE_STDMEM
//  with the OSW_HEAP_SIZE set to 550

void setup() {         
  int* iptrs[10] = {OSW_NULL};
  int idx;  
  Serial.begin(9600); 
  //Serial.println("EEPROM:");
  //xdumpEEPROM();
  
  //  Print the free memory of the Arduino run-time environment.
  Serial.print("memFree: ");
  Serial.println(memoryFree());
  
  //  Print the free memory of the memory manager.
  osw_print_mem_free(); Serial.println();
  
  //  Start allocating memory until it runs out.
  iptrs[0] = (int*)osw_malloc(2);
  Serial.print("0:malloc-size:2 at:0x");
  Serial.println((int)iptrs[0], HEX);
  osw_print_mem_free(); Serial.println();

  iptrs[1] = (int*)osw_malloc(4);
  Serial.print("1:malloc-size:4 at:0x");
  Serial.println((int)iptrs[1], HEX);
  osw_print_mem_free(); Serial.println();

  iptrs[2] = (int*)osw_malloc(8);
  Serial.print("2:malloc-size:8 at:0x");
  Serial.println((int)iptrs[2], HEX);
  osw_print_mem_free(); Serial.println();

  iptrs[3] = (int*)osw_malloc(16);
  Serial.print("3:malloc-size:16 at:0x");
  Serial.println((int)iptrs[3], HEX);
  osw_print_mem_free(); Serial.println();

  iptrs[4] = (int*)osw_malloc(32);
  Serial.print("4:malloc-size:32 at:0x");
  Serial.println((int)iptrs[4], HEX);
  osw_print_mem_free(); Serial.println();

  iptrs[5] = (int*)osw_malloc(64);
  Serial.print("5:malloc-size:64 at:0x");
  Serial.println((int)iptrs[5], HEX);
  osw_print_mem_free(); Serial.println();

  iptrs[6] = (int*)osw_malloc(128);
  Serial.print("6:malloc-size:128 at:0x");
  Serial.println((int)iptrs[6], HEX);
  osw_print_mem_free(); Serial.println();

  iptrs[7] = (int*)osw_malloc(50);
  Serial.print("7:malloc-size:50 at:0x");
  Serial.println((int)iptrs[7], HEX);
  osw_print_mem_free(); Serial.println();

  // this one fails.
  iptrs[8] = (int*)osw_malloc(512);
  Serial.print("8:malloc-size:512 at:0x");
  Serial.println((int)iptrs[8], HEX);
  osw_print_mem_free(); Serial.println();

  // Now free up memory and check the free list.

  int retval;
  
  retval = osw_free(iptrs[1]);
  Serial.print("1:free:");
  Serial.println(retval);
  osw_print_mem_free(); Serial.println();
  
  retval = osw_free(iptrs[3]);
  Serial.print("3:free:");
  Serial.println(retval);
  osw_print_mem_free(); Serial.println();
  
  retval = osw_free(iptrs[5]);
  Serial.print("5:free:");
  Serial.println(retval);
  osw_print_mem_free(); Serial.println();
  
  //  This is now maximum fragmentation.
  //  As more memory is free-ed, the pieces should merge.

  retval = osw_free(iptrs[6]);
  Serial.print("6:free:");
  Serial.println(retval);
  osw_print_mem_free(); Serial.println();
  
  retval = osw_free(iptrs[0]);
  Serial.print("0:free:");
  Serial.println(retval);
  osw_print_mem_free(); Serial.println();
  
  retval = osw_free(iptrs[7]);
  Serial.print("7:free:");
  Serial.println(retval);
  osw_print_mem_free(); Serial.println();
  
  retval = osw_free(iptrs[2]);
  Serial.print("2:free:");
  Serial.println(retval);
  osw_print_mem_free(); Serial.println();
  
  retval = osw_free(iptrs[4]);
  Serial.print("4:free:");
  Serial.println(retval);
  osw_print_mem_free(); Serial.println();
  

  osw_list_tasks();
}

void loop() {
  osw_tasks_go();
}
