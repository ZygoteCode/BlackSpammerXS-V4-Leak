using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json.Linq;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Suite;
using WindowsInput;

namespace BlackSpammerXS
{
	// Token: 0x02000088 RID: 136
	public class ReactionSpammer : UserControl
	{
		// Token: 0x0600023C RID: 572 RVA: 0x00029500 File Offset: 0x00027700
		public ReactionSpammer()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600023D RID: 573 RVA: 0x0002951F File Offset: 0x0002771F
		private void hasLive_Click(object sender, EventArgs e)
		{
			this.hasEmbed.Checked = false;
		}

		// Token: 0x0600023E RID: 574 RVA: 0x0002952F File Offset: 0x0002772F
		private void hasEmbed_Click(object sender, EventArgs e)
		{
			this.hasLive.Checked = false;
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00029540 File Offset: 0x00027740
		private async void startBtn_Click(object sender, EventArgs e)
		{
			bool flag = this.channelId.Text == "" || this.emot.Text == "" || this.messageId.Text == "";
			if (flag)
			{
				MessageBox.Show("Please fill every requested parameter", "Avviso", ContentAlignment.MiddleCenter);
			}
			else
			{
				this.startBtn.Text = "Reacting..";
				this.startBtn.Enabled = false;
				bool flag2 = ImpostazioniGlobali.Tokens == null || ImpostazioniGlobali.Proxies == null;
				if (flag2)
				{
					await Task.Delay(50);
					this.startBtn.Text = "Spam Reactions";
					this.startBtn.Enabled = true;
					MessageBox.Show("There are no such tokens or proxies", "Avviso", ContentAlignment.MiddleCenter);
				}
				else
				{
					ImpostazioniGlobali.StartLog();
					try
					{
						string ddt = ImpostazioniGlobali.GetReadableDateNow();
						JObject devDebug = ImpostazioniGlobali.CreateDebugAction(19, "REACT+_SPM", "REACTION_SPAMMER_REACT_SF", new string[]
						{
							"BUTTON_SPAM_REACTIONS",
							"T_" + ImpostazioniGlobali.Tokens.Count.ToString() + "_P_" + ImpostazioniGlobali.Proxies.Count.ToString()
						}, "RSPM_SGL_OF_CEM_" + this.hasDelay.Checked.ToString(), ddt);
						ImpostazioniGlobali.Debug_DPut(devDebug);
						ddt = null;
						devDebug = null;
					}
					catch (Exception)
					{
					}
					Random random = new Random();
					List<string> proxies = ImpostazioniGlobali.Proxies;
					string guildInvite = this.channelId.Text.Replace("https", "").Replace("/", "").Replace(":", "")
						.Replace("discordapp.com", "")
						.Replace(" ", "")
						.Replace("discord.gg", "")
						.Replace("discord.com", "")
						.Replace("invite", "")
						.Replace(" ", "")
						.Replace(".", "");
					ImpostazioniGlobali.Log(string.Concat(new string[]
					{
						"Manager -> (Operation Starting) Reaction Spammer => Spamming reactions in ",
						this.channelId.Text,
						" with ",
						proxies.Count.ToString(),
						" proxies and ",
						ImpostazioniGlobali.Tokens.Count.ToString(),
						" tokens.. Delay has been set to ",
						this.sliderDelay.Value.ToString()
					}));
					bool hasDel = this.hasDelay.Checked;
					if (this.sliderDelay.Value == 0)
					{
						hasDel = false;
						this.hasDelay.Checked = false;
					}
					try
					{
						int type = 0;
						if (!this.hasLive.Checked)
						{
							type = 1;
						}
						AuditManager auditManager = ImpostazioniGlobali.auditManager;
						auditManager.LogActionReaction(type, this.emot.Text, this.channelId.Text, this.messageId.Text);
						auditManager = null;
					}
					catch (Exception)
					{
					}
					new Thread(delegate(object p)
					{
						using (List<string>.Enumerator enumerator = ImpostazioniGlobali.Tokens.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								string token = enumerator.Current;
								new Thread(async delegate(object j)
								{
									bool hasDel2 = hasDel;
									if (hasDel2)
									{
										ImpostazioniGlobali.Log(string.Concat(new string[]
										{
											"Manager -> (Delay) (",
											token,
											") Reaction Spammer => Awaiting ",
											this.sliderDelay.Value.ToString(),
											"ms of delay before reacting."
										}));
										Thread.Sleep(this.sliderDelay.Value);
									}
									string proxy;
									try
									{
										proxy = proxies[random.Next(proxies.Count)];
									}
									catch (Exception)
									{
										proxy = "Error";
									}
									try
									{
										HttpClientHandler handler = new HttpClientHandler();
										handler.PreAuthenticate = true;
										handler.UseProxy = true;
										handler.Proxy = new WebProxy(proxy.Split(new char[] { ':' })[0], int.Parse(proxy.Split(new char[] { ':' })[1]));
										HttpClient http = new HttpClient(handler);
										bool flag3 = !this.hasLive.Checked;
										if (flag3)
										{
											HttpRequestMessage request = new HttpRequestMessage
											{
												Content = null,
												RequestUri = new Uri(string.Concat(new string[]
												{
													"https://discord.com/api/v9/channels/",
													this.channelId.Text,
													"/messages/",
													this.messageId.Text,
													"/reactions/",
													this.emot.Text,
													"/@me"
												})),
												Method = HttpMethod.Put,
												Headers = 
												{
													{ "Authorization", token },
													{ "Accept-Language", "it" },
													{ "User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36" },
													{ "X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9" },
													{ "Accept", "*/*" },
													{ "Cookie", "locale=it" },
													{ "Connection", "keep-alive" },
													{ "Host", "discord.com" },
													{ "Origin", "https://discord.com" },
													{
														"Referer",
														"https://discord.com/channels/" + this.channelId.Text
													},
													{
														HttpRequestHeader.ContentLength.ToString(),
														"0"
													}
												}
											};
											HttpResponseMessage httpResponseMessage = await http.SendAsync(request);
											string text = await httpResponseMessage.Content.ReadAsStringAsync();
											httpResponseMessage = null;
											string _ = text;
											text = null;
											if (_ == "")
											{
												_ = "Successfully Reacted";
											}
											if (ImpostazioniGlobali.StreamerMode)
											{
												ImpostazioniGlobali.Log(string.Concat(new string[]
												{
													proxy,
													" -> (Token ",
													ImpostazioniGlobali.Tokens.IndexOf(token).ToString(),
													") Reaction => ",
													_
												}));
											}
											else
											{
												ImpostazioniGlobali.Log(string.Concat(new string[] { proxy, " -> (", token, ") Reaction => ", _ }));
											}
											request = null;
											_ = null;
										}
										else
										{
											HttpRequestMessage request2 = new HttpRequestMessage
											{
												RequestUri = new Uri(string.Concat(new string[]
												{
													"https://discord.com/api/v9/channels/",
													this.channelId.Text,
													"/messages/",
													this.messageId.Text,
													"/reactions/",
													Uri.EscapeDataString(this.emot.Text),
													"/@me"
												})),
												Method = HttpMethod.Put,
												Headers = 
												{
													{ "Authorization", token },
													{ "Accept-Language", "it" },
													{ "User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36" },
													{ "X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9" },
													{ "Accept", "*/*" },
													{ "Cookie", "locale=it" },
													{
														"Referer",
														"https://discord.com/channels/" + this.channelId.Text
													},
													{ "Connection", "keep-alive" },
													{ "Host", "discord.com" },
													{ "Origin", "https://discord.com" },
													{
														HttpRequestHeader.ContentLength.ToString(),
														"0"
													}
												}
											};
											HttpResponseMessage httpResponseMessage2 = await http.SendAsync(request2);
											string text2 = await httpResponseMessage2.Content.ReadAsStringAsync();
											httpResponseMessage2 = null;
											string _2 = text2;
											text2 = null;
											if (_2 == "")
											{
												_2 = "Successfully Reacted";
											}
											if (ImpostazioniGlobali.StreamerMode)
											{
												ImpostazioniGlobali.Log(string.Concat(new string[]
												{
													proxy,
													" -> (Token ",
													ImpostazioniGlobali.Tokens.IndexOf(token).ToString(),
													") Reaction => ",
													_2
												}));
											}
											else
											{
												ImpostazioniGlobali.Log(string.Concat(new string[] { proxy, " -> (", token, ") Reaction => ", _2 }));
											}
											request2 = null;
											_2 = null;
										}
										handler = null;
										http = null;
									}
									catch (Exception)
									{
										if (ImpostazioniGlobali.StreamerMode)
										{
											ImpostazioniGlobali.Log(proxy + " -> (Token " + ImpostazioniGlobali.Tokens.IndexOf(token).ToString() + ") Reaction => Unknown Error [Check your proxies]");
										}
										else
										{
											ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Reaction => Unknown Error [Check your proxies]");
										}
									}
									try
									{
										Thread.CurrentThread.Abort();
									}
									catch
									{
									}
								}).Start();
							}
						}
					}).Start();
					await Task.Delay(50);
					this.startBtn.Text = "Spam Reactions";
					this.startBtn.Enabled = true;
				}
			}
		}

