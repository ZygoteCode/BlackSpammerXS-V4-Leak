namespace BlackSpammerXS
{
	// Token: 0x02000085 RID: 133
	public partial class OpacityFull : global::System.Windows.Forms.Form
	{
		// Token: 0x06000236 RID: 566 RVA: 0x0002919C File Offset: 0x0002739C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000237 RID: 567 RVA: 0x000291D4 File Offset: 0x000273D4
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::BlackSpammerXS.OpacityFull));
			this.siticoneAnimateWindow1 = new global::Siticone.UI.WinForms.SiticoneAnimateWindow(this.components);
			this.contextMenuStrip1 = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.chiudiToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1.SuspendLayout();
			base.SuspendLayout();
			this.siticoneAnimateWindow1.AnimationType = 65536;
			this.siticoneAnimateWindow1.Interval = 500;
			this.contextMenuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.chiudiToolStripMenuItem });
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new global::System.Drawing.Size(110, 26);
			this.chiudiToolStripMenuItem.Name = "chiudiToolStripMenuItem";
			this.chiudiToolStripMenuItem.Size = new global::System.Drawing.Size(109, 22);
			this.chiudiToolStripMenuItem.Text = "Chiudi";
			this.chiudiToolStripMenuItem.Click += new global::System.EventHandler(this.chiudiToolStripMenuItem_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.SystemColors.ActiveBorder;
			base.ClientSize = new global::System.Drawing.Size(811, 509);
			this.ContextMenuStrip = this.contextMenuStrip1;
			base.ControlBox = false;
			base.Enabled = false;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "OpacityFull";
			base.Opacity = 0.5;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.Text = "OpacityFull";
			base.Activated += new global::System.EventHandler(this.OpacityFull_Activated);
			base.Load += new global::System.EventHandler(this.OpacityFull_Load);
			base.Click += new global::System.EventHandler(this.OpacityFull_Click);
			this.contextMenuStrip1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000504 RID: 1284
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000505 RID: 1285
		private global::Siticone.UI.WinForms.SiticoneAnimateWindow siticoneAnimateWindow1;

		// Token: 0x04000506 RID: 1286
		private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

		// Token: 0x04000507 RID: 1287
		private global::System.Windows.Forms.ToolStripMenuItem chiudiToolStripMenuItem;
	}
}
