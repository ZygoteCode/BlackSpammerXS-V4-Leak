using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Suite;

namespace BlackSpammerXS;

public class AuditSpam : UserControl
{
	private string a;

	private string b;

	private AuditLogForm __log;

	private IContainer components = null;

	private Label label7;

	private PictureBox pictureBox1;

	private Label label6;

	private Label proxiesAm;

	private Label label4;

	private Label tamount;

	private Label label2;

	private Label label3;

	private Label sLink;

	private Label label1;

	private SiticoneGradientButton siticoneButton3;

	public AuditSpam(string serverId, string tokens, string proxies, string timeStamp, string message, string mref, bool dark, AuditLogForm __log)
	{
		InitializeComponent();
		sLink.Text = serverId;
		tamount.Text = tokens;
		proxiesAm.Text = proxies;
		a = message;
		b = mref;
		this.__log = __log;
		if (!dark)
		{
			return;
		}
		List<Label> list = new List<Label> { sLink, label1, label2, label3, tamount, proxiesAm, label4, label6, label7 };
		foreach (Label item in list)
		{
			item.ForeColor = Color.White;
		}
	}

	private void AuditSpam_Load(object sender, EventArgs e)
	{
	}

	private async void siticoneGradientButton3_Click(object sender, EventArgs e)
	{
		await Task.Delay(50);
		ImpostazioniGlobali.CallbackBridgeAL(1, 0, new object[3] { sLink.Text, a, b });
		ImpostazioniGlobali.bridgeAct_(0);
		ImpostazioniGlobali.CallbackBridgeAL(1153, 2, null);
		__log.Close();
	}

	private void siticoneButton3_Click(object sender, EventArgs e)
	{
		siticoneGradientButton3_Click(sender, e);
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
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlackSpammerXS.AuditSpam));
		this.label7 = new System.Windows.Forms.Label();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.label6 = new System.Windows.Forms.Label();
		this.proxiesAm = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.tamount = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.sLink = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.siticoneButton3 = new SiticoneGradientButton();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		base.SuspendLayout();
		this.label7.AutoSize = true;
		this.label7.Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label7.Location = new System.Drawing.Point(116, 88);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(30, 15);
		this.label7.TabIndex = 115;
		this.label7.Text = "and";
		this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
		this.pictureBox1.Location = new System.Drawing.Point(15, 16);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(24, 24);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.pictureBox1.TabIndex = 114;
		this.pictureBox1.TabStop = false;
		this.label6.AutoSize = true;
		this.label6.Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label6.Location = new System.Drawing.Point(206, 88);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(56, 15);
		this.label6.TabIndex = 113;
		this.label6.Text = "proxies.";
		this.proxiesAm.Font = new System.Drawing.Font("SF Pro Text", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.proxiesAm.Location = new System.Drawing.Point(150, 84);
		this.proxiesAm.Name = "proxiesAm";
		this.proxiesAm.Size = new System.Drawing.Size(52, 23);
		this.proxiesAm.TabIndex = 112;
		this.proxiesAm.Text = "1000";
		this.proxiesAm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.Location = new System.Drawing.Point(63, 88);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(49, 15);
		this.label4.TabIndex = 111;
		this.label4.Text = "tokens";
		this.tamount.Font = new System.Drawing.Font("SF Pro Text", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.tamount.Location = new System.Drawing.Point(11, 85);
		this.tamount.Name = "tamount";
		this.tamount.Size = new System.Drawing.Size(52, 23);
		this.tamount.TabIndex = 110;
		this.tamount.Text = "1000";
		this.tamount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.Location = new System.Drawing.Point(286, 61);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(33, 15);
		this.label2.TabIndex = 109;
		this.label2.Text = "with";
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.Location = new System.Drawing.Point(13, 61);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(86, 15);
		this.label3.TabIndex = 108;
		this.label3.Text = "Spamming in";
		this.sLink.Font = new System.Drawing.Font("SF Pro Text", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.sLink.Location = new System.Drawing.Point(99, 58);
		this.sLink.Name = "sLink";
		this.sLink.Size = new System.Drawing.Size(185, 23);
		this.sLink.TabIndex = 107;
		this.sLink.Text = "000000000000000000";
		this.sLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Inter Black", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(45, 16);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(72, 25);
		this.label1.TabIndex = 106;
		this.label1.Text = "Spam";
		this.siticoneButton3.BorderRadius = 18;
		((ButtonState)this.siticoneButton3.CheckedState).Parent = (CustomButtonBase)(object)this.siticoneButton3;
		((System.Windows.Forms.Control)(object)this.siticoneButton3).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneButton3.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneButton3;
		this.siticoneButton3.FillColor = System.Drawing.Color.DodgerBlue;
		this.siticoneButton3.FillColor2 = System.Drawing.Color.DeepSkyBlue;
		((System.Windows.Forms.Control)(object)this.siticoneButton3).Font = new System.Drawing.Font("SF Pro Text", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneButton3).ForeColor = System.Drawing.Color.White;
		((ButtonState)this.siticoneButton3.HoveredState).Parent = (CustomButtonBase)(object)this.siticoneButton3;
		this.siticoneButton3.Image = (System.Drawing.Image)resources.GetObject("siticoneButton3.Image");
		this.siticoneButton3.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.siticoneButton3.ImageOffset = new System.Drawing.Point(6, -1);
		((System.Windows.Forms.Control)(object)this.siticoneButton3).Location = new System.Drawing.Point(337, 54);
		((System.Windows.Forms.Control)(object)this.siticoneButton3).Name = "siticoneButton3";
		this.siticoneButton3.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneButton3;
		((System.Windows.Forms.Control)(object)this.siticoneButton3).Size = new System.Drawing.Size(247, 38);
		((System.Windows.Forms.Control)(object)this.siticoneButton3).TabIndex = 117;
		((System.Windows.Forms.Control)(object)this.siticoneButton3).Text = "Perform Again";
		this.siticoneButton3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.siticoneButton3).Click += new System.EventHandler(siticoneButton3_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneButton3);
		base.Controls.Add(this.label7);
		base.Controls.Add(this.pictureBox1);
		base.Controls.Add(this.label6);
		base.Controls.Add(this.proxiesAm);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.tamount);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.sLink);
		base.Controls.Add(this.label1);
		base.Name = "AuditSpam";
		base.Size = new System.Drawing.Size(591, 124);
		base.Load += new System.EventHandler(AuditSpam_Load);
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
