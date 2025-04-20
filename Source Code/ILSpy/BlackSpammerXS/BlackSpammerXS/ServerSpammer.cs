using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Suite;

namespace BlackSpammerXS;

public class ServerSpammer : UserControl
{
	private bool cans = false;

	private Thread _0;

	private List<string> users = new List<string>();

	private Random random = new Random();

	private List<string> proxies = ImpostazioniGlobali.Proxies;

	private List<string> multi_channels = new List<string>();

	private List<string> multi_messages = new List<string>();

	private static Random randdom = new Random();

	private ulong currentMessages = 0uL;

	private IContainer components = null;

	private Label label1;

	private SiticoneTextBox channelId;

	private SiticoneTextBox msgContent;

	private SiticoneButton startBtn;

	private SiticoneButton stopBtn;

	private Label label9;

	private Label label8;

	private SiticoneCustomCheckBox hasMassTag;

	private SiticoneCustomCheckBox hasLive;

	private SiticoneToggleSwitch hasDelay;

	private Label del;

	private SiticoneSlider sliderDelay;

	private Label label2;

	private SiticoneToggleSwitch tdel;

	private PictureBox pictureBox2;

	private SiticoneDragControl siticoneDragControl1;

	private Label label3;

	private SiticoneToggleSwitch xsmodeTypeEnable;

	private Label label4;

	private SiticoneTextBox messageReferenceTxt;

	private Label label5;

	private SiticoneCustomCheckBox hasMultiChannels;

	private Label label6;

	private SiticoneCustomCheckBox hasMultiMessages;

	public ServerSpammer()
	{
		InitializeComponent();
	}

	private void sliderThreads_Scroll(object sender, EventArgs e)
	{
		del.Text = "Delay: " + sliderDelay.Value + "ms";
	}

	private void hasEmbed_Click(object sender, EventArgs e)
	{
	}

	private void multi_channel_p(string ch)
	{
		try
		{
			multi_channels.Clear();
			multi_channels = null;
			multi_channels = new List<string>();
			string[] array = ch.Split(',');
			string[] array2 = array;
			foreach (string text in array2)
			{
				string item = text.Replace(" ", "");
				multi_channels.Add(item);
			}
		}
		catch
		{
		}
	}

	private void multi_msg_p(string ch)
	{
		try
		{
			multi_messages.Clear();
			multi_messages = null;
			multi_messages = new List<string>();
			string[] array = ch.Split(',');
			string[] array2 = array;
			foreach (string item in array2)
			{
				multi_messages.Add(item);
			}
		}
		catch
		{
		}
	}

	private async void startBtn_Click(object sender, EventArgs e)
	{
		if (((TextBox)channelId).Text == "" || ((TextBox)msgContent).Text == "")
		{
			MessageBox.Show("Channel ID and Message Content are required");
			return;
		}
		((Control)(object)startBtn).Text = "Starting..";
		((Control)(object)startBtn).Enabled = false;
		if (ImpostazioniGlobali.Tokens == null || ImpostazioniGlobali.Proxies == null)
		{
			await Task.Delay(50);
			((Control)(object)startBtn).Text = "Start";
			((Control)(object)startBtn).Enabled = true;
			MessageBox.Show("There are no such tokens or proxies");
			return;
		}
		if (hasMultiChannels.Checked && ImpostazioniGlobali.Tokens.Count < 20)
		{
			await Task.Delay(50);
			((Control)(object)startBtn).Text = "Start";
			((Control)(object)startBtn).Enabled = true;
			MessageBox.Show("Per utilizzare il multi channel, sono necessari almeno 20 tokens");
			return;
		}
		ImpostazioniGlobali.StartLog();
		proxies = ImpostazioniGlobali.Proxies;
		random = new Random();
		ImpostazioniGlobali.Log("Manager -> (Operation Starting) Server Spamming => Spamming in " + ((TextBox)channelId).Text + " with " + proxies.Count + " proxies and " + ImpostazioniGlobali.Tokens.Count + " tokens.. Delay has been set to " + sliderDelay.Value);
		bool hasDel = hasDelay.Checked;
		if (sliderDelay.Value == 0)
		{
			hasDel = false;
			hasDelay.Checked = false;
		}
		try
		{
			AuditManager auditManager = ImpostazioniGlobali.auditManager;
			auditManager.LogActionSpam(((TextBox)channelId).Text, ((TextBox)msgContent).Text, ((TextBox)messageReferenceTxt).Text);
		}
		catch (Exception)
		{
		}
		cans = true;
		_0 = new Thread((ParameterizedThreadStart)async delegate
		{
			ThreadPool.GetMaxThreads(out var _, out var o);
			ThreadPool.SetMinThreads(o - 1, o - 1);
			while (cans)
			{
				Thread.Sleep(1);
				ThreadPool.UnsafeQueueUserWorkItem(delegate
				{
					if (hasDel)
					{
						ImpostazioniGlobali.Log("Manager -> (Delay) (Thread " + Thread.CurrentThread.ManagedThreadId + ") Attack => Awaiting " + sliderDelay.Value + " before spamming..");
						Thread.Sleep(sliderDelay.Value);
					}
					if (hasMultiChannels.Checked)
					{
						multi_channel_p(((TextBox)channelId).Text);
					}
					if (hasMultiMessages.Checked)
					{
						multi_msg_p(((TextBox)msgContent).Text);
					}
					doSpam(null, hasDel);
				}, null);
			}
		});
		_0.Start();
		await Task.Delay(100);
		((Control)(object)startBtn).Text = "Start";
		((Control)(object)stopBtn).Enabled = true;
	}

