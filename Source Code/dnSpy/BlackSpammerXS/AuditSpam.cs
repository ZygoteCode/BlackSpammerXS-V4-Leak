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
	// Token: 0x0200001D RID: 29
	public class AuditSpam : UserControl
	{
		// Token: 0x06000088 RID: 136 RVA: 0x00009BC4 File Offset: 0x00007DC4
		public AuditSpam(string serverId, string tokens, string proxies, string timeStamp, string message, string mref, bool dark, AuditLogForm __log)
		{
			this.InitializeComponent();
			this.sLink.Text = serverId;
			this.tamount.Text = tokens;
			this.proxiesAm.Text = proxies;
			this.a = message;
			this.b = mref;
			this.__log = __log;
			if (dark)
			{
				List<Label> list = new List<Label> { this.sLink, this.label1, this.label2, this.label3, this.tamount, this.proxiesAm, this.label4, this.label6, this.label7 };
				foreach (Label label in list)
				{
					label.ForeColor = Color.White;
				}
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00002067 File Offset: 0x00000267
		private void AuditSpam_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00009CF8 File Offset: 0x00007EF8
		private async void siticoneGradientButton3_Click(object sender, EventArgs e)
		{
			await Task.Delay(50);
			ImpostazioniGlobali.CallbackBridgeAL(1, 0, new object[]
			{
				this.sLink.Text,
				this.a,
				this.b
			});
			ImpostazioniGlobali.bridgeAct_(0);
			ImpostazioniGlobali.CallbackBridgeAL(1153, 2, null);
			this.__log.Close();
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00009D3F File Offset: 0x00007F3F
		private void siticoneButton3_Click(object sender, EventArgs e)
		{
			this.siticoneGradientButton3_Click(sender, e);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00009D4C File Offset: 0x00007F4C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00009D84 File Offset: 0x00007F84
		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AuditSpam));
			this.label7 = new Label();
			this.pictureBox1 = new PictureBox();
			this.label6 = new Label();
			this.proxiesAm = new Label();
			this.label4 = new Label();
			this.tamount = new Label();
			this.label2 = new Label();
			this.label3 = new Label();
			this.sLink = new Label();
			this.label1 = new Label();
			this.siticoneButton3 = new SiticoneGradientButton();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.label7.AutoSize = true;
			this.label7.Font = new Font("SF Pro Text", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label7.Location = new Point(116, 88);
			this.label7.Name = "label7";
			this.label7.Size = new Size(30, 15);
			this.label7.TabIndex = 115;
			this.label7.Text = "and";
			this.pictureBox1.Image = (Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new Point(15, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(24, 24);
			this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 114;
			this.pictureBox1.TabStop = false;
			this.label6.AutoSize = true;
			this.label6.Font = new Font("SF Pro Text", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label6.Location = new Point(206, 88);
			this.label6.Name = "label6";
			this.label6.Size = new Size(56, 15);
			this.label6.TabIndex = 113;
			this.label6.Text = "proxies.";
			this.proxiesAm.Font = new Font("SF Pro Text", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.proxiesAm.Location = new Point(150, 84);
			this.proxiesAm.Name = "proxiesAm";
			this.proxiesAm.Size = new Size(52, 23);
			this.proxiesAm.TabIndex = 112;
			this.proxiesAm.Text = "1000";
			this.proxiesAm.TextAlign = ContentAlignment.MiddleCenter;
			this.label4.AutoSize = true;
			this.label4.Font = new Font("SF Pro Text", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label4.Location = new Point(63, 88);
			this.label4.Name = "label4";
			this.label4.Size = new Size(49, 15);
			this.label4.TabIndex = 111;
			this.label4.Text = "tokens";
			this.tamount.Font = new Font("SF Pro Text", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.tamount.Location = new Point(11, 85);
			this.tamount.Name = "tamount";
			this.tamount.Size = new Size(52, 23);
			this.tamount.TabIndex = 110;
			this.tamount.Text = "1000";
			this.tamount.TextAlign = ContentAlignment.MiddleCenter;
			this.label2.AutoSize = true;
			this.label2.Font = new Font("SF Pro Text", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label2.Location = new Point(286, 61);
			this.label2.Name = "label2";
			this.label2.Size = new Size(33, 15);
			this.label2.TabIndex = 109;
			this.label2.Text = "with";
			this.label3.AutoSize = true;
			this.label3.Font = new Font("SF Pro Text", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label3.Location = new Point(13, 61);
			this.label3.Name = "label3";
			this.label3.Size = new Size(86, 15);
			this.label3.TabIndex = 108;
			this.label3.Text = "Spamming in";
			this.sLink.Font = new Font("SF Pro Text", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.sLink.Location = new Point(99, 58);
			this.sLink.Name = "sLink";
			this.sLink.Size = new Size(185, 23);
			this.sLink.TabIndex = 107;
			this.sLink.Text = "000000000000000000";
			this.sLink.TextAlign = ContentAlignment.MiddleCenter;
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Inter Black", 15.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(45, 16);
			this.label1.Name = "label1";
			this.label1.Size = new Size(72, 25);
			this.label1.TabIndex = 106;
			this.label1.Text = "Spam";
			this.siticoneButton3.BorderRadius = 18;
			this.siticoneButton3.CheckedState.Parent = this.siticoneButton3;
			this.siticoneButton3.Cursor = Cursors.Hand;
			this.siticoneButton3.CustomImages.Parent = this.siticoneButton3;
			this.siticoneButton3.FillColor = Color.DodgerBlue;
			this.siticoneButton3.FillColor2 = Color.DeepSkyBlue;
			this.siticoneButton3.Font = new Font("SF Pro Text", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.siticoneButton3.ForeColor = Color.White;
			this.siticoneButton3.HoveredState.Parent = this.siticoneButton3;
			this.siticoneButton3.Image = (Image)componentResourceManager.GetObject("siticoneButton3.Image");
			this.siticoneButton3.ImageAlign = HorizontalAlignment.Right;
			this.siticoneButton3.ImageOffset = new Point(6, -1);
			this.siticoneButton3.Location = new Point(337, 54);
			this.siticoneButton3.Name = "siticoneButton3";
			this.siticoneButton3.ShadowDecoration.Parent = this.siticoneButton3;
			this.siticoneButton3.Size = new Size(247, 38);
			this.siticoneButton3.TabIndex = 117;
			this.siticoneButton3.Text = "Perform Again";
			this.siticoneButton3.TextRenderingHint = TextRenderingHint.AntiAlias;
			this.siticoneButton3.Click += this.siticoneButton3_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.siticoneButton3);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.proxiesAm);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.tamount);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.sLink);
			base.Controls.Add(this.label1);
			base.Name = "AuditSpam";
			base.Size = new Size(591, 124);
			base.Load += this.AuditSpam_Load;
			((ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040000EA RID: 234
		private string a;

		// Token: 0x040000EB RID: 235
		private string b;

		// Token: 0x040000EC RID: 236
		private AuditLogForm __log;

		// Token: 0x040000ED RID: 237
		private IContainer components = null;

		// Token: 0x040000EE RID: 238
		private Label label7;

		// Token: 0x040000EF RID: 239
		private PictureBox pictureBox1;

		// Token: 0x040000F0 RID: 240
		private Label label6;

		// Token: 0x040000F1 RID: 241
		private Label proxiesAm;

		// Token: 0x040000F2 RID: 242
		private Label label4;

		// Token: 0x040000F3 RID: 243
		private Label tamount;

		// Token: 0x040000F4 RID: 244
		private Label label2;

		// Token: 0x040000F5 RID: 245
		private Label label3;

		// Token: 0x040000F6 RID: 246
		private Label sLink;

		// Token: 0x040000F7 RID: 247
		private Label label1;

		// Token: 0x040000F8 RID: 248
		private SiticoneGradientButton siticoneButton3;
	}
}
