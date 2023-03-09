namespace DomainModels;

public class ServerPlatform
{
    public int PlatformId { get; set; }
    public int ServerId { get; set; }

    public Platform Platform { get; set; }
    public Server Server { get; set; }
}