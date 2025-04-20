using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Siticone.UI.WinForms;

namespace BlackSpammerXS
{
	// Token: 0x0200007C RID: 124
	public partial class Logger : Form
	{
		// Token: 0x060001FE RID: 510 RVA: 0x00024D70 File Offset: 0x00022F70
		public Logger(bool _mode, bool _streamer)
		{
			this.InitializeComponent();
			if (_mode)
			{
				Color color = Color.FromArgb(44, 47, 51);
				this.BackColor = color;
				this.logBox.FillColor = color;
				this.logBox.ForeColor = Color.White;
			}
			bool flag = !ImpostazioniGlobali.LOG_UseNewFont;
			if (flag)
			{
				try
				{
					this.logBox.Font = new Font(new FontFamily("SF Pro Text"), 9.75f, FontStyle.Regular);
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x060001FF RID: 511 RVA: 0x00024E28 File Offset: 0x00023028
		protected override void WndProc(ref Message m)
		{
			int msg = m.Msg;
			int num = msg;
			if (num != 132)
			{
				base.WndProc(ref m);
			}
			else
			{
				base.WndProc(ref m);
				bool flag = (int)m.Result == 1;
				if (flag)
				{
					Point point = new Point(m.LParam.ToInt32());
					Point point2 = base.PointToClient(point);
					bool flag2 = point2.Y <= 10;
					if (flag2)
					{
						bool flag3 = point2.X <= 10;
						if (flag3)
						{
							m.Result = (IntPtr)13;
						}
						else
						{
							bool flag4 = point2.X < base.Size.Width - 10;
							if (flag4)
							{
								m.Result = (IntPtr)12;
							}
							else
							{
								m.Result = (IntPtr)14;
							}
						}
					}
					else
					{
						bool flag5 = point2.Y <= base.Size.Height - 10;
						if (flag5)
						{
							bool flag6 = point2.X <= 10;
							if (flag6)
							{
								m.Result = (IntPtr)10;
							}
							else
							{
								bool flag7 = point2.X < base.Size.Width - 10;
								if (flag7)
								{
									m.Result = (IntPtr)2;
								}
								else
								{
									m.Result = (IntPtr)11;
								}
							}
						}
						else
						{
							bool flag8 = point2.X <= 10;
							if (flag8)
							{
								m.Result = (IntPtr)16;
							}
							else
							{
								bool flag9 = point2.X < base.Size.Width - 10;
								if (flag9)
								{
									m.Result = (IntPtr)15;
								}
								else
								{
									m.Result = (IntPtr)17;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000200 RID: 512 RVA: 0x00025004 File Offset: 0x00023204
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.Style |= 131072;
				return createParams;
			}
		}

		// Token: 0x06000201 RID: 513 RVA: 0x00025034 File Offset: 0x00023234
		public string get_log_content()
		{
			return this.logBox.Text;
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00025054 File Offset: 0x00023254
		public string get_queue_last_thrm()
		{
			int num = this.queue_w.Keys.First<int>();
			string text = this.queue_w[num];
			try
			{
				this.queue_w.Remove(num);
			}
			catch
			{
			}
			return text;
		}

		// Token: 0x06000203 RID: 515 RVA: 0x000250AC File Offset: 0x000232AC
		private void Logger_Load(object sender, EventArgs e)
		{
			this.siticoneShadowForm1.SetShadowForm(this);
			ImpostazioniGlobali.l_ = new Action<string>(this.PutLog);
			int num;
			int num2;
			ThreadPool.GetMaxThreads(out num, out num2);
			ThreadPool.SetMinThreads(num2 - 1, num2 - 1);
			this.ch_queue_t = new Thread(delegate(object f)
			{
				while (this.q_c_l)
				{
					bool flag = !this.q_c_l;
					if (flag)
					{
						break;
					}
					bool flag2 = this.queue_w.Count == 0;
					if (!flag2)
					{
						try
						{
							this.logBox.AppendText(Environment.NewLine + this.get_queue_last_thrm());
						}
						catch (Exception)
						{
						}
						Thread.Sleep(1);
					}
				}
			});
			this.ch_queue_t.Start();
		}

		// Token: 0x06000204 RID: 516 RVA: 0x00025114 File Offset: 0x00023314
		public void PutLog(string a)
		{
			try
			{
				bool flag = this.logBox.Text.Length > ImpostazioniGlobali.log_interval_cl;
				if (flag)
				{
					this.logBox.Text = "";
					this.logBox.AppendText(Environment.NewLine + "Log => Auto Clear :: Done[" + ImpostazioniGlobali.log_interval_cl.ToString() + "]");
				}
			}
			catch (Exception)
			{
			}
			try
			{
				this.queue_w.Add(this.queue_w.Count, a);
			}
			catch
			{
			}
		}

		// Token: 0x06000205 RID: 517 RVA: 0x00002067 File Offset: 0x00000267
		private void logBox_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000206 RID: 518 RVA: 0x000251C4 File Offset: 0x000233C4
		private void Logger_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				ImpostazioniGlobali.LogForm = null;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000207 RID: 519 RVA: 0x000251F4 File Offset: 0x000233F4
		private void siticoneImageButton1_Click(object sender, EventArgs e)
		{
			this.q_c_l = false;
			try
			{
				this.ch_queue_t.Abort();
			}
			catch
			{
			}
			try
			{
				this.queue_w.Clear();
			}
			catch
			{
			}
			try
			{
				this.logBox.Clear();
			}
			catch
			{
			}
			try
			{
				base.Dispose();
			}
			catch
			{
			}
			try
			{
				base.Close();
			}
			catch
			{
			}
		}

		// Token: 0x06000208 RID: 520 RVA: 0x000124AE File Offset: 0x000106AE
		private void siticoneImageButton2_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x06000209 RID: 521 RVA: 0x000252AC File Offset: 0x000234AC
		private void siticoneImageButton3_Click(object sender, EventArgs e)
		{
			bool flag = base.WindowState == FormWindowState.Maximized;
			if (flag)
			{
				base.WindowState = FormWindowState.Normal;
			}
			else
			{
				base.WindowState = FormWindowState.Maximized;
			}
		}

		// Token: 0x0400047C RID: 1148
		private Thread ch_queue_t;

		// Token: 0x0400047D RID: 1149
		private bool q_c_l = true;

		// Token: 0x0400047E RID: 1150
		private Dictionary<int, string> queue_w = new Dictionary<int, string>();
	}
}
