::Installationsfile Server
@echo off
echo "Starte Installation Server..."
MKDIR "%UserProfile%\Documents\ASAP\Server"
XCOPY "%~dp0\Files" "%UserProfile%\Documents\ASAP\Server"
echo "Files kopiert. Erzeuge Verknüpfung..."
XCOPY "%~dp0\Files\ASAP-Server.lnk" "%UserProfile%\Desktop"
echo "Installation beendet! Falls kein Desktop-Shortcut erzeugt wurde starten Sie den Installationsvorgang erneut und wenden sich gegebenen Falls an den Support"
pause 
