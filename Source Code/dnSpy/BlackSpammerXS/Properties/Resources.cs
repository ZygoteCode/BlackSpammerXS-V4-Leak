using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace BlackSpammerXS.Properties
{
	// Token: 0x020000B1 RID: 177
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x060002F0 RID: 752 RVA: 0x00036D24 File Offset: 0x00034F24
		internal Resources()
		{
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x060002F1 RID: 753 RVA: 0x00036D30 File Offset: 0x00034F30
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resources.resourceMan == null;
				if (flag)
				{
					ResourceManager resourceManager = new ResourceManager("BlackSpammerXS.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x00036D78 File Offset: 0x00034F78
		// (set) Token: 0x060002F3 RID: 755 RVA: 0x00036D8F File Offset: 0x00034F8F
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x0400068E RID: 1678
		private static ResourceManager resourceMan;

		// Token: 0x0400068F RID: 1679
		private static CultureInfo resourceCulture;
	}
}
