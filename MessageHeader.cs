public class MessageHeader
{
    public required byte[] Sequence { get; set; }
    public required byte[] Length { get; set; }
    public required byte[] Source { get; set; }
    public required byte[] Destination { get; set; }
    public required byte[] Type { get; set; }
    public required byte[] Properties { get; set; }
} 
