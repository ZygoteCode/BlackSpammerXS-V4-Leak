using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BlackSpammerXS.Properties;

[CompilerGenerated]
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.8.1.0")]
internal sealed class Settings : ApplicationSettingsBase
{
	private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());

	public static Settings Default => defaultInstance;

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
}
