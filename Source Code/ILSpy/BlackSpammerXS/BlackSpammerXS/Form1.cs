using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlackSpammerXS.Properties;
using Bunifu.Framework.UI;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Enums;
using Siticone.UI.WinForms.Suite;

namespace BlackSpammerXS;

public class Form1 : Form
{
	private IContainer components = null;

	private SiticoneShadowForm siticoneShadowForm1;

	private SiticoneDragControl siticoneDragControl1;

	private SiticonePanel siticonePanel1;

	private SiticoneDragControl siticoneDragControl2;

	private SiticoneButton siticoneButton4;

	private SiticoneButton siticoneButton3;

	private SiticoneButton siticoneButton2;

	private SiticoneButton siticoneButton1;

	private Label label2;

	private Label label1;

	private PictureBox pictureBox1;

	private SiticoneDragControl siticoneDragControl3;

	private SiticoneDragControl siticoneDragControl4;

	private SiticoneDragControl siticoneDragControl5;

	private SiticonePanel siticonePanel2;

	private SiticoneDragControl siticoneDragControl6;

	private SiticoneDragControl siticoneDragControl7;

	private Dashboard dashboard1;

	private BunifuDragControl bunifuDragControl1;

	private GuildManager guildManager1;

	private ServerSpammer serverSpammer1;

	private ReactionSpammer reactionSpammer1;

	private SiticoneButton siticoneButton6;

	private AdvancedSettings advancedSettings1;

	private SiticoneGradientButton siticoneGradientButton1;

	private Label label3;

	private SiticoneElipse siticoneElipse1;

	private SiticoneImageButton siticoneImageButton3;

	private SiticoneImageButton siticoneImageButton2;

	private SiticoneImageButton siticoneImageButton1;

	private SiticoneButton siticoneButton5;

	private WebsocketManager websocketManager1;

	public Form1(int __sqn, int add_of, int ct, Login f_origin)
	{
		InitializeComponent();
		if (f_origin == null || SecurityMT.ch_scr(__sqn - 63554, GetHashCode() / 241, ct, 63554, this) != 287059)
		{
			SecLG.o_wr("secr err 94178");
			Application.Exit();
			return;
		}
		Task.Run(delegate
		{
			try
			{
				Thread.Sleep(1000);
				f_origin.Dispose();
			}
			catch
			{
			}
			try
			{
				Thread.Sleep(1000);
				f_origin.Close();
			}
			catch
			{
			}
		});
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		siticoneShadowForm1.SetShadowForm((Form)this);
		dashboard1.BringToFront();
		try
		{
			label3.Text = Settings.Default._U.ToUpper();
		}
		catch (Exception)
		{
		}
		if (Settings.Default.dark)
		{
			SwitchTheme(a: true);
			advancedSettings1.Switch();
		}
		ImpostazioniGlobali.CaptchaKey_SMSACT = Settings.Default.capkeyCAPmon;
		ImpostazioniGlobali.CaptchaKey_TWO = Settings.Default.capkeyTWOcap;
		ImpostazioniGlobali.auditManager = new AuditManager();
		ImpostazioniGlobali._bridgeLogPerform.Add(delegate(int a, int b, object[] i)
		{
			if (a == 1153)
			{
				if (b == 0)
				{
					dashboard1.BringToFront();
					((CustomButtonBase)siticoneButton1).PerformClick();
				}
				if (b == 1)
				{
					guildManager1.BringToFront();
					((CustomButtonBase)siticoneButton4).PerformClick();
				}
				if (b == 2)
				{
					serverSpammer1.BringToFront();
					((CustomButtonBase)siticoneButton3).PerformClick();
				}
				if (b == 3)
				{
					reactionSpammer1.BringToFront();
					((CustomButtonBase)siticoneButton2).PerformClick();
				}
			}
		});
	}

