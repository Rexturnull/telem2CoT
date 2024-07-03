Set-ExecutionPolicy RemoteSigned -Scope CurrentUser

$currentDir = Get-Location

# Define the path to your C# file
$csFilePath = "$currentDir\TelemToCot\Telem2CoT.cs"

# Define the output executable path
$outputExePath = "$currentDir\TelemToCot\Telem2CoT.exe"

# Define the arguments to pass to your program
$args = @(
    "--listen-port",  "6060",
    "--tak-ip",       "172.28.1.51",
    "--tak-port",     "8087",
    "--tak-protocol", "tcp",
    "--source-video-url", "rtsp://10.193.1.160:554/uav01_eo?key=circ",
    "--dest-video-url",   "rtsp://video.tfn.mil.tw:8554/live/RWUAS",
    "--callsign",         "RWUAS",
    "--bitrate",          "800k",
    "--resolution",       "640:480"
)

# Compile the C# file to an executable
csc /out:$outputExePath $csFilePath

# Check if compilation was successful
