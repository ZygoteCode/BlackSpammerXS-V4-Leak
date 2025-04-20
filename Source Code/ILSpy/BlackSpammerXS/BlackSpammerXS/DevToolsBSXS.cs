using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlackSpammerXS.Properties;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Suite;

namespace BlackSpammerXS;

public class DevToolsBSXS : Form
{
	private OpacityFull opacity;

	private IContainer components = null;

	private SiticoneElipse siticoneElipse1;

	private Label label1;

	private SiticoneImageButton siticoneImageButton2;

	private SiticoneImageButton siticoneImageButton3;

	private SiticoneImageButton siticoneImageButton1;

	private SiticoneTextBox usText;

	private SiticoneButton siticoneButton2;

	private SiticoneButton siticoneButton1;

	private SiticoneButton siticoneGradientButton1;

	private Label label5;

	private SiticoneButton siticoneButton3;

	public DevToolsBSXS(OpacityFull opacity, bool dark)
	{
		InitializeComponent();
		this.opacity = opacity;
		if (!dark)
		{
			return;
		}
		label1.ForeColor = Color.White;
		label5.ForeColor = Color.White;
		Color fillColor = (BackColor = Color.FromArgb(44, 47, 51));
		SiticoneTextBox val = usText;
		((TextBox)val).ForeColor = Color.White;
		val.FillColor = fillColor;
		val.BorderColor = Color.Gray;
		val.HoveredState.BorderColor = Color.Gray;
		List<SiticoneButton> list = new List<SiticoneButton> { siticoneButton1, siticoneButton2, siticoneGradientButton1, siticoneButton3 };
		Color dimGray = Color.DimGray;
		foreach (SiticoneButton item in list)
		{
			try
			{
				((Control)(object)item).ForeColor = Color.White;
				item.FillColor = dimGray;
				item.BorderColor = Color.Gray;
			}
			catch (Exception)
			{
			}
		}
	}

	private void DevToolsBSXS_Load(object sender, EventArgs e)
	{
		try
		{
			label5.Text = "BlackSpammer XS V4 17X" + Environment.NewLine + "Debug Length: 0" + Environment.NewLine + "XCP Length: " + ImpostazioniGlobali.XCP_Default.Length + Environment.NewLine + "Audit Length: " + Settings.Default.audit.Length + Environment.NewLine + "Log CL Interval: " + ImpostazioniGlobali.log_interval_cl;
		}
		catch (Exception)
		{
		}
	}

	private void siticoneButton3_Click(object sender, EventArgs e)
	{
	}

	private void siticoneImageButton1_Click(object sender, EventArgs e)
	{
		opacity.Close();
		Close();
	}

	private void siticoneButton1_Click(object sender, EventArgs e)
	{
		if (ImpostazioniGlobali.WS_LogBasic)
		{
			ImpostazioniGlobali.WS_LogBasic = false;
		}
		else
		{
			ImpostazioniGlobali.WS_LogBasic = true;
		}
	}

	private async void siticoneGradientButton1_Click(object sender, EventArgs e)
	{
		((Control)(object)siticoneGradientButton1).Enabled = false;
		if (!((TextBox)usText).Text.StartsWith("cmd_t"))
		{
			try
			{
				ImpostazioniGlobali.Tokens.Clear();
			}
			catch (Exception)
			{
				ImpostazioniGlobali.Tokens = new List<string>();
			}
			ImpostazioniGlobali.Tokens.Add(((TextBox)usText).Text);
			ImpostazioniGlobali.CallbackBridgeAL(3699, 1601, new object[0]);
		}
		else if (((TextBox)usText).Text.StartsWith("cmd_t dev_log_interval="))
		{
			try
			{
				string i_log_nw = ((TextBox)usText).Text.Replace("cmd_t dev_log_interval=", "");
				ImpostazioniGlobali.log_interval_cl = int.Parse(i_log_nw);
				((TextBox)usText).Text = "[cmd_t] Success. New interval: " + ImpostazioniGlobali.log_interval_cl;
			}
			catch
			{
				((TextBox)usText).Text = "[cmd_t] An error has occurred.";
			}
		}
		else
		{
			((TextBox)usText).Text = "[cmd_t] Unknown developer command.";
		}
		await Task.Delay(300);
		((Control)(object)siticoneGradientButton1).Enabled = true;
	}

