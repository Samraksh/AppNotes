@echo off

dir /b /s %1\bin\Debug\le\*.pe > tempPE.tmp

MetaDataProcessor -create_database tempPE.tmp output.dat
del tempPE.txt

echo Done