using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BlackSpammerXS;

internal class ContentWRX
{
	public static async Task<ContentWRX> LoadContent(string cnat, int a, int uid)
	{
		try
		{
			try
			{
				IPAddress ip = Dns.GetHostAddresses("https://naoko.fun")[0];
				IPAddress ipAddress = ip;
				if (ipAddress.ToString() != "167.99.138.41")
				{
					return null;
				}
			}
			catch (Exception ex)
			{
				Exception ex2 = ex;
				if (!ex2.ToString().Contains("0x80004005"))
				{
					return null;
				}
			}
			HttpRequestMessage val = new HttpRequestMessage();
			val.RequestUri = new Uri("https://naoko.fun/api/v3/blackspammerxs/data/content/retrieve");
			val.Content = (HttpContent)new StringContent("{\"user_id\": " + a + ", \"version\": \"V416X\", \"client_id\": \"d5Jnc2V3ZzQyd3dobmlyaHJnYmluZ2prb2JxZXVidXFlZmJ1cWVmZ3VpZmd5dWZndXl2cWVjZmClDXlhcWVmZ2J5aXVhcWVmZ2J5cWVmZ2J5cWVmZ2J5cWVmZ203\", \"cnat\": \"" + cnat + "\", \"crat\": " + a + "}", Encoding.UTF8, "application/json");
			val.Method = HttpMethod.Post;
			((HttpHeaders)val.Headers).Add("Authorization", "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");
			HttpRequestMessage http = val;
			HttpClient client = new HttpClient();
			HttpResponseMessage r = await client.SendAsync(http);
			dynamic c = JObject.Parse(await r.Content.ReadAsStringAsync());
			try
			{
				HttpResponseHeaders rhc = r.Headers;
				string signature_temp = ((HttpHeaders)rhc).GetValues("X-Signature").First();
				dynamic validation_utils = c.payload.validation_ut;
				byte[] sign_bytes = Convert.FromBase64String(signature_temp);
				string sign_dec = Encoding.UTF8.GetString(sign_bytes);
				sign_dec.Replace(validation_utils, "");
				if (!(sign_dec == a + "UEA3K0JCIUBqWlYkdmVRWA"))
				{
					throw new Exception("Invalid signature");
				}
			}
			catch (Exception)
			{
				return null;
			}
			if (c.code == 503)
			{
				return null;
			}
			if (c.code != 200)
			{
				return null;
			}
			if (c.message != null || c.message != "Success")
			{
				return null;
			}
			return null;
		}
		catch (Exception)
		{
			return null;
		}
	}
}
