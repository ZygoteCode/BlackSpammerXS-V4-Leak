using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BlackSpammerXS
{
	// Token: 0x0200009D RID: 157
	public class TwoCaptchaHandler
	{
		// Token: 0x060002AA RID: 682 RVA: 0x00033314 File Offset: 0x00031514
		public TwoCaptchaHandler(string key)
		{
			this.capKey = key;
		}

		// Token: 0x060002AB RID: 683 RVA: 0x00033330 File Offset: 0x00031530
		public async Task<string> ResolveImageCaptcha(string discordURL)
		{
			string base64__ = "";
			using (WebClient webClient = new WebClient())
			{
				byte[] data = webClient.DownloadData(discordURL);
				using (MemoryStream mem = new MemoryStream(data))
				{
					using (Image.FromStream(mem))
					{
						byte[] imageBytes = mem.ToArray();
						base64__ = Convert.ToBase64String(imageBytes);
						imageBytes = null;
					}
					Image image = null;
				}
				MemoryStream mem = null;
				data = null;
			}
			WebClient webClient = null;
			string text = await this.SolveCaptchaImage(base64__);
			string cap = text;
			text = null;
			return cap;
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0003337C File Offset: 0x0003157C
		private async Task<string> SolveCaptchaImage(string base64)
		{
			string requestUriString = "http://2captcha.com/in.php";
			string idd = "";
			Dictionary<string, string> values = new Dictionary<string, string>
			{
				{
					"key",
					this.capKey ?? ""
				},
				{ "method", "base64" },
				{ "regsense", "1" },
				{
					"body",
					base64 ?? ""
				}
			};
			FormUrlEncodedContent content = new FormUrlEncodedContent(values);
			HttpClient httpv = new HttpClient();
			HttpResponseMessage httpResponseMessage = await httpv.PostAsync(requestUriString, content);
			string text2 = await httpResponseMessage.Content.ReadAsStringAsync();
			httpResponseMessage = null;
			string text = text2;
			text2 = null;
			bool flag = text.Length < 3;
			string text3;
			if (flag)
			{
				text3 = "ERROR";
			}
			else
			{
				bool flag2 = text.Contains("OK");
				if (flag2)
				{
					string str = text.Replace("OK|", "");
					idd = str;
					str = null;
					string rs = "";
					bool resolved = false;
					while (!resolved)
					{
						Thread.Sleep(150);
						if (!resolved)
						{
							string text4 = await this.Resolve(idd);
							string strx = text4;
							text4 = null;
							if (strx != "" && strx != "ERROR")
							{
								rs = strx;
								resolved = true;
								break;
							}
							if (strx == "ERROR")
							{
								rs = strx;
								resolved = true;
								break;
							}
							strx = null;
						}
					}
					text3 = rs;
				}
				else
				{
					text3 = "ERROR";
				}
			}
			return text3;
		}

		// Token: 0x060002AD RID: 685 RVA: 0x000333C8 File Offset: 0x000315C8
		private async Task<string> Resolve(string idd)
		{
			string text;
			try
			{
				string web = new HttpClient().GetAsync("https://2captcha.com/res.php?key=" + this.capKey + "&action=get&id=" + idd).Result.Content.ReadAsStringAsync().Result;
				bool flag = web.Contains("OK|");
				if (flag)
				{
					text = web.Replace("OK|", "");
				}
				else
				{
					bool flag2 = web.Contains("ERROR");
					if (flag2)
					{
						text = "ERROR";
					}
					else
					{
						text = "";
					}
				}
			}
			catch (Exception)
			{
				text = "";
			}
			return text;
		}

		// Token: 0x04000611 RID: 1553
		private string capKey = "";
	}
}
