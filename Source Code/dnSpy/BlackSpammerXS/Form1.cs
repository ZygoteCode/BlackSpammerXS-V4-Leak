using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlackSpammerXS.Properties;
using Bunifu.Framework.UI;
using Siticone.UI.WinForms;

namespace BlackSpammerXS
{
	// Token: 0x02000055 RID: 85
	public partial class Form1 : Form
	{
		// Token: 0x06000163 RID: 355 RVA: 0x00016530 File Offset: 0x00014730
		public Form1(int __sqn, int add_of, int ct, Login f_origin)
		{
			this.InitializeComponent();
			bool flag = f_origin == null || SecurityMT.ch_scr(__sqn - 63554, this.GetHashCode() / 241, ct, 63554, this) != 287059;
			if (flag)
			{
				SecLG.o_wr("secr err 94178");
				Application.Exit();
			}
			else
			{
				Task.Run(delegate
				{
					try
					{
						Thread.Sleep(1000);
						f_origin.Dispose();
					}
					catch
					{
					}
					try
					{
						Thread.Sleep(1000);
						f_origin.Close();
					}
					catch
					{
					}
				});
			}
		}

		// Token: 0x06000164 RID: 356 RVA: 0x000165C0 File Offset: 0x000147C0
		private void Form1_Load(object sender, EventArgs e)
		{
			this.siticoneShadowForm1.SetShadowForm(this);
			this.dashboard1.BringToFront();
			try
			{
				this.label3.Text = Settings.Default._U.ToUpper();
			}
			catch (Exception)
			{
			}
			bool dark = Settings.Default.dark;
			if (dark)
			{
				this.SwitchTheme(true);
				this.advancedSettings1.Switch();
			}
			ImpostazioniGlobali.CaptchaKey_SMSACT = Settings.Default.capkeyCAPmon;
			ImpostazioniGlobali.CaptchaKey_TWO = Settings.Default.capkeyTWOcap;
			ImpostazioniGlobali.auditManager = new AuditManager();
			ImpostazioniGlobali._bridgeLogPerform.Add(delegate(int a, int b, object[] i)
			{
				bool flag = a == 1153;
				if (flag)
				{
					bool flag2 = b == 0;
					if (flag2)
					{
						this.dashboard1.BringToFront();
						this.siticoneButton1.PerformClick();
					}
					bool flag3 = b == 1;
					if (flag3)
					{
						this.guildManager1.BringToFront();
						this.siticoneButton4.PerformClick();
					}
					bool flag4 = b == 2;
					if (flag4)
					{
						this.serverSpammer1.BringToFront();
						this.siticoneButton3.PerformClick();
					}
					bool flag5 = b == 3;
					if (flag5)
					{
						this.reactionSpammer1.BringToFront();
						this.siticoneButton2.PerformClick();
					}
				}
			});
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00016680 File Offset: 0x00014880
		private async void dashboard1_Load(object sender, EventArgs e)
		{
			bool at = false;
			int lt = 0;
			int lp = 0;
			bool flag = Settings.Default.lastProxies != "";
			if (flag)
			{
				at = true;
				await Task.Run(delegate
				{
					try
					{
						using (StreamReader streamReader = new StreamReader(Settings.Default.lastProxies))
						{
							List<string> list = new List<string>();
							string text;
							while ((text = streamReader.ReadLine()) != null)
							{
								list.Add(text);
							}
							ImpostazioniGlobali.Proxies = list;
							Control.CheckForIllegalCrossThreadCalls = false;
							this.dashboard1.SetProxies(list.Count);
							lp = list.Count;
							Control.CheckForIllegalCrossThreadCalls = true;
						}
					}
					catch (Exception)
					{
					}
				});
			}
			if (Settings.Default.lastTokens != "")
			{
				at = true;
				await Task.Run(delegate
				{
					try
					{
						using (StreamReader streamReader2 = new StreamReader(Settings.Default.lastTokens))
						{
							List<string> list2 = new List<string>();
							string text2;
							while ((text2 = streamReader2.ReadLine()) != null)
							{
								list2.Add(text2);
							}
							ImpostazioniGlobali.Tokens = list2;
							Control.CheckForIllegalCrossThreadCalls = false;
							this.dashboard1.SetTokens(list2.Count);
							lt = list2.Count;
							Control.CheckForIllegalCrossThreadCalls = true;
						}
					}
					catch (Exception)
					{
					}
				});
			}
			if (at)
			{
			}
			try
			{
				ImpostazioniGlobali._themeCallback = new Action<bool>(this.SwitchTheme);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000166 RID: 358 RVA: 0x000166C8 File Offset: 0x000148C8
		public void Light()
		{
			ImpostazioniGlobali.LoggerDark = false;
			Settings.Default.dark = false;
			Settings.Default.Save();
			try
			{
				double num = base.Opacity + 0.0;
				base.Opacity = 0.0;
				base.Controls.Clear();
				this.InitializeComponent();
				base.Opacity = num;
			}
			catch (Exception)
			{
				Application.Restart();
			}
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00016750 File Offset: 0x00014950
		public void SwitchTheme(bool a)
		{
			bool flag = !a;
			if (flag)
			{
				this.Light();
			}
			else
			{
				Color color = Color.FromArgb(35, 39, 42);
				Color color2 = Color.FromArgb(44, 47, 51);
				try
				{
					this.BackColor = color;
					this.siticonePanel1.BackColor = color;
					foreach (object obj in base.Controls)
					{
						Control control = (Control)obj;
						try
						{
							control.ForeColor = Color.White;
							bool flag2 = !(control is Label);
							if (flag2)
							{
								control.BackColor = color;
							}
						}
						catch (Exception)
						{
						}
					}
					foreach (SiticoneButton siticoneButton in new List<SiticoneButton> { this.siticoneButton1, this.siticoneButton2, this.siticoneButton3, this.siticoneButton4, this.siticoneButton6, this.siticoneButton5 })
					{
						try
						{
							siticoneButton.ForeColor = Color.White;
							siticoneButton.FillColor = color;
							siticoneButton.CheckedState.FillColor = color;
						}
						catch (Exception)
						{
						}
					}
					this.dashboard1.Dark();
					this.guildManager1.Dark();
					this.serverSpammer1.Dark();
					this.reactionSpammer1.Dark();
					this.advancedSettings1.Dark();
					this.websocketManager1.Dark();
					ImpostazioniGlobali.LoggerDark = true;
					Settings.Default.dark = true;
					Settings.Default.Save();
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x06000168 RID: 360 RVA: 0x000169B0 File Offset: 0x00014BB0
		private void siticoneButton1_Click(object sender, EventArgs e)
		{
			bool @checked = this.siticoneButton1.Checked;
			if (@checked)
			{
				this.dashboard1.BringToFront();
			}
		}

		// Token: 0x06000169 RID: 361 RVA: 0x000169DC File Offset: 0x00014BDC
		private void siticoneButton4_Click(object sender, EventArgs e)
		{
			bool @checked = this.siticoneButton4.Checked;
			if (@checked)
			{
				this.guildManager1.BringToFront();
			}
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00016A08 File Offset: 0x00014C08
		private void siticoneButton3_Click(object sender, EventArgs e)
		{
			bool @checked = this.siticoneButton3.Checked;
			if (@checked)
			{
				this.serverSpammer1.BringToFront();
			}
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00016A34 File Offset: 0x00014C34
		private void siticoneButton2_Click(object sender, EventArgs e)
		{
			bool @checked = this.siticoneButton2.Checked;
			if (@checked)
			{
				this.reactionSpammer1.BringToFront();
			}
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00002067 File Offset: 0x00000267
		private void siticonePanel1_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00016A5D File Offset: 0x00014C5D
		private void siticoneControlBox2_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00016A66 File Offset: 0x00014C66
		private void siticoneButton5_Click(object sender, EventArgs e)
		{
			Settings.Default.Reset();
			Settings.Default.Save();
			Application.Restart();
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00016A85 File Offset: 0x00014C85
		private void siticoneButton6_Click(object sender, EventArgs e)
		{
			this.advancedSettings1.BringToFront();
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00002067 File Offset: 0x00000267
		private void label1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00016A94 File Offset: 0x00014C94
		private void siticoneGradientButton1_Click(object sender, EventArgs e)
		{
			MessageBox.Show(delegate(int a, int b)
			{
				bool flag = a == 0 && b == 2;
				if (flag)
				{
					Settings.Default.Reset();
					Settings.Default.Save();
					Application.Restart();
				}
			}, "Sei sicuro di voler uscire? Questo comporterà un reset totale.", "Logout", ContentAlignment.MiddleCenter);
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00016AC8 File Offset: 0x00014CC8
		private void siticoneImageButton1_Click(object sender, EventArgs e)
		{
			try
			{
				Process.GetCurrentProcess().Kill();
			}
			catch
			{
			}
			try
			{
				Application.Exit();
			}
			catch
			{
			}
		}

		// Token: 0x06000173 RID: 371 RVA: 0x000124AE File Offset: 0x000106AE
		private void siticoneImageButton2_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00016B18 File Offset: 0x00014D18
		private void siticoneButton5_Click_1(object sender, EventArgs e)
		{
			this.websocketManager1.BringToFront();
		}
	}
}
