# 1. Set the source and destination paths
$sourcePath = "$PSScriptRoot\ffmpeg"  # ffmpeg folder in the current directory
$destinationPath = "C:\ffmpeg"

# 2. Copy the folder to the C drive
if (Test-Path $sourcePath) {
    Copy-Item -Recurse -Force -Path $sourcePath -Destination $destinationPath
    Write-Host "ffmpeg folder successfully copied to C:\ffmpeg"
} else {
    Write-Host "ffmpeg folder not found"
    exit
}

# 3. Get the current system environment variables
$envPath = [System.Environment]::GetEnvironmentVariable("Path", [System.EnvironmentVariableTarget]::Machine)

# 4. Check if ffmpeg is already in the environment variables
if ($envPath -notlike "*C:\ffmpeg*") {
    # 5. Add ffmpeg to the system environment variables
    [System.Environment]::SetEnvironmentVariable("Path", "$envPath;C:\ffmpeg\bin", [System.EnvironmentVariableTarget]::Machine)
    Write-Host "ffmpeg added to system environment variables"
} else {
    Write-Host "ffmpeg is already in the system environment variables"
}

# 6. Set ExecutePolicy
Set-ExecutionPolicy Unrestricted
Write-Host "Set ExecutePolicy to Unrestricted"

# 7. Prompt to restart
Write-Host "Please restart the system or reopen PowerShell for changes to take effect"
