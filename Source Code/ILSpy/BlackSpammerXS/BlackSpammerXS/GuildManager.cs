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
using BrotliSharpLib;
using Newtonsoft.Json.Linq;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Suite;

namespace BlackSpammerXS;

public class GuildManager : UserControl
{
	private bool needParsing = false;

	private IContainer components = null;

	private Label label1;

	private SiticoneDragControl siticoneDragControl1;

	private SiticoneTextBox channelId;

	private SiticoneButton siticoneButton1;

	private SiticoneButton startBtn;

	private SiticoneSlider sliderDelay;

	private SiticoneToggleSwitch hasDelay;

	private Label del;

	private Label label9;

	private Label label8;

	private SiticoneCustomCheckBox hasCaptchaSVX;

	private SiticoneCustomCheckBox hasPCM;

	private PictureBox pictureBox2;

	private SiticoneToggleSwitch xsmodeTypeEnable;

	private Label label4;

	private Label label3;

	private Label label5;

	private SiticoneCustomCheckBox mbvfbypass;

	private SiticoneTextBox siticoneTextBox1;

	private SiticoneTextBox siticoneTextBox2;

	private Label label2;

	private SiticoneCustomCheckBox siticoneCustomCheckBox1;

	public GuildManager()
	{
		InitializeComponent();
	}

	private void sliderThreads_Scroll(object sender, EventArgs e)
	{
		del.Text = "Delay: " + (sliderDelay.Value + 200) + "ms";
	}

	private async void hasLive_Click(object sender, EventArgs e)
	{
	}

