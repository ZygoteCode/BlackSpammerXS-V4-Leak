using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Windows.Forms;
using BlackSpammerXS.Properties;
using BlackVerifyNumber;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Suite;

namespace BlackSpammerXS;

public class AdvancedSettings : UserControl
{
	private IContainer components = null;

	private Label label1;

	private PictureBox pictureBox2;

	private Label rem;

	private Label label2;

	private SiticoneDragControl siticoneDragControl1;

	private SiticoneWinToggleSwith siticoneWinToggleSwith1;

	private SiticoneGradientButton siticoneGradientButton2;

	private SiticoneToggleSwitch hasDelay;

	private Label del;

	private SiticoneToggleSwitch siticoneToggleSwitch1;

	private Label label3;

	private SiticoneToggleSwitch wdevm;

	private Label label4;

	private SiticoneToggleSwitch siticoneToggleSwitch3;

	private Label label5;

	private ContextMenuStrip contextMenuStrip1;

	private ToolStripMenuItem enableDeveloperToolsToolStripMenuItem;

	private SiticoneGradientButton siticoneGradientButton1;

	private Label label6;

	private SiticoneGradientButton siticoneGradientButton3;

	private SiticoneGradientButton openDevToolsBtn;

	private SiticoneGradientButton siticoneGradientButton5;

	private SiticoneGradientButton siticoneGradientButton4;

	public AdvancedSettings()
	{
		InitializeComponent();
	}

	private void siticoneButton4_CheckedChanged(object sender, EventArgs e)
	{
	}

