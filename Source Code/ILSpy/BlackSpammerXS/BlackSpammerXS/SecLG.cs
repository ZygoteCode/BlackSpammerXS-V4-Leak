using System;

namespace BlackSpammerXS;

public class SecLG
{
	public static void o_wr(string o)
	{
		Console.WriteLine("[BSXS V4] [debug] [log] " + o);
	}

	public static void ntf_ex(string rs = "rexit_ntfex01")
	{
		o_wr("f_typec : Exiting.. [-0xe18] clrs=" + rs);
	}
}
