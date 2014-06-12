From:	Nathan Stohs
Sent:	Tuesday, June 10, 2014 4:46 PM
To:	William Leal
Cc:	Mukundan Sridharan
Subject:	ADAPT GC instrumented TinyCLR
Attachments:	MFpad_GC_instrumented.zip

Bill, CC: Mukundan,

Attached is the instrumented version of TinyCLR.

GPIO 55 is toggled inside of PerformGarbageCollection(). The GPIO is raised when the GC starts and 
lowered when it ends, and so should be pretty close to the length of the GC.
GPIO 53 is toggled in PerformHeapCompaction(), same semantics as above.
GPIO 52 is toggled in ScheduleThreads(). It is raised just before the scheduler executes any C# thread 
and lowered immediately on return back to ScheduleThreads().

GPIO 58 and 51 remain for general use, of which only 58 is connected to an LED but both are on the 
breakout.

Nathan
