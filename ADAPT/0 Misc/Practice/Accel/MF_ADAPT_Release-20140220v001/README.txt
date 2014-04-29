The Samraksh Company is pleased to announce the release of our port of the .NET Micro Framework to the ADAPT platform. The .NET Micro Framework is an open-source .NET platform that supports high-level application development in C# with Visual Studio but which has features more typical to a svelte close-to-the-metal OS.

Potential users would be anybody with low-latency needs, low duty-cycle applications, or traditional microcontroller applications for which Android is not necessarily the best match.

We are in the process of setting up a user account under the LSR SmartFile repository. This will act as our primary method of distribution and the following will be available there ASAP:

•	User Manual
•	OS Binary
•	Bootloader
•	Accelerometer demo (binaries and code) as shown at the recent QPR
•	Visual Studio libraries needed for custom extensions.

Note that this release is tested to work on V1.04 cores. For graphics functions a SIMcom debug board v1.01 or higher with LCD is required.

Please direct any feedback, comments, or questions to adapt@samraksh.info

--------------FILE LIST-------------------

Samraksh_SPOT_Hardware - DLLs describing interface extensions for ADAPT platform. Add these a reference to your Visual Studio project.

MFout_padded.bin - The TinyCLR binary pre-padded to 3MB for writing to the ADAPT core module with fastboot. Please see the manual for more info.

accel_demo.dat - binary for accelerometer and LCD demo application (to be used with SIMcom debug board).

full_demo.bin - A binary ready to be written with fastboot containing both the TinyCLR and C# demo.

aboot_bootloader.mbn - Bootloader to load MF instead of Android. Load with fastboot. Please see manual for more info.

User Manual v0.92.docx - User manual for ADAPT MF.

generate_mf_dat.cmd - Command to convert your C# application into proper binary formatting.

MetaDataProcessor.exe - Binary formatting application (part of MF4.3 SDK, included for convenience.)