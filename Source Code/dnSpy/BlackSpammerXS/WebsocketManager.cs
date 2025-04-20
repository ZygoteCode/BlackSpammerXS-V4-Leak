using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Siticone.UI.WinForms;

namespace BlackSpammerXS
{
	// Token: 0x020000A1 RID: 161
	public class WebsocketManager : UserControl
	{
		// Token: 0x060002B7 RID: 695 RVA: 0x00033BBC File Offset: 0x00031DBC
		public WebsocketManager()
		{
			this.InitializeComponent();
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00033BE8 File Offset: 0x00031DE8
		private void sliderDelay_Scroll(object sender, EventArgs e)
		{
			this.del.Text = "Volume: " + this.sliderDelay.Value.ToString() + "%";
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x00033C24 File Offset: 0x00031E24
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
				this.guildId.ForeColor = Color.White;
				this.guildId.FillColor = color;
				this.guildId.BorderColor = Color.Gray;
				this.guildId.HoveredState.BorderColor = Color.Gray;
				this.payloadCNT.ForeColor = Color.White;
				this.payloadCNT.FillColor = color;
				this.payloadCNT.BorderColor = Color.Gray;
				this.payloadCNT.HoveredState.BorderColor = Color.Gray;
				this.voiceChannelID.ForeColor = Color.White;
				this.voiceChannelID.FillColor = color;
				this.voiceChannelID.BorderColor = Color.Gray;
				this.voiceChannelID.HoveredState.BorderColor = Color.Gray;
				this.sliderDelay.FillColor = Color.Gray;
				this.sliderDelay.ThumbColor = Color.RoyalBlue;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00033E10 File Offset: 0x00032010
		private void WebsocketManager_Load(object sender, EventArgs e)
		{
			Control.CheckForIllegalCrossThreadCalls = false;
		}

		// Token: 0x060002BB RID: 699 RVA: 0x00002067 File Offset: 0x00000267
		private void hasLive_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060002BC RID: 700 RVA: 0x00033E1C File Offset: 0x0003201C
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

		// Token: 0x060002BD RID: 701 RVA: 0x00033E63 File Offset: 0x00032063
		private void hasMassTag_CheckedChanged(object sender, EventArgs e)
		{
			this.HasReconnect = this.hasMassTag.Checked;
		}

		// Token: 0x060002BE RID: 702 RVA: 0x00033E77 File Offset: 0x00032077
		private void tdel_Click(object sender, EventArgs e)
		{
			this.tdel.Checked = true;
		}

		// Token: 0x060002BF RID: 703 RVA: 0x00002067 File Offset: 0x00000267
		private void tdel_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x00033E88 File Offset: 0x00032088
		private void xsmodeTypeEnable_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.xsmodeTypeEnable.Checked;
			if (@checked)
			{
				this.startBtn.Text = "Join Voice Channel";
			}
			else
			{
				this.startBtn.Text = "Apply Changes";
			}
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x00033ECD File Offset: 0x000320CD
		private void stopBtn_Click(object sender, EventArgs e)
		{
			ThreadPool.UnsafeQueueUserWorkItem(delegate(object p_)
			{
				using (List<BlackWSManager>.Enumerator enumerator = this.wsList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						BlackWSManager w = enumerator.Current;
						ThreadPool.UnsafeQueueUserWorkItem(delegate(object m)
						{
							try
							{
								w.disconnect();
								this.wsList[this.wsList.IndexOf(w)] = null;
							}
							catch
							{
							}
						}, null);
					}
				}
				try
				{
					this.wsList.Clear();
				}
				catch
				{
				}
			}, null);
			this.stopBtn.Enabled = false;
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x00033EF0 File Offset: 0x000320F0
		private async void go_online()
		{
			WebsocketManager.<>c__DisplayClass13_0 CS$<>8__locals1 = new WebsocketManager.<>c__DisplayClass13_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.proxies = ImpostazioniGlobali.Proxies;
			ImpostazioniGlobali.StartLog();
			CS$<>8__locals1.random = new Random();
			ImpostazioniGlobali.Log(string.Concat(new string[]
			{
				"Manager -> (Operation Starting) WS Connect => Connecting to websocket with ",
				ImpostazioniGlobali.Proxies.Count.ToString(),
				" proxies and ",
				ImpostazioniGlobali.Tokens.Count.ToString(),
				" tokens.."
			}));
			new Thread(async delegate(object p)
			{
				using (List<string>.Enumerator enumerator = ImpostazioniGlobali.Tokens.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						WebsocketManager.<>c__DisplayClass13_1 CS$<>8__locals2 = new WebsocketManager.<>c__DisplayClass13_1();
						CS$<>8__locals2.CS$<>8__locals1 = CS$<>8__locals1;
						CS$<>8__locals2.token = enumerator.Current;
						ThreadPool.UnsafeQueueUserWorkItem(async delegate(object __M_)
						{
							string proxy;
							try
							{
								proxy = CS$<>8__locals2.CS$<>8__locals1.proxies[CS$<>8__locals2.CS$<>8__locals1.random.Next(CS$<>8__locals2.CS$<>8__locals1.proxies.Count)];
							}
							catch (Exception)
							{
								proxy = "Error";
							}
							try
							{
								ImpostazioniGlobali.Log(proxy + " -> (" + CS$<>8__locals2.token + ") WS Connect => Connecting to WebSocket... [Init]");
								BlackWSManager ws = new BlackWSManager(CS$<>8__locals2.token, proxy, ImpostazioniGlobali.WS_LogBasic, "9");
								ws.set_parsing(false);
								CS$<>8__locals2.CS$<>8__locals1.<>4__this.wsList.Add(ws);
								ws.connect();
								ImpostazioniGlobali.Log(proxy + " -> (" + CS$<>8__locals2.token + ") WS Connect => Awaiting READY state..");
								ws.WaitForData(10000);
								bool flag = ws.DataRAvaliable();
								if (flag)
								{
									ImpostazioniGlobali.Log(proxy + " -> (" + CS$<>8__locals2.token + ") WS Connect => Successfully connected: READY");
									bool flag2 = !string.IsNullOrEmpty(CS$<>8__locals2.CS$<>8__locals1.<>4__this.payloadCNT.Text);
									if (flag2)
									{
										ws.send_ws_message(CS$<>8__locals2.CS$<>8__locals1.<>4__this.payloadCNT.Text);
										ImpostazioniGlobali.Log(proxy + " -> (" + CS$<>8__locals2.token + ") WS Connect => Sent payload.");
									}
								}
								else
								{
									ImpostazioniGlobali.Log(proxy + " -> (" + CS$<>8__locals2.token + ") WS Connect => Failed to connect: No data avaliable from WS");
								}
								ws = null;
							}
							catch (Exception)
							{
								ImpostazioniGlobali.Log(proxy + " -> (" + CS$<>8__locals2.token + ") WS Connect => Unknown Error [Check your proxies]");
							}
						}, null);
						CS$<>8__locals2 = null;
					}
				}
				List<string>.Enumerator enumerator = default(List<string>.Enumerator);
			}).Start();
			await Task.Delay(100);
			this.startBtn.Text = "Apply Changes";
			this.startBtn.Enabled = true;
			this.stopBtn.Enabled = true;
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x00033F2C File Offset: 0x0003212C
		private async void startBtn_Click(object sender, EventArgs e)
		{
			WebsocketManager.<>c__DisplayClass14_0 CS$<>8__locals1 = new WebsocketManager.<>c__DisplayClass14_0();
			CS$<>8__locals1.<>4__this = this;
			this.startBtn.Text = "Connecting..";
			this.startBtn.Enabled = false;
			bool @checked = this.xsmodeTypeEnable.Checked;
			if (@checked)
			{
				bool flag = this.guildId.Text == "" || this.voiceChannelID.Text == "";
				if (flag)
				{
					MessageBox.Show("Channel ID and Message Content are required", "Avviso", ContentAlignment.MiddleCenter);
					return;
				}
			}
			bool flag2 = ImpostazioniGlobali.Tokens == null || ImpostazioniGlobali.Proxies == null;
			if (flag2)
			{
				this.startBtn.Text = "Join Voice Channel";
				this.startBtn.Enabled = true;
				MessageBox.Show("There are no such tokens or proxies", "Avviso", ContentAlignment.MiddleCenter);
			}
			else
			{
				bool flag3 = !this.xsmodeTypeEnable.Checked;
				if (flag3)
				{
					this.go_online();
				}
				else
				{
					CS$<>8__locals1.proxies = ImpostazioniGlobali.Proxies;
					ImpostazioniGlobali.StartLog();
					CS$<>8__locals1.random = new Random();
					ImpostazioniGlobali.Log(string.Concat(new string[]
					{
						"Manager -> (Operation Starting) Voice Spammer => Connecting in ",
						this.guildId.Text,
						"::",
						this.voiceChannelID.Text,
						" with ",
						ImpostazioniGlobali.Proxies.Count.ToString(),
						" proxies and ",
						ImpostazioniGlobali.Tokens.Count.ToString(),
						" tokens.."
					}));
					int max;
					int o;
					ThreadPool.GetMaxThreads(out max, out o);
					ThreadPool.SetMinThreads(o - 1, o - 1);
					new Thread(async delegate(object p)
					{
						using (List<string>.Enumerator enumerator = ImpostazioniGlobali.Tokens.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								WebsocketManager.<>c__DisplayClass14_1 CS$<>8__locals2 = new WebsocketManager.<>c__DisplayClass14_1();
								CS$<>8__locals2.CS$<>8__locals1 = CS$<>8__locals1;
								CS$<>8__locals2.token = enumerator.Current;
								ThreadPool.UnsafeQueueUserWorkItem(delegate(object _c)
								{
									string text;
									try
									{
										text = CS$<>8__locals2.CS$<>8__locals1.proxies[CS$<>8__locals2.CS$<>8__locals1.random.Next(CS$<>8__locals2.CS$<>8__locals1.proxies.Count)];
									}
									catch (Exception)
									{
										text = "Error";
									}
									try
									{
										ImpostazioniGlobali.Log(text + " -> (" + CS$<>8__locals2.token + ") Voice => Initializing Websocket Manager and Connecting..");
										BlackWSManager blackWSManager = new BlackWSManager(CS$<>8__locals2.token, text, ImpostazioniGlobali.WS_LogBasic, "9");
										blackWSManager.set_parsing(false);
										CS$<>8__locals2.CS$<>8__locals1.<>4__this.wsList.Add(blackWSManager);
										blackWSManager.connect();
										blackWSManager.WaitForData(10000);
										bool flag4 = blackWSManager.DataRAvaliable();
										if (flag4)
										{
											ImpostazioniGlobali.Log(text + " -> (" + CS$<>8__locals2.token + ") Voice => WS Success :: READY. Connecting to voice channel..");
											blackWSManager.voice_connect(CS$<>8__locals2.CS$<>8__locals1.<>4__this.guildId.Text, CS$<>8__locals2.CS$<>8__locals1.<>4__this.voiceChannelID.Text);
											bool flag5 = !string.IsNullOrEmpty(CS$<>8__locals2.CS$<>8__locals1.<>4__this.payloadCNT.Text);
											if (flag5)
											{
												blackWSManager.send_ws_message(CS$<>8__locals2.CS$<>8__locals1.<>4__this.payloadCNT.Text);
												ImpostazioniGlobali.Log(text + " -> (" + CS$<>8__locals2.token + ") WS Connect => Sent payload.");
											}
										}
										else
										{
											ImpostazioniGlobali.Log(text + " -> (" + CS$<>8__locals2.token + ") Voice => Error: No data avaliable from WS.");
										}
									}
									catch (Exception)
									{
										ImpostazioniGlobali.Log(text + " -> (" + CS$<>8__locals2.token + ") Voice => Unknown Error [Check your proxies]");
									}
								}, null);
								CS$<>8__locals2 = null;
							}
						}
						List<string>.Enumerator enumerator = default(List<string>.Enumerator);
					}).Start();
					await Task.Delay(100);
					this.startBtn.Text = "Join Voice Channel";
					this.startBtn.Enabled = true;
					this.stopBtn.Enabled = true;
				}
			}
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x00033F74 File Offset: 0x00032174
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x00033FAC File Offset: 0x000321AC
		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(WebsocketManager));
			this.voiceChannelID = new SiticoneTextBox();
			this.xsmodeTypeEnable = new SiticoneToggleSwitch();
			this.label4 = new Label();
			this.label3 = new Label();
			this.pictureBox2 = new PictureBox();
			this.tdel = new SiticoneToggleSwitch();
			this.label2 = new Label();
			this.sliderDelay = new SiticoneSlider();
			this.hasDelay = new SiticoneToggleSwitch();
			this.del = new Label();
			this.label9 = new Label();
			this.label8 = new Label();
			this.hasMassTag = new SiticoneCustomCheckBox();
			this.hasLive = new SiticoneCustomCheckBox();
			this.stopBtn = new SiticoneButton();
			this.startBtn = new SiticoneButton();
			this.guildId = new SiticoneTextBox();
			this.label1 = new Label();
			this.payloadCNT = new SiticoneTextBox();
			this.siticoneDragControl1 = new SiticoneDragControl(this.components);
			((ISupportInitialize)this.pictureBox2).BeginInit();
			base.SuspendLayout();
			this.voiceChannelID.Animated = false;
			this.voiceChannelID.BackColor = Color.Transparent;
			this.voiceChannelID.BorderRadius = 4;
			this.voiceChannelID.BorderThickness = 2;
			this.voiceChannelID.Cursor = Cursors.IBeam;
			this.voiceChannelID.DefaultText = "";
			this.voiceChannelID.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			this.voiceChannelID.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			this.voiceChannelID.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			this.voiceChannelID.DisabledState.Parent = this.voiceChannelID;
			this.voiceChannelID.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			this.voiceChannelID.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.voiceChannelID.FocusedState.Parent = this.voiceChannelID;
			this.voiceChannelID.Font = new Font("SF Pro Display", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.voiceChannelID.ForeColor = Color.Black;
			this.voiceChannelID.HoveredState.BorderColor = Color.FromArgb(213, 218, 223);
			this.voiceChannelID.HoveredState.Parent = this.voiceChannelID;
			this.voiceChannelID.Location = new Point(18, 168);
			this.voiceChannelID.Name = "voiceChannelID";
			this.voiceChannelID.PasswordChar = '\0';
			this.voiceChannelID.PlaceholderText = "Voice Channel ID";
			this.voiceChannelID.SelectedText = "";
			this.voiceChannelID.ShadowDecoration.Parent = this.voiceChannelID;
			this.voiceChannelID.Size = new Size(658, 39);
			this.voiceChannelID.TabIndex = 91;
			this.xsmodeTypeEnable.Checked = true;
			this.xsmodeTypeEnable.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.xsmodeTypeEnable.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.xsmodeTypeEnable.CheckedState.InnerBorderColor = Color.White;
			this.xsmodeTypeEnable.CheckedState.InnerColor = Color.White;
			this.xsmodeTypeEnable.CheckedState.Parent = this.xsmodeTypeEnable;
			this.xsmodeTypeEnable.Cursor = Cursors.Hand;
			this.xsmodeTypeEnable.Location = new Point(531, 82);
			this.xsmodeTypeEnable.Name = "xsmodeTypeEnable";
			this.xsmodeTypeEnable.ShadowDecoration.Parent = this.xsmodeTypeEnable;
			this.xsmodeTypeEnable.Size = new Size(32, 20);
			this.xsmodeTypeEnable.TabIndex = 90;
			this.xsmodeTypeEnable.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.xsmodeTypeEnable.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.xsmodeTypeEnable.UncheckedState.InnerBorderColor = Color.White;
			this.xsmodeTypeEnable.UncheckedState.InnerColor = Color.White;
			this.xsmodeTypeEnable.UncheckedState.Parent = this.xsmodeTypeEnable;
			this.xsmodeTypeEnable.CheckedChanged += this.xsmodeTypeEnable_CheckedChanged;
			this.label4.AutoSize = true;
			this.label4.Font = new Font("SF Pro Text", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label4.Location = new Point(568, 84);
			this.label4.Name = "label4";
			this.label4.Size = new Size(109, 15);
			this.label4.TabIndex = 89;
			this.label4.Text = "Voice Spammer";
			this.label3.AutoSize = true;
			this.label3.Font = new Font("SF Pro Text", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label3.ForeColor = Color.Teal;
			this.label3.Location = new Point(19, 70);
			this.label3.Name = "label3";
			this.label3.Size = new Size(276, 45);
			this.label3.TabIndex = 88;
			this.label3.Text = "The new WS Utility is here!\r\nWebsocket completely rewritten and now\r\nwith voice connection support.";
			this.pictureBox2.Image = (Image)componentResourceManager.GetObject("pictureBox2.Image");
			this.pictureBox2.Location = new Point(647, 30);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new Size(35, 26);
			this.pictureBox2.TabIndex = 87;
			this.pictureBox2.TabStop = false;
			this.tdel.Checked = true;
			this.tdel.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.tdel.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.tdel.CheckedState.InnerBorderColor = Color.White;
			this.tdel.CheckedState.InnerColor = Color.White;
			this.tdel.CheckedState.Parent = this.tdel;
			this.tdel.Cursor = Cursors.Hand;
			this.tdel.Location = new Point(528, 391);
			this.tdel.Name = "tdel";
			this.tdel.ShadowDecoration.Parent = this.tdel;
			this.tdel.Size = new Size(32, 20);
			this.tdel.TabIndex = 86;
			this.tdel.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.tdel.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.tdel.UncheckedState.InnerBorderColor = Color.White;
			this.tdel.UncheckedState.InnerColor = Color.White;
			this.tdel.UncheckedState.Parent = this.tdel;
			this.tdel.CheckedChanged += this.tdel_CheckedChanged;
			this.tdel.Click += this.tdel_Click;
			this.label2.AutoSize = true;
			this.label2.Font = new Font("SF Pro Text", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label2.Location = new Point(564, 395);
			this.label2.Name = "label2";
			this.label2.Size = new Size(112, 14);
			this.label2.TabIndex = 85;
			this.label2.Text = "Set Online Status";
			this.sliderDelay.Cursor = Cursors.Hand;
			this.sliderDelay.LargeChange = 5;
			this.sliderDelay.Location = new Point(24, 421);
			this.sliderDelay.Name = "sliderDelay";
			this.sliderDelay.Size = new Size(652, 60);
			this.sliderDelay.TabIndex = 84;
			this.sliderDelay.Value = 50;
			this.sliderDelay.Scroll += this.sliderDelay_Scroll;
			this.hasDelay.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.hasDelay.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.hasDelay.CheckedState.InnerBorderColor = Color.White;
			this.hasDelay.CheckedState.InnerColor = Color.White;
			this.hasDelay.CheckedState.Parent = this.hasDelay;
			this.hasDelay.Cursor = Cursors.Hand;
			this.hasDelay.Location = new Point(528, 364);
			this.hasDelay.Name = "hasDelay";
			this.hasDelay.ShadowDecoration.Parent = this.hasDelay;
			this.hasDelay.Size = new Size(32, 20);
			this.hasDelay.TabIndex = 83;
			this.hasDelay.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.hasDelay.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.hasDelay.UncheckedState.InnerBorderColor = Color.White;
			this.hasDelay.UncheckedState.InnerColor = Color.White;
			this.hasDelay.UncheckedState.Parent = this.hasDelay;
			this.del.AutoSize = true;
			this.del.Font = new Font("SF Pro Text", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.del.Location = new Point(565, 368);
			this.del.Name = "del";
			this.del.Size = new Size(85, 14);
			this.del.TabIndex = 82;
			this.del.Text = "Volume: 50%";
			this.label9.AutoSize = true;
			this.label9.Font = new Font("SF Pro Text", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label9.Location = new Point(42, 368);
			this.label9.Name = "label9";
			this.label9.Size = new Size(108, 14);
			this.label9.TabIndex = 81;
			this.label9.Text = "Send Heartbeats";
			this.label8.AutoSize = true;
			this.label8.Font = new Font("SF Pro Text", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label8.Location = new Point(42, 389);
			this.label8.Name = "label8";
			this.label8.Size = new Size(103, 14);
			this.label8.TabIndex = 80;
			this.label8.Text = "Auto Reconnect";
			this.hasMassTag.BackColor = Color.Transparent;
			this.hasMassTag.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.hasMassTag.CheckedState.BorderRadius = 2;
			this.hasMassTag.CheckedState.BorderThickness = 0;
			this.hasMassTag.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.hasMassTag.CheckedState.Parent = this.hasMassTag;
			this.hasMassTag.Cursor = Cursors.Hand;
			this.hasMassTag.Location = new Point(24, 389);
			this.hasMassTag.Name = "hasMassTag";
			this.hasMassTag.ShadowDecoration.Parent = this.hasMassTag;
			this.hasMassTag.Size = new Size(15, 15);
			this.hasMassTag.TabIndex = 79;
			this.hasMassTag.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.hasMassTag.UncheckedState.BorderRadius = 2;
			this.hasMassTag.UncheckedState.BorderThickness = 0;
			this.hasMassTag.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.hasMassTag.UncheckedState.Parent = this.hasMassTag;
			this.hasMassTag.CheckedChanged += this.hasMassTag_CheckedChanged;
			this.hasLive.Checked = true;
			this.hasLive.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.hasLive.CheckedState.BorderRadius = 2;
			this.hasLive.CheckedState.BorderThickness = 0;
			this.hasLive.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.hasLive.CheckedState.Parent = this.hasLive;
			this.hasLive.CheckState = CheckState.Checked;
			this.hasLive.Cursor = Cursors.Hand;
			this.hasLive.Location = new Point(24, 368);
			this.hasLive.Name = "hasLive";
			this.hasLive.ShadowDecoration.Parent = this.hasLive;
			this.hasLive.Size = new Size(15, 15);
			this.hasLive.TabIndex = 78;
			this.hasLive.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.hasLive.UncheckedState.BorderRadius = 2;
			this.hasLive.UncheckedState.BorderThickness = 0;
			this.hasLive.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.hasLive.UncheckedState.Parent = this.hasLive;
			this.hasLive.CheckedChanged += this.hasLive_CheckedChanged;
			this.hasLive.Click += this.hasLive_Click;
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
			this.stopBtn.Location = new Point(350, 508);
			this.stopBtn.Name = "stopBtn";
			this.stopBtn.PressedColor = Color.White;
			this.stopBtn.ShadowDecoration.Parent = this.stopBtn;
			this.stopBtn.Size = new Size(326, 29);
			this.stopBtn.TabIndex = 77;
			this.stopBtn.Text = "Close Websockets";
			this.stopBtn.TextRenderingHint = TextRenderingHint.AntiAlias;
			this.stopBtn.Click += this.stopBtn_Click;
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
			this.startBtn.Location = new Point(18, 508);
			this.startBtn.Name = "startBtn";
			this.startBtn.PressedColor = Color.White;
			this.startBtn.ShadowDecoration.Parent = this.startBtn;
			this.startBtn.Size = new Size(326, 29);
			this.startBtn.TabIndex = 76;
			this.startBtn.Text = "Join Voice Channel";
			this.startBtn.TextRenderingHint = TextRenderingHint.AntiAlias;
			this.startBtn.Click += this.startBtn_Click;
			this.guildId.Animated = false;
			this.guildId.BackColor = Color.Transparent;
			this.guildId.BorderRadius = 4;
			this.guildId.BorderThickness = 2;
			this.guildId.Cursor = Cursors.IBeam;
			this.guildId.DefaultText = "";
			this.guildId.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			this.guildId.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			this.guildId.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			this.guildId.DisabledState.Parent = this.guildId;
			this.guildId.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			this.guildId.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.guildId.FocusedState.Parent = this.guildId;
			this.guildId.Font = new Font("SF Pro Display", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.guildId.ForeColor = Color.Black;
			this.guildId.HoveredState.BorderColor = Color.FromArgb(213, 218, 223);
			this.guildId.HoveredState.Parent = this.guildId;
			this.guildId.Location = new Point(18, 127);
			this.guildId.Name = "guildId";
			this.guildId.PasswordChar = '\0';
			this.guildId.PlaceholderText = "Guild ID";
			this.guildId.SelectedText = "";
			this.guildId.ShadowDecoration.Parent = this.guildId;
			this.guildId.Size = new Size(658, 35);
			this.guildId.TabIndex = 74;
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Inter", 15.75f, FontStyle.Bold);
			this.label1.Location = new Point(13, 33);
			this.label1.Name = "label1";
			this.label1.Size = new Size(195, 25);
			this.label1.TabIndex = 73;
			this.label1.Text = "Websocket Utility";
			this.payloadCNT.Animated = false;
			this.payloadCNT.BackColor = Color.Transparent;
			this.payloadCNT.BorderRadius = 4;
			this.payloadCNT.BorderThickness = 2;
			this.payloadCNT.Cursor = Cursors.IBeam;
			this.payloadCNT.DefaultText = "";
			this.payloadCNT.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			this.payloadCNT.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			this.payloadCNT.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			this.payloadCNT.DisabledState.Parent = this.payloadCNT;
			this.payloadCNT.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			this.payloadCNT.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.payloadCNT.FocusedState.Parent = this.payloadCNT;
			this.payloadCNT.Font = new Font("SF Pro Display", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.payloadCNT.ForeColor = Color.Black;
			this.payloadCNT.HoveredState.BorderColor = Color.FromArgb(213, 218, 223);
			this.payloadCNT.HoveredState.Parent = this.payloadCNT;
			this.payloadCNT.Location = new Point(18, 213);
			this.payloadCNT.Multiline = true;
			this.payloadCNT.Name = "payloadCNT";
			this.payloadCNT.PasswordChar = '\0';
			this.payloadCNT.PlaceholderText = "Payload*";
			this.payloadCNT.SelectedText = "";
			this.payloadCNT.ShadowDecoration.Parent = this.payloadCNT;
			this.payloadCNT.Size = new Size(658, 130);
			this.payloadCNT.TabIndex = 75;
			this.siticoneDragControl1.TargetControl = this;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.voiceChannelID);
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
			base.Controls.Add(this.payloadCNT);
			base.Controls.Add(this.guildId);
			base.Controls.Add(this.label1);
			base.Name = "WebsocketManager";
			base.Size = new Size(695, 560);
			base.Load += this.WebsocketManager_Load;
			((ISupportInitialize)this.pictureBox2).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000639 RID: 1593
		private bool HasReconnect = false;

		// Token: 0x0400063A RID: 1594
		private List<BlackWSManager> wsList = new List<BlackWSManager>();

		// Token: 0x0400063B RID: 1595
		private IContainer components = null;

		// Token: 0x0400063C RID: 1596
		private SiticoneTextBox voiceChannelID;

		// Token: 0x0400063D RID: 1597
		private SiticoneToggleSwitch xsmodeTypeEnable;

		// Token: 0x0400063E RID: 1598
		private Label label4;

		// Token: 0x0400063F RID: 1599
		private Label label3;

		// Token: 0x04000640 RID: 1600
		private PictureBox pictureBox2;

		// Token: 0x04000641 RID: 1601
		private SiticoneToggleSwitch tdel;

		// Token: 0x04000642 RID: 1602
		private Label label2;

		// Token: 0x04000643 RID: 1603
		private SiticoneSlider sliderDelay;

		// Token: 0x04000644 RID: 1604
		private SiticoneToggleSwitch hasDelay;

		// Token: 0x04000645 RID: 1605
		private Label del;

		// Token: 0x04000646 RID: 1606
		private Label label9;

		// Token: 0x04000647 RID: 1607
		private Label label8;

		// Token: 0x04000648 RID: 1608
		private SiticoneCustomCheckBox hasMassTag;

		// Token: 0x04000649 RID: 1609
		private SiticoneCustomCheckBox hasLive;

		// Token: 0x0400064A RID: 1610
		private SiticoneButton stopBtn;

		// Token: 0x0400064B RID: 1611
		private SiticoneButton startBtn;

		// Token: 0x0400064C RID: 1612
		private SiticoneTextBox guildId;

		// Token: 0x0400064D RID: 1613
		private Label label1;

		// Token: 0x0400064E RID: 1614
		private SiticoneTextBox payloadCNT;

		// Token: 0x0400064F RID: 1615
		private SiticoneDragControl siticoneDragControl1;
	}
}
