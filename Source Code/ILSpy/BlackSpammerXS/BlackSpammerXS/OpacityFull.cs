using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Siticone.UI.WinForms;

namespace BlackSpammerXS;

public class OpacityFull : Form
{
	private IContainer components = null;

	private SiticoneAnimateWindow siticoneAnimateWindow1;

	private ContextMenuStrip contextMenuStrip1;

	private ToolStripMenuItem chiudiToolStripMenuItem;

	public OpacityFull()
	{
		InitializeComponent();
		base.WindowState = FormWindowState.Maximized;
	}

	private void OpacityFull_Load(object sender, EventArgs e)
	{
		siticoneAnimateWindow1.SetAnimateWindow((Form)this);
		base.Enabled = false;
	}

	private void OpacityFull_Click(object sender, EventArgs e)
	{
	}

	private void OpacityFull_Activated(object sender, EventArgs e)
	{
	}

	private void chiudiToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Close();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlackSpammerXS.OpacityFull));
		this.siticoneAnimateWindow1 = new SiticoneAnimateWindow(this.components);
		this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.chiudiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.contextMenuStrip1.SuspendLayout();
		base.SuspendLayout();
		this.siticoneAnimateWindow1.AnimationType = (AnimateWindowType)65536;
		this.siticoneAnimateWindow1.Interval = 500;
		this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.chiudiToolStripMenuItem });
		this.contextMenuStrip1.Name = "contextMenuStrip1";
		this.contextMenuStrip1.Size = new System.Drawing.Size(110, 26);
		this.chiudiToolStripMenuItem.Name = "chiudiToolStripMenuItem";
		this.chiudiToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
		this.chiudiToolStripMenuItem.Text = "Chiudi";
		this.chiudiToolStripMenuItem.Click += new System.EventHandler(chiudiToolStripMenuItem_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.SystemColors.ActiveBorder;
		base.ClientSize = new System.Drawing.Size(811, 509);
		this.ContextMenuStrip = this.contextMenuStrip1;
		base.ControlBox = false;
		base.Enabled = false;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "OpacityFull";
		base.Opacity = 0.5;
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		this.Text = "OpacityFull";
		base.Activated += new System.EventHandler(OpacityFull_Activated);
		base.Load += new System.EventHandler(OpacityFull_Load);
		base.Click += new System.EventHandler(OpacityFull_Click);
		this.contextMenuStrip1.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
