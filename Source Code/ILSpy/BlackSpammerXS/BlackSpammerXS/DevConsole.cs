using System;
using System.ComponentModel;
using System.Drawing;
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

public class DevConsole : Form
{
	private BlackWSManager test_ws;

	private bool ses_aw = false;

	private Thread c_count_thr;

	private IContainer components = null;

	private SiticoneElipse siticoneElipse1;

	private SiticoneDragControl siticoneDragControl1;

	private Label label1;

	private SiticoneImageButton siticoneImageButton3;

	private SiticoneImageButton siticoneImageButton2;

	private SiticoneImageButton siticoneImageButton1;

	private SiticoneTextBox logBox;

	private SiticoneDragControl siticoneDragControl2;

	private SiticoneDragControl siticoneDragControl3;

	public DevConsole()
	{
		InitializeComponent();
	}

	private void logBox_KeyDown(object sender, KeyEventArgs e)
	{
		if (ses_aw)
		{
			ses_aw = false;
			try
			{
				base.Controls.Clear();
				InitializeComponent();
				return;
			}
			catch
			{
				return;
			}
		}
		if (!((TextBox)logBox).ReadOnly && e.KeyCode == Keys.Return)
		{
			handle_cmd(((TextBox)logBox).Text);
		}
	}

	private void log(string a)
	{
		((TextBox)logBox).AppendText(Environment.NewLine + a);
	}

