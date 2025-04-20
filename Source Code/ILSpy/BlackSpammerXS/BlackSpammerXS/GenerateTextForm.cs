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

public class GenerateTextForm : Form
{
	private OpacityFull opacity;

	private bool isdark;

	private IContainer components = null;

	private Label label2;

	private Label del;

	private SiticoneTextBox usText;

	private Label label1;

	private Label label3;

	private SiticoneCustomCheckBox hasRand;

	private SiticoneCustomCheckBox hasMTX;

	private SiticoneCustomCheckBox hasCount;

	private SiticoneShadowForm siticoneShadowForm1;

	private SiticoneAnimateWindow siticoneAnimateWindow1;

	private SiticoneElipse siticoneElipse1;

	private SiticoneImageButton siticoneImageButton2;

	private SiticoneImageButton siticoneImageButton3;

	private SiticoneImageButton siticoneImageButton1;

	private SiticoneGradientButton siticoneGradientButton5;

	private SiticoneDragControl siticoneDragControl1;

	public GenerateTextForm(OpacityFull opacityBack, bool dark)
	{
		InitializeComponent();
		opacity = opacityBack;
		isdark = dark;
		siticoneShadowForm1.SetShadowForm((Form)this);
		siticoneAnimateWindow1.SetAnimateWindow((Form)this);
		if (!dark)
		{
			return;
		}
		Color fillColor = (BackColor = Color.FromArgb(44, 47, 51));
		Color dimGray = Color.DimGray;
		SiticoneTextBox val = usText;
		((TextBox)val).ForeColor = Color.White;
		val.FillColor = fillColor;
		val.BorderColor = Color.Gray;
		val.HoveredState.BorderColor = Color.Gray;
		List<Label> list = new List<Label> { label1, label2, label3, del };
		foreach (Label item in list)
		{
			item.ForeColor = Color.White;
		}
	}

