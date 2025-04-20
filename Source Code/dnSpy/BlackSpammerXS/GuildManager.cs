using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrotliSharpLib;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json.Linq;
using Siticone.UI.WinForms;

namespace BlackSpammerXS
{
	// Token: 0x0200005E RID: 94
	public class GuildManager : UserControl
	{
		// Token: 0x0600019B RID: 411 RVA: 0x0001AE3A File Offset: 0x0001903A
		public GuildManager()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600019C RID: 412 RVA: 0x0001AE5C File Offset: 0x0001905C
		private void sliderThreads_Scroll(object sender, EventArgs e)
		{
			this.del.Text = "Delay: " + (this.sliderDelay.Value + 200).ToString() + "ms";
		}

		// Token: 0x0600019D RID: 413 RVA: 0x0001AEA0 File Offset: 0x000190A0
		private async void hasLive_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600019E RID: 414 RVA: 0x0001AEE8 File Offset: 0x000190E8
		private async void siticoneButton1_Click(object sender, EventArgs e)
		{
			GuildManager.<>c__DisplayClass4_0 CS$<>8__locals1 = new GuildManager.<>c__DisplayClass4_0();
			CS$<>8__locals1.<>4__this = this;
			bool flag = this.channelId.Text == "";
			if (flag)
			{
				MessageBox.Show("Server Invite or Guild ID is required", "Avviso", ContentAlignment.MiddleCenter);
			}
			else
			{
				bool flag2 = ImpostazioniGlobali.CaptchaKey_TWO == "";
				if (flag2)
				{
					this.hasCaptchaSVX.Checked = false;
				}
				this.siticoneButton1.Text = "Joining..";
				this.siticoneButton1.Enabled = false;
				bool flag3 = ImpostazioniGlobali.Tokens == null || ImpostazioniGlobali.Proxies == null;
				if (flag3)
				{
					this.siticoneButton1.Text = "Join";
					this.siticoneButton1.Enabled = true;
					MessageBox.Show("At least 1 token and 1 proxy must be imported", "Avviso", ContentAlignment.MiddleCenter);
				}
				else
				{
					ImpostazioniGlobali.StartLog();
					CS$<>8__locals1.random = new Random();
					CS$<>8__locals1.proxies = ImpostazioniGlobali.Proxies;
					CS$<>8__locals1.guildInvite = this.channelId.Text.Replace("https", "").Replace("/", "").Replace(":", "")
						.Replace("discordapp.com", "")
						.Replace(" ", "")
						.Replace("discord.gg", "")
						.Replace("discord.com", "")
						.Replace("invite", "")
						.Replace(" ", "")
						.Replace(".", "");
					ImpostazioniGlobali.Log(string.Concat(new string[]
					{
						"Manager -> (Operation Starting) Join => Joining in ",
						CS$<>8__locals1.guildInvite,
						" with ",
						CS$<>8__locals1.proxies.Count.ToString(),
						" proxies and ",
						ImpostazioniGlobali.Tokens.Count.ToString(),
						" tokens.. Delay has been set to ",
						this.sliderDelay.Value.ToString()
					}));
					CS$<>8__locals1.hasDel = this.hasDelay.Checked;
					bool flag4 = this.sliderDelay.Value == 0;
					if (flag4)
					{
						CS$<>8__locals1.hasDel = false;
						this.hasDelay.Checked = false;
					}
					bool flag5 = !ImpostazioniGlobali.UseOldParsing;
					if (flag5)
					{
						this.needParsing = true;
					}
					try
					{
						AuditManager auditManager = ImpostazioniGlobali.auditManager;
						auditManager.LogActionJoin(CS$<>8__locals1.guildInvite);
						auditManager = null;
					}
					catch (Exception)
					{
					}
					int max;
					int o;
					ThreadPool.GetMaxThreads(out max, out o);
					ThreadPool.SetMinThreads(o - 1, o - 1);
					string xcpGID = this.siticoneTextBox2.Text;
					ImpostazioniGlobali.Log("[G" + xcpGID + "] Join => XCP Status: 0");
					CS$<>8__locals1.xcp_b64 = ImpostazioniGlobali.base64_encode(ImpostazioniGlobali.XCP_Default);
					bool flag6 = xcpGID != "";
					if (flag6)
					{
						ImpostazioniGlobali.Log("[G" + xcpGID + "] Join => Generating XCP..");
						string xcpdef = ImpostazioniGlobali.XCP_Default ?? "";
						xcpdef = xcpdef.Replace(ImpostazioniGlobali.XCP_GID, xcpGID);
						string b64cdef = ImpostazioniGlobali.base64_encode(xcpdef);
						bool flag7 = b64cdef == "ERR";
						if (flag7)
						{
							ImpostazioniGlobali.Log("[G" + xcpGID + "] Join => An error has occurred while generating XCP64.");
							try
							{
								string ddt = ImpostazioniGlobali.GetReadableDateNow();
								JObject devDebug = ImpostazioniGlobali.CreateDebugAction(19, "CL+_JOIN", "GUILD_MANAGER_ERR_XCP_64", new string[]
								{
									"BUTTON_JOIN",
									"T_" + ImpostazioniGlobali.Tokens.Count.ToString() + "_P_" + ImpostazioniGlobali.Proxies.Count.ToString(),
									"CWH_CHID_P__" + CS$<>8__locals1.guildInvite,
									"CWH_CHILD_UNP__" + this.channelId.Text
								}, "GMAN_0x1_1_GJL_JN_2", ddt);
								ImpostazioniGlobali.Debug_DPut(devDebug);
								ddt = null;
								devDebug = null;
							}
							catch (Exception)
							{
							}
						}
						else
						{
							CS$<>8__locals1.xcp_b64 = b64cdef;
							ImpostazioniGlobali.Log(string.Concat(new string[]
							{
								" [G",
								xcpGID,
								"] Join => XCP was successfully generated. Length RAW: ",
								xcpdef.Length.ToString(),
								" && Length B64: ",
								b64cdef.Length.ToString()
							}));
							try
							{
								string ddt2 = ImpostazioniGlobali.GetReadableDateNow();
								JObject devDebug2 = ImpostazioniGlobali.CreateDebugAction(19, "CL+_JOIN", "GUILD_MANAGER_XCP_GEN", new string[]
								{
									"BUTTON_JOIN",
									"T_" + ImpostazioniGlobali.Tokens.Count.ToString() + "_P_" + ImpostazioniGlobali.Proxies.Count.ToString(),
									"CWH_CHID_P__" + CS$<>8__locals1.guildInvite,
									"CWH_CHILD_UNP__" + this.channelId.Text
								}, "GB64=" + CS$<>8__locals1.xcp_b64, ddt2);
								ImpostazioniGlobali.Debug_DPut(devDebug2);
								ddt2 = null;
								devDebug2 = null;
							}
							catch (Exception)
							{
							}
						}
						xcpdef = null;
						b64cdef = null;
					}
					else
					{
						ImpostazioniGlobali.Log("[G" + xcpGID + "] Join => Skipping XCP generation. Using default. Length: " + CS$<>8__locals1.xcp_b64.Length.ToString());
					}
					new Thread(delegate(object p)
					{
						using (List<string>.Enumerator enumerator = ImpostazioniGlobali.Tokens.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								GuildManager.<>c__DisplayClass4_1 CS$<>8__locals2 = new GuildManager.<>c__DisplayClass4_1();
								CS$<>8__locals2.CS$<>8__locals1 = CS$<>8__locals1;
								CS$<>8__locals2.token = enumerator.Current;
								ThreadPool.UnsafeQueueUserWorkItem(async delegate(object __M_)
								{
									GuildManager.<>c__DisplayClass4_2 CS$<>8__locals3 = new GuildManager.<>c__DisplayClass4_2();
									CS$<>8__locals3.CS$<>8__locals2 = CS$<>8__locals2;
									bool hasDel = CS$<>8__locals2.CS$<>8__locals1.hasDel;
									if (hasDel)
									{
										ImpostazioniGlobali.Log(string.Concat(new string[]
										{
											"Manager -> (Delay) (",
											CS$<>8__locals2.token,
											") Join => Awaiting ",
											CS$<>8__locals2.CS$<>8__locals1.<>4__this.sliderDelay.Value.ToString(),
											"ms of delay before joining."
										}));
										await Task.Delay(CS$<>8__locals2.CS$<>8__locals1.<>4__this.sliderDelay.Value + 200);
									}
									try
									{
										CS$<>8__locals3.proxy = CS$<>8__locals2.CS$<>8__locals1.proxies[CS$<>8__locals2.CS$<>8__locals1.random.Next(CS$<>8__locals2.CS$<>8__locals1.proxies.Count)];
									}
									catch (Exception)
									{
										CS$<>8__locals3.proxy = "Error";
									}
									try
									{
										GuildManager.<>c__DisplayClass4_3 CS$<>8__locals4 = new GuildManager.<>c__DisplayClass4_3();
										CS$<>8__locals4.CS$<>8__locals3 = CS$<>8__locals3;
										HttpClientHandler handler = new HttpClientHandler();
										handler.PreAuthenticate = true;
										handler.UseProxy = true;
										handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
										handler.Proxy = new WebProxy(CS$<>8__locals4.CS$<>8__locals3.proxy.Split(new char[] { ':' })[0], int.Parse(CS$<>8__locals4.CS$<>8__locals3.proxy.Split(new char[] { ':' })[1]));
										HttpClient http = new HttpClient(handler);
										HttpRequestMessage requestGET = new HttpRequestMessage
										{
											RequestUri = new Uri(string.Concat(new string[]
											{
												"https://discord.com/api/v9/invites/",
												CS$<>8__locals2.CS$<>8__locals1.guildInvite,
												"?inputValue=",
												CS$<>8__locals2.CS$<>8__locals1.guildInvite,
												"&with_counts=true"
											})),
											Method = HttpMethod.Get,
											Headers = 
											{
												{ "Authorization", CS$<>8__locals2.token },
												{ "Accept-Language", "it" },
												{ "User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36" },
												{ "X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9" },
												{ "Cookie", "locale=it" },
												{ "Sec-Fetch-Site", "same-origin" },
												{ "Sec-Fetch-Mode", "cors" },
												{ "Sec-Fetch-Dest", "empty" },
												{ "Referer", "https://discord.com/channels/@me" }
											}
										};
										HttpResponseMessage httpResponseMessage = await http.SendAsync(requestGET);
										string text = await httpResponseMessage.Content.ReadAsStringAsync();
										httpResponseMessage = null;
										string _erspjoin = text;
										text = null;
										if (!_erspjoin.Contains("approximate_member_count"))
										{
											ImpostazioniGlobali.Log(string.Concat(new string[]
											{
												CS$<>8__locals4.CS$<>8__locals3.proxy,
												" -> (",
												CS$<>8__locals2.token,
												") Join => Invalid GET Response: ",
												_erspjoin
											}));
											return;
										}
										_erspjoin = null;
										requestGET = null;
										HttpRequestMessage request = new HttpRequestMessage
										{
											Content = null,
											RequestUri = new Uri("https://discord.com/api/v9/invites/" + CS$<>8__locals2.CS$<>8__locals1.guildInvite),
											Method = HttpMethod.Post,
											Headers = 
											{
												{ "Authorization", CS$<>8__locals2.token },
												{ "Accept-Language", "it" },
												{ "Accept-Encoding", "gzip, deflate, br" },
												{ "User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36" },
												{ "X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiQ2hyb21lIiwiZGV2aWNlIjoiIiwic3lzdGVtX2xvY2FsZSI6Iml0LUlUIiwiYnJvd3Nlcl91c2VyX2FnZW50IjoiTW96aWxsYS81LjAgKFdpbmRvd3MgTlQgMTAuMDsgV2luNjQ7IHg2NCkgQXBwbGVXZWJLaXQvNTM3LjM2IChLSFRNTCwgbGlrZSBHZWNrbykgQ2hyb21lLzg5LjAuNDM4OS4xMjggU2FmYXJpLzUzNy4zNiIsImJyb3dzZXJfdmVyc2lvbiI6Ijg5LjAuNDM4OS4xMjgiLCJvc192ZXJzaW9uIjoiMTAiLCJyZWZlcnJlciI6Imh0dHBzOi8vd3d3Lmdvb2dsZS5jb20vIiwicmVmZXJyaW5nX2RvbWFpbiI6Ind3dy5nb29nbGUuY29tIiwic2VhcmNoX2VuZ2luZSI6Imdvb2dsZSIsInJlZmVycmVyX2N1cnJlbnQiOiIiLCJyZWZlcnJpbmdfZG9tYWluX2N1cnJlbnQiOiIiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfYnVpbGRfbnVtYmVyIjo4MjExNywiY2xpZW50X2V2ZW50X3NvdXJjZSI6bnVsbH0=" },
												{ "Accept", "*/*" },
												{ "Cookie", "locale=it" },
												{
													"X-Context-Properties",
													CS$<>8__locals2.CS$<>8__locals1.xcp_b64
												},
												{ "Connection", "keep-alive" },
												{ "Host", "discord.com" },
												{ "Origin", "https://discord.com" },
												{ "Sec-Fetch-Site", "same-origin" },
												{ "Sec-Fetch-Mode", "cors" },
												{ "Sec-Fetch-Dest", "empty" },
												{ "Referer", "https://discord.com/channels/@me" },
												{
													HttpRequestHeader.ContentLength.ToString(),
													"0"
												}
											}
										};
										HttpResponseMessage httpResponseMessage2 = await http.SendAsync(request);
										HttpResponseMessage req_jn = httpResponseMessage2;
										httpResponseMessage2 = null;
										string text2 = await req_jn.Content.ReadAsStringAsync();
										CS$<>8__locals4.rspjoin = text2;
										text2 = null;
										if (!CS$<>8__locals4.rspjoin.StartsWith("{"))
										{
											try
											{
												byte[] array = await req_jn.Content.ReadAsByteArrayAsync();
												byte[] buff_z = array;
												array = null;
												byte[] bytearr_cnt = Brotli.DecompressBuffer(buff_z, 0, buff_z.Length, null);
												CS$<>8__locals4.rspjoin = Encoding.UTF8.GetString(bytearr_cnt);
												if (CS$<>8__locals4.rspjoin.StartsWith("{\"code\":"))
												{
													ImpostazioniGlobali.Log(CS$<>8__locals4.CS$<>8__locals3.proxy + " -> (" + CS$<>8__locals2.token + ") Join => Successfully joined.");
												}
												else
												{
													ImpostazioniGlobali.Log(string.Concat(new string[]
													{
														CS$<>8__locals4.CS$<>8__locals3.proxy,
														" -> (",
														CS$<>8__locals2.token,
														") Join => ",
														CS$<>8__locals4.rspjoin
													}));
												}
												buff_z = null;
												bytearr_cnt = null;
												req_jn = null;
												buff_z = null;
												bytearr_cnt = null;
											}
											catch (Exception ex)
											{
												ImpostazioniGlobali.Log(string.Concat(new string[]
												{
													CS$<>8__locals4.CS$<>8__locals3.proxy,
													" -> (",
													CS$<>8__locals2.token,
													") Join => parse_respone ? unknown_perr[",
													ex.Message,
													"] wh_tr=br_decode"
												}));
											}
										}
										if (CS$<>8__locals2.CS$<>8__locals1.<>4__this.mbvfbypass.Checked)
										{
											if (CS$<>8__locals4.rspjoin.Contains("features") && CS$<>8__locals4.rspjoin.Contains("["))
											{
												try
												{
													ImpostazioniGlobali.Log(CS$<>8__locals4.CS$<>8__locals3.proxy + " -> (" + CS$<>8__locals2.token + ") MB Verification => Checking state..");
													object jm = JObject.Parse(CS$<>8__locals4.rspjoin);
													if (GuildManager.<>o__4.<>p__2 == null)
													{
														GuildManager.<>o__4.<>p__2 = CallSite<Func<CallSite, object, JArray>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(JArray), typeof(GuildManager)));
													}
													Func<CallSite, object, JArray> target = GuildManager.<>o__4.<>p__2.Target;
													CallSite <>p__ = GuildManager.<>o__4.<>p__2;
													if (GuildManager.<>o__4.<>p__1 == null)
													{
														GuildManager.<>o__4.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "features", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
													}
													Func<CallSite, object, object> target2 = GuildManager.<>o__4.<>p__1.Target;
													CallSite <>p__2 = GuildManager.<>o__4.<>p__1;
													if (GuildManager.<>o__4.<>p__0 == null)
													{
														GuildManager.<>o__4.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "guild", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
													}
													JArray serverFeatures0 = target(<>p__, target2(<>p__2, GuildManager.<>o__4.<>p__0.Target(GuildManager.<>o__4.<>p__0, jm)));
													string[] serverFeatures = serverFeatures0.ToObject<string[]>();
													if (GuildManager.<>o__4.<>p__3 == null)
													{
														GuildManager.<>o__4.<>p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "guild", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
													}
													object guildobj = GuildManager.<>o__4.<>p__3.Target(GuildManager.<>o__4.<>p__3, jm);
													if (GuildManager.<>o__4.<>p__5 == null)
													{
														GuildManager.<>o__4.<>p__5 = CallSite<Func<CallSite, object, long>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(long), typeof(GuildManager)));
													}
													Func<CallSite, object, long> target3 = GuildManager.<>o__4.<>p__5.Target;
													CallSite <>p__3 = GuildManager.<>o__4.<>p__5;
													if (GuildManager.<>o__4.<>p__4 == null)
													{
														GuildManager.<>o__4.<>p__4 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
													}
													long gid = target3(<>p__3, GuildManager.<>o__4.<>p__4.Target(GuildManager.<>o__4.<>p__4, guildobj));
													if (serverFeatures.Contains("MEMBER_VERIFICATION_GATE_ENABLED"))
													{
														ImpostazioniGlobali.Log(CS$<>8__locals4.CS$<>8__locals3.proxy + " -> (" + CS$<>8__locals2.token + ") MB Verification => Verification is required. Verifying...");
														string url__requestVm = "https://discord.com/api/v9/guilds/" + gid.ToString() + "/member-verification?with_guild=false&invite_code=" + CS$<>8__locals2.CS$<>8__locals1.guildInvite;
														HttpRequestMessage requestVM = new HttpRequestMessage
														{
															RequestUri = new Uri(url__requestVm),
															Method = HttpMethod.Get,
															Headers = 
															{
																{ "Authorization", CS$<>8__locals2.token },
																{ "Accept-Language", "it" },
																{ "User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36" },
																{ "X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9" },
																{ "Accept", "*/*" },
																{ "Cookie", "locale=it" },
																{
																	"Referer",
																	"https://discord.com/channels/" + gid.ToString()
																}
															}
														};
														HttpResponseMessage httpResponseMessage3 = await http.SendAsync(requestVM);
														string text3 = await httpResponseMessage3.Content.ReadAsStringAsync();
														httpResponseMessage3 = null;
														string responseVMReq = text3;
														text3 = null;
														if (!responseVMReq.Contains("version"))
														{
															throw new Exception("Cannot get panel");
														}
														ImpostazioniGlobali.Log(CS$<>8__locals4.CS$<>8__locals3.proxy + " -> (" + CS$<>8__locals2.token + ") MB Verification => Successfully Got Panel. Handling..");
														string format__ = responseVMReq;
														string[] vfrmt = format__.Split(new string[] { "}], \"description\"" }, StringSplitOptions.None);
														string prm00x = vfrmt[0] + ",\"response\":\"true\"}]}";
														HttpRequestMessage requestVMput = new HttpRequestMessage
														{
															Content = new StringContent(prm00x, Encoding.UTF8, "application/json"),
															RequestUri = new Uri("https://discord.com/api/v9/guilds/" + gid.ToString() + "/requests/@me"),
															Method = HttpMethod.Put,
															Headers = 
															{
																{ "Authorization", CS$<>8__locals2.token },
																{ "Accept-Language", "it" },
																{ "User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36" },
																{ "X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9" },
																{ "Accept", "*/*" },
																{ "Cookie", "locale=it" },
																{ "Origin", "https://discord.com" },
																{
																	"Referer",
																	"https://discord.com/channels/" + gid.ToString()
																}
															}
														};
														requestVMput.Content.Headers.Add("Content-Length", prm00x.Length.ToString() ?? "");
														HttpResponseMessage httpResponseMessage4 = await http.SendAsync(requestVMput);
														string text4 = await httpResponseMessage4.Content.ReadAsStringAsync();
														httpResponseMessage4 = null;
														string a_mvb83t = text4;
														text4 = null;
														if (a_mvb83t.Contains("APPROVED"))
														{
															ImpostazioniGlobali.Log(CS$<>8__locals4.CS$<>8__locals3.proxy + " -> (" + CS$<>8__locals2.token + ") MB Verification => Success.");
														}
														else
														{
															ImpostazioniGlobali.Log(string.Concat(new string[]
															{
																CS$<>8__locals4.CS$<>8__locals3.proxy,
																" -> (",
																CS$<>8__locals2.token,
																") MB Verification => ",
																a_mvb83t
															}));
														}
														a_mvb83t = null;
														format__ = null;
														vfrmt = null;
														prm00x = null;
														requestVMput = null;
														a_mvb83t = null;
														url__requestVm = null;
														requestVM = null;
														responseVMReq = null;
													}
													jm = null;
													serverFeatures0 = null;
													serverFeatures = null;
													guildobj = null;
												}
												catch (Exception ee)
												{
													ImpostazioniGlobali.Log(string.Concat(new string[]
													{
														CS$<>8__locals4.CS$<>8__locals3.proxy,
														" -> (",
														CS$<>8__locals2.token,
														") MB Verification => An error has occurred: ",
														ee.Message
													}));
												}
											}
										}
										if (CS$<>8__locals2.CS$<>8__locals1.<>4__this.hasCaptchaSVX.Checked)
										{
											ImpostazioniGlobali.Log(CS$<>8__locals4.CS$<>8__locals3.proxy + " -> (" + CS$<>8__locals2.token + ") SVX Captcha => Bypassing Server Captcha Bot with SVX Method.");
											Thread.Sleep(500);
											try
											{
												string ab_str = "{\"recipients\": [\"512333785338216465\"]}";
												string getRecpUrl = "https://discord.com/api/v9/users/@me/channels";
												HttpRequestMessage requestRCPput = new HttpRequestMessage
												{
													Content = new StringContent(ab_str, Encoding.UTF8, "application/json"),
													RequestUri = new Uri(getRecpUrl),
													Method = HttpMethod.Post,
													Headers = 
													{
														{ "Authorization", CS$<>8__locals2.token },
														{ "Accept-Language", "it" },
														{ "User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36" },
														{ "X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9" },
														{ "Accept", "*/*" },
														{ "Cookie", "locale=it" },
														{ "Origin", "https://discord.com" },
														{ "X-Context-Properties", "e30=" },
														{ "Referer", "https://discord.com/channels/@me" }
													}
												};
												requestRCPput.Content.Headers.Add("Content-Length", ab_str.Length.ToString() ?? "");
												HttpResponseMessage httpResponseMessage5 = await http.SendAsync(requestRCPput);
												string text5 = await httpResponseMessage5.Content.ReadAsStringAsync();
												httpResponseMessage5 = null;
												string respRecipient = text5;
												text5 = null;
												if (!respRecipient.Contains("id"))
												{
													throw new Exception("Invalid Recipient Response");
												}
												object objrespRecp = JObject.Parse(respRecipient);
												if (GuildManager.<>o__4.<>p__7 == null)
												{
													GuildManager.<>o__4.<>p__7 = CallSite<Func<CallSite, object, long>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(long), typeof(GuildManager)));
												}
												Func<CallSite, object, long> target4 = GuildManager.<>o__4.<>p__7.Target;
												CallSite <>p__4 = GuildManager.<>o__4.<>p__7;
												if (GuildManager.<>o__4.<>p__6 == null)
												{
													GuildManager.<>o__4.<>p__6 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
												}
												long recId = target4(<>p__4, GuildManager.<>o__4.<>p__6.Target(GuildManager.<>o__4.<>p__6, objrespRecp));
												ImpostazioniGlobali.Log(string.Concat(new string[]
												{
													CS$<>8__locals4.CS$<>8__locals3.proxy,
													" -> (",
													CS$<>8__locals2.token,
													") SVX Captcha => Got Recipient ID: ",
													recId.ToString()
												}));
												string dmMessagesURL = "https://discord.com/api/v9/channels/" + recId.ToString() + "/messages?limit=50";
												HttpRequestMessage reqGetDMMsgs = new HttpRequestMessage
												{
													RequestUri = new Uri(dmMessagesURL),
													Method = HttpMethod.Get,
													Headers = 
													{
														{ "Authorization", CS$<>8__locals2.token },
														{ "Accept-Language", "it" },
														{ "User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36" },
														{ "X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9" },
														{ "Accept", "*/*" },
														{ "Cookie", "locale=it" },
														{ "Referer", "https://discord.com/channels/@me" }
													}
												};
												HttpResponseMessage httpResponseMessage6 = await http.SendAsync(reqGetDMMsgs);
												string text6 = await httpResponseMessage6.Content.ReadAsStringAsync();
												httpResponseMessage6 = null;
												string raw__respDMM = text6;
												text6 = null;
												string respDMM = "{\"BLCSVXrespDM\":" + raw__respDMM + "}";
												object DMRsms = JObject.Parse(respDMM);
												if (GuildManager.<>o__4.<>p__9 == null)
												{
													GuildManager.<>o__4.<>p__9 = CallSite<Func<CallSite, object, JArray>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(JArray), typeof(GuildManager)));
												}
												Func<CallSite, object, JArray> target5 = GuildManager.<>o__4.<>p__9.Target;
												CallSite <>p__5 = GuildManager.<>o__4.<>p__9;
												if (GuildManager.<>o__4.<>p__8 == null)
												{
													GuildManager.<>o__4.<>p__8 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "BLCSVXrespDM", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
												}
												JArray __dm_array = target5(<>p__5, GuildManager.<>o__4.<>p__8.Target(GuildManager.<>o__4.<>p__8, DMRsms));
												JObject[] __jobjs = __dm_array.ToObject<JObject[]>();
												JObject latestMessageSVX = __jobjs[0];
												string SVXfinalMsg = latestMessageSVX.ToString();
												int indexWhereHTTP = SVXfinalMsg.IndexOf("https");
												int indexWherePNG = SVXfinalMsg.IndexOf(".png");
												string SVXcaptchaURL = SVXfinalMsg.Substring(indexWhereHTTP, indexWherePNG - indexWhereHTTP) + ".png";
												ImpostazioniGlobali.Log(string.Concat(new string[]
												{
													CS$<>8__locals4.CS$<>8__locals3.proxy,
													" -> (",
													CS$<>8__locals2.token,
													") SVX Captcha => Got Image URL: ",
													SVXcaptchaURL
												}));
												TwoCaptchaHandler captchaHandler = new TwoCaptchaHandler(ImpostazioniGlobali.CaptchaKey_TWO);
												ImpostazioniGlobali.Log(CS$<>8__locals4.CS$<>8__locals3.proxy + " -> (" + CS$<>8__locals2.token + ") SVX Captcha => Downloading Base64 Image and Submitting Captcha to 2Captcha..");
												string text7 = await captchaHandler.ResolveImageCaptcha(SVXcaptchaURL);
												string resolvedResult = text7;
												text7 = null;
												if (resolvedResult == "ERROR")
												{
													throw new Exception("An error has occurred while resolving captcha with 2captcha.");
												}
												ImpostazioniGlobali.Log(string.Concat(new string[]
												{
													CS$<>8__locals4.CS$<>8__locals3.proxy,
													" -> (",
													CS$<>8__locals2.token,
													") SVX Captcha => 2CAPTCHA: Captcha has been resolved! Result: ",
													resolvedResult
												}));
												ImpostazioniGlobali.Log(CS$<>8__locals4.CS$<>8__locals3.proxy + " -> (" + CS$<>8__locals2.token + ") SVX Captcha => Submitting Result...");
												string cnn_sv = "{\"content\": \"" + resolvedResult + "\", \"nonce\": null, \"tts\": false}";
												StringContent content_ac_dm_svx = new StringContent(cnn_sv, Encoding.UTF8, "application/json");
												string submitMsgRESCap = "https://discord.com/api/v9/channels/" + recId.ToString() + "/messages";
												HttpRequestMessage resCAP = new HttpRequestMessage
												{
													Content = content_ac_dm_svx,
													RequestUri = new Uri(submitMsgRESCap),
													Method = HttpMethod.Post,
													Headers = 
													{
														{ "Authorization", CS$<>8__locals2.token },
														{ "Accept-Language", "it" },
														{ "User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36" },
														{ "X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9" },
														{ "Accept", "*/*" },
														{ "Cookie", "locale=it" },
														{ "Origin", "https://discord.com" },
														{
															"Referer",
															"https://discord.com/channels/" + recId.ToString()
														},
														{
															HttpRequestHeader.ContentLength.ToString(),
															cnn_sv.Length.ToString() ?? ""
														}
													}
												};
												HttpResponseMessage httpResponseMessage7 = await http.SendAsync(resCAP);
												string text8 = await httpResponseMessage7.Content.ReadAsStringAsync();
												httpResponseMessage7 = null;
												string respCAPSub = text8;
												text8 = null;
												bool wasSVXsuccess = false;
												if (respCAPSub.Contains("id"))
												{
													wasSVXsuccess = true;
												}
												ImpostazioniGlobali.Log(string.Concat(new string[]
												{
													CS$<>8__locals4.CS$<>8__locals3.proxy,
													" -> (",
													CS$<>8__locals2.token,
													") SVX Captcha => Submit: ",
													respCAPSub
												}));
												Thread.Sleep(100);
												if (wasSVXsuccess)
												{
													ImpostazioniGlobali.Log(CS$<>8__locals4.CS$<>8__locals3.proxy + " -> (" + CS$<>8__locals2.token + ") SVX Captcha => Captcha was completed successfully.");
												}
												else
												{
													ImpostazioniGlobali.Log(CS$<>8__locals4.CS$<>8__locals3.proxy + " -> (" + CS$<>8__locals2.token + ") SVX Captcha => Unable to complete the captcha.");
												}
												cnn_sv = null;
												content_ac_dm_svx = null;
												submitMsgRESCap = null;
												resCAP = null;
												respCAPSub = null;
												objrespRecp = null;
												dmMessagesURL = null;
												reqGetDMMsgs = null;
												raw__respDMM = null;
												respDMM = null;
												DMRsms = null;
												__dm_array = null;
												__jobjs = null;
												latestMessageSVX = null;
												SVXfinalMsg = null;
												SVXcaptchaURL = null;
												captchaHandler = null;
												resolvedResult = null;
												ab_str = null;
												getRecpUrl = null;
												requestRCPput = null;
												respRecipient = null;
											}
											catch (Exception ed)
											{
												ImpostazioniGlobali.Log(string.Concat(new string[]
												{
													CS$<>8__locals4.CS$<>8__locals3.proxy,
													" -> (",
													CS$<>8__locals2.token,
													") SVX Captcha => An error has occurred: ",
													ed.Message
												}));
											}
										}
										if (CS$<>8__locals2.CS$<>8__locals1.<>4__this.needParsing)
										{
											ImpostazioniGlobali._bridgeGS(1, 0, null);
											CS$<>8__locals2.CS$<>8__locals1.<>4__this.needParsing = false;
											new Thread(delegate(object nnnn)
											{
												CS$<>8__locals4.CS$<>8__locals3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.MassTagV2XParse(CS$<>8__locals4.rspjoin, CS$<>8__locals4.CS$<>8__locals3.CS$<>8__locals2.token, CS$<>8__locals4.CS$<>8__locals3.proxy);
											}).Start();
										}
										CS$<>8__locals4 = null;
										handler = null;
										http = null;
										requestGET = null;
										_erspjoin = null;
										request = null;
										req_jn = null;
									}
									catch (Exception)
									{
										if (ImpostazioniGlobali.StreamerMode)
										{
											ImpostazioniGlobali.Log(CS$<>8__locals3.proxy + " -> (Token " + ImpostazioniGlobali.Tokens.IndexOf(CS$<>8__locals2.token).ToString() + ") Join => Unknown Error [Check your proxies]");
										}
										else
										{
											ImpostazioniGlobali.Log(CS$<>8__locals3.proxy + " -> (" + CS$<>8__locals2.token + ") Join => Unknown Error [Check your proxies]");
										}
									}
									try
									{
										Thread.CurrentThread.Interrupt();
									}
									catch
									{
									}
								}, null);
							}
						}
					}).Start();
					this.siticoneButton1.Text = "Join";
					this.siticoneButton1.Enabled = true;
				}
			}
		}

		// Token: 0x0600019F RID: 415 RVA: 0x0001AF30 File Offset: 0x00019130
		private async void MassTagV3(string joinResponse, string token, string proxy)
		{
			GuildManager.<>c__DisplayClass5_0 CS$<>8__locals1 = new GuildManager.<>c__DisplayClass5_0();
			CS$<>8__locals1.proxy = proxy;
			CS$<>8__locals1.token = token;
			bool flag = !ImpostazioniGlobali.AutoParse;
			if (flag)
			{
				ImpostazioniGlobali.Log(CS$<>8__locals1.proxy + " -> (" + CS$<>8__locals1.token + ") MassV3X => Skipping parsing as requested by the user.");
			}
			else
			{
				try
				{
					bool flag2 = joinResponse.Contains("id") && joinResponse.Contains("{");
					if (!flag2)
					{
						throw new Exception("Invalid join response");
					}
					GuildManager.<>c__DisplayClass5_1 CS$<>8__locals2 = new GuildManager.<>c__DisplayClass5_1();
					CS$<>8__locals2.CS$<>8__locals1 = CS$<>8__locals1;
					object jm = JObject.Parse(joinResponse);
					if (GuildManager.<>o__5.<>p__0 == null)
					{
						GuildManager.<>o__5.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "guild", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					object guildobj = GuildManager.<>o__5.<>p__0.Target(GuildManager.<>o__5.<>p__0, jm);
					GuildManager.<>c__DisplayClass5_1 CS$<>8__locals3 = CS$<>8__locals2;
					if (GuildManager.<>o__5.<>p__2 == null)
					{
						GuildManager.<>o__5.<>p__2 = CallSite<Func<CallSite, object, long>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(long), typeof(GuildManager)));
					}
					Func<CallSite, object, long> target = GuildManager.<>o__5.<>p__2.Target;
					CallSite <>p__ = GuildManager.<>o__5.<>p__2;
					if (GuildManager.<>o__5.<>p__1 == null)
					{
						GuildManager.<>o__5.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					CS$<>8__locals3.gid = target(<>p__, GuildManager.<>o__5.<>p__1.Target(GuildManager.<>o__5.<>p__1, guildobj));
					HttpClientHandler handler = new HttpClientHandler();
					handler.PreAuthenticate = true;
					handler.UseProxy = true;
					handler.Proxy = new WebProxy(CS$<>8__locals2.CS$<>8__locals1.proxy.Split(new char[] { ':' })[0], int.Parse(CS$<>8__locals2.CS$<>8__locals1.proxy.Split(new char[] { ':' })[1]));
					CS$<>8__locals2.http = new HttpClient(handler);
					ImpostazioniGlobali.Log(string.Concat(new string[]
					{
						CS$<>8__locals2.CS$<>8__locals1.proxy,
						" -> (",
						CS$<>8__locals2.CS$<>8__locals1.token,
						") [",
						CS$<>8__locals2.gid.ToString(),
						"] MassV3X => Parsing Guild ",
						CS$<>8__locals2.gid.ToString(),
						".."
					}));
					ImpostazioniGlobali.Log(string.Concat(new string[]
					{
						CS$<>8__locals2.CS$<>8__locals1.proxy,
						" -> (",
						CS$<>8__locals2.CS$<>8__locals1.token,
						") [",
						CS$<>8__locals2.gid.ToString(),
						"] MassV3X => Starting websocket.."
					}));
					BlackWSManager blackWS = new BlackWSManager(CS$<>8__locals2.CS$<>8__locals1.token, CS$<>8__locals2.CS$<>8__locals1.proxy);
					blackWS.connect();
					bool flag3 = await blackWS.WaitForData(2500);
					bool flag4 = flag3;
					if (flag4)
					{
						ImpostazioniGlobali.Log(string.Concat(new string[]
						{
							CS$<>8__locals2.CS$<>8__locals1.proxy,
							" -> (",
							CS$<>8__locals2.CS$<>8__locals1.token,
							") [",
							CS$<>8__locals2.gid.ToString(),
							"] MassV3X => Got data from websocket. Guilds: ",
							blackWS.GetGuilds().Count.ToString()
						}));
					}
					else
					{
						ImpostazioniGlobali.Log(string.Concat(new string[]
						{
							CS$<>8__locals2.CS$<>8__locals1.proxy,
							" -> (",
							CS$<>8__locals2.CS$<>8__locals1.token,
							") [",
							CS$<>8__locals2.gid.ToString(),
							"] MassV3X => An error with the websocket has occurred. No data received."
						}));
					}
					GuildChannels thisGuildChannel = null;
					foreach (GuildChannels gc in blackWS.GetGuilds())
					{
						if (gc.GetGuildId() == CS$<>8__locals2.gid.ToString())
						{
							thisGuildChannel = gc;
						}
						gc = null;
					}
					List<GuildChannels>.Enumerator enumerator = default(List<GuildChannels>.Enumerator);
					if (thisGuildChannel == null)
					{
						ImpostazioniGlobali.Log(string.Concat(new string[]
						{
							CS$<>8__locals2.CS$<>8__locals1.proxy,
							" -> (",
							CS$<>8__locals2.CS$<>8__locals1.token,
							") [",
							CS$<>8__locals2.gid.ToString(),
							"] MassV3X => WS Error: No guild with ID ",
							CS$<>8__locals2.gid.ToString(),
							" got from READY payload."
						}));
					}
					else
					{
						using (List<GChannel>.Enumerator enumerator2 = thisGuildChannel.GetChannels().GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								GuildManager.<>c__DisplayClass5_2 CS$<>8__locals4 = new GuildManager.<>c__DisplayClass5_2();
								CS$<>8__locals4.CS$<>8__locals2 = CS$<>8__locals2;
								CS$<>8__locals4.channel = enumerator2.Current;
								if (CS$<>8__locals4.channel.GetChannelType() == ChannelType.TESTUALE)
								{
									new Thread(async delegate(object a__)
									{
										try
										{
											ImpostazioniGlobali.Log(string.Concat(new string[]
											{
												CS$<>8__locals4.CS$<>8__locals2.CS$<>8__locals1.proxy,
												" -> (",
												CS$<>8__locals4.CS$<>8__locals2.CS$<>8__locals1.token,
												") [",
												CS$<>8__locals4.CS$<>8__locals2.gid.ToString(),
												"] MassV3X => Got #",
												CS$<>8__locals4.channel.GetName(),
												" with ID ",
												CS$<>8__locals4.channel.GetId(),
												" from websocket READY payload."
											}));
											string messageGetURL = "https://discord.com/api/v9/channels/" + CS$<>8__locals4.channel.GetName() + "/messages?limit=50";
											HttpRequestMessage requestMessages = new HttpRequestMessage
											{
												RequestUri = new Uri(messageGetURL),
												Method = HttpMethod.Get,
												Headers = 
												{
													{
														"Authorization",
														CS$<>8__locals4.CS$<>8__locals2.CS$<>8__locals1.token
													},
													{ "Accept-Language", "it" },
													{ "User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36" },
													{ "X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9" },
													{ "Accept", "*/*" },
													{ "Cookie", "locale=it" },
													{ "Referer", "https://discord.com/channels/@me" }
												}
											};
											HttpResponseMessage httpResponseMessage = await CS$<>8__locals4.CS$<>8__locals2.http.SendAsync(requestMessages);
											string text = await httpResponseMessage.Content.ReadAsStringAsync();
											httpResponseMessage = null;
											string respCHMessages = text;
											text = null;
											if (!(respCHMessages == "[]"))
											{
												JArray messagesArr = JArray.Parse(respCHMessages);
												JObject[] jMObjects = messagesArr.ToObject<JObject[]>();
												foreach (JObject objMsgCH in jMObjects)
												{
													if (GuildManager.<>o__5.<>p__5 == null)
													{
														GuildManager.<>o__5.<>p__5 = CallSite<Action<CallSite, Action<int, int, object>, int, int, object>>.Create(Binder.Invoke(CSharpBinderFlags.ResultDiscarded, typeof(GuildManager), new CSharpArgumentInfo[]
														{
															CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
															CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
															CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
															CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
														}));
													}
													Action<CallSite, Action<int, int, object>, int, int, object> target2 = GuildManager.<>o__5.<>p__5.Target;
													CallSite <>p__2 = GuildManager.<>o__5.<>p__5;
													Action<int, int, object> bridgeGS = ImpostazioniGlobali._bridgeGS;
													int num = 1;
													int num2 = 1;
													if (GuildManager.<>o__5.<>p__4 == null)
													{
														GuildManager.<>o__5.<>p__4 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
													}
													Func<CallSite, object, object> target3 = GuildManager.<>o__5.<>p__4.Target;
													CallSite <>p__3 = GuildManager.<>o__5.<>p__4;
													if (GuildManager.<>o__5.<>p__3 == null)
													{
														GuildManager.<>o__5.<>p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "author", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
													}
													target2(<>p__2, bridgeGS, num, num2, target3(<>p__3, GuildManager.<>o__5.<>p__3.Target(GuildManager.<>o__5.<>p__3, objMsgCH)));
													objMsgCH = null;
												}
												JObject[] array = null;
												object __lastMsg = jMObjects[jMObjects.Length - 1];
												if (GuildManager.<>o__5.<>p__7 == null)
												{
													GuildManager.<>o__5.<>p__7 = CallSite<Func<CallSite, object, long>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(long), typeof(GuildManager)));
												}
												Func<CallSite, object, long> target4 = GuildManager.<>o__5.<>p__7.Target;
												CallSite <>p__4 = GuildManager.<>o__5.<>p__7;
												if (GuildManager.<>o__5.<>p__6 == null)
												{
													GuildManager.<>o__5.<>p__6 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
												}
												long __lastId = target4(<>p__4, GuildManager.<>o__5.<>p__6.Target(GuildManager.<>o__5.<>p__6, __lastMsg));
												string beforeURL = string.Concat(new string[]
												{
													"https://discord.com/api/v9/channels/",
													CS$<>8__locals4.channel.GetName(),
													"/messages?before=",
													__lastId.ToString(),
													"&limit=50"
												});
												HttpRequestMessage requestMessagesBefore = new HttpRequestMessage
												{
													RequestUri = new Uri(beforeURL),
													Method = HttpMethod.Get,
													Headers = 
													{
														{
															"Authorization",
															CS$<>8__locals4.CS$<>8__locals2.CS$<>8__locals1.token
														},
														{ "Accept-Language", "it" },
														{ "User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36" },
														{ "X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9" },
														{ "Accept", "*/*" },
														{ "Cookie", "locale=it" },
														{
															"Referer",
															"https://discord.com/channels/" + CS$<>8__locals4.channel.GetId()
														}
													}
												};
												HttpResponseMessage httpResponseMessage2 = await CS$<>8__locals4.CS$<>8__locals2.http.SendAsync(requestMessagesBefore);
												string text2 = await httpResponseMessage2.Content.ReadAsStringAsync();
												httpResponseMessage2 = null;
												string respCHMessages2 = text2;
												text2 = null;
												if (!(respCHMessages2 == "[]"))
												{
													JArray messagesArr2 = JArray.Parse(respCHMessages2);
													JObject[] jMObjects2 = messagesArr.ToObject<JObject[]>();
													foreach (JObject objMsgCH2 in jMObjects2)
													{
														if (GuildManager.<>o__5.<>p__10 == null)
														{
															GuildManager.<>o__5.<>p__10 = CallSite<Action<CallSite, Action<int, int, object>, int, int, object>>.Create(Binder.Invoke(CSharpBinderFlags.ResultDiscarded, typeof(GuildManager), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
															}));
														}
														Action<CallSite, Action<int, int, object>, int, int, object> target5 = GuildManager.<>o__5.<>p__10.Target;
														CallSite <>p__5 = GuildManager.<>o__5.<>p__10;
														Action<int, int, object> bridgeGS2 = ImpostazioniGlobali._bridgeGS;
														int num3 = 1;
														int num4 = 1;
														if (GuildManager.<>o__5.<>p__9 == null)
														{
															GuildManager.<>o__5.<>p__9 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
														}
														Func<CallSite, object, object> target6 = GuildManager.<>o__5.<>p__9.Target;
														CallSite <>p__6 = GuildManager.<>o__5.<>p__9;
														if (GuildManager.<>o__5.<>p__8 == null)
														{
															GuildManager.<>o__5.<>p__8 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "author", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
														}
														target5(<>p__5, bridgeGS2, num3, num4, target6(<>p__6, GuildManager.<>o__5.<>p__8.Target(GuildManager.<>o__5.<>p__8, objMsgCH2)));
														objMsgCH2 = null;
													}
													JObject[] array2 = null;
													ImpostazioniGlobali.Log(string.Concat(new string[]
													{
														CS$<>8__locals4.CS$<>8__locals2.CS$<>8__locals1.proxy,
														" -> (",
														CS$<>8__locals4.CS$<>8__locals2.CS$<>8__locals1.token,
														") [",
														CS$<>8__locals4.CS$<>8__locals2.gid.ToString(),
														"] MassV3X => #",
														CS$<>8__locals4.channel.GetName(),
														" {",
														CS$<>8__locals4.channel.GetId(),
														"} has been successfully parsed!"
													}));
													messageGetURL = null;
													requestMessages = null;
													respCHMessages = null;
													messagesArr = null;
													jMObjects = null;
													__lastMsg = null;
													beforeURL = null;
													requestMessagesBefore = null;
													respCHMessages2 = null;
													jMObjects2 = null;
												}
											}
										}
										catch (Exception err)
										{
											if (err.Message == "Error reading JArray from JsonReader. Current JsonReader item is not an array: StartObject. Path '', line 1, position 1." || err.Message.StartsWith("Error reading JArray from JsonReader. Current JsonReader"))
											{
												ImpostazioniGlobali.Log(string.Concat(new string[]
												{
													CS$<>8__locals4.CS$<>8__locals2.CS$<>8__locals1.proxy,
													" -> (",
													CS$<>8__locals4.CS$<>8__locals2.CS$<>8__locals1.token,
													") [",
													CS$<>8__locals4.CS$<>8__locals2.gid.ToString(),
													"] MassV3X => Il canale #",
													CS$<>8__locals4.channel.GetName(),
													" with ID ",
													CS$<>8__locals4.channel.GetId(),
													" è privato e peranto è stato skippato!"
												}));
											}
											else
											{
												ImpostazioniGlobali.Log(string.Concat(new string[]
												{
													CS$<>8__locals4.CS$<>8__locals2.CS$<>8__locals1.proxy,
													" -> (",
													CS$<>8__locals4.CS$<>8__locals2.CS$<>8__locals1.token,
													") [",
													CS$<>8__locals4.CS$<>8__locals2.gid.ToString(),
													"] MassV3X => An error has occurred with channel #",
													CS$<>8__locals4.channel.GetName(),
													" with ID ",
													CS$<>8__locals4.channel.GetId(),
													": ",
													err.Message
												}));
											}
										}
									}).Start();
								}
								CS$<>8__locals4 = null;
							}
						}
						List<GChannel>.Enumerator enumerator2 = default(List<GChannel>.Enumerator);
						CS$<>8__locals2 = null;
						jm = null;
						guildobj = null;
						handler = null;
						blackWS = null;
						thisGuildChannel = null;
					}
				}
				catch (Exception ex)
				{
					ImpostazioniGlobali.Log("MassV3X => Errore durante il parsing: " + ex.Message);
				}
			}
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x0001AF80 File Offset: 0x00019180
		private async void startBtn_Click(object sender, EventArgs e)
		{
			bool flag = this.channelId.Text == "";
			if (flag)
			{
				MessageBox.Show("A valid Server ID is required", "Avviso", ContentAlignment.MiddleCenter);
			}
			else
			{
				this.startBtn.Text = "Leaving..";
				this.startBtn.Enabled = false;
				bool flag2 = ImpostazioniGlobali.Tokens == null || ImpostazioniGlobali.Proxies == null;
				if (flag2)
				{
					this.startBtn.Text = "Leave";
					this.startBtn.Enabled = true;
					MessageBox.Show("You must import at least 1 token and 1 proxy", "Avviso", ContentAlignment.MiddleCenter);
				}
				else
				{
					ImpostazioniGlobali.StartLog();
					Random random = new Random();
					List<string> proxies = ImpostazioniGlobali.Proxies;
					string guildInvite = this.channelId.Text;
					ImpostazioniGlobali.Log(string.Concat(new string[]
					{
						"Manager -> (Operation Starting) Leave => Leaving in ",
						guildInvite,
						" with ",
						proxies.Count.ToString(),
						" proxies and ",
						ImpostazioniGlobali.Tokens.Count.ToString(),
						" tokens.. Delay has been set to ",
						this.sliderDelay.Value.ToString()
					}));
					bool hasDel = this.hasDelay.Checked;
					bool flag3 = this.sliderDelay.Value == 0;
					if (flag3)
					{
						hasDel = false;
						this.hasDelay.Checked = false;
					}
					int max;
					int o;
					ThreadPool.GetMaxThreads(out max, out o);
					ThreadPool.SetMinThreads(o - 1, o - 1);
					try
					{
						AuditManager auditManager = ImpostazioniGlobali.auditManager;
						auditManager.LogActionLeave(this.channelId.Text);
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
								ThreadPool.UnsafeQueueUserWorkItem(async delegate(object mn)
								{
									bool hasDel2 = hasDel;
									if (hasDel2)
									{
										ImpostazioniGlobali.Log(string.Concat(new string[]
										{
											"Manager -> (Delay) (",
											token,
											") Leave => Awaiting ",
											this.sliderDelay.Value.ToString(),
											"ms of delay before leaving."
										}));
										Thread.Sleep(this.sliderDelay.Value + 200);
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
										string urlLeave = "https://discord.com/api/v9/users/@me/guilds/" + guildInvite;
										bool @checked = this.hasPCM.Checked;
										if (@checked)
										{
											ImpostazioniGlobali.Log("Manager => [PCM] Mode is enabled. Using /channels/ endpoint..");
											urlLeave = "https://discord.com/api/v9/channels/" + guildInvite;
										}
										HttpClientHandler handler = new HttpClientHandler();
										handler.PreAuthenticate = true;
										handler.UseProxy = true;
										handler.Proxy = new WebProxy(proxy.Split(new char[] { ':' })[0], int.Parse(proxy.Split(new char[] { ':' })[1]));
										HttpClient http = new HttpClient(handler);
										HttpRequestMessage request = new HttpRequestMessage
										{
											RequestUri = new Uri(urlLeave),
											Method = HttpMethod.Delete,
											Headers = 
											{
												{ "Authorization", token },
												{ "Accept-Language", "it" },
												{ "User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36" },
												{ "X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9" },
												{ "Accept", "*/*" },
												{ "Cookie", "locale=it" },
												{ "Origin", "https://discord.com" },
												{ "Referer", "https://discord.com/channels/@me" }
											}
										};
										HttpResponseMessage httpResponseMessage = await http.SendAsync(request);
										string text = await httpResponseMessage.Content.ReadAsStringAsync();
										httpResponseMessage = null;
										string _r = text;
										text = null;
										if (_r == "")
										{
											_r = "Successfully Leaved";
										}
										if (ImpostazioniGlobali.StreamerMode)
										{
											ImpostazioniGlobali.Log(string.Concat(new string[]
											{
												proxy,
												" -> (Token ",
												ImpostazioniGlobali.Tokens.IndexOf(token).ToString(),
												") Leave => ",
												_r
											}));
										}
										else
										{
											ImpostazioniGlobali.Log(string.Concat(new string[] { proxy, " -> (", token, ") Leave => ", _r }));
										}
										_r = null;
										http = null;
										handler = null;
										urlLeave = null;
										proxy = null;
										request = null;
										urlLeave = null;
										handler = null;
										http = null;
										request = null;
										_r = null;
									}
									catch (Exception exc)
									{
										if (exc.GetType() == typeof(ThreadAbortException))
										{
											exc = null;
											return;
										}
										if (ImpostazioniGlobali.StreamerMode)
										{
											ImpostazioniGlobali.Log(proxy + " -> (Token " + ImpostazioniGlobali.Tokens.IndexOf(token).ToString() + ") Leave => Unknown Error [Check your proxies]");
										}
										else
										{
											ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Leave => Unknown Error [Check your proxies]");
										}
										exc = null;
									}
									try
									{
										Thread.CurrentThread.Abort();
									}
									catch
									{
									}
								}, null);
							}
						}
					}).Start();
					this.startBtn.Text = "Leave";
					this.startBtn.Enabled = true;
				}
			}
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x0001AFC8 File Offset: 0x000191C8
		private void siticoneButton1_MouseEnter(object sender, EventArgs e)
		{
			try
			{
				SiticoneButton siticoneButton = (SiticoneButton)sender;
				bool flag = siticoneButton != null;
				if (flag)
				{
					siticoneButton.BorderThickness = 1;
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x0001B008 File Offset: 0x00019208
		private void siticoneButton1_MouseLeave(object sender, EventArgs e)
		{
			try
			{
				SiticoneButton siticoneButton = (SiticoneButton)sender;
				bool flag = siticoneButton != null;
				if (flag)
				{
					siticoneButton.BorderThickness = 1;
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x0001B048 File Offset: 0x00019248
		public void Dark()
		{
			Color color = Color.FromArgb(44, 47, 51);
			this.BackColor = color;
			Color dimGray = Color.DimGray;
			try
			{
				foreach (SiticoneButton siticoneButton in new List<SiticoneButton> { this.siticoneButton1, this.startBtn })
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
				this.siticoneTextBox1.ForeColor = Color.White;
				this.siticoneTextBox1.FillColor = color;
				this.siticoneTextBox1.BorderColor = Color.Gray;
				this.siticoneTextBox1.HoveredState.BorderColor = Color.Gray;
				this.siticoneTextBox2.ForeColor = Color.White;
				this.siticoneTextBox2.FillColor = color;
				this.siticoneTextBox2.BorderColor = Color.Gray;
				this.siticoneTextBox2.HoveredState.BorderColor = Color.Gray;
				this.sliderDelay.FillColor = Color.Gray;
				this.sliderDelay.ThumbColor = Color.RoyalBlue;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x0001B234 File Offset: 0x00019434
		private async Task MassTagV2XParse(string joinResponse, string token, string proxy)
		{
			GuildManager.<>c__DisplayClass10_0 CS$<>8__locals1 = new GuildManager.<>c__DisplayClass10_0();
			CS$<>8__locals1.proxy = proxy;
			CS$<>8__locals1.token = token;
			bool flag = !ImpostazioniGlobali.AutoParse;
			if (flag)
			{
				ImpostazioniGlobali.Log(CS$<>8__locals1.proxy + " -> (" + CS$<>8__locals1.token + ") MassV2X => Skipping parsing as requested by the user.");
			}
			else
			{
				try
				{
					bool flag2 = joinResponse.Contains("id") && joinResponse.Contains("{");
					if (!flag2)
					{
						throw new Exception("Invalid join response");
					}
					GuildManager.<>c__DisplayClass10_1 CS$<>8__locals2 = new GuildManager.<>c__DisplayClass10_1();
					CS$<>8__locals2.CS$<>8__locals1 = CS$<>8__locals1;
					CS$<>8__locals2.jm = JObject.Parse(joinResponse);
					GuildManager.<>c__DisplayClass10_1 CS$<>8__locals3 = CS$<>8__locals2;
					if (GuildManager.<>o__10.<>p__0 == null)
					{
						GuildManager.<>o__10.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "guild", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					CS$<>8__locals3.guildobj = GuildManager.<>o__10.<>p__0.Target(GuildManager.<>o__10.<>p__0, CS$<>8__locals2.jm);
					GuildManager.<>c__DisplayClass10_1 CS$<>8__locals4 = CS$<>8__locals2;
					if (GuildManager.<>o__10.<>p__2 == null)
					{
						GuildManager.<>o__10.<>p__2 = CallSite<Func<CallSite, object, long>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(long), typeof(GuildManager)));
					}
					Func<CallSite, object, long> target = GuildManager.<>o__10.<>p__2.Target;
					CallSite <>p__ = GuildManager.<>o__10.<>p__2;
					if (GuildManager.<>o__10.<>p__1 == null)
					{
						GuildManager.<>o__10.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					CS$<>8__locals4.gid = target(<>p__, GuildManager.<>o__10.<>p__1.Target(GuildManager.<>o__10.<>p__1, CS$<>8__locals2.guildobj));
					CS$<>8__locals2.handler = new HttpClientHandler();
					CS$<>8__locals2.handler.PreAuthenticate = true;
					CS$<>8__locals2.handler.UseProxy = true;
					CS$<>8__locals2.handler.Proxy = new WebProxy(CS$<>8__locals2.CS$<>8__locals1.proxy.Split(new char[] { ':' })[0], int.Parse(CS$<>8__locals2.CS$<>8__locals1.proxy.Split(new char[] { ':' })[1]));
					CS$<>8__locals2.http = new HttpClient(CS$<>8__locals2.handler);
					ImpostazioniGlobali.Log(string.Concat(new string[]
					{
						CS$<>8__locals2.CS$<>8__locals1.proxy,
						" -> (",
						CS$<>8__locals2.CS$<>8__locals1.token,
						") [",
						CS$<>8__locals2.gid.ToString(),
						"] MassV2X => Parsing Guild ",
						CS$<>8__locals2.gid.ToString(),
						".."
					}));
					ImpostazioniGlobali.Log(string.Concat(new string[]
					{
						CS$<>8__locals2.CS$<>8__locals1.proxy,
						" -> (",
						CS$<>8__locals2.CS$<>8__locals1.token,
						") [",
						CS$<>8__locals2.gid.ToString(),
						"] MassV2X => Getting channels..."
					}));
					CS$<>8__locals2.URL_channels = "https://discord.com/api/v9/guilds/" + CS$<>8__locals2.gid.ToString() + "/channels";
					CS$<>8__locals2.requestChannels = new HttpRequestMessage
					{
						RequestUri = new Uri(CS$<>8__locals2.URL_channels),
						Method = HttpMethod.Get,
						Headers = 
						{
							{
								"Authorization",
								CS$<>8__locals2.CS$<>8__locals1.token
							},
							{ "Accept-Language", "it" },
							{ "User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36" },
							{ "X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9" },
							{ "Accept", "*/*" },
							{ "Cookie", "locale=it" },
							{ "Connection", "keep-alive" },
							{ "Host", "discord.com" },
							{ "Referer", "https://discord.com/channels/@me" }
						}
					};
					HttpResponseMessage httpResponseMessage = await CS$<>8__locals2.http.SendAsync(CS$<>8__locals2.requestChannels);
					string text = await httpResponseMessage.Content.ReadAsStringAsync();
					httpResponseMessage = null;
					CS$<>8__locals2.respGLChannels = text;
					text = null;
					CS$<>8__locals2.obArr = JArray.Parse(CS$<>8__locals2.respGLChannels);
					CS$<>8__locals2.jObjects = CS$<>8__locals2.obArr.ToObject<JObject[]>();
					JObject[] array = CS$<>8__locals2.jObjects;
					for (int i = 0; i < array.Length; i++)
					{
						GuildManager.<>c__DisplayClass10_2 CS$<>8__locals5 = new GuildManager.<>c__DisplayClass10_2();
						CS$<>8__locals5.CS$<>8__locals2 = CS$<>8__locals2;
						CS$<>8__locals5.objsch = array[i];
						if (GuildManager.<>o__10.<>p__5 == null)
						{
							GuildManager.<>o__10.<>p__5 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, bool> target2 = GuildManager.<>o__10.<>p__5.Target;
						CallSite <>p__2 = GuildManager.<>o__10.<>p__5;
						if (GuildManager.<>o__10.<>p__4 == null)
						{
							GuildManager.<>o__10.<>p__4 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(GuildManager), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						Func<CallSite, object, int, object> target3 = GuildManager.<>o__10.<>p__4.Target;
						CallSite <>p__3 = GuildManager.<>o__10.<>p__4;
						if (GuildManager.<>o__10.<>p__3 == null)
						{
							GuildManager.<>o__10.<>p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "type", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						if (target2(<>p__2, target3(<>p__3, GuildManager.<>o__10.<>p__3.Target(GuildManager.<>o__10.<>p__3, CS$<>8__locals5.objsch), 0)))
						{
							new Thread(async delegate(object a__)
							{
								try
								{
									if (GuildManager.<>o__10.<>p__11 == null)
									{
										GuildManager.<>o__10.<>p__11 = CallSite<Action<CallSite, Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Log", null, typeof(GuildManager), new CSharpArgumentInfo[]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
										}));
									}
									Action<CallSite, Type, object> target4 = GuildManager.<>o__10.<>p__11.Target;
									CallSite <>p__4 = GuildManager.<>o__10.<>p__11;
									Type typeFromHandle = typeof(ImpostazioniGlobali);
									if (GuildManager.<>o__10.<>p__10 == null)
									{
										GuildManager.<>o__10.<>p__10 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(GuildManager), new CSharpArgumentInfo[]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
										}));
									}
									Func<CallSite, object, object, object> target5 = GuildManager.<>o__10.<>p__10.Target;
									CallSite <>p__5 = GuildManager.<>o__10.<>p__10;
									if (GuildManager.<>o__10.<>p__8 == null)
									{
										GuildManager.<>o__10.<>p__8 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(GuildManager), new CSharpArgumentInfo[]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
										}));
									}
									Func<CallSite, object, string, object> target6 = GuildManager.<>o__10.<>p__8.Target;
									CallSite <>p__6 = GuildManager.<>o__10.<>p__8;
									if (GuildManager.<>o__10.<>p__7 == null)
									{
										GuildManager.<>o__10.<>p__7 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(GuildManager), new CSharpArgumentInfo[]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
										}));
									}
									Func<CallSite, string, object, object> target7 = GuildManager.<>o__10.<>p__7.Target;
									CallSite <>p__7 = GuildManager.<>o__10.<>p__7;
									string text2 = string.Concat(new string[]
									{
										CS$<>8__locals5.CS$<>8__locals2.CS$<>8__locals1.proxy,
										" -> (",
										CS$<>8__locals5.CS$<>8__locals2.CS$<>8__locals1.token,
										") [",
										CS$<>8__locals5.CS$<>8__locals2.gid.ToString(),
										"] MassV2X => Got #"
									});
									if (GuildManager.<>o__10.<>p__6 == null)
									{
										GuildManager.<>o__10.<>p__6 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "name", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
									}
									object obj = target6(<>p__6, target7(<>p__7, text2, GuildManager.<>o__10.<>p__6.Target(GuildManager.<>o__10.<>p__6, CS$<>8__locals5.objsch)), " with ID ");
									if (GuildManager.<>o__10.<>p__9 == null)
									{
										GuildManager.<>o__10.<>p__9 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
									}
									target4(<>p__4, typeFromHandle, target5(<>p__5, obj, GuildManager.<>o__10.<>p__9.Target(GuildManager.<>o__10.<>p__9, CS$<>8__locals5.objsch)));
									if (GuildManager.<>o__10.<>p__15 == null)
									{
										GuildManager.<>o__10.<>p__15 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(GuildManager)));
									}
									Func<CallSite, object, string> target8 = GuildManager.<>o__10.<>p__15.Target;
									CallSite <>p__8 = GuildManager.<>o__10.<>p__15;
									if (GuildManager.<>o__10.<>p__14 == null)
									{
										GuildManager.<>o__10.<>p__14 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(GuildManager), new CSharpArgumentInfo[]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
										}));
									}
									Func<CallSite, object, string, object> target9 = GuildManager.<>o__10.<>p__14.Target;
									CallSite <>p__9 = GuildManager.<>o__10.<>p__14;
									if (GuildManager.<>o__10.<>p__13 == null)
									{
										GuildManager.<>o__10.<>p__13 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(GuildManager), new CSharpArgumentInfo[]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
										}));
									}
									Func<CallSite, string, object, object> target10 = GuildManager.<>o__10.<>p__13.Target;
									CallSite <>p__10 = GuildManager.<>o__10.<>p__13;
									string text3 = "https://discord.com/api/v9/channels/";
									if (GuildManager.<>o__10.<>p__12 == null)
									{
										GuildManager.<>o__10.<>p__12 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
									}
									string messageGetURL = target8(<>p__8, target9(<>p__9, target10(<>p__10, text3, GuildManager.<>o__10.<>p__12.Target(GuildManager.<>o__10.<>p__12, CS$<>8__locals5.objsch)), "/messages?limit=50"));
									HttpRequestMessage requestMessages = new HttpRequestMessage
									{
										RequestUri = new Uri(messageGetURL),
										Method = HttpMethod.Get,
										Headers = 
										{
											{
												"Authorization",
												CS$<>8__locals5.CS$<>8__locals2.CS$<>8__locals1.token
											},
											{ "Accept-Language", "it" },
											{ "User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36" },
											{ "X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9" },
											{ "Accept", "*/*" },
											{ "Cookie", "locale=it" },
											{ "Origin", "https://discord.com" },
											{ "Referer", "https://discord.com/channels/@me" }
										}
									};
									HttpResponseMessage httpResponseMessage2 = await CS$<>8__locals5.CS$<>8__locals2.http.SendAsync(requestMessages);
									string text4 = await httpResponseMessage2.Content.ReadAsStringAsync();
									httpResponseMessage2 = null;
									string respCHMessages = text4;
									text4 = null;
									if (!(respCHMessages == "[]"))
									{
										JArray messagesArr = JArray.Parse(respCHMessages);
										JObject[] jMObjects = messagesArr.ToObject<JObject[]>();
										foreach (JObject objMsgCH in jMObjects)
										{
											if (GuildManager.<>o__10.<>p__18 == null)
											{
												GuildManager.<>o__10.<>p__18 = CallSite<Action<CallSite, Action<int, int, object>, int, int, object>>.Create(Binder.Invoke(CSharpBinderFlags.ResultDiscarded, typeof(GuildManager), new CSharpArgumentInfo[]
												{
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
												}));
											}
											Action<CallSite, Action<int, int, object>, int, int, object> target11 = GuildManager.<>o__10.<>p__18.Target;
											CallSite <>p__11 = GuildManager.<>o__10.<>p__18;
											Action<int, int, object> bridgeGS = ImpostazioniGlobali._bridgeGS;
											int num = 1;
											int num2 = 1;
											if (GuildManager.<>o__10.<>p__17 == null)
											{
												GuildManager.<>o__10.<>p__17 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
											}
											Func<CallSite, object, object> target12 = GuildManager.<>o__10.<>p__17.Target;
											CallSite <>p__12 = GuildManager.<>o__10.<>p__17;
											if (GuildManager.<>o__10.<>p__16 == null)
											{
												GuildManager.<>o__10.<>p__16 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "author", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
											}
											target11(<>p__11, bridgeGS, num, num2, target12(<>p__12, GuildManager.<>o__10.<>p__16.Target(GuildManager.<>o__10.<>p__16, objMsgCH)));
											objMsgCH = null;
										}
										JObject[] array2 = null;
										object __lastMsg = jMObjects[jMObjects.Length - 1];
										if (GuildManager.<>o__10.<>p__20 == null)
										{
											GuildManager.<>o__10.<>p__20 = CallSite<Func<CallSite, object, long>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(long), typeof(GuildManager)));
										}
										Func<CallSite, object, long> target13 = GuildManager.<>o__10.<>p__20.Target;
										CallSite <>p__13 = GuildManager.<>o__10.<>p__20;
										if (GuildManager.<>o__10.<>p__19 == null)
										{
											GuildManager.<>o__10.<>p__19 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
										}
										long __lastId = target13(<>p__13, GuildManager.<>o__10.<>p__19.Target(GuildManager.<>o__10.<>p__19, __lastMsg));
										if (GuildManager.<>o__10.<>p__26 == null)
										{
											GuildManager.<>o__10.<>p__26 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(GuildManager)));
										}
										Func<CallSite, object, string> target14 = GuildManager.<>o__10.<>p__26.Target;
										CallSite <>p__14 = GuildManager.<>o__10.<>p__26;
										if (GuildManager.<>o__10.<>p__25 == null)
										{
											GuildManager.<>o__10.<>p__25 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(GuildManager), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
											}));
										}
										Func<CallSite, object, string, object> target15 = GuildManager.<>o__10.<>p__25.Target;
										CallSite <>p__15 = GuildManager.<>o__10.<>p__25;
										if (GuildManager.<>o__10.<>p__24 == null)
										{
											GuildManager.<>o__10.<>p__24 = CallSite<Func<CallSite, object, long, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(GuildManager), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
											}));
										}
										Func<CallSite, object, long, object> target16 = GuildManager.<>o__10.<>p__24.Target;
										CallSite <>p__16 = GuildManager.<>o__10.<>p__24;
										if (GuildManager.<>o__10.<>p__23 == null)
										{
											GuildManager.<>o__10.<>p__23 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(GuildManager), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
											}));
										}
										Func<CallSite, object, string, object> target17 = GuildManager.<>o__10.<>p__23.Target;
										CallSite <>p__17 = GuildManager.<>o__10.<>p__23;
										if (GuildManager.<>o__10.<>p__22 == null)
										{
											GuildManager.<>o__10.<>p__22 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(GuildManager), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, string, object, object> target18 = GuildManager.<>o__10.<>p__22.Target;
										CallSite <>p__18 = GuildManager.<>o__10.<>p__22;
										string text5 = "https://discord.com/api/v9/channels/";
										if (GuildManager.<>o__10.<>p__21 == null)
										{
											GuildManager.<>o__10.<>p__21 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
										}
										string beforeURL = target14(<>p__14, target15(<>p__15, target16(<>p__16, target17(<>p__17, target18(<>p__18, text5, GuildManager.<>o__10.<>p__21.Target(GuildManager.<>o__10.<>p__21, CS$<>8__locals5.objsch)), "/messages?before="), __lastId), "&limit=50"));
										HttpRequestMessage requestMessagesBefore = new HttpRequestMessage
										{
											RequestUri = new Uri(beforeURL),
											Method = HttpMethod.Get,
											Headers = 
											{
												{
													"Authorization",
													CS$<>8__locals5.CS$<>8__locals2.CS$<>8__locals1.token
												},
												{ "Accept-Language", "it" },
												{ "User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36" },
												{ "X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9" },
												{ "Accept", "*/*" },
												{ "Cookie", "locale=it" },
												{ "Referer", "https://discord.com/channels/@me" }
											}
										};
										HttpResponseMessage httpResponseMessage3 = await CS$<>8__locals5.CS$<>8__locals2.http.SendAsync(requestMessagesBefore);
										string text6 = await httpResponseMessage3.Content.ReadAsStringAsync();
										httpResponseMessage3 = null;
										string respCHMessages2 = text6;
										text6 = null;
										if (!(respCHMessages2 == "[]"))
										{
											JArray messagesArr2 = JArray.Parse(respCHMessages2);
											JObject[] jMObjects2 = messagesArr.ToObject<JObject[]>();
											foreach (JObject objMsgCH2 in jMObjects2)
											{
												if (GuildManager.<>o__10.<>p__29 == null)
												{
													GuildManager.<>o__10.<>p__29 = CallSite<Action<CallSite, Action<int, int, object>, int, int, object>>.Create(Binder.Invoke(CSharpBinderFlags.ResultDiscarded, typeof(GuildManager), new CSharpArgumentInfo[]
													{
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
													}));
												}
												Action<CallSite, Action<int, int, object>, int, int, object> target19 = GuildManager.<>o__10.<>p__29.Target;
												CallSite <>p__19 = GuildManager.<>o__10.<>p__29;
												Action<int, int, object> bridgeGS2 = ImpostazioniGlobali._bridgeGS;
												int num3 = 1;
												int num4 = 1;
												if (GuildManager.<>o__10.<>p__28 == null)
												{
													GuildManager.<>o__10.<>p__28 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
												}
												Func<CallSite, object, object> target20 = GuildManager.<>o__10.<>p__28.Target;
												CallSite <>p__20 = GuildManager.<>o__10.<>p__28;
												if (GuildManager.<>o__10.<>p__27 == null)
												{
													GuildManager.<>o__10.<>p__27 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "author", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
												}
												target19(<>p__19, bridgeGS2, num3, num4, target20(<>p__20, GuildManager.<>o__10.<>p__27.Target(GuildManager.<>o__10.<>p__27, objMsgCH2)));
												objMsgCH2 = null;
											}
											JObject[] array3 = null;
											if (GuildManager.<>o__10.<>p__36 == null)
											{
												GuildManager.<>o__10.<>p__36 = CallSite<Action<CallSite, Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Log", null, typeof(GuildManager), new CSharpArgumentInfo[]
												{
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
												}));
											}
											Action<CallSite, Type, object> target21 = GuildManager.<>o__10.<>p__36.Target;
											CallSite <>p__21 = GuildManager.<>o__10.<>p__36;
											Type typeFromHandle2 = typeof(ImpostazioniGlobali);
											if (GuildManager.<>o__10.<>p__35 == null)
											{
												GuildManager.<>o__10.<>p__35 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(GuildManager), new CSharpArgumentInfo[]
												{
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
												}));
											}
											Func<CallSite, object, string, object> target22 = GuildManager.<>o__10.<>p__35.Target;
											CallSite <>p__22 = GuildManager.<>o__10.<>p__35;
											if (GuildManager.<>o__10.<>p__34 == null)
											{
												GuildManager.<>o__10.<>p__34 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(GuildManager), new CSharpArgumentInfo[]
												{
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
												}));
											}
											Func<CallSite, object, object, object> target23 = GuildManager.<>o__10.<>p__34.Target;
											CallSite <>p__23 = GuildManager.<>o__10.<>p__34;
											if (GuildManager.<>o__10.<>p__32 == null)
											{
												GuildManager.<>o__10.<>p__32 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(GuildManager), new CSharpArgumentInfo[]
												{
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
												}));
											}
											Func<CallSite, object, string, object> target24 = GuildManager.<>o__10.<>p__32.Target;
											CallSite <>p__24 = GuildManager.<>o__10.<>p__32;
											if (GuildManager.<>o__10.<>p__31 == null)
											{
												GuildManager.<>o__10.<>p__31 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(GuildManager), new CSharpArgumentInfo[]
												{
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
												}));
											}
											Func<CallSite, string, object, object> target25 = GuildManager.<>o__10.<>p__31.Target;
											CallSite <>p__25 = GuildManager.<>o__10.<>p__31;
											string text7 = string.Concat(new string[]
											{
												CS$<>8__locals5.CS$<>8__locals2.CS$<>8__locals1.proxy,
												" -> (",
												CS$<>8__locals5.CS$<>8__locals2.CS$<>8__locals1.token,
												") [",
												CS$<>8__locals5.CS$<>8__locals2.gid.ToString(),
												"] MassV2X => #"
											});
											if (GuildManager.<>o__10.<>p__30 == null)
											{
												GuildManager.<>o__10.<>p__30 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "name", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
											}
											object obj2 = target24(<>p__24, target25(<>p__25, text7, GuildManager.<>o__10.<>p__30.Target(GuildManager.<>o__10.<>p__30, CS$<>8__locals5.objsch)), " {");
											if (GuildManager.<>o__10.<>p__33 == null)
											{
												GuildManager.<>o__10.<>p__33 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
											}
											target21(<>p__21, typeFromHandle2, target22(<>p__22, target23(<>p__23, obj2, GuildManager.<>o__10.<>p__33.Target(GuildManager.<>o__10.<>p__33, CS$<>8__locals5.objsch)), "} has been successfully parsed!"));
											jMObjects = null;
											messageGetURL = null;
											jMObjects2 = null;
											messagesArr = null;
											respCHMessages = null;
											respCHMessages2 = null;
											requestMessagesBefore = null;
											CS$<>8__locals5.CS$<>8__locals2.requestChannels = null;
											CS$<>8__locals5.CS$<>8__locals2.http = null;
											CS$<>8__locals5.CS$<>8__locals2.handler = null;
											CS$<>8__locals5.CS$<>8__locals2.CS$<>8__locals1.token = null;
											CS$<>8__locals5.CS$<>8__locals2.CS$<>8__locals1.proxy = null;
											beforeURL = null;
											__lastMsg = null;
											requestMessages = null;
											CS$<>8__locals5.CS$<>8__locals2.jObjects = null;
											CS$<>8__locals5.CS$<>8__locals2.obArr = null;
											CS$<>8__locals5.CS$<>8__locals2.respGLChannels = null;
											CS$<>8__locals5.CS$<>8__locals2.URL_channels = null;
											CS$<>8__locals5.CS$<>8__locals2.jm = null;
											CS$<>8__locals5.CS$<>8__locals2.guildobj = null;
											try
											{
												Thread.CurrentThread.Interrupt();
											}
											catch
											{
											}
											messageGetURL = null;
											requestMessages = null;
											respCHMessages = null;
											messagesArr = null;
											jMObjects = null;
											__lastMsg = null;
											beforeURL = null;
											requestMessagesBefore = null;
											respCHMessages2 = null;
											jMObjects2 = null;
										}
									}
								}
								catch (Exception err)
								{
									if (err.Message == "Error reading JArray from JsonReader. Current JsonReader item is not an array: StartObject. Path '', line 1, position 1." || err.Message.StartsWith("Error reading JArray from JsonReader. Current JsonReader"))
									{
										err = null;
										if (GuildManager.<>o__10.<>p__43 == null)
										{
											GuildManager.<>o__10.<>p__43 = CallSite<Action<CallSite, Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Log", null, typeof(GuildManager), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Action<CallSite, Type, object> target26 = GuildManager.<>o__10.<>p__43.Target;
										CallSite <>p__26 = GuildManager.<>o__10.<>p__43;
										Type typeFromHandle3 = typeof(ImpostazioniGlobali);
										if (GuildManager.<>o__10.<>p__42 == null)
										{
											GuildManager.<>o__10.<>p__42 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(GuildManager), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
											}));
										}
										Func<CallSite, object, string, object> target27 = GuildManager.<>o__10.<>p__42.Target;
										CallSite <>p__27 = GuildManager.<>o__10.<>p__42;
										if (GuildManager.<>o__10.<>p__41 == null)
										{
											GuildManager.<>o__10.<>p__41 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(GuildManager), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, object, object, object> target28 = GuildManager.<>o__10.<>p__41.Target;
										CallSite <>p__28 = GuildManager.<>o__10.<>p__41;
										if (GuildManager.<>o__10.<>p__39 == null)
										{
											GuildManager.<>o__10.<>p__39 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(GuildManager), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
											}));
										}
										Func<CallSite, object, string, object> target29 = GuildManager.<>o__10.<>p__39.Target;
										CallSite <>p__29 = GuildManager.<>o__10.<>p__39;
										if (GuildManager.<>o__10.<>p__38 == null)
										{
											GuildManager.<>o__10.<>p__38 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(GuildManager), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, string, object, object> target30 = GuildManager.<>o__10.<>p__38.Target;
										CallSite <>p__30 = GuildManager.<>o__10.<>p__38;
										string text8 = string.Concat(new string[]
										{
											CS$<>8__locals5.CS$<>8__locals2.CS$<>8__locals1.proxy,
											" -> (",
											CS$<>8__locals5.CS$<>8__locals2.CS$<>8__locals1.token,
											") [",
											CS$<>8__locals5.CS$<>8__locals2.gid.ToString(),
											"] MassV2X => Il canale #"
										});
										if (GuildManager.<>o__10.<>p__37 == null)
										{
											GuildManager.<>o__10.<>p__37 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "name", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
										}
										object obj3 = target29(<>p__29, target30(<>p__30, text8, GuildManager.<>o__10.<>p__37.Target(GuildManager.<>o__10.<>p__37, CS$<>8__locals5.objsch)), " with ID ");
										if (GuildManager.<>o__10.<>p__40 == null)
										{
											GuildManager.<>o__10.<>p__40 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
										}
										target26(<>p__26, typeFromHandle3, target27(<>p__27, target28(<>p__28, obj3, GuildManager.<>o__10.<>p__40.Target(GuildManager.<>o__10.<>p__40, CS$<>8__locals5.objsch)), " è privato e peranto è stato skippato!"));
									}
									else
									{
										if (GuildManager.<>o__10.<>p__51 == null)
										{
											GuildManager.<>o__10.<>p__51 = CallSite<Action<CallSite, Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Log", null, typeof(GuildManager), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Action<CallSite, Type, object> target31 = GuildManager.<>o__10.<>p__51.Target;
										CallSite <>p__31 = GuildManager.<>o__10.<>p__51;
										Type typeFromHandle4 = typeof(ImpostazioniGlobali);
										if (GuildManager.<>o__10.<>p__50 == null)
										{
											GuildManager.<>o__10.<>p__50 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(GuildManager), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
											}));
										}
										Func<CallSite, object, string, object> target32 = GuildManager.<>o__10.<>p__50.Target;
										CallSite <>p__32 = GuildManager.<>o__10.<>p__50;
										if (GuildManager.<>o__10.<>p__49 == null)
										{
											GuildManager.<>o__10.<>p__49 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(GuildManager), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
											}));
										}
										Func<CallSite, object, string, object> target33 = GuildManager.<>o__10.<>p__49.Target;
										CallSite <>p__33 = GuildManager.<>o__10.<>p__49;
										if (GuildManager.<>o__10.<>p__48 == null)
										{
											GuildManager.<>o__10.<>p__48 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(GuildManager), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, object, object, object> target34 = GuildManager.<>o__10.<>p__48.Target;
										CallSite <>p__34 = GuildManager.<>o__10.<>p__48;
										if (GuildManager.<>o__10.<>p__46 == null)
										{
											GuildManager.<>o__10.<>p__46 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(GuildManager), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
											}));
										}
										Func<CallSite, object, string, object> target35 = GuildManager.<>o__10.<>p__46.Target;
										CallSite <>p__35 = GuildManager.<>o__10.<>p__46;
										if (GuildManager.<>o__10.<>p__45 == null)
										{
											GuildManager.<>o__10.<>p__45 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(GuildManager), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, string, object, object> target36 = GuildManager.<>o__10.<>p__45.Target;
										CallSite <>p__36 = GuildManager.<>o__10.<>p__45;
										string text9 = string.Concat(new string[]
										{
											CS$<>8__locals5.CS$<>8__locals2.CS$<>8__locals1.proxy,
											" -> (",
											CS$<>8__locals5.CS$<>8__locals2.CS$<>8__locals1.token,
											") [",
											CS$<>8__locals5.CS$<>8__locals2.gid.ToString(),
											"] MassV2X => An error has occurred with channel #"
										});
										if (GuildManager.<>o__10.<>p__44 == null)
										{
											GuildManager.<>o__10.<>p__44 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "name", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
										}
										object obj4 = target35(<>p__35, target36(<>p__36, text9, GuildManager.<>o__10.<>p__44.Target(GuildManager.<>o__10.<>p__44, CS$<>8__locals5.objsch)), " with ID ");
										if (GuildManager.<>o__10.<>p__47 == null)
										{
											GuildManager.<>o__10.<>p__47 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(GuildManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
										}
										target31(<>p__31, typeFromHandle4, target32(<>p__32, target33(<>p__33, target34(<>p__34, obj4, GuildManager.<>o__10.<>p__47.Target(GuildManager.<>o__10.<>p__47, CS$<>8__locals5.objsch)), ": "), err.Message));
										err = null;
									}
								}
							}).Start();
						}
						CS$<>8__locals5 = null;
					}
					array = null;
					CS$<>8__locals2 = null;
				}
				catch (Exception ex)
				{
					ImpostazioniGlobali.Log("MassV2X => Errore durante il parsing: " + ex.Message);
					ex = null;
				}
			}
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x0001B28D File Offset: 0x0001948D
		private void GuildManager_Load(object sender, EventArgs e)
		{
			ImpostazioniGlobali._bridgeLogPerform.Add(delegate(int a, int b, object[] i)
			{
				bool flag = a == 0;
				if (flag)
				{
					try
					{
						this.channelId.Text = (string)i[0];
					}
					catch (Exception)
					{
					}
				}
			});
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00002067 File Offset: 0x00000267
		private void hasPCM_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00002067 File Offset: 0x00000267
		private void xsmodeTypeEnable_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x0001B2A7 File Offset: 0x000194A7
		private void xsmodeTypeEnable_Click(object sender, EventArgs e)
		{
			this.xsmodeTypeEnable.Checked = true;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00002067 File Offset: 0x00000267
		private void mbvfbypass_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060001AA RID: 426 RVA: 0x0001B2B8 File Offset: 0x000194B8
		private void hasEmbed_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.hasCaptchaSVX.Checked;
			if (@checked)
			{
				bool flag = ImpostazioniGlobali.CaptchaKey_TWO == "";
				if (flag)
				{
					this.hasCaptchaSVX.Checked = false;
					MessageBox.Show("Devi prima importare una Captcha Key", "Avviso", ContentAlignment.MiddleCenter);
				}
			}
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00002067 File Offset: 0x00000267
		private void del_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00002067 File Offset: 0x00000267
		private void siticoneTextBox1_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060001AD RID: 429 RVA: 0x0001B30B File Offset: 0x0001950B
		private void siticoneCustomCheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			ImpostazioniGlobali.AutoParse = this.siticoneCustomCheckBox1.Checked;
		}

		// Token: 0x060001AE RID: 430 RVA: 0x0001B320 File Offset: 0x00019520
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001AF RID: 431 RVA: 0x0001B358 File Offset: 0x00019558
		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(GuildManager));
			this.label1 = new Label();
			this.siticoneDragControl1 = new SiticoneDragControl(this.components);
			this.channelId = new SiticoneTextBox();
			this.startBtn = new SiticoneButton();
			this.siticoneButton1 = new SiticoneButton();
			this.sliderDelay = new SiticoneSlider();
			this.hasDelay = new SiticoneToggleSwitch();
			this.del = new Label();
			this.label9 = new Label();
			this.label8 = new Label();
			this.hasCaptchaSVX = new SiticoneCustomCheckBox();
			this.hasPCM = new SiticoneCustomCheckBox();
			this.pictureBox2 = new PictureBox();
			this.xsmodeTypeEnable = new SiticoneToggleSwitch();
			this.label4 = new Label();
			this.label3 = new Label();
			this.label5 = new Label();
			this.mbvfbypass = new SiticoneCustomCheckBox();
			this.siticoneTextBox1 = new SiticoneTextBox();
			this.siticoneTextBox2 = new SiticoneTextBox();
			this.label2 = new Label();
			this.siticoneCustomCheckBox1 = new SiticoneCustomCheckBox();
			((ISupportInitialize)this.pictureBox2).BeginInit();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Inter", 15.75f, FontStyle.Bold);
			this.label1.Location = new Point(13, 40);
			this.label1.Name = "label1";
			this.label1.Size = new Size(162, 25);
			this.label1.TabIndex = 1;
			this.label1.Text = "Guild Manager";
			this.siticoneDragControl1.TargetControl = this;
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
			this.channelId.FillColor = Color.Snow;
			this.channelId.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.channelId.FocusedState.Parent = this.channelId;
			this.channelId.Font = new Font("SF Pro Text", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.channelId.ForeColor = Color.Black;
			this.channelId.HoveredState.BorderColor = Color.FromArgb(213, 218, 223);
			this.channelId.HoveredState.Parent = this.channelId;
			this.channelId.Location = new Point(24, 205);
			this.channelId.Margin = new Padding(4, 3, 4, 3);
			this.channelId.Name = "channelId";
			this.channelId.PasswordChar = '\0';
			this.channelId.PlaceholderText = "Invite Link or Server ID";
			this.channelId.SelectedText = "";
			this.channelId.ShadowDecoration.Parent = this.channelId;
			this.channelId.Size = new Size(658, 41);
			this.channelId.TabIndex = 35;
			this.startBtn.BackColor = Color.Transparent;
			this.startBtn.BorderColor = Color.LightGray;
			this.startBtn.BorderRadius = 4;
			this.startBtn.BorderStyle = DashStyle.Dot;
			this.startBtn.BorderThickness = 1;
			this.startBtn.CheckedState.Parent = this.startBtn;
			this.startBtn.Cursor = Cursors.Hand;
			this.startBtn.CustomImages.Parent = this.startBtn;
			this.startBtn.FillColor = Color.Snow;
			this.startBtn.Font = new Font("Inter", 9.749999f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.startBtn.ForeColor = Color.Black;
			this.startBtn.HoveredState.Parent = this.startBtn;
			this.startBtn.Location = new Point(18, 502);
			this.startBtn.Name = "startBtn";
			this.startBtn.PressedColor = Color.White;
			this.startBtn.ShadowDecoration.Parent = this.startBtn;
			this.startBtn.Size = new Size(326, 32);
			this.startBtn.TabIndex = 38;
			this.startBtn.Text = "Leave";
			this.startBtn.TextRenderingHint = TextRenderingHint.AntiAlias;
			this.startBtn.Click += this.startBtn_Click;
			this.startBtn.MouseEnter += this.siticoneButton1_MouseEnter;
			this.startBtn.MouseLeave += this.siticoneButton1_MouseLeave;
			this.siticoneButton1.BackColor = Color.Transparent;
			this.siticoneButton1.BorderColor = Color.LightGray;
			this.siticoneButton1.BorderRadius = 4;
			this.siticoneButton1.BorderStyle = DashStyle.Dot;
			this.siticoneButton1.BorderThickness = 1;
			this.siticoneButton1.CheckedState.Parent = this.siticoneButton1;
			this.siticoneButton1.Cursor = Cursors.Hand;
			this.siticoneButton1.CustomImages.Parent = this.siticoneButton1;
			this.siticoneButton1.FillColor = Color.Snow;
			this.siticoneButton1.Font = new Font("Inter", 9.749999f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.siticoneButton1.ForeColor = Color.Black;
			this.siticoneButton1.HoveredState.Parent = this.siticoneButton1;
			this.siticoneButton1.Location = new Point(350, 502);
			this.siticoneButton1.Name = "siticoneButton1";
			this.siticoneButton1.PressedColor = Color.White;
			this.siticoneButton1.ShadowDecoration.Parent = this.siticoneButton1;
			this.siticoneButton1.Size = new Size(332, 32);
			this.siticoneButton1.TabIndex = 39;
			this.siticoneButton1.Text = "Join";
			this.siticoneButton1.TextRenderingHint = TextRenderingHint.AntiAlias;
			this.siticoneButton1.Click += this.siticoneButton1_Click;
			this.siticoneButton1.MouseEnter += this.siticoneButton1_MouseEnter;
			this.siticoneButton1.MouseLeave += this.siticoneButton1_MouseLeave;
			this.sliderDelay.Cursor = Cursors.Hand;
			this.sliderDelay.LargeChange = 5;
			this.sliderDelay.Location = new Point(24, 431);
			this.sliderDelay.Name = "sliderDelay";
			this.sliderDelay.Size = new Size(641, 60);
			this.sliderDelay.TabIndex = 51;
			this.sliderDelay.Scroll += this.sliderThreads_Scroll;
			this.hasDelay.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.hasDelay.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.hasDelay.CheckedState.InnerBorderColor = Color.White;
			this.hasDelay.CheckedState.InnerColor = Color.White;
			this.hasDelay.CheckedState.Parent = this.hasDelay;
			this.hasDelay.Cursor = Cursors.Hand;
			this.hasDelay.Location = new Point(529, 345);
			this.hasDelay.Name = "hasDelay";
			this.hasDelay.ShadowDecoration.Parent = this.hasDelay;
			this.hasDelay.Size = new Size(32, 20);
			this.hasDelay.TabIndex = 50;
			this.hasDelay.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.hasDelay.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.hasDelay.UncheckedState.InnerBorderColor = Color.White;
			this.hasDelay.UncheckedState.InnerColor = Color.White;
			this.hasDelay.UncheckedState.Parent = this.hasDelay;
			this.del.AutoSize = true;
			this.del.Font = new Font("SF Pro Text", 9f, FontStyle.Bold);
			this.del.Location = new Point(566, 348);
			this.del.Name = "del";
			this.del.Size = new Size(90, 14);
			this.del.TabIndex = 49;
			this.del.Text = "Delay: 200ms";
			this.del.Click += this.del_Click;
			this.label9.AutoSize = true;
			this.label9.Font = new Font("SF Pro Text", 9f, FontStyle.Bold);
			this.label9.Location = new Point(43, 347);
			this.label9.Name = "label9";
			this.label9.Size = new Size(139, 14);
			this.label9.TabIndex = 48;
			this.label9.Text = "Private Channel Mode";
			this.label8.AutoSize = true;
			this.label8.Font = new Font("SF Pro Text", 9f, FontStyle.Bold);
			this.label8.Location = new Point(43, 385);
			this.label8.Name = "label8";
			this.label8.Size = new Size(95, 14);
			this.label8.TabIndex = 47;
			this.label8.Text = "Captcha SBVX";
			this.hasCaptchaSVX.BackColor = Color.Transparent;
			this.hasCaptchaSVX.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.hasCaptchaSVX.CheckedState.BorderRadius = 2;
			this.hasCaptchaSVX.CheckedState.BorderThickness = 0;
			this.hasCaptchaSVX.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.hasCaptchaSVX.CheckedState.Parent = this.hasCaptchaSVX;
			this.hasCaptchaSVX.Cursor = Cursors.Hand;
			this.hasCaptchaSVX.Location = new Point(25, 385);
			this.hasCaptchaSVX.Name = "hasCaptchaSVX";
			this.hasCaptchaSVX.ShadowDecoration.Parent = this.hasCaptchaSVX;
			this.hasCaptchaSVX.Size = new Size(15, 15);
			this.hasCaptchaSVX.TabIndex = 46;
			this.hasCaptchaSVX.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.hasCaptchaSVX.UncheckedState.BorderRadius = 2;
			this.hasCaptchaSVX.UncheckedState.BorderThickness = 0;
			this.hasCaptchaSVX.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.hasCaptchaSVX.UncheckedState.Parent = this.hasCaptchaSVX;
			this.hasCaptchaSVX.CheckedChanged += this.hasEmbed_CheckedChanged;
			this.hasPCM.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.hasPCM.CheckedState.BorderRadius = 2;
			this.hasPCM.CheckedState.BorderThickness = 0;
			this.hasPCM.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.hasPCM.CheckedState.Parent = this.hasPCM;
			this.hasPCM.Cursor = Cursors.Hand;
			this.hasPCM.Location = new Point(25, 347);
			this.hasPCM.Name = "hasPCM";
			this.hasPCM.ShadowDecoration.Parent = this.hasPCM;
			this.hasPCM.Size = new Size(15, 15);
			this.hasPCM.TabIndex = 45;
			this.hasPCM.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.hasPCM.UncheckedState.BorderRadius = 2;
			this.hasPCM.UncheckedState.BorderThickness = 0;
			this.hasPCM.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.hasPCM.UncheckedState.Parent = this.hasPCM;
			this.hasPCM.CheckedChanged += this.hasPCM_CheckedChanged;
			this.hasPCM.Click += this.hasLive_Click;
			this.pictureBox2.Image = (Image)componentResourceManager.GetObject("pictureBox2.Image");
			this.pictureBox2.Location = new Point(655, 37);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new Size(35, 23);
			this.pictureBox2.TabIndex = 68;
			this.pictureBox2.TabStop = false;
			this.xsmodeTypeEnable.Checked = true;
			this.xsmodeTypeEnable.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.xsmodeTypeEnable.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.xsmodeTypeEnable.CheckedState.InnerBorderColor = Color.White;
			this.xsmodeTypeEnable.CheckedState.InnerColor = Color.White;
			this.xsmodeTypeEnable.CheckedState.Parent = this.xsmodeTypeEnable;
			this.xsmodeTypeEnable.Cursor = Cursors.Hand;
			this.xsmodeTypeEnable.Location = new Point(594, 112);
			this.xsmodeTypeEnable.Name = "xsmodeTypeEnable";
			this.xsmodeTypeEnable.ShadowDecoration.Parent = this.xsmodeTypeEnable;
			this.xsmodeTypeEnable.Size = new Size(32, 20);
			this.xsmodeTypeEnable.TabIndex = 74;
			this.xsmodeTypeEnable.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.xsmodeTypeEnable.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.xsmodeTypeEnable.UncheckedState.InnerBorderColor = Color.White;
			this.xsmodeTypeEnable.UncheckedState.InnerColor = Color.White;
			this.xsmodeTypeEnable.UncheckedState.Parent = this.xsmodeTypeEnable;
			this.xsmodeTypeEnable.CheckedChanged += this.xsmodeTypeEnable_CheckedChanged;
			this.xsmodeTypeEnable.Click += this.xsmodeTypeEnable_Click;
			this.label4.AutoSize = true;
			this.label4.Font = new Font("SF Pro Text", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label4.Location = new Point(631, 115);
			this.label4.Name = "label4";
			this.label4.Size = new Size(44, 14);
			this.label4.TabIndex = 73;
			this.label4.Text = "XS V4";
			this.label3.AutoSize = true;
			this.label3.Font = new Font("SF Pro Text", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label3.ForeColor = Color.Teal;
			this.label3.Location = new Point(23, 85);
			this.label3.Name = "label3";
			this.label3.Size = new Size(345, 60);
			this.label3.TabIndex = 72;
			this.label3.Text = "The join method has been updated and now supports\r\ncontent encoding and decoding.\r\nPatch: Works with the latest discord security patch\r\nImproved MB Verification Bypass.";
			this.label5.AutoSize = true;
			this.label5.Font = new Font("SF Pro Text", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label5.Location = new Point(43, 366);
			this.label5.Name = "label5";
			this.label5.Size = new Size(144, 14);
			this.label5.TabIndex = 76;
			this.label5.Text = "Bypass MB Verification";
			this.mbvfbypass.BackColor = Color.Transparent;
			this.mbvfbypass.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.mbvfbypass.CheckedState.BorderRadius = 2;
			this.mbvfbypass.CheckedState.BorderThickness = 0;
			this.mbvfbypass.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.mbvfbypass.CheckedState.Parent = this.mbvfbypass;
			this.mbvfbypass.Cursor = Cursors.Hand;
			this.mbvfbypass.Location = new Point(25, 366);
			this.mbvfbypass.Name = "mbvfbypass";
			this.mbvfbypass.ShadowDecoration.Parent = this.mbvfbypass;
			this.mbvfbypass.Size = new Size(15, 15);
			this.mbvfbypass.TabIndex = 75;
			this.mbvfbypass.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.mbvfbypass.UncheckedState.BorderRadius = 2;
			this.mbvfbypass.UncheckedState.BorderThickness = 0;
			this.mbvfbypass.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.mbvfbypass.UncheckedState.Parent = this.mbvfbypass;
			this.mbvfbypass.CheckedChanged += this.mbvfbypass_CheckedChanged;
			this.siticoneTextBox1.Animated = false;
			this.siticoneTextBox1.BackColor = Color.Transparent;
			this.siticoneTextBox1.BorderRadius = 4;
			this.siticoneTextBox1.BorderThickness = 2;
			this.siticoneTextBox1.Cursor = Cursors.IBeam;
			this.siticoneTextBox1.DefaultText = "";
			this.siticoneTextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			this.siticoneTextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			this.siticoneTextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			this.siticoneTextBox1.DisabledState.Parent = this.siticoneTextBox1;
			this.siticoneTextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			this.siticoneTextBox1.FillColor = Color.Snow;
			this.siticoneTextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.siticoneTextBox1.FocusedState.Parent = this.siticoneTextBox1;
			this.siticoneTextBox1.Font = new Font("SF Pro Text", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.siticoneTextBox1.ForeColor = Color.Black;
			this.siticoneTextBox1.HoveredState.BorderColor = Color.FromArgb(213, 218, 223);
			this.siticoneTextBox1.HoveredState.Parent = this.siticoneTextBox1;
			this.siticoneTextBox1.Location = new Point(24, 161);
			this.siticoneTextBox1.Margin = new Padding(4, 3, 4, 3);
			this.siticoneTextBox1.Name = "siticoneTextBox1";
			this.siticoneTextBox1.PasswordChar = '\0';
			this.siticoneTextBox1.PlaceholderText = "Captcha Bot ID*";
			this.siticoneTextBox1.SelectedText = "";
			this.siticoneTextBox1.ShadowDecoration.Parent = this.siticoneTextBox1;
			this.siticoneTextBox1.Size = new Size(658, 38);
			this.siticoneTextBox1.TabIndex = 77;
			this.siticoneTextBox1.TextChanged += this.siticoneTextBox1_TextChanged;
			this.siticoneTextBox2.Animated = false;
			this.siticoneTextBox2.BackColor = Color.Transparent;
			this.siticoneTextBox2.BorderRadius = 4;
			this.siticoneTextBox2.BorderThickness = 2;
			this.siticoneTextBox2.Cursor = Cursors.IBeam;
			this.siticoneTextBox2.DefaultText = "";
			this.siticoneTextBox2.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			this.siticoneTextBox2.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			this.siticoneTextBox2.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			this.siticoneTextBox2.DisabledState.Parent = this.siticoneTextBox2;
			this.siticoneTextBox2.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			this.siticoneTextBox2.FillColor = Color.Snow;
			this.siticoneTextBox2.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.siticoneTextBox2.FocusedState.Parent = this.siticoneTextBox2;
			this.siticoneTextBox2.Font = new Font("SF Pro Text", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.siticoneTextBox2.ForeColor = Color.Black;
			this.siticoneTextBox2.HoveredState.BorderColor = Color.FromArgb(213, 218, 223);
			this.siticoneTextBox2.HoveredState.Parent = this.siticoneTextBox2;
			this.siticoneTextBox2.Location = new Point(24, 252);
			this.siticoneTextBox2.Margin = new Padding(4, 3, 4, 3);
			this.siticoneTextBox2.Name = "siticoneTextBox2";
			this.siticoneTextBox2.PasswordChar = '\0';
			this.siticoneTextBox2.PlaceholderText = "Guild ID (XCP)*";
			this.siticoneTextBox2.SelectedText = "";
			this.siticoneTextBox2.ShadowDecoration.Parent = this.siticoneTextBox2;
			this.siticoneTextBox2.Size = new Size(658, 38);
			this.siticoneTextBox2.TabIndex = 78;
			this.label2.AutoSize = true;
			this.label2.Font = new Font("SF Pro Text", 9f, FontStyle.Bold);
			this.label2.Location = new Point(43, 328);
			this.label2.Name = "label2";
			this.label2.Size = new Size(85, 14);
			this.label2.TabIndex = 80;
			this.label2.Text = "Auto Parsing";
			this.siticoneCustomCheckBox1.BackColor = Color.Transparent;
			this.siticoneCustomCheckBox1.Checked = true;
			this.siticoneCustomCheckBox1.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.siticoneCustomCheckBox1.CheckedState.BorderRadius = 2;
			this.siticoneCustomCheckBox1.CheckedState.BorderThickness = 0;
			this.siticoneCustomCheckBox1.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.siticoneCustomCheckBox1.CheckedState.Parent = this.siticoneCustomCheckBox1;
			this.siticoneCustomCheckBox1.CheckState = CheckState.Checked;
			this.siticoneCustomCheckBox1.Cursor = Cursors.Hand;
			this.siticoneCustomCheckBox1.Location = new Point(25, 328);
			this.siticoneCustomCheckBox1.Name = "siticoneCustomCheckBox1";
			this.siticoneCustomCheckBox1.ShadowDecoration.Parent = this.siticoneCustomCheckBox1;
			this.siticoneCustomCheckBox1.Size = new Size(15, 15);
			this.siticoneCustomCheckBox1.TabIndex = 79;
			this.siticoneCustomCheckBox1.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.siticoneCustomCheckBox1.UncheckedState.BorderRadius = 2;
			this.siticoneCustomCheckBox1.UncheckedState.BorderThickness = 0;
			this.siticoneCustomCheckBox1.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.siticoneCustomCheckBox1.UncheckedState.Parent = this.siticoneCustomCheckBox1;
			this.siticoneCustomCheckBox1.CheckedChanged += this.siticoneCustomCheckBox1_CheckedChanged;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.label2);
			base.Controls.Add(this.siticoneCustomCheckBox1);
			base.Controls.Add(this.siticoneTextBox2);
			base.Controls.Add(this.siticoneTextBox1);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.mbvfbypass);
			base.Controls.Add(this.xsmodeTypeEnable);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.pictureBox2);
			base.Controls.Add(this.sliderDelay);
			base.Controls.Add(this.hasDelay);
			base.Controls.Add(this.del);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.hasCaptchaSVX);
			base.Controls.Add(this.hasPCM);
			base.Controls.Add(this.siticoneButton1);
			base.Controls.Add(this.startBtn);
			base.Controls.Add(this.channelId);
			base.Controls.Add(this.label1);
			base.Name = "GuildManager";
			base.Size = new Size(700, 546);
			base.Load += this.GuildManager_Load;
			((ISupportInitialize)this.pictureBox2).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040002E4 RID: 740
		private bool needParsing = false;

		// Token: 0x040002E5 RID: 741
		private IContainer components = null;

		// Token: 0x040002E6 RID: 742
		private Label label1;

		// Token: 0x040002E7 RID: 743
		private SiticoneDragControl siticoneDragControl1;

		// Token: 0x040002E8 RID: 744
		private SiticoneTextBox channelId;

		// Token: 0x040002E9 RID: 745
		private SiticoneButton siticoneButton1;

		// Token: 0x040002EA RID: 746
		private SiticoneButton startBtn;

		// Token: 0x040002EB RID: 747
		private SiticoneSlider sliderDelay;

		// Token: 0x040002EC RID: 748
		private SiticoneToggleSwitch hasDelay;

		// Token: 0x040002ED RID: 749
		private Label del;

		// Token: 0x040002EE RID: 750
		private Label label9;

		// Token: 0x040002EF RID: 751
		private Label label8;

		// Token: 0x040002F0 RID: 752
		private SiticoneCustomCheckBox hasCaptchaSVX;

		// Token: 0x040002F1 RID: 753
		private SiticoneCustomCheckBox hasPCM;

		// Token: 0x040002F2 RID: 754
		private PictureBox pictureBox2;

		// Token: 0x040002F3 RID: 755
		private SiticoneToggleSwitch xsmodeTypeEnable;

		// Token: 0x040002F4 RID: 756
		private Label label4;

		// Token: 0x040002F5 RID: 757
		private Label label3;

		// Token: 0x040002F6 RID: 758
		private Label label5;

		// Token: 0x040002F7 RID: 759
		private SiticoneCustomCheckBox mbvfbypass;

		// Token: 0x040002F8 RID: 760
		private SiticoneTextBox siticoneTextBox1;

		// Token: 0x040002F9 RID: 761
		private SiticoneTextBox siticoneTextBox2;

		// Token: 0x040002FA RID: 762
		private Label label2;

		// Token: 0x040002FB RID: 763
		private SiticoneCustomCheckBox siticoneCustomCheckBox1;
	}
}
