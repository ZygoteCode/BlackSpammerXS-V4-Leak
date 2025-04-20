using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Suite;

namespace BlackSpammerXS;

public class WebsocketManager : UserControl
{
	private bool HasReconnect = false;

	private List<BlackWSManager> wsList = new List<BlackWSManager>();

	private IContainer components = null;

	private SiticoneTextBox voiceChannelID;

	private SiticoneToggleSwitch xsmodeTypeEnable;

	private Label label4;

	private Label label3;

	private PictureBox pictureBox2;

	private SiticoneToggleSwitch tdel;

	private Label label2;

	private SiticoneSlider sliderDelay;

	private SiticoneToggleSwitch hasDelay;

	private Label del;

	private Label label9;

	private Label label8;

	private SiticoneCustomCheckBox hasMassTag;

	private SiticoneCustomCheckBox hasLive;

	private SiticoneButton stopBtn;

	private SiticoneButton startBtn;

	private SiticoneTextBox guildId;

	private Label label1;

	private SiticoneTextBox payloadCNT;

	private SiticoneDragControl siticoneDragControl1;

	public WebsocketManager()
	{
		InitializeComponent();
	}

	private void sliderDelay_Scroll(object sender, EventArgs e)
	{
		del.Text = "Volume: " + sliderDelay.Value + "%";
	}

	public void Dark()
	{
		Color fillColor = (BackColor = Color.FromArgb(44, 47, 51));
		Color dimGray = Color.DimGray;
		try
		{
			List<SiticoneButton> list = new List<SiticoneButton>();
			list.Add(stopBtn);
			list.Add(startBtn);
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
			((TextBox)guildId).ForeColor = Color.White;
			guildId.FillColor = fillColor;
			guildId.BorderColor = Color.Gray;
			guildId.HoveredState.BorderColor = Color.Gray;
			((TextBox)payloadCNT).ForeColor = Color.White;
			payloadCNT.FillColor = fillColor;
			payloadCNT.BorderColor = Color.Gray;
			payloadCNT.HoveredState.BorderColor = Color.Gray;
			((TextBox)voiceChannelID).ForeColor = Color.White;
			voiceChannelID.FillColor = fillColor;
			voiceChannelID.BorderColor = Color.Gray;
			voiceChannelID.HoveredState.BorderColor = Color.Gray;
			sliderDelay.FillColor = Color.Gray;
			sliderDelay.ThumbColor = Color.RoyalBlue;
		}
		catch (Exception)
		{
		}
	}

	private void WebsocketManager_Load(object sender, EventArgs e)
	{
		Control.CheckForIllegalCrossThreadCalls = false;
	}

	private void hasLive_CheckedChanged(object sender, EventArgs e)
	{
	}

	private async void hasLive_Click(object sender, EventArgs e)
	{
		try
		{
			await Task.Run(delegate
			{
				Thread.Sleep(100);
			});
			hasLive.Checked = true;
		}
		catch (Exception)
		{
		}
	}

	private void hasMassTag_CheckedChanged(object sender, EventArgs e)
	{
		HasReconnect = hasMassTag.Checked;
	}

	private void tdel_Click(object sender, EventArgs e)
	{
		tdel.Checked = true;
	}

	private void tdel_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void xsmodeTypeEnable_CheckedChanged(object sender, EventArgs e)
	{
		if (xsmodeTypeEnable.Checked)
		{
			((Control)(object)startBtn).Text = "Join Voice Channel";
		}
		else
		{
			((Control)(object)startBtn).Text = "Apply Changes";
		}
	}

	private void stopBtn_Click(object sender, EventArgs e)
	{
		ThreadPool.UnsafeQueueUserWorkItem(delegate
		{
			foreach (BlackWSManager w in wsList)
			{
				ThreadPool.UnsafeQueueUserWorkItem(delegate
				{
					try
					{
						w.disconnect();
						wsList[wsList.IndexOf(w)] = null;
					}
					catch
					{
					}
				}, null);
			}
			try
			{
				wsList.Clear();
			}
			catch
			{
			}
		}, null);
		((Control)(object)stopBtn).Enabled = false;
	}

