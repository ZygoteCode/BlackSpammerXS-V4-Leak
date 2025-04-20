using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Suite;
using WindowsInput;
using WindowsInput.Native;

namespace BlackSpammerXS;

public class ReactionSpammer : UserControl
{
	public int tt = 0;

	private IContainer components = null;

	private Label label1;

	private SiticoneSlider sliderDelay;

	private SiticoneToggleSwitch hasDelay;

	private Label del;

	private Label label9;

	private Label label8;

	private SiticoneCustomCheckBox hasEmbed;

	private SiticoneCustomCheckBox hasLive;

	private SiticoneButton startBtn;

	private SiticoneTextBox emot;

	private SiticoneTextBox channelId;

	private SiticoneTextBox messageId;

	private PictureBox pictureBox2;

	private SiticoneDragControl siticoneDragControl1;

	private SiticoneToggleSwitch xsmodeTypeEnable;

	private Label label4;

	private Label label3;

	private SiticoneButton siticoneButton1;

	private SiticoneGradientButton emoAsst;

	public ReactionSpammer()
	{
		InitializeComponent();
	}

	private void hasLive_Click(object sender, EventArgs e)
	{
		hasEmbed.Checked = false;
	}

	private void hasEmbed_Click(object sender, EventArgs e)
	{
		hasLive.Checked = false;
	}

