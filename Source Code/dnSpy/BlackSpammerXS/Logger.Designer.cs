namespace BlackSpammerXS
{
	// Token: 0x0200007C RID: 124
	public partial class Logger : global::System.Windows.Forms.Form
	{
		// Token: 0x0600020A RID: 522 RVA: 0x000252E0 File Offset: 0x000234E0
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00025318 File Offset: 0x00023518
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::BlackSpammerXS.Logger));
			this.logBox = new global::Siticone.UI.WinForms.SiticoneTextBox();
			this.siticoneDragControl1 = new global::Siticone.UI.WinForms.SiticoneDragControl(this.components);
			this.siticoneElipse1 = new global::Siticone.UI.WinForms.SiticoneElipse(this.components);
			this.siticoneDragControl2 = new global::Siticone.UI.WinForms.SiticoneDragControl(this.components);
			this.siticoneImageButton3 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneImageButton2 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneImageButton1 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneShadowForm1 = new global::Siticone.UI.WinForms.SiticoneShadowForm(this.components);
			base.SuspendLayout();
			this.logBox.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.logBox.Animated = false;
			this.logBox.BackColor = global::System.Drawing.Color.Transparent;
			this.logBox.BorderColor = global::System.Drawing.Color.Transparent;
			this.logBox.BorderThickness = 0;
			this.logBox.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.logBox.DefaultText = "";
			this.logBox.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.logBox.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.logBox.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.logBox.DisabledState.Parent = this.logBox;
			this.logBox.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.logBox.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.logBox.FocusedState.Parent = this.logBox;
			this.logBox.Font = new global::System.Drawing.Font("JetBrains Mono", 9.75f);
			this.logBox.ForeColor = global::System.Drawing.Color.Black;
			this.logBox.HoveredState.BorderColor = global::System.Drawing.Color.Transparent;
			this.logBox.HoveredState.Parent = this.logBox;
			this.logBox.Location = new global::System.Drawing.Point(-3, 32);
			this.logBox.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
			this.logBox.Multiline = true;
			this.logBox.Name = "logBox";
			this.logBox.PasswordChar = '\0';
			this.logBox.PlaceholderText = "BlackSpammer XS Logger V4";
			this.logBox.ReadOnly = true;
			this.logBox.SelectedText = "";
			this.logBox.ShadowDecoration.Parent = this.logBox;
			this.logBox.Size = new global::System.Drawing.Size(889, 319);
			this.logBox.TabIndex = 36;
			this.logBox.TextChanged += new global::System.EventHandler(this.logBox_TextChanged);
			this.siticoneDragControl1.TargetControl = this.logBox;
			this.siticoneElipse1.BorderRadius = 11;
			this.siticoneElipse1.TargetControl = this;
			this.siticoneDragControl2.TargetControl = this;
			this.siticoneImageButton3.CheckedState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneImageButton3.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image");
			this.siticoneImageButton3.HoveredState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.HoveredState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneImageButton3.Image");
			this.siticoneImageButton3.ImageRotate = 0f;
			this.siticoneImageButton3.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.IndicateFocus = false;
			this.siticoneImageButton3.Location = new global::System.Drawing.Point(47, 2);
			this.siticoneImageButton3.Name = "siticoneImageButton3";
			this.siticoneImageButton3.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.PressedState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Size = new global::System.Drawing.Size(29, 29);
			this.siticoneImageButton3.TabIndex = 82;
			this.siticoneImageButton3.Click += new global::System.EventHandler(this.siticoneImageButton3_Click);
			this.siticoneImageButton2.CheckedState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneImageButton2.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image1");
			this.siticoneImageButton2.HoveredState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton2.HoveredState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneImageButton2.Image");
			this.siticoneImageButton2.ImageRotate = 0f;
			this.siticoneImageButton2.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton2.IndicateFocus = false;
			this.siticoneImageButton2.Location = new global::System.Drawing.Point(26, 2);
			this.siticoneImageButton2.Name = "siticoneImageButton2";
			this.siticoneImageButton2.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton2.PressedState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.Size = new global::System.Drawing.Size(29, 29);
			this.siticoneImageButton2.TabIndex = 81;
			this.siticoneImageButton2.Click += new global::System.EventHandler(this.siticoneImageButton2_Click);
			this.siticoneImageButton1.CheckedState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneImageButton1.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image2");
			this.siticoneImageButton1.HoveredState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.HoveredState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneImageButton1.Image");
			this.siticoneImageButton1.ImageRotate = 0f;
			this.siticoneImageButton1.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.IndicateFocus = false;
			this.siticoneImageButton1.Location = new global::System.Drawing.Point(7, 2);
			this.siticoneImageButton1.Name = "siticoneImageButton1";
			this.siticoneImageButton1.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.PressedState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Size = new global::System.Drawing.Size(26, 29);
			this.siticoneImageButton1.TabIndex = 80;
			this.siticoneImageButton1.Click += new global::System.EventHandler(this.siticoneImageButton1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(887, 349);
			base.Controls.Add(this.siticoneImageButton3);
			base.Controls.Add(this.siticoneImageButton2);
			base.Controls.Add(this.siticoneImageButton1);
			base.Controls.Add(this.logBox);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "Logger";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Logger";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.Logger_FormClosed);
			base.Load += new global::System.EventHandler(this.Logger_Load);
			base.ResumeLayout(false);
		}

		// Token: 0x0400047F RID: 1151
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000480 RID: 1152
		private global::Siticone.UI.WinForms.SiticoneTextBox logBox;

		// Token: 0x04000481 RID: 1153
		private global::Siticone.UI.WinForms.SiticoneDragControl siticoneDragControl1;

		// Token: 0x04000482 RID: 1154
		private global::Siticone.UI.WinForms.SiticoneElipse siticoneElipse1;

		// Token: 0x04000483 RID: 1155
		private global::Siticone.UI.WinForms.SiticoneDragControl siticoneDragControl2;

		// Token: 0x04000484 RID: 1156
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton3;

		// Token: 0x04000485 RID: 1157
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton2;

		// Token: 0x04000486 RID: 1158
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton1;

		// Token: 0x04000487 RID: 1159
		private global::Siticone.UI.WinForms.SiticoneShadowForm siticoneShadowForm1;
	}
}