	public static string RandomString(int length)
	{
		return new string((from s in Enumerable.Repeat("AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789", length)
			select s[randdom.Next(s.Length)]).ToArray());
	}

	public string RandStr()
	{
		return RandomString(15);
	}

	private string RepeatMTXF(int t)
	{
		string text = "";
		int num = 0;
		while (num > t + 1)
		{
			text = text + "<@" + users[random.Next(users.Count)] + ">";
			t++;
		}
		return text;
	}

	private async void doSpam(object o, bool hasDel)
	{
		if (ImpostazioniGlobali.Tokens == null || ImpostazioniGlobali.Tokens.Count == 0)
		{
			cans = false;
		}
		if (!cans)
		{
			Thread.CurrentThread.Interrupt();
			return;
		}
		string token = ImpostazioniGlobali.Tokens[random.Next(ImpostazioniGlobali.Tokens.Count)];
		Control.CheckForIllegalCrossThreadCalls = false;
		string proxy;
		try
		{
			proxy = proxies[random.Next(proxies.Count)];
		}
		catch (Exception)
		{
			proxy = "Error";
		}
		Control.CheckForIllegalCrossThreadCalls = false;
		if (!cans)
		{
			Thread.CurrentThread.Interrupt();
			return;
		}
		try
		{
			if (hasDel)
			{
				ImpostazioniGlobali.Log("Manager -> (Delay) (Thread " + Thread.CurrentThread.ManagedThreadId + ") Attack => Awaiting " + sliderDelay.Value + " before spamming..");
				Thread.Sleep(sliderDelay.Value);
			}
			HttpClientHandler handler = new HttpClientHandler();
			handler.PreAuthenticate = true;
			handler.UseProxy = true;
			handler.Proxy = new WebProxy(proxy.Split(':')[0], int.Parse(proxy.Split(':')[1]));
			string msg = ((TextBox)msgContent).Text;
			if (hasMultiMessages.Checked)
			{
				msg = multi_messages[randdom.Next(multi_messages.Count)];
			}
			List<string> msgLines = new List<string>(((TextBox)msgContent).Lines);
			if (msgLines.Count != 1)
			{
				string mmr = "";
				foreach (string line in msgLines)
				{
					mmr = mmr + " \\u000d" + line;
				}
				msg = mmr;
			}
			if (hasMassTag.Checked && users.Count > 0)
			{
				try
				{
					msg = msg.Replace("[mtag]", "<@" + users[random.Next(users.Count)] + ">");
					for (int nnnn = 0; nnnn < 101; nnnn++)
					{
						msg = msg.Replace("[mtag" + nnnn + "]", "<@" + users[random.Next(users.Count)] + ">");
					}
				}
				catch (Exception)
				{
				}
			}
			if (msg.Contains("[rand]"))
			{
				msg = msg.Replace("[rand]", RandStr());
			}
			string payload__c = "{\"content\": \"" + msg + "\", \"tts\": false}";
			string channel_af = ((TextBox)channelId).Text;
			if (hasMultiChannels.Checked)
			{
				channel_af = multi_channels[randdom.Next(multi_channels.Count)];
			}
			if (((TextBox)messageReferenceTxt).Text.Length != 0)
			{
				payload__c = "{\"content\": \"" + msg + "\",\"message_reference\": {\"channel_id\": \"" + channel_af + "\", \"message_id\": \"" + ((TextBox)messageReferenceTxt).Text + "\"},\"tts\": false}";
			}
			HttpClient http = new HttpClient((HttpMessageHandler)(object)handler);
			HttpRequestMessage val = new HttpRequestMessage
			{
				RequestUri = new Uri("https://discord.com/api/v9/channels/" + channel_af + "/messages"),
				Content = (HttpContent)new StringContent(payload__c, Encoding.UTF8, "application/json"),
				Method = HttpMethod.Post
			};
			((HttpHeaders)val.Headers).Add("Authorization", token);
			((HttpHeaders)val.Headers).Add("Accept-Language", "it");
			((HttpHeaders)val.Headers).Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36");
			((HttpHeaders)val.Headers).Add("X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9");
			((HttpHeaders)val.Headers).Add("Accept", "*/*");
			((HttpHeaders)val.Headers).Add("Cookie", "locale=it");
			((HttpHeaders)val.Headers).Add("Referer", "https://discord.com/channels/" + channel_af);
			HttpRequestMessage request = val;
			string _ = await (await http.SendAsync(request)).Content.ReadAsStringAsync();
			if (_.Contains("{\"id\":"))
			{
				if (!hasMultiChannels.Checked)
				{
					ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Server Spamming [" + channel_af + "] => Message successfully sent");
				}
				else
				{
					ImpostazioniGlobali.Log(proxy + " -> (" + token + ") [Multi Channel] Server Spamming [" + channel_af + "] => Message successfully sent");
				}
			}
			else if (ImpostazioniGlobali.StreamerMode)
			{
				ImpostazioniGlobali.Log(proxy + " -> (Token " + ImpostazioniGlobali.Tokens.IndexOf(token) + ") Server Spamming [" + channel_af + "] => " + _);
			}
			else if (!hasMultiChannels.Checked)
			{
				ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Server Spamming [" + channel_af + "] => " + _);
			}
			else
			{
				ImpostazioniGlobali.Log(proxy + " -> (" + token + ") [Multi Channel] Server Spamming [" + channel_af + "] => " + _);
			}
			try
			{
				if (_.Contains("{\"id\":"))
				{
					if (currentMessages > 100000000)
					{
						label9.Text = "Live Text (∞)";
					}
					else
					{
						currentMessages++;
						label9.Text = "Live Text (" + currentMessages + ")";
					}
				}
			}
			catch
			{
			}
			try
			{
				((HttpMessageInvoker)http).Dispose();
				((HttpMessageHandler)handler).Dispose();
				request.Dispose();
				token = null;
				proxy = null;
			}
			catch
			{
			}
			try
			{
				Thread.CurrentThread.Abort();
			}
			catch
			{
			}
		}
		catch (Exception ex3)
		{
			if (ex3.GetType() == typeof(ThreadAbortException))
			{
				return;
			}
			if (ImpostazioniGlobali.StreamerMode)
			{
				ImpostazioniGlobali.Log(proxy + " -> (Token " + ImpostazioniGlobali.Tokens.IndexOf(token) + ") Server Spamming [" + ((TextBox)channelId).Text + "] => Unknown Error [Check your proxies]");
			}
			else
			{
				ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Server Spamming [" + ((TextBox)channelId).Text + "] => Unknown Error [Check your proxies]");
			}
			try
			{
				Thread.CurrentThread.Abort();
			}
			catch
			{
			}
		}
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

	private void stopBtn_Click(object sender, EventArgs e)
	{
		try
		{
			cans = false;
			((Control)(object)stopBtn).Enabled = false;
			((Control)(object)startBtn).Enabled = true;
			try
			{
				_0.Abort();
			}
			catch
			{
			}
			_0 = null;
			currentMessages = 0uL;
			label9.Text = "Live Text";
			currentMessages = 0uL;
			ImpostazioniGlobali.Log("Manager -> (Stop) Server Spamming [" + ((TextBox)channelId).Text + "] => Attack stopped.");
		}
		catch (Exception)
		{
		}
	}

	private void hasMassTag_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void stopBtn_MouseLeave(object sender, EventArgs e)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Expected O, but got Unknown
		try
		{
			SiticoneButton val = (SiticoneButton)sender;
			if (val != null)
			{
				val.BorderThickness = 1;
			}
		}
		catch (Exception)
		{
		}
	}

