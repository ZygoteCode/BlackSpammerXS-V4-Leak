using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Siticone.UI.WinForms;

namespace BlackSpammerXS
{
	// Token: 0x0200005D RID: 93
	public partial class GTextRes : Form
	{
		// Token: 0x06000194 RID: 404 RVA: 0x0001A480 File Offset: 0x00018680
		public GTextRes(string _res, OpacityFull opacity, bool dark)
		{
			this.InitializeComponent();
			this.usText.Text = _res;
			this.opacity = opacity;
			if (dark)
			{
				this.label1.ForeColor = Color.White;
				Color color = Color.FromArgb(44, 47, 51);
				this.BackColor = color;
				Color dimGray = Color.DimGray;
				SiticoneTextBox siticoneTextBox = this.usText;
				siticoneTextBox.ForeColor = Color.White;
				siticoneTextBox.FillColor = color;
				siticoneTextBox.BorderColor = Color.Gray;
				siticoneTextBox.HoveredState.BorderColor = Color.Gray;
			}
		}

		// Token: 0x06000195 RID: 405 RVA: 0x0001A521 File Offset: 0x00018721
		private void GTextRes_Load(object sender, EventArgs e)
		{
			this.siticoneShadowForm1.SetShadowForm(this);
			this.siticoneAnimateWindow1.SetAnimateWindow(this);
		}

		// Token: 0x06000196 RID: 406 RVA: 0x0001A53E File Offset: 0x0001873E
		private void siticoneControlBox1_Click(object sender, EventArgs e)
		{
			ImpostazioniGlobali.bridgeAct_(0);
			this.opacity.Close();
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00002067 File Offset: 0x00000267
		private void label1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000198 RID: 408 RVA: 0x0001A559 File Offset: 0x00018759
		private void siticoneImageButton1_Click(object sender, EventArgs e)
		{
			this.siticoneControlBox1_Click(sender, e);
			base.Close();
		}

		// Token: 0x040002DA RID: 730
		private OpacityFull opacity;
	}
}
