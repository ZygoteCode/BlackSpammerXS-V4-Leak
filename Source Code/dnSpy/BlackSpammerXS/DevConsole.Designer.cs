namespace BlackSpammerXS
{
	// Token: 0x02000041 RID: 65
	public partial class DevConsole : global::System.Windows.Forms.Form
	{
		// Token: 0x0600012A RID: 298 RVA: 0x000124BC File Offset: 0x000106BC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600012B RID: 299 RVA: 0x000124F4 File Offset: 0x000106F4
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::BlackSpammerXS.DevConsole));
			this.siticoneElipse1 = new global::Siticone.UI.WinForms.SiticoneElipse(this.components);
			this.siticoneDragControl1 = new global::Siticone.UI.WinForms.SiticoneDragControl(this.components);
			this.label1 = new global::System.Windows.Forms.Label();
			this.siticoneImageButton3 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneImageButton2 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneImageButton1 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.logBox = new global::Siticone.UI.WinForms.SiticoneTextBox();
			this.siticoneDragControl2 = new global::Siticone.UI.WinForms.SiticoneDragControl(this.components);
			this.siticoneDragControl3 = new global::Siticone.UI.WinForms.SiticoneDragControl(this.components);
			base.SuspendLayout();
			this.siticoneElipse1.TargetControl = this;
			this.siticoneDragControl1.TargetControl = this;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("SF Pro Text", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(258, 17);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(266, 18);
			this.label1.TabIndex = 106;
			this.label1.Text = "BlackSpammer Developer Console";
			this.siticoneImageButton3.CheckedState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Cursor = global::System.Windows.Forms.Cursors.Arrow;
			this.siticoneImageButton3.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image");
			this.siticoneImageButton3.HoveredState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.HoveredState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneImageButton3.Image");
			this.siticoneImageButton3.ImageRotate = 0f;
			this.siticoneImageButton3.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.IndicateFocus = false;
			this.siticoneImageButton3.Location = new global::System.Drawing.Point(52, 11);
			this.siticoneImageButton3.Name = "siticoneImageButton3";
			this.siticoneImageButton3.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.PressedState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Size = new global::System.Drawing.Size(29, 29);
			this.siticoneImageButton3.TabIndex = 109;
			this.siticoneImageButton2.CheckedState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneImageButton2.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image1");
			this.siticoneImageButton2.HoveredState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton2.HoveredState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneImageButton2.Image");
			this.siticoneImageButton2.ImageRotate = 0f;
			this.siticoneImageButton2.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton2.IndicateFocus = false;
			this.siticoneImageButton2.Location = new global::System.Drawing.Point(31, 11);
			this.siticoneImageButton2.Name = "siticoneImageButton2";
			this.siticoneImageButton2.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton2.PressedState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.Size = new global::System.Drawing.Size(29, 29);
			this.siticoneImageButton2.TabIndex = 108;
			this.siticoneImageButton2.Click += new global::System.EventHandler(this.siticoneImageButton2_Click);
			this.siticoneImageButton1.CheckedState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneImageButton1.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image1");
			this.siticoneImageButton1.HoveredState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.HoveredState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneImageButton1.Image");
			this.siticoneImageButton1.ImageRotate = 0f;
			this.siticoneImageButton1.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.IndicateFocus = false;
			this.siticoneImageButton1.Location = new global::System.Drawing.Point(12, 11);
			this.siticoneImageButton1.Name = "siticoneImageButton1";
			this.siticoneImageButton1.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.PressedState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Size = new global::System.Drawing.Size(26, 29);
			this.siticoneImageButton1.TabIndex = 107;
			this.siticoneImageButton1.Click += new global::System.EventHandler(this.siticoneImageButton1_Click);
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
			this.logBox.FillColor = global::System.Drawing.Color.FromArgb(44, 47, 51);
			this.logBox.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.logBox.FocusedState.Parent = this.logBox;
			this.logBox.Font = new global::System.Drawing.Font("JetBrains Mono", 9.75f);
			this.logBox.ForeColor = global::System.Drawing.Color.White;
			this.logBox.HoveredState.BorderColor = global::System.Drawing.Color.Transparent;
			this.logBox.HoveredState.Parent = this.logBox;
			this.logBox.Location = new global::System.Drawing.Point(1, 47);
			this.logBox.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
			this.logBox.Multiline = true;
			this.logBox.Name = "logBox";
			this.logBox.PasswordChar = '\0';
			this.logBox.PlaceholderText = "Esegui un comando nella sessione corrente";
			this.logBox.SelectedText = "";
			this.logBox.ShadowDecoration.Parent = this.logBox;
			this.logBox.Size = new global::System.Drawing.Size(797, 402);
			this.logBox.TabIndex = 110;
			this.logBox.TextChanged += new global::System.EventHandler(this.logBox_TextChanged);
			this.logBox.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.logBox_KeyDown);
			this.siticoneDragControl2.TargetControl = this.logBox;
			this.siticoneDragControl3.TargetControl = this.label1;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(44, 47, 51);
			base.ClientSize = new global::System.Drawing.Size(800, 450);
			base.ControlBox = false;
			base.Controls.Add(this.logBox);
			base.Controls.Add(this.siticoneImageButton3);
			base.Controls.Add(this.siticoneImageButton2);
			base.Controls.Add(this.siticoneImageButton1);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "DevConsole";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BlackSpammer XS Developer Console";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400020E RID: 526
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400020F RID: 527
		private global::Siticone.UI.WinForms.SiticoneElipse siticoneElipse1;

		// Token: 0x04000210 RID: 528
		private global::Siticone.UI.WinForms.SiticoneDragControl siticoneDragControl1;

		// Token: 0x04000211 RID: 529
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000212 RID: 530
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton3;

		// Token: 0x04000213 RID: 531
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton2;

		// Token: 0x04000214 RID: 532
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton1;

		// Token: 0x04000215 RID: 533
		private global::Siticone.UI.WinForms.SiticoneTextBox logBox;

		// Token: 0x04000216 RID: 534
		private global::Siticone.UI.WinForms.SiticoneDragControl siticoneDragControl2;

		// Token: 0x04000217 RID: 535
		private global::Siticone.UI.WinForms.SiticoneDragControl siticoneDragControl3;
	}
}
