@echo off
call gen_bin.cmd

if errorlevel 1 (exit /b)
fastboot flash boot _Build.bin