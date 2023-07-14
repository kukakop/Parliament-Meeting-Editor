@echo off
echo wscript.Quit((msgbox("Do you want to kill PLM.exe process?",4+32+256, "title")-6) Mod 255) > %temp%\msgbox.vbs
start /min /wait %temp%\msgbox.vbs
rem echo wscript returned %errorlevel%
if errorlevel 1 goto error
taskkill /F /IM PLM.exe /T
goto end
:error
echo We have No
:end
del %temp%\msgbox.vbs /f /q
exit