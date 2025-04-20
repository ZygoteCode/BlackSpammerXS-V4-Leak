using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlackSpammerXS.Properties;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Suite;

namespace BlackSpammerXS;

public class Dashboard : UserControl
{
	private IContainer components = null;

	private Label label1;

	private SiticoneDragControl siticoneDragControl1;

	private Label emailsCount;

	private Label proxiesCount;

	private Label label3;

	private Label label2;

	private Label label9;

	private Label label8;

	private SiticoneCustomCheckBox hasJMFont;

	private SiticoneCustomCheckBox hasLive;

	private SiticoneButton siticoneButton2;

	private SiticoneButton siticoneButton1;

	private SiticoneButton siticoneButton6;

	private SiticoneButton siticoneButton5;

	private SiticoneDragControl siticoneDragControl2;

	private Label userWlob;

	private SiticoneGradientButton siticoneButton4;

	private SiticoneGradientButton loadDefaultBtn;

	private SiticoneGradientButton siticoneButton7;

	private Label label7;

	private Label label4;

	private PictureBox pictureBox1;

	public Dashboard()
	{
		InitializeComponent();
	}

	private void Dashboard_Load(object sender, EventArgs e)
	{
		userWlob.Text = Settings.Default._U ?? "";
		ImpostazioniGlobali._stmodeCallback = delegate(bool a)
		{
			StreamerMode(a);
		};
		ImpostazioniGlobali._bridgeLogPerform.Add(delegate(int a, int b, object[] i)
		{
			if (a == 3699 && b == 1601)
			{
				proxiesCount.Text = "Testing";
			}
		});
	}

	public void StreamerMode(bool _)
	{
	}

