namespace BlackSpammerXS
{
	// Token: 0x0200000C RID: 12
	public partial class AlertFM : global::System.Windows.Forms.Form
	{
		// Token: 0x06000045 RID: 69 RVA: 0x00004D30 File Offset: 0x00002F30
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00004D68 File Offset: 0x00002F68
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::BlackSpammerXS.AlertFM));
			this.siticoneElipse1 = new global::Siticone.UI.WinForms.SiticoneElipse(this.components);
			this.siticoneImageButton2 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneImageButton3 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneImageButton1 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneDragControl1 = new global::Siticone.UI.WinForms.SiticoneDragControl(this.components);
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.annullaBtn = new global::Siticone.UI.WinForms.SiticoneButton();
			this.siticoneButton1 = new global::Siticone.UI.WinForms.SiticoneButton();
			this.label2 = new global::System.Windows.Forms.Label();
			this.siticoneShadowForm1 = new global::Siticone.UI.WinForms.SiticoneShadowForm(this.components);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.siticoneElipse1.TargetControl = this;
			this.siticoneImageButton2.CheckedState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.Cursor = global::System.Windows.Forms.Cursors.Arrow;
			this.siticoneImageButton2.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image");
			this.siticoneImageButton2.HoveredState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton2.HoveredState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneImageButton2.Image");
			this.siticoneImageButton2.ImageRotate = 0f;
			this.siticoneImageButton2.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton2.IndicateFocus = false;
			this.siticoneImageButton2.Location = new global::System.Drawing.Point(29, 9);
			this.siticoneImageButton2.Name = "siticoneImageButton2";
			this.siticoneImageButton2.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton2.PressedState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.Size = new global::System.Drawing.Size(29, 29);
			this.siticoneImageButton2.TabIndex = 92;
			this.siticoneImageButton3.CheckedState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Cursor = global::System.Windows.Forms.Cursors.Arrow;
			this.siticoneImageButton3.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image1");
			this.siticoneImageButton3.HoveredState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.HoveredState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneImageButton3.Image");
			this.siticoneImageButton3.ImageRotate = 0f;
			this.siticoneImageButton3.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.IndicateFocus = false;
			this.siticoneImageButton3.Location = new global::System.Drawing.Point(50, 9);
			this.siticoneImageButton3.Name = "siticoneImageButton3";
			this.siticoneImageButton3.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.PressedState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Size = new global::System.Drawing.Size(29, 29);
			this.siticoneImageButton3.TabIndex = 91;
			this.siticoneImageButton1.CheckedState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneImageButton1.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image2");
			this.siticoneImageButton1.HoveredState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.HoveredState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneImageButton1.Image");
			this.siticoneImageButton1.ImageRotate = 0f;
			this.siticoneImageButton1.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.IndicateFocus = false;
			this.siticoneImageButton1.Location = new global::System.Drawing.Point(10, 9);
			this.siticoneImageButton1.Name = "siticoneImageButton1";
			this.siticoneImageButton1.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.PressedState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Size = new global::System.Drawing.Size(26, 29);
			this.siticoneImageButton1.TabIndex = 90;
			this.siticoneImageButton1.Click += new global::System.EventHandler(this.siticoneImageButton1_Click);
			this.siticoneDragControl1.TargetControl = this;
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(149, 68);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(48, 48);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 93;
			this.pictureBox1.TabStop = false;
			this.label1.Font = new global::System.Drawing.Font("SF Pro Text", 15.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(10, 125);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(328, 29);
			this.label1.TabIndex = 94;
			this.label1.Text = "Avviso";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label1.Click += new global::System.EventHandler(this.label1_Click);
			this.annullaBtn.BackColor = global::System.Drawing.Color.Transparent;
			this.annullaBtn.BorderColor = global::System.Drawing.Color.LightGray;
			this.annullaBtn.BorderRadius = 4;
			this.annullaBtn.BorderStyle = global::System.Drawing.Drawing2D.DashStyle.Dot;
			this.annullaBtn.BorderThickness = 1;
			this.annullaBtn.CheckedState.Parent = this.annullaBtn;
			this.annullaBtn.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.annullaBtn.CustomImages.Parent = this.annullaBtn;
			this.annullaBtn.FillColor = global::System.Drawing.Color.White;
			this.annullaBtn.Font = new global::System.Drawing.Font("SF Pro Text", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.annullaBtn.ForeColor = global::System.Drawing.Color.Black;
			this.annullaBtn.HoveredState.Parent = this.annullaBtn;
			this.annullaBtn.Location = new global::System.Drawing.Point(12, 277);
			this.annullaBtn.Name = "annullaBtn";
			this.annullaBtn.PressedColor = global::System.Drawing.Color.White;
			this.annullaBtn.ShadowDecoration.Parent = this.annullaBtn;
			this.annullaBtn.Size = new global::System.Drawing.Size(326, 29);
			this.annullaBtn.TabIndex = 95;
			this.annullaBtn.Text = "Annulla";
			this.annullaBtn.TextRenderingHint = global::System.Drawing.Text.TextRenderingHint.AntiAlias;
			this.annullaBtn.Click += new global::System.EventHandler(this.annullaBtn_Click);
			this.siticoneButton1.BackColor = global::System.Drawing.Color.Transparent;
			this.siticoneButton1.BorderColor = global::System.Drawing.Color.DodgerBlue;
			this.siticoneButton1.BorderRadius = 4;
			this.siticoneButton1.BorderStyle = global::System.Drawing.Drawing2D.DashStyle.Dot;
			this.siticoneButton1.BorderThickness = 1;
			this.siticoneButton1.CheckedState.Parent = this.siticoneButton1;
			this.siticoneButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneButton1.CustomImages.Parent = this.siticoneButton1;
			this.siticoneButton1.FillColor = global::System.Drawing.Color.DodgerBlue;
			this.siticoneButton1.Font = new global::System.Drawing.Font("SF Pro Text", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneButton1.ForeColor = global::System.Drawing.Color.White;
			this.siticoneButton1.HoveredState.Parent = this.siticoneButton1;
			this.siticoneButton1.Location = new global::System.Drawing.Point(13, 242);
			this.siticoneButton1.Name = "siticoneButton1";
			this.siticoneButton1.PressedColor = global::System.Drawing.Color.White;
			this.siticoneButton1.ShadowDecoration.Parent = this.siticoneButton1;
			this.siticoneButton1.Size = new global::System.Drawing.Size(326, 29);
			this.siticoneButton1.TabIndex = 96;
			this.siticoneButton1.Text = "OK";
			this.siticoneButton1.TextRenderingHint = global::System.Drawing.Text.TextRenderingHint.AntiAlias;
			this.siticoneButton1.Click += new global::System.EventHandler(this.siticoneButton1_Click);
			this.label2.Font = new global::System.Drawing.Font("SF Pro Text", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new global::System.Drawing.Point(13, 163);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(325, 63);
			this.label2.TabIndex = 97;
			this.label2.Text = "Questo è un avviso di BlackSpammer XS";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(351, 321);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.siticoneButton1);
			base.Controls.Add(this.annullaBtn);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.siticoneImageButton2);
			base.Controls.Add(this.siticoneImageButton3);
			base.Controls.Add(this.siticoneImageButton1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "AlertFM";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Avviso";
			base.Load += new global::System.EventHandler(this.AlertFM_Load);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000049 RID: 73
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400004A RID: 74
		private global::Siticone.UI.WinForms.SiticoneElipse siticoneElipse1;

		// Token: 0x0400004B RID: 75
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton2;

		// Token: 0x0400004C RID: 76
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton3;

		// Token: 0x0400004D RID: 77
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton1;

		// Token: 0x0400004E RID: 78
		private global::Siticone.UI.WinForms.SiticoneDragControl siticoneDragControl1;

		// Token: 0x0400004F RID: 79
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000050 RID: 80
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000051 RID: 81
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000052 RID: 82
		private global::Siticone.UI.WinForms.SiticoneButton siticoneButton1;

		// Token: 0x04000053 RID: 83
		private global::Siticone.UI.WinForms.SiticoneButton annullaBtn;

		// Token: 0x04000054 RID: 84
		private global::Siticone.UI.WinForms.SiticoneShadowForm siticoneShadowForm1;
	}
}
