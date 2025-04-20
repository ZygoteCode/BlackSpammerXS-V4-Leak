using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using BlackSpammerXS.Properties;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Suite;

namespace BlackSpammerXS;

public class ChcapKM : Form
{
	private IContainer components = null;

	private SiticoneShadowForm siticoneShadowForm1;

	private SiticoneAnimateWindow siticoneAnimateWindow1;

	private Label label1;

	private SiticoneTextBox usText;

	private SiticoneButton siticoneButton6;

	private SiticoneToggleSwitch hastwocap;

	private Label label2;

	private SiticoneToggleSwitch hascapmon;

	private Label del;

	private SiticoneElipse siticoneElipse1;

	private SiticoneImageButton siticoneImageButton2;

	private SiticoneImageButton siticoneImageButton3;

	private SiticoneImageButton siticoneImageButton1;

	public ChcapKM()
	{
		InitializeComponent();
	}

	private void siticoneControlBox1_Click(object sender, EventArgs e)
	{
		ImpostazioniGlobali.bridgeAct_(0);
	}

	private void ChcapKM_Load(object sender, EventArgs e)
	{
		siticoneShadowForm1.SetShadowForm((Form)this);
		siticoneAnimateWindow1.SetAnimateWindow((Form)this);
		if (Settings.Default.dark)
		{
			Color color = Color.FromArgb(44, 47, 51);
			Color dimGray = Color.DimGray;
			BackColor = color;
			label1.ForeColor = Color.White;
			label2.ForeColor = Color.White;
			del.ForeColor = Color.White;
			((Control)(object)siticoneButton6).ForeColor = Color.White;
			siticoneButton6.FillColor = dimGray;
			siticoneButton6.BorderColor = Color.Gray;
			((TextBox)usText).ForeColor = Color.White;
			usText.FillColor = color;
			usText.BorderColor = Color.Gray;
			usText.HoveredState.BorderColor = Color.Gray;
		}
	}

	private void siticoneButton6_Click(object sender, EventArgs e)
	{
		if (hascapmon.Checked)
		{
			Settings.Default.capkeyCAPmon = ((TextBox)usText).Text;
			ImpostazioniGlobali.CaptchaKey_SMSACT = ((TextBox)usText).Text;
		}
		else
		{
			Settings.Default.capkeyTWOcap = ((TextBox)usText).Text;
			ImpostazioniGlobali.CaptchaKey_TWO = ((TextBox)usText).Text;
		}
		Settings.Default.Save();
		Settings.Default.Reload();
		ImpostazioniGlobali.bridgeAct_(0);
		Close();
	}

	private void hasDelay_Click(object sender, EventArgs e)
	{
		hastwocap.Checked = false;
		usText.PlaceholderText = "SmsActivate Key";
	}

	private void tdel_Click(object sender, EventArgs e)
	{
		hascapmon.Checked = false;
		usText.PlaceholderText = "Captcha Key";
	}

	private void hastwocap_CheckedChanged(object sender, EventArgs e)
	{
		if (!hastwocap.Checked)
		{
			hastwocap.Checked = true;
		}
	}

