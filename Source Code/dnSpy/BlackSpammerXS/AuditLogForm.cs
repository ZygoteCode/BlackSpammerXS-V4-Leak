using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using BlackSpammerXS.Properties;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json.Linq;
using Siticone.UI.WinForms;

namespace BlackSpammerXS
{
	// Token: 0x02000012 RID: 18
	public partial class AuditLogForm : Form
	{
		// Token: 0x0600005F RID: 95 RVA: 0x00006F2C File Offset: 0x0000512C
		public AuditLogForm()
		{
			this.InitializeComponent();
			this.siticoneShadowForm1.SetShadowForm(this);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00006F54 File Offset: 0x00005154
		private void AuditLogForm_Load(object sender, EventArgs e)
		{
			bool flag = false;
			bool dark = Settings.Default.dark;
			if (dark)
			{
				Color color = Color.FromArgb(44, 47, 51);
				Color dimGray = Color.DimGray;
				flag = true;
				this.BackColor = color;
				this.label1.ForeColor = Color.White;
			}
			try
			{
				AuditManager auditManager = ImpostazioniGlobali.auditManager;
				object rawLog = auditManager.GetRawLog();
				if (AuditLogForm.<>o__1.<>p__1 == null)
				{
					AuditLogForm.<>o__1.<>p__1 = CallSite<Func<CallSite, object, JArray>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(JArray), typeof(AuditLogForm)));
				}
				Func<CallSite, object, JArray> target = AuditLogForm.<>o__1.<>p__1.Target;
				CallSite <>p__ = AuditLogForm.<>o__1.<>p__1;
				if (AuditLogForm.<>o__1.<>p__0 == null)
				{
					AuditLogForm.<>o__1.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "joins", typeof(AuditLogForm), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				JArray jarray = target(<>p__, AuditLogForm.<>o__1.<>p__0.Target(AuditLogForm.<>o__1.<>p__0, rawLog));
				bool flag2 = jarray.Count != 0;
				if (flag2)
				{
					JObject[] array = jarray.ToObject<JObject[]>();
					foreach (JObject jobject in array)
					{
						object obj = jobject;
						if (AuditLogForm.<>o__1.<>p__3 == null)
						{
							AuditLogForm.<>o__1.<>p__3 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(AuditLogForm)));
						}
						Func<CallSite, object, string> target2 = AuditLogForm.<>o__1.<>p__3.Target;
						CallSite <>p__2 = AuditLogForm.<>o__1.<>p__3;
						if (AuditLogForm.<>o__1.<>p__2 == null)
						{
							AuditLogForm.<>o__1.<>p__2 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "serverLink", typeof(AuditLogForm), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						string text = target2(<>p__2, AuditLogForm.<>o__1.<>p__2.Target(AuditLogForm.<>o__1.<>p__2, obj));
						if (AuditLogForm.<>o__1.<>p__5 == null)
						{
							AuditLogForm.<>o__1.<>p__5 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(AuditLogForm)));
						}
						Func<CallSite, object, string> target3 = AuditLogForm.<>o__1.<>p__5.Target;
						CallSite <>p__3 = AuditLogForm.<>o__1.<>p__5;
						if (AuditLogForm.<>o__1.<>p__4 == null)
						{
							AuditLogForm.<>o__1.<>p__4 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "tokensAmount", typeof(AuditLogForm), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						string text2 = target3(<>p__3, AuditLogForm.<>o__1.<>p__4.Target(AuditLogForm.<>o__1.<>p__4, obj));
						if (AuditLogForm.<>o__1.<>p__7 == null)
						{
							AuditLogForm.<>o__1.<>p__7 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(AuditLogForm)));
						}
						Func<CallSite, object, string> target4 = AuditLogForm.<>o__1.<>p__7.Target;
						CallSite <>p__4 = AuditLogForm.<>o__1.<>p__7;
						if (AuditLogForm.<>o__1.<>p__6 == null)
						{
							AuditLogForm.<>o__1.<>p__6 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "proxiesAmount", typeof(AuditLogForm), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						string text3 = target4(<>p__4, AuditLogForm.<>o__1.<>p__6.Target(AuditLogForm.<>o__1.<>p__6, obj));
						string text4 = "Completato";
						AuditJoin auditJoin = new AuditJoin(text, text2, "valid", text4, flag, this);
						this.logContainer.Controls.Add(auditJoin);
					}
				}
				if (AuditLogForm.<>o__1.<>p__9 == null)
				{
					AuditLogForm.<>o__1.<>p__9 = CallSite<Func<CallSite, object, JArray>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(JArray), typeof(AuditLogForm)));
				}
				Func<CallSite, object, JArray> target5 = AuditLogForm.<>o__1.<>p__9.Target;
				CallSite <>p__5 = AuditLogForm.<>o__1.<>p__9;
				if (AuditLogForm.<>o__1.<>p__8 == null)
				{
					AuditLogForm.<>o__1.<>p__8 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "leaves", typeof(AuditLogForm), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				JArray jarray2 = target5(<>p__5, AuditLogForm.<>o__1.<>p__8.Target(AuditLogForm.<>o__1.<>p__8, rawLog));
				bool flag3 = jarray2.Count != 0;
				if (flag3)
				{
					JObject[] array3 = jarray2.ToObject<JObject[]>();
					foreach (JObject jobject2 in array3)
					{
						object obj2 = jobject2;
						if (AuditLogForm.<>o__1.<>p__11 == null)
						{
							AuditLogForm.<>o__1.<>p__11 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(AuditLogForm)));
						}
						Func<CallSite, object, string> target6 = AuditLogForm.<>o__1.<>p__11.Target;
						CallSite <>p__6 = AuditLogForm.<>o__1.<>p__11;
						if (AuditLogForm.<>o__1.<>p__10 == null)
						{
							AuditLogForm.<>o__1.<>p__10 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "serverId", typeof(AuditLogForm), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						string text5 = target6(<>p__6, AuditLogForm.<>o__1.<>p__10.Target(AuditLogForm.<>o__1.<>p__10, obj2));
						if (AuditLogForm.<>o__1.<>p__13 == null)
						{
							AuditLogForm.<>o__1.<>p__13 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(AuditLogForm)));
						}
						Func<CallSite, object, string> target7 = AuditLogForm.<>o__1.<>p__13.Target;
						CallSite <>p__7 = AuditLogForm.<>o__1.<>p__13;
						if (AuditLogForm.<>o__1.<>p__12 == null)
						{
							AuditLogForm.<>o__1.<>p__12 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "tokensAmount", typeof(AuditLogForm), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						string text6 = target7(<>p__7, AuditLogForm.<>o__1.<>p__12.Target(AuditLogForm.<>o__1.<>p__12, obj2));
						if (AuditLogForm.<>o__1.<>p__15 == null)
						{
							AuditLogForm.<>o__1.<>p__15 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(AuditLogForm)));
						}
						Func<CallSite, object, string> target8 = AuditLogForm.<>o__1.<>p__15.Target;
						CallSite <>p__8 = AuditLogForm.<>o__1.<>p__15;
						if (AuditLogForm.<>o__1.<>p__14 == null)
						{
							AuditLogForm.<>o__1.<>p__14 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "proxiesAmount", typeof(AuditLogForm), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						string text7 = target8(<>p__8, AuditLogForm.<>o__1.<>p__14.Target(AuditLogForm.<>o__1.<>p__14, obj2));
						string text8 = "Completato";
						AuditLeave auditLeave = new AuditLeave(text5, text6, "valid", text8, flag, this);
						this.logContainer.Controls.Add(auditLeave);
					}
				}
				if (AuditLogForm.<>o__1.<>p__17 == null)
				{
					AuditLogForm.<>o__1.<>p__17 = CallSite<Func<CallSite, object, JArray>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(JArray), typeof(AuditLogForm)));
				}
				Func<CallSite, object, JArray> target9 = AuditLogForm.<>o__1.<>p__17.Target;
				CallSite <>p__9 = AuditLogForm.<>o__1.<>p__17;
				if (AuditLogForm.<>o__1.<>p__16 == null)
				{
					AuditLogForm.<>o__1.<>p__16 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "spam", typeof(AuditLogForm), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				JArray jarray3 = target9(<>p__9, AuditLogForm.<>o__1.<>p__16.Target(AuditLogForm.<>o__1.<>p__16, rawLog));
				bool flag4 = jarray3.Count != 0;
				if (flag4)
				{
					JObject[] array5 = jarray3.ToObject<JObject[]>();
					foreach (JObject jobject3 in array5)
					{
						object obj3 = jobject3;
						if (AuditLogForm.<>o__1.<>p__19 == null)
						{
							AuditLogForm.<>o__1.<>p__19 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(AuditLogForm)));
						}
						Func<CallSite, object, string> target10 = AuditLogForm.<>o__1.<>p__19.Target;
						CallSite <>p__10 = AuditLogForm.<>o__1.<>p__19;
						if (AuditLogForm.<>o__1.<>p__18 == null)
						{
							AuditLogForm.<>o__1.<>p__18 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "channelId", typeof(AuditLogForm), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						string text9 = target10(<>p__10, AuditLogForm.<>o__1.<>p__18.Target(AuditLogForm.<>o__1.<>p__18, obj3));
						if (AuditLogForm.<>o__1.<>p__21 == null)
						{
							AuditLogForm.<>o__1.<>p__21 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(AuditLogForm)));
						}
						Func<CallSite, object, string> target11 = AuditLogForm.<>o__1.<>p__21.Target;
						CallSite <>p__11 = AuditLogForm.<>o__1.<>p__21;
						if (AuditLogForm.<>o__1.<>p__20 == null)
						{
							AuditLogForm.<>o__1.<>p__20 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "tokensAmount", typeof(AuditLogForm), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						string text10 = target11(<>p__11, AuditLogForm.<>o__1.<>p__20.Target(AuditLogForm.<>o__1.<>p__20, obj3));
						if (AuditLogForm.<>o__1.<>p__23 == null)
						{
							AuditLogForm.<>o__1.<>p__23 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(AuditLogForm)));
						}
						Func<CallSite, object, string> target12 = AuditLogForm.<>o__1.<>p__23.Target;
						CallSite <>p__12 = AuditLogForm.<>o__1.<>p__23;
						if (AuditLogForm.<>o__1.<>p__22 == null)
						{
							AuditLogForm.<>o__1.<>p__22 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "proxiesAmount", typeof(AuditLogForm), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						string text11 = target12(<>p__12, AuditLogForm.<>o__1.<>p__22.Target(AuditLogForm.<>o__1.<>p__22, obj3));
						string text12 = "Completato";
						if (AuditLogForm.<>o__1.<>p__25 == null)
						{
							AuditLogForm.<>o__1.<>p__25 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(AuditLogForm)));
						}
						Func<CallSite, object, string> target13 = AuditLogForm.<>o__1.<>p__25.Target;
						CallSite <>p__13 = AuditLogForm.<>o__1.<>p__25;
						if (AuditLogForm.<>o__1.<>p__24 == null)
						{
							AuditLogForm.<>o__1.<>p__24 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "message", typeof(AuditLogForm), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						string text13 = target13(<>p__13, AuditLogForm.<>o__1.<>p__24.Target(AuditLogForm.<>o__1.<>p__24, obj3));
						if (AuditLogForm.<>o__1.<>p__27 == null)
						{
							AuditLogForm.<>o__1.<>p__27 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(AuditLogForm)));
						}
						Func<CallSite, object, string> target14 = AuditLogForm.<>o__1.<>p__27.Target;
						CallSite <>p__14 = AuditLogForm.<>o__1.<>p__27;
						if (AuditLogForm.<>o__1.<>p__26 == null)
						{
							AuditLogForm.<>o__1.<>p__26 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "mref", typeof(AuditLogForm), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						string text14 = target14(<>p__14, AuditLogForm.<>o__1.<>p__26.Target(AuditLogForm.<>o__1.<>p__26, obj3));
						AuditSpam auditSpam = new AuditSpam(text9, text10, "valid", text12, text13, text14, flag, this);
						this.logContainer.Controls.Add(auditSpam);
					}
				}
				if (AuditLogForm.<>o__1.<>p__29 == null)
				{
					AuditLogForm.<>o__1.<>p__29 = CallSite<Func<CallSite, object, JArray>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(JArray), typeof(AuditLogForm)));
				}
				Func<CallSite, object, JArray> target15 = AuditLogForm.<>o__1.<>p__29.Target;
				CallSite <>p__15 = AuditLogForm.<>o__1.<>p__29;
				if (AuditLogForm.<>o__1.<>p__28 == null)
				{
					AuditLogForm.<>o__1.<>p__28 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "reaction", typeof(AuditLogForm), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				JArray jarray4 = target15(<>p__15, AuditLogForm.<>o__1.<>p__28.Target(AuditLogForm.<>o__1.<>p__28, rawLog));
				bool flag5 = jarray4.Count != 0;
				if (flag5)
				{
					JObject[] array7 = jarray4.ToObject<JObject[]>();
					foreach (JObject jobject4 in array7)
					{
						object obj4 = jobject4;
						if (AuditLogForm.<>o__1.<>p__31 == null)
						{
							AuditLogForm.<>o__1.<>p__31 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(AuditLogForm)));
						}
						Func<CallSite, object, string> target16 = AuditLogForm.<>o__1.<>p__31.Target;
						CallSite <>p__16 = AuditLogForm.<>o__1.<>p__31;
						if (AuditLogForm.<>o__1.<>p__30 == null)
						{
							AuditLogForm.<>o__1.<>p__30 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "channelId", typeof(AuditLogForm), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						string text15 = target16(<>p__16, AuditLogForm.<>o__1.<>p__30.Target(AuditLogForm.<>o__1.<>p__30, obj4));
						if (AuditLogForm.<>o__1.<>p__33 == null)
						{
							AuditLogForm.<>o__1.<>p__33 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(AuditLogForm)));
						}
						Func<CallSite, object, string> target17 = AuditLogForm.<>o__1.<>p__33.Target;
						CallSite <>p__17 = AuditLogForm.<>o__1.<>p__33;
						if (AuditLogForm.<>o__1.<>p__32 == null)
						{
							AuditLogForm.<>o__1.<>p__32 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "tokensAmount", typeof(AuditLogForm), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						string text16 = target17(<>p__17, AuditLogForm.<>o__1.<>p__32.Target(AuditLogForm.<>o__1.<>p__32, obj4));
						if (AuditLogForm.<>o__1.<>p__35 == null)
						{
							AuditLogForm.<>o__1.<>p__35 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(AuditLogForm)));
						}
						Func<CallSite, object, string> target18 = AuditLogForm.<>o__1.<>p__35.Target;
						CallSite <>p__18 = AuditLogForm.<>o__1.<>p__35;
						if (AuditLogForm.<>o__1.<>p__34 == null)
						{
							AuditLogForm.<>o__1.<>p__34 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "proxiesAmount", typeof(AuditLogForm), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						string text17 = target18(<>p__18, AuditLogForm.<>o__1.<>p__34.Target(AuditLogForm.<>o__1.<>p__34, obj4));
						if (AuditLogForm.<>o__1.<>p__37 == null)
						{
							AuditLogForm.<>o__1.<>p__37 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(AuditLogForm)));
						}
						Func<CallSite, object, string> target19 = AuditLogForm.<>o__1.<>p__37.Target;
						CallSite <>p__19 = AuditLogForm.<>o__1.<>p__37;
						if (AuditLogForm.<>o__1.<>p__36 == null)
						{
							AuditLogForm.<>o__1.<>p__36 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "emoji", typeof(AuditLogForm), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						string text18 = target19(<>p__19, AuditLogForm.<>o__1.<>p__36.Target(AuditLogForm.<>o__1.<>p__36, obj4));
						if (AuditLogForm.<>o__1.<>p__39 == null)
						{
							AuditLogForm.<>o__1.<>p__39 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(int), typeof(AuditLogForm)));
						}
						Func<CallSite, object, int> target20 = AuditLogForm.<>o__1.<>p__39.Target;
						CallSite <>p__20 = AuditLogForm.<>o__1.<>p__39;
						if (AuditLogForm.<>o__1.<>p__38 == null)
						{
							AuditLogForm.<>o__1.<>p__38 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "type", typeof(AuditLogForm), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						int num = target20(<>p__20, AuditLogForm.<>o__1.<>p__38.Target(AuditLogForm.<>o__1.<>p__38, obj4));
						if (AuditLogForm.<>o__1.<>p__41 == null)
						{
							AuditLogForm.<>o__1.<>p__41 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(AuditLogForm)));
						}
						Func<CallSite, object, string> target21 = AuditLogForm.<>o__1.<>p__41.Target;
						CallSite <>p__21 = AuditLogForm.<>o__1.<>p__41;
						if (AuditLogForm.<>o__1.<>p__40 == null)
						{
							AuditLogForm.<>o__1.<>p__40 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "message", typeof(AuditLogForm), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						string text19 = target21(<>p__21, AuditLogForm.<>o__1.<>p__40.Target(AuditLogForm.<>o__1.<>p__40, obj4));
						AuditReact auditReact = new AuditReact(text15, text16, "valid", num, text18, flag, this, text19);
						this.logContainer.Controls.Add(auditReact);
					}
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Ops! Qualcosa è andato storto. Riprova.", "Avviso", ContentAlignment.MiddleCenter);
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00007DAC File Offset: 0x00005FAC
		private async void siticoneButton6_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00007DF3 File Offset: 0x00005FF3
		private void siticoneControlBox1_Click(object sender, EventArgs e)
		{
			ImpostazioniGlobali.bridgeAct_(0);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00002067 File Offset: 0x00000267
		private void logContainer_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00002067 File Offset: 0x00000267
		private void siticoneVScrollBar1_Scroll(object sender, ScrollEventArgs e)
		{
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00007E04 File Offset: 0x00006004
		private async void siticoneGradientButton3_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00007E4C File Offset: 0x0000604C
		private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				AuditManager auditManager = ImpostazioniGlobali.auditManager;
				auditManager.ClearLog();
				this.logContainer.Controls.Clear();
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00007E94 File Offset: 0x00006094
		private void rawJSONLogToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpacityFull opacityFull = new OpacityFull();
			opacityFull.Show();
			GTextRes gtextRes = new GTextRes(Settings.Default.audit, opacityFull, Settings.Default.dark);
			gtextRes.Show();
			gtextRes.Focus();
			base.Close();
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00002067 File Offset: 0x00000267
		private void logContainer_Scroll(object sender, ScrollEventArgs e)
		{
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00002067 File Offset: 0x00000267
		private void logContainer_Paint_1(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00002067 File Offset: 0x00000267
		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00007EDF File Offset: 0x000060DF
		private void siticoneImageButton1_Click(object sender, EventArgs e)
		{
			this.siticoneControlBox1_Click(sender, e);
			base.Close();
		}
	}
}
