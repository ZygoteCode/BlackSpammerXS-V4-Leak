namespace BlackSpammerXS;

public class GChannel
{
	private string n;

	private string i;

	private ChannelType channel;

	public GChannel(string name, string id, ChannelType channelType)
	{
		n = name;
		i = id;
		channel = channelType;
	}

	public string GetName()
	{
		return n;
	}

	public ChannelType GetChannelType()
	{
		return channel;
	}

	public string GetId()
	{
		return i;
	}
}
