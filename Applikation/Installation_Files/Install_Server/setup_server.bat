::Installationsfile Server
@echo off
echo "Starte Installation Server..."
MKDIR "%UserProfile%\Documents\ASAP\Server"
XCOPY "%~dp0\Files" "%UserProfile%\Documents\ASAP\Server" /q /s /e /h
echo "Files kopiert. Erzeuge Verknüpfung..."
XCOPY "%~dp0\Files\ASAP-Server.lnk" "%UserProfile%\Desktop" /q /s /e /h
echo "Installation beendet! Falls kein Desktop-Shortcut erzeugt wurde starten Sie den Installationsvorgang erneut und wenden sich gegebenen Falls an den Support"
pause 
