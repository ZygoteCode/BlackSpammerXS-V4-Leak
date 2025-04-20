using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json.Linq;
using Websocket.Client;
using Websocket.Client.Models;

namespace BlackSpammerXS
{
	// Token: 0x02000022 RID: 34
	public class BlackWSManager
	{
		// Token: 0x06000098 RID: 152 RVA: 0x0000A824 File Offset: 0x00008A24
		public BlackWSManager(string token, string proxy)
		{
			this.token = token;
			this.proxy = proxy;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000A8D4 File Offset: 0x00008AD4
		public BlackWSManager(string token, string proxy, bool logging, string version = "9")
		{
			this.token = token;
			this.proxy = proxy;
			this.Logging = logging;
			this.WS_CON_AT += version;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000A9A0 File Offset: 0x00008BA0
		public void voice_connect(string server_id, string channel_id)
		{
			this.queued_serv_id = server_id;
			this.queued_channel_id = channel_id;
			this.ATTM_CONNECT_V = true;
			try
			{
				bool logging = this.Logging;
				if (logging)
				{
					ImpostazioniGlobali.Log(string.Concat(new string[] { this.proxy, " -> (", this.token, ") Websocket => Voice:: Connecting to ", server_id, ":", channel_id }));
				}
				this.ws.Send(string.Concat(new string[] { "{\"op\": 4, \"d\": {\"guild_id\": \"", server_id, "\", \"channel_id\": \"", channel_id, "\", \"self_mute\": true, \"self_deaf\": true}}" }));
			}
			catch
			{
				ImpostazioniGlobali.Log(this.proxy + " -> (" + this.token + ") Websocket => Voice:: Impossibile connettersi al canale vocale: 0x001");
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000AA84 File Offset: 0x00008C84
		public void voice_disconnect()
		{
			try
			{
				try
				{
					this.voice_ws.Stop(WebSocketCloseStatus.NormalClosure, "User disconnected");
				}
				catch
				{
				}
				this.voice_ws.Dispose();
				this.voice_ws = null;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0000AAEC File Offset: 0x00008CEC
		public void set_parsing(bool p)
		{
			this.parsing = p;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000AAF8 File Offset: 0x00008CF8
		public string GetUserID()
		{
			return this.user_id;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000AB10 File Offset: 0x00008D10
		public void connect()
		{
			this.scTh = new Thread(delegate(object p)
			{
				try
				{
					Func<ClientWebSocket> func = () => new ClientWebSocket
					{
						Options = 
						{
							KeepAliveInterval = TimeSpan.FromSeconds(5.0),
							Proxy = new WebProxy(this.proxy)
						}
					};
					this.ws = new WebsocketClient(new Uri(this.WS_CON_AT), func);
					this.ws.ReconnectTimeout = new TimeSpan?(TimeSpan.FromMinutes(10.0));
					ObservableExtensions.Subscribe<ReconnectionInfo>(this.ws.ReconnectionHappened, delegate(ReconnectionInfo i)
					{
						bool logging = this.Logging;
						if (logging)
						{
							ImpostazioniGlobali.Log(string.Concat(new string[]
							{
								this.proxy,
								" -> (",
								this.token,
								") Websocket => Disconnected 0x00 :: status_crt?reconnecting :: type=",
								i.Type.ToString()
							}));
						}
					});
					ObservableExtensions.Subscribe<DisconnectionInfo>(this.ws.DisconnectionHappened, delegate(DisconnectionInfo i)
					{
						bool flag = i.CloseStatusDescription.StartsWith("Authentication failed");
						if (flag)
						{
							try
							{
								this.disconnect();
							}
							catch (Exception)
							{
							}
						}
						bool logging2 = this.Logging;
						if (logging2)
						{
							ImpostazioniGlobali.Log(string.Concat(new string[]
							{
								this.proxy,
								" -> (",
								this.token,
								") Websocket => Disconnected 0x01 :: type=",
								i.Type.ToString(),
								"&close_status=",
								i.CloseStatus.ToString(),
								"&close_status_descr=",
								i.CloseStatusDescription,
								"&prev_protocol=",
								i.SubProtocol
							}));
						}
					});
					this.ws.MessageEncoding = Encoding.UTF8;
					ObservableExtensions.Subscribe<ResponseMessage>(this.ws.MessageReceived, delegate(ResponseMessage msg)
					{
						this.handle_ws_message(msg);
					});
					this.ws.Start();
				}
				catch (Exception ex)
				{
					try
					{
						string readableDateNow = ImpostazioniGlobali.GetReadableDateNow();
						int num = 91734;
						string text = "WS_MBL";
						string text2 = "WEBSOCKET_CONNECT_FAIL";
						string[] array = new string[]
						{
							"METHOD:CONNECT?URL_AT" + this.WS_CON_AT,
							"T_" + ImpostazioniGlobali.Tokens.Count.ToString() + "_P_" + ImpostazioniGlobali.Proxies.Count.ToString(),
							"hPRX__" + this.proxy,
							"hTKN__" + this.token
						};
						string text3 = "WS_con_ERR::connect?";
						Exception ex2 = ex;
						JObject jobject = ImpostazioniGlobali.CreateDebugAction(num, text, text2, array, text3 + ((ex2 != null) ? ex2.ToString() : null), readableDateNow);
						ImpostazioniGlobali.Debug_DPut(jobject);
					}
					catch (Exception)
					{
					}
					ImpostazioniGlobali.Log(this.proxy + " -> (" + this.token + ") Websocket => Cannot connect to websocket. Please check developer debug. ACT_ID=91734");
				}
			});
			this.scTh.Start();
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000AB38 File Offset: 0x00008D38
		private void start_ack_handling(int interval)
		{
			this.hb_thr = new Thread(delegate(object z)
			{
				try
				{
					while (this.hb_thr.IsAlive && this.is_connected())
					{
						bool logging = this.Logging;
						if (logging)
						{
							ImpostazioniGlobali.Log(string.Concat(new string[]
							{
								this.proxy,
								" -> (",
								this.token,
								") Websocket => Heartbeating.. (intrv=",
								interval.ToString(),
								")"
							}));
						}
						try
						{
							this.ws.Send("{\"op\": 1, \"d\": null}");
						}
						catch (Exception ex)
						{
							bool logging2 = this.Logging;
							if (logging2)
							{
								string[] array = new string[5];
								array[0] = this.proxy;
								array[1] = " -> (";
								array[2] = this.token;
								array[3] = ") Websocket => Cannot handle heartbeating. Error: ";
								int num = 4;
								Exception ex2 = ex;
								array[num] = ((ex2 != null) ? ex2.ToString() : null);
								ImpostazioniGlobali.Log(string.Concat(array));
							}
						}
						Thread.Sleep(interval);
					}
				}
				catch
				{
				}
			});
			this.hb_thr.Start();
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000AB80 File Offset: 0x00008D80
		public void disconnect()
		{
			bool logging = this.Logging;
			if (logging)
			{
				ImpostazioniGlobali.Log(this.proxy + " -> (" + this.token + ") Websocket => Handling disconnection (call=disconnect)...");
			}
			try
			{
				try
				{
					this.ws.Stop(WebSocketCloseStatus.NormalClosure, "User disconnect");
				}
				catch
				{
				}
				try
				{
					this.voice_disconnect();
				}
				catch
				{
				}
				this.ws.Dispose();
				bool isAlive = this.hb_thr.IsAlive;
				if (isAlive)
				{
					this.hb_thr.Interrupt();
				}
				bool isAlive2 = this.scTh.IsAlive;
				if (isAlive2)
				{
					this.scTh.Interrupt();
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000AC60 File Offset: 0x00008E60
		private void identify()
		{
			try
			{
				this.ws.Send("{\"op\": 2, \"d\": {\"token\": \"" + this.token + "\", \"properties\": {\"$os\": \"Windows\", \"$browser\": \"Google Chrome\", \"$device\": \"desktop\"}, \"presence\": {\"activites\": [{\"name\": \"Zasch\", \"type\": 0}]}, \"status\": \"online\", \"afk\": false}}");
				this.__INTERNAL_STATE = 1;
				bool logging = this.Logging;
				if (logging)
				{
					ImpostazioniGlobali.Log(this.proxy + " -> (" + this.token + ") Websocket => Identify payload sent. Awaiting ready status.");
				}
			}
			catch (Exception ex)
			{
				string[] array = new string[5];
				array[0] = this.proxy;
				array[1] = " -> (";
				array[2] = this.token;
				array[3] = ") Websocket => Cannot handle heartbeating. Error: ";
				int num = 4;
				Exception ex2 = ex;
				array[num] = ((ex2 != null) ? ex2.ToString() : null);
				ImpostazioniGlobali.Log(string.Concat(array));
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000AD20 File Offset: 0x00008F20
		private void h_ready(string ready_payload)
		{
			bool flag = this.__INTERNAL_STATE != 1;
			if (flag)
			{
				ImpostazioniGlobali.Log(this.proxy + " -> (" + this.token + ") Websocket => Unknown Error :: Cannot handle a READY payload while INTERNAL_STATE is not 1. The payload has already been sent.");
			}
			else
			{
				this.__INTERNAL_STATE = 2;
				ImpostazioniGlobali.Log(this.proxy + " -> (" + this.token + ") Websocket => READY");
				try
				{
					object obj = JObject.Parse(ready_payload);
					if (BlackWSManager.<>o__31.<>p__0 == null)
					{
						BlackWSManager.<>o__31.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "d", typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					object obj2 = BlackWSManager.<>o__31.<>p__0.Target(BlackWSManager.<>o__31.<>p__0, obj);
					if (BlackWSManager.<>o__31.<>p__2 == null)
					{
						BlackWSManager.<>o__31.<>p__2 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(BlackWSManager)));
					}
					Func<CallSite, object, string> target = BlackWSManager.<>o__31.<>p__2.Target;
					CallSite <>p__ = BlackWSManager.<>o__31.<>p__2;
					if (BlackWSManager.<>o__31.<>p__1 == null)
					{
						BlackWSManager.<>o__31.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "t", typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					string text = target(<>p__, BlackWSManager.<>o__31.<>p__1.Target(BlackWSManager.<>o__31.<>p__1, obj));
					bool flag2 = text != "READY";
					if (flag2)
					{
						ImpostazioniGlobali.Log(this.proxy + " -> (" + this.token + ") Websocket => The received payload is not a READY payload. Error -0xe81");
					}
					else
					{
						bool logging = this.Logging;
						if (logging)
						{
							ImpostazioniGlobali.Log(this.proxy + " -> (" + this.token + ") Websocket => Extracting session id and user id..");
						}
						if (BlackWSManager.<>o__31.<>p__4 == null)
						{
							BlackWSManager.<>o__31.<>p__4 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(BlackWSManager)));
						}
						Func<CallSite, object, string> target2 = BlackWSManager.<>o__31.<>p__4.Target;
						CallSite <>p__2 = BlackWSManager.<>o__31.<>p__4;
						if (BlackWSManager.<>o__31.<>p__3 == null)
						{
							BlackWSManager.<>o__31.<>p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "session_id", typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						this.session_id = target2(<>p__2, BlackWSManager.<>o__31.<>p__3.Target(BlackWSManager.<>o__31.<>p__3, obj2));
						if (BlackWSManager.<>o__31.<>p__7 == null)
						{
							BlackWSManager.<>o__31.<>p__7 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(BlackWSManager)));
						}
						Func<CallSite, object, string> target3 = BlackWSManager.<>o__31.<>p__7.Target;
						CallSite <>p__3 = BlackWSManager.<>o__31.<>p__7;
						if (BlackWSManager.<>o__31.<>p__6 == null)
						{
							BlackWSManager.<>o__31.<>p__6 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, object> target4 = BlackWSManager.<>o__31.<>p__6.Target;
						CallSite <>p__4 = BlackWSManager.<>o__31.<>p__6;
						if (BlackWSManager.<>o__31.<>p__5 == null)
						{
							BlackWSManager.<>o__31.<>p__5 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "user", typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						this.user_id = target3(<>p__3, target4(<>p__4, BlackWSManager.<>o__31.<>p__5.Target(BlackWSManager.<>o__31.<>p__5, obj2)));
						bool logging2 = this.Logging;
						if (logging2)
						{
							ImpostazioniGlobali.Log(string.Concat(new string[] { this.proxy, " -> (", this.token, ") Websocket => Session ID: ", this.session_id }));
						}
						bool logging3 = this.Logging;
						if (logging3)
						{
							ImpostazioniGlobali.Log(string.Concat(new string[] { this.proxy, " -> (", this.token, ") Websocket => User ID: ", this.user_id }));
						}
						bool flag3 = this.parsing;
						if (flag3)
						{
							bool logging4 = this.Logging;
							if (logging4)
							{
								ImpostazioniGlobali.Log(this.proxy + " -> (" + this.token + ") Websocket => Parsing guilds..");
							}
							if (BlackWSManager.<>o__31.<>p__8 == null)
							{
								BlackWSManager.<>o__31.<>p__8 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "guilds", typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
							}
							object obj3 = BlackWSManager.<>o__31.<>p__8.Target(BlackWSManager.<>o__31.<>p__8, obj2);
							if (BlackWSManager.<>o__31.<>p__27 == null)
							{
								BlackWSManager.<>o__31.<>p__27 = CallSite<Func<CallSite, object, IEnumerable>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(IEnumerable), typeof(BlackWSManager)));
							}
							foreach (object obj4 in BlackWSManager.<>o__31.<>p__27.Target(BlackWSManager.<>o__31.<>p__27, obj3))
							{
								if (BlackWSManager.<>o__31.<>p__10 == null)
								{
									BlackWSManager.<>o__31.<>p__10 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(BlackWSManager)));
								}
								Func<CallSite, object, string> target5 = BlackWSManager.<>o__31.<>p__10.Target;
								CallSite <>p__5 = BlackWSManager.<>o__31.<>p__10;
								if (BlackWSManager.<>o__31.<>p__9 == null)
								{
									BlackWSManager.<>o__31.<>p__9 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
								}
								string text2 = target5(<>p__5, BlackWSManager.<>o__31.<>p__9.Target(BlackWSManager.<>o__31.<>p__9, obj4));
								List<GChannel> list = new List<GChannel>();
								GuildChannels guildChannels = new GuildChannels(text2, list);
								if (BlackWSManager.<>o__31.<>p__11 == null)
								{
									BlackWSManager.<>o__31.<>p__11 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "channels", typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
								}
								object obj5 = BlackWSManager.<>o__31.<>p__11.Target(BlackWSManager.<>o__31.<>p__11, obj4);
								if (BlackWSManager.<>o__31.<>p__26 == null)
								{
									BlackWSManager.<>o__31.<>p__26 = CallSite<Func<CallSite, object, IEnumerable>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(IEnumerable), typeof(BlackWSManager)));
								}
								foreach (object obj6 in BlackWSManager.<>o__31.<>p__26.Target(BlackWSManager.<>o__31.<>p__26, obj5))
								{
									if (BlackWSManager.<>o__31.<>p__13 == null)
									{
										BlackWSManager.<>o__31.<>p__13 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(BlackWSManager)));
									}
									Func<CallSite, object, string> target6 = BlackWSManager.<>o__31.<>p__13.Target;
									CallSite <>p__6 = BlackWSManager.<>o__31.<>p__13;
									if (BlackWSManager.<>o__31.<>p__12 == null)
									{
										BlackWSManager.<>o__31.<>p__12 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "name", typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
									}
									string text3 = target6(<>p__6, BlackWSManager.<>o__31.<>p__12.Target(BlackWSManager.<>o__31.<>p__12, obj6));
									if (BlackWSManager.<>o__31.<>p__15 == null)
									{
										BlackWSManager.<>o__31.<>p__15 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(int), typeof(BlackWSManager)));
									}
									Func<CallSite, object, int> target7 = BlackWSManager.<>o__31.<>p__15.Target;
									CallSite <>p__7 = BlackWSManager.<>o__31.<>p__15;
									if (BlackWSManager.<>o__31.<>p__14 == null)
									{
										BlackWSManager.<>o__31.<>p__14 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "type", typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
									}
									bool flag4;
									if (target7(<>p__7, BlackWSManager.<>o__31.<>p__14.Target(BlackWSManager.<>o__31.<>p__14, obj6)) != 2)
									{
										if (BlackWSManager.<>o__31.<>p__17 == null)
										{
											BlackWSManager.<>o__31.<>p__17 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(int), typeof(BlackWSManager)));
										}
										Func<CallSite, object, int> target8 = BlackWSManager.<>o__31.<>p__17.Target;
										CallSite <>p__8 = BlackWSManager.<>o__31.<>p__17;
										if (BlackWSManager.<>o__31.<>p__16 == null)
										{
											BlackWSManager.<>o__31.<>p__16 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "type", typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
										}
										flag4 = target8(<>p__8, BlackWSManager.<>o__31.<>p__16.Target(BlackWSManager.<>o__31.<>p__16, obj6)) == 0;
									}
									else
									{
										flag4 = true;
									}
									bool flag5 = flag4;
									if (flag5)
									{
										string text4 = text3;
										if (BlackWSManager.<>o__31.<>p__19 == null)
										{
											BlackWSManager.<>o__31.<>p__19 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string), typeof(BlackWSManager)));
										}
										Func<CallSite, object, string> target9 = BlackWSManager.<>o__31.<>p__19.Target;
										CallSite <>p__9 = BlackWSManager.<>o__31.<>p__19;
										if (BlackWSManager.<>o__31.<>p__18 == null)
										{
											BlackWSManager.<>o__31.<>p__18 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
										}
										string text5 = target9(<>p__9, BlackWSManager.<>o__31.<>p__18.Target(BlackWSManager.<>o__31.<>p__18, obj6));
										if (BlackWSManager.<>o__31.<>p__22 == null)
										{
											BlackWSManager.<>o__31.<>p__22 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
										}
										Func<CallSite, object, bool> target10 = BlackWSManager.<>o__31.<>p__22.Target;
										CallSite <>p__10 = BlackWSManager.<>o__31.<>p__22;
										if (BlackWSManager.<>o__31.<>p__21 == null)
										{
											BlackWSManager.<>o__31.<>p__21 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(BlackWSManager), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
											}));
										}
										Func<CallSite, object, int, object> target11 = BlackWSManager.<>o__31.<>p__21.Target;
										CallSite <>p__11 = BlackWSManager.<>o__31.<>p__21;
										if (BlackWSManager.<>o__31.<>p__20 == null)
										{
											BlackWSManager.<>o__31.<>p__20 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "type", typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
										}
										ChannelType channelType;
										if (!target10(<>p__10, target11(<>p__11, BlackWSManager.<>o__31.<>p__20.Target(BlackWSManager.<>o__31.<>p__20, obj6), 0)))
										{
											if (BlackWSManager.<>o__31.<>p__25 == null)
											{
												BlackWSManager.<>o__31.<>p__25 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
											}
											Func<CallSite, object, bool> target12 = BlackWSManager.<>o__31.<>p__25.Target;
											CallSite <>p__12 = BlackWSManager.<>o__31.<>p__25;
											if (BlackWSManager.<>o__31.<>p__24 == null)
											{
												BlackWSManager.<>o__31.<>p__24 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(BlackWSManager), new CSharpArgumentInfo[]
												{
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
												}));
											}
											Func<CallSite, object, int, object> target13 = BlackWSManager.<>o__31.<>p__24.Target;
											CallSite <>p__13 = BlackWSManager.<>o__31.<>p__24;
											if (BlackWSManager.<>o__31.<>p__23 == null)
											{
												BlackWSManager.<>o__31.<>p__23 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "type", typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
											}
											channelType = (target12(<>p__12, target13(<>p__13, BlackWSManager.<>o__31.<>p__23.Target(BlackWSManager.<>o__31.<>p__23, obj6), 2)) ? ChannelType.VOCALE : ChannelType.TESTUALE);
										}
										else
										{
											channelType = ChannelType.TESTUALE;
										}
										GChannel gchannel = new GChannel(text4, text5, channelType);
										list.Add(gchannel);
									}
								}
								this.gc.Add(guildChannels);
							}
							bool logging5 = this.Logging;
							if (logging5)
							{
								ImpostazioniGlobali.Log(this.proxy + " -> (" + this.token + ") Websocket => Successfully Parsed.");
							}
						}
						bool logging6 = this.Logging;
						if (logging6)
						{
							ImpostazioniGlobali.Log(this.proxy + " -> (" + this.token + ") Websocket => Internal State: CONNECTED and HANDLED. [SUCCESS]");
						}
					}
				}
				catch (Exception)
				{
					ImpostazioniGlobali.Log(this.proxy + " -> (" + this.token + ") Websocket => Unable to decode READY payload.");
					this.disconnect();
				}
			}
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000B88C File Offset: 0x00009A8C
		public async Task<bool> WaitForData(int timeout = 10000)
		{
			bool d_result = false;
			int d = 0;
			while (d != timeout)
			{
				bool flag = this.DataRAvaliable();
				if (flag)
				{
					d_result = true;
					break;
				}
				int num = d;
				d = num + 1;
				Thread.Sleep(1);
			}
			return d_result;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000B8D8 File Offset: 0x00009AD8
		private bool abs_g_c_t()
		{
			bool flag = !this.parsing;
			return flag || this.gc.Count != 0;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000B90C File Offset: 0x00009B0C
		public bool DataRAvaliable()
		{
			return this.session_id != "" && this.abs_g_c_t();
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000B93C File Offset: 0x00009B3C
		public List<GuildChannels> GetGuilds()
		{
			return this.gc;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000B954 File Offset: 0x00009B54
		private void h_voice_state_u(string r)
		{
			try
			{
				object obj = JObject.Parse(r);
				if (BlackWSManager.<>o__36.<>p__0 == null)
				{
					BlackWSManager.<>o__36.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "d", typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				object obj2 = BlackWSManager.<>o__36.<>p__0.Target(BlackWSManager.<>o__36.<>p__0, obj);
				if (BlackWSManager.<>o__36.<>p__2 == null)
				{
					BlackWSManager.<>o__36.<>p__2 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(BlackWSManager)));
				}
				Func<CallSite, object, string> target = BlackWSManager.<>o__36.<>p__2.Target;
				CallSite <>p__ = BlackWSManager.<>o__36.<>p__2;
				if (BlackWSManager.<>o__36.<>p__1 == null)
				{
					BlackWSManager.<>o__36.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "channel_id", typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				string text = target(<>p__, BlackWSManager.<>o__36.<>p__1.Target(BlackWSManager.<>o__36.<>p__1, obj2));
				if (BlackWSManager.<>o__36.<>p__4 == null)
				{
					BlackWSManager.<>o__36.<>p__4 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(BlackWSManager)));
				}
				Func<CallSite, object, string> target2 = BlackWSManager.<>o__36.<>p__4.Target;
				CallSite <>p__2 = BlackWSManager.<>o__36.<>p__4;
				if (BlackWSManager.<>o__36.<>p__3 == null)
				{
					BlackWSManager.<>o__36.<>p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "user_id", typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				string text2 = target2(<>p__2, BlackWSManager.<>o__36.<>p__3.Target(BlackWSManager.<>o__36.<>p__3, obj2));
				bool flag = text != this.queued_channel_id && text2 != this.user_id;
				if (flag)
				{
					bool logging = this.Logging;
					if (logging)
					{
						ImpostazioniGlobali.Log(string.Concat(new string[] { this.proxy, " -> (", this.token, ") Websocket => Another user (", text, ") changed his state. Payload: ", r }));
					}
				}
				else
				{
					bool logging2 = this.Logging;
					if (logging2)
					{
						ImpostazioniGlobali.Log(this.proxy + " -> (" + this.token + ") Websocket => VOICE_STATE_UPDATE Payload (f_r=true)");
					}
					if (BlackWSManager.<>o__36.<>p__6 == null)
					{
						BlackWSManager.<>o__36.<>p__6 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(BlackWSManager)));
					}
					Func<CallSite, object, string> target3 = BlackWSManager.<>o__36.<>p__6.Target;
					CallSite <>p__3 = BlackWSManager.<>o__36.<>p__6;
					if (BlackWSManager.<>o__36.<>p__5 == null)
					{
						BlackWSManager.<>o__36.<>p__5 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "session_id", typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					string text3 = target3(<>p__3, BlackWSManager.<>o__36.<>p__5.Target(BlackWSManager.<>o__36.<>p__5, obj2));
					bool logging3 = this.Logging;
					if (logging3)
					{
						ImpostazioniGlobali.Log(string.Concat(new string[] { this.proxy, " -> (", this.token, ") Websocket => Voice Session ID were updated to ", text3 }));
					}
					this.voice_session_id = text3;
					this.v_cr_voice_state_update = true;
					this.voice_next();
				}
			}
			catch
			{
				ImpostazioniGlobali.Log(this.proxy + " -> (" + this.token + ") Websocket => An error has occurred while handling h_voice_state_u.");
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000BCAC File Offset: 0x00009EAC
		private void h_voice_server_u(string r)
		{
			try
			{
				object obj = JObject.Parse(r);
				if (BlackWSManager.<>o__37.<>p__0 == null)
				{
					BlackWSManager.<>o__37.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "d", typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				object obj2 = BlackWSManager.<>o__37.<>p__0.Target(BlackWSManager.<>o__37.<>p__0, obj);
				if (BlackWSManager.<>o__37.<>p__2 == null)
				{
					BlackWSManager.<>o__37.<>p__2 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(BlackWSManager)));
				}
				Func<CallSite, object, string> target = BlackWSManager.<>o__37.<>p__2.Target;
				CallSite <>p__ = BlackWSManager.<>o__37.<>p__2;
				if (BlackWSManager.<>o__37.<>p__1 == null)
				{
					BlackWSManager.<>o__37.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "token", typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				string text = target(<>p__, BlackWSManager.<>o__37.<>p__1.Target(BlackWSManager.<>o__37.<>p__1, obj2));
				if (BlackWSManager.<>o__37.<>p__5 == null)
				{
					BlackWSManager.<>o__37.<>p__5 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(BlackWSManager)));
				}
				Func<CallSite, object, string> target2 = BlackWSManager.<>o__37.<>p__5.Target;
				CallSite <>p__2 = BlackWSManager.<>o__37.<>p__5;
				if (BlackWSManager.<>o__37.<>p__4 == null)
				{
					BlackWSManager.<>o__37.<>p__4 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(BlackWSManager), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, string, object, object> target3 = BlackWSManager.<>o__37.<>p__4.Target;
				CallSite <>p__3 = BlackWSManager.<>o__37.<>p__4;
				string text2 = "wss://";
				if (BlackWSManager.<>o__37.<>p__3 == null)
				{
					BlackWSManager.<>o__37.<>p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "endpoint", typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				string text3 = target2(<>p__2, target3(<>p__3, text2, BlackWSManager.<>o__37.<>p__3.Target(BlackWSManager.<>o__37.<>p__3, obj2)));
				this.VOICE_URL = text3;
				this.voice_token = text;
				this.v_cr_voice_server_update = true;
				this.voice_next();
			}
			catch
			{
				ImpostazioniGlobali.Log(this.proxy + " -> (" + this.token + ") Websocket => An error has occurred while handling h_voice_server_u.");
			}
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000BEE8 File Offset: 0x0000A0E8
		private void voice_next()
		{
			bool logging = this.Logging;
			if (logging)
			{
				ImpostazioniGlobali.Log(string.Concat(new string[]
				{
					this.proxy,
					" -> (",
					this.token,
					") Websocket => h_s? voice_next() called wh (attm=",
					this.ATTM_CONNECT_V.ToString(),
					",v_cr_v_srv_u=",
					this.v_cr_voice_server_update.ToString(),
					",v_cr_v_st_u=",
					this.v_cr_voice_state_update.ToString(),
					")"
				}));
			}
			bool flag = !this.ATTM_CONNECT_V || !this.v_cr_voice_server_update || !this.v_cr_voice_state_update;
			if (!flag)
			{
				bool logging2 = this.Logging;
				if (logging2)
				{
					ImpostazioniGlobali.Log(this.proxy + " -> (" + this.token + ") Websocket => Handling voice_next() in a new thread when avaliable..");
				}
				Task.Run(delegate
				{
					try
					{
						Func<ClientWebSocket> func = () => new ClientWebSocket
						{
							Options = 
							{
								KeepAliveInterval = TimeSpan.FromSeconds(5.0),
								Proxy = new WebProxy(this.proxy)
							}
						};
						this.voice_ws = new WebsocketClient(new Uri(this.VOICE_URL), func);
						this.voice_ws.ReconnectTimeout = new TimeSpan?(TimeSpan.FromMinutes(3.0));
						ObservableExtensions.Subscribe<ReconnectionInfo>(this.voice_ws.ReconnectionHappened, delegate(ReconnectionInfo i)
						{
						});
						ObservableExtensions.Subscribe<DisconnectionInfo>(this.voice_ws.DisconnectionHappened, delegate(DisconnectionInfo i)
						{
							bool logging4 = this.Logging;
							if (logging4)
							{
								ImpostazioniGlobali.Log(string.Concat(new string[]
								{
									this.proxy,
									" -> (",
									this.token,
									") Websocket => VOICE::Disconnected type=",
									i.Type.ToString(),
									"&close_status=",
									i.CloseStatus.ToString(),
									"&close_status_descr=",
									i.CloseStatusDescription,
									"&prev_protocol=",
									i.SubProtocol
								}));
							}
						});
						this.voice_ws.MessageEncoding = Encoding.UTF8;
						ObservableExtensions.Subscribe<ResponseMessage>(this.voice_ws.MessageReceived, delegate(ResponseMessage msg)
						{
							bool logging5 = this.Logging;
							if (logging5)
							{
								ImpostazioniGlobali.Log(string.Concat(new string[] { this.proxy, " -> (", this.token, ") Websocket => VOICE::MessageReceived msg=", msg.Text }));
							}
							try
							{
								bool flag2 = msg.Text.Replace(" ", "").StartsWith("{\"op\":2,");
								if (flag2)
								{
									ImpostazioniGlobali.Log(this.proxy + " -> (" + this.token + ") WS Voice Spammer => Successfully joined. READY.");
								}
							}
							catch (Exception)
							{
							}
						});
						this.voice_ws.Start();
						string text = string.Concat(new string[] { "{\"op\":0,\"d\":{\"server_id\":\"", this.queued_serv_id, "\",\"user_id\":\"", this.user_id, "\",\"session_id\":\"", this.voice_session_id, "\",\"token\":\"", this.voice_token, "\",\"video\":true,\"streams\":[{\"type\":\"video\",\"rid\":\"100\",\"quality\":100}]}}" });
						this.voice_ws.Send(text);
					}
					catch (Exception ex)
					{
						string[] array = new string[5];
						array[0] = this.proxy;
						array[1] = " -> (";
						array[2] = this.token;
						array[3] = ") Websocket => VOICE::An error has occurred: ";
						int num = 4;
						Exception ex2 = ex;
						array[num] = ((ex2 != null) ? ex2.ToString() : null);
						ImpostazioniGlobali.Log(string.Concat(array));
					}
					try
					{
						bool logging3 = this.Logging;
						if (logging3)
						{
							ImpostazioniGlobali.Log(this.proxy + " -> (" + this.token + ") Websocket => Disposing in 5 seconds..");
						}
						Thread.Sleep(5000);
						this.voice_ws.Dispose();
						this.voice_ws = null;
					}
					catch (Exception)
					{
						this.voice_ws = null;
					}
					this.ATTM_CONNECT_V = false;
					this.v_cr_voice_server_update = false;
					this.v_cr_voice_state_update = false;
				});
			}
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000BFD8 File Offset: 0x0000A1D8
		private void handle_ws_message(ResponseMessage responseMessage)
		{
			Task.Run(delegate
			{
				try
				{
					bool logging = this.Logging;
					if (logging)
					{
						ImpostazioniGlobali.Log(string.Concat(new string[]
						{
							this.proxy,
							" -> (",
							this.token,
							") Websocket => Received message (typeof ",
							responseMessage.MessageType.ToString(),
							") with ",
							responseMessage.Text
						}));
					}
					object obj = JObject.Parse(responseMessage.Text);
					if (BlackWSManager.<>o__39.<>p__1 == null)
					{
						BlackWSManager.<>o__39.<>p__1 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(int), typeof(BlackWSManager)));
					}
					Func<CallSite, object, int> target = BlackWSManager.<>o__39.<>p__1.Target;
					CallSite <>p__ = BlackWSManager.<>o__39.<>p__1;
					if (BlackWSManager.<>o__39.<>p__0 == null)
					{
						BlackWSManager.<>o__39.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "op", typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					int num = target(<>p__, BlackWSManager.<>o__39.<>p__0.Target(BlackWSManager.<>o__39.<>p__0, obj));
					bool flag = num == 10;
					if (flag)
					{
						if (BlackWSManager.<>o__39.<>p__2 == null)
						{
							BlackWSManager.<>o__39.<>p__2 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "d", typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						object obj2 = BlackWSManager.<>o__39.<>p__2.Target(BlackWSManager.<>o__39.<>p__2, obj);
						if (BlackWSManager.<>o__39.<>p__4 == null)
						{
							BlackWSManager.<>o__39.<>p__4 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(int), typeof(BlackWSManager)));
						}
						Func<CallSite, object, int> target2 = BlackWSManager.<>o__39.<>p__4.Target;
						CallSite <>p__2 = BlackWSManager.<>o__39.<>p__4;
						if (BlackWSManager.<>o__39.<>p__3 == null)
						{
							BlackWSManager.<>o__39.<>p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "heartbeat_interval", typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						int num2 = target2(<>p__2, BlackWSManager.<>o__39.<>p__3.Target(BlackWSManager.<>o__39.<>p__3, obj2));
						this.start_ack_handling(num2);
						bool logging2 = this.Logging;
						if (logging2)
						{
							string[] array = new string[5];
							array[0] = this.proxy;
							array[1] = " -> (";
							array[2] = this.token;
							array[3] = ") Websocket => Handled a 10 hello payload. Heartbeat Interval: ";
							int num3 = 4;
							Thread thread = this.hb_thr;
							array[num3] = ((thread != null) ? thread.ToString() : null);
							ImpostazioniGlobali.Log(string.Concat(array));
						}
						ImpostazioniGlobali.Log(this.proxy + " -> (" + this.token + ") Websocket => Identifying..");
						this.identify();
					}
					else
					{
						bool flag2 = num == 11;
						if (flag2)
						{
							bool logging3 = this.Logging;
							if (logging3)
							{
								ImpostazioniGlobali.Log(this.proxy + " -> (" + this.token + ") Websocket => Heartbeating Response: Success! OP_CODE=11");
							}
						}
						else
						{
							bool flag3 = num == 0;
							if (flag3)
							{
								bool flag4 = responseMessage.Text.Contains("user") && responseMessage.Text.Contains("session_id") && responseMessage.Text.Contains("guilds") && responseMessage.Text.Contains("\"t\":\"READY\"");
								if (flag4)
								{
									ImpostazioniGlobali.Log(this.proxy + " -> (" + this.token + ") Websocket => Got a READY event payload :: Handling..");
									this.h_ready(responseMessage.Text);
								}
								else
								{
									if (BlackWSManager.<>o__39.<>p__6 == null)
									{
										BlackWSManager.<>o__39.<>p__6 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(BlackWSManager)));
									}
									Func<CallSite, object, string> target3 = BlackWSManager.<>o__39.<>p__6.Target;
									CallSite <>p__3 = BlackWSManager.<>o__39.<>p__6;
									if (BlackWSManager.<>o__39.<>p__5 == null)
									{
										BlackWSManager.<>o__39.<>p__5 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "t", typeof(BlackWSManager), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
									}
									string text = target3(<>p__3, BlackWSManager.<>o__39.<>p__5.Target(BlackWSManager.<>o__39.<>p__5, obj));
									bool flag5 = text == "VOICE_SERVER_UPDATE";
									if (flag5)
									{
										bool logging4 = this.Logging;
										if (logging4)
										{
											ImpostazioniGlobali.Log(this.proxy + " -> (" + this.token + ") Websocket => Got a VOICE_SERVER_UPDATE payload :: Handling..");
										}
										this.h_voice_server_u(responseMessage.Text);
									}
									else
									{
										bool flag6 = text == "VOICE_STATE_UPDATE";
										if (flag6)
										{
											bool logging5 = this.Logging;
											if (logging5)
											{
												ImpostazioniGlobali.Log(this.proxy + " -> (" + this.token + ") Websocket => Got a VOICE_STATE_UPDATE payload :: Handling..");
											}
											this.h_voice_state_u(responseMessage.Text);
										}
									}
								}
							}
						}
					}
				}
				catch (Exception ex)
				{
					string[] array2 = new string[5];
					array2[0] = this.proxy;
					array2[1] = " -> (";
					array2[2] = this.token;
					array2[3] = ") Websocket => Cannot handle received message: ";
					int num4 = 4;
					Exception ex2 = ex;
					array2[num4] = ((ex2 != null) ? ex2.ToString() : null);
					ImpostazioniGlobali.Log(string.Concat(array2));
				}
			});
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000C00C File Offset: 0x0000A20C
		public void send_ws_message(string msg)
		{
			try
			{
				Task.Run(delegate
				{
					try
					{
						ImpostazioniGlobali.Log(string.Concat(new string[] { this.proxy, " -> (", this.token, ") Websocket => Adding message to queue. Length: ", msg }));
						this.ws.Send(msg);
					}
					catch (Exception)
					{
						ImpostazioniGlobali.Log(this.proxy + " -> (" + this.token + ") Websocket => Unable to send message. 0x00");
					}
				});
			}
			catch (Exception)
			{
				ImpostazioniGlobali.Log(this.proxy + " -> (" + this.token + ") Websocket => Unable to send message. 0x01");
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000C07C File Offset: 0x0000A27C
		public bool is_connected()
		{
			bool flag = this.ws == null;
			bool flag2;
			if (flag)
			{
				flag2 = false;
			}
			else
			{
				bool isRunning = this.ws.IsRunning;
				flag2 = isRunning;
			}
			return flag2;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000C0B4 File Offset: 0x0000A2B4
		public WebsocketClient get_ws()
		{
			return this.ws;
		}

		// Token: 0x04000108 RID: 264
		private string WS_CON_AT = "wss://gateway.discord.gg/?encoding=json&v=";

		// Token: 0x04000109 RID: 265
		private string VOICE_URL = "wss://eu-central4734.discord.media/?v=5";

		// Token: 0x0400010A RID: 266
		private bool ATTM_CONNECT_V = false;

		// Token: 0x0400010B RID: 267
		private bool v_cr_voice_state_update = false;

		// Token: 0x0400010C RID: 268
		private bool v_cr_voice_server_update = false;

		// Token: 0x0400010D RID: 269
		public bool Logging = true;

		// Token: 0x0400010E RID: 270
		private string voice_token = "";

		// Token: 0x0400010F RID: 271
		private string voice_session_id = "";

		// Token: 0x04000110 RID: 272
		private string queued_serv_id = "";

		// Token: 0x04000111 RID: 273
		private string queued_channel_id = "";

		// Token: 0x04000112 RID: 274
		private string proxy;

		// Token: 0x04000113 RID: 275
		private string token;

		// Token: 0x04000114 RID: 276
		private WebsocketClient ws;

		// Token: 0x04000115 RID: 277
		private WebsocketClient voice_ws;

		// Token: 0x04000116 RID: 278
		private int __INTERNAL_STATE = 0;

		// Token: 0x04000117 RID: 279
		private string user_id = "";

		// Token: 0x04000118 RID: 280
		private string session_id = "";

		// Token: 0x04000119 RID: 281
		private List<GuildChannels> gc = new List<GuildChannels>();

		// Token: 0x0400011A RID: 282
		private Thread scTh;

		// Token: 0x0400011B RID: 283
		private Thread hb_thr;

		// Token: 0x0400011C RID: 284
		private bool parsing = true;
	}
}
