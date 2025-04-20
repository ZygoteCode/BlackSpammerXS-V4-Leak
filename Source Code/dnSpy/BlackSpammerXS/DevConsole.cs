using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Siticone.UI.WinForms;

namespace BlackSpammerXS
{
	// Token: 0x02000041 RID: 65
	public partial class DevConsole : Form
	{
		// Token: 0x06000123 RID: 291 RVA: 0x000123A4 File Offset: 0x000105A4
		public DevConsole()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000124 RID: 292 RVA: 0x000123C4 File Offset: 0x000105C4
		private void logBox_KeyDown(object sender, KeyEventArgs e)
		{
			bool flag = this.ses_aw;
			if (flag)
			{
				this.ses_aw = false;
				try
				{
					base.Controls.Clear();
					this.InitializeComponent();
				}
				catch
				{
				}
			}
			else
			{
				bool readOnly = this.logBox.ReadOnly;
				if (!readOnly)
				{
					bool flag2 = e.KeyCode == Keys.Return;
					if (flag2)
					{
						this.handle_cmd(this.logBox.Text);
					}
				}
			}
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00012448 File Offset: 0x00010648
		private void log(string a)
		{
			this.logBox.AppendText(Environment.NewLine + a);
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00012464 File Offset: 0x00010664
		private async void handle_cmd(string cmd)
		{
			this.logBox.ReadOnly = true;
			await Task.Run(delegate
			{
				try
				{
					bool flag = false;
					this.log("Comando: " + cmd + " :: Handling..");
					bool flag2 = cmd.StartsWith("count");
					if (flag2)
					{
						string channelId2 = cmd.Split(new char[] { ' ' })[1];
						int cfrom = 0;
						try
						{
							cfrom = int.Parse(cmd.Split(new char[] { ' ' })[2]);
						}
						catch
						{
						}
						flag = true;
						this.log("Initializing..");
						this.log("Starting Logger..");
						ImpostazioniGlobali.StartLog();
						this.c_count_thr = new Thread(delegate
						{
							this.log("Thread has been started. (MAX TOKENS: 150)");
							this.log("Counting from " + cfrom.ToString() + "...");
							int o = 0;
							using (List<string>.Enumerator enumerator = ImpostazioniGlobali.Tokens.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									string t = enumerator.Current;
									bool flag10 = o > 150;
									if (flag10)
									{
										break;
									}
									new Thread(async delegate
									{
										int num = o;
										o = num + 1;
										num = cfrom;
										cfrom = num + 1;
										this.log("Thread " + o.ToString() + " has been started.");
										Control.CheckForIllegalCrossThreadCalls = false;
										string proxy2;
										try
										{
											proxy2 = ImpostazioniGlobali.Proxies[new Random().Next(ImpostazioniGlobali.Proxies.Count)];
										}
										catch (Exception)
										{
											proxy2 = "Error";
										}
										HttpClient http = new HttpClient(new HttpClientHandler
										{
											PreAuthenticate = true,
											UseProxy = true,
											Proxy = new WebProxy(proxy2.Split(new char[] { ':' })[0], int.Parse(proxy2.Split(new char[] { ':' })[1]))
										});
										HttpRequestMessage request = new HttpRequestMessage
										{
											RequestUri = new Uri("https://discord.com/api/v9/channels/" + channelId2 + "/messages"),
											Content = new StringContent("{\"content\": \"" + cfrom.ToString() + "\", \"tts\": false}", Encoding.UTF8, "application/json"),
											Method = HttpMethod.Post,
											Headers = 
											{
												{ "Authorization", t },
												{ "Accept-Language", "it" },
												{ "User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36" },
												{ "X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9" },
												{ "Accept", "*/*" },
												{ "Cookie", "locale=it" },
												{
													"Referer",
													"https://discord.com/channels/" + channelId2
												}
											}
										};
										try
										{
											HttpResponseMessage httpResponseMessage = await http.SendAsync(request);
											string text = await httpResponseMessage.Content.ReadAsStringAsync();
											httpResponseMessage = null;
											string _ = text;
											text = null;
											if (_.Contains("{\"id\""))
											{
												ImpostazioniGlobali.Log(string.Concat(new string[]
												{
													proxy2,
													" -> (",
													t,
													") Count [",
													channelId2,
													"] => Message successfully sent (",
													cfrom.ToString(),
													")"
												}));
											}
											else
											{
												ImpostazioniGlobali.Log(string.Concat(new string[] { proxy2, " -> (", t, ") Count [", channelId2, "] => ", _ }));
											}
											_ = null;
										}
										catch
										{
											ImpostazioniGlobali.Log(string.Concat(new string[] { proxy2, " -> (", t, ") Count [", channelId2, "] => Unknown Error [Check your proxies]" }));
										}
									}).Start();
									Thread.Sleep(45);
								}
							}
						});
						this.c_count_thr.Start();
					}
					bool flag3 = cmd.StartsWith("ws-voice-start");
					if (flag3)
					{
						string serverId = cmd.Split(new char[] { ' ' })[1];
						string channelId = cmd.Split(new char[] { ' ' })[2];
						flag = true;
						this.log("Initializing websocket testing process..");
						this.log("Starting Logger..");
						ImpostazioniGlobali.StartLog();
						string token2 = ImpostazioniGlobali.Tokens[new Random().Next(ImpostazioniGlobali.Tokens.Count)];
						Control.CheckForIllegalCrossThreadCalls = false;
						string proxy3;
						try
						{
							proxy3 = ImpostazioniGlobali.Proxies[new Random().Next(ImpostazioniGlobali.Proxies.Count)];
						}
						catch (Exception)
						{
							proxy3 = "Error";
						}
						this.log(string.Concat(new string[] { "Using token: ", token2, " and proxy: ", proxy3, ".." }));
						Task.Run(async delegate
						{
							this.test_ws = new BlackWSManager(token2, proxy3, true, "9");
							this.log("Connecting..");
							this.test_ws.connect();
							this.log("Connection process has started.");
							this.log("Current State: " + this.test_ws.is_connected().ToString());
							this.log("Awaiting for data..");
							bool flag11 = await this.test_ws.WaitForData(5000);
							bool data = flag11;
							if (!data)
							{
								this.log("No data received.");
							}
							else
							{
								this.log("Data success.");
								this.log("Guilds: " + this.test_ws.GetGuilds().Count.ToString());
							}
							this.log(string.Concat(new string[] { "Joining in voice. Server ID=", serverId, " and Channel ID=", channelId, ".." }));
							this.test_ws.voice_connect(serverId, channelId);
						});
					}
					bool flag4 = cmd.StartsWith("ws-cr");
					if (flag4)
					{
						flag = true;
						string g_id = cmd.Split(new char[] { ' ' })[1];
						this.log("Initializing websocket (cr) (gid=" + g_id + ") testing process..");
						this.log("Starting logger..");
						ImpostazioniGlobali.StartLog();
						string token3 = ImpostazioniGlobali.Tokens[new Random().Next(ImpostazioniGlobali.Tokens.Count)];
						Control.CheckForIllegalCrossThreadCalls = false;
						string proxy5;
						try
						{
							proxy5 = ImpostazioniGlobali.Proxies[new Random().Next(ImpostazioniGlobali.Proxies.Count)];
						}
						catch (Exception)
						{
							proxy5 = "Error";
						}
						this.log(string.Concat(new string[] { "Using token: ", token3, " and proxy: ", proxy5, ".." }));
						Task.Run(async delegate
						{
							this.test_ws = new BlackWSManager(token3, proxy5, true, "9");
							this.log("Connecting..");
							this.test_ws.connect();
							this.log("Current State: " + this.test_ws.is_connected().ToString());
							this.log("Awaiting for data..");
							bool flag12 = await this.test_ws.WaitForData(10000);
							bool data2 = flag12;
							if (!data2)
							{
								this.log("No data received.");
							}
							else
							{
								this.log("Connected!");
								this.log("Guilds: " + this.test_ws.GetGuilds().Count.ToString());
								this.log("Sending payload..");
								this.test_ws.send_ws_message("{\"op\":14,\"d\":{\"guild_id\":\"" + g_id + "\",\"channels\":{\"836020859860811777\":[[0, 100]]}}} ");
							}
						});
					}
					bool flag5 = cmd.StartsWith("setBio");
					if (flag5)
					{
						flag = true;
						this.log("Initializing..");
						this.log("Starting Logger..");
						string _bio = cmd.Split(new char[] { ' ' })[1];
						ImpostazioniGlobali.StartLog();
						this.c_count_thr = new Thread(delegate
						{
							this.log("Thread has been started.");
							using (List<string>.Enumerator enumerator2 = ImpostazioniGlobali.Tokens.GetEnumerator())
							{
								while (enumerator2.MoveNext())
								{
									string t = enumerator2.Current;
									new Thread(async delegate
									{
										this.log("A new thread has been started.");
										Control.CheckForIllegalCrossThreadCalls = false;
										string proxy4;
										try
										{
											proxy4 = ImpostazioniGlobali.Proxies[new Random().Next(ImpostazioniGlobali.Proxies.Count)];
										}
										catch (Exception)
										{
											proxy4 = "Error";
										}
										HttpClient http2 = new HttpClient(new HttpClientHandler
										{
											PreAuthenticate = true,
											UseProxy = true,
											Proxy = new WebProxy(proxy4.Split(new char[] { ':' })[0], int.Parse(proxy4.Split(new char[] { ':' })[1]))
										});
										HttpRequestMessage request2 = new HttpRequestMessage
										{
											RequestUri = new Uri("https://discord.com/api/v9/users/@me"),
											Content = new StringContent("{\"bio\": \"" + _bio + "\"}", Encoding.UTF8, "application/json"),
											Method = new HttpMethod("PATCH"),
											Headers = 
											{
												{ "Authorization", t },
												{ "Accept-Language", "it" },
												{ "User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36" },
												{ "X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9" },
												{ "Accept", "*/*" },
												{ "Cookie", "locale=it" },
												{ "Origin", "https://discord.com" },
												{ "Referer", "https://discord.com/channels/@me" }
											}
										};
										request2.Headers.Add("Content-Length", "{\"bio\": \"" + _bio + "\"}".Length.ToString());
										try
										{
											HttpResponseMessage httpResponseMessage2 = await http2.SendAsync(request2);
											string text2 = await httpResponseMessage2.Content.ReadAsStringAsync();
											httpResponseMessage2 = null;
											string _2 = text2;
											text2 = null;
											if (_2.Contains("{\"id\""))
											{
												ImpostazioniGlobali.Log(proxy4 + " -> (" + t + ") Bio => Success.");
											}
											else
											{
												ImpostazioniGlobali.Log(string.Concat(new string[] { proxy4, " -> (", t, ") Bio => ", _2 }));
											}
											_2 = null;
										}
										catch
										{
											ImpostazioniGlobali.Log(proxy4 + " -> (" + t + ") Bio => Unknown Error [Check your proxies]");
										}
									}).Start();
									Thread.Sleep(1);
								}
							}
						});
						this.c_count_thr.Start();
					}
					bool flag6 = cmd == "websocket-test start";
					if (flag6)
					{
						flag = true;
						this.log("Initializing websocket testing process..");
						this.log("Starting logger..");
						ImpostazioniGlobali.StartLog();
						string token = ImpostazioniGlobali.Tokens[new Random().Next(ImpostazioniGlobali.Tokens.Count)];
						Control.CheckForIllegalCrossThreadCalls = false;
						string proxy;
						try
						{
							proxy = ImpostazioniGlobali.Proxies[new Random().Next(ImpostazioniGlobali.Proxies.Count)];
						}
						catch (Exception)
						{
							proxy = "Error";
						}
						this.log(string.Concat(new string[] { "Using token: ", token, " and proxy: ", proxy, ".." }));
						Task.Run(async delegate
						{
							this.test_ws = new BlackWSManager(token, proxy, true, "9");
							this.log("Connecting..");
							this.test_ws.connect();
							this.log("Connection process has started.");
							this.log("Current State: " + this.test_ws.is_connected().ToString());
							this.log("Awaiting for data..");
							bool flag13 = await this.test_ws.WaitForData(10000);
							bool data3 = flag13;
							if (!data3)
							{
								this.log("No data received.");
							}
							else
							{
								this.log("Data success.");
								this.log("Guilds: " + this.test_ws.GetGuilds().Count.ToString());
							}
						});
					}
					else
					{
						bool flag7 = cmd == "websocket-test disconnect";
						if (flag7)
						{
							flag = true;
							this.log("Checking state..");
							bool flag8 = this.test_ws == null;
							if (flag8)
							{
								this.log("Non ci sono websockets attivi. (0x00)");
							}
							else
							{
								this.log("Tentativo di disconnessione con disconnect(null:param:?!0)..");
								this.test_ws.disconnect();
								this.test_ws = null;
								this.log("Successfully Disconnected.");
							}
						}
					}
					bool flag9 = !flag;
					if (flag9)
					{
						this.log("Questo comando non esiste.");
					}
				}
				catch (Exception ex)
				{
					this.log("Si è verificato un errore: " + ex.Message);
				}
			});
			this.log("Comando eseguito. Clicca un pulsante per creare una nuova sessione.");
			this.ses_aw = true;
		}

		// Token: 0x06000127 RID: 295 RVA: 0x000124A4 File Offset: 0x000106A4
		private void siticoneImageButton1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000124AE File Offset: 0x000106AE
		private void siticoneImageButton2_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00002067 File Offset: 0x00000267
		private void logBox_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0400020B RID: 523
		private BlackWSManager test_ws;

		// Token: 0x0400020C RID: 524
		private bool ses_aw = false;

		// Token: 0x0400020D RID: 525
		private Thread c_count_thr;
	}
}
