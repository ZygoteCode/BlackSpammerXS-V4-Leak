using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BlackSpammerXS.Properties;
using Newtonsoft.Json.Linq;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Suite;

namespace BlackSpammerXS;

public class AuditLogForm : Form
{
	private IContainer components = null;

	private SiticoneShadowForm siticoneShadowForm1;

	private SiticoneAnimateWindow siticoneAnimateWindow1;

	private Label label1;

	private ContextMenuStrip contextMenuStrip1;

	private ToolStripMenuItem clearLogToolStripMenuItem;

	private ToolStripMenuItem rawJSONLogToolStripMenuItem;

	private FlowLayoutPanel logContainer;

	private SiticoneImageButton siticoneImageButton2;

	private SiticoneImageButton siticoneImageButton3;

	private SiticoneImageButton siticoneImageButton1;

	private SiticoneElipse siticoneElipse1;

	public AuditLogForm()
	{
		InitializeComponent();
		siticoneShadowForm1.SetShadowForm((Form)this);
	}

	private void AuditLogForm_Load(object sender, EventArgs e)
	{
		bool dark = false;
		if (Settings.Default.dark)
		{
			Color backColor = Color.FromArgb(44, 47, 51);
			Color dimGray = Color.DimGray;
			dark = true;
			BackColor = backColor;
			label1.ForeColor = Color.White;
		}
		try
		{
			AuditManager auditManager = ImpostazioniGlobali.auditManager;
			dynamic rawLog = auditManager.GetRawLog();
			JArray val = (JArray)rawLog.joins;
			if (((JContainer)val).Count != 0)
			{
				JObject[] array = ((JToken)val).ToObject<JObject[]>();
				JObject[] array2 = array;
				foreach (JObject val2 in array2)
				{
					dynamic val3 = val2;
					string serverLink = val3.serverLink;
					string tokens = val3.tokensAmount;
					string text = val3.proxiesAmount;
					string timeStamp = "Completato";
					AuditJoin value = new AuditJoin(serverLink, tokens, "valid", timeStamp, dark, this);
					logContainer.Controls.Add(value);
				}
			}
			JArray val4 = (JArray)rawLog.leaves;
			if (((JContainer)val4).Count != 0)
			{
				JObject[] array3 = ((JToken)val4).ToObject<JObject[]>();
				JObject[] array4 = array3;
				foreach (JObject val5 in array4)
				{
					dynamic val6 = val5;
					string serverId = val6.serverId;
					string tokens2 = val6.tokensAmount;
					string text2 = val6.proxiesAmount;
					string timeStamp2 = "Completato";
					AuditLeave value2 = new AuditLeave(serverId, tokens2, "valid", timeStamp2, dark, this);
					logContainer.Controls.Add(value2);
				}
			}
			JArray val7 = (JArray)rawLog.spam;
			if (((JContainer)val7).Count != 0)
			{
				JObject[] array5 = ((JToken)val7).ToObject<JObject[]>();
				JObject[] array6 = array5;
				foreach (JObject val8 in array6)
				{
					dynamic val9 = val8;
					string serverId2 = val9.channelId;
					string tokens3 = val9.tokensAmount;
					string text3 = val9.proxiesAmount;
					string timeStamp3 = "Completato";
					string message = val9.message;
					string mref = val9.mref;
					AuditSpam value3 = new AuditSpam(serverId2, tokens3, "valid", timeStamp3, message, mref, dark, this);
					logContainer.Controls.Add(value3);
				}
			}
			JArray val10 = (JArray)rawLog.reaction;
			if (((JContainer)val10).Count != 0)
			{
				JObject[] array7 = ((JToken)val10).ToObject<JObject[]>();
				JObject[] array8 = array7;
				foreach (JObject val11 in array8)
				{
					dynamic val12 = val11;
					string serverId3 = val12.channelId;
					string tokens4 = val12.tokensAmount;
					string text4 = val12.proxiesAmount;
					string emoji = val12.emoji;
					int type = val12.type;
					string message2 = val12.message;
					AuditReact value4 = new AuditReact(serverId3, tokens4, "valid", type, emoji, dark, this, message2);
					logContainer.Controls.Add(value4);
				}
			}
		}
		catch (Exception)
		{
			MessageBox.Show("Ops! Qualcosa è andato storto. Riprova.");
		}
	}

	private async void siticoneButton6_Click(object sender, EventArgs e)
	{
	}

	private void siticoneControlBox1_Click(object sender, EventArgs e)
	{
		ImpostazioniGlobali.bridgeAct_(0);
	}

	private void logContainer_Paint(object sender, PaintEventArgs e)
	{
	}

	private void siticoneVScrollBar1_Scroll(object sender, ScrollEventArgs e)
	{
	}

	private async void siticoneGradientButton3_Click(object sender, EventArgs e)
	{
	}