	private async void siticoneButton1_Click(object sender, EventArgs e)
	{
		if (((TextBox)channelId).Text == "")
		{
			MessageBox.Show("Server Invite or Guild ID is required");
			return;
		}
		if (ImpostazioniGlobali.CaptchaKey_TWO == "")
		{
			hasCaptchaSVX.Checked = false;
		}
		((Control)(object)siticoneButton1).Text = "Joining..";
		((Control)(object)siticoneButton1).Enabled = false;
		if (ImpostazioniGlobali.Tokens == null || ImpostazioniGlobali.Proxies == null)
		{
			((Control)(object)siticoneButton1).Text = "Join";
			((Control)(object)siticoneButton1).Enabled = true;
			MessageBox.Show("At least 1 token and 1 proxy must be imported");
			return;
		}
		ImpostazioniGlobali.StartLog();
		Random random = new Random();
		List<string> proxies = ImpostazioniGlobali.Proxies;
		string guildInvite = ((TextBox)channelId).Text.Replace("https", "").Replace("/", "").Replace(":", "")
			.Replace("discordapp.com", "")
			.Replace(" ", "")
			.Replace("discord.gg", "")
			.Replace("discord.com", "")
			.Replace("invite", "")
			.Replace(" ", "")
			.Replace(".", "");
		ImpostazioniGlobali.Log("Manager -> (Operation Starting) Join => Joining in " + guildInvite + " with " + proxies.Count + " proxies and " + ImpostazioniGlobali.Tokens.Count + " tokens.. Delay has been set to " + sliderDelay.Value);
		bool hasDel = hasDelay.Checked;
		if (sliderDelay.Value == 0)
		{
			hasDel = false;
			hasDelay.Checked = false;
		}
		if (!ImpostazioniGlobali.UseOldParsing)
		{
			needParsing = true;
		}
		try
		{
			AuditManager auditManager = ImpostazioniGlobali.auditManager;
			auditManager.LogActionJoin(guildInvite);
		}
		catch (Exception)
		{
		}
		ThreadPool.GetMaxThreads(out var _, out var o);
		ThreadPool.SetMinThreads(o - 1, o - 1);
		string xcpGID = ((TextBox)siticoneTextBox2).Text;
		ImpostazioniGlobali.Log("[G" + xcpGID + "] Join => XCP Status: 0");
		string xcp_b64 = ImpostazioniGlobali.base64_encode(ImpostazioniGlobali.XCP_Default);
		if (xcpGID != "")
		{
			ImpostazioniGlobali.Log("[G" + xcpGID + "] Join => Generating XCP..");
			string xcpdef = ImpostazioniGlobali.XCP_Default ?? "";
			xcpdef = xcpdef.Replace(ImpostazioniGlobali.XCP_GID, xcpGID);
			string b64cdef = ImpostazioniGlobali.base64_encode(xcpdef);
			if (b64cdef == "ERR")
			{
				ImpostazioniGlobali.Log("[G" + xcpGID + "] Join => An error has occurred while generating XCP64.");
				try
				{
					JObject devDebug = ImpostazioniGlobali.CreateDebugAction(timestamp: ImpostazioniGlobali.GetReadableDateNow(), id: 19, act: "CL+_JOIN", of: "GUILD_MANAGER_ERR_XCP_64", notesRaw: new string[4]
					{
						"BUTTON_JOIN",
						"T_" + ImpostazioniGlobali.Tokens.Count + "_P_" + ImpostazioniGlobali.Proxies.Count,
						"CWH_CHID_P__" + guildInvite,
						"CWH_CHILD_UNP__" + ((TextBox)channelId).Text
					}, a: "GMAN_0x1_1_GJL_JN_2");
					ImpostazioniGlobali.Debug_DPut(devDebug);
				}
				catch (Exception)
				{
				}
			}
			else
			{
				xcp_b64 = b64cdef;
				ImpostazioniGlobali.Log(" [G" + xcpGID + "] Join => XCP was successfully generated. Length RAW: " + xcpdef.Length + " && Length B64: " + b64cdef.Length);
				try
				{
					JObject devDebug2 = ImpostazioniGlobali.CreateDebugAction(timestamp: ImpostazioniGlobali.GetReadableDateNow(), id: 19, act: "CL+_JOIN", of: "GUILD_MANAGER_XCP_GEN", notesRaw: new string[4]
					{
						"BUTTON_JOIN",
						"T_" + ImpostazioniGlobali.Tokens.Count + "_P_" + ImpostazioniGlobali.Proxies.Count,
						"CWH_CHID_P__" + guildInvite,
						"CWH_CHILD_UNP__" + ((TextBox)channelId).Text
					}, a: "GB64=" + xcp_b64);
					ImpostazioniGlobali.Debug_DPut(devDebug2);
				}
				catch (Exception)
				{
				}
			}
		}
		else
		{
			ImpostazioniGlobali.Log("[G" + xcpGID + "] Join => Skipping XCP generation. Using default. Length: " + xcp_b64.Length);
		}
		new Thread((ParameterizedThreadStart)delegate
		{
			foreach (string token in ImpostazioniGlobali.Tokens)
			{
				ThreadPool.UnsafeQueueUserWorkItem(async delegate
				{
					if (hasDel)
					{
						ImpostazioniGlobali.Log("Manager -> (Delay) (" + token + ") Join => Awaiting " + sliderDelay.Value + "ms of delay before joining.");
						await Task.Delay(sliderDelay.Value + 200);
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
						handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
						handler.Proxy = new WebProxy(proxy.Split(':')[0], int.Parse(proxy.Split(':')[1]));
						HttpClient http = new HttpClient((HttpMessageHandler)(object)handler);
						HttpRequestMessage val = new HttpRequestMessage();
						val.RequestUri = new Uri("https://discord.com/api/v9/invites/" + guildInvite + "?inputValue=" + guildInvite + "&with_counts=true");
						val.Method = HttpMethod.Get;
						((HttpHeaders)val.Headers).Add("Authorization", token);
						((HttpHeaders)val.Headers).Add("Accept-Language", "it");
						((HttpHeaders)val.Headers).Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36");
						((HttpHeaders)val.Headers).Add("X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9");
						((HttpHeaders)val.Headers).Add("Cookie", "locale=it");
						((HttpHeaders)val.Headers).Add("Sec-Fetch-Site", "same-origin");
						((HttpHeaders)val.Headers).Add("Sec-Fetch-Mode", "cors");
						((HttpHeaders)val.Headers).Add("Sec-Fetch-Dest", "empty");
						((HttpHeaders)val.Headers).Add("Referer", "https://discord.com/channels/@me");
						HttpRequestMessage requestGET = val;
						string _erspjoin = await (await http.SendAsync(requestGET)).Content.ReadAsStringAsync();
						if (!_erspjoin.Contains("approximate_member_count"))
						{
							ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Join => Invalid GET Response: " + _erspjoin);
							return;
						}
						HttpRequestMessage val2 = new HttpRequestMessage
						{
							Content = null,
							RequestUri = new Uri("https://discord.com/api/v9/invites/" + guildInvite),
							Method = HttpMethod.Post
						};
						((HttpHeaders)val2.Headers).Add("Authorization", token);
						((HttpHeaders)val2.Headers).Add("Accept-Language", "it");
						((HttpHeaders)val2.Headers).Add("Accept-Encoding", "gzip, deflate, br");
						((HttpHeaders)val2.Headers).Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36");
						((HttpHeaders)val2.Headers).Add("X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiQ2hyb21lIiwiZGV2aWNlIjoiIiwic3lzdGVtX2xvY2FsZSI6Iml0LUlUIiwiYnJvd3Nlcl91c2VyX2FnZW50IjoiTW96aWxsYS81LjAgKFdpbmRvd3MgTlQgMTAuMDsgV2luNjQ7IHg2NCkgQXBwbGVXZWJLaXQvNTM3LjM2IChLSFRNTCwgbGlrZSBHZWNrbykgQ2hyb21lLzg5LjAuNDM4OS4xMjggU2FmYXJpLzUzNy4zNiIsImJyb3dzZXJfdmVyc2lvbiI6Ijg5LjAuNDM4OS4xMjgiLCJvc192ZXJzaW9uIjoiMTAiLCJyZWZlcnJlciI6Imh0dHBzOi8vd3d3Lmdvb2dsZS5jb20vIiwicmVmZXJyaW5nX2RvbWFpbiI6Ind3dy5nb29nbGUuY29tIiwic2VhcmNoX2VuZ2luZSI6Imdvb2dsZSIsInJlZmVycmVyX2N1cnJlbnQiOiIiLCJyZWZlcnJpbmdfZG9tYWluX2N1cnJlbnQiOiIiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfYnVpbGRfbnVtYmVyIjo4MjExNywiY2xpZW50X2V2ZW50X3NvdXJjZSI6bnVsbH0=");
						((HttpHeaders)val2.Headers).Add("Accept", "*/*");
						((HttpHeaders)val2.Headers).Add("Cookie", "locale=it");
						((HttpHeaders)val2.Headers).Add("X-Context-Properties", xcp_b64);
						((HttpHeaders)val2.Headers).Add("Connection", "keep-alive");
						((HttpHeaders)val2.Headers).Add("Host", "discord.com");
						((HttpHeaders)val2.Headers).Add("Origin", "https://discord.com");
						((HttpHeaders)val2.Headers).Add("Sec-Fetch-Site", "same-origin");
						((HttpHeaders)val2.Headers).Add("Sec-Fetch-Mode", "cors");
						((HttpHeaders)val2.Headers).Add("Sec-Fetch-Dest", "empty");
						((HttpHeaders)val2.Headers).Add("Referer", "https://discord.com/channels/@me");
						((HttpHeaders)val2.Headers).Add(HttpRequestHeader.ContentLength.ToString(), "0");
						HttpRequestMessage request = val2;
						HttpResponseMessage req_jn = await http.SendAsync(request);
						string rspjoin = await req_jn.Content.ReadAsStringAsync();
						if (!rspjoin.StartsWith("{"))
						{
							try
							{
								byte[] buff_z = await req_jn.Content.ReadAsByteArrayAsync();
								byte[] bytearr_cnt = Brotli.DecompressBuffer(buff_z, 0, buff_z.Length, (byte[])null);
								rspjoin = Encoding.UTF8.GetString(bytearr_cnt);
								if (rspjoin.StartsWith("{\"code\":"))
								{
									ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Join => Successfully joined.");
								}
								else
								{
									ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Join => " + rspjoin);
								}
							}
							catch (Exception ex5)
							{
								Exception ex6 = ex5;
								ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Join => parse_respone ? unknown_perr[" + ex6.Message + "] wh_tr=br_decode");
							}
						}
						if (mbvfbypass.Checked && rspjoin.Contains("features") && rspjoin.Contains("["))
						{
							try
							{
								ImpostazioniGlobali.Log(proxy + " -> (" + token + ") MB Verification => Checking state..");
								dynamic jm = JObject.Parse(rspjoin);
								JArray serverFeatures0 = (JArray)jm.guild.features;
								string[] serverFeatures1 = ((JToken)serverFeatures0).ToObject<string[]>();
								dynamic guildobj = jm.guild;
								long gid = guildobj.id;
								if (serverFeatures1.Contains("MEMBER_VERIFICATION_GATE_ENABLED"))
								{
									ImpostazioniGlobali.Log(proxy + " -> (" + token + ") MB Verification => Verification is required. Verifying...");
									string url__requestVm = "https://discord.com/api/v9/guilds/" + gid + "/member-verification?with_guild=false&invite_code=" + guildInvite;
									HttpRequestMessage val3 = new HttpRequestMessage
									{
										RequestUri = new Uri(url__requestVm),
										Method = HttpMethod.Get
									};
									((HttpHeaders)val3.Headers).Add("Authorization", token);
									((HttpHeaders)val3.Headers).Add("Accept-Language", "it");
									((HttpHeaders)val3.Headers).Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36");
									((HttpHeaders)val3.Headers).Add("X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9");
									((HttpHeaders)val3.Headers).Add("Accept", "*/*");
									((HttpHeaders)val3.Headers).Add("Cookie", "locale=it");
									((HttpHeaders)val3.Headers).Add("Referer", "https://discord.com/channels/" + gid);
									HttpRequestMessage requestVM = val3;
									string responseVMReq = await (await http.SendAsync(requestVM)).Content.ReadAsStringAsync();
									if (!responseVMReq.Contains("version"))
									{
										throw new Exception("Cannot get panel");
									}
									ImpostazioniGlobali.Log(proxy + " -> (" + token + ") MB Verification => Successfully Got Panel. Handling..");
									string format__ = responseVMReq;
									string[] vfrmt = format__.Split(new string[1] { "}], \"description\"" }, StringSplitOptions.None);
									string prm00x = vfrmt[0] + ",\"response\":\"true\"}]}";
									HttpRequestMessage val4 = new HttpRequestMessage
									{
										Content = (HttpContent)new StringContent(prm00x, Encoding.UTF8, "application/json"),
										RequestUri = new Uri("https://discord.com/api/v9/guilds/" + gid + "/requests/@me"),
										Method = HttpMethod.Put
									};
									((HttpHeaders)val4.Headers).Add("Authorization", token);
									((HttpHeaders)val4.Headers).Add("Accept-Language", "it");
									((HttpHeaders)val4.Headers).Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36");
									((HttpHeaders)val4.Headers).Add("X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9");
									((HttpHeaders)val4.Headers).Add("Accept", "*/*");
									((HttpHeaders)val4.Headers).Add("Cookie", "locale=it");
									((HttpHeaders)val4.Headers).Add("Origin", "https://discord.com");
									((HttpHeaders)val4.Headers).Add("Referer", "https://discord.com/channels/" + gid);
									HttpRequestMessage requestVMput = val4;
									((HttpHeaders)requestVMput.Content.Headers).Add("Content-Length", prm00x.Length.ToString() ?? "");
									string a_mvb83t = await (await http.SendAsync(requestVMput)).Content.ReadAsStringAsync();
									if (a_mvb83t.Contains("APPROVED"))
									{
										ImpostazioniGlobali.Log(proxy + " -> (" + token + ") MB Verification => Success.");
									}
									else
									{
										ImpostazioniGlobali.Log(proxy + " -> (" + token + ") MB Verification => " + a_mvb83t);
									}
								}
							}
							catch (Exception ex5)
							{
								Exception ee = ex5;
								ImpostazioniGlobali.Log(proxy + " -> (" + token + ") MB Verification => An error has occurred: " + ee.Message);
							}
						}
						if (hasCaptchaSVX.Checked)
						{
							ImpostazioniGlobali.Log(proxy + " -> (" + token + ") SVX Captcha => Bypassing Server Captcha Bot with SVX Method.");
							Thread.Sleep(500);
							try
							{
								string ab_str = "{\"recipients\": [\"512333785338216465\"]}";
								string getRecpUrl = "https://discord.com/api/v9/users/@me/channels";
								HttpRequestMessage val5 = new HttpRequestMessage
								{
									Content = (HttpContent)new StringContent(ab_str, Encoding.UTF8, "application/json"),
									RequestUri = new Uri(getRecpUrl),
									Method = HttpMethod.Post
								};
								((HttpHeaders)val5.Headers).Add("Authorization", token);
								((HttpHeaders)val5.Headers).Add("Accept-Language", "it");
								((HttpHeaders)val5.Headers).Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36");
								((HttpHeaders)val5.Headers).Add("X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9");
								((HttpHeaders)val5.Headers).Add("Accept", "*/*");
								((HttpHeaders)val5.Headers).Add("Cookie", "locale=it");
								((HttpHeaders)val5.Headers).Add("Origin", "https://discord.com");
								((HttpHeaders)val5.Headers).Add("X-Context-Properties", "e30=");
								((HttpHeaders)val5.Headers).Add("Referer", "https://discord.com/channels/@me");
								HttpRequestMessage requestRCPput = val5;
								((HttpHeaders)requestRCPput.Content.Headers).Add("Content-Length", ab_str.Length.ToString() ?? "");
								string respRecipient = await (await http.SendAsync(requestRCPput)).Content.ReadAsStringAsync();
								if (!respRecipient.Contains("id"))
								{
									throw new Exception("Invalid Recipient Response");
								}
								dynamic objrespRecp = JObject.Parse(respRecipient);
								long recId = objrespRecp.id;
								ImpostazioniGlobali.Log(proxy + " -> (" + token + ") SVX Captcha => Got Recipient ID: " + recId);
								string dmMessagesURL = "https://discord.com/api/v9/channels/" + recId + "/messages?limit=50";
								HttpRequestMessage val6 = new HttpRequestMessage
								{
									RequestUri = new Uri(dmMessagesURL),
									Method = HttpMethod.Get
								};
								((HttpHeaders)val6.Headers).Add("Authorization", token);
								((HttpHeaders)val6.Headers).Add("Accept-Language", "it");
								((HttpHeaders)val6.Headers).Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36");
								((HttpHeaders)val6.Headers).Add("X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9");
								((HttpHeaders)val6.Headers).Add("Accept", "*/*");
								((HttpHeaders)val6.Headers).Add("Cookie", "locale=it");
								((HttpHeaders)val6.Headers).Add("Referer", "https://discord.com/channels/@me");
								HttpRequestMessage reqGetDMMsgs = val6;
								string respDMM = "{\"BLCSVXrespDM\":" + await (await http.SendAsync(reqGetDMMsgs)).Content.ReadAsStringAsync() + "}";
								dynamic DMRsms = JObject.Parse(respDMM);
								JArray __dm_array = (JArray)DMRsms.BLCSVXrespDM;
								JObject[] __jobjs = ((JToken)__dm_array).ToObject<JObject[]>();
								JObject latestMessageSVX = __jobjs[0];
								string SVXfinalMsg = ((object)latestMessageSVX).ToString();
								int indexWhereHTTP = SVXfinalMsg.IndexOf("https");
								int indexWherePNG = SVXfinalMsg.IndexOf(".png");
								string SVXcaptchaURL = SVXfinalMsg.Substring(indexWhereHTTP, indexWherePNG - indexWhereHTTP) + ".png";
								ImpostazioniGlobali.Log(proxy + " -> (" + token + ") SVX Captcha => Got Image URL: " + SVXcaptchaURL);
								TwoCaptchaHandler captchaHandler = new TwoCaptchaHandler(ImpostazioniGlobali.CaptchaKey_TWO);
								ImpostazioniGlobali.Log(proxy + " -> (" + token + ") SVX Captcha => Downloading Base64 Image and Submitting Captcha to 2Captcha..");
								string resolvedResult = await captchaHandler.ResolveImageCaptcha(SVXcaptchaURL);
								if (resolvedResult == "ERROR")
								{
									throw new Exception("An error has occurred while resolving captcha with 2captcha.");
								}
								ImpostazioniGlobali.Log(proxy + " -> (" + token + ") SVX Captcha => 2CAPTCHA: Captcha has been resolved! Result: " + resolvedResult);
								ImpostazioniGlobali.Log(proxy + " -> (" + token + ") SVX Captcha => Submitting Result...");
								string cnn_sv = "{\"content\": \"" + resolvedResult + "\", \"nonce\": null, \"tts\": false}";
								StringContent content_ac_dm_svx = new StringContent(cnn_sv, Encoding.UTF8, "application/json");
								string submitMsgRESCap = "https://discord.com/api/v9/channels/" + recId + "/messages";
								HttpRequestMessage val7 = new HttpRequestMessage
								{
									Content = (HttpContent)(object)content_ac_dm_svx,
									RequestUri = new Uri(submitMsgRESCap),
									Method = HttpMethod.Post
								};
								((HttpHeaders)val7.Headers).Add("Authorization", token);
								((HttpHeaders)val7.Headers).Add("Accept-Language", "it");
								((HttpHeaders)val7.Headers).Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36");
								((HttpHeaders)val7.Headers).Add("X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9");
								((HttpHeaders)val7.Headers).Add("Accept", "*/*");
								((HttpHeaders)val7.Headers).Add("Cookie", "locale=it");
								((HttpHeaders)val7.Headers).Add("Origin", "https://discord.com");
								((HttpHeaders)val7.Headers).Add("Referer", "https://discord.com/channels/" + recId);
								((HttpHeaders)val7.Headers).Add(HttpRequestHeader.ContentLength.ToString(), cnn_sv.Length.ToString() ?? "");
								HttpRequestMessage resCAP = val7;
								string respCAPSub = await (await http.SendAsync(resCAP)).Content.ReadAsStringAsync();
								bool wasSVXsuccess = false;
								if (respCAPSub.Contains("id"))
								{
									wasSVXsuccess = true;
								}
								ImpostazioniGlobali.Log(proxy + " -> (" + token + ") SVX Captcha => Submit: " + respCAPSub);
								Thread.Sleep(100);
								if (wasSVXsuccess)
								{
									ImpostazioniGlobali.Log(proxy + " -> (" + token + ") SVX Captcha => Captcha was completed successfully.");
								}
								else
								{
									ImpostazioniGlobali.Log(proxy + " -> (" + token + ") SVX Captcha => Unable to complete the captcha.");
								}
							}
							catch (Exception ex5)
							{
								Exception ed = ex5;
								ImpostazioniGlobali.Log(proxy + " -> (" + token + ") SVX Captcha => An error has occurred: " + ed.Message);
							}
						}
						if (needParsing)
						{
							ImpostazioniGlobali._bridgeGS(1, 0, null);
							needParsing = false;
							new Thread((ParameterizedThreadStart)delegate
							{
								MassTagV2XParse(rspjoin, token, proxy);
							}).Start();
						}
					}
					catch (Exception)
					{
						if (ImpostazioniGlobali.StreamerMode)
						{
							ImpostazioniGlobali.Log(proxy + " -> (Token " + ImpostazioniGlobali.Tokens.IndexOf(token) + ") Join => Unknown Error [Check your proxies]");
						}
						else
						{
							ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Join => Unknown Error [Check your proxies]");
						}
					}
					try
					{
						Thread.CurrentThread.Interrupt();
					}
					catch
					{
					}
				}, null);
			}
		}).Start();
		((Control)(object)siticoneButton1).Text = "Join";
		((Control)(object)siticoneButton1).Enabled = true;
	}

