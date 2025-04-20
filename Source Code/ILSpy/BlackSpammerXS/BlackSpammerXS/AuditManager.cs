using BlackSpammerXS.Properties;
using Newtonsoft.Json.Linq;

namespace BlackSpammerXS;

public class AuditManager
{
	private JObject rawLog;

	public AuditManager()
	{
		rawLog = JObject.Parse(Settings.Default.audit);
	}

	public JObject GetRawLog()
	{
		return rawLog;
	}

	public void LogActionJoin(string linkWh)
	{
		dynamic val = rawLog;
		JArray val2 = (JArray)val.joins;
		string text = "{\"serverLink\": \"" + linkWh + "\", \"tokensAmount\": \"" + ImpostazioniGlobali.Tokens.Count + "\", \"proxiesCount\": \"" + ImpostazioniGlobali.Proxies.Count + "\"}";
		val2.Add((JToken)(object)JObject.Parse(text));
		val.joins = val2;
		rawLog = (JObject)val;
		Apply();
	}

	public void LogActionLeave(string idLev)
	{
		dynamic val = rawLog;
		JArray val2 = (JArray)val.leaves;
		string text = "{\"serverId\": \"" + idLev + "\", \"tokensAmount\": \"" + ImpostazioniGlobali.Tokens.Count + "\", \"proxiesCount\": \"" + ImpostazioniGlobali.Proxies.Count + "\"}";
		val2.Add((JToken)(object)JObject.Parse(text));
		val.leaves = val2;
		rawLog = (JObject)val;
		Apply();
	}

	public void LogActionSpam(string gid, string message, string mref)
	{
		dynamic val = rawLog;
		JArray val2 = (JArray)val.spam;
		string text = "{\"channelId\": \"" + gid + "\", \"tokensAmount\": \"" + ImpostazioniGlobali.Tokens.Count + "\", \"proxiesCount\": \"" + ImpostazioniGlobali.Proxies.Count + "\", \"message\": \"" + message + "\", \"mref\": \"" + mref + "\"}";
		val2.Add((JToken)(object)JObject.Parse(text));
		val.spam = val2;
		rawLog = (JObject)val;
		Apply();
	}

	public void LogActionReaction(int type_0, string whem, string chid, string ms)
	{
		dynamic val = rawLog;
		JArray val2 = (JArray)val.reaction;
		string text = "{\"channelId\": \"" + chid + "\", \"tokensAmount\": \"" + ImpostazioniGlobali.Tokens.Count + "\", \"proxiesCount\": \"" + ImpostazioniGlobali.Proxies.Count + "\", \"emoji\": \"" + whem + "\", \"type\":" + type_0 + ", \"message\": \"" + ms + "\"}";
		val2.Add((JToken)(object)JObject.Parse(text));
		val.reaction = val2;
		rawLog = (JObject)val;
		Apply();
	}

	public void ClearLog()
	{
		string text = "{\"joins\": [], \"leaves\": [], \"spam\": [], \"reaction\": []}";
		SetProp0(text);
		rawLog = JObject.Parse(text);
	}

	private void Apply()
	{
		SetProp0(((object)rawLog).ToString());
	}

	private void SetProp0(string set)
	{
		Settings.Default.audit = set;
		SaveSettings();
		Settings.Default.Reload();
		rawLog = JObject.Parse(Settings.Default.audit);
	}

	private void SaveSettings()
	{
		Settings.Default.Save();
		Settings.Default.Reload();
	}
}
