using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlackSpammerXS.Properties;
using Siticone.UI.WinForms;

namespace BlackSpammerXS
{
	// Token: 0x02000051 RID: 81
	public partial class DevToolsBSXS : Form
	{
		// Token: 0x0600014F RID: 335 RVA: 0x00014B6C File Offset: 0x00012D6C
		public DevToolsBSXS(OpacityFull opacity, bool dark)
		{
			this.InitializeComponent();
			this.opacity = opacity;
			if (dark)
			{
				this.label1.ForeColor = Color.White;
				this.label5.ForeColor = Color.White;
				Color color = Color.FromArgb(44, 47, 51);
				this.BackColor = color;
				SiticoneTextBox siticoneTextBox = this.usText;
				siticoneTextBox.ForeColor = Color.White;
				siticoneTextBox.FillColor = color;
				siticoneTextBox.BorderColor = Color.Gray;
				siticoneTextBox.HoveredState.BorderColor = Color.Gray;
				List<SiticoneButton> list = new List<SiticoneButton>();
				list.Add(this.siticoneButton1);
				list.Add(this.siticoneButton2);
				list.Add(this.siticoneGradientButton1);
				list.Add(this.siticoneButton3);
				Color dimGray = Color.DimGray;
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
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00014CC8 File Offset: 0x00012EC8
		private void DevToolsBSXS_Load(object sender, EventArgs e)
		{
			try
			{
				this.label5.Text = string.Concat(new string[]
				{
					"BlackSpammer XS V4 17X",
					Environment.NewLine,
					"Debug Length: 0",
					Environment.NewLine,
					"XCP Length: ",
					ImpostazioniGlobali.XCP_Default.Length.ToString(),
					Environment.NewLine,
					"Audit Length: ",
					Settings.Default.audit.Length.ToString(),
					Environment.NewLine,
					"Log CL Interval: ",
					ImpostazioniGlobali.log_interval_cl.ToString()
				});
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00002067 File Offset: 0x00000267
		private void siticoneButton3_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00014D90 File Offset: 0x00012F90
		private void siticoneImageButton1_Click(object sender, EventArgs e)
		{
			this.opacity.Close();
			base.Close();
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00014DA8 File Offset: 0x00012FA8
		private void siticoneButton1_Click(object sender, EventArgs e)
		{
			bool ws_LogBasic = ImpostazioniGlobali.WS_LogBasic;
			if (ws_LogBasic)
			{
				ImpostazioniGlobali.WS_LogBasic = false;
			}
			else
			{
				ImpostazioniGlobali.WS_LogBasic = true;
			}
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00014DD4 File Offset: 0x00012FD4
		private async void siticoneGradientButton1_Click(object sender, EventArgs e)
		{
			this.siticoneGradientButton1.Enabled = false;
			bool flag = !this.usText.Text.StartsWith("cmd_t");
			if (flag)
			{
				try
				{
					ImpostazioniGlobali.Tokens.Clear();
				}
				catch (Exception)
				{
					ImpostazioniGlobali.Tokens = new List<string>();
				}
				ImpostazioniGlobali.Tokens.Add(this.usText.Text);
				ImpostazioniGlobali.CallbackBridgeAL(3699, 1601, new object[0]);
			}
			else
			{
				bool flag2 = this.usText.Text.StartsWith("cmd_t dev_log_interval=");
				if (flag2)
				{
					try
					{
						string i_log_nw = this.usText.Text.Replace("cmd_t dev_log_interval=", "");
						ImpostazioniGlobali.log_interval_cl = int.Parse(i_log_nw);
						this.usText.Text = "[cmd_t] Success. New interval: " + ImpostazioniGlobali.log_interval_cl.ToString();
						i_log_nw = null;
					}
					catch
					{
						this.usText.Text = "[cmd_t] An error has occurred.";
					}
				}
				else
				{
					this.usText.Text = "[cmd_t] Unknown developer command.";
				}
			}
			await Task.Delay(300);
			this.siticoneGradientButton1.Enabled = true;
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00014E1B File Offset: 0x0001301B
		private void siticoneButton2_Click(object sender, EventArgs e)
		{
			this.siticoneButton2.Enabled = false;
			Control.CheckForIllegalCrossThreadCalls = false;
			new Thread(async delegate(object _a)
			{
				Control.CheckForIllegalCrossThreadCalls = false;
				HttpClient http = new HttpClient();
				string a = "";
				try
				{
					HttpResponseMessage httpResponseMessage = await http.GetAsync("https://naoko.fun");
					HttpResponseMessage c = httpResponseMessage;
					httpResponseMessage = null;
					string text = await c.Content.ReadAsStringAsync();
					string b = text;
					text = null;
					int s = (int)c.StatusCode;
					KeyValuePair<string, IEnumerable<string>>[] u = c.Headers.ToArray<KeyValuePair<string, IEnumerable<string>>>();
					a = string.Concat(new string[]
					{
						"URL: https://naoko.fun",
						Environment.NewLine,
						"Status: ",
						s.ToString(),
						Environment.NewLine,
						"Headers Length: ",
						u.Length.ToString(),
						Environment.NewLine,
						"Response: ",
						b
					});
					c = null;
					b = null;
					u = null;
				}
				catch (Exception ee)
				{
					a = string.Concat(new string[]
					{
						"URL: https://naoko.fun",
						Environment.NewLine,
						"Error: True",
						Environment.NewLine,
						"Exception: ",
						ee.Message
					});
				}
				base.Invoke(new MethodInvoker(delegate
				{
					GTextRes gtextRes = new GTextRes(a, this.opacity, Settings.Default.dark);
					gtextRes.Show();
					gtextRes.Focus();
					this.Close();
				}));
			}).Start();
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00014E4C File Offset: 0x0001304C
		private void siticoneButton3_Click_1(object sender, EventArgs e)
		{
			try
			{
				DevConsole devConsole = new DevConsole();
				devConsole.Show();
				this.opacity.Close();
				base.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Si è verificato un errore. Puoi riprovare?", "Developer Tools", ContentAlignment.MiddleCenter);
			}
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00002067 File Offset: 0x00000267
		private void label5_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x04000261 RID: 609
		private OpacityFull opacity;
	}
}
