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

public class AuditJoin : UserControl
{
	private AuditLogForm __log;

	private IContainer components = null;

	private Label label1;

	private Label sLink;

	private Label label3;

	private Label label2;

	private Label tamount;

	private Label label4;

	private Label proxiesAm;

	private Label label6;

	private PictureBox pictureBox1;

	private Label label7;

	private SiticoneGradientButton siticoneButton3;

	public AuditJoin(string serverLink, string tokens, string proxies, string timeStamp, bool dark, AuditLogForm logForm)
	{
		InitializeComponent();
		sLink.Text = serverLink;
		tamount.Text = tokens;
		proxiesAm.Text = proxies;
		__log = logForm;
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

	private void AuditJoin_Load(object sender, EventArgs e)
	{
	}

	private async void siticoneGradientButton3_Click(object sender, EventArgs e)
	{
		await Task.Delay(50);
		ImpostazioniGlobali.CallbackBridgeAL(0, 0, new object[2] { sLink.Text, null });
		ImpostazioniGlobali.bridgeAct_(0);
		ImpostazioniGlobali.CallbackBridgeAL(1153, 1, null);
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlackSpammerXS.AuditJoin));
		this.label1 = new System.Windows.Forms.Label();
		this.sLink = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.tamount = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.proxiesAm = new System.Windows.Forms.Label();
		this.label6 = new System.Windows.Forms.Label();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.label7 = new System.Windows.Forms.Label();
		this.siticoneButton3 = new SiticoneGradientButton();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Inter Black", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(47, 11);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(57, 25);
		this.label1.TabIndex = 0;
		this.label1.Text = "Join";
		this.sLink.Font = new System.Drawing.Font("SF Pro Text", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.sLink.Location = new System.Drawing.Point(80, 53);
		this.sLink.Name = "sLink";
		this.sLink.Size = new System.Drawing.Size(108, 23);
		this.sLink.TabIndex = 1;
		this.sLink.Text = "Server Link";
		this.sLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.Location = new System.Drawing.Point(15, 57);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(63, 15);
		this.label3.TabIndex = 2;
		this.label3.Text = "Joined in";
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.Location = new System.Drawing.Point(190, 57);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(33, 15);
		this.label2.TabIndex = 3;
		this.label2.Text = "with";
		this.tamount.Font = new System.Drawing.Font("SF Pro Text", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.tamount.Location = new System.Drawing.Point(229, 53);
		this.tamount.Name = "tamount";
		this.tamount.Size = new System.Drawing.Size(52, 23);
		this.tamount.TabIndex = 4;
		this.tamount.Text = "1000";
		this.tamount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.Location = new System.Drawing.Point(285, 57);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(49, 15);
		this.label4.TabIndex = 5;
		this.label4.Text = "tokens";
		this.proxiesAm.Font = new System.Drawing.Font("SF Pro Text", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.proxiesAm.Location = new System.Drawing.Point(54, 81);
		this.proxiesAm.Name = "proxiesAm";
		this.proxiesAm.Size = new System.Drawing.Size(52, 23);
		this.proxiesAm.TabIndex = 6;
		this.proxiesAm.Text = "1000";
		this.proxiesAm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label6.AutoSize = true;
		this.label6.Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label6.Location = new System.Drawing.Point(110, 85);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(56, 15);
		this.label6.TabIndex = 7;
		this.label6.Text = "proxies.";
		this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
		this.pictureBox1.Location = new System.Drawing.Point(17, 11);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(24, 24);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.pictureBox1.TabIndex = 8;
		this.pictureBox1.TabStop = false;
		this.label7.AutoSize = true;
		this.label7.Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label7.Location = new System.Drawing.Point(20, 85);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(30, 15);
		this.label7.TabIndex = 9;
		this.label7.Text = "and";
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
		((System.Windows.Forms.Control)(object)this.siticoneButton3).Location = new System.Drawing.Point(341, 53);
		((System.Windows.Forms.Control)(object)this.siticoneButton3).Name = "siticoneButton3";
		this.siticoneButton3.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneButton3;
		((System.Windows.Forms.Control)(object)this.siticoneButton3).Size = new System.Drawing.Size(247, 38);
		((System.Windows.Forms.Control)(object)this.siticoneButton3).TabIndex = 118;
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
		base.Name = "AuditJoin";
		base.Size = new System.Drawing.Size(591, 124);
		base.Load += new System.EventHandler(AuditJoin_Load);
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
