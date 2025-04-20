using System;

namespace BlackSpammerXS
{
	// Token: 0x02000093 RID: 147
	public class SECBOOL
	{
		// Token: 0x06000266 RID: 614 RVA: 0x0002EDD4 File Offset: 0x0002CFD4
		public SECBOOL(int offs_ok, int offs_ndg, int cr_st)
		{
			this.a_0e17 = offs_ndg;
			this.b_0xe81 = offs_ok;
			this.fv = cr_st;
		}

		// Token: 0x06000267 RID: 615 RVA: 0x0002EE08 File Offset: 0x0002D008
		public int s_c_st(int st)
		{
			this.fv = st;
			bool flag = this.fv == 0;
			int num;
			if (flag)
			{
				num = -923444;
			}
			else
			{
				num = 3607;
			}
			return num;
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0002EE3C File Offset: 0x0002D03C
		public int g_curr_state()
		{
			bool flag = this.fv == 3713;
			int num;
			if (flag)
			{
				num = this.g_val_ct_a();
			}
			else
			{
				bool flag2 = this.fv == 33817;
				if (flag2)
				{
					num = this.g_val_ct_b();
				}
				else
				{
					num = 0;
				}
			}
			return num;
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0002EE88 File Offset: 0x0002D088
		public int g_val_ct_a()
		{
			return this.a_0e17;
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0002EEA0 File Offset: 0x0002D0A0
		public int g_val_ct_b()
		{
			return this.b_0xe81;
		}

		// Token: 0x040005B6 RID: 1462
		private int fv = 0;

		// Token: 0x040005B7 RID: 1463
		private int a_0e17 = 0;

		// Token: 0x040005B8 RID: 1464
		private int b_0xe81 = 0;
	}
}