	private void stopBtn_MouseEnter(object sender, EventArgs e)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Expected O, but got Unknown
		try
		{
			SiticoneButton val = (SiticoneButton)sender;
			if (val != null)
			{
				val.BorderThickness = 1;
			}
		}
		catch (Exception)
		{
		}
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
			((TextBox)channelId).ForeColor = Color.White;
			channelId.FillColor = fillColor;
			channelId.BorderColor = Color.Gray;
			channelId.HoveredState.BorderColor = Color.Gray;
			((TextBox)msgContent).ForeColor = Color.White;
			msgContent.FillColor = fillColor;
			msgContent.BorderColor = Color.Gray;
			msgContent.HoveredState.BorderColor = Color.Gray;
			((TextBox)messageReferenceTxt).ForeColor = Color.White;
			messageReferenceTxt.FillColor = fillColor;
			messageReferenceTxt.BorderColor = Color.Gray;
			messageReferenceTxt.HoveredState.BorderColor = Color.Gray;
			sliderDelay.FillColor = Color.Gray;
			sliderDelay.ThumbColor = Color.RoyalBlue;
		}
		catch (Exception)
		{
		}
	}

	private void ServerSpammer_Load(object sender, EventArgs e)
	{
		Control.CheckForIllegalCrossThreadCalls = false;
		ImpostazioniGlobali._bridgeGS = delegate(int a, int b, object c)
		{
			if (a == 1 && b == 1)
			{
				users.Add(c?.ToString() ?? "");
				label8.Text = "Mass Tag V2X (" + users.Count + ")";
			}
			if (a == 1 && b == 2)
			{
				users.Remove(c?.ToString() ?? "");
				label8.Text = "Mass Tag V2X (" + users.Count + ")";
			}
			if (a == 1 && b == 0)
			{
				users.Clear();
				label8.Text = "Mass Tag V2X";
			}
		};
		ImpostazioniGlobali._bridgeLogPerform.Add(delegate(int a, int b, object[] i)
		{
			if (a == 1)
			{
				try
				{
					((TextBox)channelId).Text = (string)i[0];
					((TextBox)msgContent).Text = (string)i[1];
					((TextBox)messageReferenceTxt).Text = (string)i[2];
				}
				catch (Exception)
				{
				}
			}
		});
	}

	private void tdel_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void xsmodeTypeEnable_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void xsmodeTypeEnable_Click(object sender, EventArgs e)
	{
		xsmodeTypeEnable.Checked = true;
	}

	private void tdel_Click(object sender, EventArgs e)
	{
		if (tdel.Checked)
		{
			xsmodeTypeEnable.Checked = false;
			label8.Text = "Old V2X Mass Tag";
		}
		else
		{
			xsmodeTypeEnable.Checked = true;
			label8.Text = "Mass Tag V3X";
		}
	}

	private void hasDelay_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void mbvfbypass_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void label3_Click(object sender, EventArgs e)
	{
	}

	private void hasMultiChannels_CheckedChanged(object sender, EventArgs e)
	{
		if (hasMultiChannels.Checked)
		{
			channelId.PlaceholderText = "Channels ID (separated by comma)";
		}
		else
		{
			channelId.PlaceholderText = "Channel ID";
		}
	}

	private void channelId_TextChanged(object sender, EventArgs e)
	{
	}

	private void siticoneCustomCheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		if (hasMultiMessages.Checked)
		{
			msgContent.PlaceholderText = "Messages (separated by comma)";
		}
		else
		{
			msgContent.PlaceholderText = "Message";
		}
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
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlackSpammerXS.ServerSpammer));
		this.label1 = new System.Windows.Forms.Label();
		this.channelId = new SiticoneTextBox();
		this.msgContent = new SiticoneTextBox();
		this.startBtn = new SiticoneButton();
		this.stopBtn = new SiticoneButton();
		this.label9 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.hasMassTag = new SiticoneCustomCheckBox();
		this.hasLive = new SiticoneCustomCheckBox();
		this.hasDelay = new SiticoneToggleSwitch();
		this.del = new System.Windows.Forms.Label();
		this.sliderDelay = new SiticoneSlider();
		this.label2 = new System.Windows.Forms.Label();
		this.tdel = new SiticoneToggleSwitch();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.siticoneDragControl1 = new SiticoneDragControl(this.components);
		this.label3 = new System.Windows.Forms.Label();
		this.xsmodeTypeEnable = new SiticoneToggleSwitch();
		this.label4 = new System.Windows.Forms.Label();
		this.messageReferenceTxt = new SiticoneTextBox();
		this.label5 = new System.Windows.Forms.Label();
		this.hasMultiChannels = new SiticoneCustomCheckBox();
		this.label6 = new System.Windows.Forms.Label();
		this.hasMultiMessages = new SiticoneCustomCheckBox();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Inter", 15.75f, System.Drawing.FontStyle.Bold);
		this.label1.Location = new System.Drawing.Point(13, 43);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(186, 25);
		this.label1.TabIndex = 2;
		this.label1.Text = "Server Spammer";
		this.channelId.Animated = false;
		((System.Windows.Forms.Control)(object)this.channelId).BackColor = System.Drawing.Color.Transparent;
		this.channelId.BorderRadius = 4;
		this.channelId.BorderThickness = 2;
		((System.Windows.Forms.Control)(object)this.channelId).Cursor = System.Windows.Forms.Cursors.IBeam;
		((TextBox)this.channelId).DefaultText = "";
		this.channelId.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		this.channelId.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		this.channelId.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.channelId.DisabledState.Parent = (TextBox)(object)this.channelId;
		this.channelId.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.channelId.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.channelId.FocusedState.Parent = (TextBox)(object)this.channelId;
		((TextBox)this.channelId).Font = new System.Drawing.Font("SF Pro Display", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		((TextBox)this.channelId).ForeColor = System.Drawing.Color.Black;
		this.channelId.HoveredState.BorderColor = System.Drawing.Color.FromArgb(213, 218, 223);
		this.channelId.HoveredState.Parent = (TextBox)(object)this.channelId;
		((System.Windows.Forms.Control)(object)this.channelId).Location = new System.Drawing.Point(18, 139);
		((System.Windows.Forms.Control)(object)this.channelId).Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		((System.Windows.Forms.Control)(object)this.channelId).Name = "channelId";
		((TextBox)this.channelId).PasswordChar = '\0';
		this.channelId.PlaceholderText = "Channel ID ";
		((TextBox)this.channelId).SelectedText = "";
		this.channelId.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.channelId;
		((System.Windows.Forms.Control)(object)this.channelId).Size = new System.Drawing.Size(658, 35);
		((System.Windows.Forms.Control)(object)this.channelId).TabIndex = 34;
		((TextBox)this.channelId).TextChanged += new System.EventHandler(channelId_TextChanged);
		this.msgContent.Animated = false;
		((System.Windows.Forms.Control)(object)this.msgContent).BackColor = System.Drawing.Color.Transparent;
		this.msgContent.BorderRadius = 4;
		this.msgContent.BorderThickness = 2;
		((System.Windows.Forms.Control)(object)this.msgContent).Cursor = System.Windows.Forms.Cursors.IBeam;
		((TextBox)this.msgContent).DefaultText = "";
		this.msgContent.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		this.msgContent.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		this.msgContent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.msgContent.DisabledState.Parent = (TextBox)(object)this.msgContent;
		this.msgContent.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.msgContent.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.msgContent.FocusedState.Parent = (TextBox)(object)this.msgContent;
		((TextBox)this.msgContent).Font = new System.Drawing.Font("SF Pro Display", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		((TextBox)this.msgContent).ForeColor = System.Drawing.Color.Black;
		this.msgContent.HoveredState.BorderColor = System.Drawing.Color.FromArgb(213, 218, 223);
		this.msgContent.HoveredState.Parent = (TextBox)(object)this.msgContent;
		((System.Windows.Forms.Control)(object)this.msgContent).Location = new System.Drawing.Point(18, 225);
		((System.Windows.Forms.Control)(object)this.msgContent).Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		((TextBox)this.msgContent).Multiline = true;
		((System.Windows.Forms.Control)(object)this.msgContent).Name = "msgContent";
		((TextBox)this.msgContent).PasswordChar = '\0';
		this.msgContent.PlaceholderText = "Message";
		((TextBox)this.msgContent).SelectedText = "";
		this.msgContent.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.msgContent;
		((System.Windows.Forms.Control)(object)this.msgContent).Size = new System.Drawing.Size(658, 130);
		((System.Windows.Forms.Control)(object)this.msgContent).TabIndex = 35;
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
		((System.Windows.Forms.Control)(object)this.startBtn).Location = new System.Drawing.Point(18, 514);
		((System.Windows.Forms.Control)(object)this.startBtn).Name = "startBtn";
		this.startBtn.PressedColor = System.Drawing.Color.White;
		this.startBtn.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.startBtn;
		((System.Windows.Forms.Control)(object)this.startBtn).Size = new System.Drawing.Size(326, 29);
		((System.Windows.Forms.Control)(object)this.startBtn).TabIndex = 36;
		((System.Windows.Forms.Control)(object)this.startBtn).Text = "Start";
		this.startBtn.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.startBtn).Click += new System.EventHandler(startBtn_Click);
		((System.Windows.Forms.Control)(object)this.startBtn).MouseEnter += new System.EventHandler(stopBtn_MouseEnter);
		((System.Windows.Forms.Control)(object)this.startBtn).MouseLeave += new System.EventHandler(stopBtn_MouseLeave);
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
		((System.Windows.Forms.Control)(object)this.stopBtn).Location = new System.Drawing.Point(350, 514);
		((System.Windows.Forms.Control)(object)this.stopBtn).Name = "stopBtn";
		this.stopBtn.PressedColor = System.Drawing.Color.White;
		this.stopBtn.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.stopBtn;
		((System.Windows.Forms.Control)(object)this.stopBtn).Size = new System.Drawing.Size(326, 29);
		((System.Windows.Forms.Control)(object)this.stopBtn).TabIndex = 37;
		((System.Windows.Forms.Control)(object)this.stopBtn).Text = "Stop";
		this.stopBtn.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.stopBtn).Click += new System.EventHandler(stopBtn_Click);
		((System.Windows.Forms.Control)(object)this.stopBtn).MouseEnter += new System.EventHandler(stopBtn_MouseEnter);
		((System.Windows.Forms.Control)(object)this.stopBtn).MouseLeave += new System.EventHandler(stopBtn_MouseLeave);
		this.label9.AutoSize = true;
		this.label9.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label9.Location = new System.Drawing.Point(42, 367);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(60, 14);
		this.label9.TabIndex = 41;
		this.label9.Text = "Live Text";
		this.label8.AutoSize = true;
		this.label8.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label8.Location = new System.Drawing.Point(42, 388);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(93, 14);
		this.label8.TabIndex = 40;
		this.label8.Text = "Mass Tag V2X";
		((System.Windows.Forms.Control)(object)this.hasMassTag).BackColor = System.Drawing.Color.Transparent;
		this.hasMassTag.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasMassTag.CheckedState.BorderRadius = 2;
		this.hasMassTag.CheckedState.BorderThickness = 0;
		this.hasMassTag.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasMassTag.CheckedState.Parent = (CustomCheckBox)(object)this.hasMassTag;
		((System.Windows.Forms.Control)(object)this.hasMassTag).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.hasMassTag).Location = new System.Drawing.Point(24, 387);
		((System.Windows.Forms.Control)(object)this.hasMassTag).Name = "hasMassTag";
		this.hasMassTag.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.hasMassTag;
		((System.Windows.Forms.Control)(object)this.hasMassTag).Size = new System.Drawing.Size(15, 15);
		((System.Windows.Forms.Control)(object)this.hasMassTag).TabIndex = 39;
		this.hasMassTag.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasMassTag.UncheckedState.BorderRadius = 2;
		this.hasMassTag.UncheckedState.BorderThickness = 0;
		this.hasMassTag.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasMassTag.UncheckedState.Parent = (CustomCheckBox)(object)this.hasMassTag;
		((CustomCheckBox)this.hasMassTag).CheckedChanged += new System.EventHandler(hasMassTag_CheckedChanged);
		((System.Windows.Forms.Control)(object)this.hasMassTag).Click += new System.EventHandler(hasEmbed_Click);
		this.hasLive.Checked = true;
		this.hasLive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasLive.CheckedState.BorderRadius = 2;
		this.hasLive.CheckedState.BorderThickness = 0;
		this.hasLive.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasLive.CheckedState.Parent = (CustomCheckBox)(object)this.hasLive;
		this.hasLive.CheckState = System.Windows.Forms.CheckState.Checked;
		((System.Windows.Forms.Control)(object)this.hasLive).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.hasLive).Location = new System.Drawing.Point(24, 366);
		((System.Windows.Forms.Control)(object)this.hasLive).Name = "hasLive";
		this.hasLive.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.hasLive;
		((System.Windows.Forms.Control)(object)this.hasLive).Size = new System.Drawing.Size(15, 15);
		((System.Windows.Forms.Control)(object)this.hasLive).TabIndex = 38;
		this.hasLive.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasLive.UncheckedState.BorderRadius = 2;
		this.hasLive.UncheckedState.BorderThickness = 0;
		this.hasLive.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasLive.UncheckedState.Parent = (CustomCheckBox)(object)this.hasLive;
		((CustomCheckBox)this.hasLive).CheckedChanged += new System.EventHandler(hasLive_CheckedChanged);
		((System.Windows.Forms.Control)(object)this.hasLive).Click += new System.EventHandler(hasLive_Click);
		this.hasDelay.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasDelay.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasDelay.CheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.hasDelay.CheckedState.InnerColor = System.Drawing.Color.White;
		this.hasDelay.CheckedState.Parent = (ToggleSwitch)(object)this.hasDelay;
		((System.Windows.Forms.Control)(object)this.hasDelay).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.hasDelay).Location = new System.Drawing.Point(528, 376);
		((System.Windows.Forms.Control)(object)this.hasDelay).Name = "hasDelay";
		this.hasDelay.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.hasDelay;
		((System.Windows.Forms.Control)(object)this.hasDelay).Size = new System.Drawing.Size(32, 20);
		((System.Windows.Forms.Control)(object)this.hasDelay).TabIndex = 43;
		this.hasDelay.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasDelay.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasDelay.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.hasDelay.UncheckedState.InnerColor = System.Drawing.Color.White;
		this.hasDelay.UncheckedState.Parent = (ToggleSwitch)(object)this.hasDelay;
		((ToggleSwitch)this.hasDelay).CheckedChanged += new System.EventHandler(hasDelay_CheckedChanged);
		this.del.AutoSize = true;
		this.del.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.del.Location = new System.Drawing.Point(565, 378);
		this.del.Name = "del";
		this.del.Size = new System.Drawing.Size(82, 14);
		this.del.TabIndex = 42;
		this.del.Text = "Delay: 50ms";
		((System.Windows.Forms.Control)(object)this.sliderDelay).Cursor = System.Windows.Forms.Cursors.Hand;
		this.sliderDelay.LargeChange = 5;
		((System.Windows.Forms.Control)(object)this.sliderDelay).Location = new System.Drawing.Point(24, 448);
		((System.Windows.Forms.Control)(object)this.sliderDelay).Name = "sliderDelay";
		((System.Windows.Forms.Control)(object)this.sliderDelay).Size = new System.Drawing.Size(652, 60);
		((System.Windows.Forms.Control)(object)this.sliderDelay).TabIndex = 44;
		this.sliderDelay.Value = 50;
		this.sliderDelay.Scroll += new System.EventHandler(sliderThreads_Scroll);
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.Location = new System.Drawing.Point(564, 407);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(100, 14);
		this.label2.TabIndex = 46;
		this.label2.Text = "Old X Mass Tag";
		this.tdel.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.tdel.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.tdel.CheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.tdel.CheckedState.InnerColor = System.Drawing.Color.White;
		this.tdel.CheckedState.Parent = (ToggleSwitch)(object)this.tdel;
		((System.Windows.Forms.Control)(object)this.tdel).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.tdel).Enabled = false;
		((System.Windows.Forms.Control)(object)this.tdel).Location = new System.Drawing.Point(528, 403);
		((System.Windows.Forms.Control)(object)this.tdel).Name = "tdel";
		this.tdel.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.tdel;
		((System.Windows.Forms.Control)(object)this.tdel).Size = new System.Drawing.Size(32, 20);
		((System.Windows.Forms.Control)(object)this.tdel).TabIndex = 47;
		this.tdel.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.tdel.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.tdel.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.tdel.UncheckedState.InnerColor = System.Drawing.Color.White;
		this.tdel.UncheckedState.Parent = (ToggleSwitch)(object)this.tdel;
		((ToggleSwitch)this.tdel).CheckedChanged += new System.EventHandler(tdel_CheckedChanged);
		((System.Windows.Forms.Control)(object)this.tdel).Click += new System.EventHandler(tdel_Click);
		this.pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
		this.pictureBox2.Location = new System.Drawing.Point(647, 42);
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.Size = new System.Drawing.Size(35, 23);
		this.pictureBox2.TabIndex = 68;
		this.pictureBox2.TabStop = false;
		this.siticoneDragControl1.TargetControl = this;
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.ForeColor = System.Drawing.Color.Teal;
		this.label3.Location = new System.Drawing.Point(19, 78);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(498, 45);
		this.label3.TabIndex = 69;
		this.label3.Text = resources.GetString("label3.Text");
		this.label3.Click += new System.EventHandler(label3_Click);
		this.xsmodeTypeEnable.Checked = true;
		this.xsmodeTypeEnable.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.xsmodeTypeEnable.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.xsmodeTypeEnable.CheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.xsmodeTypeEnable.CheckedState.InnerColor = System.Drawing.Color.White;
		this.xsmodeTypeEnable.CheckedState.Parent = (ToggleSwitch)(object)this.xsmodeTypeEnable;
		((System.Windows.Forms.Control)(object)this.xsmodeTypeEnable).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.xsmodeTypeEnable).Location = new System.Drawing.Point(584, 94);
		((System.Windows.Forms.Control)(object)this.xsmodeTypeEnable).Name = "xsmodeTypeEnable";
		this.xsmodeTypeEnable.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.xsmodeTypeEnable;
		((System.Windows.Forms.Control)(object)this.xsmodeTypeEnable).Size = new System.Drawing.Size(32, 20);
		((System.Windows.Forms.Control)(object)this.xsmodeTypeEnable).TabIndex = 71;
		this.xsmodeTypeEnable.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.xsmodeTypeEnable.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.xsmodeTypeEnable.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.xsmodeTypeEnable.UncheckedState.InnerColor = System.Drawing.Color.White;
		this.xsmodeTypeEnable.UncheckedState.Parent = (ToggleSwitch)(object)this.xsmodeTypeEnable;
		((ToggleSwitch)this.xsmodeTypeEnable).CheckedChanged += new System.EventHandler(xsmodeTypeEnable_CheckedChanged);
		((System.Windows.Forms.Control)(object)this.xsmodeTypeEnable).Click += new System.EventHandler(xsmodeTypeEnable_Click);
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.Location = new System.Drawing.Point(621, 97);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(44, 14);
		this.label4.TabIndex = 70;
		this.label4.Text = "XS V4";
		this.messageReferenceTxt.Animated = false;
		((System.Windows.Forms.Control)(object)this.messageReferenceTxt).BackColor = System.Drawing.Color.Transparent;
		this.messageReferenceTxt.BorderRadius = 4;
		this.messageReferenceTxt.BorderThickness = 2;
		((System.Windows.Forms.Control)(object)this.messageReferenceTxt).Cursor = System.Windows.Forms.Cursors.IBeam;
		((TextBox)this.messageReferenceTxt).DefaultText = "";
		this.messageReferenceTxt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		this.messageReferenceTxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		this.messageReferenceTxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.messageReferenceTxt.DisabledState.Parent = (TextBox)(object)this.messageReferenceTxt;
		this.messageReferenceTxt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.messageReferenceTxt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.messageReferenceTxt.FocusedState.Parent = (TextBox)(object)this.messageReferenceTxt;
		((TextBox)this.messageReferenceTxt).Font = new System.Drawing.Font("SF Pro Display", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		((TextBox)this.messageReferenceTxt).ForeColor = System.Drawing.Color.Black;
		this.messageReferenceTxt.HoveredState.BorderColor = System.Drawing.Color.FromArgb(213, 218, 223);
		this.messageReferenceTxt.HoveredState.Parent = (TextBox)(object)this.messageReferenceTxt;
		((System.Windows.Forms.Control)(object)this.messageReferenceTxt).Location = new System.Drawing.Point(18, 180);
		((System.Windows.Forms.Control)(object)this.messageReferenceTxt).Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		((System.Windows.Forms.Control)(object)this.messageReferenceTxt).Name = "messageReferenceTxt";
		((TextBox)this.messageReferenceTxt).PasswordChar = '\0';
		this.messageReferenceTxt.PlaceholderText = "Message Reference*";
		((TextBox)this.messageReferenceTxt).SelectedText = "";
		this.messageReferenceTxt.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.messageReferenceTxt;
		((System.Windows.Forms.Control)(object)this.messageReferenceTxt).Size = new System.Drawing.Size(658, 39);
		((System.Windows.Forms.Control)(object)this.messageReferenceTxt).TabIndex = 72;
		this.label5.AutoSize = true;
		this.label5.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label5.Location = new System.Drawing.Point(42, 410);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(92, 14);
		this.label5.TabIndex = 74;
		this.label5.Text = "Multi Channel";
		((System.Windows.Forms.Control)(object)this.hasMultiChannels).BackColor = System.Drawing.Color.Transparent;
		this.hasMultiChannels.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasMultiChannels.CheckedState.BorderRadius = 2;
		this.hasMultiChannels.CheckedState.BorderThickness = 0;
		this.hasMultiChannels.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasMultiChannels.CheckedState.Parent = (CustomCheckBox)(object)this.hasMultiChannels;
		((System.Windows.Forms.Control)(object)this.hasMultiChannels).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.hasMultiChannels).Location = new System.Drawing.Point(24, 409);
		((System.Windows.Forms.Control)(object)this.hasMultiChannels).Name = "hasMultiChannels";
		this.hasMultiChannels.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.hasMultiChannels;
		((System.Windows.Forms.Control)(object)this.hasMultiChannels).Size = new System.Drawing.Size(15, 15);
		((System.Windows.Forms.Control)(object)this.hasMultiChannels).TabIndex = 73;
		this.hasMultiChannels.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasMultiChannels.UncheckedState.BorderRadius = 2;
		this.hasMultiChannels.UncheckedState.BorderThickness = 0;
		this.hasMultiChannels.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasMultiChannels.UncheckedState.Parent = (CustomCheckBox)(object)this.hasMultiChannels;
		((CustomCheckBox)this.hasMultiChannels).CheckedChanged += new System.EventHandler(hasMultiChannels_CheckedChanged);
		this.label6.AutoSize = true;
		this.label6.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label6.Location = new System.Drawing.Point(42, 431);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(102, 14);
		this.label6.TabIndex = 76;
		this.label6.Text = "Multi Messages";
		((System.Windows.Forms.Control)(object)this.hasMultiMessages).BackColor = System.Drawing.Color.Transparent;
		this.hasMultiMessages.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasMultiMessages.CheckedState.BorderRadius = 2;
		this.hasMultiMessages.CheckedState.BorderThickness = 0;
		this.hasMultiMessages.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasMultiMessages.CheckedState.Parent = (CustomCheckBox)(object)this.hasMultiMessages;
		((System.Windows.Forms.Control)(object)this.hasMultiMessages).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.hasMultiMessages).Location = new System.Drawing.Point(24, 430);
		((System.Windows.Forms.Control)(object)this.hasMultiMessages).Name = "hasMultiMessages";
		this.hasMultiMessages.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.hasMultiMessages;
		((System.Windows.Forms.Control)(object)this.hasMultiMessages).Size = new System.Drawing.Size(15, 15);
		((System.Windows.Forms.Control)(object)this.hasMultiMessages).TabIndex = 75;
		this.hasMultiMessages.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasMultiMessages.UncheckedState.BorderRadius = 2;
		this.hasMultiMessages.UncheckedState.BorderThickness = 0;
		this.hasMultiMessages.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasMultiMessages.UncheckedState.Parent = (CustomCheckBox)(object)this.hasMultiMessages;
		((CustomCheckBox)this.hasMultiMessages).CheckedChanged += new System.EventHandler(siticoneCustomCheckBox1_CheckedChanged);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.Controls.Add(this.label6);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.hasMultiMessages);
		base.Controls.Add(this.label5);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.hasMultiChannels);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.messageReferenceTxt);
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
		base.Controls.Add((System.Windows.Forms.Control)(object)this.msgContent);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.channelId);
		base.Controls.Add(this.label1);
		base.Name = "ServerSpammer";
		base.Size = new System.Drawing.Size(695, 560);
		base.Load += new System.EventHandler(ServerSpammer_Load);
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