	private async void MassTagV3(string joinResponse, string token, string proxy)
	{
		if (!ImpostazioniGlobali.AutoParse)
		{
			ImpostazioniGlobali.Log(proxy + " -> (" + token + ") MassV3X => Skipping parsing as requested by the user.");
			return;
		}
		try
		{
			if (joinResponse.Contains("id") && joinResponse.Contains("{"))
			{
				dynamic jm = JObject.Parse(joinResponse);
				dynamic guildobj = jm.guild;
				long gid = guildobj.id;
				HttpClientHandler handler = new HttpClientHandler();
				handler.PreAuthenticate = true;
				handler.UseProxy = true;
				handler.Proxy = new WebProxy(proxy.Split(':')[0], int.Parse(proxy.Split(':')[1]));
				HttpClient http = new HttpClient((HttpMessageHandler)(object)handler);
				ImpostazioniGlobali.Log(proxy + " -> (" + token + ") [" + gid + "] MassV3X => Parsing Guild " + gid + "..");
				ImpostazioniGlobali.Log(proxy + " -> (" + token + ") [" + gid + "] MassV3X => Starting websocket..");
				BlackWSManager blackWS = new BlackWSManager(token, proxy);
				blackWS.connect();
				if (await blackWS.WaitForData(2500))
				{
					ImpostazioniGlobali.Log(proxy + " -> (" + token + ") [" + gid + "] MassV3X => Got data from websocket. Guilds: " + blackWS.GetGuilds().Count);
				}
				else
				{
					ImpostazioniGlobali.Log(proxy + " -> (" + token + ") [" + gid + "] MassV3X => An error with the websocket has occurred. No data received.");
				}
				GuildChannels thisGuildChannel = null;
				foreach (GuildChannels gc in blackWS.GetGuilds())
				{
					if (gc.GetGuildId() == gid.ToString())
					{
						thisGuildChannel = gc;
					}
				}
				if (thisGuildChannel == null)
				{
					ImpostazioniGlobali.Log(proxy + " -> (" + token + ") [" + gid + "] MassV3X => WS Error: No guild with ID " + gid + " got from READY payload.");
					return;
				}
				foreach (GChannel channel in thisGuildChannel.GetChannels())
				{
					if (channel.GetChannelType() != 0)
					{
						continue;
					}
					new Thread((ParameterizedThreadStart)async delegate
					{
						try
						{
							ImpostazioniGlobali.Log(proxy + " -> (" + token + ") [" + gid + "] MassV3X => Got #" + channel.GetName() + " with ID " + channel.GetId() + " from websocket READY payload.");
							string messageGetURL = "https://discord.com/api/v9/channels/" + channel.GetName() + "/messages?limit=50";
							HttpRequestMessage val = new HttpRequestMessage
							{
								RequestUri = new Uri(messageGetURL),
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
							if (!(respCHMessages == "[]"))
							{
								JArray messagesArr = JArray.Parse(respCHMessages);
								JObject[] jMObjects = ((JToken)messagesArr).ToObject<JObject[]>();
								JObject[] array = jMObjects;
								foreach (dynamic objMsgCH in array)
								{
									ImpostazioniGlobali._bridgeGS(1, 1, objMsgCH.author.id);
								}
								dynamic __lastMsg = jMObjects[jMObjects.Length - 1];
								long __lastId = __lastMsg.id;
								string beforeURL = "https://discord.com/api/v9/channels/" + channel.GetName() + "/messages?before=" + __lastId + "&limit=50";
								HttpRequestMessage val2 = new HttpRequestMessage
								{
									RequestUri = new Uri(beforeURL),
									Method = HttpMethod.Get
								};
								((HttpHeaders)val2.Headers).Add("Authorization", token);
								((HttpHeaders)val2.Headers).Add("Accept-Language", "it");
								((HttpHeaders)val2.Headers).Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36");
								((HttpHeaders)val2.Headers).Add("X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9");
								((HttpHeaders)val2.Headers).Add("Accept", "*/*");
								((HttpHeaders)val2.Headers).Add("Cookie", "locale=it");
								((HttpHeaders)val2.Headers).Add("Referer", "https://discord.com/channels/" + channel.GetId());
								HttpRequestMessage requestMessagesBefore = val2;
								string respCHMessages2 = await (await http.SendAsync(requestMessagesBefore)).Content.ReadAsStringAsync();
								if (!(respCHMessages2 == "[]"))
								{
									JArray.Parse(respCHMessages2);
									JObject[] jMObjects2 = ((JToken)messagesArr).ToObject<JObject[]>();
									JObject[] array2 = jMObjects2;
									foreach (dynamic objMsgCH2 in array2)
									{
										ImpostazioniGlobali._bridgeGS(1, 1, objMsgCH2.author.id);
									}
									ImpostazioniGlobali.Log(proxy + " -> (" + token + ") [" + gid + "] MassV3X => #" + channel.GetName() + " {" + channel.GetId() + "} has been successfully parsed!");
								}
							}
						}
						catch (Exception ex)
						{
							Exception err = ex;
							if (err.Message == "Error reading JArray from JsonReader. Current JsonReader item is not an array: StartObject. Path '', line 1, position 1." || err.Message.StartsWith("Error reading JArray from JsonReader. Current JsonReader"))
							{
								ImpostazioniGlobali.Log(proxy + " -> (" + token + ") [" + gid + "] MassV3X => Il canale #" + channel.GetName() + " with ID " + channel.GetId() + " è privato e peranto è stato skippato!");
							}
							else
							{
								ImpostazioniGlobali.Log(proxy + " -> (" + token + ") [" + gid + "] MassV3X => An error has occurred with channel #" + channel.GetName() + " with ID " + channel.GetId() + ": " + err.Message);
							}
						}
					}).Start();
				}
				return;
			}
			throw new Exception("Invalid join response");
		}
		catch (Exception ex2)
		{
			ImpostazioniGlobali.Log("MassV3X => Errore durante il parsing: " + ex2.Message);
		}
	}

	private async void startBtn_Click(object sender, EventArgs e)
	{
		if (((TextBox)channelId).Text == "")
		{
			MessageBox.Show("A valid Server ID is required");
			return;
		}
		((Control)(object)startBtn).Text = "Leaving..";
		((Control)(object)startBtn).Enabled = false;
		if (ImpostazioniGlobali.Tokens == null || ImpostazioniGlobali.Proxies == null)
		{
			((Control)(object)startBtn).Text = "Leave";
			((Control)(object)startBtn).Enabled = true;
			MessageBox.Show("You must import at least 1 token and 1 proxy");
			return;
		}
		ImpostazioniGlobali.StartLog();
		Random random = new Random();
		List<string> proxies = ImpostazioniGlobali.Proxies;
		string guildInvite = ((TextBox)channelId).Text;
		ImpostazioniGlobali.Log("Manager -> (Operation Starting) Leave => Leaving in " + guildInvite + " with " + proxies.Count + " proxies and " + ImpostazioniGlobali.Tokens.Count + " tokens.. Delay has been set to " + sliderDelay.Value);
		bool hasDel = hasDelay.Checked;
		if (sliderDelay.Value == 0)
		{
			hasDel = false;
			hasDelay.Checked = false;
		}
		ThreadPool.GetMaxThreads(out var _, out var o);
		ThreadPool.SetMinThreads(o - 1, o - 1);
		try
		{
			AuditManager auditManager = ImpostazioniGlobali.auditManager;
			auditManager.LogActionLeave(((TextBox)channelId).Text);
		}
		catch (Exception)
		{
		}
		new Thread((ParameterizedThreadStart)delegate
		{
			foreach (string token in ImpostazioniGlobali.Tokens)
			{
				ThreadPool.UnsafeQueueUserWorkItem(async delegate
				{
					if (hasDel)
					{
						ImpostazioniGlobali.Log("Manager -> (Delay) (" + token + ") Leave => Awaiting " + sliderDelay.Value + "ms of delay before leaving.");
						Thread.Sleep(sliderDelay.Value + 200);
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
						string urlLeave = "https://discord.com/api/v9/users/@me/guilds/" + guildInvite;
						if (hasPCM.Checked)
						{
							ImpostazioniGlobali.Log("Manager => [PCM] Mode is enabled. Using /channels/ endpoint..");
							urlLeave = "https://discord.com/api/v9/channels/" + guildInvite;
						}
						HttpClientHandler handler = new HttpClientHandler();
						handler.PreAuthenticate = true;
						handler.UseProxy = true;
						handler.Proxy = new WebProxy(proxy.Split(':')[0], int.Parse(proxy.Split(':')[1]));
						HttpClient http = new HttpClient((HttpMessageHandler)(object)handler);
						HttpRequestMessage val = new HttpRequestMessage
						{
							RequestUri = new Uri(urlLeave),
							Method = HttpMethod.Delete
						};
						((HttpHeaders)val.Headers).Add("Authorization", token);
						((HttpHeaders)val.Headers).Add("Accept-Language", "it");
						((HttpHeaders)val.Headers).Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36");
						((HttpHeaders)val.Headers).Add("X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9");
						((HttpHeaders)val.Headers).Add("Accept", "*/*");
						((HttpHeaders)val.Headers).Add("Cookie", "locale=it");
						((HttpHeaders)val.Headers).Add("Origin", "https://discord.com");
						((HttpHeaders)val.Headers).Add("Referer", "https://discord.com/channels/@me");
						HttpRequestMessage request = val;
						string _r = await (await http.SendAsync(request)).Content.ReadAsStringAsync();
						if (_r == "")
						{
							_r = "Successfully Leaved";
						}
						if (ImpostazioniGlobali.StreamerMode)
						{
							ImpostazioniGlobali.Log(proxy + " -> (Token " + ImpostazioniGlobali.Tokens.IndexOf(token) + ") Leave => " + _r);
						}
						else
						{
							ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Leave => " + _r);
						}
						proxy = null;
					}
					catch (Exception ex3)
					{
						if (ex3.GetType() == typeof(ThreadAbortException))
						{
							return;
						}
						if (ImpostazioniGlobali.StreamerMode)
						{
							ImpostazioniGlobali.Log(proxy + " -> (Token " + ImpostazioniGlobali.Tokens.IndexOf(token) + ") Leave => Unknown Error [Check your proxies]");
						}
						else
						{
							ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Leave => Unknown Error [Check your proxies]");
						}
					}
					try
					{
						Thread.CurrentThread.Abort();
					}
					catch
					{
					}
				}, null);
			}
		}).Start();
		((Control)(object)startBtn).Text = "Leave";
		((Control)(object)startBtn).Enabled = true;
	}

	private void siticoneButton1_MouseEnter(object sender, EventArgs e)
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

	private void siticoneButton1_MouseLeave(object sender, EventArgs e)
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
			list.Add(siticoneButton1);
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
			((TextBox)siticoneTextBox1).ForeColor = Color.White;
			siticoneTextBox1.FillColor = fillColor;
			siticoneTextBox1.BorderColor = Color.Gray;
			siticoneTextBox1.HoveredState.BorderColor = Color.Gray;
			((TextBox)siticoneTextBox2).ForeColor = Color.White;
			siticoneTextBox2.FillColor = fillColor;
			siticoneTextBox2.BorderColor = Color.Gray;
			siticoneTextBox2.HoveredState.BorderColor = Color.Gray;
			sliderDelay.FillColor = Color.Gray;
			sliderDelay.ThumbColor = Color.RoyalBlue;
		}
		catch (Exception)
		{
		}
	}

	private async Task MassTagV2XParse(string joinResponse, string token, string proxy)
	{
		if (!ImpostazioniGlobali.AutoParse)
		{
			ImpostazioniGlobali.Log(proxy + " -> (" + token + ") MassV2X => Skipping parsing as requested by the user.");
			return;
		}
		try
		{
			if (joinResponse.Contains("id") && joinResponse.Contains("{"))
			{
				dynamic jm = JObject.Parse(joinResponse);
				dynamic guildobj = jm.guild;
				long gid = guildobj.id;
				HttpClientHandler handler = new HttpClientHandler();
				handler.PreAuthenticate = true;
				handler.UseProxy = true;
				handler.Proxy = new WebProxy(proxy.Split(':')[0], int.Parse(proxy.Split(':')[1]));
				HttpClient http = new HttpClient((HttpMessageHandler)(object)handler);
				ImpostazioniGlobali.Log(proxy + " -> (" + token + ") [" + gid + "] MassV2X => Parsing Guild " + gid + "..");
				ImpostazioniGlobali.Log(proxy + " -> (" + token + ") [" + gid + "] MassV2X => Getting channels...");
				string URL_channels = "https://discord.com/api/v9/guilds/" + gid + "/channels";
				HttpRequestMessage val = new HttpRequestMessage
				{
					RequestUri = new Uri(URL_channels),
					Method = HttpMethod.Get
				};
				((HttpHeaders)val.Headers).Add("Authorization", token);
				((HttpHeaders)val.Headers).Add("Accept-Language", "it");
				((HttpHeaders)val.Headers).Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36");
				((HttpHeaders)val.Headers).Add("X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9");
				((HttpHeaders)val.Headers).Add("Accept", "*/*");
				((HttpHeaders)val.Headers).Add("Cookie", "locale=it");
				((HttpHeaders)val.Headers).Add("Connection", "keep-alive");
				((HttpHeaders)val.Headers).Add("Host", "discord.com");
				((HttpHeaders)val.Headers).Add("Referer", "https://discord.com/channels/@me");
				HttpRequestMessage requestChannels = val;
				string respGLChannels = await (await http.SendAsync(requestChannels)).Content.ReadAsStringAsync();
				JArray obArr = JArray.Parse(respGLChannels);
				JObject[] jObjects = ((JToken)obArr).ToObject<JObject[]>();
				JObject[] array = jObjects;
				foreach (dynamic objsch in array)
				{
					if (!((objsch.type == 0) ? true : false))
					{
						continue;
					}
					new Thread((ParameterizedThreadStart)async delegate
					{
						try
						{
							ImpostazioniGlobali.Log(proxy + " -> (" + token + ") [" + gid + "] MassV2X => Got #" + objsch.name + " with ID " + objsch.id);
							string messageGetURL = "https://discord.com/api/v9/channels/" + objsch.id + "/messages?limit=50";
							HttpRequestMessage val2 = new HttpRequestMessage
							{
								RequestUri = new Uri(messageGetURL),
								Method = HttpMethod.Get
							};
							((HttpHeaders)val2.Headers).Add("Authorization", token);
							((HttpHeaders)val2.Headers).Add("Accept-Language", "it");
							((HttpHeaders)val2.Headers).Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36");
							((HttpHeaders)val2.Headers).Add("X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9");
							((HttpHeaders)val2.Headers).Add("Accept", "*/*");
							((HttpHeaders)val2.Headers).Add("Cookie", "locale=it");
							((HttpHeaders)val2.Headers).Add("Origin", "https://discord.com");
							((HttpHeaders)val2.Headers).Add("Referer", "https://discord.com/channels/@me");
							HttpRequestMessage requestMessages = val2;
							string respCHMessages = await (await http.SendAsync(requestMessages)).Content.ReadAsStringAsync();
							if (!(respCHMessages == "[]"))
							{
								JArray messagesArr = JArray.Parse(respCHMessages);
								JObject[] jMObjects = ((JToken)messagesArr).ToObject<JObject[]>();
								JObject[] array2 = jMObjects;
								foreach (dynamic objMsgCH in array2)
								{
									ImpostazioniGlobali._bridgeGS(1, 1, objMsgCH.author.id);
								}
								dynamic __lastMsg = jMObjects[jMObjects.Length - 1];
								long __lastId = __lastMsg.id;
								string beforeURL = "https://discord.com/api/v9/channels/" + objsch.id + "/messages?before=" + __lastId + "&limit=50";
								HttpRequestMessage val3 = new HttpRequestMessage
								{
									RequestUri = new Uri(beforeURL),
									Method = HttpMethod.Get
								};
								((HttpHeaders)val3.Headers).Add("Authorization", token);
								((HttpHeaders)val3.Headers).Add("Accept-Language", "it");
								((HttpHeaders)val3.Headers).Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/1.0.9001 Chrome/88.0.4105.134 Electron/9.3.5 Safari/537.36");
								((HttpHeaders)val3.Headers).Add("X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6Iml0IiwiY2xpZW50X2J1aWxkX251bWJlciI6ODIxMTcsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9");
								((HttpHeaders)val3.Headers).Add("Accept", "*/*");
								((HttpHeaders)val3.Headers).Add("Cookie", "locale=it");
								((HttpHeaders)val3.Headers).Add("Referer", "https://discord.com/channels/@me");
								HttpRequestMessage requestMessagesBefore = val3;
								string respCHMessages2 = await (await http.SendAsync(requestMessagesBefore)).Content.ReadAsStringAsync();
								if (!(respCHMessages2 == "[]"))
								{
									JArray.Parse(respCHMessages2);
									JObject[] jMObjects2 = ((JToken)messagesArr).ToObject<JObject[]>();
									JObject[] array3 = jMObjects2;
									foreach (dynamic objMsgCH2 in array3)
									{
										ImpostazioniGlobali._bridgeGS(1, 1, objMsgCH2.author.id);
									}
									ImpostazioniGlobali.Log(proxy + " -> (" + token + ") [" + gid + "] MassV2X => #" + objsch.name + " {" + objsch.id + "} has been successfully parsed!");
									requestChannels = null;
									http = null;
									handler = null;
									token = null;
									proxy = null;
									jObjects = null;
									obArr = null;
									respGLChannels = null;
									URL_channels = null;
									jm = null;
									guildobj = null;
									try
									{
										Thread.CurrentThread.Interrupt();
									}
									catch
									{
									}
								}
							}
						}
						catch (Exception ex)
						{
							Exception err = ex;
							if (err.Message == "Error reading JArray from JsonReader. Current JsonReader item is not an array: StartObject. Path '', line 1, position 1." || err.Message.StartsWith("Error reading JArray from JsonReader. Current JsonReader"))
							{
								ImpostazioniGlobali.Log(proxy + " -> (" + token + ") [" + gid + "] MassV2X => Il canale #" + objsch.name + " with ID " + objsch.id + " è privato e peranto è stato skippato!");
							}
							else
							{
								ImpostazioniGlobali.Log(proxy + " -> (" + token + ") [" + gid + "] MassV2X => An error has occurred with channel #" + objsch.name + " with ID " + objsch.id + ": " + err.Message);
							}
						}
					}).Start();
				}
				return;
			}
			throw new Exception("Invalid join response");
		}
		catch (Exception ex2)
		{
			ImpostazioniGlobali.Log("MassV2X => Errore durante il parsing: " + ex2.Message);
		}
	}

	private void GuildManager_Load(object sender, EventArgs e)
	{
		ImpostazioniGlobali._bridgeLogPerform.Add(delegate(int a, int b, object[] i)
		{
			if (a == 0)
			{
				try
				{
					((TextBox)channelId).Text = (string)i[0];
				}
				catch (Exception)
				{
				}
			}
		});
	}

	private void hasPCM_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void xsmodeTypeEnable_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void xsmodeTypeEnable_Click(object sender, EventArgs e)
	{
		xsmodeTypeEnable.Checked = true;
	}

	private void mbvfbypass_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void hasEmbed_CheckedChanged(object sender, EventArgs e)
	{
		if (hasCaptchaSVX.Checked && ImpostazioniGlobali.CaptchaKey_TWO == "")
		{
			hasCaptchaSVX.Checked = false;
			MessageBox.Show("Devi prima importare una Captcha Key");
		}
	}

	private void del_Click(object sender, EventArgs e)
	{
	}

	private void siticoneTextBox1_TextChanged(object sender, EventArgs e)
	{
	}

	private void siticoneCustomCheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		ImpostazioniGlobali.AutoParse = siticoneCustomCheckBox1.Checked;
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
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
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
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlackSpammerXS.GuildManager));
		this.label1 = new System.Windows.Forms.Label();
		this.siticoneDragControl1 = new SiticoneDragControl(this.components);
		this.channelId = new SiticoneTextBox();
		this.startBtn = new SiticoneButton();
		this.siticoneButton1 = new SiticoneButton();
		this.sliderDelay = new SiticoneSlider();
		this.hasDelay = new SiticoneToggleSwitch();
		this.del = new System.Windows.Forms.Label();
		this.label9 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.hasCaptchaSVX = new SiticoneCustomCheckBox();
		this.hasPCM = new SiticoneCustomCheckBox();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.xsmodeTypeEnable = new SiticoneToggleSwitch();
		this.label4 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.mbvfbypass = new SiticoneCustomCheckBox();
		this.siticoneTextBox1 = new SiticoneTextBox();
		this.siticoneTextBox2 = new SiticoneTextBox();
		this.label2 = new System.Windows.Forms.Label();
		this.siticoneCustomCheckBox1 = new SiticoneCustomCheckBox();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Inter", 15.75f, System.Drawing.FontStyle.Bold);
		this.label1.Location = new System.Drawing.Point(13, 40);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(162, 25);
		this.label1.TabIndex = 1;
		this.label1.Text = "Guild Manager";
		this.siticoneDragControl1.TargetControl = this;
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
		this.channelId.FillColor = System.Drawing.Color.Snow;
		this.channelId.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.channelId.FocusedState.Parent = (TextBox)(object)this.channelId;
		((TextBox)this.channelId).Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		((TextBox)this.channelId).ForeColor = System.Drawing.Color.Black;
		this.channelId.HoveredState.BorderColor = System.Drawing.Color.FromArgb(213, 218, 223);
		this.channelId.HoveredState.Parent = (TextBox)(object)this.channelId;
		((System.Windows.Forms.Control)(object)this.channelId).Location = new System.Drawing.Point(24, 205);
		((System.Windows.Forms.Control)(object)this.channelId).Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		((System.Windows.Forms.Control)(object)this.channelId).Name = "channelId";
		((TextBox)this.channelId).PasswordChar = '\0';
		this.channelId.PlaceholderText = "Invite Link or Server ID";
		((TextBox)this.channelId).SelectedText = "";
		this.channelId.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.channelId;
		((System.Windows.Forms.Control)(object)this.channelId).Size = new System.Drawing.Size(658, 41);
		((System.Windows.Forms.Control)(object)this.channelId).TabIndex = 35;
		((System.Windows.Forms.Control)(object)this.startBtn).BackColor = System.Drawing.Color.Transparent;
		this.startBtn.BorderColor = System.Drawing.Color.LightGray;
		this.startBtn.BorderRadius = 4;
		this.startBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
		this.startBtn.BorderThickness = 1;
		this.startBtn.CheckedState.Parent = (CustomButtonBase)(object)this.startBtn;
		((System.Windows.Forms.Control)(object)this.startBtn).Cursor = System.Windows.Forms.Cursors.Hand;
		this.startBtn.CustomImages.Parent = (CustomButtonBase)(object)this.startBtn;
		this.startBtn.FillColor = System.Drawing.Color.Snow;
		((System.Windows.Forms.Control)(object)this.startBtn).Font = new System.Drawing.Font("Inter", 9.749999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.startBtn).ForeColor = System.Drawing.Color.Black;
		this.startBtn.HoveredState.Parent = (CustomButtonBase)(object)this.startBtn;
		((System.Windows.Forms.Control)(object)this.startBtn).Location = new System.Drawing.Point(18, 502);
		((System.Windows.Forms.Control)(object)this.startBtn).Name = "startBtn";
		this.startBtn.PressedColor = System.Drawing.Color.White;
		this.startBtn.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.startBtn;
		((System.Windows.Forms.Control)(object)this.startBtn).Size = new System.Drawing.Size(326, 32);
		((System.Windows.Forms.Control)(object)this.startBtn).TabIndex = 38;
		((System.Windows.Forms.Control)(object)this.startBtn).Text = "Leave";
		this.startBtn.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.startBtn).Click += new System.EventHandler(startBtn_Click);
		((System.Windows.Forms.Control)(object)this.startBtn).MouseEnter += new System.EventHandler(siticoneButton1_MouseEnter);
		((System.Windows.Forms.Control)(object)this.startBtn).MouseLeave += new System.EventHandler(siticoneButton1_MouseLeave);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).BackColor = System.Drawing.Color.Transparent;
		this.siticoneButton1.BorderColor = System.Drawing.Color.LightGray;
		this.siticoneButton1.BorderRadius = 4;
		this.siticoneButton1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
		this.siticoneButton1.BorderThickness = 1;
		this.siticoneButton1.CheckedState.Parent = (CustomButtonBase)(object)this.siticoneButton1;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneButton1.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneButton1;
		this.siticoneButton1.FillColor = System.Drawing.Color.Snow;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Font = new System.Drawing.Font("Inter", 9.749999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).ForeColor = System.Drawing.Color.Black;
		this.siticoneButton1.HoveredState.Parent = (CustomButtonBase)(object)this.siticoneButton1;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Location = new System.Drawing.Point(350, 502);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Name = "siticoneButton1";
		this.siticoneButton1.PressedColor = System.Drawing.Color.White;
		this.siticoneButton1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneButton1;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Size = new System.Drawing.Size(332, 32);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).TabIndex = 39;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Text = "Join";
		this.siticoneButton1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Click += new System.EventHandler(siticoneButton1_Click);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).MouseEnter += new System.EventHandler(siticoneButton1_MouseEnter);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).MouseLeave += new System.EventHandler(siticoneButton1_MouseLeave);
		((System.Windows.Forms.Control)(object)this.sliderDelay).Cursor = System.Windows.Forms.Cursors.Hand;
		this.sliderDelay.LargeChange = 5;
		((System.Windows.Forms.Control)(object)this.sliderDelay).Location = new System.Drawing.Point(24, 431);
		((System.Windows.Forms.Control)(object)this.sliderDelay).Name = "sliderDelay";
		((System.Windows.Forms.Control)(object)this.sliderDelay).Size = new System.Drawing.Size(641, 60);
		((System.Windows.Forms.Control)(object)this.sliderDelay).TabIndex = 51;
		this.sliderDelay.Scroll += new System.EventHandler(sliderThreads_Scroll);
		this.hasDelay.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasDelay.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasDelay.CheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.hasDelay.CheckedState.InnerColor = System.Drawing.Color.White;
		this.hasDelay.CheckedState.Parent = (ToggleSwitch)(object)this.hasDelay;
		((System.Windows.Forms.Control)(object)this.hasDelay).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.hasDelay).Location = new System.Drawing.Point(529, 345);
		((System.Windows.Forms.Control)(object)this.hasDelay).Name = "hasDelay";
		this.hasDelay.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.hasDelay;
		((System.Windows.Forms.Control)(object)this.hasDelay).Size = new System.Drawing.Size(32, 20);
		((System.Windows.Forms.Control)(object)this.hasDelay).TabIndex = 50;
		this.hasDelay.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasDelay.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasDelay.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.hasDelay.UncheckedState.InnerColor = System.Drawing.Color.White;
		this.hasDelay.UncheckedState.Parent = (ToggleSwitch)(object)this.hasDelay;
		this.del.AutoSize = true;
		this.del.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold);
		this.del.Location = new System.Drawing.Point(566, 348);
		this.del.Name = "del";
		this.del.Size = new System.Drawing.Size(90, 14);
		this.del.TabIndex = 49;
		this.del.Text = "Delay: 200ms";
		this.del.Click += new System.EventHandler(del_Click);
		this.label9.AutoSize = true;
		this.label9.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold);
		this.label9.Location = new System.Drawing.Point(43, 347);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(139, 14);
		this.label9.TabIndex = 48;
		this.label9.Text = "Private Channel Mode";
		this.label8.AutoSize = true;
		this.label8.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold);
		this.label8.Location = new System.Drawing.Point(43, 385);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(95, 14);
		this.label8.TabIndex = 47;
		this.label8.Text = "Captcha SBVX";
		((System.Windows.Forms.Control)(object)this.hasCaptchaSVX).BackColor = System.Drawing.Color.Transparent;
		this.hasCaptchaSVX.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasCaptchaSVX.CheckedState.BorderRadius = 2;
		this.hasCaptchaSVX.CheckedState.BorderThickness = 0;
		this.hasCaptchaSVX.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasCaptchaSVX.CheckedState.Parent = (CustomCheckBox)(object)this.hasCaptchaSVX;
		((System.Windows.Forms.Control)(object)this.hasCaptchaSVX).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.hasCaptchaSVX).Location = new System.Drawing.Point(25, 385);
		((System.Windows.Forms.Control)(object)this.hasCaptchaSVX).Name = "hasCaptchaSVX";
		this.hasCaptchaSVX.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.hasCaptchaSVX;
		((System.Windows.Forms.Control)(object)this.hasCaptchaSVX).Size = new System.Drawing.Size(15, 15);
		((System.Windows.Forms.Control)(object)this.hasCaptchaSVX).TabIndex = 46;
		this.hasCaptchaSVX.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasCaptchaSVX.UncheckedState.BorderRadius = 2;
		this.hasCaptchaSVX.UncheckedState.BorderThickness = 0;
		this.hasCaptchaSVX.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasCaptchaSVX.UncheckedState.Parent = (CustomCheckBox)(object)this.hasCaptchaSVX;
		((CustomCheckBox)this.hasCaptchaSVX).CheckedChanged += new System.EventHandler(hasEmbed_CheckedChanged);
		this.hasPCM.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasPCM.CheckedState.BorderRadius = 2;
		this.hasPCM.CheckedState.BorderThickness = 0;
		this.hasPCM.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasPCM.CheckedState.Parent = (CustomCheckBox)(object)this.hasPCM;
		((System.Windows.Forms.Control)(object)this.hasPCM).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.hasPCM).Location = new System.Drawing.Point(25, 347);
		((System.Windows.Forms.Control)(object)this.hasPCM).Name = "hasPCM";
		this.hasPCM.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.hasPCM;
		((System.Windows.Forms.Control)(object)this.hasPCM).Size = new System.Drawing.Size(15, 15);
		((System.Windows.Forms.Control)(object)this.hasPCM).TabIndex = 45;
		this.hasPCM.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasPCM.UncheckedState.BorderRadius = 2;
		this.hasPCM.UncheckedState.BorderThickness = 0;
		this.hasPCM.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasPCM.UncheckedState.Parent = (CustomCheckBox)(object)this.hasPCM;
		((CustomCheckBox)this.hasPCM).CheckedChanged += new System.EventHandler(hasPCM_CheckedChanged);
		((System.Windows.Forms.Control)(object)this.hasPCM).Click += new System.EventHandler(hasLive_Click);
		this.pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
		this.pictureBox2.Location = new System.Drawing.Point(655, 37);
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.Size = new System.Drawing.Size(35, 23);
		this.pictureBox2.TabIndex = 68;
		this.pictureBox2.TabStop = false;
		this.xsmodeTypeEnable.Checked = true;
		this.xsmodeTypeEnable.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.xsmodeTypeEnable.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.xsmodeTypeEnable.CheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.xsmodeTypeEnable.CheckedState.InnerColor = System.Drawing.Color.White;
		this.xsmodeTypeEnable.CheckedState.Parent = (ToggleSwitch)(object)this.xsmodeTypeEnable;
		((System.Windows.Forms.Control)(object)this.xsmodeTypeEnable).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.xsmodeTypeEnable).Location = new System.Drawing.Point(594, 112);
		((System.Windows.Forms.Control)(object)this.xsmodeTypeEnable).Name = "xsmodeTypeEnable";
		this.xsmodeTypeEnable.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.xsmodeTypeEnable;
		((System.Windows.Forms.Control)(object)this.xsmodeTypeEnable).Size = new System.Drawing.Size(32, 20);
		((System.Windows.Forms.Control)(object)this.xsmodeTypeEnable).TabIndex = 74;
		this.xsmodeTypeEnable.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.xsmodeTypeEnable.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.xsmodeTypeEnable.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
		this.xsmodeTypeEnable.UncheckedState.InnerColor = System.Drawing.Color.White;
		this.xsmodeTypeEnable.UncheckedState.Parent = (ToggleSwitch)(object)this.xsmodeTypeEnable;
		((ToggleSwitch)this.xsmodeTypeEnable).CheckedChanged += new System.EventHandler(xsmodeTypeEnable_CheckedChanged);
		((System.Windows.Forms.Control)(object)this.xsmodeTypeEnable).Click += new System.EventHandler(xsmodeTypeEnable_Click);
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.Location = new System.Drawing.Point(631, 115);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(44, 14);
		this.label4.TabIndex = 73;
		this.label4.Text = "XS V4";
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.ForeColor = System.Drawing.Color.Teal;
		this.label3.Location = new System.Drawing.Point(23, 85);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(345, 60);
		this.label3.TabIndex = 72;
		this.label3.Text = "The join method has been updated and now supports\r\ncontent encoding and decoding.\r\nPatch: Works with the latest discord security patch\r\nImproved MB Verification Bypass.";
		this.label5.AutoSize = true;
		this.label5.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label5.Location = new System.Drawing.Point(43, 366);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(144, 14);
		this.label5.TabIndex = 76;
		this.label5.Text = "Bypass MB Verification";
		((System.Windows.Forms.Control)(object)this.mbvfbypass).BackColor = System.Drawing.Color.Transparent;
		this.mbvfbypass.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.mbvfbypass.CheckedState.BorderRadius = 2;
		this.mbvfbypass.CheckedState.BorderThickness = 0;
		this.mbvfbypass.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.mbvfbypass.CheckedState.Parent = (CustomCheckBox)(object)this.mbvfbypass;
		((System.Windows.Forms.Control)(object)this.mbvfbypass).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.mbvfbypass).Location = new System.Drawing.Point(25, 366);
		((System.Windows.Forms.Control)(object)this.mbvfbypass).Name = "mbvfbypass";
		this.mbvfbypass.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.mbvfbypass;
		((System.Windows.Forms.Control)(object)this.mbvfbypass).Size = new System.Drawing.Size(15, 15);
		((System.Windows.Forms.Control)(object)this.mbvfbypass).TabIndex = 75;
		this.mbvfbypass.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.mbvfbypass.UncheckedState.BorderRadius = 2;
		this.mbvfbypass.UncheckedState.BorderThickness = 0;
		this.mbvfbypass.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.mbvfbypass.UncheckedState.Parent = (CustomCheckBox)(object)this.mbvfbypass;
		((CustomCheckBox)this.mbvfbypass).CheckedChanged += new System.EventHandler(mbvfbypass_CheckedChanged);
		this.siticoneTextBox1.Animated = false;
		((System.Windows.Forms.Control)(object)this.siticoneTextBox1).BackColor = System.Drawing.Color.Transparent;
		this.siticoneTextBox1.BorderRadius = 4;
		this.siticoneTextBox1.BorderThickness = 2;
		((System.Windows.Forms.Control)(object)this.siticoneTextBox1).Cursor = System.Windows.Forms.Cursors.IBeam;
		((TextBox)this.siticoneTextBox1).DefaultText = "";
		this.siticoneTextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		this.siticoneTextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		this.siticoneTextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.siticoneTextBox1.DisabledState.Parent = (TextBox)(object)this.siticoneTextBox1;
		this.siticoneTextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.siticoneTextBox1.FillColor = System.Drawing.Color.Snow;
		this.siticoneTextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.siticoneTextBox1.FocusedState.Parent = (TextBox)(object)this.siticoneTextBox1;
		((TextBox)this.siticoneTextBox1).Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		((TextBox)this.siticoneTextBox1).ForeColor = System.Drawing.Color.Black;
		this.siticoneTextBox1.HoveredState.BorderColor = System.Drawing.Color.FromArgb(213, 218, 223);
		this.siticoneTextBox1.HoveredState.Parent = (TextBox)(object)this.siticoneTextBox1;
		((System.Windows.Forms.Control)(object)this.siticoneTextBox1).Location = new System.Drawing.Point(24, 161);
		((System.Windows.Forms.Control)(object)this.siticoneTextBox1).Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		((System.Windows.Forms.Control)(object)this.siticoneTextBox1).Name = "siticoneTextBox1";
		((TextBox)this.siticoneTextBox1).PasswordChar = '\0';
		this.siticoneTextBox1.PlaceholderText = "Captcha Bot ID*";
		((TextBox)this.siticoneTextBox1).SelectedText = "";
		this.siticoneTextBox1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneTextBox1;
		((System.Windows.Forms.Control)(object)this.siticoneTextBox1).Size = new System.Drawing.Size(658, 38);
		((System.Windows.Forms.Control)(object)this.siticoneTextBox1).TabIndex = 77;
		((TextBox)this.siticoneTextBox1).TextChanged += new System.EventHandler(siticoneTextBox1_TextChanged);
		this.siticoneTextBox2.Animated = false;
		((System.Windows.Forms.Control)(object)this.siticoneTextBox2).BackColor = System.Drawing.Color.Transparent;
		this.siticoneTextBox2.BorderRadius = 4;
		this.siticoneTextBox2.BorderThickness = 2;
		((System.Windows.Forms.Control)(object)this.siticoneTextBox2).Cursor = System.Windows.Forms.Cursors.IBeam;
		((TextBox)this.siticoneTextBox2).DefaultText = "";
		this.siticoneTextBox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		this.siticoneTextBox2.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		this.siticoneTextBox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.siticoneTextBox2.DisabledState.Parent = (TextBox)(object)this.siticoneTextBox2;
		this.siticoneTextBox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.siticoneTextBox2.FillColor = System.Drawing.Color.Snow;
		this.siticoneTextBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.siticoneTextBox2.FocusedState.Parent = (TextBox)(object)this.siticoneTextBox2;
		((TextBox)this.siticoneTextBox2).Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		((TextBox)this.siticoneTextBox2).ForeColor = System.Drawing.Color.Black;
		this.siticoneTextBox2.HoveredState.BorderColor = System.Drawing.Color.FromArgb(213, 218, 223);
		this.siticoneTextBox2.HoveredState.Parent = (TextBox)(object)this.siticoneTextBox2;
		((System.Windows.Forms.Control)(object)this.siticoneTextBox2).Location = new System.Drawing.Point(24, 252);
		((System.Windows.Forms.Control)(object)this.siticoneTextBox2).Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		((System.Windows.Forms.Control)(object)this.siticoneTextBox2).Name = "siticoneTextBox2";
		((TextBox)this.siticoneTextBox2).PasswordChar = '\0';
		this.siticoneTextBox2.PlaceholderText = "Guild ID (XCP)*";
		((TextBox)this.siticoneTextBox2).SelectedText = "";
		this.siticoneTextBox2.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneTextBox2;
		((System.Windows.Forms.Control)(object)this.siticoneTextBox2).Size = new System.Drawing.Size(658, 38);
		((System.Windows.Forms.Control)(object)this.siticoneTextBox2).TabIndex = 78;
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold);
		this.label2.Location = new System.Drawing.Point(43, 328);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(85, 14);
		this.label2.TabIndex = 80;
		this.label2.Text = "Auto Parsing";
		((System.Windows.Forms.Control)(object)this.siticoneCustomCheckBox1).BackColor = System.Drawing.Color.Transparent;
		this.siticoneCustomCheckBox1.Checked = true;
		this.siticoneCustomCheckBox1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.siticoneCustomCheckBox1.CheckedState.BorderRadius = 2;
		this.siticoneCustomCheckBox1.CheckedState.BorderThickness = 0;
		this.siticoneCustomCheckBox1.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.siticoneCustomCheckBox1.CheckedState.Parent = (CustomCheckBox)(object)this.siticoneCustomCheckBox1;
		this.siticoneCustomCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
		((System.Windows.Forms.Control)(object)this.siticoneCustomCheckBox1).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.siticoneCustomCheckBox1).Location = new System.Drawing.Point(25, 328);
		((System.Windows.Forms.Control)(object)this.siticoneCustomCheckBox1).Name = "siticoneCustomCheckBox1";
		this.siticoneCustomCheckBox1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneCustomCheckBox1;
		((System.Windows.Forms.Control)(object)this.siticoneCustomCheckBox1).Size = new System.Drawing.Size(15, 15);
		((System.Windows.Forms.Control)(object)this.siticoneCustomCheckBox1).TabIndex = 79;
		this.siticoneCustomCheckBox1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.siticoneCustomCheckBox1.UncheckedState.BorderRadius = 2;
		this.siticoneCustomCheckBox1.UncheckedState.BorderThickness = 0;
		this.siticoneCustomCheckBox1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.siticoneCustomCheckBox1.UncheckedState.Parent = (CustomCheckBox)(object)this.siticoneCustomCheckBox1;
		((CustomCheckBox)this.siticoneCustomCheckBox1).CheckedChanged += new System.EventHandler(siticoneCustomCheckBox1_CheckedChanged);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.Controls.Add(this.label2);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneCustomCheckBox1);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneTextBox2);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneTextBox1);
		base.Controls.Add(this.label5);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.mbvfbypass);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.xsmodeTypeEnable);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.pictureBox2);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.sliderDelay);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.hasDelay);
		base.Controls.Add(this.del);
		base.Controls.Add(this.label9);
		base.Controls.Add(this.label8);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.hasCaptchaSVX);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.hasPCM);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneButton1);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.startBtn);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.channelId);
		base.Controls.Add(this.label1);
		base.Name = "GuildManager";
		base.Size = new System.Drawing.Size(700, 546);
		base.Load += new System.EventHandler(GuildManager_Load);
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
