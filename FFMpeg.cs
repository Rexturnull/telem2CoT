using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

public class FFmpegChecker
{
    public static bool IsFFmpegInstalled()
    {
        try
        {
            using (Process process = new Process())
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    process.StartInfo.FileName = "ffmpeg.exe";  // Assuming ffmpeg.exe is in the system PATH
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    process.StartInfo.FileName = "/opt/homebrew/bin/ffmpeg";  // Common path for FFmpeg on macOS
                }
                else
                {
                    // Add support for other OS if necessary, e.g., Linux
                    process.StartInfo.FileName = "ffmpeg";
                }

                process.StartInfo.Arguments = "-version";  // Command to get the version of FFmpeg
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;

                process.Start();
                string output = process.StandardOutput.ReadToEnd(); // Read the output
                process.WaitForExit();

                return process.ExitCode == 0 && !string.IsNullOrEmpty(output);
            }
        }
        catch (Exception ex)
        {
            // Log the error if necessary
            Console.WriteLine($"Error checking FFmpeg: {ex.Message}");
            return false;
        }
    }
}

