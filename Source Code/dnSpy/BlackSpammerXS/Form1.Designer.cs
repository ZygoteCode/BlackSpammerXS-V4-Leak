namespace BlackSpammerXS
{
	// Token: 0x02000055 RID: 85
	public partial class Form1 : global::System.Windows.Forms.Form
	{
		// Token: 0x06000175 RID: 373 RVA: 0x00016B28 File Offset: 0x00014D28
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00016B60 File Offset: 0x00014D60
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::BlackSpammerXS.Form1));
			this.siticoneShadowForm1 = new global::Siticone.UI.WinForms.SiticoneShadowForm(this.components);
			this.siticoneDragControl1 = new global::Siticone.UI.WinForms.SiticoneDragControl(this.components);
			this.siticonePanel1 = new global::Siticone.UI.WinForms.SiticonePanel();
			this.siticoneButton5 = new global::Siticone.UI.WinForms.SiticoneButton();
			this.siticoneImageButton3 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneImageButton2 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.siticoneImageButton1 = new global::Siticone.UI.WinForms.SiticoneImageButton();
			this.label3 = new global::System.Windows.Forms.Label();
			this.siticoneGradientButton1 = new global::Siticone.UI.WinForms.SiticoneGradientButton();
			this.siticoneButton6 = new global::Siticone.UI.WinForms.SiticoneButton();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.siticoneButton4 = new global::Siticone.UI.WinForms.SiticoneButton();
			this.siticoneButton3 = new global::Siticone.UI.WinForms.SiticoneButton();
			this.siticoneButton2 = new global::Siticone.UI.WinForms.SiticoneButton();
			this.siticoneButton1 = new global::Siticone.UI.WinForms.SiticoneButton();
			this.siticoneDragControl2 = new global::Siticone.UI.WinForms.SiticoneDragControl(this.components);
			this.siticoneDragControl3 = new global::Siticone.UI.WinForms.SiticoneDragControl(this.components);
			this.siticoneDragControl4 = new global::Siticone.UI.WinForms.SiticoneDragControl(this.components);
			this.siticoneDragControl5 = new global::Siticone.UI.WinForms.SiticoneDragControl(this.components);
			this.siticonePanel2 = new global::Siticone.UI.WinForms.SiticonePanel();
			this.dashboard1 = new global::BlackSpammerXS.Dashboard();
			this.guildManager1 = new global::BlackSpammerXS.GuildManager();
			this.serverSpammer1 = new global::BlackSpammerXS.ServerSpammer();
			this.reactionSpammer1 = new global::BlackSpammerXS.ReactionSpammer();
			this.advancedSettings1 = new global::BlackSpammerXS.AdvancedSettings();
			this.websocketManager1 = new global::BlackSpammerXS.WebsocketManager();
			this.siticoneDragControl6 = new global::Siticone.UI.WinForms.SiticoneDragControl(this.components);
			this.siticoneDragControl7 = new global::Siticone.UI.WinForms.SiticoneDragControl(this.components);
			this.bunifuDragControl1 = new global::Bunifu.Framework.UI.BunifuDragControl(this.components);
			this.siticoneElipse1 = new global::Siticone.UI.WinForms.SiticoneElipse(this.components);
			this.siticonePanel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.siticonePanel2.SuspendLayout();
			base.SuspendLayout();
			this.siticoneDragControl1.TargetControl = this;
			this.siticonePanel1.BackColor = global::System.Drawing.SystemColors.Control;
			this.siticonePanel1.Controls.Add(this.siticoneButton5);
			this.siticonePanel1.Controls.Add(this.siticoneImageButton3);
			this.siticonePanel1.Controls.Add(this.siticoneImageButton2);
			this.siticonePanel1.Controls.Add(this.siticoneImageButton1);
			this.siticonePanel1.Controls.Add(this.label3);
			this.siticonePanel1.Controls.Add(this.siticoneGradientButton1);
			this.siticonePanel1.Controls.Add(this.siticoneButton6);
			this.siticonePanel1.Controls.Add(this.label2);
			this.siticonePanel1.Controls.Add(this.label1);
			this.siticonePanel1.Controls.Add(this.pictureBox1);
			this.siticonePanel1.Controls.Add(this.siticoneButton4);
			this.siticonePanel1.Controls.Add(this.siticoneButton3);
			this.siticonePanel1.Controls.Add(this.siticoneButton2);
			this.siticonePanel1.Controls.Add(this.siticoneButton1);
			this.siticonePanel1.Location = new global::System.Drawing.Point(0, 0);
			this.siticonePanel1.Name = "siticonePanel1";
			this.siticonePanel1.ShadowDecoration.Depth = 3;
			this.siticonePanel1.ShadowDecoration.Enabled = true;
			this.siticonePanel1.ShadowDecoration.Parent = this.siticonePanel1;
			this.siticonePanel1.ShadowDecoration.Shadow = new global::System.Windows.Forms.Padding(3, 3, 5, 3);
			this.siticonePanel1.Size = new global::System.Drawing.Size(208, 564);
			this.siticonePanel1.TabIndex = 0;
			this.siticonePanel1.Paint += new global::System.Windows.Forms.PaintEventHandler(this.siticonePanel1_Paint);
			this.siticoneButton5.ButtonMode = 1;
			this.siticoneButton5.CheckedState.CustomBorderColor = global::System.Drawing.SystemColors.Highlight;
			this.siticoneButton5.CheckedState.FillColor = global::System.Drawing.SystemColors.Control;
			this.siticoneButton5.CheckedState.Parent = this.siticoneButton5;
			this.siticoneButton5.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneButton5.CustomBorderThickness = new global::System.Windows.Forms.Padding(3, 0, 0, 0);
			this.siticoneButton5.CustomImages.Parent = this.siticoneButton5;
			this.siticoneButton5.FillColor = global::System.Drawing.SystemColors.Control;
			this.siticoneButton5.Font = new global::System.Drawing.Font("SF Pro Text", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneButton5.ForeColor = global::System.Drawing.Color.Black;
			this.siticoneButton5.HoveredState.Parent = this.siticoneButton5;
			this.siticoneButton5.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneButton5.Image");
			this.siticoneButton5.ImageAlign = global::System.Windows.Forms.HorizontalAlignment.Left;
			this.siticoneButton5.ImageOffset = new global::System.Drawing.Point(15, 0);
			this.siticoneButton5.ImageSize = new global::System.Drawing.Size(18, 18);
			this.siticoneButton5.Location = new global::System.Drawing.Point(0, 346);
			this.siticoneButton5.Name = "siticoneButton5";
			this.siticoneButton5.ShadowDecoration.Parent = this.siticoneButton5;
			this.siticoneButton5.Size = new global::System.Drawing.Size(208, 45);
			this.siticoneButton5.TabIndex = 80;
			this.siticoneButton5.Text = "Websocket Utility";
			this.siticoneButton5.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Left;
			this.siticoneButton5.TextOffset = new global::System.Drawing.Point(15, 0);
			this.siticoneButton5.TextRenderingHint = global::System.Drawing.Text.TextRenderingHint.AntiAlias;
			this.siticoneButton5.Click += new global::System.EventHandler(this.siticoneButton5_Click_1);
			this.siticoneImageButton3.CheckedState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Cursor = global::System.Windows.Forms.Cursors.Arrow;
			this.siticoneImageButton3.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image");
			this.siticoneImageButton3.HoveredState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.HoveredState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneImageButton3.Image");
			this.siticoneImageButton3.ImageRotate = 0f;
			this.siticoneImageButton3.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.IndicateFocus = false;
			this.siticoneImageButton3.Location = new global::System.Drawing.Point(49, 5);
			this.siticoneImageButton3.Name = "siticoneImageButton3";
			this.siticoneImageButton3.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton3.PressedState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Size = new global::System.Drawing.Size(29, 29);
			this.siticoneImageButton3.TabIndex = 79;
			this.siticoneImageButton2.CheckedState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneImageButton2.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image1");
			this.siticoneImageButton2.HoveredState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton2.HoveredState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneImageButton2.Image");
			this.siticoneImageButton2.ImageRotate = 0f;
			this.siticoneImageButton2.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton2.IndicateFocus = false;
			this.siticoneImageButton2.Location = new global::System.Drawing.Point(28, 5);
			this.siticoneImageButton2.Name = "siticoneImageButton2";
			this.siticoneImageButton2.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton2.PressedState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.Size = new global::System.Drawing.Size(29, 29);
			this.siticoneImageButton2.TabIndex = 78;
			this.siticoneImageButton2.Click += new global::System.EventHandler(this.siticoneImageButton2_Click);
			this.siticoneImageButton1.CheckedState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneImageButton1.HoveredState.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Image2");
			this.siticoneImageButton1.HoveredState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.HoveredState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneImageButton1.Image");
			this.siticoneImageButton1.ImageRotate = 0f;
			this.siticoneImageButton1.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.IndicateFocus = false;
			this.siticoneImageButton1.Location = new global::System.Drawing.Point(9, 5);
			this.siticoneImageButton1.Name = "siticoneImageButton1";
			this.siticoneImageButton1.PressedState.ImageSize = new global::System.Drawing.Size(17, 17);
			this.siticoneImageButton1.PressedState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Size = new global::System.Drawing.Size(26, 29);
			this.siticoneImageButton1.TabIndex = 77;
			this.siticoneImageButton1.Click += new global::System.EventHandler(this.siticoneImageButton1_Click);
			this.label3.Font = new global::System.Drawing.Font("Inter Black", 9.749999f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.label3.Location = new global::System.Drawing.Point(12, 487);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(174, 24);
			this.label3.TabIndex = 71;
			this.label3.Text = "UTENTE";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.siticoneGradientButton1.BorderRadius = 18;
			this.siticoneGradientButton1.CheckedState.Parent = this.siticoneGradientButton1;
			this.siticoneGradientButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneGradientButton1.CustomImages.Parent = this.siticoneGradientButton1;
			this.siticoneGradientButton1.FillColor = global::System.Drawing.Color.FromArgb(56, 128, 255);
			this.siticoneGradientButton1.FillColor2 = global::System.Drawing.Color.FromArgb(56, 128, 255);
			this.siticoneGradientButton1.Font = new global::System.Drawing.Font("SF Pro Text", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneGradientButton1.ForeColor = global::System.Drawing.Color.White;
			this.siticoneGradientButton1.HoveredState.Parent = this.siticoneGradientButton1;
			this.siticoneGradientButton1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneGradientButton1.Image");
			this.siticoneGradientButton1.ImageAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.siticoneGradientButton1.ImageOffset = new global::System.Drawing.Point(6, -1);
			this.siticoneGradientButton1.Location = new global::System.Drawing.Point(16, 516);
			this.siticoneGradientButton1.Name = "siticoneGradientButton1";
			this.siticoneGradientButton1.ShadowDecoration.Parent = this.siticoneGradientButton1;
			this.siticoneGradientButton1.Size = new global::System.Drawing.Size(170, 38);
			this.siticoneGradientButton1.TabIndex = 70;
			this.siticoneGradientButton1.Text = "Logout";
			this.siticoneGradientButton1.TextRenderingHint = global::System.Drawing.Text.TextRenderingHint.AntiAlias;
			this.siticoneGradientButton1.Click += new global::System.EventHandler(this.siticoneGradientButton1_Click);
			this.siticoneButton6.ButtonMode = 1;
			this.siticoneButton6.CheckedState.CustomBorderColor = global::System.Drawing.SystemColors.Highlight;
			this.siticoneButton6.CheckedState.FillColor = global::System.Drawing.SystemColors.Control;
			this.siticoneButton6.CheckedState.Parent = this.siticoneButton6;
			this.siticoneButton6.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneButton6.CustomBorderThickness = new global::System.Windows.Forms.Padding(3, 0, 0, 0);
			this.siticoneButton6.CustomImages.Parent = this.siticoneButton6;
			this.siticoneButton6.FillColor = global::System.Drawing.SystemColors.Control;
			this.siticoneButton6.Font = new global::System.Drawing.Font("SF Pro Text", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneButton6.ForeColor = global::System.Drawing.Color.Black;
			this.siticoneButton6.HoveredState.Parent = this.siticoneButton6;
			this.siticoneButton6.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneButton6.Image");
			this.siticoneButton6.ImageAlign = global::System.Windows.Forms.HorizontalAlignment.Left;
			this.siticoneButton6.ImageOffset = new global::System.Drawing.Point(15, 0);
			this.siticoneButton6.ImageSize = new global::System.Drawing.Size(18, 18);
			this.siticoneButton6.Location = new global::System.Drawing.Point(-1, 392);
			this.siticoneButton6.Name = "siticoneButton6";
			this.siticoneButton6.ShadowDecoration.Parent = this.siticoneButton6;
			this.siticoneButton6.Size = new global::System.Drawing.Size(208, 45);
			this.siticoneButton6.TabIndex = 7;
			this.siticoneButton6.Text = "Settings And Other";
			this.siticoneButton6.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Left;
			this.siticoneButton6.TextOffset = new global::System.Drawing.Point(15, 0);
			this.siticoneButton6.TextRenderingHint = global::System.Drawing.Text.TextRenderingHint.AntiAlias;
			this.siticoneButton6.Click += new global::System.EventHandler(this.siticoneButton6_Click);
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Inter Black", 9.749999f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.label2.Location = new global::System.Drawing.Point(146, 135);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(27, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "V4";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Uni Sans Heavy CAPS", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(25, 116);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(150, 19);
			this.label1.TabIndex = 5;
			this.label1.Text = "BLACKSPAMMER XS";
			this.label1.Click += new global::System.EventHandler(this.label1_Click);
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(68, 53);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(50, 50);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			this.siticoneButton4.ButtonMode = 1;
			this.siticoneButton4.CheckedState.CustomBorderColor = global::System.Drawing.SystemColors.Highlight;
			this.siticoneButton4.CheckedState.FillColor = global::System.Drawing.SystemColors.Control;
			this.siticoneButton4.CheckedState.Parent = this.siticoneButton4;
			this.siticoneButton4.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneButton4.CustomBorderThickness = new global::System.Windows.Forms.Padding(3, 0, 0, 0);
			this.siticoneButton4.CustomImages.Parent = this.siticoneButton4;
			this.siticoneButton4.FillColor = global::System.Drawing.SystemColors.Control;
			this.siticoneButton4.Font = new global::System.Drawing.Font("SF Pro Text", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneButton4.ForeColor = global::System.Drawing.Color.Black;
			this.siticoneButton4.HoveredState.Parent = this.siticoneButton4;
			this.siticoneButton4.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneButton4.Image");
			this.siticoneButton4.ImageAlign = global::System.Windows.Forms.HorizontalAlignment.Left;
			this.siticoneButton4.ImageOffset = new global::System.Drawing.Point(15, 0);
			this.siticoneButton4.ImageSize = new global::System.Drawing.Size(18, 18);
			this.siticoneButton4.Location = new global::System.Drawing.Point(0, 212);
			this.siticoneButton4.Name = "siticoneButton4";
			this.siticoneButton4.ShadowDecoration.Parent = this.siticoneButton4;
			this.siticoneButton4.Size = new global::System.Drawing.Size(208, 45);
			this.siticoneButton4.TabIndex = 4;
			this.siticoneButton4.Text = "Guild Manager";
			this.siticoneButton4.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Left;
			this.siticoneButton4.TextOffset = new global::System.Drawing.Point(15, 0);
			this.siticoneButton4.TextRenderingHint = global::System.Drawing.Text.TextRenderingHint.AntiAlias;
			this.siticoneButton4.Click += new global::System.EventHandler(this.siticoneButton4_Click);
			this.siticoneButton3.ButtonMode = 1;
			this.siticoneButton3.CheckedState.CustomBorderColor = global::System.Drawing.SystemColors.Highlight;
			this.siticoneButton3.CheckedState.FillColor = global::System.Drawing.SystemColors.Control;
			this.siticoneButton3.CheckedState.Parent = this.siticoneButton3;
			this.siticoneButton3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneButton3.CustomBorderThickness = new global::System.Windows.Forms.Padding(3, 0, 0, 0);
			this.siticoneButton3.CustomImages.Parent = this.siticoneButton3;
			this.siticoneButton3.FillColor = global::System.Drawing.SystemColors.Control;
			this.siticoneButton3.Font = new global::System.Drawing.Font("SF Pro Text", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneButton3.ForeColor = global::System.Drawing.Color.Black;
			this.siticoneButton3.HoveredState.Parent = this.siticoneButton3;
			this.siticoneButton3.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneButton3.Image");
			this.siticoneButton3.ImageAlign = global::System.Windows.Forms.HorizontalAlignment.Left;
			this.siticoneButton3.ImageOffset = new global::System.Drawing.Point(15, 0);
			this.siticoneButton3.ImageSize = new global::System.Drawing.Size(18, 18);
			this.siticoneButton3.Location = new global::System.Drawing.Point(0, 257);
			this.siticoneButton3.Name = "siticoneButton3";
			this.siticoneButton3.ShadowDecoration.Parent = this.siticoneButton3;
			this.siticoneButton3.Size = new global::System.Drawing.Size(208, 45);
			this.siticoneButton3.TabIndex = 3;
			this.siticoneButton3.Text = "Server Spammer";
			this.siticoneButton3.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Left;
			this.siticoneButton3.TextOffset = new global::System.Drawing.Point(15, 0);
			this.siticoneButton3.TextRenderingHint = global::System.Drawing.Text.TextRenderingHint.AntiAlias;
			this.siticoneButton3.Click += new global::System.EventHandler(this.siticoneButton3_Click);
			this.siticoneButton2.ButtonMode = 1;
			this.siticoneButton2.CheckedState.CustomBorderColor = global::System.Drawing.SystemColors.Highlight;
			this.siticoneButton2.CheckedState.FillColor = global::System.Drawing.SystemColors.Control;
			this.siticoneButton2.CheckedState.Parent = this.siticoneButton2;
			this.siticoneButton2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneButton2.CustomBorderThickness = new global::System.Windows.Forms.Padding(3, 0, 0, 0);
			this.siticoneButton2.CustomImages.Parent = this.siticoneButton2;
			this.siticoneButton2.FillColor = global::System.Drawing.SystemColors.Control;
			this.siticoneButton2.Font = new global::System.Drawing.Font("SF Pro Text", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneButton2.ForeColor = global::System.Drawing.Color.Black;
			this.siticoneButton2.HoveredState.Parent = this.siticoneButton2;
			this.siticoneButton2.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneButton2.Image");
			this.siticoneButton2.ImageAlign = global::System.Windows.Forms.HorizontalAlignment.Left;
			this.siticoneButton2.ImageOffset = new global::System.Drawing.Point(15, 0);
			this.siticoneButton2.ImageSize = new global::System.Drawing.Size(18, 18);
			this.siticoneButton2.Location = new global::System.Drawing.Point(0, 302);
			this.siticoneButton2.Name = "siticoneButton2";
			this.siticoneButton2.ShadowDecoration.Parent = this.siticoneButton2;
			this.siticoneButton2.Size = new global::System.Drawing.Size(208, 45);
			this.siticoneButton2.TabIndex = 2;
			this.siticoneButton2.Text = "Reaction Spammer";
			this.siticoneButton2.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Left;
			this.siticoneButton2.TextOffset = new global::System.Drawing.Point(15, 0);
			this.siticoneButton2.TextRenderingHint = global::System.Drawing.Text.TextRenderingHint.AntiAlias;
			this.siticoneButton2.Click += new global::System.EventHandler(this.siticoneButton2_Click);
			this.siticoneButton1.ButtonMode = 1;
			this.siticoneButton1.Checked = true;
			this.siticoneButton1.CheckedState.BorderColor = global::System.Drawing.Color.FromArgb(0, 192, 192);
			this.siticoneButton1.CheckedState.CustomBorderColor = global::System.Drawing.SystemColors.Highlight;
			this.siticoneButton1.CheckedState.FillColor = global::System.Drawing.SystemColors.Control;
			this.siticoneButton1.CheckedState.Parent = this.siticoneButton1;
			this.siticoneButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.siticoneButton1.CustomBorderThickness = new global::System.Windows.Forms.Padding(3, 0, 0, 0);
			this.siticoneButton1.CustomImages.Parent = this.siticoneButton1;
			this.siticoneButton1.FillColor = global::System.Drawing.SystemColors.Control;
			this.siticoneButton1.Font = new global::System.Drawing.Font("SF Pro Text", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.siticoneButton1.ForeColor = global::System.Drawing.Color.Black;
			this.siticoneButton1.HoveredState.Parent = this.siticoneButton1;
			this.siticoneButton1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("siticoneButton1.Image");
			this.siticoneButton1.ImageAlign = global::System.Windows.Forms.HorizontalAlignment.Left;
			this.siticoneButton1.ImageOffset = new global::System.Drawing.Point(15, 0);
			this.siticoneButton1.ImageSize = new global::System.Drawing.Size(18, 18);
			this.siticoneButton1.Location = new global::System.Drawing.Point(0, 167);
			this.siticoneButton1.Name = "siticoneButton1";
			this.siticoneButton1.ShadowDecoration.Parent = this.siticoneButton1;
			this.siticoneButton1.Size = new global::System.Drawing.Size(208, 45);
			this.siticoneButton1.TabIndex = 1;
			this.siticoneButton1.Text = "Dashboard";
			this.siticoneButton1.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Left;
			this.siticoneButton1.TextOffset = new global::System.Drawing.Point(15, 0);
			this.siticoneButton1.TextRenderingHint = global::System.Drawing.Text.TextRenderingHint.AntiAlias;
			this.siticoneButton1.Click += new global::System.EventHandler(this.siticoneButton1_Click);
			this.siticoneDragControl2.TargetControl = this.siticonePanel1;
			this.siticoneDragControl3.TargetControl = this.pictureBox1;
			this.siticoneDragControl4.TargetControl = this.label1;
			this.siticoneDragControl5.TargetControl = this.label2;
			this.siticonePanel2.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.siticonePanel2.Controls.Add(this.dashboard1);
			this.siticonePanel2.Controls.Add(this.guildManager1);
			this.siticonePanel2.Controls.Add(this.serverSpammer1);
			this.siticonePanel2.Controls.Add(this.reactionSpammer1);
			this.siticonePanel2.Controls.Add(this.advancedSettings1);
			this.siticonePanel2.Controls.Add(this.websocketManager1);
			this.siticonePanel2.Location = new global::System.Drawing.Point(208, 0);
			this.siticonePanel2.Name = "siticonePanel2";
			this.siticonePanel2.ShadowDecoration.Parent = this.siticonePanel2;
			this.siticonePanel2.Size = new global::System.Drawing.Size(704, 564);
			this.siticonePanel2.TabIndex = 3;
			this.dashboard1.BackColor = global::System.Drawing.Color.White;
			this.dashboard1.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.dashboard1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.dashboard1.Location = new global::System.Drawing.Point(0, 0);
			this.dashboard1.Name = "dashboard1";
			this.dashboard1.Size = new global::System.Drawing.Size(704, 564);
			this.dashboard1.TabIndex = 0;
			this.dashboard1.Load += new global::System.EventHandler(this.dashboard1_Load);
			this.guildManager1.BackColor = global::System.Drawing.Color.White;
			this.guildManager1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.guildManager1.Location = new global::System.Drawing.Point(0, 0);
			this.guildManager1.Name = "guildManager1";
			this.guildManager1.Size = new global::System.Drawing.Size(704, 564);
			this.guildManager1.TabIndex = 1;
			this.serverSpammer1.BackColor = global::System.Drawing.Color.White;
			this.serverSpammer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.serverSpammer1.Location = new global::System.Drawing.Point(0, 0);
			this.serverSpammer1.Name = "serverSpammer1";
			this.serverSpammer1.Size = new global::System.Drawing.Size(704, 564);
			this.serverSpammer1.TabIndex = 3;
			this.reactionSpammer1.BackColor = global::System.Drawing.Color.White;
			this.reactionSpammer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.reactionSpammer1.Location = new global::System.Drawing.Point(0, 0);
			this.reactionSpammer1.Name = "reactionSpammer1";
			this.reactionSpammer1.Size = new global::System.Drawing.Size(704, 564);
			this.reactionSpammer1.TabIndex = 2;
			this.advancedSettings1.BackColor = global::System.Drawing.Color.White;
			this.advancedSettings1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.advancedSettings1.Location = new global::System.Drawing.Point(0, 0);
			this.advancedSettings1.Name = "advancedSettings1";
			this.advancedSettings1.Size = new global::System.Drawing.Size(704, 564);
			this.advancedSettings1.TabIndex = 4;
			this.websocketManager1.BackColor = global::System.Drawing.Color.White;
			this.websocketManager1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.websocketManager1.Location = new global::System.Drawing.Point(0, 0);
			this.websocketManager1.Name = "websocketManager1";
			this.websocketManager1.Size = new global::System.Drawing.Size(704, 564);
			this.websocketManager1.TabIndex = 5;
			this.siticoneDragControl6.TargetControl = this.siticonePanel2;
			this.siticoneDragControl7.TargetControl = null;
			this.bunifuDragControl1.Fixed = true;
			this.bunifuDragControl1.Horizontal = true;
			this.bunifuDragControl1.TargetControl = null;
			this.bunifuDragControl1.Vertical = true;
			this.siticoneElipse1.TargetControl = this;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(914, 566);
			base.ControlBox = false;
			base.Controls.Add(this.siticonePanel2);
			base.Controls.Add(this.siticonePanel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Form1";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BlackSpammer XS";
			base.Load += new global::System.EventHandler(this.Form1_Load);
			this.siticonePanel1.ResumeLayout(false);
			this.siticonePanel1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.siticonePanel2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000286 RID: 646
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000287 RID: 647
		private global::Siticone.UI.WinForms.SiticoneShadowForm siticoneShadowForm1;

		// Token: 0x04000288 RID: 648
		private global::Siticone.UI.WinForms.SiticoneDragControl siticoneDragControl1;

		// Token: 0x04000289 RID: 649
		private global::Siticone.UI.WinForms.SiticonePanel siticonePanel1;

		// Token: 0x0400028A RID: 650
		private global::Siticone.UI.WinForms.SiticoneDragControl siticoneDragControl2;

		// Token: 0x0400028B RID: 651
		private global::Siticone.UI.WinForms.SiticoneButton siticoneButton4;

		// Token: 0x0400028C RID: 652
		private global::Siticone.UI.WinForms.SiticoneButton siticoneButton3;

		// Token: 0x0400028D RID: 653
		private global::Siticone.UI.WinForms.SiticoneButton siticoneButton2;

		// Token: 0x0400028E RID: 654
		private global::Siticone.UI.WinForms.SiticoneButton siticoneButton1;

		// Token: 0x0400028F RID: 655
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000290 RID: 656
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000291 RID: 657
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000292 RID: 658
		private global::Siticone.UI.WinForms.SiticoneDragControl siticoneDragControl3;

		// Token: 0x04000293 RID: 659
		private global::Siticone.UI.WinForms.SiticoneDragControl siticoneDragControl4;

		// Token: 0x04000294 RID: 660
		private global::Siticone.UI.WinForms.SiticoneDragControl siticoneDragControl5;

		// Token: 0x04000295 RID: 661
		private global::Siticone.UI.WinForms.SiticonePanel siticonePanel2;

		// Token: 0x04000296 RID: 662
		private global::Siticone.UI.WinForms.SiticoneDragControl siticoneDragControl6;

		// Token: 0x04000297 RID: 663
		private global::Siticone.UI.WinForms.SiticoneDragControl siticoneDragControl7;

		// Token: 0x04000298 RID: 664
		private global::BlackSpammerXS.Dashboard dashboard1;

		// Token: 0x04000299 RID: 665
		private global::Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;

		// Token: 0x0400029A RID: 666
		private global::BlackSpammerXS.GuildManager guildManager1;

		// Token: 0x0400029B RID: 667
		private global::BlackSpammerXS.ServerSpammer serverSpammer1;

		// Token: 0x0400029C RID: 668
		private global::BlackSpammerXS.ReactionSpammer reactionSpammer1;

		// Token: 0x0400029D RID: 669
		private global::Siticone.UI.WinForms.SiticoneButton siticoneButton6;

		// Token: 0x0400029E RID: 670
		private global::BlackSpammerXS.AdvancedSettings advancedSettings1;

		// Token: 0x0400029F RID: 671
		private global::Siticone.UI.WinForms.SiticoneGradientButton siticoneGradientButton1;

		// Token: 0x040002A0 RID: 672
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040002A1 RID: 673
		private global::Siticone.UI.WinForms.SiticoneElipse siticoneElipse1;

		// Token: 0x040002A2 RID: 674
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton3;

		// Token: 0x040002A3 RID: 675
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton2;

		// Token: 0x040002A4 RID: 676
		private global::Siticone.UI.WinForms.SiticoneImageButton siticoneImageButton1;

		// Token: 0x040002A5 RID: 677
		private global::Siticone.UI.WinForms.SiticoneButton siticoneButton5;

		// Token: 0x040002A6 RID: 678
		private global::BlackSpammerXS.WebsocketManager websocketManager1;
	}
}