	private void siticoneImageButton1_Click(object sender, EventArgs e)
	{
		siticoneControlBox1_Click(sender, e);
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
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlackSpammerXS.ChcapKM));
		this.siticoneShadowForm1 = new SiticoneShadowForm(this.components);
		this.siticoneAnimateWindow1 = new SiticoneAnimateWindow(this.components);
		this.label1 = new System.Windows.Forms.Label();
		this.usText = new SiticoneTextBox();
		this.siticoneButton6 = new SiticoneButton();
		this.hastwocap = new SiticoneToggleSwitch();
		this.label2 = new System.Windows.Forms.Label();
		this.hascapmon = new SiticoneToggleSwitch();
		this.del = new System.Windows.Forms.Label();
		this.siticoneElipse1 = new SiticoneElipse(this.components);
		this.siticoneImageButton2 = new SiticoneImageButton();
		this.siticoneImageButton3 = new SiticoneImageButton();
		this.siticoneImageButton1 = new SiticoneImageButton();
		base.SuspendLayout();
		this.siticoneAnimateWindow1.AnimationType = (AnimateWindowType)262144;
		this.siticoneAnimateWindow1.Interval = 300;
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("SF Pro Text", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(152, 14);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(104, 18);
		this.label1.TabIndex = 1;
		this.label1.Text = "Captcha Key";
		this.usText.Animated = false;
		((System.Windows.Forms.Control)(object)this.usText).BackColor = System.Drawing.Color.Transparent;
		this.usText.BorderRadius = 4;
		this.usText.BorderThickness = 2;
		((System.Windows.Forms.Control)(object)this.usText).Cursor = System.Windows.Forms.Cursors.IBeam;
		((TextBox)this.usText).DefaultText = "";
		this.usText.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		this.usText.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		this.usText.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.usText.DisabledState.Parent = (TextBox)(object)this.usText;
		this.usText.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.usText.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.usText.FocusedState.Parent = (TextBox)(object)this.usText;
		((TextBox)this.usText).Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		((TextBox)this.usText).ForeColor = System.Drawing.Color.Black;
		this.usText.HoveredState.BorderColor = System.Drawing.Color.FromArgb(213, 218, 223);
		this.usText.HoveredState.Parent = (TextBox)(object)this.usText;
		((System.Windows.Forms.Control)(object)this.usText).Location = new System.Drawing.Point(12, 68);
		((System.Windows.Forms.Control)(object)this.usText).Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		((System.Windows.Forms.Control)(object)this.usText).Name = "usText";
		((TextBox)this.usText).PasswordChar = '\0';
		this.usText.PlaceholderText = "Captcha Key";
		((TextBox)this.usText).SelectedText = "";
		this.usText.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.usText;
		((System.Windows.Forms.Control)(object)this.usText).Size = new System.Drawing.Size(395, 40);
		((System.Windows.Forms.Control)(object)this.usText).TabIndex = 59;
		((System.Windows.Forms.Control)(object)this.siticoneButton6).BackColor = System.Drawing.Color.Transparent;
		this.siticoneButton6.BorderColor = System.Drawing.Color.LightGray;
		this.siticoneButton6.BorderRadius = 4;
		this.siticoneButton6.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
		this.siticoneButton6.BorderThickness = 1;
		this.siticoneButton6.CheckedState.Parent = (CustomButtonBase)(object)this.siticoneButton6;
		((System.Windows.Forms.Control)(object)this.siticoneButton6).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneButton6.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneButton6;
		this.siticoneButton6.FillColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)(object)this.siticoneButton6).Font = new System.Drawing.Font("SF Pro Text", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneButton6).ForeColor = System.Drawing.Color.Black;
		this.siticoneButton6.HoveredState.Parent = (CustomButtonBase)(object)this.siticoneButton6;
		((System.Windows.Forms.Control)(object)this.siticoneButton6).Location = new System.Drawing.Point(12, 221);
		((System.Windows.Forms.Control)(object)this.siticoneButton6).Name = "siticoneButton6";
		this.siticoneButton6.PressedColor = System.Drawing.Color.White;
		this.siticoneButton6.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneButton6;
		((System.Windows.Forms.Control)(object)this.siticoneButton6).Size = new System.Drawing.Size(395, 43);
		((System.Windows.Forms.Control)(object)this.siticoneButton6).TabIndex = 60;
		((System.Windows.Forms.Control)(object)this.siticoneButton6).Text = "Save";
		this.siticoneButton6.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.siticoneButton6).Click += new System.EventHandler(siticoneButton6_Click);
		this.hastwocap.Checked = true;
		this.hastwocap.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hastwocap.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hastwocap.CheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.hastwocap.CheckedState.InnerColor = System.Drawing.Color.White;
		this.hastwocap.CheckedState.Parent = (ToggleSwitch)(object)this.hastwocap;
		((System.Windows.Forms.Control)(object)this.hastwocap).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.hastwocap).Location = new System.Drawing.Point(15, 162);
		((System.Windows.Forms.Control)(object)this.hastwocap).Name = "hastwocap";
		this.hastwocap.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.hastwocap;
		((System.Windows.Forms.Control)(object)this.hastwocap).Size = new System.Drawing.Size(32, 20);
		((System.Windows.Forms.Control)(object)this.hastwocap).TabIndex = 64;
		this.hastwocap.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hastwocap.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hastwocap.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.hastwocap.UncheckedState.InnerColor = System.Drawing.Color.White;
		this.hastwocap.UncheckedState.Parent = (ToggleSwitch)(object)this.hastwocap;
		((ToggleSwitch)this.hastwocap).CheckedChanged += new System.EventHandler(hastwocap_CheckedChanged);
		((System.Windows.Forms.Control)(object)this.hastwocap).Click += new System.EventHandler(tdel_Click);
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.Location = new System.Drawing.Point(50, 165);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(66, 14);
		this.label2.TabIndex = 63;
		this.label2.Text = "2Captcha";
		this.hascapmon.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hascapmon.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hascapmon.CheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.hascapmon.CheckedState.InnerColor = System.Drawing.Color.White;
		this.hascapmon.CheckedState.Parent = (ToggleSwitch)(object)this.hascapmon;
		((System.Windows.Forms.Control)(object)this.hascapmon).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.hascapmon).Enabled = false;
		((System.Windows.Forms.Control)(object)this.hascapmon).Location = new System.Drawing.Point(15, 135);
		((System.Windows.Forms.Control)(object)this.hascapmon).Name = "hascapmon";
		this.hascapmon.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.hascapmon;
		((System.Windows.Forms.Control)(object)this.hascapmon).Size = new System.Drawing.Size(32, 20);
		((System.Windows.Forms.Control)(object)this.hascapmon).TabIndex = 62;
		this.hascapmon.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hascapmon.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hascapmon.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.hascapmon.UncheckedState.InnerColor = System.Drawing.Color.White;
		this.hascapmon.UncheckedState.Parent = (ToggleSwitch)(object)this.hascapmon;
		((System.Windows.Forms.Control)(object)this.hascapmon).Click += new System.EventHandler(hasDelay_Click);
		this.del.AutoSize = true;
		this.del.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.del.Location = new System.Drawing.Point(50, 139);
		this.del.Name = "del";
		this.del.Size = new System.Drawing.Size(83, 14);
		this.del.TabIndex = 61;
		this.del.Text = "SmsActivate";
		this.siticoneElipse1.TargetControl = this;
		this.siticoneImageButton2.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton2;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Cursor = System.Windows.Forms.Cursors.Arrow;
		this.siticoneImageButton2.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image");
		this.siticoneImageButton2.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton2.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton2;
		this.siticoneImageButton2.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton2.Image");
		((ImageButton)this.siticoneImageButton2).ImageRotate = 0f;
		this.siticoneImageButton2.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton2.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Location = new System.Drawing.Point(30, 6);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Name = "siticoneImageButton2";
		this.siticoneImageButton2.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton2.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton2;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Size = new System.Drawing.Size(29, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).TabIndex = 86;
		this.siticoneImageButton3.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Cursor = System.Windows.Forms.Cursors.Arrow;
		this.siticoneImageButton3.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image1");
		this.siticoneImageButton3.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		this.siticoneImageButton3.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton3.Image");
		((ImageButton)this.siticoneImageButton3).ImageRotate = 0f;
		this.siticoneImageButton3.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Location = new System.Drawing.Point(51, 6);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Name = "siticoneImageButton3";
		this.siticoneImageButton3.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Size = new System.Drawing.Size(29, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).TabIndex = 85;
		this.siticoneImageButton1.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneImageButton1.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image2");
		this.siticoneImageButton1.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		this.siticoneImageButton1.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton1.Image");
		((ImageButton)this.siticoneImageButton1).ImageRotate = 0f;
		this.siticoneImageButton1.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Location = new System.Drawing.Point(11, 6);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Name = "siticoneImageButton1";
		this.siticoneImageButton1.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Size = new System.Drawing.Size(26, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).TabIndex = 84;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Click += new System.EventHandler(siticoneImageButton1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(419, 276);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton2);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton3);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton1);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.hastwocap);
		base.Controls.Add(this.label2);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.hascapmon);
		base.Controls.Add(this.del);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneButton6);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.usText);
		base.Controls.Add(this.label1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "ChcapKM";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "ChcapKM";
		base.Load += new System.EventHandler(ChcapKM_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
