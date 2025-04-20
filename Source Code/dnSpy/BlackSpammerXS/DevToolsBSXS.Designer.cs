namespace BlackSpammerXS
{
	// Token: 0x02000051 RID: 81
	public partial class DevToolsBSXS : global::System.Windows.Forms.Form
	{
		// Token: 0x06000158 RID: 344 RVA: 0x00014EA8 File Offset: 0x000130A8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00014EE0 File Offset: 0x000130E0
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::BlackSpammerXS.DevToolsBSXS));
			this.siticoneElipse1 = new global::Siticone.UI.WinForms.SiticoneElipse(this.components);
			this.label1 = new global::System.Windows.Forms.Label();
			this.siticoneImageButton2 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneImageButton3 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneImageButton1 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.usText = new global::Siticone.UI.WinForms.SiticoneTextBox();
			this.siticoneGradientButton1 = new global::Siticone.UI.WinForms.SiticoneButton();
			this.siticoneButton1 = new global::Siticone.UI.WinForms.SiticoneButton();
			this.siticoneButton2 = new global::Siticone.UI.WinForms.SiticoneButton();
			this.label5 = new global::System.Windows.Forms.Label();
			this.siticoneButton3 = new global::Siticone.UI.WinForms.SiticoneButton();
			base.SuspendLayout();
			this.siticoneElipse1.TargetControl = this;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("SF Pro Text", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(168, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(128, 18);
			this.label1.TabIndex = 66;
			this.label1.Text = "Developer Tools";
			this.siticoneImageButton2.CheckedState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.Cursor = global::System.Windows.Forms.Cursors.Arrow;
			this.siticoneImageButton2.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image");
			this.siticoneImageButton2.HoveredState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton2.HoveredState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneImageButton2.Image");
			this.siticoneImageButton2.ImageRotate = 0f;
			this.siticoneImageButton2.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton2.IndicateFocus = false;
			this.siticoneImageButton2.Location = new global::System.Drawing.Point(29, 5);
			this.siticoneImageButton2.Name = "siticoneImageButton2";
			this.siticoneImageButton2.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton2.PressedState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.Size = new global::System.Drawing.Size(29, 29);
			this.siticoneImageButton2.TabIndex = 105;
			this.siticoneImageButton3.CheckedState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Cursor = global::System.Windows.Forms.Cursors.Arrow;
			this.siticoneImageButton3.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image1");
			this.siticoneImageButton3.HoveredState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.HoveredState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneImageButton3.Image");
			this.siticoneImageButton3.ImageRotate = 0f;
			this.siticoneImageButton3.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.IndicateFocus = false;
			this.siticoneImageButton3.Location = new global::System.Drawing.Point(50, 5);
			this.siticoneImageButton3.Name = "siticoneImageButton3";
			this.siticoneImageButton3.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.PressedState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Size = new global::System.Drawing.Size(29, 29);
			this.siticoneImageButton3.TabIndex = 104;
			this.siticoneImageButton1.CheckedState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneImageButton1.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image2");
			this.siticoneImageButton1.HoveredState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.HoveredState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneImageButton1.Image");
			this.siticoneImageButton1.ImageRotate = 0f;
			this.siticoneImageButton1.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.IndicateFocus = false;
			this.siticoneImageButton1.Location = new global::System.Drawing.Point(10, 5);
			this.siticoneImageButton1.Name = "siticoneImageButton1";
			this.siticoneImageButton1.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.PressedState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Size = new global::System.Drawing.Size(26, 29);
			this.siticoneImageButton1.TabIndex = 103;
			this.siticoneImageButton1.Click += new global::System.EventHandler(this.siticoneImageButton1_Click);
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
			this.usText.Location = new global::System.Drawing.Point(10, 137);
			this.usText.Margin = new global::System.Windows.Forms.Padding(4, 3, 4, 3);
			this.usText.Name = "usText";
			this.usText.PasswordChar = '\0';
			this.usText.PlaceholderText = "Test Token";
			this.usText.SelectedText = "";
			this.usText.ShadowDecoration.Parent = this.usText;
			this.usText.Size = new global::System.Drawing.Size(464, 40);
			this.usText.TabIndex = 110;
			this.siticoneGradientButton1.BackColor = global::System.Drawing.Color.Transparent;
			this.siticoneGradientButton1.BorderColor = global::System.Drawing.Color.LightGray;
			this.siticoneGradientButton1.BorderRadius = 4;
			this.siticoneGradientButton1.BorderStyle = global::System.Drawing.Drawing2D.DashStyle.Dot;
			this.siticoneGradientButton1.BorderThickness = 1;
			this.siticoneGradientButton1.CheckedState.CustomBorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.siticoneGradientButton1.CheckedState.Parent = this.siticoneGradientButton1;
			this.siticoneGradientButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneGradientButton1.CustomImages.Parent = this.siticoneGradientButton1;
			this.siticoneGradientButton1.FillColor = global::System.Drawing.Color.White;
			this.siticoneGradientButton1.Font = new global::System.Drawing.Font("SF Pro Text", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneGradientButton1.ForeColor = global::System.Drawing.Color.Black;
			this.siticoneGradientButton1.HoveredState.Parent = this.siticoneGradientButton1;
			this.siticoneGradientButton1.Location = new global::System.Drawing.Point(10, 184);
			this.siticoneGradientButton1.Name = "siticoneGradientButton1";
			this.siticoneGradientButton1.PressedColor = global::System.Drawing.Color.White;
			this.siticoneGradientButton1.ShadowDecoration.Parent = this.siticoneGradientButton1;
			this.siticoneGradientButton1.Size = new global::System.Drawing.Size(464, 33);
			this.siticoneGradientButton1.TabIndex = 111;
			this.siticoneGradientButton1.Text = "Set Test Token";
			this.siticoneGradientButton1.TextRenderingHint = global::System.Drawing.Text.TextRenderingHint.AntiAlias;
			this.siticoneGradientButton1.Click += new global::System.EventHandler(this.siticoneGradientButton1_Click);
			this.siticoneButton1.BackColor = global::System.Drawing.Color.Transparent;
			this.siticoneButton1.BorderColor = global::System.Drawing.Color.LightGray;
			this.siticoneButton1.BorderRadius = 4;
			this.siticoneButton1.BorderStyle = global::System.Drawing.Drawing2D.DashStyle.Dot;
			this.siticoneButton1.BorderThickness = 1;
			this.siticoneButton1.CheckedState.CustomBorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.siticoneButton1.CheckedState.Parent = this.siticoneButton1;
			this.siticoneButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneButton1.CustomImages.Parent = this.siticoneButton1;
			this.siticoneButton1.FillColor = global::System.Drawing.Color.White;
			this.siticoneButton1.Font = new global::System.Drawing.Font("SF Pro Text", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneButton1.ForeColor = global::System.Drawing.Color.Black;
			this.siticoneButton1.HoveredState.Parent = this.siticoneButton1;
			this.siticoneButton1.Location = new global::System.Drawing.Point(10, 296);
			this.siticoneButton1.Name = "siticoneButton1";
			this.siticoneButton1.PressedColor = global::System.Drawing.Color.White;
			this.siticoneButton1.ShadowDecoration.Parent = this.siticoneButton1;
			this.siticoneButton1.Size = new global::System.Drawing.Size(465, 33);
			this.siticoneButton1.TabIndex = 112;
			this.siticoneButton1.Text = "WS Testing Tools";
			this.siticoneButton1.TextRenderingHint = global::System.Drawing.Text.TextRenderingHint.AntiAlias;
			this.siticoneButton1.Click += new global::System.EventHandler(this.siticoneButton1_Click);
			this.siticoneButton2.BackColor = global::System.Drawing.Color.Transparent;
			this.siticoneButton2.BorderColor = global::System.Drawing.Color.LightGray;
			this.siticoneButton2.BorderRadius = 4;
			this.siticoneButton2.BorderStyle = global::System.Drawing.Drawing2D.DashStyle.Dot;
			this.siticoneButton2.BorderThickness = 1;
			this.siticoneButton2.CheckedState.CustomBorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.siticoneButton2.CheckedState.Parent = this.siticoneButton2;
			this.siticoneButton2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneButton2.CustomImages.Parent = this.siticoneButton2;
			this.siticoneButton2.FillColor = global::System.Drawing.Color.White;
			this.siticoneButton2.Font = new global::System.Drawing.Font("SF Pro Text", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneButton2.ForeColor = global::System.Drawing.Color.Black;
			this.siticoneButton2.HoveredState.Parent = this.siticoneButton2;
			this.siticoneButton2.Location = new global::System.Drawing.Point(9, 258);
			this.siticoneButton2.Name = "siticoneButton2";
			this.siticoneButton2.PressedColor = global::System.Drawing.Color.White;
			this.siticoneButton2.ShadowDecoration.Parent = this.siticoneButton2;
			this.siticoneButton2.Size = new global::System.Drawing.Size(465, 33);
			this.siticoneButton2.TabIndex = 113;
			this.siticoneButton2.Text = "Server Status";
			this.siticoneButton2.TextRenderingHint = global::System.Drawing.Text.TextRenderingHint.AntiAlias;
			this.siticoneButton2.Click += new global::System.EventHandler(this.siticoneButton2_Click);
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("JetBrains Mono", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.Location = new global::System.Drawing.Point(12, 44);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(152, 85);
			this.label5.TabIndex = 114;
			this.label5.Text = "BlackSpammer XS V4\r\nDebug Length: 0\r\nXCP Length: 0\r\nAudit Length: 0\r\nLog CL Interval: 0";
			this.label5.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label5.Click += new global::System.EventHandler(this.label5_Click);
			this.siticoneButton3.BackColor = global::System.Drawing.Color.Transparent;
			this.siticoneButton3.BorderColor = global::System.Drawing.Color.LightGray;
			this.siticoneButton3.BorderRadius = 4;
			this.siticoneButton3.BorderStyle = global::System.Drawing.Drawing2D.DashStyle.Dot;
			this.siticoneButton3.BorderThickness = 1;
			this.siticoneButton3.CheckedState.CustomBorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.siticoneButton3.CheckedState.Parent = this.siticoneButton3;
			this.siticoneButton3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneButton3.CustomImages.Parent = this.siticoneButton3;
			this.siticoneButton3.FillColor = global::System.Drawing.Color.White;
			this.siticoneButton3.Font = new global::System.Drawing.Font("SF Pro Text", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneButton3.ForeColor = global::System.Drawing.Color.Black;
			this.siticoneButton3.HoveredState.Parent = this.siticoneButton3;
			this.siticoneButton3.Location = new global::System.Drawing.Point(9, 221);
			this.siticoneButton3.Name = "siticoneButton3";
			this.siticoneButton3.PressedColor = global::System.Drawing.Color.White;
			this.siticoneButton3.ShadowDecoration.Parent = this.siticoneButton3;
			this.siticoneButton3.Size = new global::System.Drawing.Size(464, 33);
			this.siticoneButton3.TabIndex = 115;
			this.siticoneButton3.Text = "Open Developer Console";
			this.siticoneButton3.TextRenderingHint = global::System.Drawing.Text.TextRenderingHint.AntiAlias;
			this.siticoneButton3.Click += new global::System.EventHandler(this.siticoneButton3_Click_1);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(487, 339);
			base.Controls.Add(this.siticoneButton3);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.siticoneButton2);
			base.Controls.Add(this.siticoneButton1);
			base.Controls.Add(this.siticoneGradientButton1);
			base.Controls.Add(this.usText);
			base.Controls.Add(this.siticoneImageButton2);
			base.Controls.Add(this.siticoneImageButton3);
			base.Controls.Add(this.siticoneImageButton1);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "DevToolsBSXS";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DevToolsBSXS";
			base.Load += new global::System.EventHandler(this.DevToolsBSXS_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000262 RID: 610
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000263 RID: 611
		private global::Siticone.UI.WinForms.SiticoneElipse siticoneElipse1;

		// Token: 0x04000264 RID: 612
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000265 RID: 613
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton2;

		// Token: 0x04000266 RID: 614
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton3;

		// Token: 0x04000267 RID: 615
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton1;

		// Token: 0x04000268 RID: 616
		private global::Siticone.UI.WinForms.SiticoneTextBox usText;

		// Token: 0x04000269 RID: 617
		private global::Siticone.UI.WinForms.SiticoneButton siticoneButton2;

		// Token: 0x0400026A RID: 618
		private global::Siticone.UI.WinForms.SiticoneButton siticoneButton1;

		// Token: 0x0400026B RID: 619
		private global::Siticone.UI.WinForms.SiticoneButton siticoneGradientButton1;

		// Token: 0x0400026C RID: 620
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400026D RID: 621
		private global::Siticone.UI.WinForms.SiticoneButton siticoneButton3;
	}
}
