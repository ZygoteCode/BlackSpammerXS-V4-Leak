using System;

namespace BlackSpammerXS
{
	// Token: 0x02000094 RID: 148
	public class SecLG
	{
		// Token: 0x0600026B RID: 619 RVA: 0x0002EEB8 File Offset: 0x0002D0B8
		public static void o_wr(string o)
		{
			Console.WriteLine("[BSXS V4] [debug] [log] " + o);
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0002EECC File Offset: 0x0002D0CC
		public static void ntf_ex(string rs = "rexit_ntfex01")
		{
			SecLG.o_wr("f_typec : Exiting.. [-0xe18] clrs=" + rs);
		}
	}
}
