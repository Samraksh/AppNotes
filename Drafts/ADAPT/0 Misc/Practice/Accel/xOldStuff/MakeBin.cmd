if "%1"=="" {
	echo Argument 1 is missing
	exit /b
}
MetaDataProcessor -create_database -BOM.txt -Build.dat
copy tinyclr.bin /b + -Build.dat /b -Build.bin