if not exist "C:\Program Files\XRFAgent\" mkdir "C:\Program Files\XRFAgent"
robocopy "C:\HAC\scripts\agenttemp" "C:\Program Files\XRFAgent" /E /R:6 /W:5
rmdir /s /q C:\HAC\Scripts\agenttemp
sc create "XRFAgent" binpath="\"C:\Program Files\XRFAgent\XRFAgent.exe\"" start=auto displayname="XRF Agent Service"
net start XRFAgent
exit