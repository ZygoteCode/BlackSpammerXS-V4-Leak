using System;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json.Linq;

namespace BlackSpammerXS
{
	// Token: 0x02000081 RID: 129
	internal class ContentWRX
	{
		// Token: 0x06000226 RID: 550 RVA: 0x0002867C File Offset: 0x0002687C
		public static async Task<ContentWRX> LoadContent(string cnat, int a, int uid)
		{
			ContentWRX contentWRX;
			try
			{
				try
				{
					IPAddress ip = Dns.GetHostAddresses("https://naoko.fun")[0];
					IPAddress ipAddress = ip;
					bool flag = ipAddress.ToString() != "167.99.138.41";
					if (flag)
					{
						return null;
					}
					ip = null;
					ipAddress = null;
				}
				catch (Exception ex2)
				{
					Exception ex = ex2;
					bool flag2 = !ex.ToString().Contains("0x80004005");
					if (flag2)
					{
						return null;
					}
				}
				HttpRequestMessage http = new HttpRequestMessage
				{
					RequestUri = new Uri("https://naoko.fun/api/v3/blackspammerxs/data/content/retrieve"),
					Content = new StringContent(string.Concat(new string[]
					{
						"{\"user_id\": ",
						a.ToString(),
						", \"version\": \"V416X\", \"client_id\": \"d5Jnc2V3ZzQyd3dobmlyaHJnYmluZ2prb2JxZXVidXFlZmJ1cWVmZ3VpZmd5dWZndXl2cWVjZmClDXlhcWVmZ2J5aXVhcWVmZ2J5cWVmZ2J5cWVmZ2J5cWVmZ203\", \"cnat\": \"",
						cnat,
						"\", \"crat\": ",
						a.ToString(),
						"}"
					}), Encoding.UTF8, "application/json"),
					Method = HttpMethod.Post,
					Headers = { { "Authorization", "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" } }
				};
				HttpClient client = new HttpClient();
				HttpResponseMessage httpResponseMessage = await client.SendAsync(http);
				HttpResponseMessage r = httpResponseMessage;
				httpResponseMessage = null;
				string text = await r.Content.ReadAsStringAsync();
				string b = text;
				text = null;
				object c = JObject.Parse(b);
				try
				{
					HttpResponseHeaders rhc = r.Headers;
					string signature_temp = rhc.GetValues("X-Signature").First<string>();
					if (ContentWRX.<>o__0.<>p__1 == null)
					{
						ContentWRX.<>o__0.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "validation_ut", typeof(ContentWRX), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					Func<CallSite, object, object> target = ContentWRX.<>o__0.<>p__1.Target;
					CallSite <>p__ = ContentWRX.<>o__0.<>p__1;
					if (ContentWRX.<>o__0.<>p__0 == null)
					{
						ContentWRX.<>o__0.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "payload", typeof(ContentWRX), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					object validation_utils = target(<>p__, ContentWRX.<>o__0.<>p__0.Target(ContentWRX.<>o__0.<>p__0, c));
					byte[] sign_bytes = Convert.FromBase64String(signature_temp);
					string sign_dec = Encoding.UTF8.GetString(sign_bytes);
					if (ContentWRX.<>o__0.<>p__2 == null)
					{
						ContentWRX.<>o__0.<>p__2 = CallSite<Action<CallSite, string, object, string>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Replace", null, typeof(ContentWRX), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					ContentWRX.<>o__0.<>p__2.Target(ContentWRX.<>o__0.<>p__2, sign_dec, validation_utils, "");
					if (!(sign_dec == a.ToString() + "UEA3K0JCIUBqWlYkdmVRWA"))
					{
						throw new Exception("Invalid signature");
					}
					sign_dec = null;
					sign_bytes = null;
					validation_utils = null;
					signature_temp = null;
					rhc = null;
					rhc = null;
					signature_temp = null;
					validation_utils = null;
					sign_bytes = null;
					sign_dec = null;
				}
				catch (Exception)
				{
					return null;
				}
				b = null;
				r = null;
				if (ContentWRX.<>o__0.<>p__5 == null)
				{
					ContentWRX.<>o__0.<>p__5 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(ContentWRX), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				Func<CallSite, object, bool> target2 = ContentWRX.<>o__0.<>p__5.Target;
				CallSite <>p__2 = ContentWRX.<>o__0.<>p__5;
				if (ContentWRX.<>o__0.<>p__4 == null)
				{
					ContentWRX.<>o__0.<>p__4 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(ContentWRX), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Func<CallSite, object, int, object> target3 = ContentWRX.<>o__0.<>p__4.Target;
				CallSite <>p__3 = ContentWRX.<>o__0.<>p__4;
				if (ContentWRX.<>o__0.<>p__3 == null)
				{
					ContentWRX.<>o__0.<>p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "code", typeof(ContentWRX), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				if (target2(<>p__2, target3(<>p__3, ContentWRX.<>o__0.<>p__3.Target(ContentWRX.<>o__0.<>p__3, c), 503)))
				{
					contentWRX = null;
				}
				else
				{
					if (ContentWRX.<>o__0.<>p__8 == null)
					{
						ContentWRX.<>o__0.<>p__8 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(ContentWRX), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					Func<CallSite, object, bool> target4 = ContentWRX.<>o__0.<>p__8.Target;
					CallSite <>p__4 = ContentWRX.<>o__0.<>p__8;
					if (ContentWRX.<>o__0.<>p__7 == null)
					{
						ContentWRX.<>o__0.<>p__7 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof(ContentWRX), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					Func<CallSite, object, int, object> target5 = ContentWRX.<>o__0.<>p__7.Target;
					CallSite <>p__5 = ContentWRX.<>o__0.<>p__7;
					if (ContentWRX.<>o__0.<>p__6 == null)
					{
						ContentWRX.<>o__0.<>p__6 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "code", typeof(ContentWRX), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					if (target4(<>p__4, target5(<>p__5, ContentWRX.<>o__0.<>p__6.Target(ContentWRX.<>o__0.<>p__6, c), 200)))
					{
						contentWRX = null;
					}
					else
					{
						if (ContentWRX.<>o__0.<>p__10 == null)
						{
							ContentWRX.<>o__0.<>p__10 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof(ContentWRX), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						Func<CallSite, object, object, object> target6 = ContentWRX.<>o__0.<>p__10.Target;
						CallSite <>p__6 = ContentWRX.<>o__0.<>p__10;
						if (ContentWRX.<>o__0.<>p__9 == null)
						{
							ContentWRX.<>o__0.<>p__9 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "message", typeof(ContentWRX), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						object obj = target6(<>p__6, ContentWRX.<>o__0.<>p__9.Target(ContentWRX.<>o__0.<>p__9, c), null);
						if (ContentWRX.<>o__0.<>p__15 == null)
						{
							ContentWRX.<>o__0.<>p__15 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(ContentWRX), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						bool flag3;
						if (!ContentWRX.<>o__0.<>p__15.Target(ContentWRX.<>o__0.<>p__15, obj))
						{
							if (ContentWRX.<>o__0.<>p__14 == null)
							{
								ContentWRX.<>o__0.<>p__14 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(ContentWRX), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
							}
							Func<CallSite, object, bool> target7 = ContentWRX.<>o__0.<>p__14.Target;
							CallSite <>p__7 = ContentWRX.<>o__0.<>p__14;
							if (ContentWRX.<>o__0.<>p__13 == null)
							{
								ContentWRX.<>o__0.<>p__13 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, ExpressionType.Or, typeof(ContentWRX), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							Func<CallSite, object, object, object> target8 = ContentWRX.<>o__0.<>p__13.Target;
							CallSite <>p__8 = ContentWRX.<>o__0.<>p__13;
							if (ContentWRX.<>o__0.<>p__12 == null)
							{
								ContentWRX.<>o__0.<>p__12 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof(ContentWRX), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
								}));
							}
							Func<CallSite, object, string, object> target9 = ContentWRX.<>o__0.<>p__12.Target;
							CallSite <>p__9 = ContentWRX.<>o__0.<>p__12;
							if (ContentWRX.<>o__0.<>p__11 == null)
							{
								ContentWRX.<>o__0.<>p__11 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "message", typeof(ContentWRX), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
							}
							flag3 = target7(<>p__7, target8(<>p__8, obj, target9(<>p__9, ContentWRX.<>o__0.<>p__11.Target(ContentWRX.<>o__0.<>p__11, c), "Success")));
						}
						else
						{
							flag3 = true;
						}
						if (flag3)
						{
							contentWRX = null;
						}
						else
						{
							contentWRX = null;
						}
					}
				}
			}
			catch (Exception)
			{
				contentWRX = null;
			}
			return contentWRX;
		}
	}
}
