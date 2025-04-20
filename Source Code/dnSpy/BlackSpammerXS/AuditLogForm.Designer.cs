namespace BlackSpammerXS
{
	// Token: 0x02000012 RID: 18
	public partial class AuditLogForm : global::System.Windows.Forms.Form
	{
		// Token: 0x0600006C RID: 108 RVA: 0x00007EF4 File Offset: 0x000060F4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00007F2C File Offset: 0x0000612C
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::BlackSpammerXS.AuditLogForm));
			this.siticoneShadowForm1 = new global::Siticone.UI.WinForms.SiticoneShadowForm(this.components);
			this.siticoneAnimateWindow1 = new global::Siticone.UI.WinForms.SiticoneAnimateWindow(this.components);
			this.label1 = new global::System.Windows.Forms.Label();
			this.contextMenuStrip1 = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.clearLogToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.rawJSONLogToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.logContainer = new global::System.Windows.Forms.FlowLayoutPanel();
			this.siticoneImageButton2 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneImageButton3 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneImageButton1 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneElipse1 = new global::Siticone.UI.WinForms.SiticoneElipse(this.components);
			this.contextMenuStrip1.SuspendLayout();
			base.SuspendLayout();
			this.siticoneAnimateWindow1.AnimationType = 262144;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("SF Pro Text", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(257, 13);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(80, 18);
			this.label1.TabIndex = 66;
			this.label1.Text = "Audit Log";
			this.contextMenuStrip1.Font = new global::System.Drawing.Font("SF Pro Text", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.contextMenuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.clearLogToolStripMenuItem, this.rawJSONLogToolStripMenuItem });
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new global::System.Drawing.Size(181, 70);
			this.contextMenuStrip1.Opening += new global::System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
			this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
			this.clearLogToolStripMenuItem.Size = new global::System.Drawing.Size(180, 22);
			this.clearLogToolStripMenuItem.Text = "Clear Log";
			this.clearLogToolStripMenuItem.Click += new global::System.EventHandler(this.clearLogToolStripMenuItem_Click);
			this.rawJSONLogToolStripMenuItem.Name = "rawJSONLogToolStripMenuItem";
			this.rawJSONLogToolStripMenuItem.Size = new global::System.Drawing.Size(180, 22);
			this.rawJSONLogToolStripMenuItem.Text = "Raw JSON Log";
			this.rawJSONLogToolStripMenuItem.Click += new global::System.EventHandler(this.rawJSONLogToolStripMenuItem_Click);
			this.logContainer.Location = new global::System.Drawing.Point(-2, 44);
			this.logContainer.Name = "logContainer";
			this.logContainer.Size = new global::System.Drawing.Size(614, 507);
			this.logContainer.TabIndex = 67;
			this.logContainer.Paint += new global::System.Windows.Forms.PaintEventHandler(this.logContainer_Paint_1);
			this.siticoneImageButton2.CheckedState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.Cursor = global::System.Windows.Forms.Cursors.Arrow;
			this.siticoneImageButton2.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image");
			this.siticoneImageButton2.HoveredState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton2.HoveredState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneImageButton2.Image");
			this.siticoneImageButton2.ImageRotate = 0f;
			this.siticoneImageButton2.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton2.IndicateFocus = false;
			this.siticoneImageButton2.Location = new global::System.Drawing.Point(29, 7);
			this.siticoneImageButton2.Name = "siticoneImageButton2";
			this.siticoneImageButton2.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton2.PressedState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.Size = new global::System.Drawing.Size(29, 29);
			this.siticoneImageButton2.TabIndex = 89;
			this.siticoneImageButton3.CheckedState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Cursor = global::System.Windows.Forms.Cursors.Arrow;
			this.siticoneImageButton3.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image1");
			this.siticoneImageButton3.HoveredState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.HoveredState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneImageButton3.Image");
			this.siticoneImageButton3.ImageRotate = 0f;
			this.siticoneImageButton3.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.IndicateFocus = false;
			this.siticoneImageButton3.Location = new global::System.Drawing.Point(50, 7);
			this.siticoneImageButton3.Name = "siticoneImageButton3";
			this.siticoneImageButton3.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.PressedState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Size = new global::System.Drawing.Size(29, 29);
			this.siticoneImageButton3.TabIndex = 88;
			this.siticoneImageButton1.CheckedState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneImageButton1.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image2");
			this.siticoneImageButton1.HoveredState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.HoveredState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneImageButton1.Image");
			this.siticoneImageButton1.ImageRotate = 0f;
			this.siticoneImageButton1.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.IndicateFocus = false;
			this.siticoneImageButton1.Location = new global::System.Drawing.Point(10, 7);
			this.siticoneImageButton1.Name = "siticoneImageButton1";
			this.siticoneImageButton1.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.PressedState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Size = new global::System.Drawing.Size(26, 29);
			this.siticoneImageButton1.TabIndex = 87;
			this.siticoneImageButton1.Click += new global::System.EventHandler(this.siticoneImageButton1_Click);
			this.siticoneElipse1.TargetControl = this;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(611, 551);
			this.ContextMenuStrip = this.contextMenuStrip1;
			base.Controls.Add(this.siticoneImageButton2);
			base.Controls.Add(this.siticoneImageButton3);
			base.Controls.Add(this.siticoneImageButton1);
			base.Controls.Add(this.logContainer);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "AuditLogForm";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "AuditLogForm";
			base.Load += new global::System.EventHandler(this.AuditLogForm_Load);
			this.contextMenuStrip1.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000082 RID: 130
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000083 RID: 131
		private global::Siticone.UI.WinForms.SiticoneShadowForm siticoneShadowForm1;

		// Token: 0x04000084 RID: 132
		private global::Siticone.UI.WinForms.SiticoneAnimateWindow siticoneAnimateWindow1;

		// Token: 0x04000085 RID: 133
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000086 RID: 134
		private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

		// Token: 0x04000087 RID: 135
		private global::System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem;

		// Token: 0x04000088 RID: 136
		private global::System.Windows.Forms.ToolStripMenuItem rawJSONLogToolStripMenuItem;

		// Token: 0x04000089 RID: 137
		private global::System.Windows.Forms.FlowLayoutPanel logContainer;

		// Token: 0x0400008A RID: 138
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton2;

		// Token: 0x0400008B RID: 139
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton3;

		// Token: 0x0400008C RID: 140
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton1;

		// Token: 0x0400008D RID: 141
		private global::Siticone.UI.WinForms.SiticoneElipse siticoneElipse1;
	}
}