	private async void go_online()
	{
		List<string> proxies = ImpostazioniGlobali.Proxies;
		ImpostazioniGlobali.StartLog();
		Random random = new Random();
		ImpostazioniGlobali.Log("Manager -> (Operation Starting) WS Connect => Connecting to websocket with " + ImpostazioniGlobali.Proxies.Count + " proxies and " + ImpostazioniGlobali.Tokens.Count + " tokens..");
		new Thread((ParameterizedThreadStart)async delegate
		{
			foreach (string token in ImpostazioniGlobali.Tokens)
			{
				ThreadPool.UnsafeQueueUserWorkItem(async delegate
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
						ImpostazioniGlobali.Log(proxy + " -> (" + token + ") WS Connect => Connecting to WebSocket... [Init]");
						BlackWSManager ws = new BlackWSManager(token, proxy, ImpostazioniGlobali.WS_LogBasic);
						ws.set_parsing(p: false);
						wsList.Add(ws);
						ws.connect();
						ImpostazioniGlobali.Log(proxy + " -> (" + token + ") WS Connect => Awaiting READY state..");
						ws.WaitForData();
						if (ws.DataRAvaliable())
						{
							ImpostazioniGlobali.Log(proxy + " -> (" + token + ") WS Connect => Successfully connected: READY");
							if (!string.IsNullOrEmpty(((TextBox)payloadCNT).Text))
							{
								ws.send_ws_message(((TextBox)payloadCNT).Text);
								ImpostazioniGlobali.Log(proxy + " -> (" + token + ") WS Connect => Sent payload.");
							}
						}
						else
						{
							ImpostazioniGlobali.Log(proxy + " -> (" + token + ") WS Connect => Failed to connect: No data avaliable from WS");
						}
					}
					catch (Exception)
					{
						ImpostazioniGlobali.Log(proxy + " -> (" + token + ") WS Connect => Unknown Error [Check your proxies]");
					}
				}, null);
			}
		}).Start();
		await Task.Delay(100);
		((Control)(object)startBtn).Text = "Apply Changes";
		((Control)(object)startBtn).Enabled = true;
		((Control)(object)stopBtn).Enabled = true;
	}

	private async void startBtn_Click(object sender, EventArgs e)
	{
		((Control)(object)startBtn).Text = "Connecting..";
		((Control)(object)startBtn).Enabled = false;
		if (xsmodeTypeEnable.Checked && (((TextBox)guildId).Text == "" || ((TextBox)voiceChannelID).Text == ""))
		{
			MessageBox.Show("Channel ID and Message Content are required");
			return;
		}
		if (ImpostazioniGlobali.Tokens == null || ImpostazioniGlobali.Proxies == null)
		{
			((Control)(object)startBtn).Text = "Join Voice Channel";
			((Control)(object)startBtn).Enabled = true;
			MessageBox.Show("There are no such tokens or proxies");
			return;
		}
		if (!xsmodeTypeEnable.Checked)
		{
			go_online();
			return;
		}
		List<string> proxies = ImpostazioniGlobali.Proxies;
		ImpostazioniGlobali.StartLog();
		Random random = new Random();
		ImpostazioniGlobali.Log("Manager -> (Operation Starting) Voice Spammer => Connecting in " + ((TextBox)guildId).Text + "::" + ((TextBox)voiceChannelID).Text + " with " + ImpostazioniGlobali.Proxies.Count + " proxies and " + ImpostazioniGlobali.Tokens.Count + " tokens..");
		ThreadPool.GetMaxThreads(out var _, out var o);
		ThreadPool.SetMinThreads(o - 1, o - 1);
		new Thread((ParameterizedThreadStart)async delegate
		{
			foreach (string token in ImpostazioniGlobali.Tokens)
			{
				ThreadPool.UnsafeQueueUserWorkItem(delegate
				{
					string text;
					try
					{
						text = proxies[random.Next(proxies.Count)];
					}
					catch (Exception)
					{
						text = "Error";
					}
					try
					{
						ImpostazioniGlobali.Log(text + " -> (" + token + ") Voice => Initializing Websocket Manager and Connecting..");
						BlackWSManager blackWSManager = new BlackWSManager(token, text, ImpostazioniGlobali.WS_LogBasic);
						blackWSManager.set_parsing(p: false);
						wsList.Add(blackWSManager);
						blackWSManager.connect();
						blackWSManager.WaitForData();
						if (blackWSManager.DataRAvaliable())
						{
							ImpostazioniGlobali.Log(text + " -> (" + token + ") Voice => WS Success :: READY. Connecting to voice channel..");
							blackWSManager.voice_connect(((TextBox)guildId).Text, ((TextBox)voiceChannelID).Text);
							if (!string.IsNullOrEmpty(((TextBox)payloadCNT).Text))
							{
								blackWSManager.send_ws_message(((TextBox)payloadCNT).Text);
								ImpostazioniGlobali.Log(text + " -> (" + token + ") WS Connect => Sent payload.");
							}
						}
						else
						{
							ImpostazioniGlobali.Log(text + " -> (" + token + ") Voice => Error: No data avaliable from WS.");
						}
					}
					catch (Exception)
					{
						ImpostazioniGlobali.Log(text + " -> (" + token + ") Voice => Unknown Error [Check your proxies]");
					}
				}, null);
			}
		}).Start();
		await Task.Delay(100);
		((Control)(object)startBtn).Text = "Join Voice Channel";
		((Control)(object)startBtn).Enabled = true;
		((Control)(object)stopBtn).Enabled = true;
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
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlackSpammerXS.WebsocketManager));
		this.voiceChannelID = new SiticoneTextBox();
		this.xsmodeTypeEnable = new SiticoneToggleSwitch();
		this.label4 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.tdel = new SiticoneToggleSwitch();
		this.label2 = new System.Windows.Forms.Label();
		this.sliderDelay = new SiticoneSlider();
		this.hasDelay = new SiticoneToggleSwitch();
		this.del = new System.Windows.Forms.Label();
		this.label9 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.hasMassTag = new SiticoneCustomCheckBox();
		this.hasLive = new SiticoneCustomCheckBox();
		this.stopBtn = new SiticoneButton();
		this.startBtn = new SiticoneButton();
		this.guildId = new SiticoneTextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.payloadCNT = new SiticoneTextBox();
		this.siticoneDragControl1 = new SiticoneDragControl(this.components);
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		base.SuspendLayout();
		this.voiceChannelID.Animated = false;
		((System.Windows.Forms.Control)(object)this.voiceChannelID).BackColor = System.Drawing.Color.Transparent;
		this.voiceChannelID.BorderRadius = 4;
		this.voiceChannelID.BorderThickness = 2;
		((System.Windows.Forms.Control)(object)this.voiceChannelID).Cursor = System.Windows.Forms.Cursors.IBeam;
		((TextBox)this.voiceChannelID).DefaultText = "";
		this.voiceChannelID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		this.voiceChannelID.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		this.voiceChannelID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.voiceChannelID.DisabledState.Parent = (TextBox)(object)this.voiceChannelID;
		this.voiceChannelID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.voiceChannelID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.voiceChannelID.FocusedState.Parent = (TextBox)(object)this.voiceChannelID;
		((TextBox)this.voiceChannelID).Font = new System.Drawing.Font("SF Pro Display", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		((TextBox)this.voiceChannelID).ForeColor = System.Drawing.Color.Black;
		this.voiceChannelID.HoveredState.BorderColor = System.Drawing.Color.FromArgb(213, 218, 223);
		this.voiceChannelID.HoveredState.Parent = (TextBox)(object)this.voiceChannelID;
		((System.Windows.Forms.Control)(object)this.voiceChannelID).Location = new System.Drawing.Point(18, 168);
		((System.Windows.Forms.Control)(object)this.voiceChannelID).Name = "voiceChannelID";
		((TextBox)this.voiceChannelID).PasswordChar = '\0';
		this.voiceChannelID.PlaceholderText = "Voice Channel ID";
		((TextBox)this.voiceChannelID).SelectedText = "";
		this.voiceChannelID.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.voiceChannelID;
		((System.Windows.Forms.Control)(object)this.voiceChannelID).Size = new System.Drawing.Size(658, 39);
		((System.Windows.Forms.Control)(object)this.voiceChannelID).TabIndex = 91;
		this.xsmodeTypeEnable.Checked = true;
		this.xsmodeTypeEnable.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.xsmodeTypeEnable.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.xsmodeTypeEnable.CheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.xsmodeTypeEnable.CheckedState.InnerColor = System.Drawing.Color.White;
		this.xsmodeTypeEnable.CheckedState.Parent = (ToggleSwitch)(object)this.xsmodeTypeEnable;
		((System.Windows.Forms.Control)(object)this.xsmodeTypeEnable).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.xsmodeTypeEnable).Location = new System.Drawing.Point(531, 82);
		((System.Windows.Forms.Control)(object)this.xsmodeTypeEnable).Name = "xsmodeTypeEnable";
		this.xsmodeTypeEnable.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.xsmodeTypeEnable;
		((System.Windows.Forms.Control)(object)this.xsmodeTypeEnable).Size = new System.Drawing.Size(32, 20);
		((System.Windows.Forms.Control)(object)this.xsmodeTypeEnable).TabIndex = 90;
		this.xsmodeTypeEnable.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.xsmodeTypeEnable.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.xsmodeTypeEnable.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.xsmodeTypeEnable.UncheckedState.InnerColor = System.Drawing.Color.White;
		this.xsmodeTypeEnable.UncheckedState.Parent = (ToggleSwitch)(object)this.xsmodeTypeEnable;
		((ToggleSwitch)this.xsmodeTypeEnable).CheckedChanged += new System.EventHandler(xsmodeTypeEnable_CheckedChanged);
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.Location = new System.Drawing.Point(568, 84);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(109, 15);
		this.label4.TabIndex = 89;
		this.label4.Text = "Voice Spammer";
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.ForeColor = System.Drawing.Color.Teal;
		this.label3.Location = new System.Drawing.Point(19, 70);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(276, 45);
		this.label3.TabIndex = 88;
		this.label3.Text = "The new WS Utility is here!\r\nWebsocket completely rewritten and now\r\nwith voice connection support.";
		this.pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
		this.pictureBox2.Location = new System.Drawing.Point(647, 30);
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.Size = new System.Drawing.Size(35, 26);
		this.pictureBox2.TabIndex = 87;
		this.pictureBox2.TabStop = false;
		this.tdel.Checked = true;
		this.tdel.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.tdel.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.tdel.CheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.tdel.CheckedState.InnerColor = System.Drawing.Color.White;
		this.tdel.CheckedState.Parent = (ToggleSwitch)(object)this.tdel;
		((System.Windows.Forms.Control)(object)this.tdel).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.tdel).Location = new System.Drawing.Point(528, 391);
		((System.Windows.Forms.Control)(object)this.tdel).Name = "tdel";
		this.tdel.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.tdel;
		((System.Windows.Forms.Control)(object)this.tdel).Size = new System.Drawing.Size(32, 20);
		((System.Windows.Forms.Control)(object)this.tdel).TabIndex = 86;
		this.tdel.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.tdel.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.tdel.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.tdel.UncheckedState.InnerColor = System.Drawing.Color.White;
		this.tdel.UncheckedState.Parent = (ToggleSwitch)(object)this.tdel;
		((ToggleSwitch)this.tdel).CheckedChanged += new System.EventHandler(tdel_CheckedChanged);
		((System.Windows.Forms.Control)(object)this.tdel).Click += new System.EventHandler(tdel_Click);
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.Location = new System.Drawing.Point(564, 395);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(112, 14);
		this.label2.TabIndex = 85;
		this.label2.Text = "Set Online Status";
		((System.Windows.Forms.Control)(object)this.sliderDelay).Cursor = System.Windows.Forms.Cursors.Hand;
		this.sliderDelay.LargeChange = 5;
		((System.Windows.Forms.Control)(object)this.sliderDelay).Location = new System.Drawing.Point(24, 421);
		((System.Windows.Forms.Control)(object)this.sliderDelay).Name = "sliderDelay";
		((System.Windows.Forms.Control)(object)this.sliderDelay).Size = new System.Drawing.Size(652, 60);
		((System.Windows.Forms.Control)(object)this.sliderDelay).TabIndex = 84;
		this.sliderDelay.Value = 50;
		this.sliderDelay.Scroll += new System.EventHandler(sliderDelay_Scroll);
		this.hasDelay.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasDelay.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasDelay.CheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.hasDelay.CheckedState.InnerColor = System.Drawing.Color.White;
		this.hasDelay.CheckedState.Parent = (ToggleSwitch)(object)this.hasDelay;
		((System.Windows.Forms.Control)(object)this.hasDelay).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.hasDelay).Location = new System.Drawing.Point(528, 364);
		((System.Windows.Forms.Control)(object)this.hasDelay).Name = "hasDelay";
		this.hasDelay.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.hasDelay;
		((System.Windows.Forms.Control)(object)this.hasDelay).Size = new System.Drawing.Size(32, 20);
		((System.Windows.Forms.Control)(object)this.hasDelay).TabIndex = 83;
		this.hasDelay.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasDelay.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasDelay.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.hasDelay.UncheckedState.InnerColor = System.Drawing.Color.White;
		this.hasDelay.UncheckedState.Parent = (ToggleSwitch)(object)this.hasDelay;
		this.del.AutoSize = true;
		this.del.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.del.Location = new System.Drawing.Point(565, 368);
		this.del.Name = "del";
		this.del.Size = new System.Drawing.Size(85, 14);
		this.del.TabIndex = 82;
		this.del.Text = "Volume: 50%";
		this.label9.AutoSize = true;
		this.label9.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label9.Location = new System.Drawing.Point(42, 368);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(108, 14);
		this.label9.TabIndex = 81;
		this.label9.Text = "Send Heartbeats";
		this.label8.AutoSize = true;
		this.label8.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label8.Location = new System.Drawing.Point(42, 389);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(103, 14);
		this.label8.TabIndex = 80;
		this.label8.Text = "Auto Reconnect";
		((System.Windows.Forms.Control)(object)this.hasMassTag).BackColor = System.Drawing.Color.Transparent;
		this.hasMassTag.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasMassTag.CheckedState.BorderRadius = 2;
		this.hasMassTag.CheckedState.BorderThickness = 0;
		this.hasMassTag.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasMassTag.CheckedState.Parent = (CustomCheckBox)(object)this.hasMassTag;
		((System.Windows.Forms.Control)(object)this.hasMassTag).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.hasMassTag).Location = new System.Drawing.Point(24, 389);
		((System.Windows.Forms.Control)(object)this.hasMassTag).Name = "hasMassTag";
		this.hasMassTag.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.hasMassTag;
		((System.Windows.Forms.Control)(object)this.hasMassTag).Size = new System.Drawing.Size(15, 15);
		((System.Windows.Forms.Control)(object)this.hasMassTag).TabIndex = 79;
		this.hasMassTag.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasMassTag.UncheckedState.BorderRadius = 2;
		this.hasMassTag.UncheckedState.BorderThickness = 0;
		this.hasMassTag.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasMassTag.UncheckedState.Parent = (CustomCheckBox)(object)this.hasMassTag;
		((CustomCheckBox)this.hasMassTag).CheckedChanged += new System.EventHandler(hasMassTag_CheckedChanged);
		this.hasLive.Checked = true;
		this.hasLive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasLive.CheckedState.BorderRadius = 2;
		this.hasLive.CheckedState.BorderThickness = 0;
		this.hasLive.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasLive.CheckedState.Parent = (CustomCheckBox)(object)this.hasLive;
		this.hasLive.CheckState = System.Windows.Forms.CheckState.Checked;
		((System.Windows.Forms.Control)(object)this.hasLive).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.hasLive).Location = new System.Drawing.Point(24, 368);
		((System.Windows.Forms.Control)(object)this.hasLive).Name = "hasLive";
		this.hasLive.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.hasLive;
		((System.Windows.Forms.Control)(object)this.hasLive).Size = new System.Drawing.Size(15, 15);
		((System.Windows.Forms.Control)(object)this.hasLive).TabIndex = 78;
		this.hasLive.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasLive.UncheckedState.BorderRadius = 2;
		this.hasLive.UncheckedState.BorderThickness = 0;
		this.hasLive.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasLive.UncheckedState.Parent = (CustomCheckBox)(object)this.hasLive;
		((CustomCheckBox)this.hasLive).CheckedChanged += new System.EventHandler(hasLive_CheckedChanged);
		((System.Windows.Forms.Control)(object)this.hasLive).Click += new System.EventHandler(hasLive_Click);
		((System.Windows.Forms.Control)(object)this.stopBtn).BackColor = System.Drawing.Color.Transparent;
		this.stopBtn.BorderColor = System.Drawing.Color.LightGray;
		this.stopBtn.BorderRadius = 4;
		this.stopBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
		this.stopBtn.BorderThickness = 1;
		this.stopBtn.CheckedState.Parent = (CustomButtonBase)(object)this.stopBtn;
		((System.Windows.Forms.Control)(object)this.stopBtn).Cursor = System.Windows.Forms.Cursors.Hand;
		this.stopBtn.CustomImages.Parent = (CustomButtonBase)(object)this.stopBtn;
		((System.Windows.Forms.Control)(object)this.stopBtn).Enabled = false;
		this.stopBtn.FillColor = System.Drawing.Color.Snow;
		((System.Windows.Forms.Control)(object)this.stopBtn).Font = new System.Drawing.Font("Inter", 9.749999f, System.Drawing.FontStyle.Bold);
		((System.Windows.Forms.Control)(object)this.stopBtn).ForeColor = System.Drawing.Color.Black;
		this.stopBtn.HoveredState.Parent = (CustomButtonBase)(object)this.stopBtn;
		((System.Windows.Forms.Control)(object)this.stopBtn).Location = new System.Drawing.Point(350, 508);
		((System.Windows.Forms.Control)(object)this.stopBtn).Name = "stopBtn";
		this.stopBtn.PressedColor = System.Drawing.Color.White;
		this.stopBtn.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.stopBtn;
		((System.Windows.Forms.Control)(object)this.stopBtn).Size = new System.Drawing.Size(326, 29);
		((System.Windows.Forms.Control)(object)this.stopBtn).TabIndex = 77;
		((System.Windows.Forms.Control)(object)this.stopBtn).Text = "Close Websockets";
		this.stopBtn.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.stopBtn).Click += new System.EventHandler(stopBtn_Click);
		((System.Windows.Forms.Control)(object)this.startBtn).BackColor = System.Drawing.Color.Transparent;
		this.startBtn.BorderColor = System.Drawing.Color.LightGray;
		this.startBtn.BorderRadius = 4;
		this.startBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
		this.startBtn.BorderThickness = 1;
		this.startBtn.CheckedState.Parent = (CustomButtonBase)(object)this.startBtn;
		((System.Windows.Forms.Control)(object)this.startBtn).Cursor = System.Windows.Forms.Cursors.Hand;
		this.startBtn.CustomImages.Parent = (CustomButtonBase)(object)this.startBtn;
		this.startBtn.FillColor = System.Drawing.Color.Snow;
		((System.Windows.Forms.Control)(object)this.startBtn).Font = new System.Drawing.Font("Inter", 9.749999f, System.Drawing.FontStyle.Bold);
		((System.Windows.Forms.Control)(object)this.startBtn).ForeColor = System.Drawing.Color.Black;
		this.startBtn.HoveredState.Parent = (CustomButtonBase)(object)this.startBtn;
		((System.Windows.Forms.Control)(object)this.startBtn).Location = new System.Drawing.Point(18, 508);
		((System.Windows.Forms.Control)(object)this.startBtn).Name = "startBtn";
		this.startBtn.PressedColor = System.Drawing.Color.White;
		this.startBtn.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.startBtn;
		((System.Windows.Forms.Control)(object)this.startBtn).Size = new System.Drawing.Size(326, 29);
		((System.Windows.Forms.Control)(object)this.startBtn).TabIndex = 76;
		((System.Windows.Forms.Control)(object)this.startBtn).Text = "Join Voice Channel";
		this.startBtn.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.startBtn).Click += new System.EventHandler(startBtn_Click);
		this.guildId.Animated = false;
		((System.Windows.Forms.Control)(object)this.guildId).BackColor = System.Drawing.Color.Transparent;
		this.guildId.BorderRadius = 4;
		this.guildId.BorderThickness = 2;
		((System.Windows.Forms.Control)(object)this.guildId).Cursor = System.Windows.Forms.Cursors.IBeam;
		((TextBox)this.guildId).DefaultText = "";
		this.guildId.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		this.guildId.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		this.guildId.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.guildId.DisabledState.Parent = (TextBox)(object)this.guildId;
		this.guildId.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.guildId.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.guildId.FocusedState.Parent = (TextBox)(object)this.guildId;
		((TextBox)this.guildId).Font = new System.Drawing.Font("SF Pro Display", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		((TextBox)this.guildId).ForeColor = System.Drawing.Color.Black;
		this.guildId.HoveredState.BorderColor = System.Drawing.Color.FromArgb(213, 218, 223);
		this.guildId.HoveredState.Parent = (TextBox)(object)this.guildId;
		((System.Windows.Forms.Control)(object)this.guildId).Location = new System.Drawing.Point(18, 127);
		((System.Windows.Forms.Control)(object)this.guildId).Name = "guildId";
		((TextBox)this.guildId).PasswordChar = '\0';
		this.guildId.PlaceholderText = "Guild ID";
		((TextBox)this.guildId).SelectedText = "";
		this.guildId.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.guildId;
		((System.Windows.Forms.Control)(object)this.guildId).Size = new System.Drawing.Size(658, 35);
		((System.Windows.Forms.Control)(object)this.guildId).TabIndex = 74;
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Inter", 15.75f, System.Drawing.FontStyle.Bold);
		this.label1.Location = new System.Drawing.Point(13, 33);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(195, 25);
		this.label1.TabIndex = 73;
		this.label1.Text = "Websocket Utility";
		this.payloadCNT.Animated = false;
		((System.Windows.Forms.Control)(object)this.payloadCNT).BackColor = System.Drawing.Color.Transparent;
		this.payloadCNT.BorderRadius = 4;
		this.payloadCNT.BorderThickness = 2;
		((System.Windows.Forms.Control)(object)this.payloadCNT).Cursor = System.Windows.Forms.Cursors.IBeam;
		((TextBox)this.payloadCNT).DefaultText = "";
		this.payloadCNT.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		this.payloadCNT.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		this.payloadCNT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.payloadCNT.DisabledState.Parent = (TextBox)(object)this.payloadCNT;
		this.payloadCNT.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.payloadCNT.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.payloadCNT.FocusedState.Parent = (TextBox)(object)this.payloadCNT;
		((TextBox)this.payloadCNT).Font = new System.Drawing.Font("SF Pro Display", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		((TextBox)this.payloadCNT).ForeColor = System.Drawing.Color.Black;
		this.payloadCNT.HoveredState.BorderColor = System.Drawing.Color.FromArgb(213, 218, 223);
		this.payloadCNT.HoveredState.Parent = (TextBox)(object)this.payloadCNT;
		((System.Windows.Forms.Control)(object)this.payloadCNT).Location = new System.Drawing.Point(18, 213);
		((TextBox)this.payloadCNT).Multiline = true;
		((System.Windows.Forms.Control)(object)this.payloadCNT).Name = "payloadCNT";
		((TextBox)this.payloadCNT).PasswordChar = '\0';
		this.payloadCNT.PlaceholderText = "Payload*";
		((TextBox)this.payloadCNT).SelectedText = "";
		this.payloadCNT.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.payloadCNT;
		((System.Windows.Forms.Control)(object)this.payloadCNT).Size = new System.Drawing.Size(658, 130);
		((System.Windows.Forms.Control)(object)this.payloadCNT).TabIndex = 75;
		this.siticoneDragControl1.TargetControl = this;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.Controls.Add((System.Windows.Forms.Control)(object)this.voiceChannelID);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.xsmodeTypeEnable);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.pictureBox2);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.tdel);
		base.Controls.Add(this.label2);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.sliderDelay);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.hasDelay);
		base.Controls.Add(this.del);
		base.Controls.Add(this.label9);
		base.Controls.Add(this.label8);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.hasMassTag);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.hasLive);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.stopBtn);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.startBtn);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.payloadCNT);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.guildId);
		base.Controls.Add(this.label1);
		base.Name = "WebsocketManager";
		base.Size = new System.Drawing.Size(695, 560);
		base.Load += new System.EventHandler(WebsocketManager_Load);
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
