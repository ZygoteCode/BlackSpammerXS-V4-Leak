using System;
using System.ComponentModel;
using System.Drawing;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Enums;
using Siticone.UI.WinForms.Suite;

namespace BlackSpammerXS;

public class LoadingCVF : Form
{
	private OpacityFull full;

	private IContainer components = null;

	private Label label1;

	private SiticoneCircleProgressBar siticoneCircleProgressBar1;

	private SiticoneShadowForm siticoneShadowForm1;

	private PictureBox pictureBox1;

	private SiticoneElipse siticoneElipse1;

	private SiticoneImageButton siticoneImageButton1;

	private SiticoneImageButton siticoneImageButton2;

	private SiticoneImageButton siticoneImageButton3;

	public LoadingCVF(OpacityFull opacityFull, bool dark)
	{
		InitializeComponent();
		full = opacityFull;
		siticoneShadowForm1.SetShadowForm((Form)this);
		if (dark)
		{
			label1.ForeColor = Color.White;
			siticoneCircleProgressBar1.FillColor = Color.DimGray;
			siticoneCircleProgressBar1.ProgressColor = Color.Aqua;
			Color backColor = Color.FromArgb(44, 47, 51);
			BackColor = backColor;
		}
	}

	private async void LoadingCVF_Load(object sender, EventArgs e)
	{
		pictureBox1.Location = new Point(232, 57);
		pictureBox1.Visible = false;
		Control.CheckForIllegalCrossThreadCalls = false;
		new Thread((ParameterizedThreadStart)async delegate
		{
			Control.CheckForIllegalCrossThreadCalls = false;
			HttpClient http = new HttpClient();
			try
			{
				JObject.Parse(await (await http.GetAsync("https://naoko.fun/api/v4/blackspammer/v3/xs/developer/devmode")).Content.ReadAsStringAsync());
				try
				{
					((Control)(object)siticoneCircleProgressBar1).Visible = false;
					pictureBox1.Visible = true;
					await Task.Delay(700);
					ImpostazioniGlobali.CallbackBridgeAL(4727417, 1, new object[0]);
					full.Close();
					Close();
				}
				catch
				{
				}
			}
			catch (Exception)
			{
				full.Close();
				Close();
			}
		}).Start();
	}

	private void siticoneControlBox1_Click(object sender, EventArgs e)
	{
		full.Close();
	}

	private void siticoneImageButton1_Click(object sender, EventArgs e)
	{
		full.Close();
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
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlackSpammerXS.LoadingCVF));
		this.label1 = new System.Windows.Forms.Label();
		this.siticoneCircleProgressBar1 = new SiticoneCircleProgressBar();
		this.siticoneShadowForm1 = new SiticoneShadowForm(this.components);
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.siticoneElipse1 = new SiticoneElipse(this.components);
		this.siticoneImageButton1 = new SiticoneImageButton();
		this.siticoneImageButton3 = new SiticoneImageButton();
		this.siticoneImageButton2 = new SiticoneImageButton();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("SF Pro Text", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(177, 8);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(173, 18);
		this.label1.TabIndex = 3;
		this.label1.Text = "Developer Connection";
		this.label1.Visible = false;
		this.siticoneCircleProgressBar1.Animated = true;
		this.siticoneCircleProgressBar1.AnimationSpeed = 3f;
		this.siticoneCircleProgressBar1.FillThickness = 2;
		((System.Windows.Forms.Control)(object)this.siticoneCircleProgressBar1).Location = new System.Drawing.Point(238, 69);
		((System.Windows.Forms.Control)(object)this.siticoneCircleProgressBar1).Name = "siticoneCircleProgressBar1";
		this.siticoneCircleProgressBar1.ProgressThickness = 2;
		this.siticoneCircleProgressBar1.ShadowDecoration.Mode = (ShadowMode)1;
		this.siticoneCircleProgressBar1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneCircleProgressBar1;
		((System.Windows.Forms.Control)(object)this.siticoneCircleProgressBar1).Size = new System.Drawing.Size(32, 32);
		((System.Windows.Forms.Control)(object)this.siticoneCircleProgressBar1).TabIndex = 4;
		this.siticoneCircleProgressBar1.Value = 30;
		this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
		this.pictureBox1.Location = new System.Drawing.Point(356, 51);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(48, 50);
		this.pictureBox1.TabIndex = 5;
		this.pictureBox1.TabStop = false;
		this.siticoneElipse1.TargetControl = this;
		this.siticoneImageButton1.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneImageButton1.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image");
		this.siticoneImageButton1.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		this.siticoneImageButton1.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton1.Image");
		((ImageButton)this.siticoneImageButton1).ImageRotate = 0f;
		this.siticoneImageButton1.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Location = new System.Drawing.Point(7, 2);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Name = "siticoneImageButton1";
		this.siticoneImageButton1.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Size = new System.Drawing.Size(26, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).TabIndex = 80;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Click += new System.EventHandler(siticoneImageButton1_Click);
		this.siticoneImageButton3.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Cursor = System.Windows.Forms.Cursors.Arrow;
		this.siticoneImageButton3.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image1");
		this.siticoneImageButton3.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		this.siticoneImageButton3.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton3.Image");
		((ImageButton)this.siticoneImageButton3).ImageRotate = 0f;
		this.siticoneImageButton3.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Location = new System.Drawing.Point(47, 2);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Name = "siticoneImageButton3";
		this.siticoneImageButton3.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Size = new System.Drawing.Size(29, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).TabIndex = 82;
		this.siticoneImageButton2.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton2;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Cursor = System.Windows.Forms.Cursors.Arrow;
		this.siticoneImageButton2.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image");
		this.siticoneImageButton2.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton2.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton2;
		this.siticoneImageButton2.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton2.Image");
		((ImageButton)this.siticoneImageButton2).ImageRotate = 0f;
		this.siticoneImageButton2.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton2.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Location = new System.Drawing.Point(26, 2);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Name = "siticoneImageButton2";
		this.siticoneImageButton2.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton2.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton2;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Size = new System.Drawing.Size(29, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).TabIndex = 83;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(524, 159);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton2);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton3);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton1);
		base.Controls.Add(this.pictureBox1);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneCircleProgressBar1);
		base.Controls.Add(this.label1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "LoadingCVF";
		base.ShowIcon = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "LoadingCVF";
		base.Load += new System.EventHandler(LoadingCVF_Load);
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
