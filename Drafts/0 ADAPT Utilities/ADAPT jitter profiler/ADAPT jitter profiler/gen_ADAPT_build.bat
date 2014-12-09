@echo off
REM -- Prepare the Command Processor --
SETLOCAL ENABLEEXTENSIONS
SETLOCAL DISABLEDELAYEDEXPANSION

REM Cleanup if needed
if exist _BOM.txt (del /s _BOM.txt > nul)
if exist _BOM_out (del /s _BOM_out > nul)
if exist _BOM2.txt (del /s _BOM2.txt > nul)
if exist _Build.dat (del /s _Build.dat > nul)
REM dir Build.bin | find "Build.bin"
REM if exist Build.bin (del /s Build.bin > nul)
REM dir Build.bin | find "Build.bin"
del Build.bin
dir Build.bin | find "Build.bin"

if [%1]==[] (
	echo *** Missing Directory
	echo *** usage %0 " [project directory containing .sln file]"
	exit /b
)

dir /b /s %1\bin\Debug\le\*.pe > _BOM.txt

call subst.bat _BOM.txt > _bom_out
call quote.bat _bom_out > _bom2.txt

MetaDataProcessor -create_database _bom2.txt _Build.dat

if errorlevel 1 (
	echo *** Creation of _Build.dat failed
	exit /b
)

copy %1\eMote\CLR\MFout_padded.bin /b + _Build.dat /b Build.bin > nul

if errorlevel 1 (
	echo *** Copy to Build.bin failed
	exit /b
)

rem if exist _BOM.txt (del /s _BOM.txt > nul)
rem if exist _BOM_out (del /s _BOM_out > nul)
rem if exist _BOM2.txt (del /s _BOM2.txt > nul) 
rem if exist _Build.dat (del /s _Build.dat > nul) 

echo.
echo ## Done. Executable is in Build.bin ##
dir Build.bin | find "Build.bin"