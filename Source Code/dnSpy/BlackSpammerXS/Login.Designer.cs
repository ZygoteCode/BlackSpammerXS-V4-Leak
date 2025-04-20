namespace BlackSpammerXS
{
	// Token: 0x0200007D RID: 125
	public partial class Login : global::System.Windows.Forms.Form
	{
		// Token: 0x0600021E RID: 542 RVA: 0x00025E08 File Offset: 0x00024008
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00025E40 File Offset: 0x00024040
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::Siticone.UI.AnimatorNS.Animation animation = new global::Siticone.UI.AnimatorNS.Animation();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::BlackSpammerXS.Login));
			this.siticoneDragControl1 = new global::Siticone.UI.WinForms.SiticoneDragControl(this.components);
			this.label1 = new global::System.Windows.Forms.Label();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.passw = new global::Siticone.UI.WinForms.SiticoneTextBox();
			this.siticoneCustomCheckBox1 = new global::Siticone.UI.WinForms.SiticoneCustomCheckBox();
			this.usText = new global::Siticone.UI.WinForms.SiticoneTextBox();
			this.siticoneShadowForm1 = new global::Siticone.UI.WinForms.SiticoneShadowForm(this.components);
			this.siticoneDragControl2 = new global::Siticone.UI.WinForms.SiticoneDragControl(this.components);
			this.siticoneDragControl3 = new global::Siticone.UI.WinForms.SiticoneDragControl(this.components);
			this.siticoneDragControl4 = new global::Siticone.UI.WinForms.SiticoneDragControl(this.components);
			this.label2 = new global::System.Windows.Forms.Label();
			this.siticoneElipse1 = new global::Siticone.UI.WinForms.SiticoneElipse(this.components);
			this.siticoneGradientButton1 = new global::Siticone.UI.WinForms.SiticoneButton();
			this.siticoneImageButton1 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneImageButton2 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneImageButton3 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneTransition1 = new global::Siticone.UI.WinForms.SiticoneTransition();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.siticoneDragControl5 = new global::Siticone.UI.WinForms.SiticoneDragControl(this.components);
			this.label9 = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.siticoneDragControl1.TargetControl = this;
			this.label1.AutoSize = true;
			this.siticoneTransition1.SetDecoration(this.label1, 0);
			this.label1.Font = new global::System.Drawing.Font("Uni Sans Heavy CAPS", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(228, 74);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(150, 19);
			this.label1.TabIndex = 8;
			this.label1.Text = "BLACKSPAMMER XS";
			this.label1.Click += new global::System.EventHandler(this.label1_Click);
			this.siticoneTransition1.SetDecoration(this.pictureBox1, 0);
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(274, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(50, 50);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 7;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new global::System.EventHandler(this.pictureBox1_Click);
			this.label4.AutoSize = true;
			this.siticoneTransition1.SetDecoration(this.label4, 0);
			this.label4.Font = new global::System.Drawing.Font("SF Pro Text", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.Location = new global::System.Drawing.Point(39, 242);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(101, 15);
			this.label4.TabIndex = 56;
			this.label4.Text = "Remember Me";
			this.passw.Animated = false;
			this.passw.BackColor = global::System.Drawing.Color.Transparent;
			this.passw.BorderRadius = 4;
			this.passw.BorderThickness = 2;
			this.passw.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.siticoneTransition1.SetDecoration(this.passw, 0);
			this.passw.DefaultText = "";
			this.passw.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.passw.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.passw.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.passw.DisabledState.Parent = this.passw;
			this.passw.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.passw.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.passw.FocusedState.Parent = this.passw;
			this.passw.Font = new global::System.Drawing.Font("SF Pro Text", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.passw.ForeColor = global::System.Drawing.Color.Black;
			this.passw.HoveredState.BorderColor = global::System.Drawing.Color.FromArgb(213, 218, 223);
			this.passw.HoveredState.Parent = this.passw;
			this.passw.Location = new global::System.Drawing.Point(14, 180);
			this.passw.Margin = new global::System.Windows.Forms.Padding(4, 3, 4, 3);
			this.passw.Name = "passw";
			this.passw.PasswordChar = '\0';
			this.passw.PlaceholderText = "Password";
			this.passw.SelectedText = "";
			this.passw.ShadowDecoration.Parent = this.passw;
			this.passw.Size = new global::System.Drawing.Size(578, 35);
			this.passw.TabIndex = 54;
			this.passw.UseSystemPasswordChar = true;
			this.siticoneCustomCheckBox1.Checked = true;
			this.siticoneCustomCheckBox1.CheckedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.siticoneCustomCheckBox1.CheckedState.BorderRadius = 2;
			this.siticoneCustomCheckBox1.CheckedState.BorderThickness = 0;
			this.siticoneCustomCheckBox1.CheckedState.FillColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.siticoneCustomCheckBox1.CheckedState.Parent = this.siticoneCustomCheckBox1;
			this.siticoneCustomCheckBox1.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.siticoneCustomCheckBox1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneTransition1.SetDecoration(this.siticoneCustomCheckBox1, 0);
			this.siticoneCustomCheckBox1.Location = new global::System.Drawing.Point(18, 242);
			this.siticoneCustomCheckBox1.Name = "siticoneCustomCheckBox1";
			this.siticoneCustomCheckBox1.ShadowDecoration.Parent = this.siticoneCustomCheckBox1;
			this.siticoneCustomCheckBox1.Size = new global::System.Drawing.Size(15, 15);
			this.siticoneCustomCheckBox1.TabIndex = 57;
			this.siticoneCustomCheckBox1.UncheckedState.BorderColor = global::System.Drawing.Color.FromArgb(125, 137, 149);
			this.siticoneCustomCheckBox1.UncheckedState.BorderRadius = 2;
			this.siticoneCustomCheckBox1.UncheckedState.BorderThickness = 0;
			this.siticoneCustomCheckBox1.UncheckedState.FillColor = global::System.Drawing.Color.FromArgb(125, 137, 149);
			this.siticoneCustomCheckBox1.UncheckedState.Parent = this.siticoneCustomCheckBox1;
			this.siticoneCustomCheckBox1.CheckedChanged += new global::System.EventHandler(this.siticoneCustomCheckBox1_CheckedChanged);
			this.usText.Animated = false;
			this.usText.BackColor = global::System.Drawing.Color.Transparent;
			this.usText.BorderRadius = 4;
			this.usText.BorderThickness = 2;
			this.usText.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.siticoneTransition1.SetDecoration(this.usText, 0);
			this.usText.DefaultText = "";
			this.usText.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.usText.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.usText.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.usText.DisabledState.Parent = this.usText;
			this.usText.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.usText.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.usText.FocusedState.Parent = this.usText;
			this.usText.Font = new global::System.Drawing.Font("SF Pro Text", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.usText.ForeColor = global::System.Drawing.Color.Black;
			this.usText.HoveredState.BorderColor = global::System.Drawing.Color.FromArgb(213, 218, 223);
			this.usText.HoveredState.Parent = this.usText;
			this.usText.Location = new global::System.Drawing.Point(14, 140);
			this.usText.Margin = new global::System.Windows.Forms.Padding(4, 3, 4, 3);
			this.usText.Name = "usText";
			this.usText.PasswordChar = '\0';
			this.usText.PlaceholderText = "Username";
			this.usText.SelectedText = "";
			this.usText.ShadowDecoration.Parent = this.usText;
			this.usText.Size = new global::System.Drawing.Size(578, 34);
			this.usText.TabIndex = 58;
			this.usText.TextChanged += new global::System.EventHandler(this.usText_TextChanged);
			this.siticoneDragControl2.TargetControl = this.label1;
			this.siticoneDragControl3.TargetControl = null;
			this.siticoneDragControl4.TargetControl = this.pictureBox1;
			this.label2.AutoSize = true;
			this.siticoneTransition1.SetDecoration(this.label2, 0);
			this.label2.Font = new global::System.Drawing.Font("Inter Black", 9.749999f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.label2.Location = new global::System.Drawing.Point(248, 94);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(130, 16);
			this.label2.TabIndex = 59;
			this.label2.Text = "V4 DISCONTINUED";
			this.siticoneElipse1.TargetControl = this;
			this.siticoneGradientButton1.BackColor = global::System.Drawing.Color.Transparent;
			this.siticoneGradientButton1.BorderColor = global::System.Drawing.Color.LightGray;
			this.siticoneGradientButton1.BorderRadius = 4;
			this.siticoneGradientButton1.BorderStyle = global::System.Drawing.Drawing2D.DashStyle.Dot;
			this.siticoneGradientButton1.BorderThickness = 1;
			this.siticoneGradientButton1.CheckedState.CustomBorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.siticoneGradientButton1.CheckedState.Parent = this.siticoneGradientButton1;
			this.siticoneGradientButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneGradientButton1.CustomImages.Parent = this.siticoneGradientButton1;
			this.siticoneTransition1.SetDecoration(this.siticoneGradientButton1, 0);
			this.siticoneGradientButton1.FillColor = global::System.Drawing.Color.White;
			this.siticoneGradientButton1.Font = new global::System.Drawing.Font("SF Pro Text", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneGradientButton1.ForeColor = global::System.Drawing.Color.Black;
			this.siticoneGradientButton1.HoveredState.Parent = this.siticoneGradientButton1;
			this.siticoneGradientButton1.Location = new global::System.Drawing.Point(14, 284);
			this.siticoneGradientButton1.Name = "siticoneGradientButton1";
			this.siticoneGradientButton1.PressedColor = global::System.Drawing.Color.White;
			this.siticoneGradientButton1.ShadowDecoration.Parent = this.siticoneGradientButton1;
			this.siticoneGradientButton1.Size = new global::System.Drawing.Size(578, 33);
			this.siticoneGradientButton1.TabIndex = 55;
			this.siticoneGradientButton1.Text = "Login";
			this.siticoneGradientButton1.TextRenderingHint = global::System.Drawing.Text.TextRenderingHint.SystemDefault;
			this.siticoneGradientButton1.Click += new global::System.EventHandler(this.siticoneButton3_Click);
			this.siticoneGradientButton1.MouseEnter += new global::System.EventHandler(this.siticoneButton3_MouseEnter);
			this.siticoneGradientButton1.MouseLeave += new global::System.EventHandler(this.siticoneButton3_MouseLeave);
			this.siticoneImageButton1.CheckedState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneTransition1.SetDecoration(this.siticoneImageButton1, 0);
			this.siticoneImageButton1.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image2");
			this.siticoneImageButton1.HoveredState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.HoveredState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneImageButton1.Image");
			this.siticoneImageButton1.ImageRotate = 0f;
			this.siticoneImageButton1.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.IndicateFocus = false;
			this.siticoneImageButton1.Location = new global::System.Drawing.Point(7, 3);
			this.siticoneImageButton1.Name = "siticoneImageButton1";
			this.siticoneImageButton1.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.PressedState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Size = new global::System.Drawing.Size(26, 29);
			this.siticoneImageButton1.TabIndex = 74;
			this.siticoneImageButton1.Click += new global::System.EventHandler(this.siticoneImageButton1_Click);
			this.siticoneImageButton2.CheckedState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneTransition1.SetDecoration(this.siticoneImageButton2, 0);
			this.siticoneImageButton2.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image1");
			this.siticoneImageButton2.HoveredState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton2.HoveredState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneImageButton2.Image");
			this.siticoneImageButton2.ImageRotate = 0f;
			this.siticoneImageButton2.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton2.IndicateFocus = false;
			this.siticoneImageButton2.Location = new global::System.Drawing.Point(26, 3);
			this.siticoneImageButton2.Name = "siticoneImageButton2";
			this.siticoneImageButton2.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton2.PressedState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.Size = new global::System.Drawing.Size(29, 29);
			this.siticoneImageButton2.TabIndex = 75;
			this.siticoneImageButton2.Click += new global::System.EventHandler(this.siticoneImageButton2_Click);
			this.siticoneImageButton3.CheckedState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Cursor = global::System.Windows.Forms.Cursors.Arrow;
			this.siticoneTransition1.SetDecoration(this.siticoneImageButton3, 0);
			this.siticoneImageButton3.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image");
			this.siticoneImageButton3.HoveredState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.HoveredState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneImageButton3.Image");
			this.siticoneImageButton3.ImageRotate = 0f;
			this.siticoneImageButton3.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.IndicateFocus = false;
			this.siticoneImageButton3.Location = new global::System.Drawing.Point(47, 3);
			this.siticoneImageButton3.Name = "siticoneImageButton3";
			this.siticoneImageButton3.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.PressedState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Size = new global::System.Drawing.Size(29, 29);
			this.siticoneImageButton3.TabIndex = 76;
			this.siticoneImageButton3.Click += new global::System.EventHandler(this.siticoneImageButton3_Click);
			this.siticoneTransition1.AnimationType = 8;
			this.siticoneTransition1.Cursor = null;
			animation.AnimateOnlyDifferences = true;
			animation.BlindCoeff = (global::System.Drawing.PointF)componentResourceManager.GetObject("animation3.BlindCoeff");
			animation.LeafCoeff = 0f;
			animation.MaxTime = 1f;
			animation.MinTime = 0f;
			animation.MosaicCoeff = (global::System.Drawing.PointF)componentResourceManager.GetObject("animation3.MosaicCoeff");
			animation.MosaicShift = (global::System.Drawing.PointF)componentResourceManager.GetObject("animation3.MosaicShift");
			animation.MosaicSize = 0;
			animation.Padding = new global::System.Windows.Forms.Padding(0);
			animation.RotateCoeff = 0f;
			animation.RotateLimit = 0f;
			animation.ScaleCoeff = (global::System.Drawing.PointF)componentResourceManager.GetObject("animation3.ScaleCoeff");
			animation.SlideCoeff = (global::System.Drawing.PointF)componentResourceManager.GetObject("animation3.SlideCoeff");
			animation.TimeCoeff = 0f;
			animation.TransparencyCoeff = 1f;
			this.siticoneTransition1.DefaultAnimation = animation;
			this.siticoneTransition1.Interval = 1;
			this.siticoneTransition1.MaxAnimationTime = 1000;
			this.panel1.Controls.Add(this.siticoneGradientButton1);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.passw);
			this.panel1.Controls.Add(this.siticoneCustomCheckBox1);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.usText);
			this.siticoneTransition1.SetDecoration(this.panel1, 0);
			this.panel1.Location = new global::System.Drawing.Point(2, 30);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(615, 330);
			this.panel1.TabIndex = 77;
			this.panel1.Visible = false;
			this.panel1.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			this.siticoneDragControl5.TargetControl = this.panel1;
			this.label9.AutoSize = true;
			this.siticoneTransition1.SetDecoration(this.label9, 0);
			this.label9.Font = new global::System.Drawing.Font("SF Pro Text", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label9.Location = new global::System.Drawing.Point(502, 10);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(104, 14);
			this.label9.TabIndex = 60;
			this.label9.Text = "Developer Mode";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(617, 363);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.siticoneImageButton3);
			base.Controls.Add(this.siticoneImageButton2);
			base.Controls.Add(this.siticoneImageButton1);
			this.siticoneTransition1.SetDecoration(this, 0);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "Login";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login";
			base.Load += new global::System.EventHandler(this.Login_Load);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000489 RID: 1161
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400048A RID: 1162
		private global::Siticone.UI.WinForms.SiticoneDragControl siticoneDragControl1;

		// Token: 0x0400048B RID: 1163
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400048C RID: 1164
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x0400048D RID: 1165
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400048E RID: 1166
		private global::Siticone.UI.WinForms.SiticoneTextBox passw;

		// Token: 0x0400048F RID: 1167
		private global::Siticone.UI.WinForms.SiticoneTextBox usText;

		// Token: 0x04000490 RID: 1168
		private global::Siticone.UI.WinForms.SiticoneCustomCheckBox siticoneCustomCheckBox1;

		// Token: 0x04000491 RID: 1169
		private global::Siticone.UI.WinForms.SiticoneShadowForm siticoneShadowForm1;

		// Token: 0x04000492 RID: 1170
		private global::Siticone.UI.WinForms.SiticoneDragControl siticoneDragControl2;

		// Token: 0x04000493 RID: 1171
		private global::Siticone.UI.WinForms.SiticoneDragControl siticoneDragControl3;

		// Token: 0x04000494 RID: 1172
		private global::Siticone.UI.WinForms.SiticoneDragControl siticoneDragControl4;

		// Token: 0x04000495 RID: 1173
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000496 RID: 1174
		private global::Siticone.UI.WinForms.SiticoneElipse siticoneElipse1;

		// Token: 0x04000497 RID: 1175
		private global::Siticone.UI.WinForms.SiticoneButton siticoneGradientButton1;

		// Token: 0x04000498 RID: 1176
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton1;

		// Token: 0x04000499 RID: 1177
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton2;

		// Token: 0x0400049A RID: 1178
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton3;

		// Token: 0x0400049B RID: 1179
		private global::Siticone.UI.WinForms.SiticoneTransition siticoneTransition1;

		// Token: 0x0400049C RID: 1180
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400049D RID: 1181
		private global::Siticone.UI.WinForms.SiticoneDragControl siticoneDragControl5;

		// Token: 0x0400049E RID: 1182
		private global::System.Windows.Forms.Label label9;
	}
}
