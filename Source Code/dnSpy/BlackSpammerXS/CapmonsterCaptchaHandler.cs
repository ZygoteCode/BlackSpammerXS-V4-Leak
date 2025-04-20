using System;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json.Linq;

namespace BlackSpammerXS
{
	// Token: 0x0200002C RID: 44
	public class CapmonsterCaptchaHandler
	{
		// Token: 0x060000C3 RID: 195 RVA: 0x0000D030 File Offset: 0x0000B230
		public CapmonsterCaptchaHandler(string key)
		{
			this.capKey = key;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000D04C File Offset: 0x0000B24C
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
			string text = await this.CreateCapmonsterTask(base64__);
			string taskId = text;
			text = null;
			string text2;
			if (taskId == "0")
			{
				text2 = "ERROR";
			}
			else
			{
				bool resolved = false;
				string _cap_r = "";
				while (!resolved)
				{
					Thread.Sleep(100);
					string text3 = await this.CapmonsterResult(taskId);
					string resp = text3;
					text3 = null;
					if (resp == "ERROR")
					{
						resolved = true;
						return "ERROR";
					}
					if (resp == "COMPLETING")
					{
						resolved = false;
					}
					else if (resp.StartsWith("OK|"))
					{
						_cap_r = resp.Replace("OK|", "");
						resolved = true;
						break;
					}
					resp = null;
				}
				text2 = _cap_r;
			}
			return text2;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000D098 File Offset: 0x0000B298
		private async Task<string> CreateCapmonsterTask(string bodyPNG)
		{
			string text2;
			try
			{
				HttpClient client = new HttpClient();
				StringContent content = new StringContent(string.Concat(new string[] { "{\"clientKey\": \"", this.capKey, "__casesensitive\", \"task\": {\"type\":\"ImageToTextTask\", \"body\": \"", bodyPNG, "\"}}" }), Encoding.UTF8, "application/json");
				HttpResponseMessage httpResponseMessage = await client.PostAsync("https://api.capmonster.cloud/createTask", content);
				string text = await httpResponseMessage.Content.ReadAsStringAsync();
				httpResponseMessage = null;
				string __cp = text;
				text = null;
				object response = JObject.Parse(__cp);
				if (CapmonsterCaptchaHandler.<>o__3.<>p__2 == null)
				{
					CapmonsterCaptchaHandler.<>o__3.<>p__2 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(CapmonsterCaptchaHandler), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				Func<CallSite, object, bool> target = CapmonsterCaptchaHandler.<>o__3.<>p__2.Target;
				CallSite <>p__ = CapmonsterCaptchaHandler.<>o__3.<>p__2;
				if (CapmonsterCaptchaHandler.<>o__3.<>p__1 == null)
				{
					CapmonsterCaptchaHandler.<>o__3.<>p__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(CapmonsterCaptchaHandler), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Func<CallSite, object, int, object> target2 = CapmonsterCaptchaHandler.<>o__3.<>p__1.Target;
				CallSite <>p__2 = CapmonsterCaptchaHandler.<>o__3.<>p__1;
				if (CapmonsterCaptchaHandler.<>o__3.<>p__0 == null)
				{
					CapmonsterCaptchaHandler.<>o__3.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "taskId", typeof(CapmonsterCaptchaHandler), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				if (target(<>p__, target2(<>p__2, CapmonsterCaptchaHandler.<>o__3.<>p__0.Target(CapmonsterCaptchaHandler.<>o__3.<>p__0, response), 0)))
				{
					text2 = "0";
				}
				else
				{
					if (CapmonsterCaptchaHandler.<>o__3.<>p__5 == null)
					{
						CapmonsterCaptchaHandler.<>o__3.<>p__5 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(CapmonsterCaptchaHandler), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					Func<CallSite, object, bool> target3 = CapmonsterCaptchaHandler.<>o__3.<>p__5.Target;
					CallSite <>p__3 = CapmonsterCaptchaHandler.<>o__3.<>p__5;
					if (CapmonsterCaptchaHandler.<>o__3.<>p__4 == null)
					{
						CapmonsterCaptchaHandler.<>o__3.<>p__4 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(CapmonsterCaptchaHandler), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					Func<CallSite, object, int, object> target4 = CapmonsterCaptchaHandler.<>o__3.<>p__4.Target;
					CallSite <>p__4 = CapmonsterCaptchaHandler.<>o__3.<>p__4;
					if (CapmonsterCaptchaHandler.<>o__3.<>p__3 == null)
					{
						CapmonsterCaptchaHandler.<>o__3.<>p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "errorId", typeof(CapmonsterCaptchaHandler), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					if (target3(<>p__3, target4(<>p__4, CapmonsterCaptchaHandler.<>o__3.<>p__3.Target(CapmonsterCaptchaHandler.<>o__3.<>p__3, response), 0)))
					{
						if (CapmonsterCaptchaHandler.<>o__3.<>p__8 == null)
						{
							CapmonsterCaptchaHandler.<>o__3.<>p__8 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(CapmonsterCaptchaHandler)));
						}
						Func<CallSite, object, string> target5 = CapmonsterCaptchaHandler.<>o__3.<>p__8.Target;
						CallSite <>p__5 = CapmonsterCaptchaHandler.<>o__3.<>p__8;
						if (CapmonsterCaptchaHandler.<>o__3.<>p__7 == null)
						{
							CapmonsterCaptchaHandler.<>o__3.<>p__7 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(CapmonsterCaptchaHandler), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, string, object, object> target6 = CapmonsterCaptchaHandler.<>o__3.<>p__7.Target;
						CallSite <>p__6 = CapmonsterCaptchaHandler.<>o__3.<>p__7;
						string text3 = "";
						if (CapmonsterCaptchaHandler.<>o__3.<>p__6 == null)
						{
							CapmonsterCaptchaHandler.<>o__3.<>p__6 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "taskId", typeof(CapmonsterCaptchaHandler), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						text2 = target5(<>p__5, target6(<>p__6, text3, CapmonsterCaptchaHandler.<>o__3.<>p__6.Target(CapmonsterCaptchaHandler.<>o__3.<>p__6, response)));
					}
					else
					{
						text2 = "0";
					}
				}
			}
			catch (Exception)
			{
				text2 = "0";
			}
			return text2;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000D0E4 File Offset: 0x0000B2E4
		private async Task<string> CapmonsterResult(string taskId)
		{
			string text3;
			try
			{
				HttpClient client = new HttpClient();
				StringContent content = new StringContent(string.Concat(new string[] { "{\"clientKey\": \"", this.capKey, "\", \"taskId\":\"", taskId, "\"}" }), Encoding.UTF8, "application/json");
				HttpResponseMessage httpResponseMessage = await client.PostAsync("https://api.capmonster.cloud/getTaskResult", content);
				string text = await httpResponseMessage.Content.ReadAsStringAsync();
				httpResponseMessage = null;
				string __cp = text;
				text = null;
				object response = JObject.Parse(__cp);
				if (CapmonsterCaptchaHandler.<>o__4.<>p__12 == null)
				{
					CapmonsterCaptchaHandler.<>o__4.<>p__12 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(CapmonsterCaptchaHandler), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				Func<CallSite, object, bool> target = CapmonsterCaptchaHandler.<>o__4.<>p__12.Target;
				CallSite <>p__ = CapmonsterCaptchaHandler.<>o__4.<>p__12;
				if (CapmonsterCaptchaHandler.<>o__4.<>p__1 == null)
				{
					CapmonsterCaptchaHandler.<>o__4.<>p__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(CapmonsterCaptchaHandler), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Func<CallSite, object, string, object> target2 = CapmonsterCaptchaHandler.<>o__4.<>p__1.Target;
				CallSite <>p__2 = CapmonsterCaptchaHandler.<>o__4.<>p__1;
				if (CapmonsterCaptchaHandler.<>o__4.<>p__0 == null)
				{
					CapmonsterCaptchaHandler.<>o__4.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "status", typeof(CapmonsterCaptchaHandler), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				object obj = target2(<>p__2, CapmonsterCaptchaHandler.<>o__4.<>p__0.Target(CapmonsterCaptchaHandler.<>o__4.<>p__0, response), "ready");
				if (CapmonsterCaptchaHandler.<>o__4.<>p__6 == null)
				{
					CapmonsterCaptchaHandler.<>o__4.<>p__6 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsFalse, typeof(CapmonsterCaptchaHandler), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				object obj2;
				if (!CapmonsterCaptchaHandler.<>o__4.<>p__6.Target(CapmonsterCaptchaHandler.<>o__4.<>p__6, obj))
				{
					if (CapmonsterCaptchaHandler.<>o__4.<>p__5 == null)
					{
						CapmonsterCaptchaHandler.<>o__4.<>p__5 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, ExpressionType.And, typeof(CapmonsterCaptchaHandler), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, object, object> target3 = CapmonsterCaptchaHandler.<>o__4.<>p__5.Target;
					CallSite <>p__3 = CapmonsterCaptchaHandler.<>o__4.<>p__5;
					if (CapmonsterCaptchaHandler.<>o__4.<>p__4 == null)
					{
						CapmonsterCaptchaHandler.<>o__4.<>p__4 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof(CapmonsterCaptchaHandler), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					Func<CallSite, object, object, object> target4 = CapmonsterCaptchaHandler.<>o__4.<>p__4.Target;
					CallSite <>p__4 = CapmonsterCaptchaHandler.<>o__4.<>p__4;
					if (CapmonsterCaptchaHandler.<>o__4.<>p__3 == null)
					{
						CapmonsterCaptchaHandler.<>o__4.<>p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "text", typeof(CapmonsterCaptchaHandler), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					Func<CallSite, object, object> target5 = CapmonsterCaptchaHandler.<>o__4.<>p__3.Target;
					CallSite <>p__5 = CapmonsterCaptchaHandler.<>o__4.<>p__3;
					if (CapmonsterCaptchaHandler.<>o__4.<>p__2 == null)
					{
						CapmonsterCaptchaHandler.<>o__4.<>p__2 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "solution", typeof(CapmonsterCaptchaHandler), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					obj2 = target3(<>p__3, obj, target4(<>p__4, target5(<>p__5, CapmonsterCaptchaHandler.<>o__4.<>p__2.Target(CapmonsterCaptchaHandler.<>o__4.<>p__2, response)), null));
				}
				else
				{
					obj2 = obj;
				}
				object obj3 = obj2;
				if (CapmonsterCaptchaHandler.<>o__4.<>p__11 == null)
				{
					CapmonsterCaptchaHandler.<>o__4.<>p__11 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsFalse, typeof(CapmonsterCaptchaHandler), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				object obj4;
				if (!CapmonsterCaptchaHandler.<>o__4.<>p__11.Target(CapmonsterCaptchaHandler.<>o__4.<>p__11, obj3))
				{
					if (CapmonsterCaptchaHandler.<>o__4.<>p__10 == null)
					{
						CapmonsterCaptchaHandler.<>o__4.<>p__10 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, ExpressionType.And, typeof(CapmonsterCaptchaHandler), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, object, object> target6 = CapmonsterCaptchaHandler.<>o__4.<>p__10.Target;
					CallSite <>p__6 = CapmonsterCaptchaHandler.<>o__4.<>p__10;
					if (CapmonsterCaptchaHandler.<>o__4.<>p__9 == null)
					{
						CapmonsterCaptchaHandler.<>o__4.<>p__9 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof(CapmonsterCaptchaHandler), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					Func<CallSite, object, string, object> target7 = CapmonsterCaptchaHandler.<>o__4.<>p__9.Target;
					CallSite <>p__7 = CapmonsterCaptchaHandler.<>o__4.<>p__9;
					if (CapmonsterCaptchaHandler.<>o__4.<>p__8 == null)
					{
						CapmonsterCaptchaHandler.<>o__4.<>p__8 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "text", typeof(CapmonsterCaptchaHandler), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					Func<CallSite, object, object> target8 = CapmonsterCaptchaHandler.<>o__4.<>p__8.Target;
					CallSite <>p__8 = CapmonsterCaptchaHandler.<>o__4.<>p__8;
					if (CapmonsterCaptchaHandler.<>o__4.<>p__7 == null)
					{
						CapmonsterCaptchaHandler.<>o__4.<>p__7 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "solution", typeof(CapmonsterCaptchaHandler), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					obj4 = target6(<>p__6, obj3, target7(<>p__7, target8(<>p__8, CapmonsterCaptchaHandler.<>o__4.<>p__7.Target(CapmonsterCaptchaHandler.<>o__4.<>p__7, response)), ""));
				}
				else
				{
					obj4 = obj3;
				}
				if (target(<>p__, obj4))
				{
					if (CapmonsterCaptchaHandler.<>o__4.<>p__16 == null)
					{
						CapmonsterCaptchaHandler.<>o__4.<>p__16 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(CapmonsterCaptchaHandler)));
					}
					Func<CallSite, object, string> target9 = CapmonsterCaptchaHandler.<>o__4.<>p__16.Target;
					CallSite <>p__9 = CapmonsterCaptchaHandler.<>o__4.<>p__16;
					if (CapmonsterCaptchaHandler.<>o__4.<>p__15 == null)
					{
						CapmonsterCaptchaHandler.<>o__4.<>p__15 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(CapmonsterCaptchaHandler), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, string, object, object> target10 = CapmonsterCaptchaHandler.<>o__4.<>p__15.Target;
					CallSite <>p__10 = CapmonsterCaptchaHandler.<>o__4.<>p__15;
					string text2 = "OK|";
					if (CapmonsterCaptchaHandler.<>o__4.<>p__14 == null)
					{
						CapmonsterCaptchaHandler.<>o__4.<>p__14 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "text", typeof(CapmonsterCaptchaHandler), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					Func<CallSite, object, object> target11 = CapmonsterCaptchaHandler.<>o__4.<>p__14.Target;
					CallSite <>p__11 = CapmonsterCaptchaHandler.<>o__4.<>p__14;
					if (CapmonsterCaptchaHandler.<>o__4.<>p__13 == null)
					{
						CapmonsterCaptchaHandler.<>o__4.<>p__13 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "solution", typeof(CapmonsterCaptchaHandler), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					text3 = target9(<>p__9, target10(<>p__10, text2, target11(<>p__11, CapmonsterCaptchaHandler.<>o__4.<>p__13.Target(CapmonsterCaptchaHandler.<>o__4.<>p__13, response))));
				}
				else
				{
					text3 = "COMPLETING";
				}
			}
			catch (Exception)
			{
				text3 = "ERROR";
			}
			return text3;
		}

		// Token: 0x0400015B RID: 347
		private string capKey = "";
	}
}
