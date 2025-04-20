using System;
using System.Collections.Generic;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Websocket.Client;
using Websocket.Client.Models;

namespace BlackSpammerXS;

public class BlackWSManager
{
	private string WS_CON_AT = "wss://gateway.discord.gg/?encoding=json&v=";

	private string VOICE_URL = "wss://eu-central4734.discord.media/?v=5";

	private bool ATTM_CONNECT_V = false;

	private bool v_cr_voice_state_update = false;

	private bool v_cr_voice_server_update = false;

	public bool Logging = true;

	private string voice_token = "";

	private string voice_session_id = "";

	private string queued_serv_id = "";

	private string queued_channel_id = "";

	private string proxy;

	private string token;

	private WebsocketClient ws;

	private WebsocketClient voice_ws;

	private int __INTERNAL_STATE = 0;

	private string user_id = "";

	private string session_id = "";

	private List<GuildChannels> gc = new List<GuildChannels>();

	private Thread scTh;

	private Thread hb_thr;

	private bool parsing = true;

	public BlackWSManager(string token, string proxy)
	{
		this.token = token;
		this.proxy = proxy;
	}

	public BlackWSManager(string token, string proxy, bool logging, string version = "9")
	{
		this.token = token;
		this.proxy = proxy;
		Logging = logging;
		WS_CON_AT += version;
	}

	public void voice_connect(string server_id, string channel_id)
	{
		queued_serv_id = server_id;
		queued_channel_id = channel_id;
		ATTM_CONNECT_V = true;
		try
		{
			if (Logging)
			{
				ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Voice:: Connecting to " + server_id + ":" + channel_id);
			}
			ws.Send("{\"op\": 4, \"d\": {\"guild_id\": \"" + server_id + "\", \"channel_id\": \"" + channel_id + "\", \"self_mute\": true, \"self_deaf\": true}}");
		}
		catch
		{
			ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Voice:: Impossibile connettersi al canale vocale: 0x001");
		}
	}

	public void voice_disconnect()
	{
		try
		{
			try
			{
				voice_ws.Stop(WebSocketCloseStatus.NormalClosure, "User disconnected");
			}
			catch
			{
			}
			voice_ws.Dispose();
			voice_ws = null;
		}
		catch (Exception)
		{
		}
	}

	public void set_parsing(bool p)
	{
		parsing = p;
	}

	public string GetUserID()
	{
		return user_id;
	}