	public void Dark()
	{
		Color backColor = Color.FromArgb(44, 47, 51);
		BackColor = backColor;
		Color dimGray = Color.DimGray;
		try
		{
			List<SiticoneButton> list = new List<SiticoneButton>();
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
		catch (Exception)
		{
		}
	}

	public void Switch()
	{
		siticoneWinToggleSwith1.Checked = true;
	}

	private void AdvancedSettings_Load(object sender, EventArgs e)
	{
		if (Settings.Default.dark)
		{
			((Control)(object)siticoneGradientButton1).Text = "Switch to Light Mode";
		}
		ImpostazioniGlobali._bridgeLogPerform.Add(delegate(int a, int b, object[] i)
		{
			if (a == 4727417)
			{
				try
				{
					if (b == 0)
					{
						((Control)(object)wdevm).Enabled = false;
					}
					if (b == 1)
					{
						((Control)(object)wdevm).Enabled = true;
					}
				}
				catch (Exception)
				{
				}
			}
		});
	}

	private void AdvancedSettings_Click(object sender, EventArgs e)
	{
	}

	private async void siticoneButton4_Click(object sender, EventArgs e)
	{
	}

	private async void siticoneButton1_Click(object sender, EventArgs e)
	{
		if (ImpostazioniGlobali.CaptchaKey_SMSACT == "")
		{
			MessageBox.Show("A valid sms activate key is required");
			return;
		}
		if (ImpostazioniGlobali.Tokens == null || ImpostazioniGlobali.Proxies == null)
		{
			MessageBox.Show("You must import at least 1 token and 1 proxy");
			return;
		}
		ImpostazioniGlobali.StartLog();
		int _suc = 0;
		int _non = 0;
		string numberKey = ImpostazioniGlobali.CaptchaKey_SMSACT;
		Random random = new Random();
		List<string> proxies = ImpostazioniGlobali.Proxies;
		BlackNumberVerification manager = new BlackNumberVerification(numberKey);
		ImpostazioniGlobali.Log("Manager -> (Operation Starting) Verification => Verifying Phone with " + proxies.Count + " proxies and " + ImpostazioniGlobali.Tokens.Count + " tokens..");
		Control.CheckForIllegalCrossThreadCalls = false;
		new Thread((ParameterizedThreadStart)delegate
		{
			Control.CheckForIllegalCrossThreadCalls = false;
			rem.Text = "0 of " + ImpostazioniGlobali.Tokens.Count;
			ImpostazioniGlobali.Log("Manager -> (Operation Starting) Verification => Checking which tokens needs verification..");
			foreach (string t in ImpostazioniGlobali.Tokens)
			{
				new Thread((ParameterizedThreadStart)async delegate
				{
					string proxy;
					try
					{
						proxy = proxies[random.Next(proxies.Count)];
					}
					catch (Exception)
					{
						proxy = "Error";
					}
					try
					{
						HttpClientHandler handler = new HttpClientHandler();
						handler.PreAuthenticate = true;
						handler.UseProxy = true;
						WebProxy __p = (WebProxy)(handler.Proxy = new WebProxy(proxy.Split(':')[0], int.Parse(proxy.Split(':')[1])));
						HttpClient http = new HttpClient((HttpMessageHandler)(object)handler);
						HttpRequestMessage val = new HttpRequestMessage
						{
							RequestUri = new Uri("https://discord.com/api/v9/users/@me/library"),
							Method = HttpMethod.Get
						};
						((HttpHeaders)val.Headers).Add("Authorization", t);
						HttpRequestMessage request = val;
						if ((await (await http.SendAsync(request)).Content.ReadAsStringAsync()).Contains("verify"))
						{
							ImpostazioniGlobali.Log(proxy + " -> (" + t + ") Check => Needs verification.");
							ImpostazioniGlobali.Log(proxy + " -> (" + t + ") Verification => Verifying phone using sms-activate.ru...");
							if (await manager.Verify(t, true, __p))
							{
								ImpostazioniGlobali.Log(proxy + " -> (" + t + ") Verification => Done! Successfully phone verified.");
								_suc++;
								rem.Text = _suc + " of " + (ImpostazioniGlobali.Tokens.Count - _non);
							}
							else
							{
								ImpostazioniGlobali.Log(proxy + " -> (" + t + ") Verification => Error! Failed to phone verify.");
							}
						}
						else
						{
							_non++;
							rem.Text = _suc + " of " + (ImpostazioniGlobali.Tokens.Count - _non);
						}
					}
					catch (Exception)
					{
						ImpostazioniGlobali.Log(proxy + " -> (" + t + ") Check => Unknown Error [Check your proxies]");
					}
					try
					{
						Thread.CurrentThread.Abort();
					}
					catch
					{
					}
				}).Start();
			}
		}).Start();
	}

	private void siticoneButton1_MouseEnter(object sender, EventArgs e)
	{
	}

	private void siticoneButton1_MouseLeave(object sender, EventArgs e)
	{
	}

	private void siticoneWinToggleSwith1_CheckedChanged(object sender, EventArgs e)
	{
		ImpostazioniGlobali.DarkMode(siticoneWinToggleSwith1.Checked);
	}

	private void siticoneButton1_Click_1(object sender, EventArgs e)
	{
	}

	private void siticoneGradientButton1_Click(object sender, EventArgs e)
	{
		if (siticoneWinToggleSwith1.Checked)
		{
			((Control)(object)siticoneGradientButton1).Text = "Switch to Dark Mode";
			siticoneWinToggleSwith1.Checked = false;
		}
		else
		{
			((Control)(object)siticoneGradientButton1).Text = "Switch to Light Mode";
			siticoneWinToggleSwith1.Checked = true;
		}
		siticoneWinToggleSwith1_CheckedChanged(sender, e);
	}

	private void siticoneGradientButton2_Click(object sender, EventArgs e)
	{
		siticoneButton1_Click(sender, e);
	}

	private void label2_Click(object sender, EventArgs e)
	{
	}

	private void hasDelay_CheckedChanged(object sender, EventArgs e)
	{
		ImpostazioniGlobali.StreamerMode = hasDelay.Checked;
		ImpostazioniGlobali.StreamOptNotify();
	}

	private void siticoneToggleSwitch1_CheckedChanged(object sender, EventArgs e)
	{
		ImpostazioniGlobali.AllowLogging = siticoneToggleSwitch1.Checked;
	}

	private void siticoneToggleSwitch3_CheckedChanged(object sender, EventArgs e)
	{
		MessageBox.Show(delegate(int a, int b)
		{
			if (a == 0 && b == 2)
			{
				ZaschModeBSOD zaschModeBSOD = new ZaschModeBSOD();
				zaschModeBSOD.Show();
			}
		}, "Attenzione. Sei sicuro di voler attivare la zasch mode? Sarà necessario riavviare il PC per rimuoverla.", "Zasch Mode");
	}

	private void siticoneToggleSwitch2_CheckedChanged(object sender, EventArgs e)
	{
		ImpostazioniGlobali.DeveloperMode = wdevm.Checked;
		if (wdevm.Checked)
		{
			((Control)(object)openDevToolsBtn).Enabled = true;
		}
		else
		{
			((Control)(object)openDevToolsBtn).Enabled = false;
		}
	}

	private void nKEY_TextChanged(object sender, EventArgs e)
	{
	}

	private void siticoneGradientButton3_Click(object sender, EventArgs e)
	{
		((Control)(object)siticoneGradientButton3).Text = "Changing Captcha Key..";
		OpacityFull opacityFull = new OpacityFull();
		opacityFull.Show();
		ChcapKM chcapKM = new ChcapKM();
		ImpostazioniGlobali.bridgeAct_ = delegate(int a)
		{
			if (a == 0)
			{
				opacityFull.Close();
				Focus();
				((Control)(object)siticoneGradientButton3).Text = "Change Captcha Key";
			}
		};
		chcapKM.Show();
	}

	private void siticoneGradientButton4_Click(object sender, EventArgs e)
	{
		OpacityFull opacityFull = new OpacityFull();
		opacityFull.Show();
		ImpostazioniGlobali.bridgeAct_ = delegate(int a)
		{
			if (a == 0)
			{
				opacityFull.Close();
				Focus();
				Show();
			}
		};
		AuditLogForm auditLogForm = new AuditLogForm();
		auditLogForm.Show();
	}

	private void siticoneGradientButton5_Click(object sender, EventArgs e)
	{
		OpacityFull opacityFull = new OpacityFull();
		opacityFull.Show();
		ImpostazioniGlobali.bridgeAct_ = delegate(int a)
		{
			if (a == 0)
			{
				opacityFull.Close();
				Focus();
				Show();
			}
		};
		GenerateTextForm generateTextForm = new GenerateTextForm(opacityFull, Settings.Default.dark);
		generateTextForm.Show();
	}

	private void enableDeveloperToolsToolStripMenuItem_Click(object sender, EventArgs e)
	{
		OpacityFull opacityFull = new OpacityFull();
		opacityFull.Show();
		LoadingCVF loadingCVF = new LoadingCVF(opacityFull, Settings.Default.dark);
		loadingCVF.Show();
	}

	private void openDevToolsBtn_Click(object sender, EventArgs e)
	{
		OpacityFull opacityFull = new OpacityFull();
		opacityFull.Show();
		ImpostazioniGlobali.bridgeAct_ = delegate
		{
		};
		DevToolsBSXS devToolsBSXS = new DevToolsBSXS(opacityFull, Settings.Default.dark);
		devToolsBSXS.Show();
	}

	private void siticoneButton4_Click_1(object sender, EventArgs e)
	{
		siticoneGradientButton1_Click(sender, e);
	}

	private void siticoneGradientButton6_Click(object sender, EventArgs e)
	{
		siticoneGradientButton3_Click(sender, e);
	}

	private void siticoneButton7_Click(object sender, EventArgs e)
	{
		openDevToolsBtn_Click(sender, e);
	}

	private void siticoneButton7_Click_1(object sender, EventArgs e)
	{
		siticoneGradientButton5_Click(sender, e);
	}

	private void siticoneButton7_Click_2(object sender, EventArgs e)
	{
		siticoneGradientButton4_Click(sender, e);
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
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected O, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlackSpammerXS.AdvancedSettings));
		this.label1 = new System.Windows.Forms.Label();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.rem = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.siticoneDragControl1 = new SiticoneDragControl(this.components);
		this.siticoneWinToggleSwith1 = new SiticoneWinToggleSwith();
		this.siticoneGradientButton2 = new SiticoneGradientButton();
		this.hasDelay = new SiticoneToggleSwitch();
		this.del = new System.Windows.Forms.Label();
		this.siticoneToggleSwitch1 = new SiticoneToggleSwitch();
		this.label3 = new System.Windows.Forms.Label();
		this.wdevm = new SiticoneToggleSwitch();
		this.label4 = new System.Windows.Forms.Label();
		this.siticoneToggleSwitch3 = new SiticoneToggleSwitch();
		this.label5 = new System.Windows.Forms.Label();
		this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.enableDeveloperToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.siticoneGradientButton1 = new SiticoneGradientButton();
		this.label6 = new System.Windows.Forms.Label();
		this.siticoneGradientButton3 = new SiticoneGradientButton();
		this.openDevToolsBtn = new SiticoneGradientButton();
		this.siticoneGradientButton5 = new SiticoneGradientButton();
		this.siticoneGradientButton4 = new SiticoneGradientButton();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		this.contextMenuStrip1.SuspendLayout();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Inter", 15.75f, System.Drawing.FontStyle.Bold);
		this.label1.Location = new System.Drawing.Point(13, 40);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(207, 25);
		this.label1.TabIndex = 4;
		this.label1.Text = "Advanced Settings";
		this.pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
		this.pictureBox2.Location = new System.Drawing.Point(653, 31);
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.Size = new System.Drawing.Size(39, 30);
		this.pictureBox2.TabIndex = 69;
		this.pictureBox2.TabStop = false;
		this.rem.Enabled = false;
		this.rem.Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.rem.Location = new System.Drawing.Point(240, 138);
		this.rem.Name = "rem";
		this.rem.Size = new System.Drawing.Size(179, 16);
		this.rem.TabIndex = 71;
		this.rem.Text = "0 of 0";
		this.rem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.rem.Visible = false;
		this.label2.AutoSize = true;
		this.label2.Enabled = false;
		this.label2.Font = new System.Drawing.Font("Inter", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.Location = new System.Drawing.Point(296, 109);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(71, 19);
		this.label2.TabIndex = 70;
		this.label2.Text = "Success";
		this.label2.Visible = false;
		this.label2.Click += new System.EventHandler(label2_Click);
		this.siticoneDragControl1.TargetControl = this;
		((System.Windows.Forms.Control)(object)this.siticoneWinToggleSwith1).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.siticoneWinToggleSwith1).Location = new System.Drawing.Point(226, 43);
		((System.Windows.Forms.Control)(object)this.siticoneWinToggleSwith1).Name = "siticoneWinToggleSwith1";
		((System.Windows.Forms.Control)(object)this.siticoneWinToggleSwith1).Size = new System.Drawing.Size(45, 22);
		((System.Windows.Forms.Control)(object)this.siticoneWinToggleSwith1).TabIndex = 79;
		((System.Windows.Forms.Control)(object)this.siticoneWinToggleSwith1).Text = "siticoneWinToggleSwith1";
		((System.Windows.Forms.Control)(object)this.siticoneWinToggleSwith1).Visible = false;
		((ToggleSwitch)this.siticoneWinToggleSwith1).CheckedChanged += new System.EventHandler(siticoneWinToggleSwith1_CheckedChanged);
		this.siticoneGradientButton2.BorderRadius = 15;
		((ButtonState)this.siticoneGradientButton2.CheckedState).Parent = (CustomButtonBase)(object)this.siticoneGradientButton2;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton2).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneGradientButton2.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneGradientButton2;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton2).Enabled = false;
		this.siticoneGradientButton2.FillColor2 = System.Drawing.Color.Teal;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton2).Font = new System.Drawing.Font("SF Pro Text", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton2).ForeColor = System.Drawing.Color.White;
		((ButtonState)this.siticoneGradientButton2.HoveredState).Parent = (CustomButtonBase)(object)this.siticoneGradientButton2;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton2).Location = new System.Drawing.Point(183, 188);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton2).Name = "siticoneGradientButton2";
		this.siticoneGradientButton2.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneGradientButton2;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton2).Size = new System.Drawing.Size(303, 37);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton2).TabIndex = 83;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton2).Text = "Verify Unverified Tokens";
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton2).Visible = false;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton2).Click += new System.EventHandler(siticoneGradientButton2_Click);
		this.hasDelay.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasDelay.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasDelay.CheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.hasDelay.CheckedState.InnerColor = System.Drawing.Color.White;
		this.hasDelay.CheckedState.Parent = (ToggleSwitch)(object)this.hasDelay;
		((System.Windows.Forms.Control)(object)this.hasDelay).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.hasDelay).Location = new System.Drawing.Point(29, 327);
		((System.Windows.Forms.Control)(object)this.hasDelay).Name = "hasDelay";
		this.hasDelay.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.hasDelay;
		((System.Windows.Forms.Control)(object)this.hasDelay).Size = new System.Drawing.Size(32, 20);
		((System.Windows.Forms.Control)(object)this.hasDelay).TabIndex = 85;
		this.hasDelay.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasDelay.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasDelay.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.hasDelay.UncheckedState.InnerColor = System.Drawing.Color.White;
		this.hasDelay.UncheckedState.Parent = (ToggleSwitch)(object)this.hasDelay;
		((ToggleSwitch)this.hasDelay).CheckedChanged += new System.EventHandler(hasDelay_CheckedChanged);
		this.del.AutoSize = true;
		this.del.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, 0);
		this.del.Location = new System.Drawing.Point(66, 330);
		this.del.Name = "del";
		this.del.Size = new System.Drawing.Size(98, 14);
		this.del.TabIndex = 84;
		this.del.Text = "Streamer Mode";
		this.siticoneToggleSwitch1.Checked = true;
		this.siticoneToggleSwitch1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.siticoneToggleSwitch1.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.siticoneToggleSwitch1.CheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.siticoneToggleSwitch1.CheckedState.InnerColor = System.Drawing.Color.White;
		this.siticoneToggleSwitch1.CheckedState.Parent = (ToggleSwitch)(object)this.siticoneToggleSwitch1;
		((System.Windows.Forms.Control)(object)this.siticoneToggleSwitch1).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.siticoneToggleSwitch1).Location = new System.Drawing.Point(29, 381);
		((System.Windows.Forms.Control)(object)this.siticoneToggleSwitch1).Name = "siticoneToggleSwitch1";
		this.siticoneToggleSwitch1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneToggleSwitch1;
		((System.Windows.Forms.Control)(object)this.siticoneToggleSwitch1).Size = new System.Drawing.Size(32, 20);
		((System.Windows.Forms.Control)(object)this.siticoneToggleSwitch1).TabIndex = 87;
		this.siticoneToggleSwitch1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.siticoneToggleSwitch1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.siticoneToggleSwitch1.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.siticoneToggleSwitch1.UncheckedState.InnerColor = System.Drawing.Color.White;
		this.siticoneToggleSwitch1.UncheckedState.Parent = (ToggleSwitch)(object)this.siticoneToggleSwitch1;
		((ToggleSwitch)this.siticoneToggleSwitch1).CheckedChanged += new System.EventHandler(siticoneToggleSwitch1_CheckedChanged);
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.Location = new System.Drawing.Point(66, 384);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(93, 14);
		this.label3.TabIndex = 86;
		this.label3.Text = "Allow Logging";
		this.wdevm.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.wdevm.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.wdevm.CheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.wdevm.CheckedState.InnerColor = System.Drawing.Color.White;
		this.wdevm.CheckedState.Parent = (ToggleSwitch)(object)this.wdevm;
		((System.Windows.Forms.Control)(object)this.wdevm).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.wdevm).Location = new System.Drawing.Point(29, 408);
		((System.Windows.Forms.Control)(object)this.wdevm).Name = "wdevm";
		this.wdevm.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.wdevm;
		((System.Windows.Forms.Control)(object)this.wdevm).Size = new System.Drawing.Size(32, 20);
		((System.Windows.Forms.Control)(object)this.wdevm).TabIndex = 91;
		this.wdevm.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.wdevm.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.wdevm.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.wdevm.UncheckedState.InnerColor = System.Drawing.Color.White;
		this.wdevm.UncheckedState.Parent = (ToggleSwitch)(object)this.wdevm;
		((ToggleSwitch)this.wdevm).CheckedChanged += new System.EventHandler(siticoneToggleSwitch2_CheckedChanged);
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.Location = new System.Drawing.Point(65, 412);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(110, 14);
		this.label4.TabIndex = 90;
		this.label4.Text = "Developer Mode*";
		this.siticoneToggleSwitch3.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.siticoneToggleSwitch3.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.siticoneToggleSwitch3.CheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.siticoneToggleSwitch3.CheckedState.InnerColor = System.Drawing.Color.White;
		this.siticoneToggleSwitch3.CheckedState.Parent = (ToggleSwitch)(object)this.siticoneToggleSwitch3;
		((System.Windows.Forms.Control)(object)this.siticoneToggleSwitch3).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.siticoneToggleSwitch3).Location = new System.Drawing.Point(29, 354);
		((System.Windows.Forms.Control)(object)this.siticoneToggleSwitch3).Name = "siticoneToggleSwitch3";
		this.siticoneToggleSwitch3.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneToggleSwitch3;
		((System.Windows.Forms.Control)(object)this.siticoneToggleSwitch3).Size = new System.Drawing.Size(32, 20);
		((System.Windows.Forms.Control)(object)this.siticoneToggleSwitch3).TabIndex = 89;
		this.siticoneToggleSwitch3.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.siticoneToggleSwitch3.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.siticoneToggleSwitch3.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.siticoneToggleSwitch3.UncheckedState.InnerColor = System.Drawing.Color.White;
		this.siticoneToggleSwitch3.UncheckedState.Parent = (ToggleSwitch)(object)this.siticoneToggleSwitch3;
		((ToggleSwitch)this.siticoneToggleSwitch3).CheckedChanged += new System.EventHandler(siticoneToggleSwitch3_CheckedChanged);
		this.label5.AutoSize = true;
		this.label5.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, 0);
		this.label5.Location = new System.Drawing.Point(66, 357);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(80, 14);
		this.label5.TabIndex = 88;
		this.label5.Text = "Zasch Mode";
		this.contextMenuStrip1.Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.enableDeveloperToolsToolStripMenuItem });
		this.contextMenuStrip1.Name = "contextMenuStrip1";
		this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
		this.contextMenuStrip1.Size = new System.Drawing.Size(228, 26);
		this.enableDeveloperToolsToolStripMenuItem.Name = "enableDeveloperToolsToolStripMenuItem";
		this.enableDeveloperToolsToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
		this.enableDeveloperToolsToolStripMenuItem.Text = "Enable Developer Tools";
		this.enableDeveloperToolsToolStripMenuItem.Click += new System.EventHandler(enableDeveloperToolsToolStripMenuItem_Click);
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
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).Location = new System.Drawing.Point(18, 511);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).Name = "siticoneGradientButton1";
		this.siticoneGradientButton1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneGradientButton1;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).Size = new System.Drawing.Size(651, 38);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).TabIndex = 97;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).Text = "Switch to Dark Mode";
		this.siticoneGradientButton1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton1).Click += new System.EventHandler(siticoneButton4_Click_1);
		this.label6.AutoSize = true;
		this.label6.Font = new System.Drawing.Font("Inter", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label6.Location = new System.Drawing.Point(126, 156);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(433, 38);
		this.label6.TabIndex = 98;
		this.label6.Text = "Our token verifier tool is currently disabled and will be\r\nback as soon as possible.";
		this.siticoneGradientButton3.BorderRadius = 18;
		((ButtonState)this.siticoneGradientButton3.CheckedState).Parent = (CustomButtonBase)(object)this.siticoneGradientButton3;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton3).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneGradientButton3.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneGradientButton3;
		this.siticoneGradientButton3.FillColor = System.Drawing.Color.FromArgb(56, 128, 255);
		this.siticoneGradientButton3.FillColor2 = System.Drawing.Color.FromArgb(56, 128, 255);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton3).Font = new System.Drawing.Font("SF Pro Text", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton3).ForeColor = System.Drawing.Color.White;
		((ButtonState)this.siticoneGradientButton3.HoveredState).Parent = (CustomButtonBase)(object)this.siticoneGradientButton3;
		this.siticoneGradientButton3.Image = (System.Drawing.Image)resources.GetObject("siticoneGradientButton3.Image");
		this.siticoneGradientButton3.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.siticoneGradientButton3.ImageOffset = new System.Drawing.Point(6, -1);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton3).Location = new System.Drawing.Point(178, 231);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton3).Name = "siticoneGradientButton3";
		this.siticoneGradientButton3.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneGradientButton3;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton3).Size = new System.Drawing.Size(308, 38);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton3).TabIndex = 99;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton3).Text = "Change Captcha Key";
		this.siticoneGradientButton3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton3).Click += new System.EventHandler(siticoneGradientButton6_Click);
		this.openDevToolsBtn.BorderRadius = 18;
		((ButtonState)this.openDevToolsBtn.CheckedState).Parent = (CustomButtonBase)(object)this.openDevToolsBtn;
		((System.Windows.Forms.Control)(object)this.openDevToolsBtn).Cursor = System.Windows.Forms.Cursors.Hand;
		this.openDevToolsBtn.CustomImages.Parent = (CustomButtonBase)(object)this.openDevToolsBtn;
		((System.Windows.Forms.Control)(object)this.openDevToolsBtn).Enabled = false;
		this.openDevToolsBtn.FillColor = System.Drawing.Color.DodgerBlue;
		this.openDevToolsBtn.FillColor2 = System.Drawing.Color.DeepSkyBlue;
		((System.Windows.Forms.Control)(object)this.openDevToolsBtn).Font = new System.Drawing.Font("SF Pro Text", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.openDevToolsBtn).ForeColor = System.Drawing.Color.White;
		((ButtonState)this.openDevToolsBtn.HoveredState).Parent = (CustomButtonBase)(object)this.openDevToolsBtn;
		this.openDevToolsBtn.Image = (System.Drawing.Image)resources.GetObject("openDevToolsBtn.Image");
		this.openDevToolsBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.openDevToolsBtn.ImageOffset = new System.Drawing.Point(6, -1);
		((System.Windows.Forms.Control)(object)this.openDevToolsBtn).Location = new System.Drawing.Point(383, 307);
		((System.Windows.Forms.Control)(object)this.openDevToolsBtn).Name = "openDevToolsBtn";
		this.openDevToolsBtn.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.openDevToolsBtn;
		((System.Windows.Forms.Control)(object)this.openDevToolsBtn).Size = new System.Drawing.Size(267, 38);
		((System.Windows.Forms.Control)(object)this.openDevToolsBtn).TabIndex = 100;
		((System.Windows.Forms.Control)(object)this.openDevToolsBtn).Text = "Developer Tools";
		this.openDevToolsBtn.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.openDevToolsBtn).Click += new System.EventHandler(siticoneButton7_Click);
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
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton5).Location = new System.Drawing.Point(383, 394);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton5).Name = "siticoneGradientButton5";
		this.siticoneGradientButton5.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneGradientButton5;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton5).Size = new System.Drawing.Size(267, 38);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton5).TabIndex = 101;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton5).Text = "Generate Text";
		this.siticoneGradientButton5.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton5).Click += new System.EventHandler(siticoneButton7_Click_1);
		this.siticoneGradientButton4.BorderRadius = 18;
		((ButtonState)this.siticoneGradientButton4.CheckedState).Parent = (CustomButtonBase)(object)this.siticoneGradientButton4;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton4).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneGradientButton4.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneGradientButton4;
		this.siticoneGradientButton4.FillColor = System.Drawing.Color.DodgerBlue;
		this.siticoneGradientButton4.FillColor2 = System.Drawing.Color.DeepSkyBlue;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton4).Font = new System.Drawing.Font("SF Pro Text", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton4).ForeColor = System.Drawing.Color.White;
		((ButtonState)this.siticoneGradientButton4.HoveredState).Parent = (CustomButtonBase)(object)this.siticoneGradientButton4;
		this.siticoneGradientButton4.Image = (System.Drawing.Image)resources.GetObject("siticoneGradientButton4.Image");
		this.siticoneGradientButton4.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.siticoneGradientButton4.ImageOffset = new System.Drawing.Point(6, -1);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton4).Location = new System.Drawing.Point(383, 351);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton4).Name = "siticoneGradientButton4";
		this.siticoneGradientButton4.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneGradientButton4;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton4).Size = new System.Drawing.Size(267, 38);
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton4).TabIndex = 102;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton4).Text = "Audit Log";
		this.siticoneGradientButton4.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.siticoneGradientButton4).Click += new System.EventHandler(siticoneButton7_Click_2);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		this.ContextMenuStrip = this.contextMenuStrip1;
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneGradientButton4);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneGradientButton5);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.openDevToolsBtn);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneGradientButton3);
		base.Controls.Add(this.label6);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneGradientButton1);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.wdevm);
		base.Controls.Add(this.label4);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneToggleSwitch3);
		base.Controls.Add(this.label5);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneToggleSwitch1);
		base.Controls.Add(this.label3);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.hasDelay);
		base.Controls.Add(this.del);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneGradientButton2);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneWinToggleSwith1);
		base.Controls.Add(this.rem);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.pictureBox2);
		base.Controls.Add(this.label1);
		base.Name = "AdvancedSettings";
		base.Size = new System.Drawing.Size(702, 558);
		base.Load += new System.EventHandler(AdvancedSettings_Load);
		base.Click += new System.EventHandler(AdvancedSettings_Click);
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		this.contextMenuStrip1.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
