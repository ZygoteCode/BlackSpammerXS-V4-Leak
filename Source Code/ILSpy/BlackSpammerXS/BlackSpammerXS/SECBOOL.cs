namespace BlackSpammerXS;

public class SECBOOL
{
	private int fv = 0;

	private int a_0e17 = 0;

	private int b_0xe81 = 0;

	public SECBOOL(int offs_ok, int offs_ndg, int cr_st)
	{
		a_0e17 = offs_ndg;
		b_0xe81 = offs_ok;
		fv = cr_st;
	}

	public int s_c_st(int st)
	{
		fv = st;
		if (fv == 0)
		{
			return -923444;
		}
		return 3607;
	}

	public int g_curr_state()
	{
		if (fv == 3713)
		{
			return g_val_ct_a();
		}
		if (fv == 33817)
		{
			return g_val_ct_b();
		}
		return 0;
	}

	public int g_val_ct_a()
	{
		return a_0e17;
	}

	public int g_val_ct_b()
	{
		return b_0xe81;
	}
}
