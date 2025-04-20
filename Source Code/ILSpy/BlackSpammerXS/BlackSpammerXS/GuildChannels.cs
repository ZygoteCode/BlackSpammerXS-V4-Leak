using System.Collections.Generic;

namespace BlackSpammerXS;

public class GuildChannels
{
	private string guildId;

	private List<GChannel> canali;

	public GuildChannels(string guildId, List<GChannel> canali)
	{
		this.canali = canali;
		this.guildId = guildId;
	}

	public List<GChannel> GetChannels()
	{
		return canali;
	}

	public string GetGuildId()
	{
		return guildId;
	}
}
