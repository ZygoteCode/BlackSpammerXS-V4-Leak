namespace BlackSpammerXS
{
	// Token: 0x0200005D RID: 93
	public partial class GTextRes : global::System.Windows.Forms.Form
	{
		// Token: 0x06000199 RID: 409 RVA: 0x0001A56C File Offset: 0x0001876C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600019A RID: 410 RVA: 0x0001A5A4 File Offset: 0x000187A4
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::BlackSpammerXS.GTextRes));
			this.usText = new global::Siticone.UI.WinForms.SiticoneTextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.siticoneShadowForm1 = new global::Siticone.UI.WinForms.SiticoneShadowForm(this.components);
			this.siticoneAnimateWindow1 = new global::Siticone.UI.WinForms.SiticoneAnimateWindow(this.components);
			this.siticoneElipse1 = new global::Siticone.UI.WinForms.SiticoneElipse(this.components);
			this.siticoneImageButton2 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneImageButton3 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneImageButton1 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			base.SuspendLayout();
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
			this.usText.Font = new global::System.Drawing.Font("JetBrains Mono", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.usText.ForeColor = global::System.Drawing.Color.Black;
			this.usText.HoveredState.BorderColor = global::System.Drawing.Color.FromArgb(213, 218, 223);
			this.usText.HoveredState.Parent = this.usText;
			this.usText.Location = new global::System.Drawing.Point(12, 44);
			this.usText.Multiline = true;
			this.usText.Name = "usText";
			this.usText.PasswordChar = '\0';
			this.usText.PlaceholderText = "Result will appear here";
			this.usText.ReadOnly = true;
			this.usText.SelectedText = "";
			this.usText.ShadowDecoration.Parent = this.usText;
			this.usText.Size = new global::System.Drawing.Size(623, 326);
			this.usText.TabIndex = 67;
			this.label1.Font = new global::System.Drawing.Font("SF Pro Text", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(130, 13);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(382, 18);
			this.label1.TabIndex = 69;
			this.label1.Text = "View Result";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label1.Click += new global::System.EventHandler(this.label1_Click);
			this.siticoneAnimateWindow1.AnimationType = 262144;
			this.siticoneAnimateWindow1.Interval = 300;
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
			this.siticoneImageButton2.Location = new global::System.Drawing.Point(34, 9);
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
			this.siticoneImageButton3.Location = new global::System.Drawing.Point(55, 9);
			this.siticoneImageButton3.Name = "siticoneImageButton3";
			this.siticoneImageButton3.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.PressedState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Size = new global::System.Drawing.Size(29, 29);
			this.siticoneImageButton3.TabIndex = 85;
			this.siticoneImageButton1.CheckedState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneImageButton1.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image1");
			this.siticoneImageButton1.HoveredState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.HoveredState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneImageButton1.Image");
			this.siticoneImageButton1.ImageRotate = 0f;
			this.siticoneImageButton1.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.IndicateFocus = false;
			this.siticoneImageButton1.Location = new global::System.Drawing.Point(15, 9);
			this.siticoneImageButton1.Name = "siticoneImageButton1";
			this.siticoneImageButton1.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.PressedState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Size = new global::System.Drawing.Size(26, 29);
			this.siticoneImageButton1.TabIndex = 84;
			this.siticoneImageButton1.Click += new global::System.EventHandler(this.siticoneImageButton1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(647, 382);
			base.Controls.Add(this.siticoneImageButton2);
			base.Controls.Add(this.siticoneImageButton3);
			base.Controls.Add(this.siticoneImageButton1);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.usText);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "GTextRes";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "GTextRes";
			base.Load += new global::System.EventHandler(this.GTextRes_Load);
			base.ResumeLayout(false);
		}

		// Token: 0x040002DB RID: 731
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040002DC RID: 732
		private global::Siticone.UI.WinForms.SiticoneTextBox usText;

		// Token: 0x040002DD RID: 733
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040002DE RID: 734
		private global::Siticone.UI.WinForms.SiticoneShadowForm siticoneShadowForm1;

		// Token: 0x040002DF RID: 735
		private global::Siticone.UI.WinForms.SiticoneAnimateWindow siticoneAnimateWindow1;

		// Token: 0x040002E0 RID: 736
		private global::Siticone.UI.WinForms.SiticoneElipse siticoneElipse1;

		// Token: 0x040002E1 RID: 737
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton2;

		// Token: 0x040002E2 RID: 738
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton3;

		// Token: 0x040002E3 RID: 739
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton1;
	}
}
