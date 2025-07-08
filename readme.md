# Internet
```bash
netsh interface ipv4 show interfaces
netsh interface ipv4 set address interface=12 static 10.193.1.161 255.255.255.0 10.193.1.1

netsh interface set interface name="12" admin=disable
netsh interface set interface name="12" admin=enable
```
Collision IP
```bash
Event > System
```

# Execute
```bash
dotnet new console
# delete Program.cs

dotnet run
```

# Automatic
env
```
Install .NET Core Extension Pack

# launch.json and tasks.json
F1 > .NET Generate Assets for Build and Debug
```
Launch Configuration: .vscode/launch.json
```
When debugging is started in VSCode (F5), you must specify the main 
program path and related settings for debugging.
```
Give lanuch.json args
```json
"args": [
    "172.28.1.51",
    "--tak-port",
    "8087",
    "--tak-protocol",
    "tcp",
    "--source-video-url",
    "rtsp://10.193.1.160:554/uav02_eo?key=circ",
    "--dest-video-url",
    "rtsp://video.tfn.mil.tw:8554/live/RWUAS",
    "--callsign",
    "RWUAS",
    "--bitrate",
    "800k",
    "--resolution",
    "640:480"
],
```
Task Configuration: .vscode/tasks.json
```
You can set up common commands (e.g., build, test, publish, deploy) 
and use VSCode to initiate the tasks defined here.
```

# FFmpeg
```bash
# mediamtx Server
https://github.com/bluenviron/mediamtx/releases

# Local
ffmpeg -re -stream_loop -1 -i fish.mp4 -c:v libx264 -f rtsp rtsp://localhost:8554/mystream

# Play
ffplay -rtsp_transport tcp rtsp://10.193.1.160:554/uav02_eo?key=circ
vlc rtsp://localhost:8554/mystream

# Upload
ffmpeg -rtsp_transport tcp -i rtsp://10.193.1.160:554/uav02_eo?key=circ -rw_timeout 5000000 -r 30 -q:v 2 -b:v 500k -s 640x360 -c:v libx264 -f rtsp rtsp://video.tfn.mil.tw:8554/live/TEST
```