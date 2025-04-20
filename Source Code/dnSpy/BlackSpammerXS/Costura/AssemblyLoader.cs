using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Costura
{
	// Token: 0x020000B3 RID: 179
	[CompilerGenerated]
	internal static class AssemblyLoader
	{
		// Token: 0x06000307 RID: 775 RVA: 0x00036F71 File Offset: 0x00035171
		private static string CultureToString(CultureInfo culture)
		{
			if (culture == null)
			{
				return "";
			}
			return culture.Name;
		}

		// Token: 0x06000308 RID: 776 RVA: 0x00036F84 File Offset: 0x00035184
		private static Assembly ReadExistingAssembly(AssemblyName name)
		{
			foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
			{
				AssemblyName name2 = assembly.GetName();
				if (string.Equals(name2.Name, name.Name, StringComparison.InvariantCultureIgnoreCase) && string.Equals(AssemblyLoader.CultureToString(name2.CultureInfo), AssemblyLoader.CultureToString(name.CultureInfo), StringComparison.InvariantCultureIgnoreCase))
				{
					return assembly;
				}
			}
			return null;
		}

		// Token: 0x06000309 RID: 777 RVA: 0x00036FEC File Offset: 0x000351EC
		private static void CopyTo(Stream source, Stream destination)
		{
			byte[] array = new byte[81920];
			int num;
			while ((num = source.Read(array, 0, array.Length)) != 0)
			{
				destination.Write(array, 0, num);
			}
		}

		// Token: 0x0600030A RID: 778 RVA: 0x00037020 File Offset: 0x00035220
		private static Stream LoadStream(string fullName)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (fullName.EndsWith(".compressed"))
			{
				using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(fullName))
				{
					using (DeflateStream deflateStream = new DeflateStream(manifestResourceStream, CompressionMode.Decompress))
					{
						MemoryStream memoryStream = new MemoryStream();
						AssemblyLoader.CopyTo(deflateStream, memoryStream);
						memoryStream.Position = 0L;
						return memoryStream;
					}
				}
			}
			return executingAssembly.GetManifestResourceStream(fullName);
		}

		// Token: 0x0600030B RID: 779 RVA: 0x000370A4 File Offset: 0x000352A4
		private static Stream LoadStream(Dictionary<string, string> resourceNames, string name)
		{
			string text;
			if (resourceNames.TryGetValue(name, out text))
			{
				return AssemblyLoader.LoadStream(text);
			}
			return null;
		}

		// Token: 0x0600030C RID: 780 RVA: 0x000370C4 File Offset: 0x000352C4
		private static byte[] ReadStream(Stream stream)
		{
			byte[] array = new byte[stream.Length];
			stream.Read(array, 0, array.Length);
			return array;
		}

		// Token: 0x0600030D RID: 781 RVA: 0x000370EC File Offset: 0x000352EC
		private static Assembly ReadFromEmbeddedResources(Dictionary<string, string> assemblyNames, Dictionary<string, string> symbolNames, AssemblyName requestedAssemblyName)
		{
			string text = requestedAssemblyName.Name.ToLowerInvariant();
			if (requestedAssemblyName.CultureInfo != null && !string.IsNullOrEmpty(requestedAssemblyName.CultureInfo.Name))
			{
				text = requestedAssemblyName.CultureInfo.Name + "." + text;
			}
			byte[] array;
			using (Stream stream = AssemblyLoader.LoadStream(assemblyNames, text))
			{
				if (stream == null)
				{
					return null;
				}
				array = AssemblyLoader.ReadStream(stream);
			}
			using (Stream stream2 = AssemblyLoader.LoadStream(symbolNames, text))
			{
				if (stream2 != null)
				{
					byte[] array2 = AssemblyLoader.ReadStream(stream2);
					return Assembly.Load(array, array2);
				}
			}
			return Assembly.Load(array);
		}

		// Token: 0x0600030E RID: 782 RVA: 0x000371AC File Offset: 0x000353AC
		public static Assembly ResolveAssembly(object sender, ResolveEventArgs e)
		{
			object obj = AssemblyLoader.nullCacheLock;
			lock (obj)
			{
				if (AssemblyLoader.nullCache.ContainsKey(e.Name))
				{
					return null;
				}
			}
			AssemblyName assemblyName = new AssemblyName(e.Name);
			Assembly assembly = AssemblyLoader.ReadExistingAssembly(assemblyName);
			if (assembly != null)
			{
				return assembly;
			}
			assembly = AssemblyLoader.ReadFromEmbeddedResources(AssemblyLoader.assemblyNames, AssemblyLoader.symbolNames, assemblyName);
			if (assembly == null)
			{
				obj = AssemblyLoader.nullCacheLock;
				lock (obj)
				{
					AssemblyLoader.nullCache[e.Name] = true;
				}
				if ((assemblyName.Flags & AssemblyNameFlags.Retargetable) != AssemblyNameFlags.None)
				{
					assembly = Assembly.Load(assemblyName);
				}
			}
			return assembly;
		}

		// Token: 0x0600030F RID: 783 RVA: 0x0003728C File Offset: 0x0003548C
		// Note: this type is marked as 'beforefieldinit'.
		static AssemblyLoader()
		{
			AssemblyLoader.assemblyNames.Add("blackverifynumber", "costura.blackverifynumber.dll.compressed");
			AssemblyLoader.symbolNames.Add("blackverifynumber", "costura.blackverifynumber.pdb.compressed");
			AssemblyLoader.assemblyNames.Add("brotlisharplib", "costura.brotlisharplib.dll.compressed");
			AssemblyLoader.assemblyNames.Add("bunifu_ui_v1.52", "costura.bunifu_ui_v1.52.dll.compressed");
			AssemblyLoader.assemblyNames.Add("costura", "costura.costura.dll.compressed");
			AssemblyLoader.assemblyNames.Add("microsoft.extensions.dependencyinjection.abstractions", "costura.microsoft.extensions.dependencyinjection.abstractions.dll.compressed");
			AssemblyLoader.assemblyNames.Add("microsoft.extensions.dependencyinjection", "costura.microsoft.extensions.dependencyinjection.dll.compressed");
			AssemblyLoader.assemblyNames.Add("newtonsoft.json", "costura.newtonsoft.json.dll.compressed");
			AssemblyLoader.assemblyNames.Add("siticone.ui", "costura.siticone.ui.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.collections.immutable", "costura.system.collections.immutable.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.diagnostics.diagnosticsource", "costura.system.diagnostics.diagnosticsource.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.interactive.async", "costura.system.interactive.async.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.reactive", "costura.system.reactive.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.runtime.compilerservices.unsafe", "costura.system.runtime.compilerservices.unsafe.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.threading.channels", "costura.system.threading.channels.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.threading.tasks.extensions", "costura.system.threading.tasks.extensions.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.valuetuple", "costura.system.valuetuple.dll.compressed");
			AssemblyLoader.assemblyNames.Add("websocket.client", "costura.websocket.client.dll.compressed");
			AssemblyLoader.assemblyNames.Add("windowsinput", "costura.windowsinput.dll.compressed");
		}

		// Token: 0x06000310 RID: 784 RVA: 0x0003743D File Offset: 0x0003563D
		public static void Attach()
		{
			if (Interlocked.Exchange(ref AssemblyLoader.isAttached, 1) == 1)
			{
				return;
			}
			AppDomain.CurrentDomain.AssemblyResolve += AssemblyLoader.ResolveAssembly;
		}

		// Token: 0x04000691 RID: 1681
		private static object nullCacheLock = new object();

		// Token: 0x04000692 RID: 1682
		private static Dictionary<string, bool> nullCache = new Dictionary<string, bool>();

		// Token: 0x04000693 RID: 1683
		private static Dictionary<string, string> assemblyNames = new Dictionary<string, string>();

		// Token: 0x04000694 RID: 1684
		private static Dictionary<string, string> symbolNames = new Dictionary<string, string>();

		// Token: 0x04000695 RID: 1685
		private static int isAttached;
	}
}
