//
// The Samrkash Company
//
// Author : Nived.Sivadas@samraksh.com
//
//
#include <stm32f10x.h>
#define VectorTableOffsetRegister 0xE000ED08

#define OFFSET 0x20000

extern "C"
{

void VectorRelocate()
{
	*(__IO uint32_t *) VectorTableOffsetRegister |= (uint32_t) 0;

}
}
