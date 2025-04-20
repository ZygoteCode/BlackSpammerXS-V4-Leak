using System;
using System.Runtime.CompilerServices;
using BlackSpammerXS.Properties;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json.Linq;

namespace BlackSpammerXS
{
	// Token: 0x02000016 RID: 22
	public class AuditManager
	{
		// Token: 0x06000074 RID: 116 RVA: 0x000087CC File Offset: 0x000069CC
		public AuditManager()
		{
			this.rawLog = JObject.Parse(Settings.Default.audit);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x000087EC File Offset: 0x000069EC
		public JObject GetRawLog()
		{
			return this.rawLog;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00008804 File Offset: 0x00006A04
		public void LogActionJoin(string linkWh)
		{
			object obj = this.rawLog;
			if (AuditManager.<>o__3.<>p__1 == null)
			{
				AuditManager.<>o__3.<>p__1 = CallSite<Func<CallSite, object, JArray>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(JArray), typeof(AuditManager)));
			}
			Func<CallSite, object, JArray> target = AuditManager.<>o__3.<>p__1.Target;
			CallSite <>p__ = AuditManager.<>o__3.<>p__1;
			if (AuditManager.<>o__3.<>p__0 == null)
			{
				AuditManager.<>o__3.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "joins", typeof(AuditManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			JArray jarray = target(<>p__, AuditManager.<>o__3.<>p__0.Target(AuditManager.<>o__3.<>p__0, obj));
			string text = string.Concat(new string[]
			{
				"{\"serverLink\": \"",
				linkWh,
				"\", \"tokensAmount\": \"",
				ImpostazioniGlobali.Tokens.Count.ToString(),
				"\", \"proxiesCount\": \"",
				ImpostazioniGlobali.Proxies.Count.ToString(),
				"\"}"
			});
			jarray.Add(JObject.Parse(text));
			if (AuditManager.<>o__3.<>p__2 == null)
			{
				AuditManager.<>o__3.<>p__2 = CallSite<Func<CallSite, object, JArray, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "joins", typeof(AuditManager), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			AuditManager.<>o__3.<>p__2.Target(AuditManager.<>o__3.<>p__2, obj, jarray);
			if (AuditManager.<>o__3.<>p__3 == null)
			{
				AuditManager.<>o__3.<>p__3 = CallSite<Func<CallSite, object, JObject>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(JObject), typeof(AuditManager)));
			}
			this.rawLog = AuditManager.<>o__3.<>p__3.Target(AuditManager.<>o__3.<>p__3, obj);
			this.Apply();
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000089B8 File Offset: 0x00006BB8
		public void LogActionLeave(string idLev)
		{
			object obj = this.rawLog;
			if (AuditManager.<>o__4.<>p__1 == null)
			{
				AuditManager.<>o__4.<>p__1 = CallSite<Func<CallSite, object, JArray>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(JArray), typeof(AuditManager)));
			}
			Func<CallSite, object, JArray> target = AuditManager.<>o__4.<>p__1.Target;
			CallSite <>p__ = AuditManager.<>o__4.<>p__1;
			if (AuditManager.<>o__4.<>p__0 == null)
			{
				AuditManager.<>o__4.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "leaves", typeof(AuditManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			JArray jarray = target(<>p__, AuditManager.<>o__4.<>p__0.Target(AuditManager.<>o__4.<>p__0, obj));
			string text = string.Concat(new string[]
			{
				"{\"serverId\": \"",
				idLev,
				"\", \"tokensAmount\": \"",
				ImpostazioniGlobali.Tokens.Count.ToString(),
				"\", \"proxiesCount\": \"",
				ImpostazioniGlobali.Proxies.Count.ToString(),
				"\"}"
			});
			jarray.Add(JObject.Parse(text));
			if (AuditManager.<>o__4.<>p__2 == null)
			{
				AuditManager.<>o__4.<>p__2 = CallSite<Func<CallSite, object, JArray, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "leaves", typeof(AuditManager), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			AuditManager.<>o__4.<>p__2.Target(AuditManager.<>o__4.<>p__2, obj, jarray);
			if (AuditManager.<>o__4.<>p__3 == null)
			{
				AuditManager.<>o__4.<>p__3 = CallSite<Func<CallSite, object, JObject>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(JObject), typeof(AuditManager)));
			}
			this.rawLog = AuditManager.<>o__4.<>p__3.Target(AuditManager.<>o__4.<>p__3, obj);
			this.Apply();
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00008B6C File Offset: 0x00006D6C
		public void LogActionSpam(string gid, string message, string mref)
		{
			object obj = this.rawLog;
			if (AuditManager.<>o__5.<>p__1 == null)
			{
				AuditManager.<>o__5.<>p__1 = CallSite<Func<CallSite, object, JArray>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(JArray), typeof(AuditManager)));
			}
			Func<CallSite, object, JArray> target = AuditManager.<>o__5.<>p__1.Target;
			CallSite <>p__ = AuditManager.<>o__5.<>p__1;
			if (AuditManager.<>o__5.<>p__0 == null)
			{
				AuditManager.<>o__5.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "spam", typeof(AuditManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			JArray jarray = target(<>p__, AuditManager.<>o__5.<>p__0.Target(AuditManager.<>o__5.<>p__0, obj));
			string text = string.Concat(new string[]
			{
				"{\"channelId\": \"",
				gid,
				"\", \"tokensAmount\": \"",
				ImpostazioniGlobali.Tokens.Count.ToString(),
				"\", \"proxiesCount\": \"",
				ImpostazioniGlobali.Proxies.Count.ToString(),
				"\", \"message\": \"",
				message,
				"\", \"mref\": \"",
				mref,
				"\"}"
			});
			jarray.Add(JObject.Parse(text));
			if (AuditManager.<>o__5.<>p__2 == null)
			{
				AuditManager.<>o__5.<>p__2 = CallSite<Func<CallSite, object, JArray, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "spam", typeof(AuditManager), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			AuditManager.<>o__5.<>p__2.Target(AuditManager.<>o__5.<>p__2, obj, jarray);
			if (AuditManager.<>o__5.<>p__3 == null)
			{
				AuditManager.<>o__5.<>p__3 = CallSite<Func<CallSite, object, JObject>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(JObject), typeof(AuditManager)));
			}
			this.rawLog = AuditManager.<>o__5.<>p__3.Target(AuditManager.<>o__5.<>p__3, obj);
			this.Apply();
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00008D3C File Offset: 0x00006F3C
		public void LogActionReaction(int type_0, string whem, string chid, string ms)
		{
			object obj = this.rawLog;
			if (AuditManager.<>o__6.<>p__1 == null)
			{
				AuditManager.<>o__6.<>p__1 = CallSite<Func<CallSite, object, JArray>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(JArray), typeof(AuditManager)));
			}
			Func<CallSite, object, JArray> target = AuditManager.<>o__6.<>p__1.Target;
			CallSite <>p__ = AuditManager.<>o__6.<>p__1;
			if (AuditManager.<>o__6.<>p__0 == null)
			{
				AuditManager.<>o__6.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "reaction", typeof(AuditManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			JArray jarray = target(<>p__, AuditManager.<>o__6.<>p__0.Target(AuditManager.<>o__6.<>p__0, obj));
			string text = string.Concat(new string[]
			{
				"{\"channelId\": \"",
				chid,
				"\", \"tokensAmount\": \"",
				ImpostazioniGlobali.Tokens.Count.ToString(),
				"\", \"proxiesCount\": \"",
				ImpostazioniGlobali.Proxies.Count.ToString(),
				"\", \"emoji\": \"",
				whem,
				"\", \"type\":",
				type_0.ToString(),
				", \"message\": \"",
				ms,
				"\"}"
			});
			jarray.Add(JObject.Parse(text));
			if (AuditManager.<>o__6.<>p__2 == null)
			{
				AuditManager.<>o__6.<>p__2 = CallSite<Func<CallSite, object, JArray, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "reaction", typeof(AuditManager), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			AuditManager.<>o__6.<>p__2.Target(AuditManager.<>o__6.<>p__2, obj, jarray);
			if (AuditManager.<>o__6.<>p__3 == null)
			{
				AuditManager.<>o__6.<>p__3 = CallSite<Func<CallSite, object, JObject>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(JObject), typeof(AuditManager)));
			}
			this.rawLog = AuditManager.<>o__6.<>p__3.Target(AuditManager.<>o__6.<>p__3, obj);
			this.Apply();
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00008F20 File Offset: 0x00007120
		public void ClearLog()
		{
			string text = "{\"joins\": [], \"leaves\": [], \"spam\": [], \"reaction\": []}";
			this.SetProp0(text);
			this.rawLog = JObject.Parse(text);
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00008F48 File Offset: 0x00007148
		private void Apply()
		{
			this.SetProp0(this.rawLog.ToString());
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00008F5D File Offset: 0x0000715D
		private void SetProp0(string set)
		{
			Settings.Default.audit = set;
			this.SaveSettings();
			Settings.Default.Reload();
			this.rawLog = JObject.Parse(Settings.Default.audit);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00008F93 File Offset: 0x00007193
		private void SaveSettings()
		{
			Settings.Default.Save();
			Settings.Default.Reload();
		}

		// Token: 0x040000C2 RID: 194
		private JObject rawLog;
	}
}
