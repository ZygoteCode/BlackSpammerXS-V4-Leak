namespace BlackSpammerXS
{
	// Token: 0x02000079 RID: 121
	public partial class LoadingCVF : global::System.Windows.Forms.Form
	{
		// Token: 0x060001F5 RID: 501 RVA: 0x00024208 File Offset: 0x00022408
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00024240 File Offset: 0x00022440
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::BlackSpammerXS.LoadingCVF));
			this.label1 = new global::System.Windows.Forms.Label();
			this.siticoneCircleProgressBar1 = new global::Siticone.UI.WinForms.SiticoneCircleProgressBar();
			this.siticoneShadowForm1 = new global::Siticone.UI.WinForms.SiticoneShadowForm(this.components);
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.siticoneElipse1 = new global::Siticone.UI.WinForms.SiticoneElipse(this.components);
			this.siticoneImageButton1 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneImageButton3 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneImageButton2 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("SF Pro Text", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(177, 8);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(173, 18);
			this.label1.TabIndex = 3;
			this.label1.Text = "Developer Connection";
			this.label1.Visible = false;
			this.siticoneCircleProgressBar1.Animated = true;
			this.siticoneCircleProgressBar1.AnimationSpeed = 3f;
			this.siticoneCircleProgressBar1.FillThickness = 2;
			this.siticoneCircleProgressBar1.Location = new global::System.Drawing.Point(238, 69);
			this.siticoneCircleProgressBar1.Name = "siticoneCircleProgressBar1";
			this.siticoneCircleProgressBar1.ProgressThickness = 2;
			this.siticoneCircleProgressBar1.ShadowDecoration.Mode = 1;
			this.siticoneCircleProgressBar1.ShadowDecoration.Parent = this.siticoneCircleProgressBar1;
			this.siticoneCircleProgressBar1.Size = new global::System.Drawing.Size(32, 32);
			this.siticoneCircleProgressBar1.TabIndex = 4;
			this.siticoneCircleProgressBar1.Value = 30;
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(356, 51);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(48, 50);
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			this.siticoneElipse1.TargetControl = this;
			this.siticoneImageButton1.CheckedState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneImageButton1.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image");
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
			this.siticoneImageButton3.CheckedState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Cursor = global::System.Windows.Forms.Cursors.Arrow;
			this.siticoneImageButton3.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image1");
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
			this.siticoneImageButton2.CheckedState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.Cursor = global::System.Windows.Forms.Cursors.Arrow;
			this.siticoneImageButton2.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image");
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
			this.siticoneImageButton2.TabIndex = 83;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(524, 159);
			base.Controls.Add(this.siticoneImageButton2);
			base.Controls.Add(this.siticoneImageButton3);
			base.Controls.Add(this.siticoneImageButton1);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.siticoneCircleProgressBar1);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "LoadingCVF";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "LoadingCVF";
			base.Load += new global::System.EventHandler(this.LoadingCVF_Load);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000462 RID: 1122
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000463 RID: 1123
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000464 RID: 1124
		private global::Siticone.UI.WinForms.SiticoneCircleProgressBar siticoneCircleProgressBar1;

		// Token: 0x04000465 RID: 1125
		private global::Siticone.UI.WinForms.SiticoneShadowForm siticoneShadowForm1;

		// Token: 0x04000466 RID: 1126
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000467 RID: 1127
		private global::Siticone.UI.WinForms.SiticoneElipse siticoneElipse1;

		// Token: 0x04000468 RID: 1128
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton1;

		// Token: 0x04000469 RID: 1129
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton2;

		// Token: 0x0400046A RID: 1130
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton3;
	}
}
