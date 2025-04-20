using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace BlackSpammerXS
{
	// Token: 0x02000077 RID: 119
	internal class ImpostazioniGlobali
	{
		// Token: 0x060001DF RID: 479 RVA: 0x00023D48 File Offset: 0x00021F48
		public static string base64_encode(string wh)
		{
			string text;
			try
			{
				text = Convert.ToBase64String(Encoding.UTF8.GetBytes(wh));
			}
			catch (Exception)
			{
				text = "ERR";
			}
			return text;
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00002067 File Offset: 0x00000267
		public static void Debug_DClear()
		{
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x00002067 File Offset: 0x00000267
		public static void Debug_DPut(JObject jobj)
		{
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00023D88 File Offset: 0x00021F88
		public static string GetReadableDateNow()
		{
			return DateTime.Now.ToString("d/M/yyyy hh:mm:ss");
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00023DAC File Offset: 0x00021FAC
		public static JObject CreateDebugAction(int id, string act, string of, string[] notesRaw, string a, string timestamp)
		{
			return null;
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00023DC0 File Offset: 0x00021FC0
		public static void Log(string to)
		{
			bool flag = !ImpostazioniGlobali.AllowLogging;
			if (!flag)
			{
				bool flag2 = ImpostazioniGlobali.l_ != null;
				if (flag2)
				{
					try
					{
						ImpostazioniGlobali.l_(to);
					}
					catch (Exception)
					{
					}
				}
			}
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00023E10 File Offset: 0x00022010
		public static void CallbackBridgeAL(int z, int x, object[] arr)
		{
			try
			{
				foreach (Action<int, int, object[]> action in ImpostazioniGlobali._bridgeLogPerform)
				{
					action(z, x, arr);
				}
			}
			catch
			{
			}
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00023E80 File Offset: 0x00022080
		public static void DarkMode(bool _)
		{
			try
			{
				ImpostazioniGlobali._themeCallback(_);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00023EB4 File Offset: 0x000220B4
		public static void StartLog()
		{
			bool flag = !ImpostazioniGlobali.AllowLogging;
			if (!flag)
			{
				Control.CheckForIllegalCrossThreadCalls = false;
				bool flag2 = ImpostazioniGlobali.AlwaysOn && ImpostazioniGlobali.LogForm != null;
				if (flag2)
				{
					try
					{
						ImpostazioniGlobali.l_("Logger => Resuming logger session.");
					}
					catch (Exception)
					{
						bool flag3 = ImpostazioniGlobali.LogForm != null;
						if (flag3)
						{
							try
							{
								ImpostazioniGlobali.LogForm.Close();
							}
							catch (Exception)
							{
							}
						}
						new Thread(delegate(object p)
						{
							ImpostazioniGlobali.LogForm = new Logger(ImpostazioniGlobali.LoggerDark, ImpostazioniGlobali.StreamerMode);
							ImpostazioniGlobali.LogForm.ShowDialog();
						}).Start();
					}
				}
				else
				{
					bool flag4 = ImpostazioniGlobali.AlwaysOn && ImpostazioniGlobali.LogForm == null;
					if (flag4)
					{
						new Thread(delegate(object p)
						{
							ImpostazioniGlobali.LogForm = new Logger(ImpostazioniGlobali.LoggerDark, ImpostazioniGlobali.StreamerMode);
							ImpostazioniGlobali.LogForm.ShowDialog();
						}).Start();
					}
					else
					{
						bool flag5 = ImpostazioniGlobali.LogForm != null;
						if (flag5)
						{
							try
							{
								ImpostazioniGlobali.LogForm.Close();
							}
							catch (Exception)
							{
							}
						}
						new Thread(delegate(object p)
						{
							ImpostazioniGlobali.LogForm = new Logger(ImpostazioniGlobali.LoggerDark, ImpostazioniGlobali.StreamerMode);
							ImpostazioniGlobali.LogForm.ShowDialog();
						}).Start();
					}
				}
			}
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00024014 File Offset: 0x00022214
		public static Logger GetLogger()
		{
			return ImpostazioniGlobali.LogForm;
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x0002402C File Offset: 0x0002222C
		public static void StreamOptNotify()
		{
			try
			{
				ImpostazioniGlobali._stmodeCallback(ImpostazioniGlobali.StreamerMode);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x04000445 RID: 1093
		public static List<string> Proxies;

		// Token: 0x04000446 RID: 1094
		public static List<string> Tokens;

		// Token: 0x04000447 RID: 1095
		public static Logger LogForm;

		// Token: 0x04000448 RID: 1096
		public static AuditManager auditManager;

		// Token: 0x04000449 RID: 1097
		public static bool AlwaysOn = false;

		// Token: 0x0400044A RID: 1098
		public static bool LoggerDark = false;

		// Token: 0x0400044B RID: 1099
		public static bool StreamerMode = false;

		// Token: 0x0400044C RID: 1100
		public static bool AllowLogging = true;

		// Token: 0x0400044D RID: 1101
		public static bool UseOldParsing = false;

		// Token: 0x0400044E RID: 1102
		public static bool DeveloperMode = false;

		// Token: 0x0400044F RID: 1103
		public static bool LOG_UseNewFont = true;

		// Token: 0x04000450 RID: 1104
		public static bool AutoParse = true;

		// Token: 0x04000451 RID: 1105
		public static bool WS_LogBasic = false;

		// Token: 0x04000452 RID: 1106
		public static int log_interval_cl = 10000;

		// Token: 0x04000453 RID: 1107
		public static string CaptchaKey_SMSACT = "";

		// Token: 0x04000454 RID: 1108
		public static string CaptchaKey_TWO = "";

		// Token: 0x04000455 RID: 1109
		public static string XCP_Default = "{\"location\":\"Join Guild\",\"location_guild_id\":\"613425648685547541\",\"location_channel_id\":\"613425648685547541\",\"location_channel_type\":0}";

		// Token: 0x04000456 RID: 1110
		public static string XCP_GID = "613425648685547541";

		// Token: 0x04000457 RID: 1111
		public static List<Action<int, int, object[]>> _bridgeLogPerform = new List<Action<int, int, object[]>>();

		// Token: 0x04000458 RID: 1112
		public static Action<int, int, object> _bridgeGS;

		// Token: 0x04000459 RID: 1113
		public static Action<int> bridgeAct_;

		// Token: 0x0400045A RID: 1114
		public static Action<string> l_;

		// Token: 0x0400045B RID: 1115
		public static Action<bool> _themeCallback;

		// Token: 0x0400045C RID: 1116
		public static Action<bool> _stmodeCallback;
	}
}
