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
	// Token: 0x0200000C RID: 12
	public partial class AlertFM : Form
	{
		// Token: 0x0600003A RID: 58 RVA: 0x00004964 File Offset: 0x00002B64
		public AlertFM(string alert, string title = "Avviso", ContentAlignment contentAlign = ContentAlignment.MiddleCenter)
		{
			this.InitializeComponent();
			this.label2.Text = alert;
			this.label1.Text = title;
			this.label2.TextAlign = contentAlign;
			bool dark = Settings.Default.dark;
			if (dark)
			{
				this.setDark();
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000049E8 File Offset: 0x00002BE8
		public AlertFM(Action<int, int> callback, string alert, string title = "Avviso", ContentAlignment contentAlign = ContentAlignment.MiddleCenter)
		{
			this.InitializeComponent();
			this.label2.Text = alert;
			this.label1.Text = title;
			this.label2.TextAlign = contentAlign;
			this.callback = callback;
			bool dark = Settings.Default.dark;
			if (dark)
			{
				this.setDark();
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00004A74 File Offset: 0x00002C74
		public AlertFM(int type, string alert, string title = "Avviso", ContentAlignment contentAlign = ContentAlignment.MiddleCenter)
		{
			this.InitializeComponent();
			this.label2.Text = alert;
			this.label1.Text = title;
			this.label2.TextAlign = contentAlign;
			bool flag = type == 1;
			if (flag)
			{
				this.setDark();
			}
			bool flag2 = type == 2;
			if (flag2)
			{
				this.setWhite();
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00004B04 File Offset: 0x00002D04
		public AlertFM(int type, Action<int, int> callback, string alert, string title = "Avviso", ContentAlignment contentAlign = ContentAlignment.MiddleCenter)
		{
			this.InitializeComponent();
			this.label2.Text = alert;
			this.label1.Text = title;
			this.label2.TextAlign = contentAlign;
			this.callback = callback;
			bool flag = type == 1;
			if (flag)
			{
				this.setDark();
			}
			bool flag2 = type == 2;
			if (flag2)
			{
				this.setWhite();
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00004B9A File Offset: 0x00002D9A
		public void setWhite()
		{
			this.BackColor = Color.White;
			this.annullaBtn.BackColor = Color.Snow;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00004BBC File Offset: 0x00002DBC
		public void setDark()
		{
			Color color = Color.FromArgb(35, 39, 42);
			Color dimGray = Color.DimGray;
			this.BackColor = color;
			this.label1.ForeColor = Color.White;
			this.label2.ForeColor = Color.White;
			this.annullaBtn.ForeColor = Color.White;
			this.annullaBtn.FillColor = dimGray;
			this.annullaBtn.BorderColor = Color.Gray;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00004C38 File Offset: 0x00002E38
		private void siticoneImageButton1_Click(object sender, EventArgs e)
		{
			try
			{
				this.callback(0, 1);
			}
			catch
			{
			}
			base.Close();
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00004C74 File Offset: 0x00002E74
		private void siticoneButton1_Click(object sender, EventArgs e)
		{
			try
			{
				this.callback(0, 2);
			}
			catch
			{
			}
			base.Close();
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00004CB0 File Offset: 0x00002EB0
		private void annullaBtn_Click(object sender, EventArgs e)
		{
			try
			{
				this.callback(0, 3);
			}
			catch
			{
			}
			base.Close();
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00004CEC File Offset: 0x00002EEC
		private void AlertFM_Load(object sender, EventArgs e)
		{
			this.siticoneShadowForm1.SetShadowForm(this);
			try
			{
				this.callback(1, 1);
			}
			catch
			{
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002067 File Offset: 0x00000267
		private void label1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x04000048 RID: 72
		private Action<int, int> callback = delegate(int a, int b)
		{
		};
	}
}
