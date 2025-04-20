using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using BlackSpammerXS.Properties;
using Siticone.UI.WinForms;

namespace BlackSpammerXS
{
	// Token: 0x02000032 RID: 50
	public partial class ChcapKM : Form
	{
		// Token: 0x060000D0 RID: 208 RVA: 0x0000E180 File Offset: 0x0000C380
		public ChcapKM()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00007DF3 File Offset: 0x00005FF3
		private void siticoneControlBox1_Click(object sender, EventArgs e)
		{
			ImpostazioniGlobali.bridgeAct_(0);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000E198 File Offset: 0x0000C398
		private void ChcapKM_Load(object sender, EventArgs e)
		{
			this.siticoneShadowForm1.SetShadowForm(this);
			this.siticoneAnimateWindow1.SetAnimateWindow(this);
			bool dark = Settings.Default.dark;
			if (dark)
			{
				Color color = Color.FromArgb(44, 47, 51);
				Color dimGray = Color.DimGray;
				this.BackColor = color;
				this.label1.ForeColor = Color.White;
				this.label2.ForeColor = Color.White;
				this.del.ForeColor = Color.White;
				this.siticoneButton6.ForeColor = Color.White;
				this.siticoneButton6.FillColor = dimGray;
				this.siticoneButton6.BorderColor = Color.Gray;
				this.usText.ForeColor = Color.White;
				this.usText.FillColor = color;
				this.usText.BorderColor = Color.Gray;
				this.usText.HoveredState.BorderColor = Color.Gray;
			}
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000E294 File Offset: 0x0000C494
		private void siticoneButton6_Click(object sender, EventArgs e)
		{
			bool @checked = this.hascapmon.Checked;
			if (@checked)
			{
				Settings.Default.capkeyCAPmon = this.usText.Text;
				ImpostazioniGlobali.CaptchaKey_SMSACT = this.usText.Text;
			}
			else
			{
				Settings.Default.capkeyTWOcap = this.usText.Text;
				ImpostazioniGlobali.CaptchaKey_TWO = this.usText.Text;
			}
			Settings.Default.Save();
			Settings.Default.Reload();
			ImpostazioniGlobali.bridgeAct_(0);
			base.Close();
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000E32C File Offset: 0x0000C52C
		private void hasDelay_Click(object sender, EventArgs e)
		{
			this.hastwocap.Checked = false;
			this.usText.PlaceholderText = "SmsActivate Key";
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000E34D File Offset: 0x0000C54D
		private void tdel_Click(object sender, EventArgs e)
		{
			this.hascapmon.Checked = false;
			this.usText.PlaceholderText = "Captcha Key";
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000E370 File Offset: 0x0000C570
		private void hastwocap_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !this.hastwocap.Checked;
			if (flag)
			{
				this.hastwocap.Checked = true;
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000E39D File Offset: 0x0000C59D
		private void siticoneImageButton1_Click(object sender, EventArgs e)
		{
			this.siticoneControlBox1_Click(sender, e);
		}
	}
}