	private void siticoneButton2_Click(object sender, EventArgs e)
	{
		((Control)(object)siticoneButton2).Enabled = false;
		Control.CheckForIllegalCrossThreadCalls = false;
		new Thread((ParameterizedThreadStart)async delegate
		{
			Control.CheckForIllegalCrossThreadCalls = false;
			HttpClient http = new HttpClient();
			string a = "";
			try
			{
				HttpResponseMessage c = await http.GetAsync("https://naoko.fun");
				string b = await c.Content.ReadAsStringAsync();
				int s = (int)c.StatusCode;
				KeyValuePair<string, IEnumerable<string>>[] u = ((IEnumerable<KeyValuePair<string, IEnumerable<string>>>)c.Headers).ToArray();
				a = "URL: https://naoko.fun" + Environment.NewLine + "Status: " + s + Environment.NewLine + "Headers Length: " + u.Length + Environment.NewLine + "Response: " + b;
			}
			catch (Exception ex)
			{
				Exception ee = ex;
				a = "URL: https://naoko.fun" + Environment.NewLine + "Error: True" + Environment.NewLine + "Exception: " + ee.Message;
			}
			Invoke((MethodInvoker)delegate
			{
				GTextRes gTextRes = new GTextRes(a, opacity, Settings.Default.dark);
				gTextRes.Show();
				gTextRes.Focus();
				Close();
			});
		}).Start();
	}

	private void siticoneButton3_Click_1(object sender, EventArgs e)
	{
		try
		{
			DevConsole devConsole = new DevConsole();
			devConsole.Show();
			opacity.Close();
			Close();
		}
		catch (Exception)
		{
			MessageBox.Show("Si è verificato un errore. Puoi riprovare?", "Developer Tools");
		}
	}