	private async void dashboard1_Load(object sender, EventArgs e)
	{
		bool at = false;
		int lt = 0;
		int lp = 0;
		if (Settings.Default.lastProxies != "")
		{
			at = true;
			await Task.Run(delegate
			{
				try
				{
					using StreamReader streamReader = new StreamReader(Settings.Default.lastProxies);
					List<string> list = new List<string>();
					string item;
					while ((item = streamReader.ReadLine()) != null)
					{
						list.Add(item);
					}
					ImpostazioniGlobali.Proxies = list;
					Control.CheckForIllegalCrossThreadCalls = false;
					dashboard1.SetProxies(list.Count);
					lp = list.Count;
					Control.CheckForIllegalCrossThreadCalls = true;
				}
				catch (Exception)
				{
				}
			});
		}
		if (Settings.Default.lastTokens != "")
		{
			at = true;
			await Task.Run(delegate
			{
				try
				{
					using StreamReader streamReader2 = new StreamReader(Settings.Default.lastTokens);
					List<string> list2 = new List<string>();
					string item2;
					while ((item2 = streamReader2.ReadLine()) != null)
					{
						list2.Add(item2);
					}
					ImpostazioniGlobali.Tokens = list2;
					Control.CheckForIllegalCrossThreadCalls = false;
					dashboard1.SetTokens(list2.Count);
					lt = list2.Count;
					Control.CheckForIllegalCrossThreadCalls = true;
				}
				catch (Exception)
				{
				}
			});
		}
		if (at)
		{
		}
		try
		{
			ImpostazioniGlobali._themeCallback = SwitchTheme;
		}
		catch (Exception)
		{
		}
	}

	public void Light()
	{
		ImpostazioniGlobali.LoggerDark = false;
		Settings.Default.dark = false;
		Settings.Default.Save();
		try
		{
			double opacity = base.Opacity + 0.0;
			base.Opacity = 0.0;
			base.Controls.Clear();
			InitializeComponent();
			base.Opacity = opacity;
		}
		catch (Exception)
		{
			Application.Restart();
		}
	}

	public void SwitchTheme(bool a)
	{
		if (!a)
		{
			Light();
			return;
		}
		Color color = Color.FromArgb(35, 39, 42);
		Color color2 = Color.FromArgb(44, 47, 51);
		try
		{
			BackColor = color;
			((Control)(object)siticonePanel1).BackColor = color;
			foreach (Control control in base.Controls)
			{
				try
				{
					control.ForeColor = Color.White;
					if (!(control is Label))
					{
						control.BackColor = color;
					}
				}
				catch (Exception)
				{
				}
			}
			List<SiticoneButton> list = new List<SiticoneButton>();
			list.Add(siticoneButton1);
			list.Add(siticoneButton2);
			list.Add(siticoneButton3);
			list.Add(siticoneButton4);
			list.Add(siticoneButton6);
			list.Add(siticoneButton5);
			foreach (SiticoneButton item in list)
			{
				try
				{
					((Control)(object)item).ForeColor = Color.White;
					item.FillColor = color;
					item.CheckedState.FillColor = color;
				}
				catch (Exception)
				{
				}
			}
			dashboard1.Dark();
			guildManager1.Dark();
			serverSpammer1.Dark();
			reactionSpammer1.Dark();
			advancedSettings1.Dark();
			websocketManager1.Dark();
			ImpostazioniGlobali.LoggerDark = true;
			Settings.Default.dark = true;
			Settings.Default.Save();
		}
		catch (Exception)
		{
		}
	}

	private void siticoneButton1_Click(object sender, EventArgs e)
	{
		if (siticoneButton1.Checked)
		{
			dashboard1.BringToFront();
		}
	}

	private void siticoneButton4_Click(object sender, EventArgs e)
	{
		if (siticoneButton4.Checked)
		{
			guildManager1.BringToFront();
		}
	}

	private void siticoneButton3_Click(object sender, EventArgs e)
	{
		if (siticoneButton3.Checked)
		{
			serverSpammer1.BringToFront();
		}
	}

	private void siticoneButton2_Click(object sender, EventArgs e)
	{
		if (siticoneButton2.Checked)
		{
			reactionSpammer1.BringToFront();
		}
	}

	private void siticonePanel1_Paint(object sender, PaintEventArgs e)
	{
	}

	private void siticoneControlBox2_Click(object sender, EventArgs e)
	{
		Application.Exit();
	}

	private void siticoneButton5_Click(object sender, EventArgs e)
	{
		Settings.Default.Reset();
		Settings.Default.Save();
		Application.Restart();
	}

	private void siticoneButton6_Click(object sender, EventArgs e)
	{
		advancedSettings1.BringToFront();
	}

	private void label1_Click(object sender, EventArgs e)
	{
	}

	private void siticoneGradientButton1_Click(object sender, EventArgs e)
	{
		MessageBox.Show(delegate(int a, int b)
		{
			if (a == 0 && b == 2)
			{
				Settings.Default.Reset();
				Settings.Default.Save();
				Application.Restart();
			}
		}, "Sei sicuro di voler uscire? Questo comporterà un reset totale.", "Logout");
	}

