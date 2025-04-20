using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BlackSpammerXS;

public class CapmonsterCaptchaHandler
{
	private string capKey = "";

	public CapmonsterCaptchaHandler(string key)
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
		string taskId = await CreateCapmonsterTask(base64__);
		if (taskId == "0")
		{
			return "ERROR";
		}
		bool resolved = false;
		string _cap_r = "";
		while (!resolved)
		{
			Thread.Sleep(100);
			string resp = await CapmonsterResult(taskId);
			if (resp == "ERROR")
			{
				return "ERROR";
			}
			if (resp == "COMPLETING")
			{
				resolved = false;
			}
			else if (resp.StartsWith("OK|"))
			{
				_cap_r = resp.Replace("OK|", "");
				break;
			}
		}
		return _cap_r;
	}

	private async Task<string> CreateCapmonsterTask(string bodyPNG)
	{
		try
		{
			HttpClient client = new HttpClient();
			StringContent content = new StringContent("{\"clientKey\": \"" + capKey + "__casesensitive\", \"task\": {\"type\":\"ImageToTextTask\", \"body\": \"" + bodyPNG + "\"}}", Encoding.UTF8, "application/json");
			dynamic response = JObject.Parse(await (await client.PostAsync("https://api.capmonster.cloud/createTask", (HttpContent)(object)content)).Content.ReadAsStringAsync());
			if (response.taskId == 0)
			{
				return "0";
			}
			if (response.errorId == 0)
			{
				return "" + response.taskId;
			}
			return "0";
		}
		catch (Exception)
		{
			return "0";
		}
	}

	private async Task<string> CapmonsterResult(string taskId)
	{
		try
		{
			HttpClient client = new HttpClient();
			StringContent content = new StringContent("{\"clientKey\": \"" + capKey + "\", \"taskId\":\"" + taskId + "\"}", Encoding.UTF8, "application/json");
			dynamic response = JObject.Parse(await (await client.PostAsync("https://api.capmonster.cloud/getTaskResult", (HttpContent)(object)content)).Content.ReadAsStringAsync());
			if (response.status == "ready" && response.solution.text != null && response.solution.text != "")
			{
				return "OK|" + response.solution.text;
			}
			return "COMPLETING";
		}
		catch (Exception)
		{
			return "ERROR";
		}
	}
}
