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

public class AlertFM : Form
{
	private Action<int, int> callback = delegate
	{
	};

	private IContainer components = null;

	private SiticoneElipse siticoneElipse1;

	private SiticoneImageButton siticoneImageButton2;

	private SiticoneImageButton siticoneImageButton3;

	private SiticoneImageButton siticoneImageButton1;

	private SiticoneDragControl siticoneDragControl1;

	private PictureBox pictureBox1;

	private Label label1;

	private Label label2;

	private SiticoneButton siticoneButton1;

	private SiticoneButton annullaBtn;

	private SiticoneShadowForm siticoneShadowForm1;

	public AlertFM(string alert, string title = "Avviso", ContentAlignment contentAlign = ContentAlignment.MiddleCenter)
	{
		InitializeComponent();
		label2.Text = alert;
		label1.Text = title;
		label2.TextAlign = contentAlign;
		if (Settings.Default.dark)
		{
			setDark();
		}
	}

	public AlertFM(Action<int, int> callback, string alert, string title = "Avviso", ContentAlignment contentAlign = ContentAlignment.MiddleCenter)
	{
		InitializeComponent();
		label2.Text = alert;
		label1.Text = title;
		label2.TextAlign = contentAlign;
		this.callback = callback;
		if (Settings.Default.dark)
		{
			setDark();
		}
	}

	public AlertFM(int type, string alert, string title = "Avviso", ContentAlignment contentAlign = ContentAlignment.MiddleCenter)
	{
		InitializeComponent();
		label2.Text = alert;
		label1.Text = title;
		label2.TextAlign = contentAlign;
		if (type == 1)
		{
			setDark();
		}
		if (type == 2)
		{
			setWhite();
		}
	}

	public AlertFM(int type, Action<int, int> callback, string alert, string title = "Avviso", ContentAlignment contentAlign = ContentAlignment.MiddleCenter)
	{
		InitializeComponent();
		label2.Text = alert;
		label1.Text = title;
		label2.TextAlign = contentAlign;
		this.callback = callback;
		if (type == 1)
		{
			setDark();
		}
		if (type == 2)
		{
			setWhite();
		}
	}

	public void setWhite()
	{
		BackColor = Color.White;
		((Control)(object)annullaBtn).BackColor = Color.Snow;
	}

	public void setDark()
	{
		Color backColor = Color.FromArgb(35, 39, 42);
		Color dimGray = Color.DimGray;
		BackColor = backColor;
		label1.ForeColor = Color.White;
		label2.ForeColor = Color.White;
		((Control)(object)annullaBtn).ForeColor = Color.White;
		annullaBtn.FillColor = dimGray;
		annullaBtn.BorderColor = Color.Gray;
	}

	private void siticoneImageButton1_Click(object sender, EventArgs e)
	{
		try
		{
			callback(0, 1);
		}
		catch
		{
		}
		Close();
	}

	private void siticoneButton1_Click(object sender, EventArgs e)
	{
		try
		{
			callback(0, 2);
		}
		catch
		{
		}
		Close();
	}

	private void annullaBtn_Click(object sender, EventArgs e)
	{
		try
		{
			callback(0, 3);
		}
		catch
		{
		}
		Close();
	}

	private void AlertFM_Load(object sender, EventArgs e)
	{
		siticoneShadowForm1.SetShadowForm((Form)this);
		try
		{
			callback(1, 1);
		}
		catch
		{
		}
	}

