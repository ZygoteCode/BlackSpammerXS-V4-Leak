using System;
using System.Collections.Generic;

namespace BlackSpammerXS
{
	// Token: 0x02000021 RID: 33
	public class GuildChannels
	{
		// Token: 0x06000095 RID: 149 RVA: 0x0000A7DC File Offset: 0x000089DC
		public GuildChannels(string guildId, List<GChannel> canali)
		{
			this.canali = canali;
			this.guildId = guildId;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000A7F4 File Offset: 0x000089F4
		public List<GChannel> GetChannels()
		{
			return this.canali;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000A80C File Offset: 0x00008A0C
		public string GetGuildId()
		{
			return this.guildId;
		}

		// Token: 0x04000106 RID: 262
		private string guildId;

		// Token: 0x04000107 RID: 263
		private List<GChannel> canali;
	}
}
