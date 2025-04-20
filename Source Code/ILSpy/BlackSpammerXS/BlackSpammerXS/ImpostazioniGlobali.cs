using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace BlackSpammerXS;

internal class ImpostazioniGlobali
{
	public static List<string> Proxies;

	public static List<string> Tokens;

	public static Logger LogForm;

	public static AuditManager auditManager;

	public static bool AlwaysOn = false;

	public static bool LoggerDark = false;

	public static bool StreamerMode = false;

	public static bool AllowLogging = true;

	public static bool UseOldParsing = false;

	public static bool DeveloperMode = false;

	public static bool LOG_UseNewFont = true;

	public static bool AutoParse = true;

	public static bool WS_LogBasic = false;

	public static int log_interval_cl = 10000;

	public static string CaptchaKey_SMSACT = "";

	public static string CaptchaKey_TWO = "";

	public static string XCP_Default = "{\"location\":\"Join Guild\",\"location_guild_id\":\"613425648685547541\",\"location_channel_id\":\"613425648685547541\",\"location_channel_type\":0}";

	public static string XCP_GID = "613425648685547541";

	public static List<Action<int, int, object[]>> _bridgeLogPerform = new List<Action<int, int, object[]>>();

	public static Action<int, int, object> _bridgeGS;

	public static Action<int> bridgeAct_;

	public static Action<string> l_;

	public static Action<bool> _themeCallback;

	public static Action<bool> _stmodeCallback;

	public static string base64_encode(string wh)
	{
		try
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(wh));
		}
		catch (Exception)
		{
			return "ERR";
		}
	}

	public static void Debug_DClear()
	{
	}

	public static void Debug_DPut(JObject jobj)
	{
	}

	public static string GetReadableDateNow()
	{
		return DateTime.Now.ToString("d/M/yyyy hh:mm:ss");
	}

	public static JObject CreateDebugAction(int id, string act, string of, string[] notesRaw, string a, string timestamp)
	{
		return null;
	}

	public static void Log(string to)
	{
		if (!AllowLogging || l_ == null)
		{
			return;
		}
		try
		{
			l_(to);
		}
		catch (Exception)
		{
		}
	}

	public static void CallbackBridgeAL(int z, int x, object[] arr)
	{
		try
		{
			foreach (Action<int, int, object[]> item in _bridgeLogPerform)
			{
				item(z, x, arr);
			}
		}
		catch
		{
		}
	}

	public static void DarkMode(bool _)
	{
		try
		{
			_themeCallback(_);
		}
		catch (Exception)
		{
		}
	}

	public static void StartLog()
	{
		if (!AllowLogging)
		{
			return;
		}
		Control.CheckForIllegalCrossThreadCalls = false;
		if (AlwaysOn && LogForm != null)
		{
			try
			{
				l_("Logger => Resuming logger session.");
				return;
			}
			catch (Exception)
			{
				if (LogForm != null)
				{
					try
					{
						LogForm.Close();
					}
					catch (Exception)
					{
					}
				}
				new Thread((ParameterizedThreadStart)delegate
				{
					LogForm = new Logger(LoggerDark, StreamerMode);
					LogForm.ShowDialog();
				}).Start();
				return;
			}
		}
		if (AlwaysOn && LogForm == null)
		{
			new Thread((ParameterizedThreadStart)delegate
			{
				LogForm = new Logger(LoggerDark, StreamerMode);
				LogForm.ShowDialog();
			}).Start();
			return;
		}
		if (LogForm != null)
		{
			try
			{
				LogForm.Close();
			}
			catch (Exception)
			{
			}
		}
		new Thread((ParameterizedThreadStart)delegate
		{
			LogForm = new Logger(LoggerDark, StreamerMode);
			LogForm.ShowDialog();
		}).Start();
	}

	public static Logger GetLogger()
	{
		return LogForm;
	}

	public static void StreamOptNotify()
	{
		try
		{
			_stmodeCallback(StreamerMode);
		}
		catch (Exception)
		{
		}
	}
}