	public void Dark()
	{
		Color backColor = Color.FromArgb(44, 47, 51);
		BackColor = backColor;
		Color dimGray = Color.DimGray;
		try
		{
			List<SiticoneButton> list = new List<SiticoneButton>();
			list.Add(siticoneButton1);
			list.Add(siticoneButton2);
			list.Add(siticoneButton5);
			list.Add(siticoneButton6);
			foreach (SiticoneButton item in list)
			{
				try
				{
					((Control)(object)item).ForeColor = Color.White;
					item.FillColor = dimGray;
					item.BorderColor = Color.Gray;
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

	internal void SetTokens(int t)
	{
		Control.CheckForIllegalCrossThreadCalls = false;
		proxiesCount.Text = t.ToString() ?? "";
	}

	internal void SetProxies(int a)
	{
		Control.CheckForIllegalCrossThreadCalls = false;
		emailsCount.Text = a.ToString() ?? "";
	}

	private void siticoneButton5_Click(object sender, EventArgs e)
	{
		if (ImpostazioniGlobali.Proxies == null)
		{
			MessageBox.Show("There are no proxies");
			return;
		}
		ThreadPool.GetMaxThreads(out var _, out var completionPortThreads);
		ThreadPool.SetMinThreads(completionPortThreads - 1, completionPortThreads - 1);
		ImpostazioniGlobali.StartLog();
		ImpostazioniGlobali.Log("Check Proxies => Sto controllando tutti i proxies..");
		Random random = new Random();
		new Thread((ParameterizedThreadStart)delegate
		{
			try
			{
				foreach (string proxy in ImpostazioniGlobali.Proxies)
				{
					new Thread((ParameterizedThreadStart)async delegate
					{
						try
						{
							HttpClientHandler handler = new HttpClientHandler();
							handler.PreAuthenticate = true;
							handler.UseProxy = true;
							handler.Proxy = new WebProxy(proxy.Split(':')[0], int.Parse(proxy.Split(':')[1]));
							HttpClient http = new HttpClient((HttpMessageHandler)(object)handler);
							HttpRequestMessage request = new HttpRequestMessage
							{
								RequestUri = new Uri("https://discord.com"),
								Method = HttpMethod.Get
							};
							bool ab = true;
							int mst = 0;
							Task.Run(delegate
							{
								while (ab && mst != 10000 && ab && mst < 10000)
								{
									mst++;
									Thread.Sleep(1);
								}
							});
							await (await http.SendAsync(request)).Content.ReadAsStringAsync();
							ab = true;
							ImpostazioniGlobali.Log(proxy + " ->  Check => Success. Proxy is alive and working. Took " + mst + "ms");
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
			catch (Exception)
			{
			}
		}).Start();
	}

	private void siticoneButton3_Click(object sender, EventArgs e)
	{
		try
		{
			tryLaunchBlackGenLauncher();
		}
		catch (Exception)
		{
		}
	}

	public void tryLaunchBlackGenLauncher()
	{
		MessageBox.Show("Questa funzione non è più disponibile dalla versione 13X. Avvialo manualmente", "Discontinued");
	}

	private OpenFileDialog newFileLoader(string title, string filter)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = filter;
		openFileDialog.FileName = "";
		openFileDialog.Title = title;
		return openFileDialog;
	}

	private void siticoneButton4_Click(object sender, EventArgs e)
	{
		OpenFileDialog open = newFileLoader("Proxies: Importa alcuni proxies HTTP/HTTPS", "Txt Files (*.txt)|*.txt");
		if (open.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		Task.Run(delegate
		{
			using StreamReader streamReader = new StreamReader(open.FileName);
			List<string> list = new List<string>();
			string item;
			while ((item = streamReader.ReadLine()) != null)
			{
				list.Add(item);
			}
			ImpostazioniGlobali.Proxies = list;
			Control.CheckForIllegalCrossThreadCalls = false;
			emailsCount.Text = list.Count.ToString() ?? "";
			try
			{
				Settings.Default.lastProxies = open.FileName;
				Settings.Default.Save();
			}
			catch (Exception)
			{
			}
		});
	}

	private async void siticoneButton1_Click(object sender, EventArgs e)
	{
		((Control)(object)siticoneButton1).Enabled = false;
		((Control)(object)siticoneButton1).Text = "Resetting..";
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
		emailsCount.Text = "0";
		((Control)(object)siticoneButton1).Enabled = true;
		((Control)(object)siticoneButton1).Text = "Reset";
	}

	private async void siticoneButton2_Click(object sender, EventArgs e)
	{
		((Control)(object)siticoneButton2).Enabled = false;
		((Control)(object)siticoneButton2).Text = "Resetting..";
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
		proxiesCount.Text = "0";
		((Control)(object)siticoneButton2).Enabled = true;
		((Control)(object)siticoneButton2).Text = "Reset";
	}

	private void loadDefaultBtn_Click(object sender, EventArgs e)
	{
		OpenFileDialog open = newFileLoader("Tokens: Importa tokens", "Txt Files (*.txt)|*.txt");
		if (open.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		Task.Run(delegate
		{
			using StreamReader streamReader = new StreamReader(open.FileName);
			List<string> list = new List<string>();
			string item;
			while ((item = streamReader.ReadLine()) != null)
			{
				list.Add(item);
			}
			ImpostazioniGlobali.Tokens = list;
			Control.CheckForIllegalCrossThreadCalls = false;
			proxiesCount.Text = list.Count.ToString() ?? "";
			try
			{
				Settings.Default.lastTokens = open.FileName;
				Settings.Default.Save();
			}
			catch (Exception)
			{
			}
		});
	}

	private async void siticoneButton7_Click(object sender, EventArgs e)
	{
		((Control)(object)siticoneButton7).Enabled = false;
		((Control)(object)siticoneButton7).Text = "Loading..";
		ImpostazioniGlobali.StartLog();
		await Task.Delay(50);
		((Control)(object)siticoneButton7).Enabled = true;
		((Control)(object)siticoneButton7).Text = "Logger";
	}

	private async void siticoneButton6_Click(object sender, EventArgs e)
	{
		if (ImpostazioniGlobali.Tokens == null || ImpostazioniGlobali.Proxies == null)
		{
			MessageBox.Show("There are no tokens or no proxies");
			return;
		}
		((Control)(object)siticoneButton6).Enabled = false;
		((Control)(object)siticoneButton6).Text = "Checking...";
		ThreadPool.GetMaxThreads(out var _, out var o);
		ThreadPool.SetMinThreads(o - 1, o - 1);
		Random random = new Random();
		List<string> proxies = ImpostazioniGlobali.Proxies;
		new Thread((ParameterizedThreadStart)delegate
		{
			ImpostazioniGlobali.StartLog();
			try
			{
				foreach (string t in ImpostazioniGlobali.Tokens)
				{
					new Thread((ParameterizedThreadStart)async delegate
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
							handler.Proxy = new WebProxy(proxy.Split(':')[0], int.Parse(proxy.Split(':')[1]));
							HttpClient http = new HttpClient((HttpMessageHandler)(object)handler);
							HttpRequestMessage val = new HttpRequestMessage
							{
								RequestUri = new Uri("https://discord.com/api/v9/users/@me/library"),
								Method = HttpMethod.Get
							};
							((HttpHeaders)val.Headers).Add("Authorization", t);
							HttpRequestMessage request = val;
							HttpResponseMessage req = await http.SendAsync(request);
							string _ = await req.Content.ReadAsStringAsync();
							ImpostazioniGlobali.Log(proxy + " -> (" + t + ") Check => " + _);
							if (_.Contains("401: Unauthorized"))
							{
								try
								{
									ImpostazioniGlobali.Tokens.Remove(t);
									proxiesCount.Text = ImpostazioniGlobali.Tokens.Count.ToString() ?? "";
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
									proxiesCount.Text = ImpostazioniGlobali.Tokens.Count.ToString() ?? "";
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
									proxiesCount.Text = ImpostazioniGlobali.Tokens.Count.ToString() ?? "";
								}
								catch
								{
								}
							}
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
			catch (Exception)
			{
			}
		}).Start();
		await Task.Delay(300);
		((Control)(object)siticoneButton6).Enabled = true;
		((Control)(object)siticoneButton6).Text = "Check";
	}

	private void hasVerifyDie_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void hasVerifyDie_Click(object sender, EventArgs e)
	{
	}

	private void siticoneButton7_MouseEnter(object sender, EventArgs e)
	{
		siticoneButton7.BorderThickness = 2;
	}

	private void siticoneButton7_MouseLeave(object sender, EventArgs e)
	{
		siticoneButton7.BorderThickness = 1;
	}

	private void siticoneButton2_MouseEnter(object sender, EventArgs e)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Expected O, but got Unknown
		try
		{
			SiticoneButton val = (SiticoneButton)sender;
			if (val != null)
			{
				val.BorderThickness = 1;
			}
		}
		catch (Exception)
		{
		}
	}

	private void siticoneButton2_MouseLeave(object sender, EventArgs e)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Expected O, but got Unknown
		try
		{
			SiticoneButton val = (SiticoneButton)sender;
			if (val != null)
			{
				val.BorderThickness = 1;
			}
		}
		catch (Exception)
		{
		}
	}

	private void siticoneTextBox1_MouseEnter(object sender, EventArgs e)
	{
	}

	private void siticoneTextBox1_MouseLeave(object sender, EventArgs e)
	{
	}

	private void hasLive_CheckedChanged(object sender, EventArgs e)
	{
		ImpostazioniGlobali.AlwaysOn = hasLive.Checked;
	}

	private void siticoneTextBox1_TextChanged(object sender, EventArgs e)
	{
	}

	private void label6_Click(object sender, EventArgs e)
	{
	}

	private void hasEmbed_Click(object sender, EventArgs e)
	{
	}

	private void hasEmbed_CheckedChanged(object sender, EventArgs e)
	{
		ImpostazioniGlobali.LOG_UseNewFont = hasJMFont.Checked;
	}

	private void label5_Click(object sender, EventArgs e)
	{
	}

	private void siticoneGradientButton1_Click(object sender, EventArgs e)
	{
		loadDefaultBtn_Click(sender, e);
	}

	private void siticoneGradientButton2_Click(object sender, EventArgs e)
	{
		siticoneButton4_Click(sender, e);
	}

	private void siticoneGradientButton1_Click_1(object sender, EventArgs e)
	{
		siticoneButton7_Click(sender, e);
	}

	private void siticoneGradientButton2_Click_1(object sender, EventArgs e)
	{
		siticoneButton3_Click(sender, e);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlackSpammerXS.Dashboard));
		this.label1 = new System.Windows.Forms.Label();
		this.siticoneDragControl1 = new SiticoneDragControl(this.components);
		this.emailsCount = new System.Windows.Forms.Label();
		this.proxiesCount = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.label9 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.hasJMFont = new SiticoneCustomCheckBox();
		this.hasLive = new SiticoneCustomCheckBox();
		this.siticoneButton1 = new SiticoneButton();
		this.siticoneButton2 = new SiticoneButton();
		this.siticoneButton5 = new SiticoneButton();
		this.siticoneButton6 = new SiticoneButton();
		this.siticoneDragControl2 = new SiticoneDragControl(this.components);
		this.userWlob = new System.Windows.Forms.Label();
		this.loadDefaultBtn = new SiticoneGradientButton();
		this.siticoneButton4 = new SiticoneGradientButton();
		this.siticoneButton7 = new SiticoneGradientButton();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.label4 = new System.Windows.Forms.Label();
		this.label7 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Inter", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(13, 32);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(123, 25);
		this.label1.TabIndex = 0;
		this.label1.Text = "Dashboard";
		this.siticoneDragControl1.TargetControl = this;
		this.emailsCount.Font = new System.Drawing.Font("Inter Black", 9.749999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.emailsCount.Location = new System.Drawing.Point(517, 134);
		this.emailsCount.Name = "emailsCount";
		this.emailsCount.Size = new System.Drawing.Size(144, 17);
		this.emailsCount.TabIndex = 38;
		this.emailsCount.Text = "0";
		this.emailsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.proxiesCount.Font = new System.Drawing.Font("Inter Black", 9.749999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.proxiesCount.Location = new System.Drawing.Point(21, 135);
		this.proxiesCount.Name = "proxiesCount";
		this.proxiesCount.Size = new System.Drawing.Size(179, 16);
		this.proxiesCount.TabIndex = 37;
		this.proxiesCount.Text = "0";
		this.proxiesCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("Inter Light", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.Location = new System.Drawing.Point(560, 106);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(60, 19);
		this.label3.TabIndex = 36;
		this.label3.Text = "Proxies";
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("Inter Light", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.Location = new System.Drawing.Point(81, 106);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(60, 19);
		this.label2.TabIndex = 35;
		this.label2.Text = "Tokens";
		this.label9.AutoSize = true;
		this.label9.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label9.Location = new System.Drawing.Point(295, 198);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(117, 14);
		this.label9.TabIndex = 46;
		this.label9.Text = "Always-on Logger";
		this.label8.AutoSize = true;
		this.label8.Font = new System.Drawing.Font("SF Pro Text", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label8.Location = new System.Drawing.Point(295, 220);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(136, 14);
		this.label8.TabIndex = 45;
		this.label8.Text = "Compact Logger Font";
		((System.Windows.Forms.Control)(object)this.hasJMFont).BackColor = System.Drawing.Color.Transparent;
		this.hasJMFont.Checked = true;
		this.hasJMFont.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasJMFont.CheckedState.BorderRadius = 2;
		this.hasJMFont.CheckedState.BorderThickness = 0;
		this.hasJMFont.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasJMFont.CheckedState.Parent = (CustomCheckBox)(object)this.hasJMFont;
		this.hasJMFont.CheckState = System.Windows.Forms.CheckState.Checked;
		((System.Windows.Forms.Control)(object)this.hasJMFont).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.hasJMFont).Location = new System.Drawing.Point(277, 219);
		((System.Windows.Forms.Control)(object)this.hasJMFont).Name = "hasJMFont";
		this.hasJMFont.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.hasJMFont;
		((System.Windows.Forms.Control)(object)this.hasJMFont).Size = new System.Drawing.Size(15, 15);
		((System.Windows.Forms.Control)(object)this.hasJMFont).TabIndex = 44;
		this.hasJMFont.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasJMFont.UncheckedState.BorderRadius = 2;
		this.hasJMFont.UncheckedState.BorderThickness = 0;
		this.hasJMFont.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasJMFont.UncheckedState.Parent = (CustomCheckBox)(object)this.hasJMFont;
		((CustomCheckBox)this.hasJMFont).CheckedChanged += new System.EventHandler(hasEmbed_CheckedChanged);
		((System.Windows.Forms.Control)(object)this.hasJMFont).Click += new System.EventHandler(hasEmbed_Click);
		this.hasLive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasLive.CheckedState.BorderRadius = 2;
		this.hasLive.CheckedState.BorderThickness = 0;
		this.hasLive.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.hasLive.CheckedState.Parent = (CustomCheckBox)(object)this.hasLive;
		((System.Windows.Forms.Control)(object)this.hasLive).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)(object)this.hasLive).Location = new System.Drawing.Point(277, 198);
		((System.Windows.Forms.Control)(object)this.hasLive).Name = "hasLive";
		this.hasLive.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.hasLive;
		((System.Windows.Forms.Control)(object)this.hasLive).Size = new System.Drawing.Size(15, 15);
		((System.Windows.Forms.Control)(object)this.hasLive).TabIndex = 43;
		this.hasLive.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasLive.UncheckedState.BorderRadius = 2;
		this.hasLive.UncheckedState.BorderThickness = 0;
		this.hasLive.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
		this.hasLive.UncheckedState.Parent = (CustomCheckBox)(object)this.hasLive;
		((CustomCheckBox)this.hasLive).CheckedChanged += new System.EventHandler(hasLive_CheckedChanged);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).BackColor = System.Drawing.Color.Transparent;
		this.siticoneButton1.BorderColor = System.Drawing.Color.LightGray;
		this.siticoneButton1.BorderRadius = 4;
		this.siticoneButton1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
		this.siticoneButton1.BorderThickness = 1;
		this.siticoneButton1.CheckedState.Parent = (CustomButtonBase)(object)this.siticoneButton1;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneButton1.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneButton1;
		this.siticoneButton1.FillColor = System.Drawing.Color.Snow;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Font = new System.Drawing.Font("Inter", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).ForeColor = System.Drawing.Color.Black;
		this.siticoneButton1.HoveredState.Parent = (CustomButtonBase)(object)this.siticoneButton1;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Location = new System.Drawing.Point(497, 172);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Name = "siticoneButton1";
		this.siticoneButton1.PressedColor = System.Drawing.Color.White;
		this.siticoneButton1.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneButton1;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Size = new System.Drawing.Size(182, 41);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).TabIndex = 47;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Text = "Reset";
		this.siticoneButton1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.siticoneButton1).Click += new System.EventHandler(siticoneButton1_Click);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).MouseEnter += new System.EventHandler(siticoneButton2_MouseEnter);
		((System.Windows.Forms.Control)(object)this.siticoneButton1).MouseLeave += new System.EventHandler(siticoneButton2_MouseLeave);
		((System.Windows.Forms.Control)(object)this.siticoneButton2).BackColor = System.Drawing.Color.Transparent;
		this.siticoneButton2.BorderColor = System.Drawing.Color.LightGray;
		this.siticoneButton2.BorderRadius = 4;
		this.siticoneButton2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
		this.siticoneButton2.BorderThickness = 1;
		this.siticoneButton2.CheckedState.Parent = (CustomButtonBase)(object)this.siticoneButton2;
		((System.Windows.Forms.Control)(object)this.siticoneButton2).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneButton2.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneButton2;
		this.siticoneButton2.FillColor = System.Drawing.Color.Snow;
		((System.Windows.Forms.Control)(object)this.siticoneButton2).Font = new System.Drawing.Font("Inter", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneButton2).ForeColor = System.Drawing.Color.Black;
		this.siticoneButton2.HoveredState.Parent = (CustomButtonBase)(object)this.siticoneButton2;
		((System.Windows.Forms.Control)(object)this.siticoneButton2).Location = new System.Drawing.Point(18, 172);
		((System.Windows.Forms.Control)(object)this.siticoneButton2).Name = "siticoneButton2";
		this.siticoneButton2.PressedColor = System.Drawing.Color.White;
		this.siticoneButton2.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneButton2;
		((System.Windows.Forms.Control)(object)this.siticoneButton2).Size = new System.Drawing.Size(182, 41);
		((System.Windows.Forms.Control)(object)this.siticoneButton2).TabIndex = 48;
		((System.Windows.Forms.Control)(object)this.siticoneButton2).Text = "Reset";
		this.siticoneButton2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.siticoneButton2).Click += new System.EventHandler(siticoneButton2_Click);
		((System.Windows.Forms.Control)(object)this.siticoneButton2).MouseEnter += new System.EventHandler(siticoneButton2_MouseEnter);
		((System.Windows.Forms.Control)(object)this.siticoneButton2).MouseLeave += new System.EventHandler(siticoneButton2_MouseLeave);
		((System.Windows.Forms.Control)(object)this.siticoneButton5).BackColor = System.Drawing.Color.Transparent;
		this.siticoneButton5.BorderColor = System.Drawing.Color.LightGray;
		this.siticoneButton5.BorderRadius = 4;
		this.siticoneButton5.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
		this.siticoneButton5.BorderThickness = 1;
		this.siticoneButton5.CheckedState.Parent = (CustomButtonBase)(object)this.siticoneButton5;
		((System.Windows.Forms.Control)(object)this.siticoneButton5).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneButton5.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneButton5;
		this.siticoneButton5.FillColor = System.Drawing.Color.Snow;
		((System.Windows.Forms.Control)(object)this.siticoneButton5).Font = new System.Drawing.Font("Inter", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneButton5).ForeColor = System.Drawing.Color.Black;
		this.siticoneButton5.HoveredState.Parent = (CustomButtonBase)(object)this.siticoneButton5;
		((System.Windows.Forms.Control)(object)this.siticoneButton5).Location = new System.Drawing.Point(497, 219);
		((System.Windows.Forms.Control)(object)this.siticoneButton5).Name = "siticoneButton5";
		this.siticoneButton5.PressedColor = System.Drawing.Color.White;
		this.siticoneButton5.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneButton5;
		((System.Windows.Forms.Control)(object)this.siticoneButton5).Size = new System.Drawing.Size(182, 43);
		((System.Windows.Forms.Control)(object)this.siticoneButton5).TabIndex = 50;
		((System.Windows.Forms.Control)(object)this.siticoneButton5).Text = "Check";
		this.siticoneButton5.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.siticoneButton5).Click += new System.EventHandler(siticoneButton5_Click);
		((System.Windows.Forms.Control)(object)this.siticoneButton5).MouseEnter += new System.EventHandler(siticoneButton2_MouseEnter);
		((System.Windows.Forms.Control)(object)this.siticoneButton5).MouseLeave += new System.EventHandler(siticoneButton2_MouseLeave);
		((System.Windows.Forms.Control)(object)this.siticoneButton6).BackColor = System.Drawing.Color.Transparent;
		this.siticoneButton6.BorderColor = System.Drawing.Color.LightGray;
		this.siticoneButton6.BorderRadius = 4;
		this.siticoneButton6.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
		this.siticoneButton6.BorderThickness = 1;
		this.siticoneButton6.CheckedState.Parent = (CustomButtonBase)(object)this.siticoneButton6;
		((System.Windows.Forms.Control)(object)this.siticoneButton6).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneButton6.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneButton6;
		this.siticoneButton6.FillColor = System.Drawing.Color.Snow;
		((System.Windows.Forms.Control)(object)this.siticoneButton6).Font = new System.Drawing.Font("Inter", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneButton6).ForeColor = System.Drawing.Color.Black;
		this.siticoneButton6.HoveredState.Parent = (CustomButtonBase)(object)this.siticoneButton6;
		((System.Windows.Forms.Control)(object)this.siticoneButton6).Location = new System.Drawing.Point(18, 219);
		((System.Windows.Forms.Control)(object)this.siticoneButton6).Name = "siticoneButton6";
		this.siticoneButton6.PressedColor = System.Drawing.Color.White;
		this.siticoneButton6.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneButton6;
		((System.Windows.Forms.Control)(object)this.siticoneButton6).Size = new System.Drawing.Size(182, 43);
		((System.Windows.Forms.Control)(object)this.siticoneButton6).TabIndex = 51;
		((System.Windows.Forms.Control)(object)this.siticoneButton6).Text = "Check";
		this.siticoneButton6.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.siticoneButton6).Click += new System.EventHandler(siticoneButton6_Click);
		((System.Windows.Forms.Control)(object)this.siticoneButton6).MouseEnter += new System.EventHandler(siticoneButton2_MouseEnter);
		((System.Windows.Forms.Control)(object)this.siticoneButton6).MouseLeave += new System.EventHandler(siticoneButton2_MouseLeave);
		this.siticoneDragControl2.TargetControl = null;
		this.userWlob.Font = new System.Drawing.Font("Inter", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.userWlob.Location = new System.Drawing.Point(563, 33);
		this.userWlob.Name = "userWlob";
		this.userWlob.Size = new System.Drawing.Size(114, 19);
		this.userWlob.TabIndex = 68;
		this.userWlob.Text = "Utente";
		this.userWlob.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.loadDefaultBtn.BorderRadius = 18;
		((ButtonState)this.loadDefaultBtn.CheckedState).Parent = (CustomButtonBase)(object)this.loadDefaultBtn;
		((System.Windows.Forms.Control)(object)this.loadDefaultBtn).Cursor = System.Windows.Forms.Cursors.Hand;
		this.loadDefaultBtn.CustomImages.Parent = (CustomButtonBase)(object)this.loadDefaultBtn;
		this.loadDefaultBtn.FillColor = System.Drawing.Color.FromArgb(56, 128, 255);
		this.loadDefaultBtn.FillColor2 = System.Drawing.Color.FromArgb(56, 128, 255);
		((System.Windows.Forms.Control)(object)this.loadDefaultBtn).Font = new System.Drawing.Font("SF Pro Text", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.loadDefaultBtn).ForeColor = System.Drawing.Color.White;
		((ButtonState)this.loadDefaultBtn.HoveredState).Parent = (CustomButtonBase)(object)this.loadDefaultBtn;
		this.loadDefaultBtn.Image = (System.Drawing.Image)resources.GetObject("loadDefaultBtn.Image");
		this.loadDefaultBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.loadDefaultBtn.ImageOffset = new System.Drawing.Point(6, -1);
		((System.Windows.Forms.Control)(object)this.loadDefaultBtn).Location = new System.Drawing.Point(18, 513);
		((System.Windows.Forms.Control)(object)this.loadDefaultBtn).Name = "loadDefaultBtn";
		this.loadDefaultBtn.PressedColor = System.Drawing.Color.Transparent;
		this.loadDefaultBtn.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.loadDefaultBtn;
		((System.Windows.Forms.Control)(object)this.loadDefaultBtn).Size = new System.Drawing.Size(326, 38);
		((System.Windows.Forms.Control)(object)this.loadDefaultBtn).TabIndex = 71;
		((System.Windows.Forms.Control)(object)this.loadDefaultBtn).Text = "Load Tokens";
		this.loadDefaultBtn.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.loadDefaultBtn).Click += new System.EventHandler(siticoneGradientButton1_Click);
		this.siticoneButton4.BorderRadius = 18;
		((ButtonState)this.siticoneButton4.CheckedState).Parent = (CustomButtonBase)(object)this.siticoneButton4;
		((System.Windows.Forms.Control)(object)this.siticoneButton4).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneButton4.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneButton4;
		this.siticoneButton4.FillColor = System.Drawing.Color.FromArgb(56, 128, 255);
		this.siticoneButton4.FillColor2 = System.Drawing.Color.FromArgb(56, 128, 255);
		((System.Windows.Forms.Control)(object)this.siticoneButton4).Font = new System.Drawing.Font("SF Pro Text", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneButton4).ForeColor = System.Drawing.Color.White;
		((ButtonState)this.siticoneButton4.HoveredState).Parent = (CustomButtonBase)(object)this.siticoneButton4;
		this.siticoneButton4.Image = (System.Drawing.Image)resources.GetObject("siticoneButton4.Image");
		this.siticoneButton4.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.siticoneButton4.ImageOffset = new System.Drawing.Point(6, -1);
		((System.Windows.Forms.Control)(object)this.siticoneButton4).Location = new System.Drawing.Point(350, 513);
		((System.Windows.Forms.Control)(object)this.siticoneButton4).Name = "siticoneButton4";
		this.siticoneButton4.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneButton4;
		((System.Windows.Forms.Control)(object)this.siticoneButton4).Size = new System.Drawing.Size(329, 38);
		((System.Windows.Forms.Control)(object)this.siticoneButton4).TabIndex = 72;
		((System.Windows.Forms.Control)(object)this.siticoneButton4).Text = "Load Proxies";
		this.siticoneButton4.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.siticoneButton4).Click += new System.EventHandler(siticoneGradientButton2_Click);
		this.siticoneButton7.BorderRadius = 18;
		((ButtonState)this.siticoneButton7.CheckedState).Parent = (CustomButtonBase)(object)this.siticoneButton7;
		((System.Windows.Forms.Control)(object)this.siticoneButton7).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneButton7.CustomImages.Parent = (CustomButtonBase)(object)this.siticoneButton7;
		this.siticoneButton7.FillColor = System.Drawing.Color.DodgerBlue;
		this.siticoneButton7.FillColor2 = System.Drawing.Color.DeepSkyBlue;
		((System.Windows.Forms.Control)(object)this.siticoneButton7).Font = new System.Drawing.Font("SF Pro Text", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.Control)(object)this.siticoneButton7).ForeColor = System.Drawing.Color.White;
		((ButtonState)this.siticoneButton7.HoveredState).Parent = (CustomButtonBase)(object)this.siticoneButton7;
		this.siticoneButton7.Image = (System.Drawing.Image)resources.GetObject("siticoneButton7.Image");
		this.siticoneButton7.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.siticoneButton7.ImageOffset = new System.Drawing.Point(6, -1);
		((System.Windows.Forms.Control)(object)this.siticoneButton7).Location = new System.Drawing.Point(218, 469);
		((System.Windows.Forms.Control)(object)this.siticoneButton7).Name = "siticoneButton7";
		this.siticoneButton7.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.siticoneButton7;
		((System.Windows.Forms.Control)(object)this.siticoneButton7).Size = new System.Drawing.Size(258, 38);
		((System.Windows.Forms.Control)(object)this.siticoneButton7).TabIndex = 73;
		((System.Windows.Forms.Control)(object)this.siticoneButton7).Text = "Logger";
		this.siticoneButton7.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		((System.Windows.Forms.Control)(object)this.siticoneButton7).Click += new System.EventHandler(siticoneGradientButton1_Click_1);
		this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
		this.pictureBox1.Location = new System.Drawing.Point(332, 320);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(51, 53);
		this.pictureBox1.TabIndex = 75;
		this.pictureBox1.TabStop = false;
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("Inter", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.Location = new System.Drawing.Point(180, 376);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(365, 19);
		this.label4.TabIndex = 76;
		this.label4.Text = "BlackSpammer XS V4 has been discontinued.";
		this.label7.AutoSize = true;
		this.label7.Font = new System.Drawing.Font("JetBrains Mono", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label7.Location = new System.Drawing.Point(208, 402);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(296, 34);
		this.label7.TabIndex = 77;
		this.label7.Text = "This is an unlocked developer copy. \r\n              (v17.1X)";
		this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.Controls.Add(this.label7);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.pictureBox1);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneButton7);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneButton4);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.loadDefaultBtn);
		base.Controls.Add(this.userWlob);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneButton6);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneButton5);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneButton2);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneButton1);
		base.Controls.Add(this.label9);
		base.Controls.Add(this.label8);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.hasJMFont);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.hasLive);
		base.Controls.Add(this.emailsCount);
		base.Controls.Add(this.proxiesCount);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Name = "Dashboard";
		base.Size = new System.Drawing.Size(695, 568);
		base.Load += new System.EventHandler(Dashboard_Load);
		base.MouseEnter += new System.EventHandler(siticoneButton2_MouseEnter);
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
