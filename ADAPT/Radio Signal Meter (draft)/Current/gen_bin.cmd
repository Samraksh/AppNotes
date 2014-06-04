@echo off

if exist _Build.txt (del /s _Build.txt)
if exist _Build.bin (del /s _Build.bin)

MetaDataProcessor -create_database _BOM.txt _Build.dat

if errorlevel 1 (
	echo Creation of .dat failed
	del /s _Build.dat
	exit /b
)

copy .\eMote\CLR\MFout_padded.bin /b + _Build.dat /b _Build.bin

if errorlevel 1 (
	echo Copy to .bin failed
	exit /b
)


echo Done