	private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			AuditManager auditManager = ImpostazioniGlobali.auditManager;
			auditManager.ClearLog();
			logContainer.Controls.Clear();
		}
		catch (Exception)
		{
		}
	}

	private void rawJSONLogToolStripMenuItem_Click(object sender, EventArgs e)
	{
		OpacityFull opacityFull = new OpacityFull();
		opacityFull.Show();
		GTextRes gTextRes = new GTextRes(Settings.Default.audit, opacityFull, Settings.Default.dark);
		gTextRes.Show();
		gTextRes.Focus();
		Close();
	}

	private void logContainer_Scroll(object sender, ScrollEventArgs e)
	{
	}

	private void logContainer_Paint_1(object sender, PaintEventArgs e)
	{
	}

	private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
	{
	}

	private void siticoneImageButton1_Click(object sender, EventArgs e)
	{
		siticoneControlBox1_Click(sender, e);
		Close();
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
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlackSpammerXS.AuditLogForm));
		this.siticoneShadowForm1 = new SiticoneShadowForm(this.components);
		this.siticoneAnimateWindow1 = new SiticoneAnimateWindow(this.components);
		this.label1 = new System.Windows.Forms.Label();
		this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.rawJSONLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.logContainer = new System.Windows.Forms.FlowLayoutPanel();
		this.siticoneImageButton2 = new SiticoneImageButton();
		this.siticoneImageButton3 = new SiticoneImageButton();
		this.siticoneImageButton1 = new SiticoneImageButton();
		this.siticoneElipse1 = new SiticoneElipse(this.components);
		this.contextMenuStrip1.SuspendLayout();
		base.SuspendLayout();
		this.siticoneAnimateWindow1.AnimationType = (AnimateWindowType)262144;
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("SF Pro Text", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(257, 13);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(80, 18);
		this.label1.TabIndex = 66;
		this.label1.Text = "Audit Log";
		this.contextMenuStrip1.Font = new System.Drawing.Font("SF Pro Text", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.clearLogToolStripMenuItem, this.rawJSONLogToolStripMenuItem });
		this.contextMenuStrip1.Name = "contextMenuStrip1";
		this.contextMenuStrip1.Size = new System.Drawing.Size(181, 70);
		this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(contextMenuStrip1_Opening);
		this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
		this.clearLogToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
		this.clearLogToolStripMenuItem.Text = "Clear Log";
		this.clearLogToolStripMenuItem.Click += new System.EventHandler(clearLogToolStripMenuItem_Click);
		this.rawJSONLogToolStripMenuItem.Name = "rawJSONLogToolStripMenuItem";
		this.rawJSONLogToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
		this.rawJSONLogToolStripMenuItem.Text = "Raw JSON Log";
		this.rawJSONLogToolStripMenuItem.Click += new System.EventHandler(rawJSONLogToolStripMenuItem_Click);
		this.logContainer.Location = new System.Drawing.Point(-2, 44);
		this.logContainer.Name = "logContainer";
		this.logContainer.Size = new System.Drawing.Size(614, 507);
		this.logContainer.TabIndex = 67;
		this.logContainer.Paint += new System.Windows.Forms.PaintEventHandler(logContainer_Paint_1);
		this.siticoneImageButton2.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton2;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Cursor = System.Windows.Forms.Cursors.Arrow;
		this.siticoneImageButton2.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image");
		this.siticoneImageButton2.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton2.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton2;
		this.siticoneImageButton2.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton2.Image");
		((ImageButton)this.siticoneImageButton2).ImageRotate = 0f;
		this.siticoneImageButton2.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton2.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Location = new System.Drawing.Point(29, 7);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Name = "siticoneImageButton2";
		this.siticoneImageButton2.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton2.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton2;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).Size = new System.Drawing.Size(29, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton2).TabIndex = 89;
		this.siticoneImageButton3.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Cursor = System.Windows.Forms.Cursors.Arrow;
		this.siticoneImageButton3.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image1");
		this.siticoneImageButton3.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		this.siticoneImageButton3.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton3.Image");
		((ImageButton)this.siticoneImageButton3).ImageRotate = 0f;
		this.siticoneImageButton3.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Location = new System.Drawing.Point(50, 7);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Name = "siticoneImageButton3";
		this.siticoneImageButton3.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton3.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton3;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).Size = new System.Drawing.Size(29, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton3).TabIndex = 88;
		this.siticoneImageButton1.CheckedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Cursor = System.Windows.Forms.Cursors.Hand;
		this.siticoneImageButton1.HoveredState.Image = (System.Drawing.Image)resources.GetObject("resource.Image2");
		this.siticoneImageButton1.HoveredState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.HoveredState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		this.siticoneImageButton1.Image = (System.Drawing.Image)resources.GetObject("siticoneImageButton1.Image");
		((ImageButton)this.siticoneImageButton1).ImageRotate = 0f;
		this.siticoneImageButton1.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.IndicateFocus = false;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Location = new System.Drawing.Point(10, 7);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Name = "siticoneImageButton1";
		this.siticoneImageButton1.PressedState.ImageSize = new System.Drawing.Size(17, 17);
		this.siticoneImageButton1.PressedState.Parent = (UIDefaultControl)(object)this.siticoneImageButton1;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Size = new System.Drawing.Size(26, 29);
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).TabIndex = 87;
		((System.Windows.Forms.Control)(object)this.siticoneImageButton1).Click += new System.EventHandler(siticoneImageButton1_Click);
		this.siticoneElipse1.TargetControl = this;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(611, 551);
		this.ContextMenuStrip = this.contextMenuStrip1;
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton2);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton3);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.siticoneImageButton1);
		base.Controls.Add(this.logContainer);
		base.Controls.Add(this.label1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "AuditLogForm";
		base.ShowIcon = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "AuditLogForm";
		base.Load += new System.EventHandler(AuditLogForm_Load);
		this.contextMenuStrip1.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
