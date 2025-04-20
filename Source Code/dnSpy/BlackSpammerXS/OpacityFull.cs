using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Siticone.UI.WinForms;

namespace BlackSpammerXS
{
	// Token: 0x02000085 RID: 133
	public partial class OpacityFull : Form
	{
		// Token: 0x06000231 RID: 561 RVA: 0x00029164 File Offset: 0x00027364
		public OpacityFull()
		{
			this.InitializeComponent();
			base.WindowState = FormWindowState.Maximized;
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00029184 File Offset: 0x00027384
		private void OpacityFull_Load(object sender, EventArgs e)
		{
			this.siticoneAnimateWindow1.SetAnimateWindow(this);
			base.Enabled = false;
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00002067 File Offset: 0x00000267
		private void OpacityFull_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00002067 File Offset: 0x00000267
		private void OpacityFull_Activated(object sender, EventArgs e)
		{
		}

		// Token: 0x06000235 RID: 565 RVA: 0x000124A4 File Offset: 0x000106A4
		private void chiudiToolStripMenuItem_Click(object sender, EventArgs e)
		{
			base.Close();
		}
	}
}
