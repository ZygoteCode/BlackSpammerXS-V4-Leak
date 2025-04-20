using System;
using System.ComponentModel;
using System.Drawing;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Siticone.UI.WinForms;

namespace BlackSpammerXS
{
	// Token: 0x02000079 RID: 121
	public partial class LoadingCVF : Form
	{
		// Token: 0x060001F1 RID: 497 RVA: 0x00024114 File Offset: 0x00022314
		public LoadingCVF(OpacityFull opacityFull, bool dark)
		{
			this.InitializeComponent();
			this.full = opacityFull;
			this.siticoneShadowForm1.SetShadowForm(this);
			if (dark)
			{
				this.label1.ForeColor = Color.White;
				this.siticoneCircleProgressBar1.FillColor = Color.DimGray;
				this.siticoneCircleProgressBar1.ProgressColor = Color.Aqua;
				Color color = Color.FromArgb(44, 47, 51);
				this.BackColor = color;
			}
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x0002419C File Offset: 0x0002239C
		private async void LoadingCVF_Load(object sender, EventArgs e)
		{
			this.pictureBox1.Location = new Point(232, 57);
			this.pictureBox1.Visible = false;
			Control.CheckForIllegalCrossThreadCalls = false;
			new Thread(async delegate(object _a)
			{
				Control.CheckForIllegalCrossThreadCalls = false;
				HttpClient http = new HttpClient();
				try
				{
					HttpResponseMessage httpResponseMessage = await http.GetAsync("https://naoko.fun/api/v4/blackspammer/v3/xs/developer/devmode");
					string text = await httpResponseMessage.Content.ReadAsStringAsync();
					httpResponseMessage = null;
					string a = text;
					text = null;
					object b = JObject.Parse(a);
					try
					{
						this.siticoneCircleProgressBar1.Visible = false;
						this.pictureBox1.Visible = true;
						await Task.Delay(700);
						ImpostazioniGlobali.CallbackBridgeAL(4727417, 1, new object[0]);
						this.full.Close();
						base.Close();
					}
					catch
					{
					}
					a = null;
				}
				catch (Exception)
				{
					this.full.Close();
					base.Close();
				}
			}).Start();
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x000241E3 File Offset: 0x000223E3
		private void siticoneControlBox1_Click(object sender, EventArgs e)
		{
			this.full.Close();
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x000241F2 File Offset: 0x000223F2
		private void siticoneImageButton1_Click(object sender, EventArgs e)
		{
			this.full.Close();
			base.Close();
		}

		// Token: 0x04000461 RID: 1121
		private OpacityFull full;
	}
}
