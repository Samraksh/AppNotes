@echo off

for /f "tokens=1,* delims=]" %%A in ('"type %1 | find /n /v """') do (
    set "line=%%B"
    if defined line (
        call set "line=echo.%%line:\=\\%%"
        for /f "delims=" %%X in ('"echo."%%line%%""') do %%~X
    ) ELSE echo.
)