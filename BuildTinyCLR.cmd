set /p Input=Press Enter ...

call c:\SamrakshGit\MF\MicroFrameworkPK_v4_3\setenv_gcc.cmd 4.7.3 C:\SamrakshGit\TestSystem\TestSystem\codesourcery

cd \SamrakshGit\MF\MicroFrameworkPK_v4_3\Solutions\EmoteDotNow\TinyCLR
msbuild /t:build TinyCLR.proj

set /p Input=Press Enter when done

explorer C:\SamrakshGit\MF\MicroFrameworkPK_v4_3\BuildOutput\THUMB2\GCC4.7\le\FLASH\debug\EmoteDotNow\bin