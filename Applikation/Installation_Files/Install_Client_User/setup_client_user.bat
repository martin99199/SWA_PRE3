::Installationsfile Client User
@echo off
echo "Starte Installation Client User..."
MKDIR "%UserProfile%\Documents\ASAP\Client_User"
XCOPY "%~dp0\Files" "%UserProfile%\Documents\ASAP\Client_User" /q /s /e /h
echo "Files kopiert. Erzeuge Verkn�pfung..."
XCOPY "%~dp0\Files\ASAP-User.lnk" "%UserProfile%\Desktop" /q /s /e /h
echo "Installation beendet! Falls kein Desktop-Shortcut erzeugt wurde starten Sie den Installationsvorgang erneut oder wenden sich and den Support"
pause 
