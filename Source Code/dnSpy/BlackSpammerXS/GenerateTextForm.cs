using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Siticone.UI.WinForms;

namespace BlackSpammerXS
{
	// Token: 0x0200005A RID: 90
	public partial class GenerateTextForm : Form
	{
		// Token: 0x06000183 RID: 387 RVA: 0x00018D58 File Offset: 0x00016F58
		public GenerateTextForm(OpacityFull opacityBack, bool dark)
		{
			this.InitializeComponent();
			this.opacity = opacityBack;
			this.isdark = dark;
			this.siticoneShadowForm1.SetShadowForm(this);
			this.siticoneAnimateWindow1.SetAnimateWindow(this);
			if (dark)
			{
				Color color = Color.FromArgb(44, 47, 51);
				this.BackColor = color;
				Color dimGray = Color.DimGray;
				SiticoneTextBox siticoneTextBox = this.usText;
				siticoneTextBox.ForeColor = Color.White;
				siticoneTextBox.FillColor = color;
				siticoneTextBox.BorderColor = Color.Gray;
				siticoneTextBox.HoveredState.BorderColor = Color.Gray;
				List<Label> list = new List<Label> { this.label1, this.label2, this.label3, this.del };
				foreach (Label label in list)
				{
					label.ForeColor = Color.White;
				}
			}
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00018E88 File Offset: 0x00017088
		private async void siticoneGradientButton5_Click(object sender, EventArgs e)
		{
			bool flag = string.IsNullOrEmpty(this.usText.Text);
			if (!flag)
			{
				int am = 1;
				try
				{
					am = int.Parse(this.usText.Text);
					bool flag2 = am > 100;
					if (flag2)
					{
						throw new Exception("Numero troppo grande");
					}
				}
				catch (Exception)
				{
					return;
				}
				this.siticoneGradientButton5.Enabled = false;
				this.usText.ReadOnly = true;
				this.siticoneGradientButton5.Text = "Generating..";
				await Task.Delay(100);
				try
				{
					string finalText = "";
					if (this.hasMTX.Checked)
					{
						for (int a = 0; a < am + 1; a++)
						{
							finalText = finalText + "[mtag" + a.ToString() + "]";
						}
					}
					if (this.hasRand.Checked)
					{
						for (int a2 = 0; a2 < am + 1; a2++)
						{
							finalText += "[rand]";
						}
					}
					if (this.hasCount.Checked)
					{
						for (int a3 = 0; a3 < am + 1; a3++)
						{
							finalText += "[count]";
						}
					}
					ImpostazioniGlobali.bridgeAct_(0);
					OpacityFull opacityFull = new OpacityFull();
					opacityFull.Show();
					GTextRes gTextRes = new GTextRes(finalText, opacityFull, this.isdark);
					gTextRes.Show();
					gTextRes.Focus();
					base.Close();
					finalText = null;
					opacityFull = null;
					gTextRes = null;
				}
				catch (Exception)
				{
					ImpostazioniGlobali.Log("GenerateText => Ops! Something went wrong: 0x7311");
				}
			}
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00018ECF File Offset: 0x000170CF
		private void siticoneControlBox1_Click(object sender, EventArgs e)
		{
			ImpostazioniGlobali.bridgeAct_(0);
			base.Close();
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00002067 File Offset: 0x00000267
		private void hastwocap_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00018EE8 File Offset: 0x000170E8
		private async void siticoneToggleSwitch1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00002067 File Offset: 0x00000267
		private void GenerateTextForm_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000189 RID: 393 RVA: 0x00018F2F File Offset: 0x0001712F
		private void siticoneImageButton1_Click(object sender, EventArgs e)
		{
			this.siticoneControlBox1_Click(sender, e);
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00018F3B File Offset: 0x0001713B
		private void siticoneButton7_Click(object sender, EventArgs e)
		{
			this.siticoneGradientButton5_Click(sender, e);
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00002067 File Offset: 0x00000267
		private void siticoneImageButton2_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x040002B5 RID: 693
		private OpacityFull opacity;

		// Token: 0x040002B6 RID: 694
		private bool isdark;
	}
}
