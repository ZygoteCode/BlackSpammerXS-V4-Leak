using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlackSpammerXS.Properties;
using Siticone.UI.WinForms;

namespace BlackSpammerXS
{
	// Token: 0x02000033 RID: 51
	public class Dashboard : UserControl
	{
		// Token: 0x060000DA RID: 218 RVA: 0x0000F2F4 File Offset: 0x0000D4F4
		public Dashboard()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000F30C File Offset: 0x0000D50C
		private void Dashboard_Load(object sender, EventArgs e)
		{
			this.userWlob.Text = Settings.Default._U ?? "";
			ImpostazioniGlobali._stmodeCallback = delegate(bool a)
			{
				this.StreamerMode(a);
			};
			ImpostazioniGlobali._bridgeLogPerform.Add(delegate(int a, int b, object[] i)
			{
				bool flag = a == 3699 && b == 1601;
				if (flag)
				{
					this.proxiesCount.Text = "Testing";
				}
			});
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000F361 File Offset: 0x0000D561
		public void StreamerMode(bool _)
		{
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000F368 File Offset: 0x0000D568
		public void Dark()
		{
			Color color = Color.FromArgb(44, 47, 51);
			this.BackColor = color;
			Color dimGray = Color.DimGray;
			try
			{
				foreach (SiticoneButton siticoneButton in new List<SiticoneButton> { this.siticoneButton1, this.siticoneButton2, this.siticoneButton5, this.siticoneButton6 })
				{
					try
					{
						siticoneButton.ForeColor = Color.White;
						siticoneButton.FillColor = dimGray;
						siticoneButton.BorderColor = Color.Gray;
					}
					catch (Exception)
					{
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000F458 File Offset: 0x0000D658
		internal void SetTokens(int t)
		{
			Control.CheckForIllegalCrossThreadCalls = false;
			this.proxiesCount.Text = t.ToString() ?? "";
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000F47E File Offset: 0x0000D67E
		internal void SetProxies(int a)
		{
			Control.CheckForIllegalCrossThreadCalls = false;
			this.emailsCount.Text = a.ToString() ?? "";
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000F4A4 File Offset: 0x0000D6A4
		private void siticoneButton5_Click(object sender, EventArgs e)
		{
			bool flag = ImpostazioniGlobali.Proxies == null;
			if (flag)
			{
				MessageBox.Show("There are no proxies", "Avviso", ContentAlignment.MiddleCenter);
			}
			else
			{
				int num;
				int num2;
				ThreadPool.GetMaxThreads(out num, out num2);
				ThreadPool.SetMinThreads(num2 - 1, num2 - 1);
				ImpostazioniGlobali.StartLog();
				ImpostazioniGlobali.Log("Check Proxies => Sto controllando tutti i proxies..");
				Random random = new Random();
				new Thread(delegate(object a)
				{
					try
					{
						using (List<string>.Enumerator enumerator = ImpostazioniGlobali.Proxies.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								string proxy = enumerator.Current;
								new Thread(async delegate(object CHECK)
								{
									try
									{
										Dashboard.<>c__DisplayClass6_1 CS$<>8__locals2 = new Dashboard.<>c__DisplayClass6_1();
										HttpClientHandler handler = new HttpClientHandler();
										handler.PreAuthenticate = true;
										handler.UseProxy = true;
										handler.Proxy = new WebProxy(proxy.Split(new char[] { ':' })[0], int.Parse(proxy.Split(new char[] { ':' })[1]));
										HttpClient http = new HttpClient(handler);
										HttpRequestMessage request = new HttpRequestMessage
										{
											RequestUri = new Uri("https://discord.com"),
											Method = HttpMethod.Get
										};
										CS$<>8__locals2.ab = true;
										CS$<>8__locals2.mst = 0;
										Task.Run(delegate
										{
											while (CS$<>8__locals2.ab && CS$<>8__locals2.mst != 10000)
											{
												bool flag2 = !CS$<>8__locals2.ab;
												if (flag2)
												{
													break;
												}
												bool flag3 = CS$<>8__locals2.mst >= 10000;
												if (flag3)
												{
													break;
												}
												int mst = CS$<>8__locals2.mst;
												CS$<>8__locals2.mst = mst + 1;
												Thread.Sleep(1);
											}
										});
										HttpResponseMessage httpResponseMessage = await http.SendAsync(request);
										HttpResponseMessage req = httpResponseMessage;
										httpResponseMessage = null;
										string text = await req.Content.ReadAsStringAsync();
										CS$<>8__locals2.ab = true;
										ImpostazioniGlobali.Log(proxy + " ->  Check => Success. Proxy is alive and working. Took " + CS$<>8__locals2.mst.ToString() + "ms");
										CS$<>8__locals2 = null;
										handler = null;
										http = null;
										request = null;
										req = null;
									}
									catch (Exception)
									{
										ImpostazioniGlobali.Log(proxy + " -> Check => Error. Proxy is not working");
									}
									try
									{
										Thread.CurrentThread.Abort();
									}
									catch
									{
									}
								}).Start();
							}
						}
					}
					catch (Exception)
					{
					}
				}).Start();
			}
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000F52C File Offset: 0x0000D72C
		private void siticoneButton3_Click(object sender, EventArgs e)
		{
			try
			{
				this.tryLaunchBlackGenLauncher();
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000F55C File Offset: 0x0000D75C
		public void tryLaunchBlackGenLauncher()
		{
			MessageBox.Show("Questa funzione non è più disponibile dalla versione 13X. Avvialo manualmente", "Discontinued", ContentAlignment.MiddleCenter);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000F574 File Offset: 0x0000D774
		private OpenFileDialog newFileLoader(string title, string filter)
		{
			return new OpenFileDialog
			{
				Filter = filter,
				FileName = "",
				Title = title
			};
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000F5AC File Offset: 0x0000D7AC
		private void siticoneButton4_Click(object sender, EventArgs e)
		{
			OpenFileDialog open = this.newFileLoader("Proxies: Importa alcuni proxies HTTP/HTTPS", "Txt Files (*.txt)|*.txt");
			bool flag = open.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				Task.Run(delegate
				{
					using (StreamReader streamReader = new StreamReader(open.FileName))
					{
						List<string> list = new List<string>();
						string text;
						while ((text = streamReader.ReadLine()) != null)
						{
							list.Add(text);
						}
						ImpostazioniGlobali.Proxies = list;
						Control.CheckForIllegalCrossThreadCalls = false;
						this.emailsCount.Text = list.Count.ToString() ?? "";
						try
						{
							Settings.Default.lastProxies = open.FileName;
							Settings.Default.Save();
						}
						catch (Exception)
						{
						}
					}
				});
			}
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000F604 File Offset: 0x0000D804
		private async void siticoneButton1_Click(object sender, EventArgs e)
		{
			this.siticoneButton1.Enabled = false;
			this.siticoneButton1.Text = "Resetting..";
			try
			{
				ImpostazioniGlobali.Proxies.Clear();
			}
			catch (Exception)
			{
			}
			ImpostazioniGlobali.Proxies = null;
			ImpostazioniGlobali.Proxies = new List<string>();
			await Task.Run(delegate
			{
				Thread.Sleep(50);
			});
			this.emailsCount.Text = "0";
			this.siticoneButton1.Enabled = true;
			this.siticoneButton1.Text = "Reset";
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000F64C File Offset: 0x0000D84C
		private async void siticoneButton2_Click(object sender, EventArgs e)
		{
			this.siticoneButton2.Enabled = false;
			this.siticoneButton2.Text = "Resetting..";
			try
			{
				ImpostazioniGlobali.Tokens.Clear();
			}
			catch (Exception)
			{
			}
			ImpostazioniGlobali.Tokens = null;
			ImpostazioniGlobali.Tokens = new List<string>();
			await Task.Run(delegate
			{
				Thread.Sleep(50);
			});
			this.proxiesCount.Text = "0";
			this.siticoneButton2.Enabled = true;
			this.siticoneButton2.Text = "Reset";
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000F694 File Offset: 0x0000D894
		private void loadDefaultBtn_Click(object sender, EventArgs e)
		{
			OpenFileDialog open = this.newFileLoader("Tokens: Importa tokens", "Txt Files (*.txt)|*.txt");
			bool flag = open.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				Task.Run(delegate
				{
					using (StreamReader streamReader = new StreamReader(open.FileName))
					{
						List<string> list = new List<string>();
						string text;
						while ((text = streamReader.ReadLine()) != null)
						{
							list.Add(text);
						}
						ImpostazioniGlobali.Tokens = list;
						Control.CheckForIllegalCrossThreadCalls = false;
						this.proxiesCount.Text = list.Count.ToString() ?? "";
						try
						{
							Settings.Default.lastTokens = open.FileName;
							Settings.Default.Save();
						}
						catch (Exception)
						{
						}
					}
				});
			}
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000F6EC File Offset: 0x0000D8EC
		private async void siticoneButton7_Click(object sender, EventArgs e)
		{
			this.siticoneButton7.Enabled = false;
			this.siticoneButton7.Text = "Loading..";
			ImpostazioniGlobali.StartLog();
			await Task.Delay(50);
			this.siticoneButton7.Enabled = true;
			this.siticoneButton7.Text = "Logger";
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000F734 File Offset: 0x0000D934
		private async void siticoneButton6_Click(object sender, EventArgs e)
		{
			bool flag = ImpostazioniGlobali.Tokens == null || ImpostazioniGlobali.Proxies == null;
			if (flag)
			{
				MessageBox.Show("There are no tokens or no proxies", "Avviso", ContentAlignment.MiddleCenter);
			}
			else
			{
				this.siticoneButton6.Enabled = false;
				this.siticoneButton6.Text = "Checking...";
				int max;
				int o;
				ThreadPool.GetMaxThreads(out max, out o);
				ThreadPool.SetMinThreads(o - 1, o - 1);
				Random random = new Random();
				List<string> proxies = ImpostazioniGlobali.Proxies;
				new Thread(delegate(object a)
				{
					ImpostazioniGlobali.StartLog();
					try
					{
						using (List<string>.Enumerator enumerator = ImpostazioniGlobali.Tokens.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								string t = enumerator.Current;
								new Thread(async delegate(object CHECK)
								{
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
										handler.Proxy = new WebProxy(proxy.Split(new char[] { ':' })[0], int.Parse(proxy.Split(new char[] { ':' })[1]));
										HttpClient http = new HttpClient(handler);
										HttpRequestMessage request = new HttpRequestMessage
										{
											RequestUri = new Uri("https://discord.com/api/v9/users/@me/library"),
											Method = HttpMethod.Get,
											Headers = { { "Authorization", t } }
										};
										HttpResponseMessage httpResponseMessage = await http.SendAsync(request);
										HttpResponseMessage req = httpResponseMessage;
										httpResponseMessage = null;
										string text = await req.Content.ReadAsStringAsync();
										string _ = text;
										text = null;
										ImpostazioniGlobali.Log(string.Concat(new string[] { proxy, " -> (", t, ") Check => ", _ }));
										if (_.Contains("401: Unauthorized"))
										{
											try
											{
												ImpostazioniGlobali.Tokens.Remove(t);
												this.proxiesCount.Text = ImpostazioniGlobali.Tokens.Count.ToString() ?? "";
											}
											catch
											{
											}
										}
										else if (_.Contains("verify"))
										{
											try
											{
												ImpostazioniGlobali.Tokens.Remove(t);
												this.proxiesCount.Text = ImpostazioniGlobali.Tokens.Count.ToString() ?? "";
											}
											catch
											{
											}
										}
										else if (req.StatusCode != HttpStatusCode.OK)
										{
											try
											{
												ImpostazioniGlobali.Tokens.Remove(t);
												this.proxiesCount.Text = ImpostazioniGlobali.Tokens.Count.ToString() ?? "";
											}
											catch
											{
											}
										}
										handler = null;
										http = null;
										request = null;
										req = null;
										_ = null;
									}
									catch (Exception)
									{
										ImpostazioniGlobali.Log(proxy + " -> (" + t + ") Check => Unknown Error [Check your proxies]");
									}
									try
									{
										Thread.CurrentThread.Abort();
									}
									catch
									{
									}
								}).Start();
							}
						}
					}
					catch (Exception)
					{
					}
				}).Start();
				await Task.Delay(300);
				this.siticoneButton6.Enabled = true;
				this.siticoneButton6.Text = "Check";
			}
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00002067 File Offset: 0x00000267
		private void hasVerifyDie_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00002067 File Offset: 0x00000267
		private void hasVerifyDie_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000F77B File Offset: 0x0000D97B
		private void siticoneButton7_MouseEnter(object sender, EventArgs e)
		{
			this.siticoneButton7.BorderThickness = 2;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000F78B File Offset: 0x0000D98B
		private void siticoneButton7_MouseLeave(object sender, EventArgs e)
		{
			this.siticoneButton7.BorderThickness = 1;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000F79C File Offset: 0x0000D99C
		private void siticoneButton2_MouseEnter(object sender, EventArgs e)
		{
			try
			{
				SiticoneButton siticoneButton = (SiticoneButton)sender;
				bool flag = siticoneButton != null;
				if (flag)
				{
					siticoneButton.BorderThickness = 1;
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000F7DC File Offset: 0x0000D9DC
		private void siticoneButton2_MouseLeave(object sender, EventArgs e)
		{
			try
			{
				SiticoneButton siticoneButton = (SiticoneButton)sender;
				bool flag = siticoneButton != null;
				if (flag)
				{
					siticoneButton.BorderThickness = 1;
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00002067 File Offset: 0x00000267
		private void siticoneTextBox1_MouseEnter(object sender, EventArgs e)
		{
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00002067 File Offset: 0x00000267
		private void siticoneTextBox1_MouseLeave(object sender, EventArgs e)
		{
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000F81C File Offset: 0x0000DA1C
		private void hasLive_CheckedChanged(object sender, EventArgs e)
		{
			ImpostazioniGlobali.AlwaysOn = this.hasLive.Checked;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00002067 File Offset: 0x00000267
		private void siticoneTextBox1_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00002067 File Offset: 0x00000267
		private void label6_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00002067 File Offset: 0x00000267
		private void hasEmbed_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000F82F File Offset: 0x0000DA2F
		private void hasEmbed_CheckedChanged(object sender, EventArgs e)
		{
			ImpostazioniGlobali.LOG_UseNewFont = this.hasJMFont.Checked;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00002067 File Offset: 0x00000267
		private void label5_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0000F842 File Offset: 0x0000DA42
		private void siticoneGradientButton1_Click(object sender, EventArgs e)
		{
			this.loadDefaultBtn_Click(sender, e);
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x0000F84E File Offset: 0x0000DA4E
		private void siticoneGradientButton2_Click(object sender, EventArgs e)
		{
			this.siticoneButton4_Click(sender, e);
		}

		// Token: 0x060000FA RID: 250 RVA: 0x0000F85A File Offset: 0x0000DA5A
		private void siticoneGradientButton1_Click_1(object sender, EventArgs e)
		{
			this.siticoneButton7_Click(sender, e);
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0000F866 File Offset: 0x0000DA66
		private void siticoneGradientButton2_Click_1(object sender, EventArgs e)
		{
			this.siticoneButton3_Click(sender, e);
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000F874 File Offset: 0x0000DA74
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0000F8AC File Offset: 0x0000DAAC
		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Dashboard));
			this.label1 = new Label();
			this.siticoneDragControl1 = new SiticoneDragControl(this.components);
			this.emailsCount = new Label();
			this.proxiesCount = new Label();
			this.label3 = new Label();
			this.label2 = new Label();
			this.label9 = new Label();
			this.label8 = new Label();
			this.hasJMFont = new SiticoneCustomCheckBox();
			this.hasLive = new SiticoneCustomCheckBox();
			this.siticoneButton1 = new SiticoneButton();
			this.siticoneButton2 = new SiticoneButton();
			this.siticoneButton5 = new SiticoneButton();
			this.siticoneButton6 = new SiticoneButton();
			this.siticoneDragControl2 = new SiticoneDragControl(this.components);
			this.userWlob = new Label();
			this.loadDefaultBtn = new SiticoneGradientButton();
			this.siticoneButton4 = new SiticoneGradientButton();
			this.siticoneButton7 = new SiticoneGradientButton();
			this.pictureBox1 = new PictureBox();
			this.label4 = new Label();
			this.label7 = new Label();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Inter", 15.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(13, 32);
			this.label1.Name = "label1";
			this.label1.Size = new Size(123, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "Dashboard";
			this.siticoneDragControl1.TargetControl = this;
			this.emailsCount.Font = new Font("Inter Black", 9.749999f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.emailsCount.Location = new Point(517, 134);
			this.emailsCount.Name = "emailsCount";
			this.emailsCount.Size = new Size(144, 17);
			this.emailsCount.TabIndex = 38;
			this.emailsCount.Text = "0";
			this.emailsCount.TextAlign = ContentAlignment.MiddleCenter;
			this.proxiesCount.Font = new Font("Inter Black", 9.749999f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.proxiesCount.Location = new Point(21, 135);
			this.proxiesCount.Name = "proxiesCount";
			this.proxiesCount.Size = new Size(179, 16);
			this.proxiesCount.TabIndex = 37;
			this.proxiesCount.Text = "0";
			this.proxiesCount.TextAlign = ContentAlignment.MiddleCenter;
			this.label3.AutoSize = true;
			this.label3.Font = new Font("Inter Light", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label3.Location = new Point(560, 106);
			this.label3.Name = "label3";
			this.label3.Size = new Size(60, 19);
			this.label3.TabIndex = 36;
			this.label3.Text = "Proxies";
			this.label2.AutoSize = true;
			this.label2.Font = new Font("Inter Light", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label2.Location = new Point(81, 106);
			this.label2.Name = "label2";
			this.label2.Size = new Size(60, 19);
			this.label2.TabIndex = 35;
			this.label2.Text = "Tokens";
			this.label9.AutoSize = true;
			this.label9.Font = new Font("SF Pro Text", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label9.Location = new Point(295, 198);
			this.label9.Name = "label9";
			this.label9.Size = new Size(117, 14);
			this.label9.TabIndex = 46;
			this.label9.Text = "Always-on Logger";
			this.label8.AutoSize = true;
			this.label8.Font = new Font("SF Pro Text", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label8.Location = new Point(295, 220);
			this.label8.Name = "label8";
			this.label8.Size = new Size(136, 14);
			this.label8.TabIndex = 45;
			this.label8.Text = "Compact Logger Font";
			this.hasJMFont.BackColor = Color.Transparent;
			this.hasJMFont.Checked = true;
			this.hasJMFont.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.hasJMFont.CheckedState.BorderRadius = 2;
			this.hasJMFont.CheckedState.BorderThickness = 0;
			this.hasJMFont.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.hasJMFont.CheckedState.Parent = this.hasJMFont;
			this.hasJMFont.CheckState = CheckState.Checked;
			this.hasJMFont.Cursor = Cursors.Hand;
			this.hasJMFont.Location = new Point(277, 219);
			this.hasJMFont.Name = "hasJMFont";
			this.hasJMFont.ShadowDecoration.Parent = this.hasJMFont;
			this.hasJMFont.Size = new Size(15, 15);
			this.hasJMFont.TabIndex = 44;
			this.hasJMFont.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.hasJMFont.UncheckedState.BorderRadius = 2;
			this.hasJMFont.UncheckedState.BorderThickness = 0;
			this.hasJMFont.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.hasJMFont.UncheckedState.Parent = this.hasJMFont;
			this.hasJMFont.CheckedChanged += this.hasEmbed_CheckedChanged;
			this.hasJMFont.Click += this.hasEmbed_Click;
			this.hasLive.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.hasLive.CheckedState.BorderRadius = 2;
			this.hasLive.CheckedState.BorderThickness = 0;
			this.hasLive.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
			this.hasLive.CheckedState.Parent = this.hasLive;
			this.hasLive.Cursor = Cursors.Hand;
			this.hasLive.Location = new Point(277, 198);
			this.hasLive.Name = "hasLive";
			this.hasLive.ShadowDecoration.Parent = this.hasLive;
			this.hasLive.Size = new Size(15, 15);
			this.hasLive.TabIndex = 43;
			this.hasLive.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.hasLive.UncheckedState.BorderRadius = 2;
			this.hasLive.UncheckedState.BorderThickness = 0;
			this.hasLive.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
			this.hasLive.UncheckedState.Parent = this.hasLive;
			this.hasLive.CheckedChanged += this.hasLive_CheckedChanged;
			this.siticoneButton1.BackColor = Color.Transparent;
			this.siticoneButton1.BorderColor = Color.LightGray;
			this.siticoneButton1.BorderRadius = 4;
			this.siticoneButton1.BorderStyle = DashStyle.Dot;
			this.siticoneButton1.BorderThickness = 1;
			this.siticoneButton1.CheckedState.Parent = this.siticoneButton1;
			this.siticoneButton1.Cursor = Cursors.Hand;
			this.siticoneButton1.CustomImages.Parent = this.siticoneButton1;
			this.siticoneButton1.FillColor = Color.Snow;
			this.siticoneButton1.Font = new Font("Inter", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.siticoneButton1.ForeColor = Color.Black;
			this.siticoneButton1.HoveredState.Parent = this.siticoneButton1;
			this.siticoneButton1.Location = new Point(497, 172);
			this.siticoneButton1.Name = "siticoneButton1";
			this.siticoneButton1.PressedColor = Color.White;
			this.siticoneButton1.ShadowDecoration.Parent = this.siticoneButton1;
			this.siticoneButton1.Size = new Size(182, 41);
			this.siticoneButton1.TabIndex = 47;
			this.siticoneButton1.Text = "Reset";
			this.siticoneButton1.TextRenderingHint = TextRenderingHint.AntiAlias;
			this.siticoneButton1.Click += this.siticoneButton1_Click;
			this.siticoneButton1.MouseEnter += this.siticoneButton2_MouseEnter;
			this.siticoneButton1.MouseLeave += this.siticoneButton2_MouseLeave;
			this.siticoneButton2.BackColor = Color.Transparent;
			this.siticoneButton2.BorderColor = Color.LightGray;
			this.siticoneButton2.BorderRadius = 4;
			this.siticoneButton2.BorderStyle = DashStyle.Dot;
			this.siticoneButton2.BorderThickness = 1;
			this.siticoneButton2.CheckedState.Parent = this.siticoneButton2;
			this.siticoneButton2.Cursor = Cursors.Hand;
			this.siticoneButton2.CustomImages.Parent = this.siticoneButton2;
			this.siticoneButton2.FillColor = Color.Snow;
			this.siticoneButton2.Font = new Font("Inter", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.siticoneButton2.ForeColor = Color.Black;
			this.siticoneButton2.HoveredState.Parent = this.siticoneButton2;
			this.siticoneButton2.Location = new Point(18, 172);
			this.siticoneButton2.Name = "siticoneButton2";
			this.siticoneButton2.PressedColor = Color.White;
			this.siticoneButton2.ShadowDecoration.Parent = this.siticoneButton2;
			this.siticoneButton2.Size = new Size(182, 41);
			this.siticoneButton2.TabIndex = 48;
			this.siticoneButton2.Text = "Reset";
			this.siticoneButton2.TextRenderingHint = TextRenderingHint.AntiAlias;
			this.siticoneButton2.Click += this.siticoneButton2_Click;
			this.siticoneButton2.MouseEnter += this.siticoneButton2_MouseEnter;
			this.siticoneButton2.MouseLeave += this.siticoneButton2_MouseLeave;
			this.siticoneButton5.BackColor = Color.Transparent;
			this.siticoneButton5.BorderColor = Color.LightGray;
			this.siticoneButton5.BorderRadius = 4;
			this.siticoneButton5.BorderStyle = DashStyle.Dot;
			this.siticoneButton5.BorderThickness = 1;
			this.siticoneButton5.CheckedState.Parent = this.siticoneButton5;
			this.siticoneButton5.Cursor = Cursors.Hand;
			this.siticoneButton5.CustomImages.Parent = this.siticoneButton5;
			this.siticoneButton5.FillColor = Color.Snow;
			this.siticoneButton5.Font = new Font("Inter", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.siticoneButton5.ForeColor = Color.Black;
			this.siticoneButton5.HoveredState.Parent = this.siticoneButton5;
			this.siticoneButton5.Location = new Point(497, 219);
			this.siticoneButton5.Name = "siticoneButton5";
			this.siticoneButton5.PressedColor = Color.White;
			this.siticoneButton5.ShadowDecoration.Parent = this.siticoneButton5;
			this.siticoneButton5.Size = new Size(182, 43);
			this.siticoneButton5.TabIndex = 50;
			this.siticoneButton5.Text = "Check";
			this.siticoneButton5.TextRenderingHint = TextRenderingHint.AntiAlias;
			this.siticoneButton5.Click += this.siticoneButton5_Click;
			this.siticoneButton5.MouseEnter += this.siticoneButton2_MouseEnter;
			this.siticoneButton5.MouseLeave += this.siticoneButton2_MouseLeave;
			this.siticoneButton6.BackColor = Color.Transparent;
			this.siticoneButton6.BorderColor = Color.LightGray;
			this.siticoneButton6.BorderRadius = 4;
			this.siticoneButton6.BorderStyle = DashStyle.Dot;
			this.siticoneButton6.BorderThickness = 1;
			this.siticoneButton6.CheckedState.Parent = this.siticoneButton6;
			this.siticoneButton6.Cursor = Cursors.Hand;
			this.siticoneButton6.CustomImages.Parent = this.siticoneButton6;
			this.siticoneButton6.FillColor = Color.Snow;
			this.siticoneButton6.Font = new Font("Inter", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.siticoneButton6.ForeColor = Color.Black;
			this.siticoneButton6.HoveredState.Parent = this.siticoneButton6;
			this.siticoneButton6.Location = new Point(18, 219);
			this.siticoneButton6.Name = "siticoneButton6";
			this.siticoneButton6.PressedColor = Color.White;
			this.siticoneButton6.ShadowDecoration.Parent = this.siticoneButton6;
			this.siticoneButton6.Size = new Size(182, 43);
			this.siticoneButton6.TabIndex = 51;
			this.siticoneButton6.Text = "Check";
			this.siticoneButton6.TextRenderingHint = TextRenderingHint.AntiAlias;
			this.siticoneButton6.Click += this.siticoneButton6_Click;
			this.siticoneButton6.MouseEnter += this.siticoneButton2_MouseEnter;
			this.siticoneButton6.MouseLeave += this.siticoneButton2_MouseLeave;
			this.siticoneDragControl2.TargetControl = null;
			this.userWlob.Font = new Font("Inter", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.userWlob.Location = new Point(563, 33);
			this.userWlob.Name = "userWlob";
			this.userWlob.Size = new Size(114, 19);
			this.userWlob.TabIndex = 68;
			this.userWlob.Text = "Utente";
			this.userWlob.TextAlign = ContentAlignment.MiddleCenter;
			this.loadDefaultBtn.BorderRadius = 18;
			this.loadDefaultBtn.CheckedState.Parent = this.loadDefaultBtn;
			this.loadDefaultBtn.Cursor = Cursors.Hand;
			this.loadDefaultBtn.CustomImages.Parent = this.loadDefaultBtn;
			this.loadDefaultBtn.FillColor = Color.FromArgb(56, 128, 255);
			this.loadDefaultBtn.FillColor2 = Color.FromArgb(56, 128, 255);
			this.loadDefaultBtn.Font = new Font("SF Pro Text", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.loadDefaultBtn.ForeColor = Color.White;
			this.loadDefaultBtn.HoveredState.Parent = this.loadDefaultBtn;
			this.loadDefaultBtn.Image = (Image)componentResourceManager.GetObject("loadDefaultBtn.Image");
			this.loadDefaultBtn.ImageAlign = HorizontalAlignment.Right;
			this.loadDefaultBtn.ImageOffset = new Point(6, -1);
			this.loadDefaultBtn.Location = new Point(18, 513);
			this.loadDefaultBtn.Name = "loadDefaultBtn";
			this.loadDefaultBtn.PressedColor = Color.Transparent;
			this.loadDefaultBtn.ShadowDecoration.Parent = this.loadDefaultBtn;
			this.loadDefaultBtn.Size = new Size(326, 38);
			this.loadDefaultBtn.TabIndex = 71;
			this.loadDefaultBtn.Text = "Load Tokens";
			this.loadDefaultBtn.TextRenderingHint = TextRenderingHint.AntiAlias;
			this.loadDefaultBtn.Click += this.siticoneGradientButton1_Click;
			this.siticoneButton4.BorderRadius = 18;
			this.siticoneButton4.CheckedState.Parent = this.siticoneButton4;
			this.siticoneButton4.Cursor = Cursors.Hand;
			this.siticoneButton4.CustomImages.Parent = this.siticoneButton4;
			this.siticoneButton4.FillColor = Color.FromArgb(56, 128, 255);
			this.siticoneButton4.FillColor2 = Color.FromArgb(56, 128, 255);
			this.siticoneButton4.Font = new Font("SF Pro Text", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.siticoneButton4.ForeColor = Color.White;
			this.siticoneButton4.HoveredState.Parent = this.siticoneButton4;
			this.siticoneButton4.Image = (Image)componentResourceManager.GetObject("siticoneButton4.Image");
			this.siticoneButton4.ImageAlign = HorizontalAlignment.Right;
			this.siticoneButton4.ImageOffset = new Point(6, -1);
			this.siticoneButton4.Location = new Point(350, 513);
			this.siticoneButton4.Name = "siticoneButton4";
			this.siticoneButton4.ShadowDecoration.Parent = this.siticoneButton4;
			this.siticoneButton4.Size = new Size(329, 38);
			this.siticoneButton4.TabIndex = 72;
			this.siticoneButton4.Text = "Load Proxies";
			this.siticoneButton4.TextRenderingHint = TextRenderingHint.AntiAlias;
			this.siticoneButton4.Click += this.siticoneGradientButton2_Click;
			this.siticoneButton7.BorderRadius = 18;
			this.siticoneButton7.CheckedState.Parent = this.siticoneButton7;
			this.siticoneButton7.Cursor = Cursors.Hand;
			this.siticoneButton7.CustomImages.Parent = this.siticoneButton7;
			this.siticoneButton7.FillColor = Color.DodgerBlue;
			this.siticoneButton7.FillColor2 = Color.DeepSkyBlue;
			this.siticoneButton7.Font = new Font("SF Pro Text", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.siticoneButton7.ForeColor = Color.White;
			this.siticoneButton7.HoveredState.Parent = this.siticoneButton7;
			this.siticoneButton7.Image = (Image)componentResourceManager.GetObject("siticoneButton7.Image");
			this.siticoneButton7.ImageAlign = HorizontalAlignment.Right;
			this.siticoneButton7.ImageOffset = new Point(6, -1);
			this.siticoneButton7.Location = new Point(218, 469);
			this.siticoneButton7.Name = "siticoneButton7";
			this.siticoneButton7.ShadowDecoration.Parent = this.siticoneButton7;
			this.siticoneButton7.Size = new Size(258, 38);
			this.siticoneButton7.TabIndex = 73;
			this.siticoneButton7.Text = "Logger";
			this.siticoneButton7.TextRenderingHint = TextRenderingHint.AntiAlias;
			this.siticoneButton7.Click += this.siticoneGradientButton1_Click_1;
			this.pictureBox1.Image = (Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new Point(332, 320);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(51, 53);
			this.pictureBox1.TabIndex = 75;
			this.pictureBox1.TabStop = false;
			this.label4.AutoSize = true;
			this.label4.Font = new Font("Inter", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label4.Location = new Point(180, 376);
			this.label4.Name = "label4";
			this.label4.Size = new Size(365, 19);
			this.label4.TabIndex = 76;
			this.label4.Text = "BlackSpammer XS V4 has been discontinued.";
			this.label7.AutoSize = true;
			this.label7.Font = new Font("JetBrains Mono", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label7.Location = new Point(208, 402);
			this.label7.Name = "label7";
			this.label7.Size = new Size(296, 34);
			this.label7.TabIndex = 77;
			this.label7.Text = "This is an unlocked developer copy. \r\n              (v17.1X)";
			this.label7.TextAlign = ContentAlignment.MiddleLeft;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.label7);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.siticoneButton7);
			base.Controls.Add(this.siticoneButton4);
			base.Controls.Add(this.loadDefaultBtn);
			base.Controls.Add(this.userWlob);
			base.Controls.Add(this.siticoneButton6);
			base.Controls.Add(this.siticoneButton5);
			base.Controls.Add(this.siticoneButton2);
			base.Controls.Add(this.siticoneButton1);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.hasJMFont);
			base.Controls.Add(this.hasLive);
			base.Controls.Add(this.emailsCount);
			base.Controls.Add(this.proxiesCount);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Name = "Dashboard";
			base.Size = new Size(695, 568);
			base.Load += this.Dashboard_Load;
			base.MouseEnter += this.siticoneButton2_MouseEnter;
			((ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040001AD RID: 429
		private IContainer components = null;

		// Token: 0x040001AE RID: 430
		private Label label1;

		// Token: 0x040001AF RID: 431
		private SiticoneDragControl siticoneDragControl1;

		// Token: 0x040001B0 RID: 432
		private Label emailsCount;

		// Token: 0x040001B1 RID: 433
		private Label proxiesCount;

		// Token: 0x040001B2 RID: 434
		private Label label3;

		// Token: 0x040001B3 RID: 435
		private Label label2;

		// Token: 0x040001B4 RID: 436
		private Label label9;

		// Token: 0x040001B5 RID: 437
		private Label label8;

		// Token: 0x040001B6 RID: 438
		private SiticoneCustomCheckBox hasJMFont;

		// Token: 0x040001B7 RID: 439
		private SiticoneCustomCheckBox hasLive;

		// Token: 0x040001B8 RID: 440
		private SiticoneButton siticoneButton2;

		// Token: 0x040001B9 RID: 441
		private SiticoneButton siticoneButton1;

		// Token: 0x040001BA RID: 442
		private SiticoneButton siticoneButton6;

		// Token: 0x040001BB RID: 443
		private SiticoneButton siticoneButton5;

		// Token: 0x040001BC RID: 444
		private SiticoneDragControl siticoneDragControl2;

		// Token: 0x040001BD RID: 445
		private Label userWlob;

		// Token: 0x040001BE RID: 446
		private SiticoneGradientButton siticoneButton4;

		// Token: 0x040001BF RID: 447
		private SiticoneGradientButton loadDefaultBtn;

		// Token: 0x040001C0 RID: 448
		private SiticoneGradientButton siticoneButton7;

		// Token: 0x040001C1 RID: 449
		private Label label7;

		// Token: 0x040001C2 RID: 450
		private Label label4;

		// Token: 0x040001C3 RID: 451
		private PictureBox pictureBox1;
	}
}
