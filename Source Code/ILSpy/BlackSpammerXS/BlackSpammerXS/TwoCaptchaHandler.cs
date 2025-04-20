using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BlackSpammerXS;

public class TwoCaptchaHandler
{
	private string capKey = "";

	public TwoCaptchaHandler(string key)
	{
		capKey = key;
	}

	public async Task<string> ResolveImageCaptcha(string discordURL)
	{
		string base64__ = "";
		using (WebClient webClient = new WebClient())
		{
			byte[] data = webClient.DownloadData(discordURL);
			using MemoryStream mem = new MemoryStream(data);
			using (Image.FromStream(mem))
			{
				byte[] imageBytes = mem.ToArray();
				base64__ = Convert.ToBase64String(imageBytes);
			}
		}
		return await SolveCaptchaImage(base64__);
	}

	private async Task<string> SolveCaptchaImage(string base64)
	{
		string requestUriString = "http://2captcha.com/in.php";
		Dictionary<string, string> values = new Dictionary<string, string>
		{
			{
				"key",
				capKey ?? ""
			},
			{ "method", "base64" },
			{ "regsense", "1" },
			{
				"body",
				base64 ?? ""
			}
		};
		FormUrlEncodedContent content = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)values);
		HttpClient httpv = new HttpClient();
		string text = await (await httpv.PostAsync(requestUriString, (HttpContent)(object)content)).Content.ReadAsStringAsync();
		if (text.Length < 3)
		{
			return "ERROR";
		}
		if (text.Contains("OK"))
		{
			string str = text.Replace("OK|", "");
			string idd = str;
			string rs = "";
			bool resolved = false;
			while (!resolved)
			{
				Thread.Sleep(150);
				if (!resolved)
				{
					string strx = await Resolve(idd);
					if (strx != "" && strx != "ERROR")
					{
						rs = strx;
						break;
					}
					if (strx == "ERROR")
					{
						rs = strx;
						break;
					}
				}
			}
			return rs;
		}
		return "ERROR";
	}

	private async Task<string> Resolve(string idd)
	{
		try
		{
			string web = new HttpClient().GetAsync("https://2captcha.com/res.php?key=" + capKey + "&action=get&id=" + idd).Result.Content.ReadAsStringAsync().Result;
			if (web.Contains("OK|"))
			{
				return web.Replace("OK|", "");
			}
			if (web.Contains("ERROR"))
			{
				return "ERROR";
			}
			return "";
		}
		catch (Exception)
		{
			return "";
		}
	}
}
