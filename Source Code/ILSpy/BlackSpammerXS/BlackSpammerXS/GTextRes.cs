using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Suite;

namespace BlackSpammerXS;

public class GTextRes : Form
{
	private OpacityFull opacity;

	private IContainer components = null;

	private SiticoneTextBox usText;

	private Label label1;

	private SiticoneShadowForm siticoneShadowForm1;

	private SiticoneAnimateWindow siticoneAnimateWindow1;

	private SiticoneElipse siticoneElipse1;

	private SiticoneImageButton siticoneImageButton2;

	private SiticoneImageButton siticoneImageButton3;

	private SiticoneImageButton siticoneImageButton1;

	public GTextRes(string _res, OpacityFull opacity, bool dark)
	{
		InitializeComponent();
		((TextBox)usText).Text = _res;
		this.opacity = opacity;
		if (dark)
		{
			label1.ForeColor = Color.White;
			Color fillColor = (BackColor = Color.FromArgb(44, 47, 51));
			Color dimGray = Color.DimGray;
			SiticoneTextBox val = usText;
			((TextBox)val).ForeColor = Color.White;
			val.FillColor = fillColor;
			val.BorderColor = Color.Gray;
			val.HoveredState.BorderColor = Color.Gray;
		}
	}

	private void GTextRes_Load(object sender, EventArgs e)
	{
		siticoneShadowForm1.SetShadowForm((Form)this);
		siticoneAnimateWindow1.SetAnimateWindow((Form)this);
	}

	private void siticoneControlBox1_Click(object sender, EventArgs e)
	{
		ImpostazioniGlobali.bridgeAct_(0);
		opacity.Close();
	}

	private void label1_Click(object sender, EventArgs e)
	{
	}

	private void siticoneImageButton1_Click(object sender, EventArgs e)
	{
		siticoneControlBox1_Click(sender, e);
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
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlackSpammerXS.GTextRes));
		this.usText = new SiticoneTextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.siticoneShadowForm1 = new SiticoneShadowForm(this.components);
		this.siticoneAnimateWindow1 = new SiticoneAnimateWindow(this.components);
		this.siticoneElipse1 = new SiticoneElipse(this.components);
		this.siticoneImageButton2 = new SiticoneImageButton();
		this.siticoneImageButton3 = new SiticoneImageButton();
		this.siticoneImageButton1 = new SiticoneImageButton();
		base.SuspendLayout();
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
		((TextBox)this.usText).Font = new System.Drawing.Font("JetBrains Mono", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		((TextBox)this.usText).ForeColor = System.Drawing.Color.Black;
		this.usText.HoveredState.BorderColor = System.Drawing.Color.FromArgb(213, 218, 223);
		this.usText.HoveredState.Parent = (TextBox)(object)this.usText;
		((System.Windows.Forms.Control)(object)this.usText).Location = new System.Drawing.Point(12, 44);
		((TextBox)this.usText).Multiline = true;
		((System.Windows.Forms.Control)(object)this.usText).Name = "usText";
		((TextBox)this.usText).PasswordChar = '\0';
		this.usText.PlaceholderText = "Result will appear here";
		((TextBox)this.usText).ReadOnly = true;
		((TextBox)this.usText).SelectedText = "";
		this.usText.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.usText;
		((System.Windows.Forms.Control)(object)this.usText).Size = new System.Drawing.Size(623, 326);
		((System.Windows.Forms.Control)(object)this.usText).TabIndex = 67;
		this.label1.Font = new System.Drawing.Font("SF Pro Text", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(130, 13);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(382, 18);
		this.label1.TabIndex = 69;
		this.label1.Text = "View Result";
		this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label1.Click += new System.EventHandler(label1_Click);
		this.siticoneAnimateWindow1.AnimationType = (AnimateWindowType)262144;
		this.siticoneAnimateWindow1.Interval = 300;
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
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Location = new System.Drawing.Point(34, 9);
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
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Location = new System.Drawing.Point(55, 9);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Name = "siticoneImageButton3";
		this.siticoneImageButton3.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Size = new System.Drawing.Size(29, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).TabIndex = 85;
		this.siticoneImageButton1.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneImageButton1.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image1");
		this.siticoneImageButton1.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		this.siticoneImageButton1.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton1.Image");
		((ImageButton)this.siticoneImageButton1).ImageRotate = 0f;
		this.siticoneImageButton1.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Location = new System.Drawing.Point(15, 9);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Name = "siticoneImageButton1";
		this.siticoneImageButton1.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Size = new System.Drawing.Size(26, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).TabIndex = 84;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Click += new System.EventHandler(siticoneImageButton1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(647, 382);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton2);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton3);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton1);
		base.Controls.Add(this.label1);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.usText);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "GTextRes";
		base.ShowIcon = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "GTextRes";
		base.Load += new System.EventHandler(GTextRes_Load);
		base.ResumeLayout(false);
	}
}