	private async void handle_cmd(string cmd)
	{
		((TextBox)logBox).ReadOnly = true;
		await Task.Run(delegate
		{
			try
			{
				bool flag = false;
				log("Comando: " + cmd + " :: Handling..");
				if (cmd.StartsWith("count"))
				{
					string channelId = cmd.Split(' ')[1];
					int cfrom = 0;
					try
					{
						cfrom = int.Parse(cmd.Split(' ')[2]);
					}
					catch
					{
					}
					flag = true;
					log("Initializing..");
					log("Starting Logger..");
					ImpostazioniGlobali.StartLog();
					c_count_thr = new Thread((ThreadStart)delegate
					{
						log("Thread has been started. (MAX TOKENS: 150)");
						log("Counting from " + cfrom + "...");
						int o = 0;
						foreach (string t in ImpostazioniGlobali.Tokens)
						{
							if (o > 150)
							{
								break;
							}
							new Thread((ThreadStart)async delegate
							{
								int num = o;
								o = num + 1;
								num = cfrom;
								cfrom = num + 1;
								log("Thread " + o + " has been started.");
								Control.CheckForIllegalCrossThreadCalls = false;
								string proxy;
								try
								{
									proxy = ImpostazioniGlobali.Proxies[new Random().Next(ImpostazioniGlobali.Proxies.Count)];
								}
								catch (Exception)
								{
									proxy = "Error";
								}
								HttpClientHandler handler = new HttpClientHandler();
								handler.PreAuthenticate = true;
								handler.UseProxy = true;
								handler.Proxy = new WebProxy(proxy.Split(':')[0], int.Parse(proxy.Split(':')[1]));
								HttpClient http = new HttpClient((HttpMessageHandler)(object)handler);
								HttpRequestMessage val = new HttpRequestMessage
								{
									RequestUri = new Uri("https://discord.com/api/v9/channels/" + channelId + "/messages"),
									Content = (HttpContent)new StringContent("{\"content\": \"" + cfrom + "\", \"tts\": false}", Encoding.UTF8, "application/json"),
									Method = HttpMethod.Post
								};
								((HttpHeaders)val.Headers).Add("Authorization", t);
								((HttpHeaders)val.Headers).Add("Accept-Language", "it");
								((HttpHeaders)val.Headers).Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36");
								((HttpHeaders)val.Headers).Add("X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9");
								((HttpHeaders)val.Headers).Add("Accept", "*/*");
								((HttpHeaders)val.Headers).Add("Cookie", "locale=it");
								((HttpHeaders)val.Headers).Add("Referer", "https://discord.com/channels/" + channelId);
								HttpRequestMessage request = val;
								try
								{
									string _ = await (await http.SendAsync(request)).Content.ReadAsStringAsync();
									if (_.Contains("{\"id\""))
									{
										ImpostazioniGlobali.Log(proxy + " -> (" + t + ") Count [" + channelId + "] => Message successfully sent (" + cfrom + ")");
									}
									else
									{
										ImpostazioniGlobali.Log(proxy + " -> (" + t + ") Count [" + channelId + "] => " + _);
									}
								}
								catch
								{
									ImpostazioniGlobali.Log(proxy + " -> (" + t + ") Count [" + channelId + "] => Unknown Error [Check your proxies]");
								}
							}).Start();
							Thread.Sleep(45);
						}
					});
					c_count_thr.Start();
				}
				if (cmd.StartsWith("ws-voice-start"))
				{
					string serverId = cmd.Split(' ')[1];
					string channelId2 = cmd.Split(' ')[2];
					flag = true;
					log("Initializing websocket testing process..");
					log("Starting Logger..");
					ImpostazioniGlobali.StartLog();
					string token = ImpostazioniGlobali.Tokens[new Random().Next(ImpostazioniGlobali.Tokens.Count)];
					Control.CheckForIllegalCrossThreadCalls = false;
					string proxy2;
					try
					{
						proxy2 = ImpostazioniGlobali.Proxies[new Random().Next(ImpostazioniGlobali.Proxies.Count)];
					}
					catch (Exception)
					{
						proxy2 = "Error";
					}
					log("Using token: " + token + " and proxy: " + proxy2 + "..");
					Task.Run(async delegate
					{
						test_ws = new BlackWSManager(token, proxy2, logging: true);
						log("Connecting..");
						test_ws.connect();
						log("Connection process has started.");
						log("Current State: " + test_ws.is_connected());
						log("Awaiting for data..");
						if (!(await test_ws.WaitForData(5000)))
						{
							log("No data received.");
						}
						else
						{
							log("Data success.");
							log("Guilds: " + test_ws.GetGuilds().Count);
						}
						log("Joining in voice. Server ID=" + serverId + " and Channel ID=" + channelId2 + "..");
						test_ws.voice_connect(serverId, channelId2);
					});
				}
				if (cmd.StartsWith("ws-cr"))
				{
					flag = true;
					string g_id = cmd.Split(' ')[1];
					log("Initializing websocket (cr) (gid=" + g_id + ") testing process..");
					log("Starting logger..");
					ImpostazioniGlobali.StartLog();
					string token2 = ImpostazioniGlobali.Tokens[new Random().Next(ImpostazioniGlobali.Tokens.Count)];
					Control.CheckForIllegalCrossThreadCalls = false;
					string proxy3;
					try
					{
						proxy3 = ImpostazioniGlobali.Proxies[new Random().Next(ImpostazioniGlobali.Proxies.Count)];
					}
					catch (Exception)
					{
						proxy3 = "Error";
					}
					log("Using token: " + token2 + " and proxy: " + proxy3 + "..");
					Task.Run(async delegate
					{
						test_ws = new BlackWSManager(token2, proxy3, logging: true);
						log("Connecting..");
						test_ws.connect();
						log("Current State: " + test_ws.is_connected());
						log("Awaiting for data..");
						if (!(await test_ws.WaitForData()))
						{
							log("No data received.");
						}
						else
						{
							log("Connected!");
							log("Guilds: " + test_ws.GetGuilds().Count);
							log("Sending payload..");
							test_ws.send_ws_message("{\"op\":14,\"d\":{\"guild_id\":\"" + g_id + "\",\"channels\":{\"836020859860811777\":[[0, 100]]}}} ");
						}
					});
				}
				if (cmd.StartsWith("setBio"))
				{
					flag = true;
					log("Initializing..");
					log("Starting Logger..");
					string _bio = cmd.Split(' ')[1];
					ImpostazioniGlobali.StartLog();
					c_count_thr = new Thread((ThreadStart)delegate
					{
						log("Thread has been started.");
						foreach (string t2 in ImpostazioniGlobali.Tokens)
						{
							new Thread((ThreadStart)async delegate
							{
								log("A new thread has been started.");
								Control.CheckForIllegalCrossThreadCalls = false;
								string proxy4;
								try
								{
									proxy4 = ImpostazioniGlobali.Proxies[new Random().Next(ImpostazioniGlobali.Proxies.Count)];
								}
								catch (Exception)
								{
									proxy4 = "Error";
								}
								HttpClientHandler handler2 = new HttpClientHandler();
								handler2.PreAuthenticate = true;
								handler2.UseProxy = true;
								handler2.Proxy = new WebProxy(proxy4.Split(':')[0], int.Parse(proxy4.Split(':')[1]));
								HttpClient http2 = new HttpClient((HttpMessageHandler)(object)handler2);
								HttpRequestMessage val2 = new HttpRequestMessage
								{
									RequestUri = new Uri("https://discord.com/api/v9/users/@me"),
									Content = (HttpContent)new StringContent("{\"bio\": \"" + _bio + "\"}", Encoding.UTF8, "application/json"),
									Method = new HttpMethod("PATCH")
								};
								((HttpHeaders)val2.Headers).Add("Authorization", t2);
								((HttpHeaders)val2.Headers).Add("Accept-Language", "it");
								((HttpHeaders)val2.Headers).Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36");
								((HttpHeaders)val2.Headers).Add("X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9");
								((HttpHeaders)val2.Headers).Add("Accept", "*/*");
								((HttpHeaders)val2.Headers).Add("Cookie", "locale=it");
								((HttpHeaders)val2.Headers).Add("Origin", "https://discord.com");
								((HttpHeaders)val2.Headers).Add("Referer", "https://discord.com/channels/@me");
								HttpRequestMessage request2 = val2;
								((HttpHeaders)request2.Headers).Add("Content-Length", "{\"bio\": \"" + _bio + "\"}".Length);
								try
								{
									string _2 = await (await http2.SendAsync(request2)).Content.ReadAsStringAsync();
									if (_2.Contains("{\"id\""))
									{
										ImpostazioniGlobali.Log(proxy4 + " -> (" + t2 + ") Bio => Success.");
									}
									else
									{
										ImpostazioniGlobali.Log(proxy4 + " -> (" + t2 + ") Bio => " + _2);
									}
								}
								catch
								{
									ImpostazioniGlobali.Log(proxy4 + " -> (" + t2 + ") Bio => Unknown Error [Check your proxies]");
								}
							}).Start();
							Thread.Sleep(1);
						}
					});
					c_count_thr.Start();
				}
				if (cmd == "websocket-test start")
				{
					flag = true;
					log("Initializing websocket testing process..");
					log("Starting logger..");
					ImpostazioniGlobali.StartLog();
					string token3 = ImpostazioniGlobali.Tokens[new Random().Next(ImpostazioniGlobali.Tokens.Count)];
					Control.CheckForIllegalCrossThreadCalls = false;
					string proxy5;
					try
					{
						proxy5 = ImpostazioniGlobali.Proxies[new Random().Next(ImpostazioniGlobali.Proxies.Count)];
					}
					catch (Exception)
					{
						proxy5 = "Error";
					}
					log("Using token: " + token3 + " and proxy: " + proxy5 + "..");
					Task.Run(async delegate
					{
						test_ws = new BlackWSManager(token3, proxy5, logging: true);
						log("Connecting..");
						test_ws.connect();
						log("Connection process has started.");
						log("Current State: " + test_ws.is_connected());
						log("Awaiting for data..");
						if (!(await test_ws.WaitForData()))
						{
							log("No data received.");
						}
						else
						{
							log("Data success.");
							log("Guilds: " + test_ws.GetGuilds().Count);
						}
					});
				}
				else if (cmd == "websocket-test disconnect")
				{
					flag = true;
					log("Checking state..");
					if (test_ws == null)
					{
						log("Non ci sono websockets attivi. (0x00)");
					}
					else
					{
						log("Tentativo di disconnessione con disconnect(null:param:?!0)..");
						test_ws.disconnect();
						test_ws = null;
						log("Successfully Disconnected.");
					}
				}
				if (!flag)
				{
					log("Questo comando non esiste.");
				}
			}
			catch (Exception ex6)
			{
				log("Si è verificato un errore: " + ex6.Message);
			}
		});
		log("Comando eseguito. Clicca un pulsante per creare una nuova sessione.");
		ses_aw = true;
	}