	private void label5_Click(object sender, EventArgs e)
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
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlackSpammerXS.DevToolsBSXS));
		this.siticoneElipse1 = new SiticoneElipse(this.components);
		this.label1 = new System.Windows.Forms.Label();
		this.siticoneImageButton2 = new SiticoneImageButton();
		this.siticoneImageButton3 = new SiticoneImageButton();
		this.siticoneImageButton1 = new SiticoneImageButton();
		this.usText = new SiticoneTextBox();
		this.siticoneGradientButton1 = new SiticoneButton();
		this.siticoneButton1 = new SiticoneButton();
		this.siticoneButton2 = new SiticoneButton();
		this.label5 = new System.Windows.Forms.Label();
		this.siticoneButton3 = new SiticoneButton();
		base.SuspendLayout();
		this.siticoneElipse1.TargetControl = this;
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("SF Pro Text", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(168, 9);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(128, 18);
		this.label1.TabIndex = 66;
		this.label1.Text = "Developer Tools";
		this.siticoneImageButton2.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton2;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Cursor = System.Windows.Forms.Cursors.Arrow;
		this.siticoneImageButton2.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image");
		this.siticoneImageButton2.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton2.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton2;
		this.siticoneImageButton2.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton2.Image");
		((ImageButton)this.siticoneImageButton2).ImageRotate = 0f;
		this.siticoneImageButton2.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton2.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Location = new System.Drawing.Point(29, 5);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Name = "siticoneImageButton2";
		this.siticoneImageButton2.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton2.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton2;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Size = new System.Drawing.Size(29, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).TabIndex = 105;
		this.siticoneImageButton3.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Cursor = System.Windows.Forms.Cursors.Arrow;
		this.siticoneImageButton3.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image1");
		this.siticoneImageButton3.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		this.siticoneImageButton3.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton3.Image");
		((ImageButton)this.siticoneImageButton3).ImageRotate = 0f;
		this.siticoneImageButton3.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Location = new System.Drawing.Point(50, 5);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Name = "siticoneImageButton3";
		this.siticoneImageButton3.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Size = new System.Drawing.Size(29, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).TabIndex = 104;
		this.siticoneImageButton1.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneImageButton1.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image2");
		this.siticoneImageButton1.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		this.siticoneImageButton1.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton1.Image");
		((ImageButton)this.siticoneImageButton1).ImageRotate = 0f;
		this.siticoneImageButton1.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Location = new System.Drawing.Point(10, 5);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Name = "siticoneImageButton1";
		this.siticoneImageButton1.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Size = new System.Drawing.Size(26, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).TabIndex = 103;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Click += new System.EventHandler(siticoneImageButton1_Click);
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
		((System.Windows.Forms.Control)(object)this.usText).Location = new System.Drawing.Point(10, 137);
		((System.Windows.Forms.Control)(object)this.usText).Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		((System.Windows.Forms.Control)(object)this.usText).Name = "usText";
		((TextBox)this.usText).PasswordChar = '\0';
		this.usText.PlaceholderText = "Test Token";
		((TextBox)this.usText).SelectedText = "";
		this.usText.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.usText;
		((System.Windows.Forms.Control)(object)this.usText).Size = new System.Drawing.Size(464, 40);
		((System.Windows.Forms.Control)(object)this.usText).TabIndex = 110;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).BackColor = System.Drawing.Color.Transparent;
		this.siticoneGradientButton1.BorderColor = System.Drawing.Color.LightGray;
		this.siticoneGradientButton1.BorderRadius = 4;
		this.siticoneGradientButton1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
		this.siticoneGradientButton1.BorderThickness = 1;
		this.siticoneGradientButton1.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.siticoneGradientButton1.CheckedState.Parent = (CustomButtonBase)(object)this.siticoneGradientButton1;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneGradientButton1.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneGradientButton1;
		this.siticoneGradientButton1.FillColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).Font = new System.Drawing.Font("SF Pro Text", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).ForeColor = System.Drawing.Color.Black;
		this.siticoneGradientButton1.HoveredState.Parent = (CustomButtonBase)(object)this.siticoneGradientButton1;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).Location = new System.Drawing.Point(10, 184);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).Name = "siticoneGradientButton1";
		this.siticoneGradientButton1.PressedColor = System.Drawing.Color.White;
		this.siticoneGradientButton1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneGradientButton1;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).Size = new System.Drawing.Size(464, 33);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).TabIndex = 111;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).Text = "Set Test Token";
		this.siticoneGradientButton1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).Click += new System.EventHandler(siticoneGradientButton1_Click);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).BackColor = System.Drawing.Color.Transparent;
		this.siticoneButton1.BorderColor = System.Drawing.Color.LightGray;
		this.siticoneButton1.BorderRadius = 4;
		this.siticoneButton1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
		this.siticoneButton1.BorderThickness = 1;
		this.siticoneButton1.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.siticoneButton1.CheckedState.Parent = (CustomButtonBase)(object)this.siticoneButton1;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneButton1.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneButton1;
		this.siticoneButton1.FillColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Font = new System.Drawing.Font("SF Pro Text", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).ForeColor = System.Drawing.Color.Black;
		this.siticoneButton1.HoveredState.Parent = (CustomButtonBase)(object)this.siticoneButton1;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Location = new System.Drawing.Point(10, 296);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Name = "siticoneButton1";
		this.siticoneButton1.PressedColor = System.Drawing.Color.White;
		this.siticoneButton1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneButton1;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Size = new System.Drawing.Size(465, 33);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).TabIndex = 112;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Text = "WS Testing Tools";
		this.siticoneButton1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Click += new System.EventHandler(siticoneButton1_Click);
		((System.Windows.Forms.Control)(object)this.siticoneButton2).BackColor = System.Drawing.Color.Transparent;
		this.siticoneButton2.BorderColor = System.Drawing.Color.LightGray;
		this.siticoneButton2.BorderRadius = 4;
		this.siticoneButton2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
		this.siticoneButton2.BorderThickness = 1;
		this.siticoneButton2.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.siticoneButton2.CheckedState.Parent = (CustomButtonBase)(object)this.siticoneButton2;
		((System.Windows.Forms.Control)(object)this.siticoneButton2).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneButton2.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneButton2;
		this.siticoneButton2.FillColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)(object)this.siticoneButton2).Font = new System.Drawing.Font("SF Pro Text", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneButton2).ForeColor = System.Drawing.Color.Black;
		this.siticoneButton2.HoveredState.Parent = (CustomButtonBase)(object)this.siticoneButton2;
		((System.Windows.Forms.Control)(object)this.siticoneButton2).Location = new System.Drawing.Point(9, 258);
		((System.Windows.Forms.Control)(object)this.siticoneButton2).Name = "siticoneButton2";
		this.siticoneButton2.PressedColor = System.Drawing.Color.White;
		this.siticoneButton2.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneButton2;
		((System.Windows.Forms.Control)(object)this.siticoneButton2).Size = new System.Drawing.Size(465, 33);
		((System.Windows.Forms.Control)(object)this.siticoneButton2).TabIndex = 113;
		((System.Windows.Forms.Control)(object)this.siticoneButton2).Text = "Server Status";
		this.siticoneButton2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.siticoneButton2).Click += new System.EventHandler(siticoneButton2_Click);
		this.label5.AutoSize = true;
		this.label5.Font = new System.Drawing.Font("JetBrains Mono", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label5.Location = new System.Drawing.Point(12, 44);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(152, 85);
		this.label5.TabIndex = 114;
		this.label5.Text = "BlackSpammer XS V4\r\nDebug Length: 0\r\nXCP Length: 0\r\nAudit Length: 0\r\nLog CL Interval: 0";
		this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.label5.Click += new System.EventHandler(label5_Click);
		((System.Windows.Forms.Control)(object)this.siticoneButton3).BackColor = System.Drawing.Color.Transparent;
		this.siticoneButton3.BorderColor = System.Drawing.Color.LightGray;
		this.siticoneButton3.BorderRadius = 4;
		this.siticoneButton3.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
		this.siticoneButton3.BorderThickness = 1;
		this.siticoneButton3.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.siticoneButton3.CheckedState.Parent = (CustomButtonBase)(object)this.siticoneButton3;
		((System.Windows.Forms.Control)(object)this.siticoneButton3).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneButton3.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneButton3;
		this.siticoneButton3.FillColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)(object)this.siticoneButton3).Font = new System.Drawing.Font("SF Pro Text", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneButton3).ForeColor = System.Drawing.Color.Black;
		this.siticoneButton3.HoveredState.Parent = (CustomButtonBase)(object)this.siticoneButton3;
		((System.Windows.Forms.Control)(object)this.siticoneButton3).Location = new System.Drawing.Point(9, 221);
		((System.Windows.Forms.Control)(object)this.siticoneButton3).Name = "siticoneButton3";
		this.siticoneButton3.PressedColor = System.Drawing.Color.White;
		this.siticoneButton3.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneButton3;
		((System.Windows.Forms.Control)(object)this.siticoneButton3).Size = new System.Drawing.Size(464, 33);
		((System.Windows.Forms.Control)(object)this.siticoneButton3).TabIndex = 115;
		((System.Windows.Forms.Control)(object)this.siticoneButton3).Text = "Open Developer Console";
		this.siticoneButton3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.siticoneButton3).Click += new System.EventHandler(siticoneButton3_Click_1);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(487, 339);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneButton3);
		base.Controls.Add(this.label5);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneButton2);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneButton1);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneGradientButton1);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.usText);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton2);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton3);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton1);
		base.Controls.Add(this.label1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "DevToolsBSXS";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "DevToolsBSXS";
		base.Load += new System.EventHandler(DevToolsBSXS_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
