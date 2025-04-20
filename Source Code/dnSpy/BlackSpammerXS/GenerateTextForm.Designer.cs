namespace BlackSpammerXS
{
	// Token: 0x0200005A RID: 90
	public partial class GenerateTextForm : global::System.Windows.Forms.Form
	{
		// Token: 0x0600018C RID: 396 RVA: 0x00018F48 File Offset: 0x00017148
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00018F80 File Offset: 0x00017180
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::BlackSpammerXS.GenerateTextForm));
			this.label2 = new global::System.Windows.Forms.Label();
			this.del = new global::System.Windows.Forms.Label();
			this.usText = new global::Siticone.UI.WinForms.SiticoneTextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.hasRand = new global::Siticone.UI.WinForms.SiticoneCustomCheckBox();
			this.hasMTX = new global::Siticone.UI.WinForms.SiticoneCustomCheckBox();
			this.hasCount = new global::Siticone.UI.WinForms.SiticoneCustomCheckBox();
			this.siticoneShadowForm1 = new global::Siticone.UI.WinForms.SiticoneShadowForm(this.components);
			this.siticoneAnimateWindow1 = new global::Siticone.UI.WinForms.SiticoneAnimateWindow(this.components);
			this.siticoneElipse1 = new global::Siticone.UI.WinForms.SiticoneElipse(this.components);
			this.siticoneImageButton2 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneImageButton3 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneImageButton1 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneGradientButton5 = new global::Siticone.UI.WinForms.SiticoneGradientButton();
			this.siticoneDragControl1 = new global::Siticone.UI.WinForms.SiticoneDragControl(this.components);
			base.SuspendLayout();
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("SF Pro Text", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new global::System.Drawing.Point(34, 125);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(38, 14);
			this.label2.TabIndex = 69;
			this.label2.Text = "Rand";
			this.del.AutoSize = true;
			this.del.Font = new global::System.Drawing.Font("SF Pro Text", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.del.Location = new global::System.Drawing.Point(35, 103);
			this.del.Name = "del";
			this.del.Size = new global::System.Drawing.Size(64, 14);
			this.del.TabIndex = 68;
			this.del.Text = "Mass Tag";
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
			this.usText.Location = new global::System.Drawing.Point(12, 45);
			this.usText.Margin = new global::System.Windows.Forms.Padding(4, 3, 4, 3);
			this.usText.Name = "usText";
			this.usText.PasswordChar = '\0';
			this.usText.PlaceholderText = "1, 2, 3...";
			this.usText.SelectedText = "";
			this.usText.ShadowDecoration.Parent = this.usText;
			this.usText.Size = new global::System.Drawing.Size(497, 40);
			this.usText.TabIndex = 66;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("SF Pro Text", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(194, 11);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(114, 18);
			this.label1.TabIndex = 65;
			this.label1.Text = "Generate Text";
			this.label3.AccessibleDescription = "s";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("SF Pro Text", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.Location = new global::System.Drawing.Point(34, 147);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(44, 14);
			this.label3.TabIndex = 96;
			this.label3.Text = "Count";
			this.hasRand.BackColor = global::System.Drawing.Color.Transparent;
			this.hasRand.CheckedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.hasRand.CheckedState.BorderRadius = 2;
			this.hasRand.CheckedState.BorderThickness = 0;
			this.hasRand.CheckedState.FillColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.hasRand.CheckedState.Parent = this.hasRand;
			this.hasRand.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.hasRand.Location = new global::System.Drawing.Point(15, 123);
			this.hasRand.Name = "hasRand";
			this.hasRand.ShadowDecoration.Parent = this.hasRand;
			this.hasRand.Size = new global::System.Drawing.Size(15, 15);
			this.hasRand.TabIndex = 98;
			this.hasRand.UncheckedState.BorderColor = global::System.Drawing.Color.FromArgb(125, 137, 149);
			this.hasRand.UncheckedState.BorderRadius = 2;
			this.hasRand.UncheckedState.BorderThickness = 0;
			this.hasRand.UncheckedState.FillColor = global::System.Drawing.Color.FromArgb(125, 137, 149);
			this.hasRand.UncheckedState.Parent = this.hasRand;
			this.hasMTX.Checked = true;
			this.hasMTX.CheckedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.hasMTX.CheckedState.BorderRadius = 2;
			this.hasMTX.CheckedState.BorderThickness = 0;
			this.hasMTX.CheckedState.FillColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.hasMTX.CheckedState.Parent = this.hasMTX;
			this.hasMTX.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.hasMTX.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.hasMTX.Location = new global::System.Drawing.Point(15, 102);
			this.hasMTX.Name = "hasMTX";
			this.hasMTX.ShadowDecoration.Parent = this.hasMTX;
			this.hasMTX.Size = new global::System.Drawing.Size(15, 15);
			this.hasMTX.TabIndex = 97;
			this.hasMTX.UncheckedState.BorderColor = global::System.Drawing.Color.FromArgb(125, 137, 149);
			this.hasMTX.UncheckedState.BorderRadius = 2;
			this.hasMTX.UncheckedState.BorderThickness = 0;
			this.hasMTX.UncheckedState.FillColor = global::System.Drawing.Color.FromArgb(125, 137, 149);
			this.hasMTX.UncheckedState.Parent = this.hasMTX;
			this.hasCount.CheckedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.hasCount.CheckedState.BorderRadius = 2;
			this.hasCount.CheckedState.BorderThickness = 0;
			this.hasCount.CheckedState.FillColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.hasCount.CheckedState.Parent = this.hasCount;
			this.hasCount.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.hasCount.Location = new global::System.Drawing.Point(15, 145);
			this.hasCount.Name = "hasCount";
			this.hasCount.ShadowDecoration.Parent = this.hasCount;
			this.hasCount.Size = new global::System.Drawing.Size(15, 15);
			this.hasCount.TabIndex = 99;
			this.hasCount.UncheckedState.BorderColor = global::System.Drawing.Color.FromArgb(125, 137, 149);
			this.hasCount.UncheckedState.BorderRadius = 2;
			this.hasCount.UncheckedState.BorderThickness = 0;
			this.hasCount.UncheckedState.FillColor = global::System.Drawing.Color.FromArgb(125, 137, 149);
			this.hasCount.UncheckedState.Parent = this.hasCount;
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
			this.siticoneImageButton2.Location = new global::System.Drawing.Point(26, 5);
			this.siticoneImageButton2.Name = "siticoneImageButton2";
			this.siticoneImageButton2.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton2.PressedState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.Size = new global::System.Drawing.Size(29, 29);
			this.siticoneImageButton2.TabIndex = 102;
			this.siticoneImageButton2.Click += new global::System.EventHandler(this.siticoneImageButton2_Click);
			this.siticoneImageButton3.CheckedState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Cursor = global::System.Windows.Forms.Cursors.Arrow;
			this.siticoneImageButton3.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image1");
			this.siticoneImageButton3.HoveredState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.HoveredState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneImageButton3.Image");
			this.siticoneImageButton3.ImageRotate = 0f;
			this.siticoneImageButton3.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.IndicateFocus = false;
			this.siticoneImageButton3.Location = new global::System.Drawing.Point(47, 5);
			this.siticoneImageButton3.Name = "siticoneImageButton3";
			this.siticoneImageButton3.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.PressedState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Size = new global::System.Drawing.Size(29, 29);
			this.siticoneImageButton3.TabIndex = 101;
			this.siticoneImageButton1.CheckedState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneImageButton1.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image2");
			this.siticoneImageButton1.HoveredState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.HoveredState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneImageButton1.Image");
			this.siticoneImageButton1.ImageRotate = 0f;
			this.siticoneImageButton1.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.IndicateFocus = false;
			this.siticoneImageButton1.Location = new global::System.Drawing.Point(7, 5);
			this.siticoneImageButton1.Name = "siticoneImageButton1";
			this.siticoneImageButton1.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.PressedState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Size = new global::System.Drawing.Size(26, 29);
			this.siticoneImageButton1.TabIndex = 100;
			this.siticoneImageButton1.Click += new global::System.EventHandler(this.siticoneImageButton1_Click);
			this.siticoneGradientButton5.BorderRadius = 18;
			this.siticoneGradientButton5.CheckedState.Parent = this.siticoneGradientButton5;
			this.siticoneGradientButton5.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneGradientButton5.CustomImages.Parent = this.siticoneGradientButton5;
			this.siticoneGradientButton5.FillColor = global::System.Drawing.Color.DodgerBlue;
			this.siticoneGradientButton5.FillColor2 = global::System.Drawing.Color.DeepSkyBlue;
			this.siticoneGradientButton5.Font = new global::System.Drawing.Font("SF Pro Text", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneGradientButton5.ForeColor = global::System.Drawing.Color.White;
			this.siticoneGradientButton5.HoveredState.Parent = this.siticoneGradientButton5;
			this.siticoneGradientButton5.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneGradientButton5.Image");
			this.siticoneGradientButton5.ImageAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.siticoneGradientButton5.ImageOffset = new global::System.Drawing.Point(6, -1);
			this.siticoneGradientButton5.Location = new global::System.Drawing.Point(15, 181);
			this.siticoneGradientButton5.Name = "siticoneGradientButton5";
			this.siticoneGradientButton5.ShadowDecoration.Parent = this.siticoneGradientButton5;
			this.siticoneGradientButton5.Size = new global::System.Drawing.Size(494, 38);
			this.siticoneGradientButton5.TabIndex = 103;
			this.siticoneGradientButton5.Text = "Generate";
			this.siticoneGradientButton5.TextRenderingHint = global::System.Drawing.Text.TextRenderingHint.AntiAlias;
			this.siticoneGradientButton5.Click += new global::System.EventHandler(this.siticoneButton7_Click);
			this.siticoneDragControl1.TargetControl = this;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(521, 231);
			base.ControlBox = false;
			base.Controls.Add(this.siticoneGradientButton5);
			base.Controls.Add(this.siticoneImageButton2);
			base.Controls.Add(this.siticoneImageButton3);
			base.Controls.Add(this.siticoneImageButton1);
			base.Controls.Add(this.hasCount);
			base.Controls.Add(this.hasRand);
			base.Controls.Add(this.hasMTX);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.del);
			base.Controls.Add(this.usText);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "GenerateTextForm";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "GenerateText";
			base.Load += new global::System.EventHandler(this.GenerateTextForm_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040002B7 RID: 695
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040002B8 RID: 696
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040002B9 RID: 697
		private global::System.Windows.Forms.Label del;

		// Token: 0x040002BA RID: 698
		private global::Siticone.UI.WinForms.SiticoneTextBox usText;

		// Token: 0x040002BB RID: 699
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040002BC RID: 700
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040002BD RID: 701
		private global::Siticone.UI.WinForms.SiticoneCustomCheckBox hasRand;

		// Token: 0x040002BE RID: 702
		private global::Siticone.UI.WinForms.SiticoneCustomCheckBox hasMTX;

		// Token: 0x040002BF RID: 703
		private global::Siticone.UI.WinForms.SiticoneCustomCheckBox hasCount;

		// Token: 0x040002C0 RID: 704
		private global::Siticone.UI.WinForms.SiticoneShadowForm siticoneShadowForm1;

		// Token: 0x040002C1 RID: 705
		private global::Siticone.UI.WinForms.SiticoneAnimateWindow siticoneAnimateWindow1;

		// Token: 0x040002C2 RID: 706
		private global::Siticone.UI.WinForms.SiticoneElipse siticoneElipse1;

		// Token: 0x040002C3 RID: 707
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton2;

		// Token: 0x040002C4 RID: 708
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton3;

		// Token: 0x040002C5 RID: 709
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton1;

		// Token: 0x040002C6 RID: 710
		private global::Siticone.UI.WinForms.SiticoneGradientButton siticoneGradientButton5;

		// Token: 0x040002C7 RID: 711
		private global::Siticone.UI.WinForms.SiticoneDragControl siticoneDragControl1;
	}
}
