////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#include "DS18S20Test.h"


//---//
/*
static UINT8 LastDiscrepancy[8];
static UINT8 LastFamilyDiscrepancy[8];
static UINT8 LastDevice[8];
UINT8 SerialNum[MAX_PORTNUM][8];
*/

extern DS18S20 gDS18S20_Driver;

DS18S20Test::DS18S20Test( int seedValue, int numberOfEvents )
{
	this->numberOfEvents = numberOfEvents;

	CPU_GPIO_Initialize();

	CPU_GPIO_EnableOutputPin((GPIO_PIN) GPIO_J12_PIN1 , FALSE);
	CPU_GPIO_EnableOutputPin((GPIO_PIN) GPIO_J12_PIN2, FALSE);
	CPU_GPIO_EnableOutputPin((GPIO_PIN) GPIO_J12_PIN3, FALSE);

};

BOOL DS18S20Test::Level_0A()
{

	gDS18S20_Driver.Initialize(30);

	return TRUE;

}

BOOL DS18S20Test::Level_0B()
{
}

BOOL DS18S20Test::Level_0C()
{

}

#if 0
UINT8 owNext(int portnum, UINT8 do_reset, UINT8 alarm_only)
{
  UINT8 bit_test, search_direction, bit_number;
  UINT8 last_zero, serial_byte_number, next_result;
  UINT8 serial_byte_mask;
  UINT8 lastcrc8;

  // initialize for search
  lastcrc8=0;
  bit_number = 1;
  last_zero = 0;
  serial_byte_number = 0;
  serial_byte_mask = 1;
  next_result = 0;
  //setcrc8(portnum,0);

  // if the last call was not the last one
  if (!LastDevice[portnum])
  {
    // check if reset first is requested
    if (do_reset)
    {
      // reset the 1-wire
      // if there are no parts on 1-wire, return FALSE
      if (!Reset(portnum))
      {
        // reset the search
        LastDiscrepancy[portnum] = 0;
        LastFamilyDiscrepancy[portnum] = 0;
        //OWERROR(OWERROR_NO_DEVICES_ON_NET);
        return FALSE;
      }
    }

    // If finding alarming devices issue a different command
    if (alarm_only)
      WriteByte(portnum,0xEC);  // issue the alarming search command
    else
      WriteByte(portnum,0xF0);  // issue the search command

    //pause before beginning the search
    usDelay(10);

    // loop to do the search
    do
    {
      // read a bit and its compliment
      bit_test = WriteBit(portnum,1) << 1;
      bit_test |= WriteBit(portnum,1);

      // check for no devices on 1-wire
      if (bit_test == 3)
      {
        break;
      }
      else
      {
        // all devices coupled have 0 or 1
        if (bit_test > 0)
        {
          search_direction = !(bit_test & 0x01);  // bit write value for search
        }
        else
        {
          // if this discrepancy if before the Last Discrepancy
          // on a previous next then pick the same as last time
          if (bit_number < LastDiscrepancy[portnum])
            search_direction = ((SerialNum[portnum][serial_byte_number] & serial_byte_mask) > 0);
          else
            // if equal to last pick 1, if not then pick 0
            search_direction = (bit_number == LastDiscrepancy[portnum]);

          // if 0 was picked then record its position in LastZero
          if (search_direction == 0)
          {
            last_zero = bit_number;

            // check for Last discrepancy in family
            if (last_zero < 9)
              LastFamilyDiscrepancy[portnum] = last_zero;
          }
        }

        // set or clear the bit in the SerialNum[portnum] byte serial_byte_number
        // with mask serial_byte_mask
        if (search_direction == 1)
          SerialNum[portnum][serial_byte_number] |= serial_byte_mask;
        else
          SerialNum[portnum][serial_byte_number] &= ~serial_byte_mask;

        // serial number search direction write bit
        WriteBit(portnum,search_direction);

        // increment the byte counter bit_number
        // and shift the mask serial_byte_mask
        bit_number++;
        serial_byte_mask <<= 1;

        // if the mask is 0 then go to new SerialNum[portnum] byte serial_byte_number
        // and reset mask
        if (serial_byte_mask == 0)
        {
          // The below has been added to accomidate the valid CRC with the
          // possible changing serial number values of the DS28E04.
          if (((SerialNum[portnum][0] & 0x7F) == 0x1C) && (serial_byte_number == 1))
            lastcrc8 = docrc8(portnum,0x7F);
          else
            lastcrc8 = docrc8(portnum,SerialNum[portnum][serial_byte_number]);  // accumulate the CRC

          serial_byte_number++;
          serial_byte_mask = 1;
        }
      }
    }
    while(serial_byte_number < 8);  // loop until through all SerialNum[portnum] bytes 0-7

    // if the search was successful then
    if (!((bit_number < 65) || lastcrc8))
    {
      // search successful so set LastDiscrepancy[portnum],LastDevice[portnum],next_result
      LastDiscrepancy[portnum] = last_zero;
      LastDevice[portnum] = (LastDiscrepancy[portnum] == 0);
      next_result = TRUE;
    }
  }

  // if no device found then reset counters so next 'next' will be
  // like a first
  if (!next_result || !SerialNum[portnum][0])
  {
    LastDiscrepancy[portnum] = 0;
    LastDevice[portnum] = FALSE;
    LastFamilyDiscrepancy[portnum] = 0;
    next_result = FALSE;
  }

  return next_result;
}
#endif


