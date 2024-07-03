using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

public class FFmpegLauncher
{
    public static void LaunchFFmpeg(string ffmpegArguments)
    {
        var processStartInfo = new ProcessStartInfo
        {
            FileName = "ffmpeg",
            Arguments = ffmpegArguments,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };

        using (var process = new Process { StartInfo = processStartInfo })
        {
            process.Start();

            var outputTask = Task.Run(() => ReadStreamAsync(process.StandardOutput));
            var errorTask = Task.Run(() => ReadStreamAsync(process.StandardError));

            Task.WaitAll(outputTask, errorTask);
        }
    }

    private static async Task ReadStreamAsync(StreamReader stream)
    {
        while (!stream.EndOfStream)
        {
            string? line = await stream.ReadLineAsync();
            if (line != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}