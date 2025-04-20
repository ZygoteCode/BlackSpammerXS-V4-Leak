using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Windows.Forms;
using BlackSpammerXS.Properties;
using BlackVerifyNumber;
using Siticone.UI.WinForms;

namespace BlackSpammerXS
{
	// Token: 0x02000002 RID: 2
	public class AdvancedSettings : UserControl
	{
		// Token: 0x06000002 RID: 2 RVA: 0x0000204F File Offset: 0x0000024F
		public AdvancedSettings()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002067 File Offset: 0x00000267
		private void siticoneButton4_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000004 RID: 4 RVA: 0x0000206C File Offset: 0x0000026C
		public void Dark()
		{
			Color color = Color.FromArgb(44, 47, 51);
			this.BackColor = color;
			Color dimGray = Color.DimGray;
			try
			{
				List<SiticoneButton> list = new List<SiticoneButton>();
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
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002128 File Offset: 0x00000328
		public void Switch()
		{
			this.siticoneWinToggleSwith1.Checked = true;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002138 File Offset: 0x00000338
		private void AdvancedSettings_Load(object sender, EventArgs e)
		{
			bool dark = Settings.Default.dark;
			if (dark)
			{
				this.siticoneGradientButton1.Text = "Switch to Light Mode";
			}
			ImpostazioniGlobali._bridgeLogPerform.Add(delegate(int a, int b, object[] i)
			{
				bool flag = a == 4727417;
				if (flag)
				{
					try
					{
						bool flag2 = b == 0;
						if (flag2)
						{
							this.wdevm.Enabled = false;
						}
						bool flag3 = b == 1;
						if (flag3)
						{
							this.wdevm.Enabled = true;
						}
					}
					catch (Exception)
					{
					}
				}
			});
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002067 File Offset: 0x00000267
		private void AdvancedSettings_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002180 File Offset: 0x00000380
		private async void siticoneButton4_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000021C8 File Offset: 0x000003C8
		private async void siticoneButton1_Click(object sender, EventArgs e)
		{
			bool flag = ImpostazioniGlobali.CaptchaKey_SMSACT == "";
			if (flag)
			{
				MessageBox.Show("A valid sms activate key is required", "Avviso", ContentAlignment.MiddleCenter);
			}
			else
			{
				bool flag2 = ImpostazioniGlobali.Tokens == null || ImpostazioniGlobali.Proxies == null;
				if (flag2)
				{
					MessageBox.Show("You must import at least 1 token and 1 proxy", "Avviso", ContentAlignment.MiddleCenter);
				}
				else
				{
					ImpostazioniGlobali.StartLog();
					int _suc = 0;
					int _non = 0;
					string numberKey = ImpostazioniGlobali.CaptchaKey_SMSACT;
					Random random = new Random();
					List<string> proxies = ImpostazioniGlobali.Proxies;
					BlackNumberVerification manager = new BlackNumberVerification(numberKey);
					ImpostazioniGlobali.Log(string.Concat(new string[]
					{
						"Manager -> (Operation Starting) Verification => Verifying Phone with ",
						proxies.Count.ToString(),
						" proxies and ",
						ImpostazioniGlobali.Tokens.Count.ToString(),
						" tokens.."
					}));
					Control.CheckForIllegalCrossThreadCalls = false;
					new Thread(delegate(object p)
					{
						Control.CheckForIllegalCrossThreadCalls = false;
						this.rem.Text = "0 of " + ImpostazioniGlobali.Tokens.Count.ToString();
						ImpostazioniGlobali.Log("Manager -> (Operation Starting) Verification => Checking which tokens needs verification..");
						using (List<string>.Enumerator enumerator = ImpostazioniGlobali.Tokens.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								string t = enumerator.Current;
								new Thread(async delegate(object CHECK)
								{
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
										WebProxy __p = new WebProxy(proxy.Split(new char[] { ':' })[0], int.Parse(proxy.Split(new char[] { ':' })[1]));
										handler.Proxy = __p;
										HttpClient http = new HttpClient(handler);
										HttpRequestMessage request = new HttpRequestMessage
										{
											RequestUri = new Uri("https://discord.com/api/v9/users/@me/library"),
											Method = HttpMethod.Get,
											Headers = { { "Authorization", t } }
										};
										HttpResponseMessage httpResponseMessage = await http.SendAsync(request);
										HttpResponseMessage req = httpResponseMessage;
										httpResponseMessage = null;
										string text = await req.Content.ReadAsStringAsync();
										string _ = text;
										text = null;
										if (_.Contains("verify"))
										{
											ImpostazioniGlobali.Log(proxy + " -> (" + t + ") Check => Needs verification.");
											ImpostazioniGlobali.Log(proxy + " -> (" + t + ") Verification => Verifying phone using sms-activate.ru...");
											bool flag3 = await manager.Verify(t, true, __p);
											bool done = flag3;
											if (done)
											{
												ImpostazioniGlobali.Log(proxy + " -> (" + t + ") Verification => Done! Successfully phone verified.");
												_suc++;
												this.rem.Text = _suc.ToString() + " of " + (ImpostazioniGlobali.Tokens.Count - _non).ToString();
											}
											else
											{
												ImpostazioniGlobali.Log(proxy + " -> (" + t + ") Verification => Error! Failed to phone verify.");
											}
										}
										else
										{
											_non++;
											this.rem.Text = _suc.ToString() + " of " + (ImpostazioniGlobali.Tokens.Count - _non).ToString();
										}
										handler = null;
										__p = null;
										http = null;
										request = null;
										req = null;
										_ = null;
									}
									catch (Exception)
									{
										ImpostazioniGlobali.Log(proxy + " -> (" + t + ") Check => Unknown Error [Check your proxies]");
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
				}
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002067 File Offset: 0x00000267
		private void siticoneButton1_MouseEnter(object sender, EventArgs e)
		{
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002067 File Offset: 0x00000267
		private void siticoneButton1_MouseLeave(object sender, EventArgs e)
		{
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000220F File Offset: 0x0000040F
		private void siticoneWinToggleSwith1_CheckedChanged(object sender, EventArgs e)
		{
			ImpostazioniGlobali.DarkMode(this.siticoneWinToggleSwith1.Checked);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002067 File Offset: 0x00000267
		private void siticoneButton1_Click_1(object sender, EventArgs e)
		{
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002224 File Offset: 0x00000424
		private void siticoneGradientButton1_Click(object sender, EventArgs e)
		{
			bool @checked = this.siticoneWinToggleSwith1.Checked;
			if (@checked)
			{
				this.siticoneGradientButton1.Text = "Switch to Dark Mode";
				this.siticoneWinToggleSwith1.Checked = false;
			}
			else
			{
				this.siticoneGradientButton1.Text = "Switch to Light Mode";
				this.siticoneWinToggleSwith1.Checked = true;
			}
			this.siticoneWinToggleSwith1_CheckedChanged(sender, e);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000228C File Offset: 0x0000048C
		private void siticoneGradientButton2_Click(object sender, EventArgs e)
		{
			this.siticoneButton1_Click(sender, e);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002067 File Offset: 0x00000267
		private void label2_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002298 File Offset: 0x00000498
		private void hasDelay_CheckedChanged(object sender, EventArgs e)
		{
			ImpostazioniGlobali.StreamerMode = this.hasDelay.Checked;
			ImpostazioniGlobali.StreamOptNotify();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000022B1 File Offset: 0x000004B1
		private void siticoneToggleSwitch1_CheckedChanged(object sender, EventArgs e)
		{
			ImpostazioniGlobali.AllowLogging = this.siticoneToggleSwitch1.Checked;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000022C4 File Offset: 0x000004C4
		private void siticoneToggleSwitch3_CheckedChanged(object sender, EventArgs e)
		{
			MessageBox.Show(delegate(int a, int b)
			{
				bool flag = a == 0 && b == 2;
				if (flag)
				{
					ZaschModeBSOD zaschModeBSOD = new ZaschModeBSOD();
					zaschModeBSOD.Show();
				}
			}, "Attenzione. Sei sicuro di voler attivare la zasch mode? Sarà necessario riavviare il PC per rimuoverla.", "Zasch Mode", ContentAlignment.MiddleCenter);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000022F8 File Offset: 0x000004F8
		private void siticoneToggleSwitch2_CheckedChanged(object sender, EventArgs e)
		{
			ImpostazioniGlobali.DeveloperMode = this.wdevm.Checked;
			bool @checked = this.wdevm.Checked;
			if (@checked)
			{
				this.openDevToolsBtn.Enabled = true;
			}
			else
			{
				this.openDevToolsBtn.Enabled = false;
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002067 File Offset: 0x00000267
		private void nKEY_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002348 File Offset: 0x00000548
		private void siticoneGradientButton3_Click(object sender, EventArgs e)
		{
			this.siticoneGradientButton3.Text = "Changing Captcha Key..";
			OpacityFull opacityFull = new OpacityFull();
			opacityFull.Show();
			ChcapKM chcapKM = new ChcapKM();
			ImpostazioniGlobali.bridgeAct_ = delegate(int a)
			{
				bool flag = a == 0;
				if (flag)
				{
					opacityFull.Close();
					this.Focus();
					this.siticoneGradientButton3.Text = "Change Captcha Key";
				}
			};
			chcapKM.Show();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000023AC File Offset: 0x000005AC
		private void siticoneGradientButton4_Click(object sender, EventArgs e)
		{
			OpacityFull opacityFull = new OpacityFull();
			opacityFull.Show();
			ImpostazioniGlobali.bridgeAct_ = delegate(int a)
			{
				bool flag = a == 0;
				if (flag)
				{
					opacityFull.Close();
					this.Focus();
					this.Show();
				}
			};
			AuditLogForm auditLogForm = new AuditLogForm();
			auditLogForm.Show();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000023FC File Offset: 0x000005FC
		private void siticoneGradientButton5_Click(object sender, EventArgs e)
		{
			OpacityFull opacityFull = new OpacityFull();
			opacityFull.Show();
			ImpostazioniGlobali.bridgeAct_ = delegate(int a)
			{
				bool flag = a == 0;
				if (flag)
				{
					opacityFull.Close();
					this.Focus();
					this.Show();
				}
			};
			GenerateTextForm generateTextForm = new GenerateTextForm(opacityFull, Settings.Default.dark);
			generateTextForm.Show();
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000245C File Offset: 0x0000065C
		private void enableDeveloperToolsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpacityFull opacityFull = new OpacityFull();
			opacityFull.Show();
			LoadingCVF loadingCVF = new LoadingCVF(opacityFull, Settings.Default.dark);
			loadingCVF.Show();
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002490 File Offset: 0x00000690
		private void openDevToolsBtn_Click(object sender, EventArgs e)
		{
			OpacityFull opacityFull = new OpacityFull();
			opacityFull.Show();
			ImpostazioniGlobali.bridgeAct_ = delegate(int a)
			{
			};
			DevToolsBSXS devToolsBSXS = new DevToolsBSXS(opacityFull, Settings.Default.dark);
			devToolsBSXS.Show();
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000024E7 File Offset: 0x000006E7
		private void siticoneButton4_Click_1(object sender, EventArgs e)
		{
			this.siticoneGradientButton1_Click(sender, e);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000024F3 File Offset: 0x000006F3
		private void siticoneGradientButton6_Click(object sender, EventArgs e)
		{
			this.siticoneGradientButton3_Click(sender, e);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000024FF File Offset: 0x000006FF
		private void siticoneButton7_Click(object sender, EventArgs e)
		{
			this.openDevToolsBtn_Click(sender, e);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000250B File Offset: 0x0000070B
		private void siticoneButton7_Click_1(object sender, EventArgs e)
		{
			this.siticoneGradientButton5_Click(sender, e);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002517 File Offset: 0x00000717
		private void siticoneButton7_Click_2(object sender, EventArgs e)
		{
			this.siticoneGradientButton4_Click(sender, e);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002524 File Offset: 0x00000724
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000255C File Offset: 0x0000075C
		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AdvancedSettings));
			this.label1 = new Label();
			this.pictureBox2 = new PictureBox();
			this.rem = new Label();
			this.label2 = new Label();
			this.siticoneDragControl1 = new SiticoneDragControl(this.components);
			this.siticoneWinToggleSwith1 = new SiticoneWinToggleSwith();
			this.siticoneGradientButton2 = new SiticoneGradientButton();
			this.hasDelay = new SiticoneToggleSwitch();
			this.del = new Label();
			this.siticoneToggleSwitch1 = new SiticoneToggleSwitch();
			this.label3 = new Label();
			this.wdevm = new SiticoneToggleSwitch();
			this.label4 = new Label();
			this.siticoneToggleSwitch3 = new SiticoneToggleSwitch();
			this.label5 = new Label();
			this.contextMenuStrip1 = new ContextMenuStrip(this.components);
			this.enableDeveloperToolsToolStripMenuItem = new ToolStripMenuItem();
			this.siticoneGradientButton1 = new SiticoneGradientButton();
			this.label6 = new Label();
			this.siticoneGradientButton3 = new SiticoneGradientButton();
			this.openDevToolsBtn = new SiticoneGradientButton();
			this.siticoneGradientButton5 = new SiticoneGradientButton();
			this.siticoneGradientButton4 = new SiticoneGradientButton();
			((ISupportInitialize)this.pictureBox2).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Inter", 15.75f, FontStyle.Bold);
			this.label1.Location = new Point(13, 40);
			this.label1.Name = "label1";
			this.label1.Size = new Size(207, 25);
			this.label1.TabIndex = 4;
			this.label1.Text = "Advanced Settings";
			this.pictureBox2.Image = (Image)componentResourceManager.GetObject("pictureBox2.Image");
			this.pictureBox2.Location = new Point(653, 31);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new Size(39, 30);
			this.pictureBox2.TabIndex = 69;
			this.pictureBox2.TabStop = false;
			this.rem.Enabled = false;
			this.rem.Font = new Font("SF Pro Text", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.rem.Location = new Point(240, 138);
			this.rem.Name = "rem";
			this.rem.Size = new Size(179, 16);
			this.rem.TabIndex = 71;
			this.rem.Text = "0 of 0";
			this.rem.TextAlign = ContentAlignment.MiddleCenter;
			this.rem.Visible = false;
			this.label2.AutoSize = true;
			this.label2.Enabled = false;
			this.label2.Font = new Font("Inter", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label2.Location = new Point(296, 109);
			this.label2.Name = "label2";
			this.label2.Size = new Size(71, 19);
			this.label2.TabIndex = 70;
			this.label2.Text = "Success";
			this.label2.Visible = false;
			this.label2.Click += this.label2_Click;
			this.siticoneDragControl1.TargetControl = this;
			this.siticoneWinToggleSwith1.Cursor = Cursors.Hand;
			this.siticoneWinToggleSwith1.Location = new Point(226, 43);
			this.siticoneWinToggleSwith1.Name = "siticoneWinToggleSwith1";
			this.siticoneWinToggleSwith1.Size = new Size(45, 22);
			this.siticoneWinToggleSwith1.TabIndex = 79;
			this.siticoneWinToggleSwith1.Text = "siticoneWinToggleSwith1";
			this.siticoneWinToggleSwith1.Visible = false;
			this.siticoneWinToggleSwith1.CheckedChanged += this.siticoneWinToggleSwith1_CheckedChanged;
			this.siticoneGradientButton2.BorderRadius = 15;
			this.siticoneGradientButton2.CheckedState.Parent = this.siticoneGradientButton2;
			this.siticoneGradientButton2.Cursor = Cursors.Hand;
			this.siticoneGradientButton2.CustomImages.Parent = this.siticoneGradientButton2;
			this.siticoneGradientButton2.Enabled = false;
			this.siticoneGradientButton2.FillColor2 = Color.Teal;
			this.siticoneGradientButton2.Font = new Font("SF Pro Text", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.siticoneGradientButton2.ForeColor = Color.White;
			this.siticoneGradientButton2.HoveredState.Parent = this.siticoneGradientButton2;
			this.siticoneGradientButton2.Location = new Point(183, 188);
			this.siticoneGradientButton2.Name = "siticoneGradientButton2";
			this.siticoneGradientButton2.ShadowDecoration.Parent = this.siticoneGradientButton2;
			this.siticoneGradientButton2.Size = new Size(303, 37);
			this.siticoneGradientButton2.TabIndex = 83;
			this.siticoneGradientButton2.Text = "Verify Unverified Tokens";
			this.siticoneGradientButton2.Visible = false;
			this.siticoneGradientButton2.Click += this.siticoneGradientButton2_Click;
			this.hasDelay.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.hasDelay.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.hasDelay.CheckedState.InnerBorderColor = Color.White;
			this.hasDelay.CheckedState.InnerColor = Color.White;
			this.hasDelay.CheckedState.Parent = this.hasDelay;
			this.hasDelay.Cursor = Cursors.Hand;
			this.hasDelay.Location = new Point(29, 327);
			this.hasDelay.Name = "hasDelay";
			this.hasDelay.ShadowDecoration.Parent = this.hasDelay;
			this.hasDelay.Size = new Size(32, 20);
			this.hasDelay.TabIndex = 85;
			this.hasDelay.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.hasDelay.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.hasDelay.UncheckedState.InnerBorderColor = Color.White;
			this.hasDelay.UncheckedState.InnerColor = Color.White;
			this.hasDelay.UncheckedState.Parent = this.hasDelay;
			this.hasDelay.CheckedChanged += this.hasDelay_CheckedChanged;
			this.del.AutoSize = true;
			this.del.Font = new Font("SF Pro Text", 9f, FontStyle.Bold | FontStyle.Strikeout, GraphicsUnit.Point, 0);
			this.del.Location = new Point(66, 330);
			this.del.Name = "del";
			this.del.Size = new Size(98, 14);
			this.del.TabIndex = 84;
			this.del.Text = "Streamer Mode";
			this.siticoneToggleSwitch1.Checked = true;
			this.siticoneToggleSwitch1.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.siticoneToggleSwitch1.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.siticoneToggleSwitch1.CheckedState.InnerBorderColor = Color.White;
			this.siticoneToggleSwitch1.CheckedState.InnerColor = Color.White;
			this.siticoneToggleSwitch1.CheckedState.Parent = this.siticoneToggleSwitch1;
			this.siticoneToggleSwitch1.Cursor = Cursors.Hand;
			this.siticoneToggleSwitch1.Location = new Point(29, 381);
			this.siticoneToggleSwitch1.Name = "siticoneToggleSwitch1";
			this.siticoneToggleSwitch1.ShadowDecoration.Parent = this.siticoneToggleSwitch1;
			this.siticoneToggleSwitch1.Size = new Size(32, 20);
			this.siticoneToggleSwitch1.TabIndex = 87;
			this.siticoneToggleSwitch1.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.siticoneToggleSwitch1.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.siticoneToggleSwitch1.UncheckedState.InnerBorderColor = Color.White;
			this.siticoneToggleSwitch1.UncheckedState.InnerColor = Color.White;
			this.siticoneToggleSwitch1.UncheckedState.Parent = this.siticoneToggleSwitch1;
			this.siticoneToggleSwitch1.CheckedChanged += this.siticoneToggleSwitch1_CheckedChanged;
			this.label3.AutoSize = true;
			this.label3.Font = new Font("SF Pro Text", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label3.Location = new Point(66, 384);
			this.label3.Name = "label3";
			this.label3.Size = new Size(93, 14);
			this.label3.TabIndex = 86;
			this.label3.Text = "Allow Logging";
			this.wdevm.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.wdevm.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.wdevm.CheckedState.InnerBorderColor = Color.White;
			this.wdevm.CheckedState.InnerColor = Color.White;
			this.wdevm.CheckedState.Parent = this.wdevm;
			this.wdevm.Cursor = Cursors.Hand;
			this.wdevm.Location = new Point(29, 408);
			this.wdevm.Name = "wdevm";
			this.wdevm.ShadowDecoration.Parent = this.wdevm;
			this.wdevm.Size = new Size(32, 20);
			this.wdevm.TabIndex = 91;
			this.wdevm.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.wdevm.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.wdevm.UncheckedState.InnerBorderColor = Color.White;
			this.wdevm.UncheckedState.InnerColor = Color.White;
			this.wdevm.UncheckedState.Parent = this.wdevm;
			this.wdevm.CheckedChanged += this.siticoneToggleSwitch2_CheckedChanged;
			this.label4.AutoSize = true;
			this.label4.Font = new Font("SF Pro Text", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label4.Location = new Point(65, 412);
			this.label4.Name = "label4";
			this.label4.Size = new Size(110, 14);
			this.label4.TabIndex = 90;
			this.label4.Text = "Developer Mode*";
			this.siticoneToggleSwitch3.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.siticoneToggleSwitch3.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.siticoneToggleSwitch3.CheckedState.InnerBorderColor = Color.White;
			this.siticoneToggleSwitch3.CheckedState.InnerColor = Color.White;
			this.siticoneToggleSwitch3.CheckedState.Parent = this.siticoneToggleSwitch3;
			this.siticoneToggleSwitch3.Cursor = Cursors.Hand;
			this.siticoneToggleSwitch3.Location = new Point(29, 354);
			this.siticoneToggleSwitch3.Name = "siticoneToggleSwitch3";
			this.siticoneToggleSwitch3.ShadowDecoration.Parent = this.siticoneToggleSwitch3;
			this.siticoneToggleSwitch3.Size = new Size(32, 20);
			this.siticoneToggleSwitch3.TabIndex = 89;
			this.siticoneToggleSwitch3.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.siticoneToggleSwitch3.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.siticoneToggleSwitch3.UncheckedState.InnerBorderColor = Color.White;
			this.siticoneToggleSwitch3.UncheckedState.InnerColor = Color.White;
			this.siticoneToggleSwitch3.UncheckedState.Parent = this.siticoneToggleSwitch3;
			this.siticoneToggleSwitch3.CheckedChanged += this.siticoneToggleSwitch3_CheckedChanged;
			this.label5.AutoSize = true;
			this.label5.Font = new Font("SF Pro Text", 9f, FontStyle.Bold | FontStyle.Strikeout, GraphicsUnit.Point, 0);
			this.label5.Location = new Point(66, 357);
			this.label5.Name = "label5";
			this.label5.Size = new Size(80, 14);
			this.label5.TabIndex = 88;
			this.label5.Text = "Zasch Mode";
			this.contextMenuStrip1.Font = new Font("SF Pro Text", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.contextMenuStrip1.Items.AddRange(new ToolStripItem[] { this.enableDeveloperToolsToolStripMenuItem });
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.RenderMode = ToolStripRenderMode.Professional;
			this.contextMenuStrip1.Size = new Size(228, 26);
			this.enableDeveloperToolsToolStripMenuItem.Name = "enableDeveloperToolsToolStripMenuItem";
			this.enableDeveloperToolsToolStripMenuItem.Size = new Size(227, 22);
			this.enableDeveloperToolsToolStripMenuItem.Text = "Enable Developer Tools";
			this.enableDeveloperToolsToolStripMenuItem.Click += this.enableDeveloperToolsToolStripMenuItem_Click;
			this.siticoneGradientButton1.BorderRadius = 18;
			this.siticoneGradientButton1.CheckedState.Parent = this.siticoneGradientButton1;
			this.siticoneGradientButton1.Cursor = Cursors.Hand;
			this.siticoneGradientButton1.CustomImages.Parent = this.siticoneGradientButton1;
			this.siticoneGradientButton1.FillColor = Color.FromArgb(56, 128, 255);
			this.siticoneGradientButton1.FillColor2 = Color.FromArgb(56, 128, 255);
			this.siticoneGradientButton1.Font = new Font("SF Pro Text", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.siticoneGradientButton1.ForeColor = Color.White;
			this.siticoneGradientButton1.HoveredState.Parent = this.siticoneGradientButton1;
			this.siticoneGradientButton1.Image = (Image)componentResourceManager.GetObject("siticoneGradientButton1.Image");
			this.siticoneGradientButton1.ImageAlign = HorizontalAlignment.Right;
			this.siticoneGradientButton1.ImageOffset = new Point(6, -1);
			this.siticoneGradientButton1.Location = new Point(18, 511);
			this.siticoneGradientButton1.Name = "siticoneGradientButton1";
			this.siticoneGradientButton1.ShadowDecoration.Parent = this.siticoneGradientButton1;
			this.siticoneGradientButton1.Size = new Size(651, 38);
			this.siticoneGradientButton1.TabIndex = 97;
			this.siticoneGradientButton1.Text = "Switch to Dark Mode";
			this.siticoneGradientButton1.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
			this.siticoneGradientButton1.Click += this.siticoneButton4_Click_1;
			this.label6.AutoSize = true;
			this.label6.Font = new Font("Inter", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label6.Location = new Point(126, 156);
			this.label6.Name = "label6";
			this.label6.Size = new Size(433, 38);
			this.label6.TabIndex = 98;
			this.label6.Text = "Our token verifier tool is currently disabled and will be\r\nback as soon as possible.";
			this.siticoneGradientButton3.BorderRadius = 18;
			this.siticoneGradientButton3.CheckedState.Parent = this.siticoneGradientButton3;
			this.siticoneGradientButton3.Cursor = Cursors.Hand;
			this.siticoneGradientButton3.CustomImages.Parent = this.siticoneGradientButton3;
			this.siticoneGradientButton3.FillColor = Color.FromArgb(56, 128, 255);
			this.siticoneGradientButton3.FillColor2 = Color.FromArgb(56, 128, 255);
			this.siticoneGradientButton3.Font = new Font("SF Pro Text", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.siticoneGradientButton3.ForeColor = Color.White;
			this.siticoneGradientButton3.HoveredState.Parent = this.siticoneGradientButton3;
			this.siticoneGradientButton3.Image = (Image)componentResourceManager.GetObject("siticoneGradientButton3.Image");
			this.siticoneGradientButton3.ImageAlign = HorizontalAlignment.Right;
			this.siticoneGradientButton3.ImageOffset = new Point(6, -1);
			this.siticoneGradientButton3.Location = new Point(178, 231);
			this.siticoneGradientButton3.Name = "siticoneGradientButton3";
			this.siticoneGradientButton3.ShadowDecoration.Parent = this.siticoneGradientButton3;
			this.siticoneGradientButton3.Size = new Size(308, 38);
			this.siticoneGradientButton3.TabIndex = 99;
			this.siticoneGradientButton3.Text = "Change Captcha Key";
			this.siticoneGradientButton3.TextRenderingHint = TextRenderingHint.AntiAlias;
			this.siticoneGradientButton3.Click += this.siticoneGradientButton6_Click;
			this.openDevToolsBtn.BorderRadius = 18;
			this.openDevToolsBtn.CheckedState.Parent = this.openDevToolsBtn;
			this.openDevToolsBtn.Cursor = Cursors.Hand;
			this.openDevToolsBtn.CustomImages.Parent = this.openDevToolsBtn;
			this.openDevToolsBtn.Enabled = false;
			this.openDevToolsBtn.FillColor = Color.DodgerBlue;
			this.openDevToolsBtn.FillColor2 = Color.DeepSkyBlue;
			this.openDevToolsBtn.Font = new Font("SF Pro Text", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.openDevToolsBtn.ForeColor = Color.White;
			this.openDevToolsBtn.HoveredState.Parent = this.openDevToolsBtn;
			this.openDevToolsBtn.Image = (Image)componentResourceManager.GetObject("openDevToolsBtn.Image");
			this.openDevToolsBtn.ImageAlign = HorizontalAlignment.Right;
			this.openDevToolsBtn.ImageOffset = new Point(6, -1);
			this.openDevToolsBtn.Location = new Point(383, 307);
			this.openDevToolsBtn.Name = "openDevToolsBtn";
			this.openDevToolsBtn.ShadowDecoration.Parent = this.openDevToolsBtn;
			this.openDevToolsBtn.Size = new Size(267, 38);
			this.openDevToolsBtn.TabIndex = 100;
			this.openDevToolsBtn.Text = "Developer Tools";
			this.openDevToolsBtn.TextRenderingHint = TextRenderingHint.AntiAlias;
			this.openDevToolsBtn.Click += this.siticoneButton7_Click;
			this.siticoneGradientButton5.BorderRadius = 18;
			this.siticoneGradientButton5.CheckedState.Parent = this.siticoneGradientButton5;
			this.siticoneGradientButton5.Cursor = Cursors.Hand;
			this.siticoneGradientButton5.CustomImages.Parent = this.siticoneGradientButton5;
			this.siticoneGradientButton5.FillColor = Color.DodgerBlue;
			this.siticoneGradientButton5.FillColor2 = Color.DeepSkyBlue;
			this.siticoneGradientButton5.Font = new Font("SF Pro Text", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.siticoneGradientButton5.ForeColor = Color.White;
			this.siticoneGradientButton5.HoveredState.Parent = this.siticoneGradientButton5;
			this.siticoneGradientButton5.Image = (Image)componentResourceManager.GetObject("siticoneGradientButton5.Image");
			this.siticoneGradientButton5.ImageAlign = HorizontalAlignment.Right;
			this.siticoneGradientButton5.ImageOffset = new Point(6, -1);
			this.siticoneGradientButton5.Location = new Point(383, 394);
			this.siticoneGradientButton5.Name = "siticoneGradientButton5";
			this.siticoneGradientButton5.ShadowDecoration.Parent = this.siticoneGradientButton5;
			this.siticoneGradientButton5.Size = new Size(267, 38);
			this.siticoneGradientButton5.TabIndex = 101;
			this.siticoneGradientButton5.Text = "Generate Text";
			this.siticoneGradientButton5.TextRenderingHint = TextRenderingHint.AntiAlias;
			this.siticoneGradientButton5.Click += this.siticoneButton7_Click_1;
			this.siticoneGradientButton4.BorderRadius = 18;
			this.siticoneGradientButton4.CheckedState.Parent = this.siticoneGradientButton4;
			this.siticoneGradientButton4.Cursor = Cursors.Hand;
			this.siticoneGradientButton4.CustomImages.Parent = this.siticoneGradientButton4;
			this.siticoneGradientButton4.FillColor = Color.DodgerBlue;
			this.siticoneGradientButton4.FillColor2 = Color.DeepSkyBlue;
			this.siticoneGradientButton4.Font = new Font("SF Pro Text", 12f, FontStyle.Bold | FontStyle.Strikeout, GraphicsUnit.Point, 0);
			this.siticoneGradientButton4.ForeColor = Color.White;
			this.siticoneGradientButton4.HoveredState.Parent = this.siticoneGradientButton4;
			this.siticoneGradientButton4.Image = (Image)componentResourceManager.GetObject("siticoneGradientButton4.Image");
			this.siticoneGradientButton4.ImageAlign = HorizontalAlignment.Right;
			this.siticoneGradientButton4.ImageOffset = new Point(6, -1);
			this.siticoneGradientButton4.Location = new Point(383, 351);
			this.siticoneGradientButton4.Name = "siticoneGradientButton4";
			this.siticoneGradientButton4.ShadowDecoration.Parent = this.siticoneGradientButton4;
			this.siticoneGradientButton4.Size = new Size(267, 38);
			this.siticoneGradientButton4.TabIndex = 102;
			this.siticoneGradientButton4.Text = "Audit Log";
			this.siticoneGradientButton4.TextRenderingHint = TextRenderingHint.AntiAlias;
			this.siticoneGradientButton4.Click += this.siticoneButton7_Click_2;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			this.ContextMenuStrip = this.contextMenuStrip1;
			base.Controls.Add(this.siticoneGradientButton4);
			base.Controls.Add(this.siticoneGradientButton5);
			base.Controls.Add(this.openDevToolsBtn);
			base.Controls.Add(this.siticoneGradientButton3);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.siticoneGradientButton1);
			base.Controls.Add(this.wdevm);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.siticoneToggleSwitch3);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.siticoneToggleSwitch1);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.hasDelay);
			base.Controls.Add(this.del);
			base.Controls.Add(this.siticoneGradientButton2);
			base.Controls.Add(this.siticoneWinToggleSwith1);
			base.Controls.Add(this.rem);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.pictureBox2);
			base.Controls.Add(this.label1);
			base.Name = "AdvancedSettings";
			base.Size = new Size(702, 558);
			base.Load += this.AdvancedSettings_Load;
			base.Click += this.AdvancedSettings_Click;
			((ISupportInitialize)this.pictureBox2).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000001 RID: 1
		private IContainer components = null;

		// Token: 0x04000002 RID: 2
		private Label label1;

		// Token: 0x04000003 RID: 3
		private PictureBox pictureBox2;

		// Token: 0x04000004 RID: 4
		private Label rem;

		// Token: 0x04000005 RID: 5
		private Label label2;

		// Token: 0x04000006 RID: 6
		private SiticoneDragControl siticoneDragControl1;

		// Token: 0x04000007 RID: 7
		private SiticoneWinToggleSwith siticoneWinToggleSwith1;

		// Token: 0x04000008 RID: 8
		private SiticoneGradientButton siticoneGradientButton2;

		// Token: 0x04000009 RID: 9
		private SiticoneToggleSwitch hasDelay;

		// Token: 0x0400000A RID: 10
		private Label del;

		// Token: 0x0400000B RID: 11
		private SiticoneToggleSwitch siticoneToggleSwitch1;

		// Token: 0x0400000C RID: 12
		private Label label3;

		// Token: 0x0400000D RID: 13
		private SiticoneToggleSwitch wdevm;

		// Token: 0x0400000E RID: 14
		private Label label4;

		// Token: 0x0400000F RID: 15
		private SiticoneToggleSwitch siticoneToggleSwitch3;

		// Token: 0x04000010 RID: 16
		private Label label5;

		// Token: 0x04000011 RID: 17
		private ContextMenuStrip contextMenuStrip1;

		// Token: 0x04000012 RID: 18
		private ToolStripMenuItem enableDeveloperToolsToolStripMenuItem;

		// Token: 0x04000013 RID: 19
		private SiticoneGradientButton siticoneGradientButton1;

		// Token: 0x04000014 RID: 20
		private Label label6;

		// Token: 0x04000015 RID: 21
		private SiticoneGradientButton siticoneGradientButton3;

		// Token: 0x04000016 RID: 22
		private SiticoneGradientButton openDevToolsBtn;

		// Token: 0x04000017 RID: 23
		private SiticoneGradientButton siticoneGradientButton5;

		// Token: 0x04000018 RID: 24
		private SiticoneGradientButton siticoneGradientButton4;
	}
}
