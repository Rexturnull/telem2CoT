# ============arguments for user============
# Define the arguments to pass to your program
$args = @(
    "--listen-port",      "6060",
    "--source-video-url", "rtsp://10.193.1.160:554/uav02_eo?key=circ",
    "--dest-video-url",   "rtsp://video.tfn.mil.tw:8554/live/RWUAS",
    "--callsign",         "RWUAS",
    "--bitrate",          "800k",     #300k/600k/800k
    "--resolution",       "640:480"   #426:240/640:360/640:480
)

# ============Function============
# Function to print messages with colors
function Write-Color {
    param (
        [string]$Message,
        [string]$Color = "White"
    )
    Write-Host $Message -ForegroundColor $Color
}
# Function to kill processes using a specific port
function Kill-ProcessesUsingPort {
    param (
        [int]$Port
    )

    # Run netstat and find processes using the specified port
    $netstatOutput = netstat -ano | findstr ":$Port"

    if ($netstatOutput) {
        # Extract PIDs from netstat output
        $processIds = $netstatOutput | ForEach-Object {
            if ($_ -match '\s+(\d+)\s*$') {
                $matches[1]
            }
        }

        if ($processIds) {
            Write-Color "Processes using port $Port"
            foreach ($processId in $processIds) {
                Write-Host "Process ID: $processId"
                # Kill the process
                Stop-Process -Id $processId -Force
                Write-Color "Killed process with Process ID: $processId" "Yellow"
            }
        } else {
            Write-Color "No processes found using port $Port" "Green"
        }
    } else {
        Write-Color "No processes found using port $Port" "Green"
    }
}


# Get the current directory
$currentDir = Get-Location
Write-Color "Current Directory: $currentDir" "Green"

# ============Build============
# Define the solution path
$solutionPath = "$currentDir\telem2CoT.sln"

# Build the solution
Write-Color "Building the solution in Release mode..." "Green"
dotnet build $solutionPath -c Release

# Check if the build was successful
if ($LASTEXITCODE -ne 0) {
    Write-Color "Build failed." "Red"
    exit 1
}

# Get the exePath 
$exePath = Join-Path -Path $currentDir -ChildPath "bin\Release\net8.0\Telem2CoT.exe"
Write-Color "Executable Path: $exePath" "Green"

# Copy Banner
Copy-Item -Path "$currentDir\banner.ans" -Destination "$currentDir\bin\Release\net8.0" -Force

# Check if the executable file exists
if (-Not (Test-Path $exePath)) {
    Write-Color "Executable not found: $exePath" "Red"
    exit 1
}

# ============Kill Port============
# Find and extract the listen-port argument value
$portIndex = $args.IndexOf("--listen-port")
if ($portIndex -ne -1 -and $portIndex + 1 -lt $args.Length) {
    $port = $args[$portIndex + 1]
    Write-Host "Port value extracted from arguments: $port"
    $port = [int]$port
    Write-Color "Checking processes using port $port..." "Green"
    Kill-ProcessesUsingPort -Port $port
} else {
    Write-Host "Listen-port argument not found in arguments."
}

# Start the process and capture output
try {
    Write-Color "Starting the process..." "Green"
    $process = Start-Process -FilePath $exePath -ArgumentList $args -WindowStyle Normal -PassThru
    # Check if process started successfully
    if ($process -eq $null) {
        Write-Color "Failed to start the process." "Red"
        exit 1
    }

    # Wait for the process to exit
    Write-Color "Waiting for the process to exit..." "Yellow"
    $process.WaitForExit()

    # Check if process exited successfully
    if ($process.ExitCode -eq 0) {
        Write-Color "Process exited successfully." "Green"
    } else {
        Write-Color "Process exited with error code $($process.ExitCode)." "Red"
    }
}
catch {
    Write-Color "An error occurred: $_" "Red"
}
