using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlackSpammerXS.Properties;
using Siticone.UI.AnimatorNS;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Suite;

namespace BlackSpammerXS;

public class Login : Form
{
	private bool r = true;

	private IContainer components = null;

	private SiticoneDragControl siticoneDragControl1;

	private Label label1;

	private PictureBox pictureBox1;

	private Label label4;

	private SiticoneTextBox passw;

	private SiticoneTextBox usText;

	private SiticoneCustomCheckBox siticoneCustomCheckBox1;

	private SiticoneShadowForm siticoneShadowForm1;

	private SiticoneDragControl siticoneDragControl2;

	private SiticoneDragControl siticoneDragControl3;

	private SiticoneDragControl siticoneDragControl4;

	private Label label2;

	private SiticoneElipse siticoneElipse1;

	private SiticoneButton siticoneGradientButton1;

	private SiticoneImageButton siticoneImageButton1;

	private SiticoneImageButton siticoneImageButton2;

	private SiticoneImageButton siticoneImageButton3;

	private SiticoneTransition siticoneTransition1;

	private Panel panel1;

	private SiticoneDragControl siticoneDragControl5;

	private Label label9;

	public Login(int uaf_t)
	{
		InitializeComponent();
		if (SecurityMT.ch_scr(2111, uaf_t, 0, 0, this) != 291144)
		{
			SecLG.o_wr("err_ch_??? null LG [0, 0]");
			Application.Exit();
		}
	}

	public void Dark()
	{
		Color backColor = Color.FromArgb(44, 47, 51);
		BackColor = backColor;
	}

	private void Login_Load(object sender, EventArgs e)
	{
		siticoneShadowForm1.SetShadowForm((Form)this);
		try
		{
			if (Settings.Default._U != null || Settings.Default._U != "" || Settings.Default._P != null || Settings.Default._P != "")
			{
				((TextBox)usText).Text = Settings.Default._U ?? "";
				((TextBox)passw).Text = SecurityMT.e_dr(Settings.Default._P ?? "", "blackspammerxs");
			}
		}
		catch
		{
		}
		((Animator)siticoneTransition1).Show((Control)panel1, false, (Animation)null);
	}

	private void label2_Click(object sender, EventArgs e)
	{
	}

	private void label1_Click(object sender, EventArgs e)
	{
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
	}

	private async Task<int> Authenticate(string u, string p)
	{
		return 243;
	}

	private async void siticoneButton3_Click(object sender, EventArgs e)
	{
		((Control)(object)siticoneGradientButton1).Text = "Authenticating..";
		((Control)(object)siticoneGradientButton1).Enabled = false;
		((Control)(object)usText).Enabled = false;
		((Control)(object)passw).Enabled = false;
		int o = await Authenticate(((TextBox)usText).Text, ((TextBox)passw).Text);
		if (o != 243)
		{
			((Control)(object)siticoneGradientButton1).Text = "Login";
			((Control)(object)siticoneGradientButton1).Enabled = true;
			((Control)(object)usText).Enabled = true;
			((Control)(object)passw).Enabled = true;
			switch (o)
			{
			case 245:
				MessageBox.ShowWhite("La firma del server non è valida: Invalid Signature", "Errore");
				break;
			case 244:
				MessageBox.ShowWhite("Questa versione di BlackSpammer non è più disponibile", "Errore");
				break;
			case 242:
				MessageBox.ShowWhite("Failed to login. Please try again!", "Login");
				break;
			default:
				MessageBox.ShowWhite("I servers di BlackSpammerXS non sono al momento disponibili", "Errore");
				break;
			}
			return;
		}
		((Control)(object)siticoneGradientButton1).Text = "Authenticated";
		if (r)
		{
			try
			{
				Settings.Default._U = ((TextBox)usText).Text;
				Settings.Default._P = SecurityMT.e_er(((TextBox)passw).Text, "blackspammerxs");
				Settings.Default.Save();
			}
			catch (Exception)
			{
			}
		}
		else
		{
			try
			{
				Settings.Default.Reset();
				Settings.Default.Save();
			}
			catch (Exception)
			{
			}
		}
		int sqn = SecurityMT.reg_sqn(34177u, 63713);
		if (sqn == 0)
		{
			MessageBox.ShowWhite("An error has occurred, please restart. Security Error 0x741784", "Security Manager");
			((Control)(object)siticoneGradientButton1).Text = "Security Error";
			return;
		}
		try
		{
			MessageBox.ShowWhite("BlackSpammer XS V4 has been discontinued.", "Discontinuation Notification");
			new Form1(sqn, sqn / 2, 256447608, this).Show();
		}
		catch (Exception)
		{
			MessageBox.ShowWhite("An error has occurred, please restart. SecErr 0x841", "Security Manager");
			((Control)(object)siticoneGradientButton1).Text = "Security Error";
		}
		Hide();
		try
		{
			base.Controls.Clear();
		}
		catch
		{
		}
	}