	private void siticoneImageButton1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void siticoneImageButton2_Click(object sender, EventArgs e)
	{
		base.WindowState = FormWindowState.Minimized;
	}

	private void logBox_TextChanged(object sender, EventArgs e)
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
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
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
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlackSpammerXS.DevConsole));
		this.siticoneElipse1 = new SiticoneElipse(this.components);
		this.siticoneDragControl1 = new SiticoneDragControl(this.components);
		this.label1 = new System.Windows.Forms.Label();
		this.siticoneImageButton3 = new SiticoneImageButton();
		this.siticoneImageButton2 = new SiticoneImageButton();
		this.siticoneImageButton1 = new SiticoneImageButton();
		this.logBox = new SiticoneTextBox();
		this.siticoneDragControl2 = new SiticoneDragControl(this.components);
		this.siticoneDragControl3 = new SiticoneDragControl(this.components);
		base.SuspendLayout();
		this.siticoneElipse1.TargetControl = this;
		this.siticoneDragControl1.TargetControl = this;
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("SF Pro Text", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.White;
		this.label1.Location = new System.Drawing.Point(258, 17);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(266, 18);
		this.label1.TabIndex = 106;
		this.label1.Text = "BlackSpammer Developer Console";
		this.siticoneImageButton3.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Cursor = System.Windows.Forms.Cursors.Arrow;
		this.siticoneImageButton3.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image");
		this.siticoneImageButton3.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		this.siticoneImageButton3.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton3.Image");
		((ImageButton)this.siticoneImageButton3).ImageRotate = 0f;
		this.siticoneImageButton3.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Location = new System.Drawing.Point(52, 11);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Name = "siticoneImageButton3";
		this.siticoneImageButton3.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Size = new System.Drawing.Size(29, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).TabIndex = 109;
		this.siticoneImageButton2.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton2;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneImageButton2.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image1");
		this.siticoneImageButton2.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton2.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton2;
		this.siticoneImageButton2.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton2.Image");
		((ImageButton)this.siticoneImageButton2).ImageRotate = 0f;
		this.siticoneImageButton2.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton2.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Location = new System.Drawing.Point(31, 11);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Name = "siticoneImageButton2";
		this.siticoneImageButton2.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton2.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton2;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Size = new System.Drawing.Size(29, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).TabIndex = 108;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Click += new System.EventHandler(siticoneImageButton2_Click);
		this.siticoneImageButton1.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneImageButton1.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image1");
		this.siticoneImageButton1.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		this.siticoneImageButton1.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton1.Image");
		((ImageButton)this.siticoneImageButton1).ImageRotate = 0f;
		this.siticoneImageButton1.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Location = new System.Drawing.Point(12, 11);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Name = "siticoneImageButton1";
		this.siticoneImageButton1.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Size = new System.Drawing.Size(26, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).TabIndex = 107;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Click += new System.EventHandler(siticoneImageButton1_Click);
		((System.Windows.Forms.Control)(object)this.logBox).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.logBox.Animated = false;
		((System.Windows.Forms.Control)(object)this.logBox).BackColor = System.Drawing.Color.Transparent;
		this.logBox.BorderColor = System.Drawing.Color.Transparent;
		this.logBox.BorderThickness = 0;
		((System.Windows.Forms.Control)(object)this.logBox).Cursor = System.Windows.Forms.Cursors.IBeam;
		((TextBox)this.logBox).DefaultText = "";
		this.logBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		this.logBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		this.logBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.logBox.DisabledState.Parent = (TextBox)(object)this.logBox;
		this.logBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.logBox.FillColor = System.Drawing.Color.FromArgb(44, 47, 51);
		this.logBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.logBox.FocusedState.Parent = (TextBox)(object)this.logBox;
		((TextBox)this.logBox).Font = new System.Drawing.Font("JetBrains Mono", 9.75f);
		((TextBox)this.logBox).ForeColor = System.Drawing.Color.White;
		this.logBox.HoveredState.BorderColor = System.Drawing.Color.Transparent;
		this.logBox.HoveredState.Parent = (TextBox)(object)this.logBox;
		((System.Windows.Forms.Control)(object)this.logBox).Location = new System.Drawing.Point(1, 47);
		((System.Windows.Forms.Control)(object)this.logBox).Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		((TextBox)this.logBox).Multiline = true;
		((System.Windows.Forms.Control)(object)this.logBox).Name = "logBox";
		((TextBox)this.logBox).PasswordChar = '\0';
		this.logBox.PlaceholderText = "Esegui un comando nella sessione corrente";
		((TextBox)this.logBox).SelectedText = "";
		this.logBox.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.logBox;
		((System.Windows.Forms.Control)(object)this.logBox).Size = new System.Drawing.Size(797, 402);
		((System.Windows.Forms.Control)(object)this.logBox).TabIndex = 110;
		((TextBox)this.logBox).TextChanged += new System.EventHandler(logBox_TextChanged);
		((System.Windows.Forms.Control)(object)this.logBox).KeyDown += new System.Windows.Forms.KeyEventHandler(logBox_KeyDown);
		this.siticoneDragControl2.TargetControl = (System.Windows.Forms.Control)(object)this.logBox;
		this.siticoneDragControl3.TargetControl = this.label1;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(44, 47, 51);
		base.ClientSize = new System.Drawing.Size(800, 450);
		base.ControlBox = false;
		base.Controls.Add((System.Windows.Forms.Control)(object)this.logBox);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton3);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton2);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton1);
		base.Controls.Add(this.label1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "DevConsole";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "BlackSpammer XS Developer Console";
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
