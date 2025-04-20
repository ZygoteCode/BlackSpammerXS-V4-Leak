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
	// Token: 0x0200000E RID: 14
	public class AuditJoin : UserControl
	{
		// Token: 0x0600004D RID: 77 RVA: 0x00005840 File Offset: 0x00003A40
		public AuditJoin(string serverLink, string tokens, string proxies, string timeStamp, bool dark, AuditLogForm logForm)
		{
			this.InitializeComponent();
			this.sLink.Text = serverLink;
			this.tamount.Text = tokens;
			this.proxiesAm.Text = proxies;
			this.__log = logForm;
			if (dark)
			{
				List<Label> list = new List<Label> { this.sLink, this.label1, this.label2, this.label3, this.tamount, this.proxiesAm, this.label4, this.label6, this.label7 };
				foreach (Label label in list)
				{
					label.ForeColor = Color.White;
				}
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002067 File Offset: 0x00000267
		private void AuditJoin_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00005964 File Offset: 0x00003B64
		private async void siticoneGradientButton3_Click(object sender, EventArgs e)
		{
			await Task.Delay(50);
			object[] _objarr = new object[2];
			_objarr[0] = this.sLink.Text;
			ImpostazioniGlobali.CallbackBridgeAL(0, 0, _objarr);
			ImpostazioniGlobali.bridgeAct_(0);
			ImpostazioniGlobali.CallbackBridgeAL(1153, 1, null);
			this.__log.Close();
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000059AB File Offset: 0x00003BAB
		private void siticoneButton3_Click(object sender, EventArgs e)
		{
			this.siticoneGradientButton3_Click(sender, e);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000059B8 File Offset: 0x00003BB8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x000059F0 File Offset: 0x00003BF0
		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AuditJoin));
			this.label1 = new Label();
			this.sLink = new Label();
			this.label3 = new Label();
			this.label2 = new Label();
			this.tamount = new Label();
			this.label4 = new Label();
			this.proxiesAm = new Label();
			this.label6 = new Label();
			this.pictureBox1 = new PictureBox();
			this.label7 = new Label();
			this.siticoneButton3 = new SiticoneGradientButton();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Inter Black", 15.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(47, 11);
			this.label1.Name = "label1";
			this.label1.Size = new Size(57, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "Join";
			this.sLink.Font = new Font("SF Pro Text", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.sLink.Location = new Point(80, 53);
			this.sLink.Name = "sLink";
			this.sLink.Size = new Size(108, 23);
			this.sLink.TabIndex = 1;
			this.sLink.Text = "Server Link";
			this.sLink.TextAlign = ContentAlignment.MiddleCenter;
			this.label3.AutoSize = true;
			this.label3.Font = new Font("SF Pro Text", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label3.Location = new Point(15, 57);
			this.label3.Name = "label3";
			this.label3.Size = new Size(63, 15);
			this.label3.TabIndex = 2;
			this.label3.Text = "Joined in";
			this.label2.AutoSize = true;
			this.label2.Font = new Font("SF Pro Text", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label2.Location = new Point(190, 57);
			this.label2.Name = "label2";
			this.label2.Size = new Size(33, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "with";
			this.tamount.Font = new Font("SF Pro Text", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.tamount.Location = new Point(229, 53);
			this.tamount.Name = "tamount";
			this.tamount.Size = new Size(52, 23);
			this.tamount.TabIndex = 4;
			this.tamount.Text = "1000";
			this.tamount.TextAlign = ContentAlignment.MiddleCenter;
			this.label4.AutoSize = true;
			this.label4.Font = new Font("SF Pro Text", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label4.Location = new Point(285, 57);
			this.label4.Name = "label4";
			this.label4.Size = new Size(49, 15);
			this.label4.TabIndex = 5;
			this.label4.Text = "tokens";
			this.proxiesAm.Font = new Font("SF Pro Text", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.proxiesAm.Location = new Point(54, 81);
			this.proxiesAm.Name = "proxiesAm";
			this.proxiesAm.Size = new Size(52, 23);
			this.proxiesAm.TabIndex = 6;
			this.proxiesAm.Text = "1000";
			this.proxiesAm.TextAlign = ContentAlignment.MiddleCenter;
			this.label6.AutoSize = true;
			this.label6.Font = new Font("SF Pro Text", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label6.Location = new Point(110, 85);
			this.label6.Name = "label6";
			this.label6.Size = new Size(56, 15);
			this.label6.TabIndex = 7;
			this.label6.Text = "proxies.";
			this.pictureBox1.Image = (Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new Point(17, 11);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(24, 24);
			this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 8;
			this.pictureBox1.TabStop = false;
			this.label7.AutoSize = true;
			this.label7.Font = new Font("SF Pro Text", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label7.Location = new Point(20, 85);
			this.label7.Name = "label7";
			this.label7.Size = new Size(30, 15);
			this.label7.TabIndex = 9;
			this.label7.Text = "and";
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
			this.siticoneButton3.Location = new Point(341, 53);
			this.siticoneButton3.Name = "siticoneButton3";
			this.siticoneButton3.ShadowDecoration.Parent = this.siticoneButton3;
			this.siticoneButton3.Size = new Size(247, 38);
			this.siticoneButton3.TabIndex = 118;
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
			base.Name = "AuditJoin";
			base.Size = new Size(591, 124);
			base.Load += this.AuditJoin_Load;
			((ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400005A RID: 90
		private AuditLogForm __log;

		// Token: 0x0400005B RID: 91
		private IContainer components = null;

		// Token: 0x0400005C RID: 92
		private Label label1;

		// Token: 0x0400005D RID: 93
		private Label sLink;

		// Token: 0x0400005E RID: 94
		private Label label3;

		// Token: 0x0400005F RID: 95
		private Label label2;

		// Token: 0x04000060 RID: 96
		private Label tamount;

		// Token: 0x04000061 RID: 97
		private Label label4;

		// Token: 0x04000062 RID: 98
		private Label proxiesAm;

		// Token: 0x04000063 RID: 99
		private Label label6;

		// Token: 0x04000064 RID: 100
		private PictureBox pictureBox1;

		// Token: 0x04000065 RID: 101
		private Label label7;

		// Token: 0x04000066 RID: 102
		private SiticoneGradientButton siticoneButton3;
	}
}
