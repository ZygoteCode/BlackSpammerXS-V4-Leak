namespace BlackSpammerXS
{
	// Token: 0x02000032 RID: 50
	public partial class ChcapKM : global::System.Windows.Forms.Form
	{
		// Token: 0x060000D8 RID: 216 RVA: 0x0000E3AC File Offset: 0x0000C5AC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000E3E4 File Offset: 0x0000C5E4
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::BlackSpammerXS.ChcapKM));
			this.siticoneShadowForm1 = new global::Siticone.UI.WinForms.SiticoneShadowForm(this.components);
			this.siticoneAnimateWindow1 = new global::Siticone.UI.WinForms.SiticoneAnimateWindow(this.components);
			this.label1 = new global::System.Windows.Forms.Label();
			this.usText = new global::Siticone.UI.WinForms.SiticoneTextBox();
			this.siticoneButton6 = new global::Siticone.UI.WinForms.SiticoneButton();
			this.hastwocap = new global::Siticone.UI.WinForms.SiticoneToggleSwitch();
			this.label2 = new global::System.Windows.Forms.Label();
			this.hascapmon = new global::Siticone.UI.WinForms.SiticoneToggleSwitch();
			this.del = new global::System.Windows.Forms.Label();
			this.siticoneElipse1 = new global::Siticone.UI.WinForms.SiticoneElipse(this.components);
			this.siticoneImageButton2 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneImageButton3 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneImageButton1 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			base.SuspendLayout();
			this.siticoneAnimateWindow1.AnimationType = 262144;
			this.siticoneAnimateWindow1.Interval = 300;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("SF Pro Text", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(152, 14);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(104, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "Captcha Key";
			this.usText.Animated = false;
			this.usText.BackColor = global::System.Drawing.Color.Transparent;
			this.usText.BorderRadius = 4;
			this.usText.BorderThickness = 2;
			this.usText.Cursor = global::System.Windows.Forms.Cursors.IBeam;
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
			this.usText.Location = new global::System.Drawing.Point(12, 68);
			this.usText.Margin = new global::System.Windows.Forms.Padding(4, 3, 4, 3);
			this.usText.Name = "usText";
			this.usText.PasswordChar = '\0';
			this.usText.PlaceholderText = "Captcha Key";
			this.usText.SelectedText = "";
			this.usText.ShadowDecoration.Parent = this.usText;
			this.usText.Size = new global::System.Drawing.Size(395, 40);
			this.usText.TabIndex = 59;
			this.siticoneButton6.BackColor = global::System.Drawing.Color.Transparent;
			this.siticoneButton6.BorderColor = global::System.Drawing.Color.LightGray;
			this.siticoneButton6.BorderRadius = 4;
			this.siticoneButton6.BorderStyle = global::System.Drawing.Drawing2D.DashStyle.Dot;
			this.siticoneButton6.BorderThickness = 1;
			this.siticoneButton6.CheckedState.Parent = this.siticoneButton6;
			this.siticoneButton6.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneButton6.CustomImages.Parent = this.siticoneButton6;
			this.siticoneButton6.FillColor = global::System.Drawing.Color.White;
			this.siticoneButton6.Font = new global::System.Drawing.Font("SF Pro Text", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneButton6.ForeColor = global::System.Drawing.Color.Black;
			this.siticoneButton6.HoveredState.Parent = this.siticoneButton6;
			this.siticoneButton6.Location = new global::System.Drawing.Point(12, 221);
			this.siticoneButton6.Name = "siticoneButton6";
			this.siticoneButton6.PressedColor = global::System.Drawing.Color.White;
			this.siticoneButton6.ShadowDecoration.Parent = this.siticoneButton6;
			this.siticoneButton6.Size = new global::System.Drawing.Size(395, 43);
			this.siticoneButton6.TabIndex = 60;
			this.siticoneButton6.Text = "Save";
			this.siticoneButton6.TextRenderingHint = global::System.Drawing.Text.TextRenderingHint.AntiAlias;
			this.siticoneButton6.Click += new global::System.EventHandler(this.siticoneButton6_Click);
			this.hastwocap.Checked = true;
			this.hastwocap.CheckedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.hastwocap.CheckedState.FillColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.hastwocap.CheckedState.InnerBorderColor = global::System.Drawing.Color.White;
			this.hastwocap.CheckedState.InnerColor = global::System.Drawing.Color.White;
			this.hastwocap.CheckedState.Parent = this.hastwocap;
			this.hastwocap.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.hastwocap.Location = new global::System.Drawing.Point(15, 162);
			this.hastwocap.Name = "hastwocap";
			this.hastwocap.ShadowDecoration.Parent = this.hastwocap;
			this.hastwocap.Size = new global::System.Drawing.Size(32, 20);
			this.hastwocap.TabIndex = 64;
			this.hastwocap.UncheckedState.BorderColor = global::System.Drawing.Color.FromArgb(125, 137, 149);
			this.hastwocap.UncheckedState.FillColor = global::System.Drawing.Color.FromArgb(125, 137, 149);
			this.hastwocap.UncheckedState.InnerBorderColor = global::System.Drawing.Color.White;
			this.hastwocap.UncheckedState.InnerColor = global::System.Drawing.Color.White;
			this.hastwocap.UncheckedState.Parent = this.hastwocap;
			this.hastwocap.CheckedChanged += new global::System.EventHandler(this.hastwocap_CheckedChanged);
			this.hastwocap.Click += new global::System.EventHandler(this.tdel_Click);
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("SF Pro Text", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new global::System.Drawing.Point(50, 165);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(66, 14);
			this.label2.TabIndex = 63;
			this.label2.Text = "2Captcha";
			this.hascapmon.CheckedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.hascapmon.CheckedState.FillColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.hascapmon.CheckedState.InnerBorderColor = global::System.Drawing.Color.White;
			this.hascapmon.CheckedState.InnerColor = global::System.Drawing.Color.White;
			this.hascapmon.CheckedState.Parent = this.hascapmon;
			this.hascapmon.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.hascapmon.Enabled = false;
			this.hascapmon.Location = new global::System.Drawing.Point(15, 135);
			this.hascapmon.Name = "hascapmon";
			this.hascapmon.ShadowDecoration.Parent = this.hascapmon;
			this.hascapmon.Size = new global::System.Drawing.Size(32, 20);
			this.hascapmon.TabIndex = 62;
			this.hascapmon.UncheckedState.BorderColor = global::System.Drawing.Color.FromArgb(125, 137, 149);
			this.hascapmon.UncheckedState.FillColor = global::System.Drawing.Color.FromArgb(125, 137, 149);
			this.hascapmon.UncheckedState.InnerBorderColor = global::System.Drawing.Color.White;
			this.hascapmon.UncheckedState.InnerColor = global::System.Drawing.Color.White;
			this.hascapmon.UncheckedState.Parent = this.hascapmon;
			this.hascapmon.Click += new global::System.EventHandler(this.hasDelay_Click);
			this.del.AutoSize = true;
			this.del.Font = new global::System.Drawing.Font("SF Pro Text", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.del.Location = new global::System.Drawing.Point(50, 139);
			this.del.Name = "del";
			this.del.Size = new global::System.Drawing.Size(83, 14);
			this.del.TabIndex = 61;
			this.del.Text = "SmsActivate";
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
			this.siticoneImageButton2.Location = new global::System.Drawing.Point(30, 6);
			this.siticoneImageButton2.Name = "siticoneImageButton2";
			this.siticoneImageButton2.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton2.PressedState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.Size = new global::System.Drawing.Size(29, 29);
			this.siticoneImageButton2.TabIndex = 86;
			this.siticoneImageButton3.CheckedState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Cursor = global::System.Windows.Forms.Cursors.Arrow;
			this.siticoneImageButton3.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image1");
			this.siticoneImageButton3.HoveredState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.HoveredState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneImageButton3.Image");
			this.siticoneImageButton3.ImageRotate = 0f;
			this.siticoneImageButton3.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.IndicateFocus = false;
			this.siticoneImageButton3.Location = new global::System.Drawing.Point(51, 6);
			this.siticoneImageButton3.Name = "siticoneImageButton3";
			this.siticoneImageButton3.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.PressedState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Size = new global::System.Drawing.Size(29, 29);
			this.siticoneImageButton3.TabIndex = 85;
			this.siticoneImageButton1.CheckedState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneImageButton1.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image2");
			this.siticoneImageButton1.HoveredState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.HoveredState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneImageButton1.Image");
			this.siticoneImageButton1.ImageRotate = 0f;
			this.siticoneImageButton1.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.IndicateFocus = false;
			this.siticoneImageButton1.Location = new global::System.Drawing.Point(11, 6);
			this.siticoneImageButton1.Name = "siticoneImageButton1";
			this.siticoneImageButton1.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.PressedState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Size = new global::System.Drawing.Size(26, 29);
			this.siticoneImageButton1.TabIndex = 84;
			this.siticoneImageButton1.Click += new global::System.EventHandler(this.siticoneImageButton1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(419, 276);
			base.Controls.Add(this.siticoneImageButton2);
			base.Controls.Add(this.siticoneImageButton3);
			base.Controls.Add(this.siticoneImageButton1);
			base.Controls.Add(this.hastwocap);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.hascapmon);
			base.Controls.Add(this.del);
			base.Controls.Add(this.siticoneButton6);
			base.Controls.Add(this.usText);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "ChcapKM";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ChcapKM";
			base.Load += new global::System.EventHandler(this.ChcapKM_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400019F RID: 415
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040001A0 RID: 416
		private global::Siticone.UI.WinForms.SiticoneShadowForm siticoneShadowForm1;

		// Token: 0x040001A1 RID: 417
		private global::Siticone.UI.WinForms.SiticoneAnimateWindow siticoneAnimateWindow1;

		// Token: 0x040001A2 RID: 418
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040001A3 RID: 419
		private global::Siticone.UI.WinForms.SiticoneTextBox usText;

		// Token: 0x040001A4 RID: 420
		private global::Siticone.UI.WinForms.SiticoneButton siticoneButton6;

		// Token: 0x040001A5 RID: 421
		private global::Siticone.UI.WinForms.SiticoneToggleSwitch hastwocap;

		// Token: 0x040001A6 RID: 422
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040001A7 RID: 423
		private global::Siticone.UI.WinForms.SiticoneToggleSwitch hascapmon;

		// Token: 0x040001A8 RID: 424
		private global::System.Windows.Forms.Label del;

		// Token: 0x040001A9 RID: 425
		private global::Siticone.UI.WinForms.SiticoneElipse siticoneElipse1;

		// Token: 0x040001AA RID: 426
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton2;

		// Token: 0x040001AB RID: 427
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton3;

		// Token: 0x040001AC RID: 428
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton1;
	}
}
