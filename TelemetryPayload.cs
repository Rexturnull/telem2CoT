using System.Text;

public class TelemetryPayload
{
    public byte[] PresenceVector { get; set; } = new byte[5];
    public byte[] TimeStamp { get; set; } = new byte[5];
    public byte[] MissionId { get; set; } = new byte[6];
    public byte[] GcsName { get; set; } = new byte[6];
    public byte[] GcsLatitude { get; set; } = new byte[4];
    public byte[] GcsLongitude { get; set; } = new byte[4];
    public byte[] UavName { get; set; } = new byte[6];
    public byte[] UavLatitude { get; set; } = new byte[4];
    public byte[] UavLongitude { get; set; } = new byte[4];
    public byte[] UavPressureAltitude { get; set; } = new byte[3];
    public byte[] UavGPSAltitude { get; set; } = new byte[3];
    public byte[] UavHeading { get; set; } = new byte[2];
    public byte[] UavPitchAngle { get; set; } = new byte[2];
    public byte[] UavRollAngle { get; set; } = new byte[2];
    public byte[] UavSpeed { get; set; } = new byte[2];
    public byte[] UavClimbAngle { get; set; } = new byte[2];
    public byte[] LrfLatitude { get; set; } = new byte[4];
    public byte[] LrfLongitude { get; set; } = new byte[4]; 
    public String CotGuid { get; set; } = "uas-guid";

    public String GetCotGuid()
    {
        return CotGuid;
    }   

    public String GetTimestamp(byte[] epochMilliseconds)
    {
        if (epochMilliseconds.Length != 5)
            throw new ArgumentException("Input should be a 5-byte array");

        // Array.Reverse(epochMilliseconds);

        long value = 0;
        for (int i = 0; i < epochMilliseconds.Length; i++)
        {
            value = (value << 8) + epochMilliseconds[i];
        }

        // Calculate the epoch of January 1, 2000
        var epoch2000 = new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero).ToUnixTimeMilliseconds();

        // Subtract the epoch of January 1, 2000 from the current epoch milliseconds
        value -= epoch2000;

        DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(value);

        String ret = dateTimeOffset.ToString("yyyy-MM-dd HH:mm:ss.fff");

        return ret;
    }

    public String GetUavName()
    {
        return Encoding.GetEncoding("big5").GetString(UavName);
    }

    public String GetGcsName()
    {
        return Encoding.GetEncoding("big5").GetString(GcsName);
    }

    public String GetMissionId()
    {
        return Encoding.GetEncoding("big5").GetString(MissionId);
    }

    public String GetUavLatitude()
    {
        return CalculateBinaryAngularMeasurement4(UavLatitude).ToString();
    }

    public String GetUavLongitude()
    {
        return CalculateBinaryAngularMeasurement4(UavLongitude).ToString();
    }

    public String GetUavHeading()
    {
        return CalculateBinaryAngularMeasurement2(UavHeading).ToString();
    }

    public String GetUavPitchAngle()
    {
        return CalculateBinaryAngularMeasurement2(UavPitchAngle).ToString();
    }

    public String GetUavRollAngle()
    {
        return CalculateBinaryAngularMeasurement2(UavRollAngle).ToString();
    }

    public String GetUavPressureAltitudeMeters() {
        int result = (UavPressureAltitude[0] << 16) | (UavPressureAltitude[1] << 8) | UavPressureAltitude[2];

        if ((result & 0x800000) != 0)
        {
            result |= unchecked((int)0xFF000000);
        }

        return (result * 0.02).ToString();
    }

    public String GetUavGPSAltitudeMeters() {
        int result = (UavGPSAltitude[0] << 16) | (UavGPSAltitude[1] << 8) | UavGPSAltitude[2];

        if ((result & 0x800000) != 0)
        {
            result |= unchecked((int)0xFF000000);
        }

        return (result * 0.02).ToString();
    }

    public String GetUavSpeed()
    {
        int result = (UavSpeed[0] << 8) | UavSpeed[1];
        return (result * 0.05).ToString();
    }   

    static double CalculateBinaryAngularMeasurement2(byte[] bytes)
    {
        // Combine the two bytes into a single 16-bit value
        ushort value = (ushort)((bytes[0] << 8) | bytes[1]);

        // Calculate the angular measurement in degrees
        double measurement = value * 360.0 / 65536.0;

        return measurement;
    }

    static double CalculateBinaryAngularMeasurement4(byte[] bytes)
    {
        // Combine the four bytes into a single 32-bit value
        uint value = (uint)((bytes[0] << 24) | (bytes[1] << 16) | (bytes[2] << 8) | bytes[3]);

        // Calculate the angular measurement in degrees
        double measurement = value * 360.0 / 4294967296.0;

        return measurement;
    }
}
