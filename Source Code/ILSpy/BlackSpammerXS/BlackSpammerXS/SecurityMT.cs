using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace BlackSpammerXS;

public class SecurityMT
{
	private static bool h_lg_s_BL = false;

	private static SECBOOL h_lg_s = new SECBOOL(57697, 922934, 3713);

	private static int h_sec_r_frm = -57669;

	private static SECBOOL h_nmn = new SECBOOL(57684, 1013825, 3713);

	public static bool ensure_clean_cbl()
	{
		try
		{
			if (Environment.GetCommandLineArgs().Length <= 1)
			{
				return true;
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static int _c_act_secr(int act_i, uint act_ofs)
	{
		if (act_ofs != 4241256927u)
		{
			return 0;
		}
		if (act_i == 241)
		{
			if (h_lg_s.g_curr_state() == 922934 && !h_lg_s_BL)
			{
				SecLG.o_wr("ensure_clean ?? check");
				ensure_clean_cbl();
				SecLG.o_wr("ensure_clean ? true :: success");
				h_lg_s.s_c_st(33817);
				h_lg_s_BL = true;
				Application.Run(new Login(16271636));
			}
			MessageBox.Show("SecError 0x000008f :: Login lnc_state ? NULL");
			SecLG.o_wr("Invalid application state w_c_sr 0x00e1");
			SecLG.ntf_ex();
			Application.Exit();
		}
		return 0;
	}

	public static int reg_sqn(uint cr_f, int oc)
	{
		if (h_lg_s.g_curr_state() != 57697 || h_nmn.g_curr_state() == 57684)
		{
			return 0;
		}
		Random random = new Random();
		if (oc == 63713)
		{
			h_sec_r_frm = (int)(((cr_f << 20) + 63545) * random.Next());
			return h_sec_r_frm;
		}
		return 0;
	}

	public static string e_er(string t, string p)
	{
		try
		{
			string result = "";
			string s = "91418777";
			string s2 = "83562655";
			byte[] array = new byte[0];
			array = Encoding.UTF8.GetBytes(s2);
			byte[] array2 = new byte[0];
			array2 = Encoding.UTF8.GetBytes(s);
			MemoryStream memoryStream = null;
			CryptoStream cryptoStream = null;
			byte[] bytes = Encoding.UTF8.GetBytes(t);
			using (DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider())
			{
				memoryStream = new MemoryStream();
				cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(array2, array), CryptoStreamMode.Write);
				cryptoStream.Write(bytes, 0, bytes.Length);
				cryptoStream.FlushFinalBlock();
				result = Convert.ToBase64String(memoryStream.ToArray());
			}
			s2 = null;
			s = null;
			array = null;
			s = null;
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
			bytes = null;
			return result;
		}
		catch (Exception)
		{
			return "";
		}
	}

	public static string e_dr(string t, string p)
	{
		try
		{
			string result = "";
			string s = "91418777";
			string s2 = "83562655";
			byte[] array = new byte[0];
			array = Encoding.UTF8.GetBytes(s2);
			byte[] array2 = new byte[0];
			array2 = Encoding.UTF8.GetBytes(s);
			MemoryStream memoryStream = null;
			CryptoStream cryptoStream = null;
			byte[] array3 = new byte[t.Replace(" ", "+").Length];
			array3 = Convert.FromBase64String(t.Replace(" ", "+"));
			using (DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider())
			{
				memoryStream = new MemoryStream();
				cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(array2, array), CryptoStreamMode.Write);
				cryptoStream.Write(array3, 0, array3.Length);
				cryptoStream.FlushFinalBlock();
				Encoding uTF = Encoding.UTF8;
				result = uTF.GetString(memoryStream.ToArray());
			}
			s = null;
			s2 = null;
			array = null;
			array2 = null;
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
			array3 = null;
			return result;
		}
		catch (Exception)
		{
			return "";
		}
	}

	public static int ch_scr(int of_id, int ac_of, int act_oft, int icd, Form frm_t)
	{
		if (frm_t == null || of_id == 0 || act_oft == 0 || ac_of == 0)
		{
			return 0;
		}
		if (frm_t.GetType() == typeof(Login) && of_id == 2111 && (long)ac_of == 16271636)
		{
			return 291144;
		}
		if (frm_t.GetType() == typeof(Form1))
		{
			if (of_id == h_sec_r_frm - icd && (long)act_oft == 256447608 && ac_of == frm_t.GetHashCode() / 241 && h_nmn.g_curr_state() != 57684 && h_lg_s_BL && h_lg_s.g_curr_state() == 57697)
			{
				h_nmn.s_c_st(33817);
				return 287059;
			}
			SecLG.o_wr("Invalid application state frm_MN_c1 0x0e81");
			SecLG.ntf_ex();
			Application.Exit();
			return 0;
		}
		return 0;
	}
}
