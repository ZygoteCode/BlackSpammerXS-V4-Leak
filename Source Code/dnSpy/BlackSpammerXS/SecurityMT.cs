using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace BlackSpammerXS
{
	// Token: 0x02000095 RID: 149
	public class SecurityMT
	{
		// Token: 0x0600026E RID: 622 RVA: 0x0002EEE0 File Offset: 0x0002D0E0
		public static bool ensure_clean_cbl()
		{
			bool flag2;
			try
			{
				bool flag = Environment.GetCommandLineArgs().Length <= 1;
				if (flag)
				{
					flag2 = true;
				}
				else
				{
					flag2 = false;
				}
			}
			catch (Exception)
			{
				flag2 = false;
			}
			return flag2;
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0002EF20 File Offset: 0x0002D120
		public static int _c_act_secr(int act_i, uint act_ofs)
		{
			bool flag = act_ofs != 4241256927U;
			int num;
			if (flag)
			{
				num = 0;
			}
			else
			{
				bool flag2 = act_i == 241;
				if (flag2)
				{
					bool flag3 = SecurityMT.h_lg_s.g_curr_state() == 922934 && !SecurityMT.h_lg_s_BL;
					if (flag3)
					{
						SecLG.o_wr("ensure_clean ?? check");
						SecurityMT.ensure_clean_cbl();
						SecLG.o_wr("ensure_clean ? true :: success");
						SecurityMT.h_lg_s.s_c_st(33817);
						SecurityMT.h_lg_s_BL = true;
						Application.Run(new Login(16271636));
					}
					MessageBox.Show("SecError 0x000008f :: Login lnc_state ? NULL", "Avviso", ContentAlignment.MiddleCenter);
					SecLG.o_wr("Invalid application state w_c_sr 0x00e1");
					SecLG.ntf_ex("rexit_ntfex01");
					Application.Exit();
				}
				num = 0;
			}
			return num;
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0002EFEC File Offset: 0x0002D1EC
		public static int reg_sqn(uint cr_f, int oc)
		{
			bool flag = SecurityMT.h_lg_s.g_curr_state() != 57697 || SecurityMT.h_nmn.g_curr_state() == 57684;
			int num;
			if (flag)
			{
				num = 0;
			}
			else
			{
				Random random = new Random();
				bool flag2 = oc == 63713;
				if (flag2)
				{
					SecurityMT.h_sec_r_frm = (int)((ulong)((cr_f << 20) + 63545U) * (ulong)((long)random.Next()));
					num = SecurityMT.h_sec_r_frm;
				}
				else
				{
					num = 0;
				}
			}
			return num;
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0002F060 File Offset: 0x0002D260
		public static string e_er(string t, string p)
		{
			string text4;
			try
			{
				string text = "";
				string text2 = "91418777";
				string text3 = "83562655";
				byte[] array = new byte[0];
				array = Encoding.UTF8.GetBytes(text3);
				byte[] array2 = new byte[0];
				array2 = Encoding.UTF8.GetBytes(text2);
				MemoryStream memoryStream = null;
				CryptoStream cryptoStream = null;
				byte[] bytes = Encoding.UTF8.GetBytes(t);
				using (DESCryptoServiceProvider descryptoServiceProvider = new DESCryptoServiceProvider())
				{
					memoryStream = new MemoryStream();
					cryptoStream = new CryptoStream(memoryStream, descryptoServiceProvider.CreateEncryptor(array2, array), CryptoStreamMode.Write);
					cryptoStream.Write(bytes, 0, bytes.Length);
					cryptoStream.FlushFinalBlock();
					text = Convert.ToBase64String(memoryStream.ToArray());
				}
				try
				{
					memoryStream.Close();
					cryptoStream.Close();
				}
				catch
				{
				}
				memoryStream = null;
				cryptoStream = null;
				text4 = text;
			}
			catch (Exception)
			{
				text4 = "";
			}
			return text4;
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0002F178 File Offset: 0x0002D378
		public static string e_dr(string t, string p)
		{
			string text4;
			try
			{
				string text = "";
				string text2 = "91418777";
				string text3 = "83562655";
				byte[] array = new byte[0];
				array = Encoding.UTF8.GetBytes(text3);
				byte[] array2 = new byte[0];
				array2 = Encoding.UTF8.GetBytes(text2);
				MemoryStream memoryStream = null;
				CryptoStream cryptoStream = null;
				byte[] array3 = new byte[t.Replace(" ", "+").Length];
				array3 = Convert.FromBase64String(t.Replace(" ", "+"));
				using (DESCryptoServiceProvider descryptoServiceProvider = new DESCryptoServiceProvider())
				{
					memoryStream = new MemoryStream();
					cryptoStream = new CryptoStream(memoryStream, descryptoServiceProvider.CreateDecryptor(array2, array), CryptoStreamMode.Write);
					cryptoStream.Write(array3, 0, array3.Length);
					cryptoStream.FlushFinalBlock();
					Encoding utf = Encoding.UTF8;
					text = utf.GetString(memoryStream.ToArray());
				}
				try
				{
					memoryStream.Close();
					cryptoStream.Close();
				}
				catch
				{
				}
				memoryStream = null;
				cryptoStream = null;
				text4 = text;
			}
			catch (Exception)
			{
				text4 = "";
			}
			return text4;
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0002F2E4 File Offset: 0x0002D4E4
		public static int ch_scr(int of_id, int ac_of, int act_oft, int icd, Form frm_t)
		{
			bool flag = frm_t == null || of_id == 0 || act_oft == 0 || ac_of == 0;
			int num;
			if (flag)
			{
				num = 0;
			}
			else
			{
				bool flag2 = frm_t.GetType() == typeof(Login);
				if (flag2)
				{
					bool flag3 = of_id == 2111 && (long)ac_of == 16271636L;
					if (flag3)
					{
						return 291144;
					}
				}
				bool flag4 = frm_t.GetType() == typeof(Form1);
				if (flag4)
				{
					bool flag5 = of_id == SecurityMT.h_sec_r_frm - icd && (long)act_oft == 256447608L && ac_of == frm_t.GetHashCode() / 241 && SecurityMT.h_nmn.g_curr_state() != 57684 && SecurityMT.h_lg_s_BL && SecurityMT.h_lg_s.g_curr_state() == 57697;
					if (flag5)
					{
						SecurityMT.h_nmn.s_c_st(33817);
						num = 287059;
					}
					else
					{
						SecLG.o_wr("Invalid application state frm_MN_c1 0x0e81");
						SecLG.ntf_ex("rexit_ntfex01");
						Application.Exit();
						num = 0;
					}
				}
				else
				{
					num = 0;
				}
			}
			return num;
		}

		// Token: 0x040005B9 RID: 1465
		private static bool h_lg_s_BL = false;

		// Token: 0x040005BA RID: 1466
		private static SECBOOL h_lg_s = new SECBOOL(57697, 922934, 3713);

		// Token: 0x040005BB RID: 1467
		private static int h_sec_r_frm = -57669;

		// Token: 0x040005BC RID: 1468
		private static SECBOOL h_nmn = new SECBOOL(57684, 1013825, 3713);
	}
}