	private async void startBtn_Click(object sender, EventArgs e)
	{
		if (((TextBox)channelId).Text == "" || ((TextBox)emot).Text == "" || ((TextBox)messageId).Text == "")
		{
			MessageBox.Show("Please fill every requested parameter");
			return;
		}
		((Control)(object)startBtn).Text = "Reacting..";
		((Control)(object)startBtn).Enabled = false;
		if (ImpostazioniGlobali.Tokens == null || ImpostazioniGlobali.Proxies == null)
		{
			await Task.Delay(50);
			((Control)(object)startBtn).Text = "Spam Reactions";
			((Control)(object)startBtn).Enabled = true;
			MessageBox.Show("There are no such tokens or proxies");
			return;
		}
		ImpostazioniGlobali.StartLog();
		try
		{
			JObject devDebug = ImpostazioniGlobali.CreateDebugAction(timestamp: ImpostazioniGlobali.GetReadableDateNow(), id: 19, act: "REACT+_SPM", of: "REACTION_SPAMMER_REACT_SF", notesRaw: new string[2]
			{
				"BUTTON_SPAM_REACTIONS",
				"T_" + ImpostazioniGlobali.Tokens.Count + "_P_" + ImpostazioniGlobali.Proxies.Count
			}, a: "RSPM_SGL_OF_CEM_" + hasDelay.Checked);
			ImpostazioniGlobali.Debug_DPut(devDebug);
		}
		catch (Exception)
		{
		}
		Random random = new Random();
		List<string> proxies = ImpostazioniGlobali.Proxies;
		((TextBox)channelId).Text.Replace("https", "").Replace("/", "").Replace(":", "")
			.Replace("discordapp.com", "")
			.Replace(" ", "")
			.Replace("discord.gg", "")
			.Replace("discord.com", "")
			.Replace("invite", "")
			.Replace(" ", "")
			.Replace(".", "");
		ImpostazioniGlobali.Log("Manager -> (Operation Starting) Reaction Spammer => Spamming reactions in " + ((TextBox)channelId).Text + " with " + proxies.Count + " proxies and " + ImpostazioniGlobali.Tokens.Count + " tokens.. Delay has been set to " + sliderDelay.Value);
		bool hasDel = hasDelay.Checked;
		if (sliderDelay.Value == 0)
		{
			hasDel = false;
			hasDelay.Checked = false;
		}
		try
		{
			int type = 0;
			if (!hasLive.Checked)
			{
				type = 1;
			}
			AuditManager auditManager = ImpostazioniGlobali.auditManager;
			auditManager.LogActionReaction(type, ((TextBox)emot).Text, ((TextBox)channelId).Text, ((TextBox)messageId).Text);
		}
		catch (Exception)
		{
		}
		new Thread((ParameterizedThreadStart)delegate
		{
			foreach (string token in ImpostazioniGlobali.Tokens)
			{
				new Thread((ParameterizedThreadStart)async delegate
				{
					if (hasDel)
					{
						ImpostazioniGlobali.Log("Manager -> (Delay) (" + token + ") Reaction Spammer => Awaiting " + sliderDelay.Value + "ms of delay before reacting.");
						Thread.Sleep(sliderDelay.Value);
					}
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
						handler.Proxy = new WebProxy(proxy.Split(':')[0], int.Parse(proxy.Split(':')[1]));
						HttpClient http = new HttpClient((HttpMessageHandler)(object)handler);
						if (!hasLive.Checked)
						{
							HttpRequestMessage val = new HttpRequestMessage();
							val.Content = null;
							val.RequestUri = new Uri("https://discord.com/api/v9/channels/" + ((TextBox)channelId).Text + "/messages/" + ((TextBox)messageId).Text + "/reactions/" + ((TextBox)emot).Text + "/@me");
							val.Method = HttpMethod.Put;
							((HttpHeaders)val.Headers).Add("Authorization", token);
							((HttpHeaders)val.Headers).Add("Accept-Language", "it");
							((HttpHeaders)val.Headers).Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36");
							((HttpHeaders)val.Headers).Add("X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9");
							((HttpHeaders)val.Headers).Add("Accept", "*/*");
							((HttpHeaders)val.Headers).Add("Cookie", "locale=it");
							((HttpHeaders)val.Headers).Add("Connection", "keep-alive");
							((HttpHeaders)val.Headers).Add("Host", "discord.com");
							((HttpHeaders)val.Headers).Add("Origin", "https://discord.com");
							((HttpHeaders)val.Headers).Add("Referer", "https://discord.com/channels/" + ((TextBox)channelId).Text);
							((HttpHeaders)val.Headers).Add(HttpRequestHeader.ContentLength.ToString(), "0");
							HttpRequestMessage request = val;
							string _ = await (await http.SendAsync(request)).Content.ReadAsStringAsync();
							if (_ == "")
							{
								_ = "Successfully Reacted";
							}
							if (ImpostazioniGlobali.StreamerMode)
							{
								ImpostazioniGlobali.Log(proxy + " -> (Token " + ImpostazioniGlobali.Tokens.IndexOf(token) + ") Reaction => " + _);
							}
							else
							{
								ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Reaction => " + _);
							}
						}
						else
						{
							HttpRequestMessage val = new HttpRequestMessage();
							val.RequestUri = new Uri("https://discord.com/api/v9/channels/" + ((TextBox)channelId).Text + "/messages/" + ((TextBox)messageId).Text + "/reactions/" + Uri.EscapeDataString(((TextBox)emot).Text) + "/@me");
							val.Method = HttpMethod.Put;
							((HttpHeaders)val.Headers).Add("Authorization", token);
							((HttpHeaders)val.Headers).Add("Accept-Language", "it");
							((HttpHeaders)val.Headers).Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36");
							((HttpHeaders)val.Headers).Add("X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9");
							((HttpHeaders)val.Headers).Add("Accept", "*/*");
							((HttpHeaders)val.Headers).Add("Cookie", "locale=it");
							((HttpHeaders)val.Headers).Add("Referer", "https://discord.com/channels/" + ((TextBox)channelId).Text);
							((HttpHeaders)val.Headers).Add("Connection", "keep-alive");
							((HttpHeaders)val.Headers).Add("Host", "discord.com");
							((HttpHeaders)val.Headers).Add("Origin", "https://discord.com");
							((HttpHeaders)val.Headers).Add(HttpRequestHeader.ContentLength.ToString(), "0");
							HttpRequestMessage request2 = val;
							string _2 = await (await http.SendAsync(request2)).Content.ReadAsStringAsync();
							if (_2 == "")
							{
								_2 = "Successfully Reacted";
							}
							if (ImpostazioniGlobali.StreamerMode)
							{
								ImpostazioniGlobali.Log(proxy + " -> (Token " + ImpostazioniGlobali.Tokens.IndexOf(token) + ") Reaction => " + _2);
							}
							else
							{
								ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Reaction => " + _2);
							}
						}
					}
					catch (Exception)
					{
						if (ImpostazioniGlobali.StreamerMode)
						{
							ImpostazioniGlobali.Log(proxy + " -> (Token " + ImpostazioniGlobali.Tokens.IndexOf(token) + ") Reaction => Unknown Error [Check your proxies]");
						}
						else
						{
							ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Reaction => Unknown Error [Check your proxies]");
						}
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
		await Task.Delay(50);
		((Control)(object)startBtn).Text = "Spam Reactions";
		((Control)(object)startBtn).Enabled = true;
	}

	private void sliderDelay_Scroll(object sender, EventArgs e)
	{
		del.Text = "Delay: " + sliderDelay.Value + "ms";
	}

	private void startBtn_MouseEnter(object sender, EventArgs e)
	{
		startBtn.BorderThickness = 1;
	}

	private void startBtn_MouseLeave(object sender, EventArgs e)
	{
		startBtn.BorderThickness = 1;
	}

	public void Dark()
	{
		Color fillColor = (BackColor = Color.FromArgb(44, 47, 51));
		Color dimGray = Color.DimGray;
		try
		{
			List<SiticoneButton> list = new List<SiticoneButton> { startBtn, siticoneButton1 };
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
			((TextBox)messageId).ForeColor = Color.White;
			messageId.FillColor = fillColor;
			messageId.BorderColor = Color.Gray;
			messageId.HoveredState.BorderColor = Color.Gray;
			((TextBox)emot).ForeColor = Color.White;
			emot.FillColor = fillColor;
			emot.BorderColor = Color.Gray;
			emot.HoveredState.BorderColor = Color.Gray;
			sliderDelay.FillColor = Color.Gray;
			sliderDelay.ThumbColor = Color.RoyalBlue;
		}
		catch (Exception)
		{
		}
	}

	private void ReactionSpammer_Load(object sender, EventArgs e)
	{
		ImpostazioniGlobali._bridgeLogPerform.Add(delegate(int a, int b, object[] i)
		{
			if (a == 2)
			{
				try
				{
					((TextBox)channelId).Text = (string)i[0];
					((TextBox)emot).Text = (string)i[1];
					int num = (int)i[2];
					if (num == 0)
					{
						hasLive.Checked = true;
						hasEmbed.Checked = false;
					}
					if (num == 1)
					{
						hasEmbed.Checked = true;
						hasLive.Checked = false;
					}
					((TextBox)messageId).Text = (string)i[3];
				}
				catch (Exception)
				{
				}
			}
		});
	}

	private void xsmodeTypeEnable_Click(object sender, EventArgs e)
	{
		xsmodeTypeEnable.Checked = true;
	}

	private void emoAsst_Click(object sender, EventArgs e)
	{
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		if (tt == 1)
		{
			if (string.IsNullOrEmpty(((TextBox)channelId).Text) || string.IsNullOrEmpty(((TextBox)messageId).Text))
			{
				MessageBox.Show("Specifica un Channel ID ed un Message ID");
				return;
			}
			if (ImpostazioniGlobali.Tokens == null || ImpostazioniGlobali.Tokens.Count == 0 || ImpostazioniGlobali.Proxies == null || ImpostazioniGlobali.Proxies.Count == 0)
			{
				MessageBox.Show("Devi prima importare i tuoi tokens ed i proxies");
				return;
			}
			ImpostazioniGlobali.StartLog();
			new Thread((ParameterizedThreadStart)async delegate
			{
				Random rnd = new Random();
				string token = ImpostazioniGlobali.Tokens[rnd.Next(ImpostazioniGlobali.Tokens.Count)];
				Control.CheckForIllegalCrossThreadCalls = false;
				string proxy;
				try
				{
					proxy = ImpostazioniGlobali.Proxies[rnd.Next(ImpostazioniGlobali.Proxies.Count)];
				}
				catch (Exception)
				{
					proxy = "Error";
				}
				ImpostazioniGlobali.Log(proxy + "-> (" + token + ") Emote Helper => Getting emote at msg: " + ((TextBox)messageId).Text);
				string url_emoast = "https://discord.com/api/v9/channels/" + ((TextBox)channelId).Text + "/messages";
				try
				{
					HttpClientHandler handler = new HttpClientHandler();
					handler.PreAuthenticate = true;
					handler.UseProxy = true;
					handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
					handler.Proxy = new WebProxy(proxy.Split(':')[0], int.Parse(proxy.Split(':')[1]));
					HttpClient http = new HttpClient((HttpMessageHandler)(object)handler);
					HttpRequestMessage val = new HttpRequestMessage
					{
						RequestUri = new Uri(url_emoast),
						Method = HttpMethod.Get
					};
					((HttpHeaders)val.Headers).Add("Authorization", token);
					((HttpHeaders)val.Headers).Add("Accept-Language", "it");
					((HttpHeaders)val.Headers).Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36");
					((HttpHeaders)val.Headers).Add("X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9");
					((HttpHeaders)val.Headers).Add("Accept", "*/*");
					((HttpHeaders)val.Headers).Add("Cookie", "locale=it");
					((HttpHeaders)val.Headers).Add("Referer", "https://discord.com/channels/@me");
					HttpRequestMessage requestMessages = val;
					string respCHMessages = await (await http.SendAsync(requestMessages)).Content.ReadAsStringAsync();
					if (respCHMessages == "[]")
					{
						((TextBox)emot).Text = "This channel is empty";
					}
					else
					{
						JArray messagesArr = JArray.Parse(respCHMessages);
						JObject[] jMObjects = ((JToken)messagesArr).ToObject<JObject[]>();
						bool found = false;
						((TextBox)emot).Text = "";
						JObject[] array = jMObjects;
						foreach (dynamic objMsgCH in array)
						{
							try
							{
								if (objMsgCH.id == ((TextBox)messageId).Text)
								{
									found = true;
									ImpostazioniGlobali.Log(proxy + "-> (" + token + ") Emote Helper => Got message at " + ((TextBox)channelId).Text + "::" + objMsgCH.id + " sent by " + objMsgCH.author.id);
									dynamic rj_c = objMsgCH.reactions;
									dynamic jreact_arr = JObject.Parse("{\"r_ct\": " + rj_c.ToString() + "}");
									_ = (JArray)JArray.Parse(jreact_arr.r_ct.ToString());
									JObject[] reactions = ((JToken)messagesArr).ToObject<JObject[]>();
									JObject[] array2 = reactions;
									foreach (dynamic react in array2)
									{
										foreach (dynamic emc in react.reactions)
										{
											dynamic emmj = emc.emoji;
											try
											{
												if (emmj.id == null)
												{
													throw new Exception("ex");
												}
											}
											catch (Exception)
											{
												continue;
											}
											dynamic emj = emmj;
											ImpostazioniGlobali.Log(proxy + "-> (" + token + ") Emote Helper => Found Emoji: [em_id=" + emj.id + ", em_name=" + emj.name + "]");
											if (((TextBox)emot).Text != "")
											{
												((TextBox)emot).Text = ((TextBox)emot).Text + ", " + emj.name + ":" + emj.id;
											}
											else
											{
												((TextBox)emot).Text = "" + emj.name + ":" + emj.id;
											}
										}
									}
									break;
								}
							}
							catch (Exception)
							{
								ImpostazioniGlobali.Log(proxy + "-> (" + token + ") Emote Helper => Failed to parse message with ID " + objMsgCH.id);
							}
						}
						if (!found)
						{
							((TextBox)emot).Text = "Message was not found";
							ImpostazioniGlobali.Log(proxy + "-> (" + token + ") Emote Helper => Unable to find message with ID " + ((TextBox)messageId).Text);
						}
						if (((TextBox)emot).Text == "" && found)
						{
							ImpostazioniGlobali.Log(proxy + "-> (" + token + ") Emote Helper => No emotes at " + ((TextBox)messageId).Text);
							((TextBox)emot).Text = "No emotes found";
						}
					}
				}
				catch (Exception)
				{
					ImpostazioniGlobali.Log(proxy + "-> (" + token + ") Emote Helper => An error has occurred.");
				}
			}).Start();
			return;
		}
		if (tt == 0)
		{
			((TextBox)emot).Focus();
			try
			{
				new InputSimulator().Keyboard.ModifiedKeyStroke((VirtualKeyCode)91, (VirtualKeyCode)190);
				((TextBox)emot).Focus();
				return;
			}
			catch (Exception)
			{
			}
		}
		MessageBox.Show("Qualcosa è andato storto. Puoi riprovare?");
	}

	private void hasLive_CheckedChanged(object sender, EventArgs e)
	{
		if (hasLive.Checked)
		{
			tt = 0;
			((Control)(object)emoAsst).Text = "Emojis";
		}
	}

	private void hasEmbed_CheckedChanged(object sender, EventArgs e)
	{
		if (hasEmbed.Checked)
		{
			tt = 1;
			((Control)(object)emoAsst).Text = "Emotes";
		}
	}

	private async void siticoneButton1_Click(object sender, EventArgs e)
	{
		if (((TextBox)channelId).Text == "" || ((TextBox)emot).Text == "" || ((TextBox)messageId).Text == "")
		{
			MessageBox.Show("Please fill every requested parameter");
			return;
		}
		((Control)(object)siticoneButton1).Text = "Removing Reactions..";
		((Control)(object)siticoneButton1).Enabled = false;
		if (ImpostazioniGlobali.Tokens == null || ImpostazioniGlobali.Proxies == null)
		{
			await Task.Delay(50);
			((Control)(object)siticoneButton1).Text = "Remove Reactions";
			((Control)(object)siticoneButton1).Enabled = true;
			MessageBox.Show("There are no such tokens or proxies");
			return;
		}
		ImpostazioniGlobali.StartLog();
		try
		{
			JObject devDebug = ImpostazioniGlobali.CreateDebugAction(timestamp: ImpostazioniGlobali.GetReadableDateNow(), id: 19, act: "REACT+_SPM", of: "REACTION_SPAMMER_REACT_SF", notesRaw: new string[2]
			{
				"BUTTON_SPAM_REACTIONS",
				"T_" + ImpostazioniGlobali.Tokens.Count + "_P_" + ImpostazioniGlobali.Proxies.Count
			}, a: "RSPM_SGL_OF_CEM_" + hasDelay.Checked);
			ImpostazioniGlobali.Debug_DPut(devDebug);
		}
		catch (Exception)
		{
		}
		Random random = new Random();
		List<string> proxies = ImpostazioniGlobali.Proxies;
		((TextBox)channelId).Text.Replace("https", "").Replace("/", "").Replace(":", "")
			.Replace("discordapp.com", "")
			.Replace(" ", "")
			.Replace("discord.gg", "")
			.Replace("discord.com", "")
			.Replace("invite", "")
			.Replace(" ", "")
			.Replace(".", "");
		ImpostazioniGlobali.Log("Manager -> (Operation Starting) Reaction Spammer => Spamming reactions in " + ((TextBox)channelId).Text + " with " + proxies.Count + " proxies and " + ImpostazioniGlobali.Tokens.Count + " tokens.. Delay has been set to " + sliderDelay.Value);
		bool hasDel = hasDelay.Checked;
		if (sliderDelay.Value == 0)
		{
			hasDel = false;
			hasDelay.Checked = false;
		}
		try
		{
			int type = 0;
			if (!hasLive.Checked)
			{
				type = 1;
			}
			AuditManager auditManager = ImpostazioniGlobali.auditManager;
			auditManager.LogActionReaction(type, ((TextBox)emot).Text, ((TextBox)channelId).Text, ((TextBox)messageId).Text);
		}
		catch (Exception)
		{
		}
		new Thread((ParameterizedThreadStart)delegate
		{
			foreach (string token in ImpostazioniGlobali.Tokens)
			{
				new Thread((ParameterizedThreadStart)async delegate
				{
					if (hasDel)
					{
						ImpostazioniGlobali.Log("Manager -> (Delay) (" + token + ") Reaction Spammer => Awaiting " + sliderDelay.Value + "ms of delay before reacting.");
						Thread.Sleep(sliderDelay.Value);
					}
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
						handler.Proxy = new WebProxy(proxy.Split(':')[0], int.Parse(proxy.Split(':')[1]));
						HttpClient http = new HttpClient((HttpMessageHandler)(object)handler);
						if (!hasLive.Checked)
						{
							HttpRequestMessage val = new HttpRequestMessage();
							val.RequestUri = new Uri("https://discord.com/api/v9/channels/" + ((TextBox)channelId).Text + "/messages/" + ((TextBox)messageId).Text + "/reactions/" + ((TextBox)emot).Text + "/@me");
							val.Method = HttpMethod.Delete;
							((HttpHeaders)val.Headers).Add("Authorization", token);
							((HttpHeaders)val.Headers).Add("Accept-Language", "it");
							((HttpHeaders)val.Headers).Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36");
							((HttpHeaders)val.Headers).Add("X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9");
							((HttpHeaders)val.Headers).Add("Accept", "*/*");
							((HttpHeaders)val.Headers).Add("Cookie", "locale=it");
							((HttpHeaders)val.Headers).Add("Referer", "https://discord.com/channels/" + ((TextBox)channelId).Text);
							HttpRequestMessage request = val;
							string _ = await (await http.SendAsync(request)).Content.ReadAsStringAsync();
							if (_ == "")
							{
								_ = "Successfully Unreacted";
							}
							if (ImpostazioniGlobali.StreamerMode)
							{
								ImpostazioniGlobali.Log(proxy + " -> (Token " + ImpostazioniGlobali.Tokens.IndexOf(token) + ") Reaction => " + _);
							}
							else
							{
								ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Reaction => " + _);
							}
						}
						else
						{
							HttpRequestMessage val = new HttpRequestMessage();
							val.RequestUri = new Uri("https://discord.com/api/v9/channels/" + ((TextBox)channelId).Text + "/messages/" + ((TextBox)messageId).Text + "/reactions/" + Uri.EscapeDataString(((TextBox)emot).Text) + "/@me");
							val.Method = HttpMethod.Delete;
							((HttpHeaders)val.Headers).Add("Authorization", token);
							((HttpHeaders)val.Headers).Add("Accept-Language", "it");
							((HttpHeaders)val.Headers).Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36");
							((HttpHeaders)val.Headers).Add("X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9");
							((HttpHeaders)val.Headers).Add("Accept", "*/*");
							((HttpHeaders)val.Headers).Add("Cookie", "locale=it");
							((HttpHeaders)val.Headers).Add("Referer", "https://discord.com/channels/" + ((TextBox)channelId).Text);
							HttpRequestMessage request2 = val;
							string _2 = await (await http.SendAsync(request2)).Content.ReadAsStringAsync();
							if (_2 == "")
							{
								_2 = "Successfully Unreacted";
							}
							if (ImpostazioniGlobali.StreamerMode)
							{
								ImpostazioniGlobali.Log(proxy + " -> (Token " + ImpostazioniGlobali.Tokens.IndexOf(token) + ") Reaction => " + _2);
							}
							else
							{
								ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Reaction => " + _2);
							}
						}
					}
					catch (Exception)
					{
						if (ImpostazioniGlobali.StreamerMode)
						{
							ImpostazioniGlobali.Log(proxy + " -> (Token " + ImpostazioniGlobali.Tokens.IndexOf(token) + ") Reaction => Unknown Error [Check your proxies]");
						}
						else
						{
							ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Reaction => Unknown Error [Check your proxies]");
						}
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
		await Task.Delay(50);
		((Control)(object)siticoneButton1).Text = "Remove Reactions";
		((Control)(object)siticoneButton1).Enabled = true;
	}

	private void siticoneGradientButton4_Click(object sender, EventArgs e)
	{
		emoAsst_Click(sender, e);
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
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlackSpammerXS.ReactionSpammer));
		this.label1 = new System.Windows.Forms.Label();
		this.sliderDelay = new SiticoneSlider();
		this.hasDelay = new SiticoneToggleSwitch();
		this.del = new System.Windows.Forms.Label();
		this.label9 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.hasEmbed = new SiticoneCustomCheckBox();
		this.hasLive = new SiticoneCustomCheckBox();
		this.startBtn = new SiticoneButton();
		this.emot = new SiticoneTextBox();
		this.channelId = new SiticoneTextBox();
		this.messageId = new SiticoneTextBox();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.siticoneDragControl1 = new SiticoneDragControl(this.components);
		this.xsmodeTypeEnable = new SiticoneToggleSwitch();
		this.label4 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.siticoneButton1 = new SiticoneButton();
		this.emoAsst = new SiticoneGradientButton();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Inter", 15.75f, System.Drawing.FontStyle.Bold);
		this.label1.Location = new System.Drawing.Point(13, 36);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(207, 25);
		this.label1.TabIndex = 3;
		this.label1.Text = "Reaction Spammer";
		((System.Windows.Forms.Control)(object)this.sliderDelay).Cursor = System.Windows.Forms.Cursors.Hand;
		this.sliderDelay.LargeChange = 5;
		((System.Windows.Forms.Control)(object)this.sliderDelay).Location = new System.Drawing.Point(28, 417);
		((System.Windows.Forms.Control)(object)this.sliderDelay).Name = "sliderDelay";
		((System.Windows.Forms.Control)(object)this.sliderDelay).Size = new System.Drawing.Size(640, 60);
		((System.Windows.Forms.Control)(object)this.sliderDelay).TabIndex = 63;
		this.sliderDelay.Scroll += new System.EventHandler(sliderDelay_Scroll);
		this.hasDelay.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasDelay.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasDelay.CheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.hasDelay.CheckedState.InnerColor = System.Drawing.Color.White;
		this.hasDelay.CheckedState.Parent = (ToggleSwitch)(object)this.hasDelay;
		((System.Windows.Forms.Control)(object)this.hasDelay).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.hasDelay).Location = new System.Drawing.Point(548, 365);
		((System.Windows.Forms.Control)(object)this.hasDelay).Name = "hasDelay";
		this.hasDelay.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.hasDelay;
		((System.Windows.Forms.Control)(object)this.hasDelay).Size = new System.Drawing.Size(32, 20);
		((System.Windows.Forms.Control)(object)this.hasDelay).TabIndex = 62;
		this.hasDelay.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasDelay.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasDelay.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.hasDelay.UncheckedState.InnerColor = System.Drawing.Color.White;
		this.hasDelay.UncheckedState.Parent = (ToggleSwitch)(object)this.hasDelay;
		this.del.AutoSize = true;
		this.del.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold);
		this.del.Location = new System.Drawing.Point(585, 368);
		this.del.Name = "del";
		this.del.Size = new System.Drawing.Size(74, 14);
		this.del.TabIndex = 61;
		this.del.Text = "Delay: 0ms";
		this.label9.AutoSize = true;
		this.label9.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold);
		this.label9.Location = new System.Drawing.Point(49, 353);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(38, 14);
		this.label9.TabIndex = 60;
		this.label9.Text = "Emoji";
		this.label8.AutoSize = true;
		this.label8.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold);
		this.label8.Location = new System.Drawing.Point(49, 374);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(44, 14);
		this.label8.TabIndex = 59;
		this.label8.Text = "Emote";
		((System.Windows.Forms.Control)(object)this.hasEmbed).BackColor = System.Drawing.Color.Transparent;
		this.hasEmbed.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasEmbed.CheckedState.BorderRadius = 2;
		this.hasEmbed.CheckedState.BorderThickness = 0;
		this.hasEmbed.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasEmbed.CheckedState.Parent = (CustomCheckBox)(object)this.hasEmbed;
		((System.Windows.Forms.Control)(object)this.hasEmbed).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.hasEmbed).Location = new System.Drawing.Point(31, 374);
		((System.Windows.Forms.Control)(object)this.hasEmbed).Name = "hasEmbed";
		this.hasEmbed.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.hasEmbed;
		((System.Windows.Forms.Control)(object)this.hasEmbed).Size = new System.Drawing.Size(15, 15);
		((System.Windows.Forms.Control)(object)this.hasEmbed).TabIndex = 58;
		this.hasEmbed.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasEmbed.UncheckedState.BorderRadius = 2;
		this.hasEmbed.UncheckedState.BorderThickness = 0;
		this.hasEmbed.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasEmbed.UncheckedState.Parent = (CustomCheckBox)(object)this.hasEmbed;
		((CustomCheckBox)this.hasEmbed).CheckedChanged += new System.EventHandler(hasEmbed_CheckedChanged);
		((System.Windows.Forms.Control)(object)this.hasEmbed).Click += new System.EventHandler(hasEmbed_Click);
		this.hasLive.Checked = true;
		this.hasLive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasLive.CheckedState.BorderRadius = 2;
		this.hasLive.CheckedState.BorderThickness = 0;
		this.hasLive.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasLive.CheckedState.Parent = (CustomCheckBox)(object)this.hasLive;
		this.hasLive.CheckState = System.Windows.Forms.CheckState.Checked;
		((System.Windows.Forms.Control)(object)this.hasLive).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.hasLive).Location = new System.Drawing.Point(31, 353);
		((System.Windows.Forms.Control)(object)this.hasLive).Name = "hasLive";
		this.hasLive.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.hasLive;
		((System.Windows.Forms.Control)(object)this.hasLive).Size = new System.Drawing.Size(15, 15);
		((System.Windows.Forms.Control)(object)this.hasLive).TabIndex = 57;
		this.hasLive.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasLive.UncheckedState.BorderRadius = 2;
		this.hasLive.UncheckedState.BorderThickness = 0;
		this.hasLive.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasLive.UncheckedState.Parent = (CustomCheckBox)(object)this.hasLive;
		((CustomCheckBox)this.hasLive).CheckedChanged += new System.EventHandler(hasLive_CheckedChanged);
		((System.Windows.Forms.Control)(object)this.hasLive).Click += new System.EventHandler(hasLive_Click);
		((System.Windows.Forms.Control)(object)this.startBtn).BackColor = System.Drawing.Color.Transparent;
		this.startBtn.BorderColor = System.Drawing.Color.LightGray;
		this.startBtn.BorderRadius = 4;
		this.startBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
		this.startBtn.BorderThickness = 1;
		this.startBtn.CheckedState.Parent = (CustomButtonBase)(object)this.startBtn;
		((System.Windows.Forms.Control)(object)this.startBtn).Cursor = System.Windows.Forms.Cursors.Hand;
		this.startBtn.CustomImages.Parent = (CustomButtonBase)(object)this.startBtn;
		this.startBtn.FillColor = System.Drawing.Color.Snow;
		((System.Windows.Forms.Control)(object)this.startBtn).Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.startBtn).ForeColor = System.Drawing.Color.Black;
		this.startBtn.HoveredState.Parent = (CustomButtonBase)(object)this.startBtn;
		((System.Windows.Forms.Control)(object)this.startBtn).Location = new System.Drawing.Point(22, 508);
		((System.Windows.Forms.Control)(object)this.startBtn).Name = "startBtn";
		this.startBtn.PressedColor = System.Drawing.Color.White;
		this.startBtn.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.startBtn;
		((System.Windows.Forms.Control)(object)this.startBtn).Size = new System.Drawing.Size(323, 31);
		((System.Windows.Forms.Control)(object)this.startBtn).TabIndex = 55;
		((System.Windows.Forms.Control)(object)this.startBtn).Text = "Spam Reactions";
		this.startBtn.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.startBtn).Click += new System.EventHandler(startBtn_Click);
		((System.Windows.Forms.Control)(object)this.startBtn).MouseEnter += new System.EventHandler(startBtn_MouseEnter);
		((System.Windows.Forms.Control)(object)this.startBtn).MouseLeave += new System.EventHandler(startBtn_MouseLeave);
		this.emot.Animated = false;
		((System.Windows.Forms.Control)(object)this.emot).BackColor = System.Drawing.Color.Transparent;
		this.emot.BorderRadius = 4;
		this.emot.BorderThickness = 2;
		((System.Windows.Forms.Control)(object)this.emot).Cursor = System.Windows.Forms.Cursors.IBeam;
		((TextBox)this.emot).DefaultText = "";
		this.emot.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		this.emot.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		this.emot.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.emot.DisabledState.Parent = (TextBox)(object)this.emot;
		this.emot.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.emot.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.emot.FocusedState.Parent = (TextBox)(object)this.emot;
		((TextBox)this.emot).Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		((TextBox)this.emot).ForeColor = System.Drawing.Color.Black;
		this.emot.HoveredState.BorderColor = System.Drawing.Color.FromArgb(213, 218, 223);
		this.emot.HoveredState.Parent = (TextBox)(object)this.emot;
		((System.Windows.Forms.Control)(object)this.emot).Location = new System.Drawing.Point(28, 190);
		((System.Windows.Forms.Control)(object)this.emot).Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		((System.Windows.Forms.Control)(object)this.emot).Name = "emot";
		((TextBox)this.emot).PasswordChar = '\0';
		this.emot.PlaceholderText = "Emoji Unicode or Emote ID";
		((TextBox)this.emot).SelectedText = "";
		this.emot.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.emot;
		((System.Windows.Forms.Control)(object)this.emot).Size = new System.Drawing.Size(437, 37);
		((System.Windows.Forms.Control)(object)this.emot).TabIndex = 52;
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
		((TextBox)this.channelId).Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		((TextBox)this.channelId).ForeColor = System.Drawing.Color.Black;
		this.channelId.HoveredState.BorderColor = System.Drawing.Color.FromArgb(213, 218, 223);
		this.channelId.HoveredState.Parent = (TextBox)(object)this.channelId;
		((System.Windows.Forms.Control)(object)this.channelId).Location = new System.Drawing.Point(28, 233);
		((System.Windows.Forms.Control)(object)this.channelId).Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		((System.Windows.Forms.Control)(object)this.channelId).Name = "channelId";
		((TextBox)this.channelId).PasswordChar = '\0';
		this.channelId.PlaceholderText = "Channel ID";
		((TextBox)this.channelId).SelectedText = "";
		this.channelId.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.channelId;
		((System.Windows.Forms.Control)(object)this.channelId).Size = new System.Drawing.Size(640, 36);
		((System.Windows.Forms.Control)(object)this.channelId).TabIndex = 64;
		this.messageId.Animated = false;
		((System.Windows.Forms.Control)(object)this.messageId).BackColor = System.Drawing.Color.Transparent;
		this.messageId.BorderRadius = 4;
		this.messageId.BorderThickness = 2;
		((System.Windows.Forms.Control)(object)this.messageId).Cursor = System.Windows.Forms.Cursors.IBeam;
		((TextBox)this.messageId).DefaultText = "";
		this.messageId.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		this.messageId.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		this.messageId.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.messageId.DisabledState.Parent = (TextBox)(object)this.messageId;
		this.messageId.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.messageId.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.messageId.FocusedState.Parent = (TextBox)(object)this.messageId;
		((TextBox)this.messageId).Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		((TextBox)this.messageId).ForeColor = System.Drawing.Color.Black;
		this.messageId.HoveredState.BorderColor = System.Drawing.Color.FromArgb(213, 218, 223);
		this.messageId.HoveredState.Parent = (TextBox)(object)this.messageId;
		((System.Windows.Forms.Control)(object)this.messageId).Location = new System.Drawing.Point(28, 275);
		((System.Windows.Forms.Control)(object)this.messageId).Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		((System.Windows.Forms.Control)(object)this.messageId).Name = "messageId";
		((TextBox)this.messageId).PasswordChar = '\0';
		this.messageId.PlaceholderText = "Message ID";
		((TextBox)this.messageId).SelectedText = "";
		this.messageId.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.messageId;
		((System.Windows.Forms.Control)(object)this.messageId).Size = new System.Drawing.Size(640, 36);
		((System.Windows.Forms.Control)(object)this.messageId).TabIndex = 65;
		this.pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
		this.pictureBox2.Location = new System.Drawing.Point(633, 36);
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.Size = new System.Drawing.Size(35, 23);
		this.pictureBox2.TabIndex = 68;
		this.pictureBox2.TabStop = false;
		this.siticoneDragControl1.TargetControl = this;
		this.xsmodeTypeEnable.Checked = true;
		this.xsmodeTypeEnable.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.xsmodeTypeEnable.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.xsmodeTypeEnable.CheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.xsmodeTypeEnable.CheckedState.InnerColor = System.Drawing.Color.White;
		this.xsmodeTypeEnable.CheckedState.Parent = (ToggleSwitch)(object)this.xsmodeTypeEnable;
		((System.Windows.Forms.Control)(object)this.xsmodeTypeEnable).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.xsmodeTypeEnable).Location = new System.Drawing.Point(552, 121);
		((System.Windows.Forms.Control)(object)this.xsmodeTypeEnable).Name = "xsmodeTypeEnable";
		this.xsmodeTypeEnable.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.xsmodeTypeEnable;
		((System.Windows.Forms.Control)(object)this.xsmodeTypeEnable).Size = new System.Drawing.Size(32, 20);
		((System.Windows.Forms.Control)(object)this.xsmodeTypeEnable).TabIndex = 74;
		this.xsmodeTypeEnable.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.xsmodeTypeEnable.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.xsmodeTypeEnable.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.xsmodeTypeEnable.UncheckedState.InnerColor = System.Drawing.Color.White;
		this.xsmodeTypeEnable.UncheckedState.Parent = (ToggleSwitch)(object)this.xsmodeTypeEnable;
		((System.Windows.Forms.Control)(object)this.xsmodeTypeEnable).Click += new System.EventHandler(xsmodeTypeEnable_Click);
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.Location = new System.Drawing.Point(589, 124);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(44, 14);
		this.label4.TabIndex = 73;
		this.label4.Text = "XS V4";
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.ForeColor = System.Drawing.Color.Teal;
		this.label3.Location = new System.Drawing.Point(25, 105);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(339, 60);
		this.label3.TabIndex = 72;
		this.label3.Text = "Reaction Spammer V4 has been improved and\r\nnow working with the latest discord security patch.\r\nAdded Encoding Support.\r\nFixed Threading Errors.";
		((System.Windows.Forms.Control)(object)this.siticoneButton1).BackColor = System.Drawing.Color.Transparent;
		this.siticoneButton1.BorderColor = System.Drawing.Color.LightGray;
		this.siticoneButton1.BorderRadius = 4;
		this.siticoneButton1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
		this.siticoneButton1.BorderThickness = 1;
		this.siticoneButton1.CheckedState.Parent = (CustomButtonBase)(object)this.siticoneButton1;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneButton1.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneButton1;
		this.siticoneButton1.FillColor = System.Drawing.Color.Snow;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).ForeColor = System.Drawing.Color.Black;
		this.siticoneButton1.HoveredState.Parent = (CustomButtonBase)(object)this.siticoneButton1;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Location = new System.Drawing.Point(351, 508);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Name = "siticoneButton1";
		this.siticoneButton1.PressedColor = System.Drawing.Color.White;
		this.siticoneButton1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneButton1;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Size = new System.Drawing.Size(317, 31);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).TabIndex = 85;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Text = "Remove Reactions";
		this.siticoneButton1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Click += new System.EventHandler(siticoneButton1_Click);
		this.emoAsst.BorderRadius = 18;
		((ButtonState)this.emoAsst.CheckedState).Parent = (CustomButtonBase)(object)this.emoAsst;
		((System.Windows.Forms.Control)(object)this.emoAsst).Cursor = System.Windows.Forms.Cursors.Hand;
		this.emoAsst.CustomImages.Parent = (CustomButtonBase)(object)this.emoAsst;
		this.emoAsst.FillColor = System.Drawing.Color.DodgerBlue;
		this.emoAsst.FillColor2 = System.Drawing.Color.DeepSkyBlue;
		((System.Windows.Forms.Control)(object)this.emoAsst).Font = new System.Drawing.Font("SF Pro Text", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.emoAsst).ForeColor = System.Drawing.Color.White;
		((ButtonState)this.emoAsst.HoveredState).Parent = (CustomButtonBase)(object)this.emoAsst;
		this.emoAsst.Image = (System.Drawing.Image)resources.GetObject("emoAsst.Image");
		this.emoAsst.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.emoAsst.ImageOffset = new System.Drawing.Point(6, -1);
		((System.Windows.Forms.Control)(object)this.emoAsst).Location = new System.Drawing.Point(481, 189);
		((System.Windows.Forms.Control)(object)this.emoAsst).Name = "emoAsst";
		this.emoAsst.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.emoAsst;
		((System.Windows.Forms.Control)(object)this.emoAsst).Size = new System.Drawing.Size(187, 37);
		((System.Windows.Forms.Control)(object)this.emoAsst).TabIndex = 103;
		((System.Windows.Forms.Control)(object)this.emoAsst).Text = "Emojis";
		this.emoAsst.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.emoAsst).Click += new System.EventHandler(siticoneGradientButton4_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.Controls.Add((System.Windows.Forms.Control)(object)this.emoAsst);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneButton1);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.xsmodeTypeEnable);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.pictureBox2);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.messageId);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.channelId);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.sliderDelay);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.hasDelay);
		base.Controls.Add(this.del);
		base.Controls.Add(this.label9);
		base.Controls.Add(this.label8);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.hasEmbed);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.hasLive);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.startBtn);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.emot);
		base.Controls.Add(this.label1);
		base.Name = "ReactionSpammer";
		base.Size = new System.Drawing.Size(682, 555);
		base.Load += new System.EventHandler(ReactionSpammer_Load);
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
