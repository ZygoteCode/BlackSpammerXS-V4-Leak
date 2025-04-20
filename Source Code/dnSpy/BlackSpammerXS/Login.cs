using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlackSpammerXS.Properties;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json.Linq;
using Siticone.UI.AnimatorNS;
using Siticone.UI.WinForms;

namespace BlackSpammerXS
{
	// Token: 0x0200007D RID: 125
	public partial class Login : Form
	{
		// Token: 0x0600020D RID: 525 RVA: 0x00025BF0 File Offset: 0x00023DF0
		public Login(int uaf_t)
		{
			this.InitializeComponent();
			bool flag = SecurityMT.ch_scr(2111, uaf_t, 0, 0, this) != 291144;
			if (flag)
			{
				SecLG.o_wr("err_ch_??? null LG [0, 0]");
				Application.Exit();
			}
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00025C4C File Offset: 0x00023E4C
		public void Dark()
		{
			Color color = Color.FromArgb(44, 47, 51);
			this.BackColor = color;
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00025C70 File Offset: 0x00023E70
		private void Login_Load(object sender, EventArgs e)
		{
			this.siticoneShadowForm1.SetShadowForm(this);
			try
			{
				bool flag = Settings.Default._U != null || Settings.Default._U != "" || Settings.Default._P != null || Settings.Default._P != "";
				if (flag)
				{
					this.usText.Text = Settings.Default._U ?? "";
					this.passw.Text = SecurityMT.e_dr(Settings.Default._P ?? "", "blackspammerxs");
				}
			}
			catch
			{
			}
			this.siticoneTransition1.Show(this.panel1, false, null);
		}

		// Token: 0x06000210 RID: 528 RVA: 0x00002067 File Offset: 0x00000267
		private void label2_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000211 RID: 529 RVA: 0x00002067 File Offset: 0x00000267
		private void label1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000212 RID: 530 RVA: 0x00002067 File Offset: 0x00000267
		private void pictureBox1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00025D4C File Offset: 0x00023F4C
		private async Task<int> Authenticate(string u, string p)
		{
			int num = 243;
			return num;
			try
			{
				try
				{
					IPAddress ip = Dns.GetHostAddresses("https://bgdm.dev")[0];
					IPAddress ipAddress = ip;
					bool flag = ipAddress.ToString() != "167.99.138.41";
					if (flag)
					{
						return 244;
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
						return 244;
					}
				}
				HttpRequestMessage http = new HttpRequestMessage
				{
					RequestUri = new Uri("https://bgdm.dev/api/v3/blackspammerxs/auth/login"),
					Content = new StringContent(string.Concat(new string[] { "{\"username\": \"", u, "\", \"password\": \"", p, "\", \"client_id\": \"d6Jnc2V3ZzQyd3dobmlyaHJnYmluZ2prb2JxZXVidXFlZmJ1cWVmZ3VpZmd5dWZndXl2cWVjZmClDXlhcWVmZ2J5aXVhcWVmZ2J5cWVmZ2J5cWVmZ2J5cWVmZ203\", \"version\": \"V417X\", \"formatted_version\": \"X17.1\"}" }), Encoding.UTF8, "application/json"),
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
				if (r.StatusCode == HttpStatusCode.Forbidden)
				{
					b = null;
					r = null;
					num = 242;
				}
				else
				{
					try
					{
						if (Login.<>o__6.<>p__4 == null)
						{
							Login.<>o__6.<>p__4 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Login), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, bool> target = Login.<>o__6.<>p__4.Target;
						CallSite <>p__ = Login.<>o__6.<>p__4;
						if (Login.<>o__6.<>p__3 == null)
						{
							Login.<>o__6.<>p__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof(Login), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						Func<CallSite, object, string, object> target2 = Login.<>o__6.<>p__3.Target;
						CallSite <>p__2 = Login.<>o__6.<>p__3;
						if (Login.<>o__6.<>p__2 == null)
						{
							Login.<>o__6.<>p__2 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "validation_sign", typeof(Login), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, object> target3 = Login.<>o__6.<>p__2.Target;
						CallSite <>p__3 = Login.<>o__6.<>p__2;
						if (Login.<>o__6.<>p__1 == null)
						{
							Login.<>o__6.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "session", typeof(Login), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, object> target4 = Login.<>o__6.<>p__1.Target;
						CallSite <>p__4 = Login.<>o__6.<>p__1;
						if (Login.<>o__6.<>p__0 == null)
						{
							Login.<>o__6.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "payload", typeof(Login), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						if (target(<>p__, target2(<>p__2, target3(<>p__3, target4(<>p__4, Login.<>o__6.<>p__0.Target(Login.<>o__6.<>p__0, c))), "dnNnMENkdkY8PiFQKHY7VyZ7OmI4K20jN0NzLlgUkA3VVNFK2o7JVAoIyMzMi5aYThrcGIuY2xmOTQ1Pz8MDE0ODkxNGZkZnFtd19td2ZAd2ZmYWFhYWFh")))
						{
							throw new Exception("Invalid sid vsgn");
						}
						HttpResponseHeaders rhc = r.Headers;
						string signature_temp = rhc.GetValues("X-Signature").First<string>();
						if (Login.<>o__6.<>p__7 == null)
						{
							Login.<>o__6.<>p__7 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Login)));
						}
						Func<CallSite, object, string> target5 = Login.<>o__6.<>p__7.Target;
						CallSite <>p__5 = Login.<>o__6.<>p__7;
						if (Login.<>o__6.<>p__6 == null)
						{
							Login.<>o__6.<>p__6 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "validation_ut", typeof(Login), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, object> target6 = Login.<>o__6.<>p__6.Target;
						CallSite <>p__6 = Login.<>o__6.<>p__6;
						if (Login.<>o__6.<>p__5 == null)
						{
							Login.<>o__6.<>p__5 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "payload", typeof(Login), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						string validation_utils = target5(<>p__5, target6(<>p__6, Login.<>o__6.<>p__5.Target(Login.<>o__6.<>p__5, c)));
						byte[] sign_bytes = Convert.FromBase64String(signature_temp);
						string sign_dec = Encoding.UTF8.GetString(sign_bytes);
						sign_dec = sign_dec.Replace(validation_utils, "");
						if (Login.<>o__6.<>p__14 == null)
						{
							Login.<>o__6.<>p__14 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Login), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, bool> target7 = Login.<>o__6.<>p__14.Target;
						CallSite <>p__7 = Login.<>o__6.<>p__14;
						if (Login.<>o__6.<>p__13 == null)
						{
							Login.<>o__6.<>p__13 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(Login), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, string, object, object> target8 = Login.<>o__6.<>p__13.Target;
						CallSite <>p__8 = Login.<>o__6.<>p__13;
						string text2 = sign_dec;
						if (Login.<>o__6.<>p__12 == null)
						{
							Login.<>o__6.<>p__12 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(Login), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						Func<CallSite, object, string, object> target9 = Login.<>o__6.<>p__12.Target;
						CallSite <>p__9 = Login.<>o__6.<>p__12;
						if (Login.<>o__6.<>p__11 == null)
						{
							Login.<>o__6.<>p__11 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(Login), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, string, object, object> target10 = Login.<>o__6.<>p__11.Target;
						CallSite <>p__10 = Login.<>o__6.<>p__11;
						string text3 = "";
						if (Login.<>o__6.<>p__10 == null)
						{
							Login.<>o__6.<>p__10 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "created_at", typeof(Login), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, object> target11 = Login.<>o__6.<>p__10.Target;
						CallSite <>p__11 = Login.<>o__6.<>p__10;
						if (Login.<>o__6.<>p__9 == null)
						{
							Login.<>o__6.<>p__9 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "session", typeof(Login), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, object> target12 = Login.<>o__6.<>p__9.Target;
						CallSite <>p__12 = Login.<>o__6.<>p__9;
						if (Login.<>o__6.<>p__8 == null)
						{
							Login.<>o__6.<>p__8 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "payload", typeof(Login), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						if (!target7(<>p__7, target8(<>p__8, text2, target9(<>p__9, target10(<>p__10, text3, target11(<>p__11, target12(<>p__12, Login.<>o__6.<>p__8.Target(Login.<>o__6.<>p__8, c)))), "UEA3K0JCIUBqWlYkdmVRWA"))))
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
						return 245;
					}
					b = null;
					r = null;
					if (Login.<>o__6.<>p__17 == null)
					{
						Login.<>o__6.<>p__17 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Login), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					Func<CallSite, object, bool> target13 = Login.<>o__6.<>p__17.Target;
					CallSite <>p__13 = Login.<>o__6.<>p__17;
					if (Login.<>o__6.<>p__16 == null)
					{
						Login.<>o__6.<>p__16 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(Login), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					Func<CallSite, object, int, object> target14 = Login.<>o__6.<>p__16.Target;
					CallSite <>p__14 = Login.<>o__6.<>p__16;
					if (Login.<>o__6.<>p__15 == null)
					{
						Login.<>o__6.<>p__15 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "code", typeof(Login), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					if (target13(<>p__13, target14(<>p__14, Login.<>o__6.<>p__15.Target(Login.<>o__6.<>p__15, c), 503)))
					{
						throw new Exception("err unav 0x0f0");
					}
					if (Login.<>o__6.<>p__20 == null)
					{
						Login.<>o__6.<>p__20 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Login), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					Func<CallSite, object, bool> target15 = Login.<>o__6.<>p__20.Target;
					CallSite <>p__15 = Login.<>o__6.<>p__20;
					if (Login.<>o__6.<>p__19 == null)
					{
						Login.<>o__6.<>p__19 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof(Login), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					Func<CallSite, object, int, object> target16 = Login.<>o__6.<>p__19.Target;
					CallSite <>p__16 = Login.<>o__6.<>p__19;
					if (Login.<>o__6.<>p__18 == null)
					{
						Login.<>o__6.<>p__18 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "code", typeof(Login), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					if (target15(<>p__15, target16(<>p__16, Login.<>o__6.<>p__18.Target(Login.<>o__6.<>p__18, c), 201)))
					{
						num = 242;
					}
					else
					{
						if (Login.<>o__6.<>p__24 == null)
						{
							Login.<>o__6.<>p__24 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof(Login), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						Func<CallSite, object, object, object> target17 = Login.<>o__6.<>p__24.Target;
						CallSite <>p__17 = Login.<>o__6.<>p__24;
						if (Login.<>o__6.<>p__23 == null)
						{
							Login.<>o__6.<>p__23 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(Login), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, object> target18 = Login.<>o__6.<>p__23.Target;
						CallSite <>p__18 = Login.<>o__6.<>p__23;
						if (Login.<>o__6.<>p__22 == null)
						{
							Login.<>o__6.<>p__22 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "session", typeof(Login), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, object> target19 = Login.<>o__6.<>p__22.Target;
						CallSite <>p__19 = Login.<>o__6.<>p__22;
						if (Login.<>o__6.<>p__21 == null)
						{
							Login.<>o__6.<>p__21 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "payload", typeof(Login), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						object obj = target17(<>p__17, target18(<>p__18, target19(<>p__19, Login.<>o__6.<>p__21.Target(Login.<>o__6.<>p__21, c))), null);
						if (Login.<>o__6.<>p__31 == null)
						{
							Login.<>o__6.<>p__31 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Login), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						bool flag3;
						if (!Login.<>o__6.<>p__31.Target(Login.<>o__6.<>p__31, obj))
						{
							if (Login.<>o__6.<>p__30 == null)
							{
								Login.<>o__6.<>p__30 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Login), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
							}
							Func<CallSite, object, bool> target20 = Login.<>o__6.<>p__30.Target;
							CallSite <>p__20 = Login.<>o__6.<>p__30;
							if (Login.<>o__6.<>p__29 == null)
							{
								Login.<>o__6.<>p__29 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, ExpressionType.Or, typeof(Login), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							Func<CallSite, object, object, object> target21 = Login.<>o__6.<>p__29.Target;
							CallSite <>p__21 = Login.<>o__6.<>p__29;
							if (Login.<>o__6.<>p__28 == null)
							{
								Login.<>o__6.<>p__28 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof(Login), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
								}));
							}
							Func<CallSite, object, string, object> target22 = Login.<>o__6.<>p__28.Target;
							CallSite <>p__22 = Login.<>o__6.<>p__28;
							if (Login.<>o__6.<>p__27 == null)
							{
								Login.<>o__6.<>p__27 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "id", typeof(Login), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
							}
							Func<CallSite, object, object> target23 = Login.<>o__6.<>p__27.Target;
							CallSite <>p__23 = Login.<>o__6.<>p__27;
							if (Login.<>o__6.<>p__26 == null)
							{
								Login.<>o__6.<>p__26 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "session", typeof(Login), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
							}
							Func<CallSite, object, object> target24 = Login.<>o__6.<>p__26.Target;
							CallSite <>p__24 = Login.<>o__6.<>p__26;
							if (Login.<>o__6.<>p__25 == null)
							{
								Login.<>o__6.<>p__25 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "payload", typeof(Login), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
							}
							flag3 = target20(<>p__20, target21(<>p__21, obj, target22(<>p__22, target23(<>p__23, target24(<>p__24, Login.<>o__6.<>p__25.Target(Login.<>o__6.<>p__25, c))), "")));
						}
						else
						{
							flag3 = true;
						}
						if (flag3)
						{
							num = 243;
						}
						else
						{
							num = 242;
						}
					}
				}
			}
			catch (Exception)
			{
				num = 240;
			}
			return num;
		}

		// Token: 0x06000214 RID: 532 RVA: 0x00025DA0 File Offset: 0x00023FA0
		private async void siticoneButton3_Click(object sender, EventArgs e)
		{
			this.siticoneGradientButton1.Text = "Authenticating..";
			this.siticoneGradientButton1.Enabled = false;
			this.usText.Enabled = false;
			this.passw.Enabled = false;
			int num = await this.Authenticate(this.usText.Text, this.passw.Text);
			int o = num;
			if (o != 243)
			{
				this.siticoneGradientButton1.Text = "Login";
				this.siticoneGradientButton1.Enabled = true;
				this.usText.Enabled = true;
				this.passw.Enabled = true;
				if (o == 245)
				{
					MessageBox.ShowWhite("La firma del server non è valida: Invalid Signature", "Errore", ContentAlignment.MiddleCenter);
				}
				else if (o == 244)
				{
					MessageBox.ShowWhite("Questa versione di BlackSpammer non è più disponibile", "Errore", ContentAlignment.MiddleCenter);
				}
				else if (o == 242)
				{
					MessageBox.ShowWhite("Failed to login. Please try again!", "Login", ContentAlignment.MiddleCenter);
				}
				else
				{
					MessageBox.ShowWhite("I servers di BlackSpammerXS non sono al momento disponibili", "Errore", ContentAlignment.MiddleCenter);
				}
			}
			else
			{
				this.siticoneGradientButton1.Text = "Authenticated";
				if (this.r)
				{
					try
					{
						Settings.Default._U = this.usText.Text;
						Settings.Default._P = SecurityMT.e_er(this.passw.Text, "blackspammerxs");
						Settings.Default.Save();
					}
					catch (Exception)
					{
					}
				}
				else
				{
					try
					{
						Settings.Default.Reset();
						Settings.Default.Save();
					}
					catch (Exception)
					{
					}
				}
				int sqn = SecurityMT.reg_sqn(34177U, 63713);
				if (sqn == 0)
				{
					MessageBox.ShowWhite("An error has occurred, please restart. Security Error 0x741784", "Security Manager", ContentAlignment.MiddleCenter);
					this.siticoneGradientButton1.Text = "Security Error";
				}
				else
				{
					try
					{
						MessageBox.ShowWhite("BlackSpammer XS V4 has been discontinued.", "Discontinuation Notification", ContentAlignment.MiddleCenter);
						new Form1(sqn, sqn / 2, 256447608, this).Show();
					}
					catch (Exception)
					{
						MessageBox.ShowWhite("An error has occurred, please restart. SecErr 0x841", "Security Manager", ContentAlignment.MiddleCenter);
						this.siticoneGradientButton1.Text = "Security Error";
					}
					sqn = 0;
					o = 0;
					base.Hide();
					try
					{
						base.Controls.Clear();
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x06000215 RID: 533 RVA: 0x00025DE7 File Offset: 0x00023FE7
		private void siticoneCustomCheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			this.r = this.siticoneCustomCheckBox1.Checked;
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00002067 File Offset: 0x00000267
		private void siticoneButton3_MouseEnter(object sender, EventArgs e)
		{
		}

		// Token: 0x06000217 RID: 535 RVA: 0x00002067 File Offset: 0x00000267
		private void siticoneButton3_MouseLeave(object sender, EventArgs e)
		{
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00025DFB File Offset: 0x00023FFB
		private void siticoneGradientButton1_Click(object sender, EventArgs e)
		{
			this.siticoneButton3_Click(sender, e);
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00016A5D File Offset: 0x00014C5D
		private void siticoneImageButton1_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// Token: 0x0600021A RID: 538 RVA: 0x000124AE File Offset: 0x000106AE
		private void siticoneImageButton2_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00002067 File Offset: 0x00000267
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00002067 File Offset: 0x00000267
		private void siticoneImageButton3_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00002067 File Offset: 0x00000267
		private void usText_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x04000488 RID: 1160
		private bool r = true;
	}
}
