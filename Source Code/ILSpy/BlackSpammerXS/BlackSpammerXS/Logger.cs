using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Suite;

namespace BlackSpammerXS;

public class Logger : Form
{
	private Thread ch_queue_t;

	private bool q_c_l = true;

	private Dictionary<int, string> queue_w = new Dictionary<int, string>();

	private IContainer components = null;

	private SiticoneTextBox logBox;

	private SiticoneDragControl siticoneDragControl1;

	private SiticoneElipse siticoneElipse1;

	private SiticoneDragControl siticoneDragControl2;

	private SiticoneImageButton siticoneImageButton3;

	private SiticoneImageButton siticoneImageButton2;

	private SiticoneImageButton siticoneImageButton1;

	private SiticoneShadowForm siticoneShadowForm1;

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = base.CreateParams;
			createParams.Style |= 131072;
			return createParams;
		}
	}

	public Logger(bool _mode, bool _streamer)
	{
		InitializeComponent();
		if (_mode)
		{
			Color fillColor = (BackColor = Color.FromArgb(44, 47, 51));
			logBox.FillColor = fillColor;
			((TextBox)logBox).ForeColor = Color.White;
		}
		if (!ImpostazioniGlobali.LOG_UseNewFont)
		{
			try
			{
				((TextBox)logBox).Font = new Font(new FontFamily("SF Pro Text"), 9.75f, FontStyle.Regular);
			}
			catch (Exception)
			{
			}
		}
	}

	protected override void WndProc(ref Message m)
	{
		int msg = m.Msg;
		int num = msg;
		if (num == 132)
		{
			base.WndProc(ref m);
			if ((int)m.Result != 1)
			{
				return;
			}
			Point p = new Point(m.LParam.ToInt32());
			Point point = PointToClient(p);
			if (point.Y <= 10)
			{
				if (point.X <= 10)
				{
					m.Result = (IntPtr)13;
				}
				else if (point.X < base.Size.Width - 10)
				{
					m.Result = (IntPtr)12;
				}
				else
				{
					m.Result = (IntPtr)14;
				}
			}
			else if (point.Y <= base.Size.Height - 10)
			{
				if (point.X <= 10)
				{
					m.Result = (IntPtr)10;
				}
				else if (point.X < base.Size.Width - 10)
				{
					m.Result = (IntPtr)2;
				}
				else
				{
					m.Result = (IntPtr)11;
				}
			}
			else if (point.X <= 10)
			{
				m.Result = (IntPtr)16;
			}
			else if (point.X < base.Size.Width - 10)
			{
				m.Result = (IntPtr)15;
			}
			else
			{
				m.Result = (IntPtr)17;
			}
		}
		else
		{
			base.WndProc(ref m);
		}
	}

	public string get_log_content()
	{
		return ((TextBox)logBox).Text;
	}

	public string get_queue_last_thrm()
	{
		int key = queue_w.Keys.First();
		string result = queue_w[key];
		try
		{
			queue_w.Remove(key);
		}
		catch
		{
		}
		return result;
	}

	private void Logger_Load(object sender, EventArgs e)
	{
		siticoneShadowForm1.SetShadowForm((Form)this);
		ImpostazioniGlobali.l_ = PutLog;
		ThreadPool.GetMaxThreads(out var _, out var completionPortThreads);
		ThreadPool.SetMinThreads(completionPortThreads - 1, completionPortThreads - 1);
		ch_queue_t = new Thread((ParameterizedThreadStart)delegate
		{
			while (q_c_l && q_c_l)
			{
				if (queue_w.Count != 0)
				{
					try
					{
						((TextBox)logBox).AppendText(Environment.NewLine + get_queue_last_thrm());
					}
					catch (Exception)
					{
					}
					Thread.Sleep(1);
				}
			}
		});
		ch_queue_t.Start();
	}

	public void PutLog(string a)
	{
		try
		{
			if (((TextBox)logBox).Text.Length > ImpostazioniGlobali.log_interval_cl)
			{
				((TextBox)logBox).Text = "";
				((TextBox)logBox).AppendText(Environment.NewLine + "Log => Auto Clear :: Done[" + ImpostazioniGlobali.log_interval_cl + "]");
			}
		}
		catch (Exception)
		{
		}
		try
		{
			queue_w.Add(queue_w.Count, a);
		}
		catch
		{
		}
	}

	private void logBox_TextChanged(object sender, EventArgs e)
	{
	}

	private void Logger_FormClosed(object sender, FormClosedEventArgs e)
	{
		try
		{
			ImpostazioniGlobali.LogForm = null;
		}
		catch (Exception)
		{
		}
	}

	private void siticoneImageButton1_Click(object sender, EventArgs e)
	{
		q_c_l = false;
		try
		{
			ch_queue_t.Abort();
		}
		catch
		{
		}
		try
		{
			queue_w.Clear();
		}
		catch
		{
		}
		try
		{
			((TextBox)logBox).Clear();
		}
		catch
		{
		}
		try
		{
			Dispose();
		}
		catch
		{
		}
		try
		{
			Close();
		}
		catch
		{
		}
	}

	private void siticoneImageButton2_Click(object sender, EventArgs e)
	{
		base.WindowState = FormWindowState.Minimized;
	}

	private void siticoneImageButton3_Click(object sender, EventArgs e)
	{
		if (base.WindowState == FormWindowState.Maximized)
		{
			base.WindowState = FormWindowState.Normal;
		}
		else
		{
			base.WindowState = FormWindowState.Maximized;
		}
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
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlackSpammerXS.Logger));
		this.logBox = new SiticoneTextBox();
		this.siticoneDragControl1 = new SiticoneDragControl(this.components);
		this.siticoneElipse1 = new SiticoneElipse(this.components);
		this.siticoneDragControl2 = new SiticoneDragControl(this.components);
		this.siticoneImageButton3 = new SiticoneImageButton();
		this.siticoneImageButton2 = new SiticoneImageButton();
		this.siticoneImageButton1 = new SiticoneImageButton();
		this.siticoneShadowForm1 = new SiticoneShadowForm(this.components);
		base.SuspendLayout();
		((System.Windows.Forms.Control)(object)this.logBox).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.logBox.Animated = false;
		((System.Windows.Forms.Control)(object)this.logBox).BackColor = System.Drawing.Color.Transparent;
		this.logBox.BorderColor = System.Drawing.Color.Transparent;
		this.logBox.BorderThickness = 0;
		((System.Windows.Forms.Control)(object)this.logBox).Cursor = System.Windows.Forms.Cursors.IBeam;
		((TextBox)this.logBox).DefaultText = "";
		this.logBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
		this.logBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
		this.logBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.logBox.DisabledState.Parent = (TextBox)(object)this.logBox;
		this.logBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
		this.logBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
		this.logBox.FocusedState.Parent = (TextBox)(object)this.logBox;
		((TextBox)this.logBox).Font = new System.Drawing.Font("JetBrains Mono", 9.75f);
		((TextBox)this.logBox).ForeColor = System.Drawing.Color.Black;
		this.logBox.HoveredState.BorderColor = System.Drawing.Color.Transparent;
		this.logBox.HoveredState.Parent = (TextBox)(object)this.logBox;
		((System.Windows.Forms.Control)(object)this.logBox).Location = new System.Drawing.Point(-3, 32);
		((System.Windows.Forms.Control)(object)this.logBox).Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		((TextBox)this.logBox).Multiline = true;
		((System.Windows.Forms.Control)(object)this.logBox).Name = "logBox";
		((TextBox)this.logBox).PasswordChar = '\0';
		this.logBox.PlaceholderText = "BlackSpammer XS Logger V4";
		((TextBox)this.logBox).ReadOnly = true;
		((TextBox)this.logBox).SelectedText = "";
		this.logBox.ShadowDecoration.Parent = (System.Windows.Forms.Control)(object)this.logBox;
		((System.Windows.Forms.Control)(object)this.logBox).Size = new System.Drawing.Size(889, 319);
		((System.Windows.Forms.Control)(object)this.logBox).TabIndex = 36;
		((TextBox)this.logBox).TextChanged += new System.EventHandler(logBox_TextChanged);
		this.siticoneDragControl1.TargetControl = (System.Windows.Forms.Control)(object)this.logBox;
		this.siticoneElipse1.BorderRadius = 11;
		this.siticoneElipse1.TargetControl = this;
		this.siticoneDragControl2.TargetControl = this;
		this.siticoneImageButton3.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneImageButton3.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image");
		this.siticoneImageButton3.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		this.siticoneImageButton3.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton3.Image");
		((ImageButton)this.siticoneImageButton3).ImageRotate = 0f;
		this.siticoneImageButton3.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Location = new System.Drawing.Point(47, 2);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Name = "siticoneImageButton3";
		this.siticoneImageButton3.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Size = new System.Drawing.Size(29, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).TabIndex = 82;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Click += new System.EventHandler(siticoneImageButton3_Click);
		this.siticoneImageButton2.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton2;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneImageButton2.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image1");
		this.siticoneImageButton2.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton2.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton2;
		this.siticoneImageButton2.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton2.Image");
		((ImageButton)this.siticoneImageButton2).ImageRotate = 0f;
		this.siticoneImageButton2.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton2.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Location = new System.Drawing.Point(26, 2);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Name = "siticoneImageButton2";
		this.siticoneImageButton2.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton2.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton2;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Size = new System.Drawing.Size(29, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).TabIndex = 81;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Click += new System.EventHandler(siticoneImageButton2_Click);
		this.siticoneImageButton1.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneImageButton1.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image2");
		this.siticoneImageButton1.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		this.siticoneImageButton1.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton1.Image");
		((ImageButton)this.siticoneImageButton1).ImageRotate = 0f;
		this.siticoneImageButton1.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Location = new System.Drawing.Point(7, 2);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Name = "siticoneImageButton1";
		this.siticoneImageButton1.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Size = new System.Drawing.Size(26, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).TabIndex = 80;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Click += new System.EventHandler(siticoneImageButton1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(887, 349);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton3);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton2);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton1);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.logBox);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Logger";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Logger";
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Logger_FormClosed);
		base.Load += new System.EventHandler(Logger_Load);
		base.ResumeLayout(false);
	}
}