	private void siticoneCustomCheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		r = siticoneCustomCheckBox1.Checked;
	}

	private void siticoneButton3_MouseEnter(object sender, EventArgs e)
	{
	}

	private void siticoneButton3_MouseLeave(object sender, EventArgs e)
	{
	}

	private void siticoneGradientButton1_Click(object sender, EventArgs e)
	{
		siticoneButton3_Click(sender, e);
	}

	private void siticoneImageButton1_Click(object sender, EventArgs e)
	{
		Application.Exit();
	}

	private void siticoneImageButton2_Click(object sender, EventArgs e)
	{
		base.WindowState = FormWindowState.Minimized;
	}

	private void panel1_Paint(object sender, PaintEventArgs e)
	{
	}

	private void siticoneImageButton3_Click(object sender, EventArgs e)
	{
	}

	private void usText_TextChanged(object sender, EventArgs e)
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
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected O, but got Unknown
		this.components = new System.ComponentModel.Container();
		Animation val = new Animation();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlackSpammerXS.Login));
		this.siticoneDragControl1 = new SiticoneDragControl(this.components);
		this.label1 = new System.Windows.Forms.Label();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.label4 = new System.Windows.Forms.Label();
		this.passw = new SiticoneTextBox();
		this.siticoneCustomCheckBox1 = new SiticoneCustomCheckBox();
		this.usText = new SiticoneTextBox();
		this.siticoneShadowForm1 = new SiticoneShadowForm(this.components);
		this.siticoneDragControl2 = new SiticoneDragControl(this.components);
		this.siticoneDragControl3 = new SiticoneDragControl(this.components);
		this.siticoneDragControl4 = new SiticoneDragControl(this.components);
		this.label2 = new System.Windows.Forms.Label();
		this.siticoneElipse1 = new SiticoneElipse(this.components);
		this.siticoneGradientButton1 = new SiticoneButton();
		this.siticoneImageButton1 = new SiticoneImageButton();
		this.siticoneImageButton2 = new SiticoneImageButton();
		this.siticoneImageButton3 = new SiticoneImageButton();
		this.siticoneTransition1 = new SiticoneTransition();
		this.panel1 = new System.Windows.Forms.Panel();
		this.siticoneDragControl5 = new SiticoneDragControl(this.components);
		this.label9 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		this.panel1.SuspendLayout();
		base.SuspendLayout();
		this.siticoneDragControl1.TargetControl = this;
		this.label1.AutoSize = true;
		((Animator)this.siticoneTransition1).SetDecoration((System.Windows.Forms.Control)this.label1, (DecorationType)0);
		this.label1.Font = new System.Drawing.Font("Uni Sans Heavy CAPS", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(228, 74);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(150, 19);
		this.label1.TabIndex = 8;
		this.label1.Text = "BLACKSPAMMER XS";
		this.label1.Click += new System.EventHandler(label1_Click);
		((Animator)this.siticoneTransition1).SetDecoration((System.Windows.Forms.Control)this.pictureBox1, (DecorationType)0);
		this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
		this.pictureBox1.Location = new System.Drawing.Point(274, 8);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(50, 50);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox1.TabIndex = 7;
		this.pictureBox1.TabStop = false;
		this.pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
		this.label4.AutoSize = true;
		((Animator)this.siticoneTransition1).SetDecoration((System.Windows.Forms.Control)this.label4, (DecorationType)0);
		this.label4.Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.Location = new System.Drawing.Point(39, 242);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(101, 15);
		this.label4.TabIndex = 56;
		this.label4.Text = "Remember Me";
		this.passw.Animated = false;
		((System.Windows.Forms.Control)(object)this.passw).BackColor = System.Drawing.Color.Transparent;
		this.passw.BorderRadius = 4;
		this.passw.BorderThickness = 2;
		((System.Windows.Forms.Control)(object)this.passw).Cursor = System.Windows.Forms.Cursors.IBeam;
		((Animator)this.siticoneTransition1).SetDecoration((System.Windows.Forms.Control)(object)this.passw, (DecorationType)0);
		((TextBox)this.passw).DefaultText = "";
		this.passw.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		this.passw.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		this.passw.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.passw.DisabledState.Parent = (TextBox)(object)this.passw;
		this.passw.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.passw.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.passw.FocusedState.Parent = (TextBox)(object)this.passw;
		((TextBox)this.passw).Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		((TextBox)this.passw).ForeColor = System.Drawing.Color.Black;
		this.passw.HoveredState.BorderColor = System.Drawing.Color.FromArgb(213, 218, 223);
		this.passw.HoveredState.Parent = (TextBox)(object)this.passw;
		((System.Windows.Forms.Control)(object)this.passw).Location = new System.Drawing.Point(14, 180);
		((System.Windows.Forms.Control)(object)this.passw).Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		((System.Windows.Forms.Control)(object)this.passw).Name = "passw";
		((TextBox)this.passw).PasswordChar = '\0';
		this.passw.PlaceholderText = "Password";
		((TextBox)this.passw).SelectedText = "";
		this.passw.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.passw;
		((System.Windows.Forms.Control)(object)this.passw).Size = new System.Drawing.Size(578, 35);
		((System.Windows.Forms.Control)(object)this.passw).TabIndex = 54;
		((TextBox)this.passw).UseSystemPasswordChar = true;
		this.siticoneCustomCheckBox1.Checked = true;
		this.siticoneCustomCheckBox1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.siticoneCustomCheckBox1.CheckedState.BorderRadius = 2;
		this.siticoneCustomCheckBox1.CheckedState.BorderThickness = 0;
		this.siticoneCustomCheckBox1.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.siticoneCustomCheckBox1.CheckedState.Parent = (CustomCheckBox)(object)this.siticoneCustomCheckBox1;
		this.siticoneCustomCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
		((System.Windows.Forms.Control)(object)this.siticoneCustomCheckBox1).Cursor = System.Windows.Forms.Cursors.Hand;
		((Animator)this.siticoneTransition1).SetDecoration((System.Windows.Forms.Control)(object)this.siticoneCustomCheckBox1, (DecorationType)0);
		((System.Windows.Forms.Control)(object)this.siticoneCustomCheckBox1).Location = new System.Drawing.Point(18, 242);
		((System.Windows.Forms.Control)(object)this.siticoneCustomCheckBox1).Name = "siticoneCustomCheckBox1";
		this.siticoneCustomCheckBox1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneCustomCheckBox1;
		((System.Windows.Forms.Control)(object)this.siticoneCustomCheckBox1).Size = new System.Drawing.Size(15, 15);
		((System.Windows.Forms.Control)(object)this.siticoneCustomCheckBox1).TabIndex = 57;
		this.siticoneCustomCheckBox1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.siticoneCustomCheckBox1.UncheckedState.BorderRadius = 2;
		this.siticoneCustomCheckBox1.UncheckedState.BorderThickness = 0;
		this.siticoneCustomCheckBox1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.siticoneCustomCheckBox1.UncheckedState.Parent = (CustomCheckBox)(object)this.siticoneCustomCheckBox1;
		((CustomCheckBox)this.siticoneCustomCheckBox1).CheckedChanged += new System.EventHandler(siticoneCustomCheckBox1_CheckedChanged);
		this.usText.Animated = false;
		((System.Windows.Forms.Control)(object)this.usText).BackColor = System.Drawing.Color.Transparent;
		this.usText.BorderRadius = 4;
		this.usText.BorderThickness = 2;
		((System.Windows.Forms.Control)(object)this.usText).Cursor = System.Windows.Forms.Cursors.IBeam;
		((Animator)this.siticoneTransition1).SetDecoration((System.Windows.Forms.Control)(object)this.usText, (DecorationType)0);
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
		((System.Windows.Forms.Control)(object)this.usText).Location = new System.Drawing.Point(14, 140);
		((System.Windows.Forms.Control)(object)this.usText).Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		((System.Windows.Forms.Control)(object)this.usText).Name = "usText";
		((TextBox)this.usText).PasswordChar = '\0';
		this.usText.PlaceholderText = "Username";
		((TextBox)this.usText).SelectedText = "";
		this.usText.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.usText;
		((System.Windows.Forms.Control)(object)this.usText).Size = new System.Drawing.Size(578, 34);
		((System.Windows.Forms.Control)(object)this.usText).TabIndex = 58;
		((TextBox)this.usText).TextChanged += new System.EventHandler(usText_TextChanged);
		this.siticoneDragControl2.TargetControl = this.label1;
		this.siticoneDragControl3.TargetControl = null;
		this.siticoneDragControl4.TargetControl = this.pictureBox1;
		this.label2.AutoSize = true;
		((Animator)this.siticoneTransition1).SetDecoration((System.Windows.Forms.Control)this.label2, (DecorationType)0);
		this.label2.Font = new System.Drawing.Font("Inter Black", 9.749999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
		this.label2.Location = new System.Drawing.Point(248, 94);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(130, 16);
		this.label2.TabIndex = 59;
		this.label2.Text = "V4 DISCONTINUED";
		this.siticoneElipse1.TargetControl = this;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).BackColor = System.Drawing.Color.Transparent;
		this.siticoneGradientButton1.BorderColor = System.Drawing.Color.LightGray;
		this.siticoneGradientButton1.BorderRadius = 4;
		this.siticoneGradientButton1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
		this.siticoneGradientButton1.BorderThickness = 1;
		this.siticoneGradientButton1.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.siticoneGradientButton1.CheckedState.Parent = (CustomButtonBase)(object)this.siticoneGradientButton1;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneGradientButton1.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneGradientButton1;
		((Animator)this.siticoneTransition1).SetDecoration((System.Windows.Forms.Control)(object)this.siticoneGradientButton1, (DecorationType)0);
		this.siticoneGradientButton1.FillColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).Font = new System.Drawing.Font("SF Pro Text", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).ForeColor = System.Drawing.Color.Black;
		this.siticoneGradientButton1.HoveredState.Parent = (CustomButtonBase)(object)this.siticoneGradientButton1;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).Location = new System.Drawing.Point(14, 284);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).Name = "siticoneGradientButton1";
		this.siticoneGradientButton1.PressedColor = System.Drawing.Color.White;
		this.siticoneGradientButton1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneGradientButton1;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).Size = new System.Drawing.Size(578, 33);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).TabIndex = 55;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).Text = "Login";
		this.siticoneGradientButton1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).Click += new System.EventHandler(siticoneButton3_Click);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).MouseEnter += new System.EventHandler(siticoneButton3_MouseEnter);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).MouseLeave += new System.EventHandler(siticoneButton3_MouseLeave);
		this.siticoneImageButton1.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Cursor = System.Windows.Forms.Cursors.Hand;
		((Animator)this.siticoneTransition1).SetDecoration((System.Windows.Forms.Control)(object)this.siticoneImageButton1, (DecorationType)0);
		this.siticoneImageButton1.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image2");
		this.siticoneImageButton1.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		this.siticoneImageButton1.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton1.Image");
		((ImageButton)this.siticoneImageButton1).ImageRotate = 0f;
		this.siticoneImageButton1.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Location = new System.Drawing.Point(7, 3);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Name = "siticoneImageButton1";
		this.siticoneImageButton1.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Size = new System.Drawing.Size(26, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).TabIndex = 74;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Click += new System.EventHandler(siticoneImageButton1_Click);
		this.siticoneImageButton2.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton2;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Cursor = System.Windows.Forms.Cursors.Hand;
		((Animator)this.siticoneTransition1).SetDecoration((System.Windows.Forms.Control)(object)this.siticoneImageButton2, (DecorationType)0);
		this.siticoneImageButton2.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image1");
		this.siticoneImageButton2.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton2.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton2;
		this.siticoneImageButton2.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton2.Image");
		((ImageButton)this.siticoneImageButton2).ImageRotate = 0f;
		this.siticoneImageButton2.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton2.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Location = new System.Drawing.Point(26, 3);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Name = "siticoneImageButton2";
		this.siticoneImageButton2.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton2.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton2;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Size = new System.Drawing.Size(29, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).TabIndex = 75;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Click += new System.EventHandler(siticoneImageButton2_Click);
		this.siticoneImageButton3.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Cursor = System.Windows.Forms.Cursors.Arrow;
		((Animator)this.siticoneTransition1).SetDecoration((System.Windows.Forms.Control)(object)this.siticoneImageButton3, (DecorationType)0);
		this.siticoneImageButton3.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image");
		this.siticoneImageButton3.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		this.siticoneImageButton3.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton3.Image");
		((ImageButton)this.siticoneImageButton3).ImageRotate = 0f;
		this.siticoneImageButton3.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Location = new System.Drawing.Point(47, 3);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Name = "siticoneImageButton3";
		this.siticoneImageButton3.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Size = new System.Drawing.Size(29, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).TabIndex = 76;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Click += new System.EventHandler(siticoneImageButton3_Click);
		((Animator)this.siticoneTransition1).AnimationType = (AnimationType)8;
		((Animator)this.siticoneTransition1).Cursor = null;
		val.AnimateOnlyDifferences = true;
		val.BlindCoeff = (System.Drawing.PointF)resources.GetObject("animation3.BlindCoeff");
		val.LeafCoeff = 0f;
		val.MaxTime = 1f;
		val.MinTime = 0f;
		val.MosaicCoeff = (System.Drawing.PointF)resources.GetObject("animation3.MosaicCoeff");
		val.MosaicShift = (System.Drawing.PointF)resources.GetObject("animation3.MosaicShift");
		val.MosaicSize = 0;
		val.Padding = new System.Windows.Forms.Padding(0);
		val.RotateCoeff = 0f;
		val.RotateLimit = 0f;
		val.ScaleCoeff = (System.Drawing.PointF)resources.GetObject("animation3.ScaleCoeff");
		val.SlideCoeff = (System.Drawing.PointF)resources.GetObject("animation3.SlideCoeff");
		val.TimeCoeff = 0f;
		val.TransparencyCoeff = 1f;
		((Animator)this.siticoneTransition1).DefaultAnimation = val;
		((Animator)this.siticoneTransition1).Interval = 1;
		((Animator)this.siticoneTransition1).MaxAnimationTime = 1000;
		this.panel1.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneGradientButton1);
		this.panel1.Controls.Add(this.pictureBox1);
		this.panel1.Controls.Add(this.label1);
		this.panel1.Controls.Add((System.Windows.Forms.Control)(object)this.passw);
		this.panel1.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneCustomCheckBox1);
		this.panel1.Controls.Add(this.label2);
		this.panel1.Controls.Add(this.label4);
		this.panel1.Controls.Add((System.Windows.Forms.Control)(object)this.usText);
		((Animator)this.siticoneTransition1).SetDecoration((System.Windows.Forms.Control)this.panel1, (DecorationType)0);
		this.panel1.Location = new System.Drawing.Point(2, 30);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(615, 330);
		this.panel1.TabIndex = 77;
		this.panel1.Visible = false;
		this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		this.siticoneDragControl5.TargetControl = this.panel1;
		this.label9.AutoSize = true;
		((Animator)this.siticoneTransition1).SetDecoration((System.Windows.Forms.Control)this.label9, (DecorationType)0);
		this.label9.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label9.Location = new System.Drawing.Point(502, 10);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(104, 14);
		this.label9.TabIndex = 60;
		this.label9.Text = "Developer Mode";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(617, 363);
		base.Controls.Add(this.label9);
		base.Controls.Add(this.panel1);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton3);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton2);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton1);
		((Animator)this.siticoneTransition1).SetDecoration((System.Windows.Forms.Control)this, (DecorationType)0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Login";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Login";
		base.Load += new System.EventHandler(Login_Load);
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
