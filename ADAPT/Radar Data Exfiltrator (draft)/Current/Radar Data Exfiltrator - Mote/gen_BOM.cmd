@echo off

if [%1]==[] (
	echo Missing Argument 1
	exit /b
)

if exist _BOM.txt (del /s _BOM.txt)

dir /b /s %1\bin\Debug\le\*.pe > _BOM.txt

if errorlevel 1 (
	echo Creation of BOM failed
	exit /b
)


echo Done