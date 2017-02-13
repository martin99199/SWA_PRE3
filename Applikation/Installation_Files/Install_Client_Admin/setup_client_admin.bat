::Installationsfile
@echo off
echo "Starte Installation des Admin-Client..."
MKDIR "%UserProfile%\Documents\ASAP\Client_Admin"
XCOPY "%~dp0\Files" "%UserProfile%\Documents\ASAP\Client_Admin" /q /s /e /h
echo "Files kopiert. Erzeuge Verknüpfung..."
XCOPY "%~dp0\Files\ASAP-Admin.lnk" "%UserProfile%\Desktop" /q /s /e /h
echo "Installation beendet! Falls kein Desktop-Shortcut erzeugt wurde starten Sie den Installationsvorgang erneut und wenden sich gegebenen Falls an den Support"
pause 