	public void connect()
	{
		scTh = new Thread((ParameterizedThreadStart)delegate
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			try
			{
				Func<ClientWebSocket> func = delegate
				{
					ClientWebSocket clientWebSocket = new ClientWebSocket();
					clientWebSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(5.0);
					clientWebSocket.Options.Proxy = new WebProxy(proxy);
					return clientWebSocket;
				};
				ws = new WebsocketClient(new Uri(WS_CON_AT), func);
				ws.ReconnectTimeout = TimeSpan.FromMinutes(10.0);
				ObservableExtensions.Subscribe<ReconnectionInfo>(ws.ReconnectionHappened, (Action<ReconnectionInfo>)delegate(ReconnectionInfo i)
				{
					//IL_0036: Unknown result type (might be due to invalid IL or missing references)
					//IL_003b: Unknown result type (might be due to invalid IL or missing references)
					if (Logging)
					{
						string[] obj = new string[5] { proxy, " -> (", token, ") Websocket => Disconnected 0x00 :: status_crt?reconnecting :: type=", null };
						ReconnectionType type = i.Type;
						obj[4] = ((object)(ReconnectionType)(ref type)/*cast due to .constrained prefix*/).ToString();
						ImpostazioniGlobali.Log(string.Concat(obj));
					}
				});
				ObservableExtensions.Subscribe<DisconnectionInfo>(ws.DisconnectionHappened, (Action<DisconnectionInfo>)delegate(DisconnectionInfo i)
				{
					//IL_0060: Unknown result type (might be due to invalid IL or missing references)
					//IL_0065: Unknown result type (might be due to invalid IL or missing references)
					if (i.CloseStatusDescription.StartsWith("Authentication failed"))
					{
						try
						{
							disconnect();
						}
						catch (Exception)
						{
						}
					}
					if (Logging)
					{
						string[] obj2 = new string[11]
						{
							proxy, " -> (", token, ") Websocket => Disconnected 0x01 :: type=", null, null, null, null, null, null,
							null
						};
						DisconnectionType type2 = i.Type;
						obj2[4] = ((object)(DisconnectionType)(ref type2)/*cast due to .constrained prefix*/).ToString();
						obj2[5] = "&close_status=";
						obj2[6] = i.CloseStatus.ToString();
						obj2[7] = "&close_status_descr=";
						obj2[8] = i.CloseStatusDescription;
						obj2[9] = "&prev_protocol=";
						obj2[10] = i.SubProtocol;
						ImpostazioniGlobali.Log(string.Concat(obj2));
					}
				});
				ws.MessageEncoding = Encoding.UTF8;
				ObservableExtensions.Subscribe<ResponseMessage>(ws.MessageReceived, (Action<ResponseMessage>)delegate(ResponseMessage msg)
				{
					handle_ws_message(msg);
				});
				ws.Start();
			}
			catch (Exception ex2)
			{
				try
				{
					string readableDateNow = ImpostazioniGlobali.GetReadableDateNow();
					JObject jobj = ImpostazioniGlobali.CreateDebugAction(91734, "WS_MBL", "WEBSOCKET_CONNECT_FAIL", new string[4]
					{
						"METHOD:CONNECT?URL_AT" + WS_CON_AT,
						"T_" + ImpostazioniGlobali.Tokens.Count + "_P_" + ImpostazioniGlobali.Proxies.Count,
						"hPRX__" + proxy,
						"hTKN__" + token
					}, "WS_con_ERR::connect?" + ex2, readableDateNow);
					ImpostazioniGlobali.Debug_DPut(jobj);
				}
				catch (Exception)
				{
				}
				ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Cannot connect to websocket. Please check developer debug. ACT_ID=91734");
			}
		});
		scTh.Start();
	}

	private void start_ack_handling(int interval)
	{
		hb_thr = new Thread((ParameterizedThreadStart)delegate
		{
			try
			{
				while (hb_thr.IsAlive && is_connected())
				{
					if (Logging)
					{
						ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Heartbeating.. (intrv=" + interval + ")");
					}
					try
					{
						ws.Send("{\"op\": 1, \"d\": null}");
					}
					catch (Exception ex)
					{
						if (Logging)
						{
							ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Cannot handle heartbeating. Error: " + ex);
						}
					}
					Thread.Sleep(interval);
				}
			}
			catch
			{
			}
		});
		hb_thr.Start();
	}

	public void disconnect()
	{
		if (Logging)
		{
			ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Handling disconnection (call=disconnect)...");
		}
		try
		{
			try
			{
				ws.Stop(WebSocketCloseStatus.NormalClosure, "User disconnect");
			}
			catch
			{
			}
			try
			{
				voice_disconnect();
			}
			catch
			{
			}
			ws.Dispose();
			if (hb_thr.IsAlive)
			{
				hb_thr.Interrupt();
			}
			if (scTh.IsAlive)
			{
				scTh.Interrupt();
			}
		}
		catch (Exception)
		{
		}
	}

	private void identify()
	{
		try
		{
			ws.Send("{\"op\": 2, \"d\": {\"token\": \"" + token + "\", \"properties\": {\"$os\": \"Windows\", \"$browser\": \"Google Chrome\", \"$device\": \"desktop\"}, \"presence\": {\"activites\": [{\"name\": \"Zasch\", \"type\": 0}]}, \"status\": \"online\", \"afk\": false}}");
			__INTERNAL_STATE = 1;
			if (Logging)
			{
				ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Identify payload sent. Awaiting ready status.");
			}
		}
		catch (Exception ex)
		{
			ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Cannot handle heartbeating. Error: " + ex);
		}
	}

	private void h_ready(string ready_payload)
	{
		if (__INTERNAL_STATE != 1)
		{
			ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Unknown Error :: Cannot handle a READY payload while INTERNAL_STATE is not 1. The payload has already been sent.");
			return;
		}
		__INTERNAL_STATE = 2;
		ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => READY");
		try
		{
			dynamic val = JObject.Parse(ready_payload);
			dynamic val2 = val.d;
			string text = val.t;
			if (text != "READY")
			{
				ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => The received payload is not a READY payload. Error -0xe81");
				return;
			}
			if (Logging)
			{
				ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Extracting session id and user id..");
			}
			session_id = val2.session_id;
			user_id = val2.user.id;
			if (Logging)
			{
				ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Session ID: " + session_id);
			}
			if (Logging)
			{
				ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => User ID: " + user_id);
			}
			if (parsing)
			{
				if (Logging)
				{
					ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Parsing guilds..");
				}
				dynamic val3 = val2.guilds;
				foreach (dynamic item3 in val3)
				{
					string guildId = item3.id;
					List<GChannel> list = new List<GChannel>();
					GuildChannels item = new GuildChannels(guildId, list);
					dynamic val4 = item3.channels;
					foreach (dynamic item4 in val4)
					{
						string name = item4.name;
						if ((int)item4.type == 2 || (int)item4.type == 0)
						{
							GChannel item2 = new GChannel(name, (string)item4.id, (!((item4.type == 0) ? true : false)) ? ((item4.type == 2) ? ChannelType.VOCALE : ChannelType.TESTUALE) : ChannelType.TESTUALE);
							list.Add(item2);
						}
					}
					gc.Add(item);
				}
				if (Logging)
				{
					ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Successfully Parsed.");
				}
			}
			if (Logging)
			{
				ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Internal State: CONNECTED and HANDLED. [SUCCESS]");
			}
		}
		catch (Exception)
		{
			ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Unable to decode READY payload.");
			disconnect();
		}
	}

	public async Task<bool> WaitForData(int timeout = 10000)
	{
		bool d_result = false;
		int d = 0;
		while (d != timeout)
		{
			if (DataRAvaliable())
			{
				d_result = true;
				break;
			}
			d++;
			Thread.Sleep(1);
		}
		return d_result;
	}

	private bool abs_g_c_t()
	{
		if (!parsing)
		{
			return true;
		}
		return gc.Count != 0;
	}

	public bool DataRAvaliable()
	{
		return session_id != "" && abs_g_c_t();
	}

	public List<GuildChannels> GetGuilds()
	{
		return gc;
	}

	private void h_voice_state_u(string r)
	{
		try
		{
			dynamic val = JObject.Parse(r);
			dynamic val2 = val.d;
			string text = val2.channel_id;
			string text2 = val2.user_id;
			if (text != queued_channel_id && text2 != user_id)
			{
				if (Logging)
				{
					ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Another user (" + text + ") changed his state. Payload: " + r);
				}
				return;
			}
			if (Logging)
			{
				ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => VOICE_STATE_UPDATE Payload (f_r=true)");
			}
			string text3 = val2.session_id;
			if (Logging)
			{
				ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Voice Session ID were updated to " + text3);
			}
			voice_session_id = text3;
			v_cr_voice_state_update = true;
			voice_next();
		}
		catch
		{
			ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => An error has occurred while handling h_voice_state_u.");
		}
	}

	private void h_voice_server_u(string r)
	{
		try
		{
			dynamic val = JObject.Parse(r);
			dynamic val2 = val.d;
			string text = val2.token;
			string vOICE_URL = "wss://" + val2.endpoint;
			VOICE_URL = vOICE_URL;
			voice_token = text;
			v_cr_voice_server_update = true;
			voice_next();
		}
		catch
		{
			ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => An error has occurred while handling h_voice_server_u.");
		}
	}

	private void voice_next()
	{
		if (Logging)
		{
			ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => h_s? voice_next() called wh (attm=" + ATTM_CONNECT_V + ",v_cr_v_srv_u=" + v_cr_voice_server_update + ",v_cr_v_st_u=" + v_cr_voice_state_update + ")");
		}
		if (!ATTM_CONNECT_V || !v_cr_voice_server_update || !v_cr_voice_state_update)
		{
			return;
		}
		if (Logging)
		{
			ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Handling voice_next() in a new thread when avaliable..");
		}
		Task.Run(delegate
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			try
			{
				Func<ClientWebSocket> func = delegate
				{
					ClientWebSocket clientWebSocket = new ClientWebSocket();
					clientWebSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(5.0);
					clientWebSocket.Options.Proxy = new WebProxy(proxy);
					return clientWebSocket;
				};
				voice_ws = new WebsocketClient(new Uri(VOICE_URL), func);
				voice_ws.ReconnectTimeout = TimeSpan.FromMinutes(3.0);
				ObservableExtensions.Subscribe<ReconnectionInfo>(voice_ws.ReconnectionHappened, (Action<ReconnectionInfo>)delegate
				{
				});
				ObservableExtensions.Subscribe<DisconnectionInfo>(voice_ws.DisconnectionHappened, (Action<DisconnectionInfo>)delegate(DisconnectionInfo i)
				{
					//IL_003a: Unknown result type (might be due to invalid IL or missing references)
					//IL_003f: Unknown result type (might be due to invalid IL or missing references)
					if (Logging)
					{
						string[] obj = new string[11]
						{
							proxy, " -> (", token, ") Websocket => VOICE::Disconnected type=", null, null, null, null, null, null,
							null
						};
						DisconnectionType type = i.Type;
						obj[4] = ((object)(DisconnectionType)(ref type)/*cast due to .constrained prefix*/).ToString();
						obj[5] = "&close_status=";
						obj[6] = i.CloseStatus.ToString();
						obj[7] = "&close_status_descr=";
						obj[8] = i.CloseStatusDescription;
						obj[9] = "&prev_protocol=";
						obj[10] = i.SubProtocol;
						ImpostazioniGlobali.Log(string.Concat(obj));
					}
				});
				voice_ws.MessageEncoding = Encoding.UTF8;
				ObservableExtensions.Subscribe<ResponseMessage>(voice_ws.MessageReceived, (Action<ResponseMessage>)delegate(ResponseMessage msg)
				{
					if (Logging)
					{
						ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => VOICE::MessageReceived msg=" + msg.Text);
					}
					try
					{
						if (msg.Text.Replace(" ", "").StartsWith("{\"op\":2,"))
						{
							ImpostazioniGlobali.Log(proxy + " -> (" + token + ") WS Voice Spammer => Successfully joined. READY.");
						}
					}
					catch (Exception)
					{
					}
				});
				voice_ws.Start();
				string text = "{\"op\":0,\"d\":{\"server_id\":\"" + queued_serv_id + "\",\"user_id\":\"" + user_id + "\",\"session_id\":\"" + voice_session_id + "\",\"token\":\"" + voice_token + "\",\"video\":true,\"streams\":[{\"type\":\"video\",\"rid\":\"100\",\"quality\":100}]}}";
				voice_ws.Send(text);
			}
			catch (Exception ex2)
			{
				ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => VOICE::An error has occurred: " + ex2);
			}
			try
			{
				if (Logging)
				{
					ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Disposing in 5 seconds..");
				}
				Thread.Sleep(5000);
				voice_ws.Dispose();
				voice_ws = null;
			}
			catch (Exception)
			{
				voice_ws = null;
			}
			ATTM_CONNECT_V = false;
			v_cr_voice_server_update = false;
			v_cr_voice_state_update = false;
		});
	}

	private void handle_ws_message(ResponseMessage responseMessage)
	{
		Task.Run(delegate
		{
			try
			{
				if (Logging)
				{
					ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Received message (typeof " + responseMessage.MessageType.ToString() + ") with " + responseMessage.Text);
				}
				dynamic val = JObject.Parse(responseMessage.Text);
				switch (val.op)
				{
				case 10:
				{
					dynamic val2 = val.d;
					int interval = val2.heartbeat_interval;
					start_ack_handling(interval);
					if (Logging)
					{
						ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Handled a 10 hello payload. Heartbeat Interval: " + hb_thr);
					}
					ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Identifying..");
					identify();
					break;
				}
				case 11:
					if (Logging)
					{
						ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Heartbeating Response: Success! OP_CODE=11");
					}
					break;
				case 0:
					if (responseMessage.Text.Contains("user") && responseMessage.Text.Contains("session_id") && responseMessage.Text.Contains("guilds") && responseMessage.Text.Contains("\"t\":\"READY\""))
					{
						ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Got a READY event payload :: Handling..");
						h_ready(responseMessage.Text);
					}
					else
					{
						string text = val.t;
						if (text == "VOICE_SERVER_UPDATE")
						{
							if (Logging)
							{
								ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Got a VOICE_SERVER_UPDATE payload :: Handling..");
							}
							h_voice_server_u(responseMessage.Text);
						}
						else if (text == "VOICE_STATE_UPDATE")
						{
							if (Logging)
							{
								ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Got a VOICE_STATE_UPDATE payload :: Handling..");
							}
							h_voice_state_u(responseMessage.Text);
						}
					}
					break;
				}
			}
			catch (Exception ex)
			{
				ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Cannot handle received message: " + ex);
			}
		});
	}

	public void send_ws_message(string msg)
	{
		try
		{
			Task.Run(delegate
			{
				try
				{
					ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Adding message to queue. Length: " + msg);
					ws.Send(msg);
				}
				catch (Exception)
				{
					ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Unable to send message. 0x00");
				}
			});
		}
		catch (Exception)
		{
			ImpostazioniGlobali.Log(proxy + " -> (" + token + ") Websocket => Unable to send message. 0x01");
		}
	}

	public bool is_connected()
	{
		if (ws == null)
		{
			return false;
		}
		if (ws.IsRunning)
		{
			return true;
		}
		return false;
	}

	public WebsocketClient get_ws()
	{
		return ws;
	}
}