	private async void siticoneGradientButton5_Click(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(((TextBox)usText).Text))
		{
			return;
		}
		int am;
		try
		{
			am = int.Parse(((TextBox)usText).Text);
			if (am > 100)
			{
				throw new Exception("Numero troppo grande");
			}
		}
		catch (Exception)
		{
			return;
		}
		((Control)(object)siticoneGradientButton5).Enabled = false;
		((TextBox)usText).ReadOnly = true;
		((Control)(object)siticoneGradientButton5).Text = "Generating..";
		await Task.Delay(100);
		try
		{
			string finalText = "";
			if (hasMTX.Checked)
			{
				for (int a = 0; a < am + 1; a++)
				{
					finalText = finalText + "[mtag" + a + "]";
				}
			}
			if (hasRand.Checked)
			{
				for (int i = 0; i < am + 1; i++)
				{
					finalText += "[rand]";
				}
			}
			if (hasCount.Checked)
			{
				for (int j = 0; j < am + 1; j++)
				{
					finalText += "[count]";
				}
			}
			ImpostazioniGlobali.bridgeAct_(0);
			OpacityFull opacityFull = new OpacityFull();
			opacityFull.Show();
			GTextRes gTextRes = new GTextRes(finalText, opacityFull, isdark);
			gTextRes.Show();
			gTextRes.Focus();
			Close();
		}
		catch (Exception)
		{
			ImpostazioniGlobali.Log("GenerateText => Ops! Something went wrong: 0x7311");
		}
	}

	private void siticoneControlBox1_Click(object sender, EventArgs e)
	{
		ImpostazioniGlobali.bridgeAct_(0);
		Close();
	}

	private void hastwocap_CheckedChanged(object sender, EventArgs e)
	{
	}

	private async void siticoneToggleSwitch1_Click(object sender, EventArgs e)
	{
	}

	private void GenerateTextForm_Load(object sender, EventArgs e)
	{
	}

	private void siticoneImageButton1_Click(object sender, EventArgs e)
	{
		siticoneControlBox1_Click(sender, e);
	}

	private void siticoneButton7_Click(object sender, EventArgs e)
	{
		siticoneGradientButton5_Click(sender, e);
	}

	private void siticoneImageButton2_Click(object sender, EventArgs e)
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
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlackSpammerXS.GenerateTextForm));
		this.label2 = new System.Windows.Forms.Label();
		this.del = new System.Windows.Forms.Label();
		this.usText = new SiticoneTextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.hasRand = new SiticoneCustomCheckBox();
		this.hasMTX = new SiticoneCustomCheckBox();
		this.hasCount = new SiticoneCustomCheckBox();
		this.siticoneShadowForm1 = new SiticoneShadowForm(this.components);
		this.siticoneAnimateWindow1 = new SiticoneAnimateWindow(this.components);
		this.siticoneElipse1 = new SiticoneElipse(this.components);
		this.siticoneImageButton2 = new SiticoneImageButton();
		this.siticoneImageButton3 = new SiticoneImageButton();
		this.siticoneImageButton1 = new SiticoneImageButton();
		this.siticoneGradientButton5 = new SiticoneGradientButton();
		this.siticoneDragControl1 = new SiticoneDragControl(this.components);
		base.SuspendLayout();
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.Location = new System.Drawing.Point(34, 125);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(38, 14);
		this.label2.TabIndex = 69;
		this.label2.Text = "Rand";
		this.del.AutoSize = true;
		this.del.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.del.Location = new System.Drawing.Point(35, 103);
		this.del.Name = "del";
		this.del.Size = new System.Drawing.Size(64, 14);
		this.del.TabIndex = 68;
		this.del.Text = "Mass Tag";
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
		((System.Windows.Forms.Control)(object)this.usText).Location = new System.Drawing.Point(12, 45);
		((System.Windows.Forms.Control)(object)this.usText).Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		((System.Windows.Forms.Control)(object)this.usText).Name = "usText";
		((TextBox)this.usText).PasswordChar = '\0';
		this.usText.PlaceholderText = "1, 2, 3...";
		((TextBox)this.usText).SelectedText = "";
		this.usText.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.usText;
		((System.Windows.Forms.Control)(object)this.usText).Size = new System.Drawing.Size(497, 40);
		((System.Windows.Forms.Control)(object)this.usText).TabIndex = 66;
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("SF Pro Text", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(194, 11);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(114, 18);
		this.label1.TabIndex = 65;
		this.label1.Text = "Generate Text";
		this.label3.AccessibleDescription = "s";
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.Location = new System.Drawing.Point(34, 147);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(44, 14);
		this.label3.TabIndex = 96;
		this.label3.Text = "Count";
		((System.Windows.Forms.Control)(object)this.hasRand).BackColor = System.Drawing.Color.Transparent;
		this.hasRand.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasRand.CheckedState.BorderRadius = 2;
		this.hasRand.CheckedState.BorderThickness = 0;
		this.hasRand.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasRand.CheckedState.Parent = (CustomCheckBox)(object)this.hasRand;
		((System.Windows.Forms.Control)(object)this.hasRand).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.hasRand).Location = new System.Drawing.Point(15, 123);
		((System.Windows.Forms.Control)(object)this.hasRand).Name = "hasRand";
		this.hasRand.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.hasRand;
		((System.Windows.Forms.Control)(object)this.hasRand).Size = new System.Drawing.Size(15, 15);
		((System.Windows.Forms.Control)(object)this.hasRand).TabIndex = 98;
		this.hasRand.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasRand.UncheckedState.BorderRadius = 2;
		this.hasRand.UncheckedState.BorderThickness = 0;
		this.hasRand.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasRand.UncheckedState.Parent = (CustomCheckBox)(object)this.hasRand;
		this.hasMTX.Checked = true;
		this.hasMTX.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasMTX.CheckedState.BorderRadius = 2;
		this.hasMTX.CheckedState.BorderThickness = 0;
		this.hasMTX.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasMTX.CheckedState.Parent = (CustomCheckBox)(object)this.hasMTX;
		this.hasMTX.CheckState = System.Windows.Forms.CheckState.Checked;
		((System.Windows.Forms.Control)(object)this.hasMTX).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.hasMTX).Location = new System.Drawing.Point(15, 102);
		((System.Windows.Forms.Control)(object)this.hasMTX).Name = "hasMTX";
		this.hasMTX.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.hasMTX;
		((System.Windows.Forms.Control)(object)this.hasMTX).Size = new System.Drawing.Size(15, 15);
		((System.Windows.Forms.Control)(object)this.hasMTX).TabIndex = 97;
		this.hasMTX.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasMTX.UncheckedState.BorderRadius = 2;
		this.hasMTX.UncheckedState.BorderThickness = 0;
		this.hasMTX.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasMTX.UncheckedState.Parent = (CustomCheckBox)(object)this.hasMTX;
		this.hasCount.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasCount.CheckedState.BorderRadius = 2;
		this.hasCount.CheckedState.BorderThickness = 0;
		this.hasCount.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasCount.CheckedState.Parent = (CustomCheckBox)(object)this.hasCount;
		((System.Windows.Forms.Control)(object)this.hasCount).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.hasCount).Location = new System.Drawing.Point(15, 145);
		((System.Windows.Forms.Control)(object)this.hasCount).Name = "hasCount";
		this.hasCount.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.hasCount;
		((System.Windows.Forms.Control)(object)this.hasCount).Size = new System.Drawing.Size(15, 15);
		((System.Windows.Forms.Control)(object)this.hasCount).TabIndex = 99;
		this.hasCount.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasCount.UncheckedState.BorderRadius = 2;
		this.hasCount.UncheckedState.BorderThickness = 0;
		this.hasCount.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasCount.UncheckedState.Parent = (CustomCheckBox)(object)this.hasCount;
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
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Location = new System.Drawing.Point(26, 5);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Name = "siticoneImageButton2";
		this.siticoneImageButton2.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton2.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton2;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Size = new System.Drawing.Size(29, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).TabIndex = 102;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Click += new System.EventHandler(siticoneImageButton2_Click);
		this.siticoneImageButton3.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Cursor = System.Windows.Forms.Cursors.Arrow;
		this.siticoneImageButton3.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image1");
		this.siticoneImageButton3.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		this.siticoneImageButton3.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton3.Image");
		((ImageButton)this.siticoneImageButton3).ImageRotate = 0f;
		this.siticoneImageButton3.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Location = new System.Drawing.Point(47, 5);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Name = "siticoneImageButton3";
		this.siticoneImageButton3.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Size = new System.Drawing.Size(29, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).TabIndex = 101;
		this.siticoneImageButton1.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneImageButton1.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image2");
		this.siticoneImageButton1.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		this.siticoneImageButton1.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton1.Image");
		((ImageButton)this.siticoneImageButton1).ImageRotate = 0f;
		this.siticoneImageButton1.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Location = new System.Drawing.Point(7, 5);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Name = "siticoneImageButton1";
		this.siticoneImageButton1.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Size = new System.Drawing.Size(26, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).TabIndex = 100;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Click += new System.EventHandler(siticoneImageButton1_Click);
		this.siticoneGradientButton5.BorderRadius = 18;
		((ButtonState)this.siticoneGradientButton5.CheckedState).Parent = (CustomButtonBase)(object)this.siticoneGradientButton5;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton5).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneGradientButton5.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneGradientButton5;
		this.siticoneGradientButton5.FillColor = System.Drawing.Color.DodgerBlue;
		this.siticoneGradientButton5.FillColor2 = System.Drawing.Color.DeepSkyBlue;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton5).Font = new System.Drawing.Font("SF Pro Text", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton5).ForeColor = System.Drawing.Color.White;
		((ButtonState)this.siticoneGradientButton5.HoveredState).Parent = (CustomButtonBase)(object)this.siticoneGradientButton5;
		this.siticoneGradientButton5.Image = (System.Drawing.Image)resources.GetObject("siticoneGradientButton5.Image");
		this.siticoneGradientButton5.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.siticoneGradientButton5.ImageOffset = new System.Drawing.Point(6, -1);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton5).Location = new System.Drawing.Point(15, 181);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton5).Name = "siticoneGradientButton5";
		this.siticoneGradientButton5.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneGradientButton5;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton5).Size = new System.Drawing.Size(494, 38);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton5).TabIndex = 103;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton5).Text = "Generate";
		this.siticoneGradientButton5.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton5).Click += new System.EventHandler(siticoneButton7_Click);
		this.siticoneDragControl1.TargetControl = this;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(521, 231);
		base.ControlBox = false;
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneGradientButton5);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton2);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton3);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton1);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.hasCount);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.hasRand);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.hasMTX);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.del);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.usText);
		base.Controls.Add(this.label1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "GenerateTextForm";
		base.ShowIcon = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "GenerateText";
		base.Load += new System.EventHandler(GenerateTextForm_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