		// Token: 0x06000240 RID: 576 RVA: 0x00029588 File Offset: 0x00027788
		private void sliderDelay_Scroll(object sender, EventArgs e)
		{
			this.del.Text = "Delay: " + this.sliderDelay.Value.ToString() + "ms";
		}

		// Token: 0x06000241 RID: 577 RVA: 0x000295C4 File Offset: 0x000277C4
		private void startBtn_MouseEnter(object sender, EventArgs e)
		{
			this.startBtn.BorderThickness = 1;
		}

		// Token: 0x06000242 RID: 578 RVA: 0x000295C4 File Offset: 0x000277C4
		private void startBtn_MouseLeave(object sender, EventArgs e)
		{
			this.startBtn.BorderThickness = 1;
		}

		// Token: 0x06000243 RID: 579 RVA: 0x000295D4 File Offset: 0x000277D4
		public void Dark()
		{
			Color color = Color.FromArgb(44, 47, 51);
			this.BackColor = color;
			Color dimGray = Color.DimGray;
			try
			{
				List<SiticoneButton> list = new List<SiticoneButton> { this.startBtn, this.siticoneButton1 };
				foreach (SiticoneButton siticoneButton in list)
				{
					try
					{
						siticoneButton.ForeColor = Color.White;
						siticoneButton.FillColor = dimGray;
						siticoneButton.BorderColor = Color.Gray;
					}
					catch (Exception)
					{
					}
				}
				this.channelId.ForeColor = Color.White;
				this.channelId.FillColor = color;
				this.channelId.BorderColor = Color.Gray;
				this.channelId.HoveredState.BorderColor = Color.Gray;
				this.messageId.ForeColor = Color.White;
				this.messageId.FillColor = color;
				this.messageId.BorderColor = Color.Gray;
				this.messageId.HoveredState.BorderColor = Color.Gray;
				this.emot.ForeColor = Color.White;
				this.emot.FillColor = color;
				this.emot.BorderColor = Color.Gray;
				this.emot.HoveredState.BorderColor = Color.Gray;
				this.sliderDelay.FillColor = Color.Gray;
				this.sliderDelay.ThumbColor = Color.RoyalBlue;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000244 RID: 580 RVA: 0x000297C0 File Offset: 0x000279C0
		private void ReactionSpammer_Load(object sender, EventArgs e)
		{
			ImpostazioniGlobali._bridgeLogPerform.Add(delegate(int a, int b, object[] i)
			{
				bool flag = a == 2;
				if (flag)
				{
					try
					{
						this.channelId.Text = (string)i[0];
						this.emot.Text = (string)i[1];
						int num = (int)i[2];
						bool flag2 = num == 0;
						if (flag2)
						{
							this.hasLive.Checked = true;
							this.hasEmbed.Checked = false;
						}
						bool flag3 = num == 1;
						if (flag3)
						{
							this.hasEmbed.Checked = true;
							this.hasLive.Checked = false;
						}
						this.messageId.Text = (string)i[3];
					}
					catch (Exception)
					{
					}
				}
			});
		}

		// Token: 0x06000245 RID: 581 RVA: 0x000297DA File Offset: 0x000279DA
		private void xsmodeTypeEnable_Click(object sender, EventArgs e)
		{
			this.xsmodeTypeEnable.Checked = true;
		}

		// Token: 0x06000246 RID: 582 RVA: 0x000297EC File Offset: 0x000279EC
		private void emoAsst_Click(object sender, EventArgs e)
		{
			bool flag = this.tt == 1;
			if (flag)
			{
				bool flag2 = string.IsNullOrEmpty(this.channelId.Text) || string.IsNullOrEmpty(this.messageId.Text);
				if (flag2)
				{
					MessageBox.Show("Specifica un Channel ID ed un Message ID", "Avviso", ContentAlignment.MiddleCenter);
				}
				else
				{
					bool flag3 = ImpostazioniGlobali.Tokens == null || ImpostazioniGlobali.Tokens.Count == 0 || ImpostazioniGlobali.Proxies == null || ImpostazioniGlobali.Proxies.Count == 0;
					if (flag3)
					{
						MessageBox.Show("Devi prima importare i tuoi tokens ed i proxies", "Avviso", ContentAlignment.MiddleCenter);
					}
					else
					{
						ImpostazioniGlobali.StartLog();
						new Thread(async delegate(object thr)
						{
							Random rnd = new Random();
							string token = ImpostazioniGlobali.Tokens[rnd.Next(ImpostazioniGlobali.Tokens.Count)];
							Control.CheckForIllegalCrossThreadCalls = false;
							string proxy;
							try
							{
								proxy = ImpostazioniGlobali.Proxies[rnd.Next(ImpostazioniGlobali.Proxies.Count)];
							}
							catch (Exception)
							{
								proxy = "Error";
							}
							ImpostazioniGlobali.Log(string.Concat(new string[]
							{
								proxy,
								"-> (",
								token,
								") Emote Helper => Getting emote at msg: ",
								this.messageId.Text
							}));
							string url_emoast = "https://discord.com/api/v9/channels/" + this.channelId.Text + "/messages";
							try
							{
								HttpClientHandler handler = new HttpClientHandler();
								handler.PreAuthenticate = true;
								handler.UseProxy = true;
								handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
								handler.Proxy = new WebProxy(proxy.Split(new char[] { ':' })[0], int.Parse(proxy.Split(new char[] { ':' })[1]));
								HttpClient http = new HttpClient(handler);
								HttpRequestMessage requestMessages = new HttpRequestMessage
								{
									RequestUri = new Uri(url_emoast),
									Method = HttpMethod.Get,
									Headers = 
									{
										{ "Authorization", token },
										{ "Accept-Language", "it" },
										{ "User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36" },
										{ "X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9" },
										{ "Accept", "*/*" },
										{ "Cookie", "locale=it" },
										{ "Referer", "https://discord.com/channels/@me" }
									}
								};
								HttpResponseMessage httpResponseMessage = await http.SendAsync(requestMessages);
								string text = await httpResponseMessage.Content.ReadAsStringAsync();
								httpResponseMessage = null;
								string respCHMessages = text;
								text = null;
								if (respCHMessages == "[]")
								{
									this.emot.Text = "This channel is empty";
								}
								else
								{
									JArray messagesArr = JArray.Parse(respCHMessages);
									JObject[] jMObjects = messagesArr.ToObject<JObject[]>();
									bool found = false;
									this.emot.Text = "";
									foreach (JObject objMsgCH in jMObjects)
									{
										try
										{
											if (ReactionSpammer.<>o__11.<>p__2 == null)
											{
												ReactionSpammer.<>o__11.<>p__2 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(ReactionSpammer), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
											}
											Func<CallSite, object, bool> target = ReactionSpammer.<>o__11.<>p__2.Target;
											CallSite <>p__ = ReactionSpammer.<>o__11.<>p__2;
											if (ReactionSpammer.<>o__11.<>p__1 == null)
											{
												ReactionSpammer.<>o__11.<>p__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(ReactionSpammer), new CSharpArgumentInfo[]
												{
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
												}));
											}
											Func<CallSite, object, string, object> target2 = ReactionSpammer.<>o__11.<>p__1.Target;
											CallSite <>p__2 = ReactionSpammer.<>o__11.<>p__1;
											if (ReactionSpammer.<>o__11.<>p__0 == null)
											{
												ReactionSpammer.<>o__11.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(ReactionSpammer), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
											}
											if (target(<>p__, target2(<>p__2, ReactionSpammer.<>o__11.<>p__0.Target(ReactionSpammer.<>o__11.<>p__0, objMsgCH), this.messageId.Text)))
											{
												found = true;
												if (ReactionSpammer.<>o__11.<>p__9 == null)
												{
													ReactionSpammer.<>o__11.<>p__9 = CallSite<Action<CallSite, Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Log", null, typeof(ReactionSpammer), new CSharpArgumentInfo[]
													{
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
													}));
												}
												Action<CallSite, Type, object> target3 = ReactionSpammer.<>o__11.<>p__9.Target;
												CallSite <>p__3 = ReactionSpammer.<>o__11.<>p__9;
												Type typeFromHandle = typeof(ImpostazioniGlobali);
												if (ReactionSpammer.<>o__11.<>p__8 == null)
												{
													ReactionSpammer.<>o__11.<>p__8 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(ReactionSpammer), new CSharpArgumentInfo[]
													{
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
													}));
												}
												Func<CallSite, object, object, object> target4 = ReactionSpammer.<>o__11.<>p__8.Target;
												CallSite <>p__4 = ReactionSpammer.<>o__11.<>p__8;
												if (ReactionSpammer.<>o__11.<>p__5 == null)
												{
													ReactionSpammer.<>o__11.<>p__5 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(ReactionSpammer), new CSharpArgumentInfo[]
													{
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
													}));
												}
												Func<CallSite, object, string, object> target5 = ReactionSpammer.<>o__11.<>p__5.Target;
												CallSite <>p__5 = ReactionSpammer.<>o__11.<>p__5;
												if (ReactionSpammer.<>o__11.<>p__4 == null)
												{
													ReactionSpammer.<>o__11.<>p__4 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(ReactionSpammer), new CSharpArgumentInfo[]
													{
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
													}));
												}
												Func<CallSite, string, object, object> target6 = ReactionSpammer.<>o__11.<>p__4.Target;
												CallSite <>p__6 = ReactionSpammer.<>o__11.<>p__4;
												string text2 = string.Concat(new string[]
												{
													proxy,
													"-> (",
													token,
													") Emote Helper => Got message at ",
													this.channelId.Text,
													"::"
												});
												if (ReactionSpammer.<>o__11.<>p__3 == null)
												{
													ReactionSpammer.<>o__11.<>p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(ReactionSpammer), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
												}
												object obj = target5(<>p__5, target6(<>p__6, text2, ReactionSpammer.<>o__11.<>p__3.Target(ReactionSpammer.<>o__11.<>p__3, objMsgCH)), " sent by ");
												if (ReactionSpammer.<>o__11.<>p__7 == null)
												{
													ReactionSpammer.<>o__11.<>p__7 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(ReactionSpammer), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
												}
												Func<CallSite, object, object> target7 = ReactionSpammer.<>o__11.<>p__7.Target;
												CallSite <>p__7 = ReactionSpammer.<>o__11.<>p__7;
												if (ReactionSpammer.<>o__11.<>p__6 == null)
												{
													ReactionSpammer.<>o__11.<>p__6 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "author", typeof(ReactionSpammer), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
												}
												target3(<>p__3, typeFromHandle, target4(<>p__4, obj, target7(<>p__7, ReactionSpammer.<>o__11.<>p__6.Target(ReactionSpammer.<>o__11.<>p__6, objMsgCH))));
												if (ReactionSpammer.<>o__11.<>p__10 == null)
												{
													ReactionSpammer.<>o__11.<>p__10 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "reactions", typeof(ReactionSpammer), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
												}
												object rj_c = ReactionSpammer.<>o__11.<>p__10.Target(ReactionSpammer.<>o__11.<>p__10, objMsgCH);
												if (ReactionSpammer.<>o__11.<>p__14 == null)
												{
													ReactionSpammer.<>o__11.<>p__14 = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Parse", null, typeof(ReactionSpammer), new CSharpArgumentInfo[]
													{
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
													}));
												}
												Func<CallSite, Type, object, object> target8 = ReactionSpammer.<>o__11.<>p__14.Target;
												CallSite <>p__8 = ReactionSpammer.<>o__11.<>p__14;
												Type typeFromHandle2 = typeof(JObject);
												if (ReactionSpammer.<>o__11.<>p__13 == null)
												{
													ReactionSpammer.<>o__11.<>p__13 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(ReactionSpammer), new CSharpArgumentInfo[]
													{
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
													}));
												}
												Func<CallSite, object, string, object> target9 = ReactionSpammer.<>o__11.<>p__13.Target;
												CallSite <>p__9 = ReactionSpammer.<>o__11.<>p__13;
												if (ReactionSpammer.<>o__11.<>p__12 == null)
												{
													ReactionSpammer.<>o__11.<>p__12 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(ReactionSpammer), new CSharpArgumentInfo[]
													{
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
													}));
												}
												Func<CallSite, string, object, object> target10 = ReactionSpammer.<>o__11.<>p__12.Target;
												CallSite <>p__10 = ReactionSpammer.<>o__11.<>p__12;
												string text3 = "{\"r_ct\": ";
												if (ReactionSpammer.<>o__11.<>p__11 == null)
												{
													ReactionSpammer.<>o__11.<>p__11 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(ReactionSpammer), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
												}
												object jreact_arr = target8(<>p__8, typeFromHandle2, target9(<>p__9, target10(<>p__10, text3, ReactionSpammer.<>o__11.<>p__11.Target(ReactionSpammer.<>o__11.<>p__11, rj_c)), "}"));
												if (ReactionSpammer.<>o__11.<>p__18 == null)
												{
													ReactionSpammer.<>o__11.<>p__18 = CallSite<Func<CallSite, object, JArray>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(JArray), typeof(ReactionSpammer)));
												}
												Func<CallSite, object, JArray> target11 = ReactionSpammer.<>o__11.<>p__18.Target;
												CallSite <>p__11 = ReactionSpammer.<>o__11.<>p__18;
												if (ReactionSpammer.<>o__11.<>p__17 == null)
												{
													ReactionSpammer.<>o__11.<>p__17 = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Parse", null, typeof(ReactionSpammer), new CSharpArgumentInfo[]
													{
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
													}));
												}
												Func<CallSite, Type, object, object> target12 = ReactionSpammer.<>o__11.<>p__17.Target;
												CallSite <>p__12 = ReactionSpammer.<>o__11.<>p__17;
												Type typeFromHandle3 = typeof(JArray);
												if (ReactionSpammer.<>o__11.<>p__16 == null)
												{
													ReactionSpammer.<>o__11.<>p__16 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(ReactionSpammer), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
												}
												Func<CallSite, object, object> target13 = ReactionSpammer.<>o__11.<>p__16.Target;
												CallSite <>p__13 = ReactionSpammer.<>o__11.<>p__16;
												if (ReactionSpammer.<>o__11.<>p__15 == null)
												{
													ReactionSpammer.<>o__11.<>p__15 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "r_ct", typeof(ReactionSpammer), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
												}
												JArray arrayReactions = target11(<>p__11, target12(<>p__12, typeFromHandle3, target13(<>p__13, ReactionSpammer.<>o__11.<>p__15.Target(ReactionSpammer.<>o__11.<>p__15, jreact_arr))));
												JObject[] reactions = messagesArr.ToObject<JObject[]>();
												foreach (JObject react in reactions)
												{
													if (ReactionSpammer.<>o__11.<>p__43 == null)
													{
														ReactionSpammer.<>o__11.<>p__43 = CallSite<Func<CallSite, object, IEnumerable>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(IEnumerable), typeof(ReactionSpammer)));
													}
													Func<CallSite, object, IEnumerable> target14 = ReactionSpammer.<>o__11.<>p__43.Target;
													CallSite <>p__14 = ReactionSpammer.<>o__11.<>p__43;
													if (ReactionSpammer.<>o__11.<>p__19 == null)
													{
														ReactionSpammer.<>o__11.<>p__19 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "reactions", typeof(ReactionSpammer), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
													}
													foreach (object emc in target14(<>p__14, ReactionSpammer.<>o__11.<>p__19.Target(ReactionSpammer.<>o__11.<>p__19, react)))
													{
														if (ReactionSpammer.<>o__11.<>p__20 == null)
														{
															ReactionSpammer.<>o__11.<>p__20 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "emoji", typeof(ReactionSpammer), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
														}
														object emmj = ReactionSpammer.<>o__11.<>p__20.Target(ReactionSpammer.<>o__11.<>p__20, emc);
														try
														{
															if (ReactionSpammer.<>o__11.<>p__23 == null)
															{
																ReactionSpammer.<>o__11.<>p__23 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(ReactionSpammer), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
															}
															Func<CallSite, object, bool> target15 = ReactionSpammer.<>o__11.<>p__23.Target;
															CallSite <>p__15 = ReactionSpammer.<>o__11.<>p__23;
															if (ReactionSpammer.<>o__11.<>p__22 == null)
															{
																ReactionSpammer.<>o__11.<>p__22 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(ReactionSpammer), new CSharpArgumentInfo[]
																{
																	CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
																	CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
																}));
															}
															Func<CallSite, object, object, object> target16 = ReactionSpammer.<>o__11.<>p__22.Target;
															CallSite <>p__16 = ReactionSpammer.<>o__11.<>p__22;
															if (ReactionSpammer.<>o__11.<>p__21 == null)
															{
																ReactionSpammer.<>o__11.<>p__21 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(ReactionSpammer), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
															}
															if (target15(<>p__15, target16(<>p__16, ReactionSpammer.<>o__11.<>p__21.Target(ReactionSpammer.<>o__11.<>p__21, emmj), null)))
															{
																throw new Exception("ex");
															}
														}
														catch (Exception)
														{
															continue;
														}
														object emj = emmj;
														if (ReactionSpammer.<>o__11.<>p__30 == null)
														{
															ReactionSpammer.<>o__11.<>p__30 = CallSite<Action<CallSite, Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Log", null, typeof(ReactionSpammer), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
															}));
														}
														Action<CallSite, Type, object> target17 = ReactionSpammer.<>o__11.<>p__30.Target;
														CallSite <>p__17 = ReactionSpammer.<>o__11.<>p__30;
														Type typeFromHandle4 = typeof(ImpostazioniGlobali);
														if (ReactionSpammer.<>o__11.<>p__29 == null)
														{
															ReactionSpammer.<>o__11.<>p__29 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(ReactionSpammer), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
															}));
														}
														Func<CallSite, object, string, object> target18 = ReactionSpammer.<>o__11.<>p__29.Target;
														CallSite <>p__18 = ReactionSpammer.<>o__11.<>p__29;
														if (ReactionSpammer.<>o__11.<>p__28 == null)
														{
															ReactionSpammer.<>o__11.<>p__28 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(ReactionSpammer), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
															}));
														}
														Func<CallSite, object, object, object> target19 = ReactionSpammer.<>o__11.<>p__28.Target;
														CallSite <>p__19 = ReactionSpammer.<>o__11.<>p__28;
														if (ReactionSpammer.<>o__11.<>p__26 == null)
														{
															ReactionSpammer.<>o__11.<>p__26 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(ReactionSpammer), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
															}));
														}
														Func<CallSite, object, string, object> target20 = ReactionSpammer.<>o__11.<>p__26.Target;
														CallSite <>p__20 = ReactionSpammer.<>o__11.<>p__26;
														if (ReactionSpammer.<>o__11.<>p__25 == null)
														{
															ReactionSpammer.<>o__11.<>p__25 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(ReactionSpammer), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
															}));
														}
														Func<CallSite, string, object, object> target21 = ReactionSpammer.<>o__11.<>p__25.Target;
														CallSite <>p__21 = ReactionSpammer.<>o__11.<>p__25;
														string text4 = proxy + "-> (" + token + ") Emote Helper => Found Emoji: [em_id=";
														if (ReactionSpammer.<>o__11.<>p__24 == null)
														{
															ReactionSpammer.<>o__11.<>p__24 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(ReactionSpammer), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
														}
														object obj2 = target20(<>p__20, target21(<>p__21, text4, ReactionSpammer.<>o__11.<>p__24.Target(ReactionSpammer.<>o__11.<>p__24, emj)), ", em_name=");
														if (ReactionSpammer.<>o__11.<>p__27 == null)
														{
															ReactionSpammer.<>o__11.<>p__27 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "name", typeof(ReactionSpammer), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
														}
														target17(<>p__17, typeFromHandle4, target18(<>p__18, target19(<>p__19, obj2, ReactionSpammer.<>o__11.<>p__27.Target(ReactionSpammer.<>o__11.<>p__27, emj)), "]"));
														if (this.emot.Text != "")
														{
															TextBox textBox = this.emot;
															if (ReactionSpammer.<>o__11.<>p__36 == null)
															{
																ReactionSpammer.<>o__11.<>p__36 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(ReactionSpammer)));
															}
															Func<CallSite, object, string> target22 = ReactionSpammer.<>o__11.<>p__36.Target;
															CallSite <>p__22 = ReactionSpammer.<>o__11.<>p__36;
															if (ReactionSpammer.<>o__11.<>p__35 == null)
															{
																ReactionSpammer.<>o__11.<>p__35 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(ReactionSpammer), new CSharpArgumentInfo[]
																{
																	CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
																	CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
																}));
															}
															Func<CallSite, object, object, object> target23 = ReactionSpammer.<>o__11.<>p__35.Target;
															CallSite <>p__23 = ReactionSpammer.<>o__11.<>p__35;
															if (ReactionSpammer.<>o__11.<>p__33 == null)
															{
																ReactionSpammer.<>o__11.<>p__33 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(ReactionSpammer), new CSharpArgumentInfo[]
																{
																	CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
																	CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
																}));
															}
															Func<CallSite, object, string, object> target24 = ReactionSpammer.<>o__11.<>p__33.Target;
															CallSite <>p__24 = ReactionSpammer.<>o__11.<>p__33;
															if (ReactionSpammer.<>o__11.<>p__32 == null)
															{
																ReactionSpammer.<>o__11.<>p__32 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(ReactionSpammer), new CSharpArgumentInfo[]
																{
																	CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
																	CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
																}));
															}
															Func<CallSite, string, object, object> target25 = ReactionSpammer.<>o__11.<>p__32.Target;
															CallSite <>p__25 = ReactionSpammer.<>o__11.<>p__32;
															string text5 = this.emot.Text + ", ";
															if (ReactionSpammer.<>o__11.<>p__31 == null)
															{
																ReactionSpammer.<>o__11.<>p__31 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "name", typeof(ReactionSpammer), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
															}
															object obj3 = target24(<>p__24, target25(<>p__25, text5, ReactionSpammer.<>o__11.<>p__31.Target(ReactionSpammer.<>o__11.<>p__31, emj)), ":");
															if (ReactionSpammer.<>o__11.<>p__34 == null)
															{
																ReactionSpammer.<>o__11.<>p__34 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(ReactionSpammer), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
															}
															textBox.Text = target22(<>p__22, target23(<>p__23, obj3, ReactionSpammer.<>o__11.<>p__34.Target(ReactionSpammer.<>o__11.<>p__34, emj)));
														}
														else
														{
															TextBox textBox2 = this.emot;
															if (ReactionSpammer.<>o__11.<>p__42 == null)
															{
																ReactionSpammer.<>o__11.<>p__42 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(ReactionSpammer)));
															}
															Func<CallSite, object, string> target26 = ReactionSpammer.<>o__11.<>p__42.Target;
															CallSite <>p__26 = ReactionSpammer.<>o__11.<>p__42;
															if (ReactionSpammer.<>o__11.<>p__41 == null)
															{
																ReactionSpammer.<>o__11.<>p__41 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(ReactionSpammer), new CSharpArgumentInfo[]
																{
																	CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
																	CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
																}));
															}
															Func<CallSite, object, object, object> target27 = ReactionSpammer.<>o__11.<>p__41.Target;
															CallSite <>p__27 = ReactionSpammer.<>o__11.<>p__41;
															if (ReactionSpammer.<>o__11.<>p__39 == null)
															{
																ReactionSpammer.<>o__11.<>p__39 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(ReactionSpammer), new CSharpArgumentInfo[]
																{
																	CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
																	CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
																}));
															}
															Func<CallSite, object, string, object> target28 = ReactionSpammer.<>o__11.<>p__39.Target;
															CallSite <>p__28 = ReactionSpammer.<>o__11.<>p__39;
															if (ReactionSpammer.<>o__11.<>p__38 == null)
															{
																ReactionSpammer.<>o__11.<>p__38 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(ReactionSpammer), new CSharpArgumentInfo[]
																{
																	CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
																	CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
																}));
															}
															Func<CallSite, string, object, object> target29 = ReactionSpammer.<>o__11.<>p__38.Target;
															CallSite <>p__29 = ReactionSpammer.<>o__11.<>p__38;
															string text6 = "";
															if (ReactionSpammer.<>o__11.<>p__37 == null)
															{
																ReactionSpammer.<>o__11.<>p__37 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "name", typeof(ReactionSpammer), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
															}
															object obj4 = target28(<>p__28, target29(<>p__29, text6, ReactionSpammer.<>o__11.<>p__37.Target(ReactionSpammer.<>o__11.<>p__37, emj)), ":");
															if (ReactionSpammer.<>o__11.<>p__40 == null)
															{
																ReactionSpammer.<>o__11.<>p__40 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(ReactionSpammer), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
															}
															textBox2.Text = target26(<>p__26, target27(<>p__27, obj4, ReactionSpammer.<>o__11.<>p__40.Target(ReactionSpammer.<>o__11.<>p__40, emj)));
														}
														emmj = null;
														emj = null;
														emc = null;
													}
													IEnumerator enumerator = null;
													react = null;
												}
												JObject[] array2 = null;
												break;
											}
										}
										catch (Exception r)
										{
											if (ReactionSpammer.<>o__11.<>p__46 == null)
											{
												ReactionSpammer.<>o__11.<>p__46 = CallSite<Action<CallSite, Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Log", null, typeof(ReactionSpammer), new CSharpArgumentInfo[]
												{
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
												}));
											}
											Action<CallSite, Type, object> target30 = ReactionSpammer.<>o__11.<>p__46.Target;
											CallSite <>p__30 = ReactionSpammer.<>o__11.<>p__46;
											Type typeFromHandle5 = typeof(ImpostazioniGlobali);
											if (ReactionSpammer.<>o__11.<>p__45 == null)
											{
												ReactionSpammer.<>o__11.<>p__45 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(ReactionSpammer), new CSharpArgumentInfo[]
												{
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
												}));
											}
											Func<CallSite, string, object, object> target31 = ReactionSpammer.<>o__11.<>p__45.Target;
											CallSite <>p__31 = ReactionSpammer.<>o__11.<>p__45;
											string text7 = proxy + "-> (" + token + ") Emote Helper => Failed to parse message with ID ";
											if (ReactionSpammer.<>o__11.<>p__44 == null)
											{
												ReactionSpammer.<>o__11.<>p__44 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(ReactionSpammer), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
											}
											target30(<>p__30, typeFromHandle5, target31(<>p__31, text7, ReactionSpammer.<>o__11.<>p__44.Target(ReactionSpammer.<>o__11.<>p__44, objMsgCH)));
										}
										objMsgCH = null;
									}
									JObject[] array = null;
									if (!found)
									{
										this.emot.Text = "Message was not found";
										ImpostazioniGlobali.Log(string.Concat(new string[]
										{
											proxy,
											"-> (",
											token,
											") Emote Helper => Unable to find message with ID ",
											this.messageId.Text
										}));
									}
									if (this.emot.Text == "" && found)
									{
										ImpostazioniGlobali.Log(string.Concat(new string[]
										{
											proxy,
											"-> (",
											token,
											") Emote Helper => No emotes at ",
											this.messageId.Text
										}));
										this.emot.Text = "No emotes found";
									}
									handler = null;
									http = null;
									requestMessages = null;
									respCHMessages = null;
									messagesArr = null;
									jMObjects = null;
								}
							}
							catch (Exception)
							{
								ImpostazioniGlobali.Log(proxy + "-> (" + token + ") Emote Helper => An error has occurred.");
							}
						}).Start();
					}
				}
			}
			else
			{
				bool flag4 = this.tt == 0;
				if (flag4)
				{
					this.emot.Focus();
					try
					{
						new InputSimulator().Keyboard.ModifiedKeyStroke(91, 190);
						this.emot.Focus();
					}
					catch (Exception)
					{
						goto IL_00FC;
					}
					return;
				}
				IL_00FC:
				MessageBox.Show("Qualcosa è andato storto. Puoi riprovare?", "Avviso", ContentAlignment.MiddleCenter);
			}
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00029918 File Offset: 0x00027B18
		private void hasLive_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.hasLive.Checked;
			if (@checked)
			{
				this.tt = 0;
				this.emoAsst.Text = "Emojis";
			}
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00029950 File Offset: 0x00027B50
		private void hasEmbed_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.hasEmbed.Checked;
			if (@checked)
			{
				this.tt = 1;
				this.emoAsst.Text = "Emotes";
			}
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00029988 File Offset: 0x00027B88
		private async void siticoneButton1_Click(object sender, EventArgs e)
		{
			bool flag = this.channelId.Text == "" || this.emot.Text == "" || this.messageId.Text == "";
			if (flag)
			{
				MessageBox.Show("Please fill every requested parameter", "Avviso", ContentAlignment.MiddleCenter);
			}
			else
			{
				this.siticoneButton1.Text = "Removing Reactions..";
				this.siticoneButton1.Enabled = false;
				bool flag2 = ImpostazioniGlobali.Tokens == null || ImpostazioniGlobali.Proxies == null;
				if (flag2)
				{
					await Task.Delay(50);
					this.siticoneButton1.Text = "Remove Reactions";
					this.siticoneButton1.Enabled = true;
					MessageBox.Show("There are no such tokens or proxies", "Avviso", ContentAlignment.MiddleCenter);
				}
				else
				{
					ImpostazioniGlobali.StartLog();
					try
					{
						string ddt = ImpostazioniGlobali.GetReadableDateNow();
						JObject devDebug = ImpostazioniGlobali.CreateDebugAction(19, "REACT+_SPM", "REACTION_SPAMMER_REACT_SF", new string[]
						{
							"BUTTON_SPAM_REACTIONS",
							"T_" + ImpostazioniGlobali.Tokens.Count.ToString() + "_P_" + ImpostazioniGlobali.Proxies.Count.ToString()
						}, "RSPM_SGL_OF_CEM_" + this.hasDelay.Checked.ToString(), ddt);
						ImpostazioniGlobali.Debug_DPut(devDebug);
						ddt = null;
						devDebug = null;
					}
					catch (Exception)
					{
					}
					Random random = new Random();
					List<string> proxies = ImpostazioniGlobali.Proxies;
					string guildInvite = this.channelId.Text.Replace("https", "").Replace("/", "").Replace(":", "")
						.Replace("discordapp.com", "")
						.Replace(" ", "")
						.Replace("discord.gg", "")
						.Replace("discord.com", "")
						.Replace("invite", "")
						.Replace(" ", "")
						.Replace(".", "");
					ImpostazioniGlobali.Log(string.Concat(new string[]
					{
						"Manager -> (Operation Starting) Reaction Spammer => Spamming reactions in ",
						this.channelId.Text,
						" with ",
						proxies.Count.ToString(),
						" proxies and ",
						ImpostazioniGlobali.Tokens.Count.ToString(),
						" tokens.. Delay has been set to ",
						this.sliderDelay.Value.ToString()
					}));
					bool hasDel = this.hasDelay.Checked;
					if (this.sliderDelay.Value == 0)
					{
						hasDel = false;
						this.hasDelay.Checked = false;
					}
					try
					{
						int type = 0;
						if (!this.hasLive.Checked)
						{
							type = 1;
						}
						AuditManager auditManager = ImpostazioniGlobali.auditManager;
						auditManager.LogActionReaction(type, this.emot.Text, this.channelId.Text, this.messageId.Text);
						auditManager = null;
					}
					catch (Exception)
					{
					}
					new Thread(delegate(object p)
					{
						using (List<string>.Enumerator enumerator = ImpostazioniGlobali.Tokens.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								string token = enumerator.Current;
								new Thread(async delegate(object j)
								{
									bool hasDel2 = hasDel;
									if (hasDel2)
									{
										ImpostazioniGlobali.Log(string.Concat(new string[]
										{
											"Manager -> (Delay) (",
											token,
											") Reaction Spammer => Awaiting ",
											this.sliderDelay.Value.ToString(),
											"ms of delay before reacting."
										}));
										Thread.Sleep(this.sliderDelay.Value);
									}
									string proxy;
									try
									{
										proxy = proxies[random.Next(proxies.Count)];
									}
									catch (Exception)
									{
										proxy = "Error";
									}
									try
									{
										HttpClientHandler handler = new HttpClientHandler();
										handler.PreAuthenticate = true;
										handler.UseProxy = true;
										handler.Proxy = new WebProxy(proxy.Split(new char[] { ':' })[0], int.Parse(proxy.Split(new char[] { ':' })[1]));
										HttpClient http = new HttpClient(handler);
										bool flag3 = !this.hasLive.Checked;
										if (flag3)
										{
											HttpRequestMessage request = new HttpRequestMessage
											{
												RequestUri = new Uri(string.Concat(new string[]
												{
													"https://discord.com/api/v9/channels/",
													this.channelId.Text,
													"/messages/",
													this.messageId.Text,
													"/reactions/",
													this.emot.Text,
													"/@me"
												})),
												Method = HttpMethod.Delete,
												Headers = 
												{
													{ "Authorization", token },
													{ "Accept-Language", "it" },
													{ "User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36" },
													{ "X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9" },
													{ "Accept", "*/*" },
													{ "Cookie", "locale=it" },
													{
														"Referer",
														"https://discord.com/channels/" + this.channelId.Text
													}
												}
											};
											HttpResponseMessage httpResponseMessage = await http.SendAsync(request);
											string text = await httpResponseMessage.Content.ReadAsStringAsync();
											httpResponseMessage = null;
											string _ = text;
											text = null;
											if (_ == "")
											{
												_ = "Successfully Unreacted";
											}
											if (ImpostazioniGlobali.StreamerMode)
											{
												ImpostazioniGlobali.Log(string.Concat(new string[]
												{
													proxy,
													" -> (Token ",
													ImpostazioniGlobali.Tokens.IndexOf(token).ToString(),
													") Reaction => ",
													_
												}));
											}
											else
											{
												ImpostazioniGlobali.Log(string.Concat(new string[] { proxy, " -> (", token, ") Reaction => ", _ }));
											}
											request = null;
											_ = null;
										}
										else
										{
											HttpRequestMessage request2 = new HttpRequestMessage
											{
												RequestUri = new Uri(string.Concat(new string[]
												{
													"https://discord.com/api/v9/channels/",
													this.channelId.Text,
													"/messages/",
													this.messageId.Text,
													"/reactions/",
													Uri.EscapeDataString(this.emot.Text),
													"/@me"
												})),
												Method = HttpMethod.Delete,
												Headers = 
												{
													{ "Authorization", token },
													{ "Accept-Language", "it" },
													{ "User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36" },
													{ "X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9" },
													{ "Accept", "*/*" },
													{ "Cookie", "locale=it" },
													{
														"Referer",
														"https://discord.com/channels/" + this.channelId.Text
													}
												}
											};
											HttpResponseMessage httpResponseMessage2 = await http.SendAsync(request2);
											string text2 = await httpResponseMessage2.Content.ReadAsStringAsync();
											httpResponseMessage2 = null;
											string _2 = text2;
											text2 = null;
											if (_2 == "")
											{
												_2 = "Successfully Unreacted";
											}
											if (ImpostazioniGlobali.StreamerMode)
											{
												ImpostazioniGlobali.Log(string.Concat(new string[]
												{
													proxy,
													" -> (Token ",
													ImpostazioniGlobali.Tokens.IndexOf(token).ToString(),
													") Reaction => ",
													_2
												}));
											}
											else
											{
												ImpostazioniGlobali.Log(string.Concat(new string[] { proxy, " -> (", token, ") Reaction => ", _2 }));
											}
											request2 = null;
											_2 = null;
										}
										handler = null;
										http = null;
									}
									catch (Exception)
									{
										if (ImpostazioniGlobali.StreamerMode)
										{
											ImpostazioniGlobali.Log(proxy + " -> (Token " + ImpostazioniGlobali.Tokens.IndexOf(token).ToString() + ") Reaction => Unknown Error [Check your proxies]");
										}
										else
										{
											ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Reaction => Unknown Error [Check your proxies]");
										}
									}
									try
									{
										Thread.CurrentThread.Abort();
									}
									catch
									{
									}
								}).Start();
							}
						}
					}).Start();
					await Task.Delay(50);
					this.siticoneButton1.Text = "Remove Reactions";
					this.siticoneButton1.Enabled = true;
				}
			}
		}

		// Token: 0x0600024A RID: 586 RVA: 0x000299CF File Offset: 0x00027BCF
		private void siticoneGradientButton4_Click(object sender, EventArgs e)
		{
			this.emoAsst_Click(sender, e);
		}

		// Token: 0x0600024B RID: 587 RVA: 0x000299DC File Offset: 0x00027BDC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00029A14 File Offset: 0x00027C14
		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ReactionSpammer));
			this.label1 = new Label();
			this.sliderDelay = new SiticoneSlider();
			this.hasDelay = new SiticoneToggleSwitch();
			this.del = new Label();
			this.label9 = new Label();
			this.label8 = new Label();
			this.hasEmbed = new SiticoneCustomCheckBox();
			this.hasLive = new SiticoneCustomCheckBox();
			this.startBtn = new SiticoneButton();
			this.emot = new SiticoneTextBox();
			this.channelId = new SiticoneTextBox();
			this.messageId = new SiticoneTextBox();
			this.pictureBox2 = new PictureBox();
			this.siticoneDragControl1 = new SiticoneDragControl(this.components);
			this.xsmodeTypeEnable = new SiticoneToggleSwitch();
			this.label4 = new Label();
			this.label3 = new Label();
			this.siticoneButton1 = new SiticoneButton();
			this.emoAsst = new SiticoneGradientButton();
			((ISupportInitialize)this.pictureBox2).BeginInit();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Inter", 15.75f, FontStyle.Bold);
			this.label1.Location = new Point(13, 36);
			this.label1.Name = "label1";
			this.label1.Size = new Size(207, 25);
			this.label1.TabIndex = 3;
			this.label1.Text = "Reaction Spammer";
			this.sliderDelay.Cursor = Cursors.Hand;
			this.sliderDelay.LargeChange = 5;
			this.sliderDelay.Location = new Point(28, 417);
			this.sliderDelay.Name = "sliderDelay";
			this.sliderDelay.Size = new Size(640, 60);
			this.sliderDelay.TabIndex = 63;
			this.sliderDelay.Scroll += this.sliderDelay_Scroll;
			this.hasDelay.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.hasDelay.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.hasDelay.CheckedState.InnerBorderColor = Color.White;
			this.hasDelay.CheckedState.InnerColor = Color.White;
			this.hasDelay.CheckedState.Parent = this.hasDelay;
			this.hasDelay.Cursor = Cursors.Hand;
			this.hasDelay.Location = new Point(548, 365);
			this.hasDelay.Name = "hasDelay";
			this.hasDelay.ShadowDecoration.Parent = this.hasDelay;
			this.hasDelay.Size = new Size(32, 20);
			this.hasDelay.TabIndex = 62;
			this.hasDelay.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.hasDelay.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.hasDelay.UncheckedState.InnerBorderColor = Color.White;
			this.hasDelay.UncheckedState.InnerColor = Color.White;
			this.hasDelay.UncheckedState.Parent = this.hasDelay;
			this.del.AutoSize = true;
			this.del.Font = new Font("SF Pro Text", 9f, FontStyle.Bold);
			this.del.Location = new Point(585, 368);
			this.del.Name = "del";
			this.del.Size = new Size(74, 14);
			this.del.TabIndex = 61;
			this.del.Text = "Delay: 0ms";
			this.label9.AutoSize = true;
			this.label9.Font = new Font("SF Pro Text", 9f, FontStyle.Bold);
			this.label9.Location = new Point(49, 353);
			this.label9.Name = "label9";
			this.label9.Size = new Size(38, 14);
			this.label9.TabIndex = 60;
			this.label9.Text = "Emoji";
			this.label8.AutoSize = true;
			this.label8.Font = new Font("SF Pro Text", 9f, FontStyle.Bold);
			this.label8.Location = new Point(49, 374);
			this.label8.Name = "label8";
			this.label8.Size = new Size(44, 14);
			this.label8.TabIndex = 59;
			this.label8.Text = "Emote";
			this.hasEmbed.BackColor = Color.Transparent;
			this.hasEmbed.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.hasEmbed.CheckedState.BorderRadius = 2;
			this.hasEmbed.CheckedState.BorderThickness = 0;
			this.hasEmbed.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.hasEmbed.CheckedState.Parent = this.hasEmbed;
			this.hasEmbed.Cursor = Cursors.Hand;
			this.hasEmbed.Location = new Point(31, 374);
			this.hasEmbed.Name = "hasEmbed";
			this.hasEmbed.ShadowDecoration.Parent = this.hasEmbed;
			this.hasEmbed.Size = new Size(15, 15);
			this.hasEmbed.TabIndex = 58;
			this.hasEmbed.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.hasEmbed.UncheckedState.BorderRadius = 2;
			this.hasEmbed.UncheckedState.BorderThickness = 0;
			this.hasEmbed.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.hasEmbed.UncheckedState.Parent = this.hasEmbed;
			this.hasEmbed.CheckedChanged += this.hasEmbed_CheckedChanged;
			this.hasEmbed.Click += this.hasEmbed_Click;
			this.hasLive.Checked = true;
			this.hasLive.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.hasLive.CheckedState.BorderRadius = 2;
			this.hasLive.CheckedState.BorderThickness = 0;
			this.hasLive.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.hasLive.CheckedState.Parent = this.hasLive;
			this.hasLive.CheckState = CheckState.Checked;
			this.hasLive.Cursor = Cursors.Hand;
			this.hasLive.Location = new Point(31, 353);
			this.hasLive.Name = "hasLive";
			this.hasLive.ShadowDecoration.Parent = this.hasLive;
			this.hasLive.Size = new Size(15, 15);
			this.hasLive.TabIndex = 57;
			this.hasLive.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.hasLive.UncheckedState.BorderRadius = 2;
			this.hasLive.UncheckedState.BorderThickness = 0;
			this.hasLive.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.hasLive.UncheckedState.Parent = this.hasLive;
			this.hasLive.CheckedChanged += this.hasLive_CheckedChanged;
			this.hasLive.Click += this.hasLive_Click;
			this.startBtn.BackColor = Color.Transparent;
			this.startBtn.BorderColor = Color.LightGray;
			this.startBtn.BorderRadius = 4;
			this.startBtn.BorderStyle = DashStyle.Dot;
			this.startBtn.BorderThickness = 1;
			this.startBtn.CheckedState.Parent = this.startBtn;
			this.startBtn.Cursor = Cursors.Hand;
			this.startBtn.CustomImages.Parent = this.startBtn;
			this.startBtn.FillColor = Color.Snow;
			this.startBtn.Font = new Font("SF Pro Text", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.startBtn.ForeColor = Color.Black;
			this.startBtn.HoveredState.Parent = this.startBtn;
			this.startBtn.Location = new Point(22, 508);
			this.startBtn.Name = "startBtn";
			this.startBtn.PressedColor = Color.White;
			this.startBtn.ShadowDecoration.Parent = this.startBtn;
			this.startBtn.Size = new Size(323, 31);
			this.startBtn.TabIndex = 55;
			this.startBtn.Text = "Spam Reactions";
			this.startBtn.TextRenderingHint = TextRenderingHint.AntiAlias;
			this.startBtn.Click += this.startBtn_Click;
			this.startBtn.MouseEnter += this.startBtn_MouseEnter;
			this.startBtn.MouseLeave += this.startBtn_MouseLeave;
			this.emot.Animated = false;
			this.emot.BackColor = Color.Transparent;
			this.emot.BorderRadius = 4;
			this.emot.BorderThickness = 2;
			this.emot.Cursor = Cursors.IBeam;
			this.emot.DefaultText = "";
			this.emot.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			this.emot.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			this.emot.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			this.emot.DisabledState.Parent = this.emot;
			this.emot.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			this.emot.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.emot.FocusedState.Parent = this.emot;
			this.emot.Font = new Font("SF Pro Text", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.emot.ForeColor = Color.Black;
			this.emot.HoveredState.BorderColor = Color.FromArgb(213, 218, 223);
			this.emot.HoveredState.Parent = this.emot;
			this.emot.Location = new Point(28, 190);
			this.emot.Margin = new Padding(4, 3, 4, 3);
			this.emot.Name = "emot";
			this.emot.PasswordChar = '\0';
			this.emot.PlaceholderText = "Emoji Unicode or Emote ID";
			this.emot.SelectedText = "";
			this.emot.ShadowDecoration.Parent = this.emot;
			this.emot.Size = new Size(437, 37);
			this.emot.TabIndex = 52;
			this.channelId.Animated = false;
			this.channelId.BackColor = Color.Transparent;
			this.channelId.BorderRadius = 4;
			this.channelId.BorderThickness = 2;
			this.channelId.Cursor = Cursors.IBeam;
			this.channelId.DefaultText = "";
			this.channelId.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			this.channelId.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			this.channelId.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			this.channelId.DisabledState.Parent = this.channelId;
			this.channelId.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			this.channelId.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.channelId.FocusedState.Parent = this.channelId;
			this.channelId.Font = new Font("SF Pro Text", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.channelId.ForeColor = Color.Black;
			this.channelId.HoveredState.BorderColor = Color.FromArgb(213, 218, 223);
			this.channelId.HoveredState.Parent = this.channelId;
			this.channelId.Location = new Point(28, 233);
			this.channelId.Margin = new Padding(4, 3, 4, 3);
			this.channelId.Name = "channelId";
			this.channelId.PasswordChar = '\0';
			this.channelId.PlaceholderText = "Channel ID";
			this.channelId.SelectedText = "";
			this.channelId.ShadowDecoration.Parent = this.channelId;
			this.channelId.Size = new Size(640, 36);
			this.channelId.TabIndex = 64;
			this.messageId.Animated = false;
			this.messageId.BackColor = Color.Transparent;
			this.messageId.BorderRadius = 4;
			this.messageId.BorderThickness = 2;
			this.messageId.Cursor = Cursors.IBeam;
			this.messageId.DefaultText = "";
			this.messageId.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			this.messageId.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			this.messageId.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			this.messageId.DisabledState.Parent = this.messageId;
			this.messageId.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			this.messageId.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.messageId.FocusedState.Parent = this.messageId;
			this.messageId.Font = new Font("SF Pro Text", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.messageId.ForeColor = Color.Black;
			this.messageId.HoveredState.BorderColor = Color.FromArgb(213, 218, 223);
			this.messageId.HoveredState.Parent = this.messageId;
			this.messageId.Location = new Point(28, 275);
			this.messageId.Margin = new Padding(4, 3, 4, 3);
			this.messageId.Name = "messageId";
			this.messageId.PasswordChar = '\0';
			this.messageId.PlaceholderText = "Message ID";
			this.messageId.SelectedText = "";
			this.messageId.ShadowDecoration.Parent = this.messageId;
			this.messageId.Size = new Size(640, 36);
			this.messageId.TabIndex = 65;
			this.pictureBox2.Image = (Image)componentResourceManager.GetObject("pictureBox2.Image");
			this.pictureBox2.Location = new Point(633, 36);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new Size(35, 23);
			this.pictureBox2.TabIndex = 68;
			this.pictureBox2.TabStop = false;
			this.siticoneDragControl1.TargetControl = this;
			this.xsmodeTypeEnable.Checked = true;
			this.xsmodeTypeEnable.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.xsmodeTypeEnable.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.xsmodeTypeEnable.CheckedState.InnerBorderColor = Color.White;
			this.xsmodeTypeEnable.CheckedState.InnerColor = Color.White;
			this.xsmodeTypeEnable.CheckedState.Parent = this.xsmodeTypeEnable;
			this.xsmodeTypeEnable.Cursor = Cursors.Hand;
			this.xsmodeTypeEnable.Location = new Point(552, 121);
			this.xsmodeTypeEnable.Name = "xsmodeTypeEnable";
			this.xsmodeTypeEnable.ShadowDecoration.Parent = this.xsmodeTypeEnable;
			this.xsmodeTypeEnable.Size = new Size(32, 20);
			this.xsmodeTypeEnable.TabIndex = 74;
			this.xsmodeTypeEnable.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.xsmodeTypeEnable.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.xsmodeTypeEnable.UncheckedState.InnerBorderColor = Color.White;
			this.xsmodeTypeEnable.UncheckedState.InnerColor = Color.White;
			this.xsmodeTypeEnable.UncheckedState.Parent = this.xsmodeTypeEnable;
			this.xsmodeTypeEnable.Click += this.xsmodeTypeEnable_Click;
			this.label4.AutoSize = true;
			this.label4.Font = new Font("SF Pro Text", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label4.Location = new Point(589, 124);
			this.label4.Name = "label4";
			this.label4.Size = new Size(44, 14);
			this.label4.TabIndex = 73;
			this.label4.Text = "XS V4";
			this.label3.AutoSize = true;
			this.label3.Font = new Font("SF Pro Text", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label3.ForeColor = Color.Teal;
			this.label3.Location = new Point(25, 105);
			this.label3.Name = "label3";
			this.label3.Size = new Size(339, 60);
			this.label3.TabIndex = 72;
			this.label3.Text = "Reaction Spammer V4 has been improved and\r\nnow working with the latest discord security patch.\r\nAdded Encoding Support.\r\nFixed Threading Errors.";
			this.siticoneButton1.BackColor = Color.Transparent;
			this.siticoneButton1.BorderColor = Color.LightGray;
			this.siticoneButton1.BorderRadius = 4;
			this.siticoneButton1.BorderStyle = DashStyle.Dot;
			this.siticoneButton1.BorderThickness = 1;
			this.siticoneButton1.CheckedState.Parent = this.siticoneButton1;
			this.siticoneButton1.Cursor = Cursors.Hand;
			this.siticoneButton1.CustomImages.Parent = this.siticoneButton1;
			this.siticoneButton1.FillColor = Color.Snow;
			this.siticoneButton1.Font = new Font("SF Pro Text", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.siticoneButton1.ForeColor = Color.Black;
			this.siticoneButton1.HoveredState.Parent = this.siticoneButton1;
			this.siticoneButton1.Location = new Point(351, 508);
			this.siticoneButton1.Name = "siticoneButton1";
			this.siticoneButton1.PressedColor = Color.White;
			this.siticoneButton1.ShadowDecoration.Parent = this.siticoneButton1;
			this.siticoneButton1.Size = new Size(317, 31);
			this.siticoneButton1.TabIndex = 85;
			this.siticoneButton1.Text = "Remove Reactions";
			this.siticoneButton1.TextRenderingHint = TextRenderingHint.AntiAlias;
			this.siticoneButton1.Click += this.siticoneButton1_Click;
			this.emoAsst.BorderRadius = 18;
			this.emoAsst.CheckedState.Parent = this.emoAsst;
			this.emoAsst.Cursor = Cursors.Hand;
			this.emoAsst.CustomImages.Parent = this.emoAsst;
			this.emoAsst.FillColor = Color.DodgerBlue;
			this.emoAsst.FillColor2 = Color.DeepSkyBlue;
			this.emoAsst.Font = new Font("SF Pro Text", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.emoAsst.ForeColor = Color.White;
			this.emoAsst.HoveredState.Parent = this.emoAsst;
			this.emoAsst.Image = (Image)componentResourceManager.GetObject("emoAsst.Image");
			this.emoAsst.ImageAlign = HorizontalAlignment.Right;
			this.emoAsst.ImageOffset = new Point(6, -1);
			this.emoAsst.Location = new Point(481, 189);
			this.emoAsst.Name = "emoAsst";
			this.emoAsst.ShadowDecoration.Parent = this.emoAsst;
			this.emoAsst.Size = new Size(187, 37);
			this.emoAsst.TabIndex = 103;
			this.emoAsst.Text = "Emojis";
			this.emoAsst.TextRenderingHint = TextRenderingHint.AntiAlias;
			this.emoAsst.Click += this.siticoneGradientButton4_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.emoAsst);
			base.Controls.Add(this.siticoneButton1);
			base.Controls.Add(this.xsmodeTypeEnable);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.pictureBox2);
			base.Controls.Add(this.messageId);
			base.Controls.Add(this.channelId);
			base.Controls.Add(this.sliderDelay);
			base.Controls.Add(this.hasDelay);
			base.Controls.Add(this.del);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.hasEmbed);
			base.Controls.Add(this.hasLive);
			base.Controls.Add(this.startBtn);
			base.Controls.Add(this.emot);
			base.Controls.Add(this.label1);
			base.Name = "ReactionSpammer";
			base.Size = new Size(682, 555);
			base.Load += this.ReactionSpammer_Load;
			((ISupportInitialize)this.pictureBox2).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400050A RID: 1290
		public int tt = 0;

		// Token: 0x0400050B RID: 1291
		private IContainer components = null;

		// Token: 0x0400050C RID: 1292
		private Label label1;

		// Token: 0x0400050D RID: 1293
		private SiticoneSlider sliderDelay;

		// Token: 0x0400050E RID: 1294
		private SiticoneToggleSwitch hasDelay;

		// Token: 0x0400050F RID: 1295
		private Label del;

		// Token: 0x04000510 RID: 1296
		private Label label9;

		// Token: 0x04000511 RID: 1297
		private Label label8;

		// Token: 0x04000512 RID: 1298
		private SiticoneCustomCheckBox hasEmbed;

		// Token: 0x04000513 RID: 1299
		private SiticoneCustomCheckBox hasLive;

		// Token: 0x04000514 RID: 1300
		private SiticoneButton startBtn;

		// Token: 0x04000515 RID: 1301
		private SiticoneTextBox emot;

		// Token: 0x04000516 RID: 1302
		private SiticoneTextBox channelId;

		// Token: 0x04000517 RID: 1303
		private SiticoneTextBox messageId;

		// Token: 0x04000518 RID: 1304
		private PictureBox pictureBox2;

		// Token: 0x04000519 RID: 1305
		private SiticoneDragControl siticoneDragControl1;

		// Token: 0x0400051A RID: 1306
		private SiticoneToggleSwitch xsmodeTypeEnable;

		// Token: 0x0400051B RID: 1307
		private Label label4;

		// Token: 0x0400051C RID: 1308
		private Label label3;

		// Token: 0x0400051D RID: 1309
		private SiticoneButton siticoneButton1;

		// Token: 0x0400051E RID: 1310
		private SiticoneGradientButton emoAsst;
	}
}