	private void label1_Click(object sender, EventArgs e)
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
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlackSpammerXS.AlertFM));
		this.siticoneElipse1 = new SiticoneElipse(this.components);
		this.siticoneImageButton2 = new SiticoneImageButton();
		this.siticoneImageButton3 = new SiticoneImageButton();
		this.siticoneImageButton1 = new SiticoneImageButton();
		this.siticoneDragControl1 = new SiticoneDragControl(this.components);
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.label1 = new System.Windows.Forms.Label();
		this.annullaBtn = new SiticoneButton();
		this.siticoneButton1 = new SiticoneButton();
		this.label2 = new System.Windows.Forms.Label();
		this.siticoneShadowForm1 = new SiticoneShadowForm(this.components);
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		base.SuspendLayout();
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
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Location = new System.Drawing.Point(29, 9);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Name = "siticoneImageButton2";
		this.siticoneImageButton2.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton2.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton2;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Size = new System.Drawing.Size(29, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).TabIndex = 92;
		this.siticoneImageButton3.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Cursor = System.Windows.Forms.Cursors.Arrow;
		this.siticoneImageButton3.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image1");
		this.siticoneImageButton3.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		this.siticoneImageButton3.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton3.Image");
		((ImageButton)this.siticoneImageButton3).ImageRotate = 0f;
		this.siticoneImageButton3.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Location = new System.Drawing.Point(50, 9);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Name = "siticoneImageButton3";
		this.siticoneImageButton3.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Size = new System.Drawing.Size(29, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).TabIndex = 91;
		this.siticoneImageButton1.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneImageButton1.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image2");
		this.siticoneImageButton1.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		this.siticoneImageButton1.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton1.Image");
		((ImageButton)this.siticoneImageButton1).ImageRotate = 0f;
		this.siticoneImageButton1.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Location = new System.Drawing.Point(10, 9);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Name = "siticoneImageButton1";
		this.siticoneImageButton1.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Size = new System.Drawing.Size(26, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).TabIndex = 90;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Click += new System.EventHandler(siticoneImageButton1_Click);
		this.siticoneDragControl1.TargetControl = this;
		this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
		this.pictureBox1.Location = new System.Drawing.Point(149, 68);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(48, 48);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.pictureBox1.TabIndex = 93;
		this.pictureBox1.TabStop = false;
		this.label1.Font = new System.Drawing.Font("SF Pro Text", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(10, 125);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(328, 29);
		this.label1.TabIndex = 94;
		this.label1.Text = "Avviso";
		this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label1.Click += new System.EventHandler(label1_Click);
		((System.Windows.Forms.Control)(object)this.annullaBtn).BackColor = System.Drawing.Color.Transparent;
		this.annullaBtn.BorderColor = System.Drawing.Color.LightGray;
		this.annullaBtn.BorderRadius = 4;
		this.annullaBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
		this.annullaBtn.BorderThickness = 1;
		this.annullaBtn.CheckedState.Parent = (CustomButtonBase)(object)this.annullaBtn;
		((System.Windows.Forms.Control)(object)this.annullaBtn).Cursor = System.Windows.Forms.Cursors.Hand;
		this.annullaBtn.CustomImages.Parent = (CustomButtonBase)(object)this.annullaBtn;
		this.annullaBtn.FillColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)(object)this.annullaBtn).Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.annullaBtn).ForeColor = System.Drawing.Color.Black;
		this.annullaBtn.HoveredState.Parent = (CustomButtonBase)(object)this.annullaBtn;
		((System.Windows.Forms.Control)(object)this.annullaBtn).Location = new System.Drawing.Point(12, 277);
		((System.Windows.Forms.Control)(object)this.annullaBtn).Name = "annullaBtn";
		this.annullaBtn.PressedColor = System.Drawing.Color.White;
		this.annullaBtn.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.annullaBtn;
		((System.Windows.Forms.Control)(object)this.annullaBtn).Size = new System.Drawing.Size(326, 29);
		((System.Windows.Forms.Control)(object)this.annullaBtn).TabIndex = 95;
		((System.Windows.Forms.Control)(object)this.annullaBtn).Text = "Annulla";
		this.annullaBtn.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.annullaBtn).Click += new System.EventHandler(annullaBtn_Click);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).BackColor = System.Drawing.Color.Transparent;
		this.siticoneButton1.BorderColor = System.Drawing.Color.DodgerBlue;
		this.siticoneButton1.BorderRadius = 4;
		this.siticoneButton1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
		this.siticoneButton1.BorderThickness = 1;
		this.siticoneButton1.CheckedState.Parent = (CustomButtonBase)(object)this.siticoneButton1;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneButton1.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneButton1;
		this.siticoneButton1.FillColor = System.Drawing.Color.DodgerBlue;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).ForeColor = System.Drawing.Color.White;
		this.siticoneButton1.HoveredState.Parent = (CustomButtonBase)(object)this.siticoneButton1;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Location = new System.Drawing.Point(13, 242);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Name = "siticoneButton1";
		this.siticoneButton1.PressedColor = System.Drawing.Color.White;
		this.siticoneButton1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneButton1;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Size = new System.Drawing.Size(326, 29);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).TabIndex = 96;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Text = "OK";
		this.siticoneButton1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Click += new System.EventHandler(siticoneButton1_Click);
		this.label2.Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.Location = new System.Drawing.Point(13, 163);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(325, 63);
		this.label2.TabIndex = 97;
		this.label2.Text = "Questo è un avviso di BlackSpammer XS";
		this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(351, 321);
		base.Controls.Add(this.label2);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneButton1);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.annullaBtn);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.pictureBox1);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton2);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton3);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "AlertFM";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Avviso";
		base.Load += new System.EventHandler(AlertFM_Load);
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
