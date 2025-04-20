using System;

namespace BlackSpammerXS
{
	// Token: 0x02000020 RID: 32
	public class GChannel
	{
		// Token: 0x06000091 RID: 145 RVA: 0x0000A774 File Offset: 0x00008974
		public GChannel(string name, string id, ChannelType channelType)
		{
			this.n = name;
			this.i = id;
			this.channel = channelType;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000A794 File Offset: 0x00008994
		public string GetName()
		{
			return this.n;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000A7AC File Offset: 0x000089AC
		public ChannelType GetChannelType()
		{
			return this.channel;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000A7C4 File Offset: 0x000089C4
		public string GetId()
		{
			return this.i;
		}

		// Token: 0x04000103 RID: 259
		private string n;

		// Token: 0x04000104 RID: 260
		private string i;

		// Token: 0x04000105 RID: 261
		private ChannelType channel;
	}
}
