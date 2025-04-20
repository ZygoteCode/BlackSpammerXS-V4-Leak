using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Siticone.UI.WinForms;

namespace BlackSpammerXS
{
	// Token: 0x02000096 RID: 150
	public class ServerSpammer : UserControl
	{
		// Token: 0x06000276 RID: 630 RVA: 0x0002F454 File Offset: 0x0002D654
		public ServerSpammer()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0002F4C0 File Offset: 0x0002D6C0
		private void sliderThreads_Scroll(object sender, EventArgs e)
		{
			this.del.Text = "Delay: " + this.sliderDelay.Value.ToString() + "ms";
		}

		// Token: 0x06000278 RID: 632 RVA: 0x00002067 File Offset: 0x00000267
		private void hasEmbed_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0002F4FC File Offset: 0x0002D6FC
		private void multi_channel_p(string ch)
		{
			try
			{
				this.multi_channels.Clear();
				this.multi_channels = null;
				this.multi_channels = new List<string>();
				string[] array = ch.Split(new char[] { ',' });
				foreach (string text in array)
				{
					string text2 = text.Replace(" ", "");
					this.multi_channels.Add(text2);
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0002F58C File Offset: 0x0002D78C
		private void multi_msg_p(string ch)
		{
			try
			{
				this.multi_messages.Clear();
				this.multi_messages = null;
				this.multi_messages = new List<string>();
				string[] array = ch.Split(new char[] { ',' });
				foreach (string text in array)
				{
					this.multi_messages.Add(text);
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0002F608 File Offset: 0x0002D808
		private async void startBtn_Click(object sender, EventArgs e)
		{
			bool flag = this.channelId.Text == "" || this.msgContent.Text == "";
			if (flag)
			{
				MessageBox.Show("Channel ID and Message Content are required", "Avviso", ContentAlignment.MiddleCenter);
			}
			else
			{
				this.startBtn.Text = "Starting..";
				this.startBtn.Enabled = false;
				bool flag2 = ImpostazioniGlobali.Tokens == null || ImpostazioniGlobali.Proxies == null;
				if (flag2)
				{
					await Task.Delay(50);
					this.startBtn.Text = "Start";
					this.startBtn.Enabled = true;
					MessageBox.Show("There are no such tokens or proxies", "Avviso", ContentAlignment.MiddleCenter);
				}
				else if (this.hasMultiChannels.Checked && ImpostazioniGlobali.Tokens.Count < 20)
				{
					await Task.Delay(50);
					this.startBtn.Text = "Start";
					this.startBtn.Enabled = true;
					MessageBox.Show("Per utilizzare il multi channel, sono necessari almeno 20 tokens", "Avviso", ContentAlignment.MiddleCenter);
				}
				else
				{
					ImpostazioniGlobali.StartLog();
					this.proxies = ImpostazioniGlobali.Proxies;
					this.random = new Random();
					ImpostazioniGlobali.Log(string.Concat(new string[]
					{
						"Manager -> (Operation Starting) Server Spamming => Spamming in ",
						this.channelId.Text,
						" with ",
						this.proxies.Count.ToString(),
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
						AuditManager auditManager = ImpostazioniGlobali.auditManager;
						auditManager.LogActionSpam(this.channelId.Text, this.msgContent.Text, this.messageReferenceTxt.Text);
						auditManager = null;
					}
					catch (Exception)
					{
					}
					this.cans = true;
					WaitCallback <>9__1;
					this._0 = new Thread(async delegate(object p)
					{
						int max;
						int o;
						ThreadPool.GetMaxThreads(out max, out o);
						ThreadPool.SetMinThreads(o - 1, o - 1);
						while (this.cans)
						{
							Thread.Sleep(1);
							WaitCallback waitCallback;
							if ((waitCallback = <>9__1) == null)
							{
								waitCallback = (<>9__1 = delegate(object mm)
								{
									bool hasDel2 = hasDel;
									if (hasDel2)
									{
										ImpostazioniGlobali.Log(string.Concat(new string[]
										{
											"Manager -> (Delay) (Thread ",
											Thread.CurrentThread.ManagedThreadId.ToString(),
											") Attack => Awaiting ",
											this.sliderDelay.Value.ToString(),
											" before spamming.."
										}));
										Thread.Sleep(this.sliderDelay.Value);
									}
									bool @checked = this.hasMultiChannels.Checked;
									if (@checked)
									{
										this.multi_channel_p(this.channelId.Text);
									}
									bool checked2 = this.hasMultiMessages.Checked;
									if (checked2)
									{
										this.multi_msg_p(this.msgContent.Text);
									}
									this.doSpam(null, hasDel);
								});
							}
							ThreadPool.UnsafeQueueUserWorkItem(waitCallback, null);
						}
					});
					this._0.Start();
					await Task.Delay(100);
					this.startBtn.Text = "Start";
					this.stopBtn.Enabled = true;
				}
			}
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0002F650 File Offset: 0x0002D850
		public static string RandomString(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789", length)
				select s[ServerSpammer.randdom.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0002F69C File Offset: 0x0002D89C
		public string RandStr()
		{
			return ServerSpammer.RandomString(15);
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0002F6B8 File Offset: 0x0002D8B8
		private string RepeatMTXF(int t)
		{
			string text = "";
			int i = 0;
			while (i > t + 1)
			{
				text = text + "<@" + this.users[this.random.Next(this.users.Count)] + ">";
				t++;
			}
			return text;
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0002F718 File Offset: 0x0002D918
		private async void doSpam(object o, bool hasDel)
		{
			bool flag = ImpostazioniGlobali.Tokens == null || ImpostazioniGlobali.Tokens.Count == 0;
			if (flag)
			{
				this.cans = false;
			}
			bool flag2 = !this.cans;
			if (flag2)
			{
				Thread.CurrentThread.Interrupt();
			}
			else
			{
				string token = ImpostazioniGlobali.Tokens[this.random.Next(ImpostazioniGlobali.Tokens.Count)];
				Control.CheckForIllegalCrossThreadCalls = false;
				string proxy;
				try
				{
					proxy = this.proxies[this.random.Next(this.proxies.Count)];
				}
				catch (Exception)
				{
					proxy = "Error";
				}
				Control.CheckForIllegalCrossThreadCalls = false;
				bool flag3 = !this.cans;
				if (flag3)
				{
					Thread.CurrentThread.Interrupt();
				}
				else
				{
					try
					{
						if (hasDel)
						{
							ImpostazioniGlobali.Log(string.Concat(new string[]
							{
								"Manager -> (Delay) (Thread ",
								Thread.CurrentThread.ManagedThreadId.ToString(),
								") Attack => Awaiting ",
								this.sliderDelay.Value.ToString(),
								" before spamming.."
							}));
							Thread.Sleep(this.sliderDelay.Value);
						}
						HttpClientHandler handler = new HttpClientHandler();
						handler.PreAuthenticate = true;
						handler.UseProxy = true;
						handler.Proxy = new WebProxy(proxy.Split(new char[] { ':' })[0], int.Parse(proxy.Split(new char[] { ':' })[1]));
						string msg = this.msgContent.Text;
						bool @checked = this.hasMultiMessages.Checked;
						if (@checked)
						{
							msg = this.multi_messages[ServerSpammer.randdom.Next(this.multi_messages.Count)];
						}
						List<string> msgLines = new List<string>(this.msgContent.Lines);
						bool flag4 = msgLines.Count != 1;
						if (flag4)
						{
							string mmr = "";
							foreach (string line in msgLines)
							{
								mmr = mmr + " \\u000d" + line;
								line = null;
							}
							List<string>.Enumerator enumerator = default(List<string>.Enumerator);
							msg = mmr;
							mmr = null;
						}
						bool flag5 = this.hasMassTag.Checked && this.users.Count > 0;
						if (flag5)
						{
							try
							{
								msg = msg.Replace("[mtag]", "<@" + this.users[this.random.Next(this.users.Count)] + ">");
								int num;
								for (int nnnn = 0; nnnn < 101; nnnn = num + 1)
								{
									msg = msg.Replace("[mtag" + nnnn.ToString() + "]", "<@" + this.users[this.random.Next(this.users.Count)] + ">");
									num = nnnn;
								}
							}
							catch (Exception)
							{
							}
						}
						bool flag6 = msg.Contains("[rand]");
						if (flag6)
						{
							msg = msg.Replace("[rand]", this.RandStr());
						}
						string payload__c = "{\"content\": \"" + msg + "\", \"tts\": false}";
						string channel_af = this.channelId.Text;
						bool checked2 = this.hasMultiChannels.Checked;
						if (checked2)
						{
							channel_af = this.multi_channels[ServerSpammer.randdom.Next(this.multi_channels.Count)];
						}
						bool flag7 = this.messageReferenceTxt.Text.Length != 0;
						if (flag7)
						{
							payload__c = string.Concat(new string[]
							{
								"{\"content\": \"",
								msg,
								"\",\"message_reference\": {\"channel_id\": \"",
								channel_af,
								"\", \"message_id\": \"",
								this.messageReferenceTxt.Text,
								"\"},\"tts\": false}"
							});
						}
						HttpClient http = new HttpClient(handler);
						HttpRequestMessage request = new HttpRequestMessage
						{
							RequestUri = new Uri("https://discord.com/api/v9/channels/" + channel_af + "/messages"),
							Content = new StringContent(payload__c, Encoding.UTF8, "application/json"),
							Method = HttpMethod.Post,
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
									"https://discord.com/channels/" + channel_af
								}
							}
						};
						HttpResponseMessage httpResponseMessage = await http.SendAsync(request);
						string text = await httpResponseMessage.Content.ReadAsStringAsync();
						httpResponseMessage = null;
						string _ = text;
						text = null;
						if (_.Contains("{\"id\":"))
						{
							if (!this.hasMultiChannels.Checked)
							{
								ImpostazioniGlobali.Log(string.Concat(new string[] { proxy, " -> (", token, ") Server Spamming [", channel_af, "] => Message successfully sent" }));
							}
							else
							{
								ImpostazioniGlobali.Log(string.Concat(new string[] { proxy, " -> (", token, ") [Multi Channel] Server Spamming [", channel_af, "] => Message successfully sent" }));
							}
						}
						else if (ImpostazioniGlobali.StreamerMode)
						{
							ImpostazioniGlobali.Log(string.Concat(new string[]
							{
								proxy,
								" -> (Token ",
								ImpostazioniGlobali.Tokens.IndexOf(token).ToString(),
								") Server Spamming [",
								channel_af,
								"] => ",
								_
							}));
						}
						else if (!this.hasMultiChannels.Checked)
						{
							ImpostazioniGlobali.Log(string.Concat(new string[] { proxy, " -> (", token, ") Server Spamming [", channel_af, "] => ", _ }));
						}
						else
						{
							ImpostazioniGlobali.Log(string.Concat(new string[] { proxy, " -> (", token, ") [Multi Channel] Server Spamming [", channel_af, "] => ", _ }));
						}
						try
						{
							if (_.Contains("{\"id\":"))
							{
								if (this.currentMessages > 100000000UL)
								{
									this.label9.Text = "Live Text (∞)";
								}
								else
								{
									this.currentMessages += 1UL;
									this.label9.Text = "Live Text (" + this.currentMessages.ToString() + ")";
								}
							}
						}
						catch
						{
						}
						try
						{
							http.Dispose();
							handler.Dispose();
							request.Dispose();
							http = null;
							handler = null;
							msg = null;
							payload__c = null;
							_ = null;
							request = null;
							msgLines = null;
							token = null;
							proxy = null;
						}
						catch
						{
						}
						try
						{
							Thread.CurrentThread.Abort();
						}
						catch
						{
						}
						handler = null;
						msg = null;
						msgLines = null;
						payload__c = null;
						channel_af = null;
						http = null;
						request = null;
						_ = null;
					}
					catch (Exception exc)
					{
						if (exc.GetType() == typeof(ThreadAbortException))
						{
							exc = null;
						}
						else
						{
							if (ImpostazioniGlobali.StreamerMode)
							{
								ImpostazioniGlobali.Log(string.Concat(new string[]
								{
									proxy,
									" -> (Token ",
									ImpostazioniGlobali.Tokens.IndexOf(token).ToString(),
									") Server Spamming [",
									this.channelId.Text,
									"] => Unknown Error [Check your proxies]"
								}));
							}
							else
							{
								ImpostazioniGlobali.Log(string.Concat(new string[]
								{
									proxy,
									" -> (",
									token,
									") Server Spamming [",
									this.channelId.Text,
									"] => Unknown Error [Check your proxies]"
								}));
							}
							exc = null;
							try
							{
								Thread.CurrentThread.Abort();
							}
							catch
							{
							}
						}
					}
				}
			}
		}

		// Token: 0x06000280 RID: 640 RVA: 0x00002067 File Offset: 0x00000267
		private void hasLive_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0002F760 File Offset: 0x0002D960
		private async void hasLive_Click(object sender, EventArgs e)
		{
			try
			{
				await Task.Run(delegate
				{
					Thread.Sleep(100);
				});
				this.hasLive.Checked = true;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0002F7A8 File Offset: 0x0002D9A8
		private void stopBtn_Click(object sender, EventArgs e)
		{
			try
			{
				this.cans = false;
				this.stopBtn.Enabled = false;
				this.startBtn.Enabled = true;
				try
				{
					this._0.Abort();
				}
				catch
				{
				}
				this._0 = null;
				this.currentMessages = 0UL;
				this.label9.Text = "Live Text";
				this.currentMessages = 0UL;
				ImpostazioniGlobali.Log("Manager -> (Stop) Server Spamming [" + this.channelId.Text + "] => Attack stopped.");
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00002067 File Offset: 0x00000267
		private void hasMassTag_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0002F85C File Offset: 0x0002DA5C
		private void stopBtn_MouseLeave(object sender, EventArgs e)
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

		// Token: 0x06000285 RID: 645 RVA: 0x0002F89C File Offset: 0x0002DA9C
		private void stopBtn_MouseEnter(object sender, EventArgs e)
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

		// Token: 0x06000286 RID: 646 RVA: 0x0002F8DC File Offset: 0x0002DADC
		public void Dark()
		{
			Color color = Color.FromArgb(44, 47, 51);
			this.BackColor = color;
			Color dimGray = Color.DimGray;
			try
			{
				foreach (SiticoneButton siticoneButton in new List<SiticoneButton> { this.stopBtn, this.startBtn })
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
				this.msgContent.ForeColor = Color.White;
				this.msgContent.FillColor = color;
				this.msgContent.BorderColor = Color.Gray;
				this.msgContent.HoveredState.BorderColor = Color.Gray;
				this.messageReferenceTxt.ForeColor = Color.White;
				this.messageReferenceTxt.FillColor = color;
				this.messageReferenceTxt.BorderColor = Color.Gray;
				this.messageReferenceTxt.HoveredState.BorderColor = Color.Gray;
				this.sliderDelay.FillColor = Color.Gray;
				this.sliderDelay.ThumbColor = Color.RoyalBlue;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0002FAC8 File Offset: 0x0002DCC8
		private void ServerSpammer_Load(object sender, EventArgs e)
		{
			Control.CheckForIllegalCrossThreadCalls = false;
			ImpostazioniGlobali._bridgeGS = delegate(int a, int b, object c)
			{
				bool flag = a == 1 && b == 1;
				if (flag)
				{
					this.users.Add(((c != null) ? c.ToString() : null) ?? "");
					this.label8.Text = "Mass Tag V2X (" + this.users.Count.ToString() + ")";
				}
				bool flag2 = a == 1 && b == 2;
				if (flag2)
				{
					this.users.Remove(((c != null) ? c.ToString() : null) ?? "");
					this.label8.Text = "Mass Tag V2X (" + this.users.Count.ToString() + ")";
				}
				bool flag3 = a == 1 && b == 0;
				if (flag3)
				{
					this.users.Clear();
					this.label8.Text = "Mass Tag V2X";
				}
			};
			ImpostazioniGlobali._bridgeLogPerform.Add(delegate(int a, int b, object[] i)
			{
				bool flag4 = a == 1;
				if (flag4)
				{
					try
					{
						this.channelId.Text = (string)i[0];
						this.msgContent.Text = (string)i[1];
						this.messageReferenceTxt.Text = (string)i[2];
					}
					catch (Exception)
					{
					}
				}
			});
		}

		// Token: 0x06000288 RID: 648 RVA: 0x00002067 File Offset: 0x00000267
		private void tdel_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000289 RID: 649 RVA: 0x00002067 File Offset: 0x00000267
		private void xsmodeTypeEnable_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0002FAFC File Offset: 0x0002DCFC
		private void xsmodeTypeEnable_Click(object sender, EventArgs e)
		{
			this.xsmodeTypeEnable.Checked = true;
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0002FB1C File Offset: 0x0002DD1C
		private void tdel_Click(object sender, EventArgs e)
		{
			bool @checked = this.tdel.Checked;
			if (@checked)
			{
				this.xsmodeTypeEnable.Checked = false;
				this.label8.Text = "Old V2X Mass Tag";
			}
			else
			{
				this.xsmodeTypeEnable.Checked = true;
				this.label8.Text = "Mass Tag V3X";
			}
		}

		// Token: 0x0600028C RID: 652 RVA: 0x00002067 File Offset: 0x00000267
		private void hasDelay_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600028D RID: 653 RVA: 0x00002067 File Offset: 0x00000267
		private void mbvfbypass_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00002067 File Offset: 0x00000267
		private void label3_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600028F RID: 655 RVA: 0x0002FB7C File Offset: 0x0002DD7C
		private void hasMultiChannels_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.hasMultiChannels.Checked;
			if (@checked)
			{
				this.channelId.PlaceholderText = "Channels ID (separated by comma)";
			}
			else
			{
				this.channelId.PlaceholderText = "Channel ID";
			}
		}

		// Token: 0x06000290 RID: 656 RVA: 0x00002067 File Offset: 0x00000267
		private void channelId_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0002FBC4 File Offset: 0x0002DDC4
		private void siticoneCustomCheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.hasMultiMessages.Checked;
			if (@checked)
			{
				this.msgContent.PlaceholderText = "Messages (separated by comma)";
			}
			else
			{
				this.msgContent.PlaceholderText = "Message";
			}
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0002FC0C File Offset: 0x0002DE0C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0002FC44 File Offset: 0x0002DE44
		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ServerSpammer));
			this.label1 = new Label();
			this.channelId = new SiticoneTextBox();
			this.msgContent = new SiticoneTextBox();
			this.startBtn = new SiticoneButton();
			this.stopBtn = new SiticoneButton();
			this.label9 = new Label();
			this.label8 = new Label();
			this.hasMassTag = new SiticoneCustomCheckBox();
			this.hasLive = new SiticoneCustomCheckBox();
			this.hasDelay = new SiticoneToggleSwitch();
			this.del = new Label();
			this.sliderDelay = new SiticoneSlider();
			this.label2 = new Label();
			this.tdel = new SiticoneToggleSwitch();
			this.pictureBox2 = new PictureBox();
			this.siticoneDragControl1 = new SiticoneDragControl(this.components);
			this.label3 = new Label();
			this.xsmodeTypeEnable = new SiticoneToggleSwitch();
			this.label4 = new Label();
			this.messageReferenceTxt = new SiticoneTextBox();
			this.label5 = new Label();
			this.hasMultiChannels = new SiticoneCustomCheckBox();
			this.label6 = new Label();
			this.hasMultiMessages = new SiticoneCustomCheckBox();
			((ISupportInitialize)this.pictureBox2).BeginInit();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Inter", 15.75f, FontStyle.Bold);
			this.label1.Location = new Point(13, 43);
			this.label1.Name = "label1";
			this.label1.Size = new Size(186, 25);
			this.label1.TabIndex = 2;
			this.label1.Text = "Server Spammer";
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
			this.channelId.Font = new Font("SF Pro Display", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.channelId.ForeColor = Color.Black;
			this.channelId.HoveredState.BorderColor = Color.FromArgb(213, 218, 223);
			this.channelId.HoveredState.Parent = this.channelId;
			this.channelId.Location = new Point(18, 139);
			this.channelId.Margin = new Padding(4, 3, 4, 3);
			this.channelId.Name = "channelId";
			this.channelId.PasswordChar = '\0';
			this.channelId.PlaceholderText = "Channel ID ";
			this.channelId.SelectedText = "";
			this.channelId.ShadowDecoration.Parent = this.channelId;
			this.channelId.Size = new Size(658, 35);
			this.channelId.TabIndex = 34;
			this.channelId.TextChanged += this.channelId_TextChanged;
			this.msgContent.Animated = false;
			this.msgContent.BackColor = Color.Transparent;
			this.msgContent.BorderRadius = 4;
			this.msgContent.BorderThickness = 2;
			this.msgContent.Cursor = Cursors.IBeam;
			this.msgContent.DefaultText = "";
			this.msgContent.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			this.msgContent.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			this.msgContent.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			this.msgContent.DisabledState.Parent = this.msgContent;
			this.msgContent.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			this.msgContent.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.msgContent.FocusedState.Parent = this.msgContent;
			this.msgContent.Font = new Font("SF Pro Display", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.msgContent.ForeColor = Color.Black;
			this.msgContent.HoveredState.BorderColor = Color.FromArgb(213, 218, 223);
			this.msgContent.HoveredState.Parent = this.msgContent;
			this.msgContent.Location = new Point(18, 225);
			this.msgContent.Margin = new Padding(4, 3, 4, 3);
			this.msgContent.Multiline = true;
			this.msgContent.Name = "msgContent";
			this.msgContent.PasswordChar = '\0';
			this.msgContent.PlaceholderText = "Message";
			this.msgContent.SelectedText = "";
			this.msgContent.ShadowDecoration.Parent = this.msgContent;
			this.msgContent.Size = new Size(658, 130);
			this.msgContent.TabIndex = 35;
			this.startBtn.BackColor = Color.Transparent;
			this.startBtn.BorderColor = Color.LightGray;
			this.startBtn.BorderRadius = 4;
			this.startBtn.BorderStyle = DashStyle.Dot;
			this.startBtn.BorderThickness = 1;
			this.startBtn.CheckedState.Parent = this.startBtn;
			this.startBtn.Cursor = Cursors.Hand;
			this.startBtn.CustomImages.Parent = this.startBtn;
			this.startBtn.FillColor = Color.Snow;
			this.startBtn.Font = new Font("Inter", 9.749999f, FontStyle.Bold);
			this.startBtn.ForeColor = Color.Black;
			this.startBtn.HoveredState.Parent = this.startBtn;
			this.startBtn.Location = new Point(18, 514);
			this.startBtn.Name = "startBtn";
			this.startBtn.PressedColor = Color.White;
			this.startBtn.ShadowDecoration.Parent = this.startBtn;
			this.startBtn.Size = new Size(326, 29);
			this.startBtn.TabIndex = 36;
			this.startBtn.Text = "Start";
			this.startBtn.TextRenderingHint = TextRenderingHint.AntiAlias;
			this.startBtn.Click += this.startBtn_Click;
			this.startBtn.MouseEnter += this.stopBtn_MouseEnter;
			this.startBtn.MouseLeave += this.stopBtn_MouseLeave;
			this.stopBtn.BackColor = Color.Transparent;
			this.stopBtn.BorderColor = Color.LightGray;
			this.stopBtn.BorderRadius = 4;
			this.stopBtn.BorderStyle = DashStyle.Dot;
			this.stopBtn.BorderThickness = 1;
			this.stopBtn.CheckedState.Parent = this.stopBtn;
			this.stopBtn.Cursor = Cursors.Hand;
			this.stopBtn.CustomImages.Parent = this.stopBtn;
			this.stopBtn.Enabled = false;
			this.stopBtn.FillColor = Color.Snow;
			this.stopBtn.Font = new Font("Inter", 9.749999f, FontStyle.Bold);
			this.stopBtn.ForeColor = Color.Black;
			this.stopBtn.HoveredState.Parent = this.stopBtn;
			this.stopBtn.Location = new Point(350, 514);
			this.stopBtn.Name = "stopBtn";
			this.stopBtn.PressedColor = Color.White;
			this.stopBtn.ShadowDecoration.Parent = this.stopBtn;
			this.stopBtn.Size = new Size(326, 29);
			this.stopBtn.TabIndex = 37;
			this.stopBtn.Text = "Stop";
			this.stopBtn.TextRenderingHint = TextRenderingHint.AntiAlias;
			this.stopBtn.Click += this.stopBtn_Click;
			this.stopBtn.MouseEnter += this.stopBtn_MouseEnter;
			this.stopBtn.MouseLeave += this.stopBtn_MouseLeave;
			this.label9.AutoSize = true;
			this.label9.Font = new Font("SF Pro Text", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label9.Location = new Point(42, 367);
			this.label9.Name = "label9";
			this.label9.Size = new Size(60, 14);
			this.label9.TabIndex = 41;
			this.label9.Text = "Live Text";
			this.label8.AutoSize = true;
			this.label8.Font = new Font("SF Pro Text", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label8.Location = new Point(42, 388);
			this.label8.Name = "label8";
			this.label8.Size = new Size(93, 14);
			this.label8.TabIndex = 40;
			this.label8.Text = "Mass Tag V2X";
			this.hasMassTag.BackColor = Color.Transparent;
			this.hasMassTag.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.hasMassTag.CheckedState.BorderRadius = 2;
			this.hasMassTag.CheckedState.BorderThickness = 0;
			this.hasMassTag.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.hasMassTag.CheckedState.Parent = this.hasMassTag;
			this.hasMassTag.Cursor = Cursors.Hand;
			this.hasMassTag.Location = new Point(24, 387);
			this.hasMassTag.Name = "hasMassTag";
			this.hasMassTag.ShadowDecoration.Parent = this.hasMassTag;
			this.hasMassTag.Size = new Size(15, 15);
			this.hasMassTag.TabIndex = 39;
			this.hasMassTag.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.hasMassTag.UncheckedState.BorderRadius = 2;
			this.hasMassTag.UncheckedState.BorderThickness = 0;
			this.hasMassTag.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.hasMassTag.UncheckedState.Parent = this.hasMassTag;
			this.hasMassTag.CheckedChanged += this.hasMassTag_CheckedChanged;
			this.hasMassTag.Click += this.hasEmbed_Click;
			this.hasLive.Checked = true;
			this.hasLive.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.hasLive.CheckedState.BorderRadius = 2;
			this.hasLive.CheckedState.BorderThickness = 0;
			this.hasLive.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.hasLive.CheckedState.Parent = this.hasLive;
			this.hasLive.CheckState = CheckState.Checked;
			this.hasLive.Cursor = Cursors.Hand;
			this.hasLive.Location = new Point(24, 366);
			this.hasLive.Name = "hasLive";
			this.hasLive.ShadowDecoration.Parent = this.hasLive;
			this.hasLive.Size = new Size(15, 15);
			this.hasLive.TabIndex = 38;
			this.hasLive.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.hasLive.UncheckedState.BorderRadius = 2;
			this.hasLive.UncheckedState.BorderThickness = 0;
			this.hasLive.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.hasLive.UncheckedState.Parent = this.hasLive;
			this.hasLive.CheckedChanged += this.hasLive_CheckedChanged;
			this.hasLive.Click += this.hasLive_Click;
			this.hasDelay.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.hasDelay.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.hasDelay.CheckedState.InnerBorderColor = Color.White;
			this.hasDelay.CheckedState.InnerColor = Color.White;
			this.hasDelay.CheckedState.Parent = this.hasDelay;
			this.hasDelay.Cursor = Cursors.Hand;
			this.hasDelay.Location = new Point(528, 376);
			this.hasDelay.Name = "hasDelay";
			this.hasDelay.ShadowDecoration.Parent = this.hasDelay;
			this.hasDelay.Size = new Size(32, 20);
			this.hasDelay.TabIndex = 43;
			this.hasDelay.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.hasDelay.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.hasDelay.UncheckedState.InnerBorderColor = Color.White;
			this.hasDelay.UncheckedState.InnerColor = Color.White;
			this.hasDelay.UncheckedState.Parent = this.hasDelay;
			this.hasDelay.CheckedChanged += this.hasDelay_CheckedChanged;
			this.del.AutoSize = true;
			this.del.Font = new Font("SF Pro Text", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.del.Location = new Point(565, 378);
			this.del.Name = "del";
			this.del.Size = new Size(82, 14);
			this.del.TabIndex = 42;
			this.del.Text = "Delay: 50ms";
			this.sliderDelay.Cursor = Cursors.Hand;
			this.sliderDelay.LargeChange = 5;
			this.sliderDelay.Location = new Point(24, 448);
			this.sliderDelay.Name = "sliderDelay";
			this.sliderDelay.Size = new Size(652, 60);
			this.sliderDelay.TabIndex = 44;
			this.sliderDelay.Value = 50;
			this.sliderDelay.Scroll += this.sliderThreads_Scroll;
			this.label2.AutoSize = true;
			this.label2.Font = new Font("SF Pro Text", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label2.Location = new Point(564, 407);
			this.label2.Name = "label2";
			this.label2.Size = new Size(100, 14);
			this.label2.TabIndex = 46;
			this.label2.Text = "Old X Mass Tag";
			this.tdel.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.tdel.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.tdel.CheckedState.InnerBorderColor = Color.White;
			this.tdel.CheckedState.InnerColor = Color.White;
			this.tdel.CheckedState.Parent = this.tdel;
			this.tdel.Cursor = Cursors.Hand;
			this.tdel.Enabled = false;
			this.tdel.Location = new Point(528, 403);
			this.tdel.Name = "tdel";
			this.tdel.ShadowDecoration.Parent = this.tdel;
			this.tdel.Size = new Size(32, 20);
			this.tdel.TabIndex = 47;
			this.tdel.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.tdel.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.tdel.UncheckedState.InnerBorderColor = Color.White;
			this.tdel.UncheckedState.InnerColor = Color.White;
			this.tdel.UncheckedState.Parent = this.tdel;
			this.tdel.CheckedChanged += this.tdel_CheckedChanged;
			this.tdel.Click += this.tdel_Click;
			this.pictureBox2.Image = (Image)componentResourceManager.GetObject("pictureBox2.Image");
			this.pictureBox2.Location = new Point(647, 42);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new Size(35, 23);
			this.pictureBox2.TabIndex = 68;
			this.pictureBox2.TabStop = false;
			this.siticoneDragControl1.TargetControl = this;
			this.label3.AutoSize = true;
			this.label3.Font = new Font("SF Pro Text", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label3.ForeColor = Color.Teal;
			this.label3.Location = new Point(19, 78);
			this.label3.Name = "label3";
			this.label3.Size = new Size(498, 45);
			this.label3.TabIndex = 69;
			this.label3.Text = componentResourceManager.GetString("label3.Text");
			this.label3.Click += this.label3_Click;
			this.xsmodeTypeEnable.Checked = true;
			this.xsmodeTypeEnable.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.xsmodeTypeEnable.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.xsmodeTypeEnable.CheckedState.InnerBorderColor = Color.White;
			this.xsmodeTypeEnable.CheckedState.InnerColor = Color.White;
			this.xsmodeTypeEnable.CheckedState.Parent = this.xsmodeTypeEnable;
			this.xsmodeTypeEnable.Cursor = Cursors.Hand;
			this.xsmodeTypeEnable.Location = new Point(584, 94);
			this.xsmodeTypeEnable.Name = "xsmodeTypeEnable";
			this.xsmodeTypeEnable.ShadowDecoration.Parent = this.xsmodeTypeEnable;
			this.xsmodeTypeEnable.Size = new Size(32, 20);
			this.xsmodeTypeEnable.TabIndex = 71;
			this.xsmodeTypeEnable.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.xsmodeTypeEnable.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.xsmodeTypeEnable.UncheckedState.InnerBorderColor = Color.White;
			this.xsmodeTypeEnable.UncheckedState.InnerColor = Color.White;
			this.xsmodeTypeEnable.UncheckedState.Parent = this.xsmodeTypeEnable;
			this.xsmodeTypeEnable.CheckedChanged += this.xsmodeTypeEnable_CheckedChanged;
			this.xsmodeTypeEnable.Click += this.xsmodeTypeEnable_Click;
			this.label4.AutoSize = true;
			this.label4.Font = new Font("SF Pro Text", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label4.Location = new Point(621, 97);
			this.label4.Name = "label4";
			this.label4.Size = new Size(44, 14);
			this.label4.TabIndex = 70;
			this.label4.Text = "XS V4";
			this.messageReferenceTxt.Animated = false;
			this.messageReferenceTxt.BackColor = Color.Transparent;
			this.messageReferenceTxt.BorderRadius = 4;
			this.messageReferenceTxt.BorderThickness = 2;
			this.messageReferenceTxt.Cursor = Cursors.IBeam;
			this.messageReferenceTxt.DefaultText = "";
			this.messageReferenceTxt.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			this.messageReferenceTxt.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			this.messageReferenceTxt.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			this.messageReferenceTxt.DisabledState.Parent = this.messageReferenceTxt;
			this.messageReferenceTxt.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			this.messageReferenceTxt.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.messageReferenceTxt.FocusedState.Parent = this.messageReferenceTxt;
			this.messageReferenceTxt.Font = new Font("SF Pro Display", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.messageReferenceTxt.ForeColor = Color.Black;
			this.messageReferenceTxt.HoveredState.BorderColor = Color.FromArgb(213, 218, 223);
			this.messageReferenceTxt.HoveredState.Parent = this.messageReferenceTxt;
			this.messageReferenceTxt.Location = new Point(18, 180);
			this.messageReferenceTxt.Margin = new Padding(4, 3, 4, 3);
			this.messageReferenceTxt.Name = "messageReferenceTxt";
			this.messageReferenceTxt.PasswordChar = '\0';
			this.messageReferenceTxt.PlaceholderText = "Message Reference*";
			this.messageReferenceTxt.SelectedText = "";
			this.messageReferenceTxt.ShadowDecoration.Parent = this.messageReferenceTxt;
			this.messageReferenceTxt.Size = new Size(658, 39);
			this.messageReferenceTxt.TabIndex = 72;
			this.label5.AutoSize = true;
			this.label5.Font = new Font("SF Pro Text", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label5.Location = new Point(42, 410);
			this.label5.Name = "label5";
			this.label5.Size = new Size(92, 14);
			this.label5.TabIndex = 74;
			this.label5.Text = "Multi Channel";
			this.hasMultiChannels.BackColor = Color.Transparent;
			this.hasMultiChannels.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.hasMultiChannels.CheckedState.BorderRadius = 2;
			this.hasMultiChannels.CheckedState.BorderThickness = 0;
			this.hasMultiChannels.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.hasMultiChannels.CheckedState.Parent = this.hasMultiChannels;
			this.hasMultiChannels.Cursor = Cursors.Hand;
			this.hasMultiChannels.Location = new Point(24, 409);
			this.hasMultiChannels.Name = "hasMultiChannels";
			this.hasMultiChannels.ShadowDecoration.Parent = this.hasMultiChannels;
			this.hasMultiChannels.Size = new Size(15, 15);
			this.hasMultiChannels.TabIndex = 73;
			this.hasMultiChannels.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.hasMultiChannels.UncheckedState.BorderRadius = 2;
			this.hasMultiChannels.UncheckedState.BorderThickness = 0;
			this.hasMultiChannels.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.hasMultiChannels.UncheckedState.Parent = this.hasMultiChannels;
			this.hasMultiChannels.CheckedChanged += this.hasMultiChannels_CheckedChanged;
			this.label6.AutoSize = true;
			this.label6.Font = new Font("SF Pro Text", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label6.Location = new Point(42, 431);
			this.label6.Name = "label6";
			this.label6.Size = new Size(102, 14);
			this.label6.TabIndex = 76;
			this.label6.Text = "Multi Messages";
			this.hasMultiMessages.BackColor = Color.Transparent;
			this.hasMultiMessages.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.hasMultiMessages.CheckedState.BorderRadius = 2;
			this.hasMultiMessages.CheckedState.BorderThickness = 0;
			this.hasMultiMessages.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.hasMultiMessages.CheckedState.Parent = this.hasMultiMessages;
			this.hasMultiMessages.Cursor = Cursors.Hand;
			this.hasMultiMessages.Location = new Point(24, 430);
			this.hasMultiMessages.Name = "hasMultiMessages";
			this.hasMultiMessages.ShadowDecoration.Parent = this.hasMultiMessages;
			this.hasMultiMessages.Size = new Size(15, 15);
			this.hasMultiMessages.TabIndex = 75;
			this.hasMultiMessages.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.hasMultiMessages.UncheckedState.BorderRadius = 2;
			this.hasMultiMessages.UncheckedState.BorderThickness = 0;
			this.hasMultiMessages.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.hasMultiMessages.UncheckedState.Parent = this.hasMultiMessages;
			this.hasMultiMessages.CheckedChanged += this.siticoneCustomCheckBox1_CheckedChanged;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.label6);
			base.Controls.Add(this.hasMultiMessages);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.hasMultiChannels);
			base.Controls.Add(this.messageReferenceTxt);
			base.Controls.Add(this.xsmodeTypeEnable);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.pictureBox2);
			base.Controls.Add(this.tdel);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.sliderDelay);
			base.Controls.Add(this.hasDelay);
			base.Controls.Add(this.del);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.hasMassTag);
			base.Controls.Add(this.hasLive);
			base.Controls.Add(this.stopBtn);
			base.Controls.Add(this.startBtn);
			base.Controls.Add(this.msgContent);
			base.Controls.Add(this.channelId);
			base.Controls.Add(this.label1);
			base.Name = "ServerSpammer";
			base.Size = new Size(695, 560);
			base.Load += this.ServerSpammer_Load;
			((ISupportInitialize)this.pictureBox2).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040005BD RID: 1469
		private bool cans = false;

		// Token: 0x040005BE RID: 1470
		private Thread _0;

		// Token: 0x040005BF RID: 1471
		private List<string> users = new List<string>();

		// Token: 0x040005C0 RID: 1472
		private Random random = new Random();

		// Token: 0x040005C1 RID: 1473
		private List<string> proxies = ImpostazioniGlobali.Proxies;

		// Token: 0x040005C2 RID: 1474
		private List<string> multi_channels = new List<string>();

		// Token: 0x040005C3 RID: 1475
		private List<string> multi_messages = new List<string>();

		// Token: 0x040005C4 RID: 1476
		private static Random randdom = new Random();

		// Token: 0x040005C5 RID: 1477
		private ulong currentMessages = 0UL;

		// Token: 0x040005C6 RID: 1478
		private IContainer components = null;

		// Token: 0x040005C7 RID: 1479
		private Label label1;

		// Token: 0x040005C8 RID: 1480
		private SiticoneTextBox channelId;

		// Token: 0x040005C9 RID: 1481
		private SiticoneTextBox msgContent;

		// Token: 0x040005CA RID: 1482
		private SiticoneButton startBtn;

		// Token: 0x040005CB RID: 1483
		private SiticoneButton stopBtn;

		// Token: 0x040005CC RID: 1484
		private Label label9;

		// Token: 0x040005CD RID: 1485
		private Label label8;

		// Token: 0x040005CE RID: 1486
		private SiticoneCustomCheckBox hasMassTag;

		// Token: 0x040005CF RID: 1487
		private SiticoneCustomCheckBox hasLive;

		// Token: 0x040005D0 RID: 1488
		private SiticoneToggleSwitch hasDelay;

		// Token: 0x040005D1 RID: 1489
		private Label del;

		// Token: 0x040005D2 RID: 1490
		private SiticoneSlider sliderDelay;

		// Token: 0x040005D3 RID: 1491
		private Label label2;

		// Token: 0x040005D4 RID: 1492
		private SiticoneToggleSwitch tdel;

		// Token: 0x040005D5 RID: 1493
		private PictureBox pictureBox2;

		// Token: 0x040005D6 RID: 1494
		private SiticoneDragControl siticoneDragControl1;

		// Token: 0x040005D7 RID: 1495
		private Label label3;

		// Token: 0x040005D8 RID: 1496
		private SiticoneToggleSwitch xsmodeTypeEnable;

		// Token: 0x040005D9 RID: 1497
		private Label label4;

		// Token: 0x040005DA RID: 1498
		private SiticoneTextBox messageReferenceTxt;

		// Token: 0x040005DB RID: 1499
		private Label label5;

		// Token: 0x040005DC RID: 1500
		private SiticoneCustomCheckBox hasMultiChannels;

		// Token: 0x040005DD RID: 1501
		private Label label6;

		// Token: 0x040005DE RID: 1502
		private SiticoneCustomCheckBox hasMultiMessages;
	}
}
