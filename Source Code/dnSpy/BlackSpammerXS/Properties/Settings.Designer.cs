using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BlackSpammerXS.Properties
{
	// Token: 0x020000B2 RID: 178
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.8.1.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x060002F4 RID: 756 RVA: 0x00036D98 File Offset: 0x00034F98
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x060002F5 RID: 757 RVA: 0x00036DB0 File Offset: 0x00034FB0
		// (set) Token: 0x060002F6 RID: 758 RVA: 0x00036DD2 File Offset: 0x00034FD2
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string _U
		{
			get
			{
				return (string)this["_U"];
			}
			set
			{
				this["_U"] = value;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x060002F7 RID: 759 RVA: 0x00036DE4 File Offset: 0x00034FE4
		// (set) Token: 0x060002F8 RID: 760 RVA: 0x00036E06 File Offset: 0x00035006
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string _P
		{
			get
			{
				return (string)this["_P"];
			}
			set
			{
				this["_P"] = value;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x060002F9 RID: 761 RVA: 0x00036E18 File Offset: 0x00035018
		// (set) Token: 0x060002FA RID: 762 RVA: 0x00036E3A File Offset: 0x0003503A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string lastProxies
		{
			get
			{
				return (string)this["lastProxies"];
			}
			set
			{
				this["lastProxies"] = value;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x060002FB RID: 763 RVA: 0x00036E4C File Offset: 0x0003504C
		// (set) Token: 0x060002FC RID: 764 RVA: 0x00036E6E File Offset: 0x0003506E
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string lastTokens
		{
			get
			{
				return (string)this["lastTokens"];
			}
			set
			{
				this["lastTokens"] = value;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x060002FD RID: 765 RVA: 0x00036E80 File Offset: 0x00035080
		// (set) Token: 0x060002FE RID: 766 RVA: 0x00036EA2 File Offset: 0x000350A2
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool dark
		{
			get
			{
				return (bool)this["dark"];
			}
			set
			{
				this["dark"] = value;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x060002FF RID: 767 RVA: 0x00036EB8 File Offset: 0x000350B8
		// (set) Token: 0x06000300 RID: 768 RVA: 0x00036EDA File Offset: 0x000350DA
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string capkeyCAPmon
		{
			get
			{
				return (string)this["capkeyCAPmon"];
			}
			set
			{
				this["capkeyCAPmon"] = value;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000301 RID: 769 RVA: 0x00036EEC File Offset: 0x000350EC
		// (set) Token: 0x06000302 RID: 770 RVA: 0x00036F0E File Offset: 0x0003510E
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string capkeyTWOcap
		{
			get
			{
				return (string)this["capkeyTWOcap"];
			}
			set
			{
				this["capkeyTWOcap"] = value;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000303 RID: 771 RVA: 0x00036F20 File Offset: 0x00035120
		// (set) Token: 0x06000304 RID: 772 RVA: 0x00036F42 File Offset: 0x00035142
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("{\"joins\": [], \"leaves\": [], \"spam\": [], \"reaction\": []}")]
		public string audit
		{
			get
			{
				return (string)this["audit"];
			}
			set
			{
				this["audit"] = value;
			}
		}

		// Token: 0x04000690 RID: 1680
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
