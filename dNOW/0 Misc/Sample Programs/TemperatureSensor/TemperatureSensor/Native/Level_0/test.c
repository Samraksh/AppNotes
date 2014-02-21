#include <stm32f10x.h>

void LED_ERROR1();
void LED_RED();
void LED_RED_OFF();


void LED_ERROR1() {
  uint32_t ik;
  while(1) {
	LED_RED();
	for(ik = 0; ik < 10000; ik++);
	LED_RED_OFF();
	for(ik = 0; ik < 10000; ik++);
  }
}

void LED_ERROR2(){
}


void LED_RED() {
  uint32_t tmp;
  RCC->APB2ENR |= 0x80;
  tmp = (GPIOF->CRH & 0xFFFFFFF0);
  GPIOF->CRH = (tmp | 0x00000003);
  GPIOF->BSRR = (0x1 << 8);
}


void LED_RED_OFF() {
  GPIOF->BRR = (0x1 << 8);
}

/*LED_ERROR();

void Default_Handler() {
	LED_ERROR();
}
*/