BOOL WriteBit(int portnum, UINT8 sendbit)
{
	   unsigned char result=0;
	   UINT32 pin = (UINT32)portnum;

	   //timing critical, so I'll disable interrupts here
	   GLOBAL_LOCK(irq); //EA = 0;

	   // start timeslot.
	   CPU_GPIO_EnableOutputPin( pin, false );

	   HAL_Time_Sleep_MicroSeconds(5);

	   if (sendbit == 1)
	   {
		   // send 1 bit out.
		   // sample result @ 15 us.
		   CPU_GPIO_EnableInputPin( pin, false, NULL, GPIO_INT_EDGE_HIGH, RESISTOR_PULLUP );
		   HAL_Time_Sleep_MicroSeconds(5);
		   result = CPU_GPIO_GetPinState(pin);
		   HAL_Time_Sleep_MicroSeconds(35);
	   }
	   else
	   {
	      // send 0 bit out.
	     ::CPU_GPIO_SetPinState(pin, 0);
	     HAL_Time_Sleep_MicroSeconds(50);
	   }
	   // timeslot done. Set output high.
	   CPU_GPIO_EnableOutputPin( pin, true );

	   //HAL_Time_Sleep_MicroSeconds(5);

	   //restore interrupts
	   irq.Release();

	   if (result != 0)
	   {
	     result = 1;
	   }
	   else
	   {
	     result = 0;
	   }

	   return result;

}

UINT8 Reset(int portnum)
{
   UINT8 result;
   UINT32 pin = (UINT32)portnum;

   // Code from appnote 126.
   CPU_GPIO_EnableOutputPin( pin, false );  // impulse start OW_PORT = 0; // drive bus low.

   HAL_Time_Sleep_MicroSeconds(600);

   // 500-(3% error) ~= 480 us

   // OW_PORT = 1; // bus high.
   // Note that the 1Wire bus will need external pullup to supply the required current
   CPU_GPIO_EnableInputPin( pin, false, NULL, GPIO_INT_EDGE_HIGH, RESISTOR_PULLUP );

   HAL_Time_Sleep_MicroSeconds(65);

   result = CPU_GPIO_GetPinState(pin); 	//!OW_PORT; // get presence detect pulse.

   HAL_Time_Sleep_MicroSeconds(372); 							// 372-(3% error) ~= 360 us

   return result == 0;
}

UINT8 WriteByte(int portnum, UINT8 sendbyte)
{
   UINT8 i;
   UINT8 result = 0;

   for (i = 0; i < 8; i++)
   {
       result |= (WriteBit(portnum,sendbyte & 1) << i);
       sendbyte >>= 1;
   }

   return result;
}


// This test is a one wire simulation
BOOL DS18S20Test::Level_1()
{
	UINT8 bit_test = 0;

	UINT8 i = 0;

	UINT64 RomContents = 0;

	UINT16 portnum = 30;

	Reset(portnum);

	HAL_Time_Sleep_MicroSeconds(600);

	Reset(portnum);

	HAL_Time_Sleep_MicroSeconds(600);

	WriteByte(portnum, 0xF0);

	HAL_Time_Sleep_MicroSeconds(5);
	//HAL_Time_Sleep_MicroSeconds(100);

	 // read a bit and its compliment
	 bit_test = WriteBit(portnum,1) << 1;
	 bit_test |= WriteBit(portnum,1);

	/*
	do
	{
		CPU_GPIO_EnableOutputPin(portnum, false);
		CPU_GPIO_EnableInputPin( portnum, false, NULL, GPIO_INT_EDGE_HIGH, RESISTOR_PULLUP );
		bit_test = CPU_GPIO_GetPinState(portnum);
		HAL_Time_Sleep_MicroSeconds(55);
		CPU_GPIO_EnableOutputPin(portnum, true);

		RomContents |= bit_test << i;

		i++;

	}while(i < 2);
	*/



	if(bit_test == 3)
	{
		hal_printf("No participating devices \n");
	}
	else
	{
		hal_printf("Response recieved from device \n");
	}

	/*
	{
		GLOBAL_LOCK(irq);

		while(i++ < 64)
		{
			// read a bit and its compliment
			//bit_test = WriteBit(portnum,1) << 1;
			//bit_test |= WriteBit(portnum,1);
			CPU_GPIO_EnableOutputPin(portnum, false);
			//HAL_Time_Sleep_MicroSeconds(5);

			CPU_GPIO_EnableInputPin( portnum, false, NULL, GPIO_INT_EDGE_HIGH, RESISTOR_PULLUP );
			//HAL_Time_Sleep_MicroSeconds(5);
			bit_test = CPU_GPIO_GetPinState(portnum);
			HAL_Time_Sleep_MicroSeconds(55);

			CPU_GPIO_EnableOutputPin(portnum, true);

			RomContents |= bit_test << i;

		}
	}
	*/

	//hal_printf("The family is %d", (RomContents & 0xff));

	return TRUE;

}




BOOL DS18S20Test::Execute( int testLevel )
{
	if(testLevel == LEVEL_0A_TEST)
		Level_0A();

} //Execute