	private void siticoneImageButton1_Click(object sender, EventArgs e)
	{
		try
		{
			Process.GetCurrentProcess().Kill();
		}
		catch
		{
		}
		try
		{
			Application.Exit();
		}
		catch
		{
		}
	}

	private void siticoneImageButton2_Click(object sender, EventArgs e)
	{
		base.WindowState = FormWindowState.Minimized;
	}

	private void siticoneButton5_Click_1(object sender, EventArgs e)
	{
		websocketManager1.BringToFront();
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
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected O, but got Unknown
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlackSpammerXS.Form1));
		this.siticoneShadowForm1 = new SiticoneShadowForm(this.components);
		this.siticoneDragControl1 = new SiticoneDragControl(this.components);
		this.siticonePanel1 = new SiticonePanel();
		this.siticoneButton5 = new SiticoneButton();
		this.siticoneImageButton3 = new SiticoneImageButton();
		this.siticoneImageButton2 = new SiticoneImageButton();
		this.siticoneImageButton1 = new SiticoneImageButton();
		this.label3 = new System.Windows.Forms.Label();
		this.siticoneGradientButton1 = new SiticoneGradientButton();
		this.siticoneButton6 = new SiticoneButton();
		this.label2 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.siticoneButton4 = new SiticoneButton();
		this.siticoneButton3 = new SiticoneButton();
		this.siticoneButton2 = new SiticoneButton();
		this.siticoneButton1 = new SiticoneButton();
		this.siticoneDragControl2 = new SiticoneDragControl(this.components);
		this.siticoneDragControl3 = new SiticoneDragControl(this.components);
		this.siticoneDragControl4 = new SiticoneDragControl(this.components);
		this.siticoneDragControl5 = new SiticoneDragControl(this.components);
		this.siticonePanel2 = new SiticonePanel();
		this.dashboard1 = new BlackSpammerXS.Dashboard();
		this.guildManager1 = new BlackSpammerXS.GuildManager();
		this.serverSpammer1 = new BlackSpammerXS.ServerSpammer();
		this.reactionSpammer1 = new BlackSpammerXS.ReactionSpammer();
		this.advancedSettings1 = new BlackSpammerXS.AdvancedSettings();
		this.websocketManager1 = new BlackSpammerXS.WebsocketManager();
		this.siticoneDragControl6 = new SiticoneDragControl(this.components);
		this.siticoneDragControl7 = new SiticoneDragControl(this.components);
		this.bunifuDragControl1 = new BunifuDragControl(this.components);
		this.siticoneElipse1 = new SiticoneElipse(this.components);
		((System.Windows.Forms.Control)(object)this.siticonePanel1).SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		((System.Windows.Forms.Control)(object)this.siticonePanel2).SuspendLayout();
		base.SuspendLayout();
		this.siticoneDragControl1.TargetControl = this;
		((System.Windows.Forms.Control)(object)this.siticonePanel1).BackColor = System.Drawing.SystemColors.Control;
		((System.Windows.Forms.Control)(object)this.siticonePanel1).Controls.Add((System.Windows.Forms.Control)(object)this.siticoneButton5);
		((System.Windows.Forms.Control)(object)this.siticonePanel1).Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton3);
		((System.Windows.Forms.Control)(object)this.siticonePanel1).Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton2);
		((System.Windows.Forms.Control)(object)this.siticonePanel1).Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton1);
		((System.Windows.Forms.Control)(object)this.siticonePanel1).Controls.Add(this.label3);
		((System.Windows.Forms.Control)(object)this.siticonePanel1).Controls.Add((System.Windows.Forms.Control)(object)this.siticoneGradientButton1);
		((System.Windows.Forms.Control)(object)this.siticonePanel1).Controls.Add((System.Windows.Forms.Control)(object)this.siticoneButton6);
		((System.Windows.Forms.Control)(object)this.siticonePanel1).Controls.Add(this.label2);
		((System.Windows.Forms.Control)(object)this.siticonePanel1).Controls.Add(this.label1);
		((System.Windows.Forms.Control)(object)this.siticonePanel1).Controls.Add(this.pictureBox1);
		((System.Windows.Forms.Control)(object)this.siticonePanel1).Controls.Add((System.Windows.Forms.Control)(object)this.siticoneButton4);
		((System.Windows.Forms.Control)(object)this.siticonePanel1).Controls.Add((System.Windows.Forms.Control)(object)this.siticoneButton3);
		((System.Windows.Forms.Control)(object)this.siticonePanel1).Controls.Add((System.Windows.Forms.Control)(object)this.siticoneButton2);
		((System.Windows.Forms.Control)(object)this.siticonePanel1).Controls.Add((System.Windows.Forms.Control)(object)this.siticoneButton1);
		((System.Windows.Forms.Control)(object)this.siticonePanel1).Location = new System.Drawing.Point(0, 0);
		((System.Windows.Forms.Control)(object)this.siticonePanel1).Name = "siticonePanel1";
		this.siticonePanel1.ShadowDecoration.Depth = 3;
		this.siticonePanel1.ShadowDecoration.Enabled = true;
		this.siticonePanel1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticonePanel1;
		this.siticonePanel1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3, 3, 5, 3);
		((System.Windows.Forms.Control)(object)this.siticonePanel1).Size = new System.Drawing.Size(208, 564);
		((System.Windows.Forms.Control)(object)this.siticonePanel1).TabIndex = 0;
		((System.Windows.Forms.Control)(object)this.siticonePanel1).Paint += new System.Windows.Forms.PaintEventHandler(siticonePanel1_Paint);
		this.siticoneButton5.ButtonMode = (ButtonMode)1;
		this.siticoneButton5.CheckedState.CustomBorderColor = System.Drawing.SystemColors.Highlight;
		this.siticoneButton5.CheckedState.FillColor = System.Drawing.SystemColors.Control;
		this.siticoneButton5.CheckedState.Parent = (CustomButtonBase)(object)this.siticoneButton5;
		((System.Windows.Forms.Control)(object)this.siticoneButton5).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneButton5.CustomBorderThickness = new System.Windows.Forms.Padding(3, 0, 0, 0);
		this.siticoneButton5.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneButton5;
		this.siticoneButton5.FillColor = System.Drawing.SystemColors.Control;
		((System.Windows.Forms.Control)(object)this.siticoneButton5).Font = new System.Drawing.Font("SF Pro Text", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneButton5).ForeColor = System.Drawing.Color.Black;
		this.siticoneButton5.HoveredState.Parent = (CustomButtonBase)(object)this.siticoneButton5;
		this.siticoneButton5.Image = (System.Drawing.Image)resources.GetObject("siticoneButton5.Image");
		this.siticoneButton5.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
		this.siticoneButton5.ImageOffset = new System.Drawing.Point(15, 0);
		this.siticoneButton5.ImageSize = new System.Drawing.Size(18, 18);
		((System.Windows.Forms.Control)(object)this.siticoneButton5).Location = new System.Drawing.Point(0, 346);
		((System.Windows.Forms.Control)(object)this.siticoneButton5).Name = "siticoneButton5";
		this.siticoneButton5.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneButton5;
		((System.Windows.Forms.Control)(object)this.siticoneButton5).Size = new System.Drawing.Size(208, 45);
		((System.Windows.Forms.Control)(object)this.siticoneButton5).TabIndex = 80;
		((System.Windows.Forms.Control)(object)this.siticoneButton5).Text = "Websocket Utility";
		this.siticoneButton5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
		this.siticoneButton5.TextOffset = new System.Drawing.Point(15, 0);
		this.siticoneButton5.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.siticoneButton5).Click += new System.EventHandler(siticoneButton5_Click_1);
		this.siticoneImageButton3.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Cursor = System.Windows.Forms.Cursors.Arrow;
		this.siticoneImageButton3.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image");
		this.siticoneImageButton3.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		this.siticoneImageButton3.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton3.Image");
		((ImageButton)this.siticoneImageButton3).ImageRotate = 0f;
		this.siticoneImageButton3.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Location = new System.Drawing.Point(49, 5);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Name = "siticoneImageButton3";
		this.siticoneImageButton3.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Size = new System.Drawing.Size(29, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).TabIndex = 79;
		this.siticoneImageButton2.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton2;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneImageButton2.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image1");
		this.siticoneImageButton2.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton2.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton2;
		this.siticoneImageButton2.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton2.Image");
		((ImageButton)this.siticoneImageButton2).ImageRotate = 0f;
		this.siticoneImageButton2.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton2.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Location = new System.Drawing.Point(28, 5);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Name = "siticoneImageButton2";
		this.siticoneImageButton2.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton2.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton2;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Size = new System.Drawing.Size(29, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).TabIndex = 78;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Click += new System.EventHandler(siticoneImageButton2_Click);
		this.siticoneImageButton1.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneImageButton1.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image2");
		this.siticoneImageButton1.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		this.siticoneImageButton1.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton1.Image");
		((ImageButton)this.siticoneImageButton1).ImageRotate = 0f;
		this.siticoneImageButton1.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Location = new System.Drawing.Point(9, 5);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Name = "siticoneImageButton1";
		this.siticoneImageButton1.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Size = new System.Drawing.Size(26, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).TabIndex = 77;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Click += new System.EventHandler(siticoneImageButton1_Click);
		this.label3.Font = new System.Drawing.Font("Inter Black", 9.749999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
		this.label3.Location = new System.Drawing.Point(12, 487);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(174, 24);
		this.label3.TabIndex = 71;
		this.label3.Text = "UTENTE";
		this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.siticoneGradientButton1.BorderRadius = 18;
		((ButtonState)this.siticoneGradientButton1.CheckedState).Parent = (CustomButtonBase)(object)this.siticoneGradientButton1;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneGradientButton1.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneGradientButton1;
		this.siticoneGradientButton1.FillColor = System.Drawing.Color.FromArgb(56, 128, 255);
		this.siticoneGradientButton1.FillColor2 = System.Drawing.Color.FromArgb(56, 128, 255);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).Font = new System.Drawing.Font("SF Pro Text", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).ForeColor = System.Drawing.Color.White;
		((ButtonState)this.siticoneGradientButton1.HoveredState).Parent = (CustomButtonBase)(object)this.siticoneGradientButton1;
		this.siticoneGradientButton1.Image = (System.Drawing.Image)resources.GetObject("siticoneGradientButton1.Image");
		this.siticoneGradientButton1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.siticoneGradientButton1.ImageOffset = new System.Drawing.Point(6, -1);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).Location = new System.Drawing.Point(16, 516);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).Name = "siticoneGradientButton1";
		this.siticoneGradientButton1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneGradientButton1;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).Size = new System.Drawing.Size(170, 38);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).TabIndex = 70;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).Text = "Logout";
		this.siticoneGradientButton1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).Click += new System.EventHandler(siticoneGradientButton1_Click);
		this.siticoneButton6.ButtonMode = (ButtonMode)1;
		this.siticoneButton6.CheckedState.CustomBorderColor = System.Drawing.SystemColors.Highlight;
		this.siticoneButton6.CheckedState.FillColor = System.Drawing.SystemColors.Control;
		this.siticoneButton6.CheckedState.Parent = (CustomButtonBase)(object)this.siticoneButton6;
		((System.Windows.Forms.Control)(object)this.siticoneButton6).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneButton6.CustomBorderThickness = new System.Windows.Forms.Padding(3, 0, 0, 0);
		this.siticoneButton6.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneButton6;
		this.siticoneButton6.FillColor = System.Drawing.SystemColors.Control;
		((System.Windows.Forms.Control)(object)this.siticoneButton6).Font = new System.Drawing.Font("SF Pro Text", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneButton6).ForeColor = System.Drawing.Color.Black;
		this.siticoneButton6.HoveredState.Parent = (CustomButtonBase)(object)this.siticoneButton6;
		this.siticoneButton6.Image = (System.Drawing.Image)resources.GetObject("siticoneButton6.Image");
		this.siticoneButton6.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
		this.siticoneButton6.ImageOffset = new System.Drawing.Point(15, 0);
		this.siticoneButton6.ImageSize = new System.Drawing.Size(18, 18);
		((System.Windows.Forms.Control)(object)this.siticoneButton6).Location = new System.Drawing.Point(-1, 392);
		((System.Windows.Forms.Control)(object)this.siticoneButton6).Name = "siticoneButton6";
		this.siticoneButton6.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneButton6;
		((System.Windows.Forms.Control)(object)this.siticoneButton6).Size = new System.Drawing.Size(208, 45);
		((System.Windows.Forms.Control)(object)this.siticoneButton6).TabIndex = 7;
		((System.Windows.Forms.Control)(object)this.siticoneButton6).Text = "Settings And Other";
		this.siticoneButton6.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
		this.siticoneButton6.TextOffset = new System.Drawing.Point(15, 0);
		this.siticoneButton6.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.siticoneButton6).Click += new System.EventHandler(siticoneButton6_Click);
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("Inter Black", 9.749999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
		this.label2.Location = new System.Drawing.Point(146, 135);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(27, 16);
		this.label2.TabIndex = 6;
		this.label2.Text = "V4";
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Uni Sans Heavy CAPS", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(25, 116);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(150, 19);
		this.label1.TabIndex = 5;
		this.label1.Text = "BLACKSPAMMER XS";
		this.label1.Click += new System.EventHandler(label1_Click);
		this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
		this.pictureBox1.Location = new System.Drawing.Point(68, 53);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(50, 50);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox1.TabIndex = 3;
		this.pictureBox1.TabStop = false;
		this.siticoneButton4.ButtonMode = (ButtonMode)1;
		this.siticoneButton4.CheckedState.CustomBorderColor = System.Drawing.SystemColors.Highlight;
		this.siticoneButton4.CheckedState.FillColor = System.Drawing.SystemColors.Control;
		this.siticoneButton4.CheckedState.Parent = (CustomButtonBase)(object)this.siticoneButton4;
		((System.Windows.Forms.Control)(object)this.siticoneButton4).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneButton4.CustomBorderThickness = new System.Windows.Forms.Padding(3, 0, 0, 0);
		this.siticoneButton4.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneButton4;
		this.siticoneButton4.FillColor = System.Drawing.SystemColors.Control;
		((System.Windows.Forms.Control)(object)this.siticoneButton4).Font = new System.Drawing.Font("SF Pro Text", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneButton4).ForeColor = System.Drawing.Color.Black;
		this.siticoneButton4.HoveredState.Parent = (CustomButtonBase)(object)this.siticoneButton4;
		this.siticoneButton4.Image = (System.Drawing.Image)resources.GetObject("siticoneButton4.Image");
		this.siticoneButton4.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
		this.siticoneButton4.ImageOffset = new System.Drawing.Point(15, 0);
		this.siticoneButton4.ImageSize = new System.Drawing.Size(18, 18);
		((System.Windows.Forms.Control)(object)this.siticoneButton4).Location = new System.Drawing.Point(0, 212);
		((System.Windows.Forms.Control)(object)this.siticoneButton4).Name = "siticoneButton4";
		this.siticoneButton4.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneButton4;
		((System.Windows.Forms.Control)(object)this.siticoneButton4).Size = new System.Drawing.Size(208, 45);
		((System.Windows.Forms.Control)(object)this.siticoneButton4).TabIndex = 4;
		((System.Windows.Forms.Control)(object)this.siticoneButton4).Text = "Guild Manager";
		this.siticoneButton4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
		this.siticoneButton4.TextOffset = new System.Drawing.Point(15, 0);
		this.siticoneButton4.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.siticoneButton4).Click += new System.EventHandler(siticoneButton4_Click);
		this.siticoneButton3.ButtonMode = (ButtonMode)1;
		this.siticoneButton3.CheckedState.CustomBorderColor = System.Drawing.SystemColors.Highlight;
		this.siticoneButton3.CheckedState.FillColor = System.Drawing.SystemColors.Control;
		this.siticoneButton3.CheckedState.Parent = (CustomButtonBase)(object)this.siticoneButton3;
		((System.Windows.Forms.Control)(object)this.siticoneButton3).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneButton3.CustomBorderThickness = new System.Windows.Forms.Padding(3, 0, 0, 0);
		this.siticoneButton3.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneButton3;
		this.siticoneButton3.FillColor = System.Drawing.SystemColors.Control;
		((System.Windows.Forms.Control)(object)this.siticoneButton3).Font = new System.Drawing.Font("SF Pro Text", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneButton3).ForeColor = System.Drawing.Color.Black;
		this.siticoneButton3.HoveredState.Parent = (CustomButtonBase)(object)this.siticoneButton3;
		this.siticoneButton3.Image = (System.Drawing.Image)resources.GetObject("siticoneButton3.Image");
		this.siticoneButton3.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
		this.siticoneButton3.ImageOffset = new System.Drawing.Point(15, 0);
		this.siticoneButton3.ImageSize = new System.Drawing.Size(18, 18);
		((System.Windows.Forms.Control)(object)this.siticoneButton3).Location = new System.Drawing.Point(0, 257);
		((System.Windows.Forms.Control)(object)this.siticoneButton3).Name = "siticoneButton3";
		this.siticoneButton3.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneButton3;
		((System.Windows.Forms.Control)(object)this.siticoneButton3).Size = new System.Drawing.Size(208, 45);
		((System.Windows.Forms.Control)(object)this.siticoneButton3).TabIndex = 3;
		((System.Windows.Forms.Control)(object)this.siticoneButton3).Text = "Server Spammer";
		this.siticoneButton3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
		this.siticoneButton3.TextOffset = new System.Drawing.Point(15, 0);
		this.siticoneButton3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.siticoneButton3).Click += new System.EventHandler(siticoneButton3_Click);
		this.siticoneButton2.ButtonMode = (ButtonMode)1;
		this.siticoneButton2.CheckedState.CustomBorderColor = System.Drawing.SystemColors.Highlight;
		this.siticoneButton2.CheckedState.FillColor = System.Drawing.SystemColors.Control;
		this.siticoneButton2.CheckedState.Parent = (CustomButtonBase)(object)this.siticoneButton2;
		((System.Windows.Forms.Control)(object)this.siticoneButton2).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneButton2.CustomBorderThickness = new System.Windows.Forms.Padding(3, 0, 0, 0);
		this.siticoneButton2.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneButton2;
		this.siticoneButton2.FillColor = System.Drawing.SystemColors.Control;
		((System.Windows.Forms.Control)(object)this.siticoneButton2).Font = new System.Drawing.Font("SF Pro Text", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneButton2).ForeColor = System.Drawing.Color.Black;
		this.siticoneButton2.HoveredState.Parent = (CustomButtonBase)(object)this.siticoneButton2;
		this.siticoneButton2.Image = (System.Drawing.Image)resources.GetObject("siticoneButton2.Image");
		this.siticoneButton2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
		this.siticoneButton2.ImageOffset = new System.Drawing.Point(15, 0);
		this.siticoneButton2.ImageSize = new System.Drawing.Size(18, 18);
		((System.Windows.Forms.Control)(object)this.siticoneButton2).Location = new System.Drawing.Point(0, 302);
		((System.Windows.Forms.Control)(object)this.siticoneButton2).Name = "siticoneButton2";
		this.siticoneButton2.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneButton2;
		((System.Windows.Forms.Control)(object)this.siticoneButton2).Size = new System.Drawing.Size(208, 45);
		((System.Windows.Forms.Control)(object)this.siticoneButton2).TabIndex = 2;
		((System.Windows.Forms.Control)(object)this.siticoneButton2).Text = "Reaction Spammer";
		this.siticoneButton2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
		this.siticoneButton2.TextOffset = new System.Drawing.Point(15, 0);
		this.siticoneButton2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.siticoneButton2).Click += new System.EventHandler(siticoneButton2_Click);
		this.siticoneButton1.ButtonMode = (ButtonMode)1;
		this.siticoneButton1.Checked = true;
		this.siticoneButton1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(0, 192, 192);
		this.siticoneButton1.CheckedState.CustomBorderColor = System.Drawing.SystemColors.Highlight;
		this.siticoneButton1.CheckedState.FillColor = System.Drawing.SystemColors.Control;
		this.siticoneButton1.CheckedState.Parent = (CustomButtonBase)(object)this.siticoneButton1;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneButton1.CustomBorderThickness = new System.Windows.Forms.Padding(3, 0, 0, 0);
		this.siticoneButton1.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneButton1;
		this.siticoneButton1.FillColor = System.Drawing.SystemColors.Control;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Font = new System.Drawing.Font("SF Pro Text", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).ForeColor = System.Drawing.Color.Black;
		this.siticoneButton1.HoveredState.Parent = (CustomButtonBase)(object)this.siticoneButton1;
		this.siticoneButton1.Image = (System.Drawing.Image)resources.GetObject("siticoneButton1.Image");
		this.siticoneButton1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
		this.siticoneButton1.ImageOffset = new System.Drawing.Point(15, 0);
		this.siticoneButton1.ImageSize = new System.Drawing.Size(18, 18);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Location = new System.Drawing.Point(0, 167);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Name = "siticoneButton1";
		this.siticoneButton1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneButton1;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Size = new System.Drawing.Size(208, 45);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).TabIndex = 1;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Text = "Dashboard";
		this.siticoneButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
		this.siticoneButton1.TextOffset = new System.Drawing.Point(15, 0);
		this.siticoneButton1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Click += new System.EventHandler(siticoneButton1_Click);
		this.siticoneDragControl2.TargetControl = (System.Windows.Forms.Control)(object)this.siticonePanel1;
		this.siticoneDragControl3.TargetControl = this.pictureBox1;
		this.siticoneDragControl4.TargetControl = this.label1;
		this.siticoneDragControl5.TargetControl = this.label2;
		((System.Windows.Forms.Control)(object)this.siticonePanel2).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		((System.Windows.Forms.Control)(object)this.siticonePanel2).Controls.Add(this.dashboard1);
		((System.Windows.Forms.Control)(object)this.siticonePanel2).Controls.Add(this.guildManager1);
		((System.Windows.Forms.Control)(object)this.siticonePanel2).Controls.Add(this.serverSpammer1);
		((System.Windows.Forms.Control)(object)this.siticonePanel2).Controls.Add(this.reactionSpammer1);
		((System.Windows.Forms.Control)(object)this.siticonePanel2).Controls.Add(this.advancedSettings1);
		((System.Windows.Forms.Control)(object)this.siticonePanel2).Controls.Add(this.websocketManager1);
		((System.Windows.Forms.Control)(object)this.siticonePanel2).Location = new System.Drawing.Point(208, 0);
		((System.Windows.Forms.Control)(object)this.siticonePanel2).Name = "siticonePanel2";
		this.siticonePanel2.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticonePanel2;
		((System.Windows.Forms.Control)(object)this.siticonePanel2).Size = new System.Drawing.Size(704, 564);
		((System.Windows.Forms.Control)(object)this.siticonePanel2).TabIndex = 3;
		this.dashboard1.BackColor = System.Drawing.Color.White;
		this.dashboard1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.dashboard1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.dashboard1.Location = new System.Drawing.Point(0, 0);
		this.dashboard1.Name = "dashboard1";
		this.dashboard1.Size = new System.Drawing.Size(704, 564);
		this.dashboard1.TabIndex = 0;
		this.dashboard1.Load += new System.EventHandler(dashboard1_Load);
		this.guildManager1.BackColor = System.Drawing.Color.White;
		this.guildManager1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.guildManager1.Location = new System.Drawing.Point(0, 0);
		this.guildManager1.Name = "guildManager1";
		this.guildManager1.Size = new System.Drawing.Size(704, 564);
		this.guildManager1.TabIndex = 1;
		this.serverSpammer1.BackColor = System.Drawing.Color.White;
		this.serverSpammer1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.serverSpammer1.Location = new System.Drawing.Point(0, 0);
		this.serverSpammer1.Name = "serverSpammer1";
		this.serverSpammer1.Size = new System.Drawing.Size(704, 564);
		this.serverSpammer1.TabIndex = 3;
		this.reactionSpammer1.BackColor = System.Drawing.Color.White;
		this.reactionSpammer1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.reactionSpammer1.Location = new System.Drawing.Point(0, 0);
		this.reactionSpammer1.Name = "reactionSpammer1";
		this.reactionSpammer1.Size = new System.Drawing.Size(704, 564);
		this.reactionSpammer1.TabIndex = 2;
		this.advancedSettings1.BackColor = System.Drawing.Color.White;
		this.advancedSettings1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.advancedSettings1.Location = new System.Drawing.Point(0, 0);
		this.advancedSettings1.Name = "advancedSettings1";
		this.advancedSettings1.Size = new System.Drawing.Size(704, 564);
		this.advancedSettings1.TabIndex = 4;
		this.websocketManager1.BackColor = System.Drawing.Color.White;
		this.websocketManager1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.websocketManager1.Location = new System.Drawing.Point(0, 0);
		this.websocketManager1.Name = "websocketManager1";
		this.websocketManager1.Size = new System.Drawing.Size(704, 564);
		this.websocketManager1.TabIndex = 5;
		this.siticoneDragControl6.TargetControl = (System.Windows.Forms.Control)(object)this.siticonePanel2;
		this.siticoneDragControl7.TargetControl = null;
		this.bunifuDragControl1.Fixed = true;
		this.bunifuDragControl1.Horizontal = true;
		this.bunifuDragControl1.TargetControl = null;
		this.bunifuDragControl1.Vertical = true;
		this.siticoneElipse1.TargetControl = this;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(914, 566);
		base.ControlBox = false;
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticonePanel2);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticonePanel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Form1";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "BlackSpammer XS";
		base.Load += new System.EventHandler(Form1_Load);
		((System.Windows.Forms.Control)(object)this.siticonePanel1).ResumeLayout(false);
		((System.Windows.Forms.Control)(object)this.siticonePanel1).PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		((System.Windows.Forms.Control)(object)this.siticonePanel2).ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
