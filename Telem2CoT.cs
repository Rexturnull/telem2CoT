using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml.Linq;
using System.Threading;

enum TakProtocolOptions
{
    UDP,
    TCP
}


class ConfigOptions
{
    public required string TakIp { get; set; }
    public int TakPort { get; set; }
    public int ListenPort { get; set; }
    public TakProtocolOptions TakProtocol { get; set; } = TakProtocolOptions.TCP;
    public required string Callsign { get; set; }
    public bool Debug { get; set; } = true;
    public required string SourceVideoUrl { get; set; }
    public required string DestVideoUrl { get; set; }
    public required string VideoPublishBitrate { get; set; } // -b:v 800k
    public required string VideoPublishResolution { get; set; } // -s 640x480

}

class Program
{
    static void Main(string[] args)
    {
        Banner();

        var config = ParseArguments(args);

        UdpClient udpClient = new UdpClient(config.ListenPort);
        IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
        //IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("10.193.1.160"), 0);
        string cotGuid = Guid.NewGuid().ToString();

        if (!FFmpegChecker.IsFFmpegInstalled())
        {
            Console.WriteLine("FFmpeg is not installed or not in the system PATH. Please install FFmpeg to continue.");
            return;
        }
        else
        {
            Console.WriteLine("FFmpeg is installed.");
        }




        // Specify the video resolution and bitrate in arg
        //var ffmpegArguments = $"-i {config.SourceVideoUrl} -c:v libx264 -b:v {config.VideoPublishBitrate} -vf scale={config.VideoPublishResolution} -f rtsp -rtsp_transport tcp {config.DestVideoUrl}";

        var ffmpegArguments = $"-i {config.SourceVideoUrl} -r 30 -q:v 2 -b:v {config.VideoPublishBitrate} -s {config.VideoPublishResolution} -c:v libx264 -f rtsp {config.DestVideoUrl}";
        //var ffmpegArguments_2 = $"-i rtsp://10.193.1.160:554/uav01_eo?key=circ -r 30 -q:v 2 -b:v 500k -s 426x240 -c:v libx264 -f rtsp rtsp://video.tfn.mil.tw:8554/live/RWUAS";
        //var ffmpegArguments_2 = $"-i rtsp://10.193.1.160:554/uav02_eo?key=circ -r 30 -q:v 2 -b:v 800k -s 640x480 -c:v libx264 -f rtsp rtsp://172.31.4.1:8554/live/RWUAS";

        //ffmpeg -i rtsp://10.193.1.160:554/uav02_eo?key=circ -r 30 -q:v 2 -b:v 800k -s 640x480 -c:v libx264 -f rtsp rtsp://video.tfn.mil.tw:8554/live/RWUAS


        // Thread ffmpegThread = new Thread(() => FFmpegLauncher.LaunchFFmpeg(ffmpegArguments));
        // ffmpegThread.Start();
        //Task.Run(() => FFmpegLauncher.LaunchFFmpeg(ffmpegArguments_1));
        Task.Run(() => FFmpegLauncher.LaunchFFmpeg(ffmpegArguments));

        // FFmpegLauncher.LaunchFFmpeg(ffmpegArguments);

        // Console.WriteLine("Listening for telemetry data on port {0}", config.ListenPort);
        // Console.WriteLine("Sending CoT to {0}:{1}", config.TakIp, config.TakPort);
        // Console.WriteLine("Tak protocol: {0}", config.TakProtocol.ToString());
        // Console.WriteLine("Callsign: {0}", config.Callsign);

        Console.WriteLine("============================RTSP============================");
        Console.WriteLine("SourceVideoUrl         : {0}", config.SourceVideoUrl);
        Console.WriteLine("DestVideoUrl           : {0}", config.DestVideoUrl);
        Console.WriteLine("Callsign               : {0}", config.Callsign);
        Console.WriteLine("VideoPublishBitrate    : {0}", config.VideoPublishBitrate);
        Console.WriteLine("VideoPublishResolution : {0}", config.VideoPublishResolution);
        // Start ffmpeg
        Console.WriteLine("Starting ffmpeg video stream capture from {0} and sending to {1}", config.SourceVideoUrl, config.DestVideoUrl);

        Console.WriteLine("============================Cot============================");
        Console.WriteLine("ListenPort : {0}", config.ListenPort);


        Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<Start>>>>>>>>>>>>>>>>>>>>>>>>>>");


        try
        {
            while (true)
            {
                //Console.WriteLine("remoteEndPoint: ", remoteEndPoint);

                byte[] payload = udpClient.Receive(ref remoteEndPoint);
                //Console.WriteLine("payload: ", payload.Length);


                if (payload.Length >= 86)
                {
                    int offset = 0;

                    // Sequence 2 bytes
                    byte[] sequence = new byte[2];
                    Array.Copy(payload, offset, sequence, 0, sequence.Length);
                    offset += sequence.Length;

                    // Message length
                    byte[] messageLength = new byte[2];
                    Array.Copy(payload, offset, messageLength, 0, messageLength.Length);
                    offset += messageLength.Length;

                    // Message source 4 bytes
                    byte[] messageSource = new byte[4];
                    Array.Copy(payload, offset, messageSource, 0, messageSource.Length);
                    offset += messageSource.Length;

                    // Message destination 4 bytes
                    byte[] messageDestination = new byte[4];
                    Array.Copy(payload, offset, messageDestination, 0, messageDestination.Length);
                    offset += messageDestination.Length;

                    // Message type 2 bytes
                    // TODO: handle is message type is incorrect
                    byte[] messageType = new byte[2];
                    Array.Copy(payload, offset, messageType, 0, messageType.Length);
                    offset += messageType.Length;
                    Array.Reverse(messageType);
                    Console.WriteLine("Message Type: " + BitConverter.ToUInt16(messageType, 0));

                    // Message properties 2 bytes
                    byte[] messageProperties = new byte[2];
                    Array.Copy(payload, offset, messageProperties, 0, messageProperties.Length);
                    offset += messageProperties.Length;

                    // Extract the presence vector [unsigned 5]
                    byte[] presenceVector = new byte[5];
                    Array.Copy(payload, offset, presenceVector, 0, presenceVector.Length);
                    offset += presenceVector.Length;

                    // Extract the time stamp [unsigned 5 GPS UTC Time 0.001 s]
                    byte[] timeStamp = new byte[5];
                    Array.Copy(payload, offset, timeStamp, 0, timeStamp.Length);
                    offset += timeStamp.Length;

                    // Extract the mission id [character 20, assuming big 5 encoding of 6 bytes]
                    byte[] missionId = new byte[6];
                    Array.Copy(payload, offset, missionId, 0, missionId.Length);
                    offset += missionId.Length;

                    // Extract the GCS name [character 20]
                    byte[] gcsName = new byte[6];
                    Array.Copy(payload, offset, gcsName, 0, gcsName.Length);
                    offset += gcsName.Length;

                    // Extract the GCS latitude [int 4 BAM]
                    byte[] gcsLatitude = new byte[4];
                    Array.Copy(payload, offset, gcsLatitude, 0, gcsLatitude.Length);
                    offset += gcsLatitude.Length;

                    // Extract the GCS longitude [int 4 BAM]
                    byte[] gcsLongitude = new byte[4];
                    Array.Copy(payload, offset, gcsLongitude, 0, gcsLongitude.Length);
                    offset += gcsLongitude.Length;

                    // Extract the UAV name [character 20]
                    byte[] uavName = new byte[6];
                    Array.Copy(payload, offset, uavName, 0, uavName.Length);
                    offset += uavName.Length;

                    // Extract the UAV latitude [int 4 BAM]
                    byte[] uavLatitude = new byte[4];
                    Array.Copy(payload, offset, uavLatitude, 0, uavLatitude.Length);
                    offset += uavLatitude.Length;

                    // Extract the UAV latitude [int 4 BAM]
                    byte[] uavLongitude = new byte[4];
                    Array.Copy(payload, offset, uavLongitude, 0, uavLongitude.Length);
                    offset += uavLongitude.Length;

                    // Extract the UAV Pressure Altitude [int 3 0.02 m]
                    byte[] uavPressureAltitude = new byte[3];
                    Array.Copy(payload, offset, uavPressureAltitude, 0, uavPressureAltitude.Length);
                    offset += uavPressureAltitude.Length;

                    // Extract the UAV GPS Altitude [int 3 0.02 m]
                    byte[] uavGPSAltitude = new byte[3];
                    Array.Copy(payload, offset, uavGPSAltitude, 0, uavGPSAltitude.Length);
                    offset += uavGPSAltitude.Length;

                    // Extract the UAV Heading [int 2 BAM]
                    byte[] uavHeading = new byte[2];
                    Array.Copy(payload, offset, uavHeading, 0, uavHeading.Length);
                    offset += uavHeading.Length;

                    // Extract the UAV Pitch Angle [int 2 BAM]
                    byte[] uavPitchAngle = new byte[2];
                    Array.Copy(payload, offset, uavPitchAngle, 0, uavPitchAngle.Length);
                    offset += uavPitchAngle.Length;

                    // Extract the UAV Roll Angle [int 2 BAM]
                    byte[] uavRollAngle = new byte[2];
                    Array.Copy(payload, offset, uavRollAngle, 0, uavRollAngle.Length);
                    offset += uavRollAngle.Length;

                    // Extract the UAV Speed [uint 2 0.05 m/s]
                    byte[] uavSpeed = new byte[2];
                    Array.Copy(payload, offset, uavSpeed, 0, uavSpeed.Length);
                    offset += uavSpeed.Length;

                    // Extract the UAV Climb Angle [int 2 0.05 m/s]
                    byte[] uavClimbAngle = new byte[2];
                    Array.Copy(payload, offset, uavClimbAngle, 0, uavClimbAngle.Length);
                    offset += uavClimbAngle.Length;

                    // Extract the Laser Range Finder Target Latitude [int 4 BAM]
                    byte[] lrfTargetLatitude = new byte[4];
                    Array.Copy(payload, offset, lrfTargetLatitude, 0, lrfTargetLatitude.Length);
                    offset += lrfTargetLatitude.Length;

                    // Extract the Laser Range Finder Target Longitude [int 4 BAM]
                    byte[] lrfTargetLongitude = new byte[4];
                    Array.Copy(payload, offset, lrfTargetLongitude, 0, lrfTargetLongitude.Length);
                    offset += lrfTargetLongitude.Length;

                    MessageHeader messageHeader = new MessageHeader
                    {
                        Sequence = sequence,
                        Length = messageLength,
                        Source = messageSource,
                        Destination = messageDestination,
                        Type = messageType,
                        Properties = messageProperties
                    };

                    TelemetryPayload tp = new TelemetryPayload
                    {

                        CotGuid = cotGuid,
                        PresenceVector = presenceVector,
                        TimeStamp = timeStamp,
                        MissionId = missionId,
                        GcsName = gcsName,
                        GcsLatitude = gcsLatitude,
                        GcsLongitude = gcsLongitude,
                        UavName = uavName,
                        UavLatitude = uavLatitude,
                        UavLongitude = uavLongitude,
                        UavPressureAltitude = uavPressureAltitude,
                        UavGPSAltitude = uavGPSAltitude,
                        UavHeading = uavHeading,
                        UavPitchAngle = uavPitchAngle,
                        UavRollAngle = uavRollAngle,
                        UavSpeed = uavSpeed,
                        UavClimbAngle = uavClimbAngle,
                        LrfLatitude = lrfTargetLatitude,
                        LrfLongitude = lrfTargetLongitude
                    };

                    string cotData = CreateCoTMessage(tp, config.DestVideoUrl);

                    if (config.Debug)
                    {
                        Console.WriteLine(cotData);
                        Console.WriteLine("Pressure Altitude: " + tp.GetUavPressureAltitudeMeters());
                        Console.WriteLine("GPS Altitude: " + tp.GetUavGPSAltitudeMeters());
                    }

                    SendCoTDataOverTcp(cotData, config.TakIp, config.TakPort);
                }
                else
                {
                    Console.WriteLine("Received unexpected payload");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        finally
        {
            udpClient.Close();
        }
    }

    static string CreateCoTMessage(TelemetryPayload telemetryPayload, String videoUrl)
    // Example CoT detail
    // <detail>
    // <__video url='rtsp://foo' sensor='123'/>
    // <remarks>ICAO-ABC123(N12345); 2008 BOEING 737-823; Eng(s):02 jet; British Airways(UK) "Speedbird" BAW; Mode3A:0237</remarks>
    // <contact callsign='BAW2322'/>  ## This should be from the SBS MSG,1, ref[10] (Max of 7 characters)
    // <status battery='0'/>
    // <track course='225.00' speed='248.47664520'/>
    // <precisionlocation altsrc='gps' geopointsrc='gps'/>
    // </detail>
    {
        XElement cotEvent = new XElement("event",
            new XAttribute("version", "2.0"),
            new XAttribute("how", "m-g"),
            new XAttribute("uid", telemetryPayload.GetCotGuid()),
            new XAttribute("type", "a-f-A"),
            new XAttribute("time", DateTime.UtcNow.ToString("o")),
            new XAttribute("start", DateTime.UtcNow.ToString("o")),
            new XAttribute("stale", DateTime.UtcNow.AddHours(1).ToString("o")),
            new XElement("point",
                new XAttribute("lat", telemetryPayload.GetUavLatitude()),
                new XAttribute("lon", telemetryPayload.GetUavLongitude()),
                // TODO: should this be gps altitude of baro alt?
                new XAttribute("hae", telemetryPayload.GetUavGPSAltitudeMeters()),
                new XAttribute("ce", "9999999"),
                new XAttribute("le", "9999999")),
            new XElement("detail",
                new XElement("__video",
                    new XAttribute("url", videoUrl),
                    new XAttribute("sensor", telemetryPayload.GetCotGuid())
                ),
                // TODO: update remarks with UAV information
                new XElement("remarks",
                    new XText("these are test remarks")
                ),
                // TODO: update callsign
                new XElement("contact",
                    new XAttribute("callsign", "RW UAS")
                ),
                new XElement("status",
                    new XAttribute("battery", "0")
                ),
                new XElement("track",
                    new XAttribute("course", telemetryPayload.GetUavHeading()),
                    new XAttribute("speed", telemetryPayload.GetUavSpeed())
                ),
                new XElement("precisionlocation",
                    new XAttribute("altsrc", "gps"),
                    new XAttribute("geopointsrc", "gps")
                )
            )
        );

        return cotEvent.ToString();
    }

    public static void SendUdp(string cotXml, string destinationIp, int destinationPort)
    {
        UdpClient udpClient = new UdpClient();
        try
        {
            byte[] bytesToSend = Encoding.UTF8.GetBytes(cotXml);

            IPAddress destIp = IPAddress.Parse(destinationIp);
            IPEndPoint endPoint = new IPEndPoint(destIp, destinationPort);

            udpClient.Send(bytesToSend, bytesToSend.Length, endPoint);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while sending the UDP packet: {ex.Message}");
        }
        finally
        {
            udpClient.Close();
        }
    }

    public static void SendCoTDataOverTcp(string cotData, string destinationIp, int destinationPort)
    {
        try
        {
            using (TcpClient client = new TcpClient(destinationIp, destinationPort))
            {
                NetworkStream stream = client.GetStream();
                byte[] dataToSend = Encoding.UTF8.GetBytes(cotData);
                stream.Write(dataToSend, 0, dataToSend.Length);
                Console.WriteLine("Sent CoT data to {0}:{1}", destinationIp, destinationPort);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error sending CoT data over TCP: " + ex.Message);
        }
    }

    static ConfigOptions ParseArguments(string[] args)
    {
        String TakIp = "172.28.1.51";
        String SourceVideoUrl = "rtsp://10.193.1.160:554/uav01_eo?key=circ";
        String DestVideoUrl = "rtsp://video.tfn.mil.tw:8554/live/RWUAS";
        String Callsign = "RWUAS";
        String VideoPublishBitrate = "300k";
        String VideoPublishResolution = "426:240";
        int TakPort = 8087;
        int ListenPort = 6060;
        TakProtocolOptions TakProtocol = TakProtocolOptions.TCP;

        for (int i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "--tak-ip":
                    if (i + 1 < args.Length)
                    {
                        TakIp = args[++i];
                    }
                    else
                    {
                        Console.WriteLine("--tak-ip argument is missing. Exiting the program.");
                        Environment.Exit(0);
                    }
                    break;
                case "--tak-port":
                    if (i + 1 < args.Length && int.TryParse(args[++i], out int takPort))
                    {
                        TakPort = takPort;
                    }
                    break;
                case "--listen-port":
                    if (i + 1 < args.Length && int.TryParse(args[++i], out int listenPort))
                    {
                        ListenPort = listenPort;
                    }
                    break;
                case "--tak-protocol":
                    if (i + 1 < args.Length)
                    {
                        if (args[++i].ToLower() == "udp")
                        {
                            TakProtocol = TakProtocolOptions.UDP;
                        }
                        else
                        {
                            TakProtocol = TakProtocolOptions.TCP;
                        }
                    }
                    break;
                case "--source-video-url":
                    if (i + 1 < args.Length) SourceVideoUrl = args[++i];
                    break;
                case "--dest-video-url":
                    if (i + 1 < args.Length) DestVideoUrl = args[++i];
                    break;
                case "--callsign":
                    if (i + 1 < args.Length) Callsign = args[++i];
                    break;
                case "--bitrate":
                    VideoPublishBitrate = i + 1 < args.Length ? args[++i] : "800k";
                    break;
                case "--resolution":
                    VideoPublishResolution = i + 1 < args.Length ? args[++i] : "640:480";
                    break;
            }
        }

        var options = new ConfigOptions
        {
            TakIp = TakIp,
            TakPort = TakPort,
            ListenPort = ListenPort,
            TakProtocol = TakProtocol,
            Callsign = Callsign,
            SourceVideoUrl = SourceVideoUrl,
            DestVideoUrl = DestVideoUrl,
            VideoPublishBitrate = VideoPublishBitrate,
            VideoPublishResolution = VideoPublishResolution
        };

        return options;
    }

    static void Banner()
    {
        string[] banner = {
        // "\x1b[31m  ____                       _                \x1b[0m",
        // "\x1b[32m / ___| ___ _ __   ___  _ __(_) ___ ___       \x1b[0m",
        // "\x1b[33m| |  _ / _ \\ '_ \\ / _ \\| '__| |/ __/ _ \\  \x1b[0m",
        // "\x1b[34m| |_| |  __/ | | | (_) | |  | | (_|  __/      \x1b[0m",
        // "\x1b[35m \\____|\\___|_| |_|\\___/|_|  |_|\\___\\___| \x1b[0m",

"\x1b[31m  __  __ _   _ _____                                                   \x1b[0m",
"\x1b[32m |  \\/  | \\ | |  __ \\                                               \x1b[0m",
"\x1b[33m | \\  / |  \\| | |  | |                                               \x1b[0m",
"\x1b[34m | |\\/| | . ` | |  | |                                                \x1b[0m",
"\x1b[35m | |  | | |\\  | |__| |                                                \x1b[0m",
"\x1b[31m |_|__|_|_| \\_|_____/                                           _     \x1b[0m",
"\x1b[32m  / ____|      / _| |                                          | |     \x1b[0m",
"\x1b[33m | (___   ___ | |_| |___      ____ _ _ __ ___    __ _ _ __   __| |     \x1b[0m",
"\x1b[34m  \\___ \\ / _ \\|  _| __\\ \\ /\\ / / _` | '__/ _ \\  / _` | '_ \\ / _` |  \x1b[0m",
"\x1b[35m  ____) | (_) | | | |_ \\ V  V / (_| | | |  __/ | (_| | | | | (_| |         \x1b[0m",
"\x1b[31m |_____/ \\___/|_|  \\__| \\_/\\_/ \\__,_|_|  \\___|  \\__,_|_| |_|\\__,_|  \x1b[0m",
"\x1b[32m |_   _|      / _|                         | | (_)                          \x1b[0m",
"\x1b[33m   | |  _ __ | |_ ___  _ __ _ __ ___   __ _| |_ _  ___  _ __                \x1b[0m",
"\x1b[34m   | | | '_ \\|  _/ _ \\| '__| '_ ` _ \\ / _` | __| |/ _ \\| '_ \\          \x1b[0m",
"\x1b[35m  _| |_| | | | || (_) | |  | | | | | | (_| | |_| | (_) | | | |              \x1b[0m",
"\x1b[31m |_____|_| |_|_| \\___/|_|  |_| |_| |_|\\__,_|\\__|_|\\___/|_| |_|          \x1b[0m",
"\x1b[32m |  __ \\               | |                                | |              \x1b[0m",
"\x1b[33m | |  | | _____   _____| | ___  _ __  _ __ ___   ___ _ __ | |_              \x1b[0m",
"\x1b[31m | |  | |/ _ \\ \\ / / _ \\ |/ _ \\| '_ \\| '_ ` _ \\ / _ \\ '_ \\| __|     \x1b[0m",
"\x1b[32m | |__| |  __/\\ V /  __/ | (_) | |_) | | | | | |  __/ | | | |_             \x1b[0m",
"\x1b[33m |_____/ \\___| \\_/ \\___|_|\\___/| .__/|_| |_| |_|\\___|_| |_|\\__|       \x1b[0m",
"\x1b[34m  / ____|         | |          | |                                          \x1b[0m",
"\x1b[35m | |     ___ _ __ | |_ ___ _ __|_|                                          \x1b[0m",
"\x1b[31m | |    / _ \\ '_ \\| __/ _ \\ '__|                                         \x1b[0m",
"\x1b[32m | |___|  __/ | | | ||  __/ |                                               \x1b[0m",
"\x1b[33m  \\_____\\___|_| |_|\\__\\___|_|                                            \x1b[0m"





    };

        foreach (var line in banner)
        {
            Console.WriteLine(line);
        }

        Thread.Sleep(3000);


        string filePath = "banner.ans";
        string asciiContent = File.ReadAllText(filePath);
        Console.WriteLine(asciiContent);

        Thread.Sleep(3000);

    }

}