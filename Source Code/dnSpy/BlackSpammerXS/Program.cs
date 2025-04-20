using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace BlackSpammerXS
{
	// Token: 0x02000086 RID: 134
	internal static class Program
	{
		// Token: 0x06000238 RID: 568 RVA: 0x00029408 File Offset: 0x00027608
		[STAThread]
		private static void Main()
		{
			try
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				try
				{
					Application.ThreadException += delegate(object a, ThreadExceptionEventArgs b)
					{
						SecLG.o_wr("[dbg_ex] uncaught ex thrwn");
						try
						{
							MessageBox.Show("An Unknown Error has occurred: TN_CATCH_0x16", "Avviso", ContentAlignment.MiddleCenter);
						}
						catch
						{
						}
					};
				}
				catch
				{
				}
				SecurityMT._c_act_secr(241, 4241256927U);
			}
			catch (Exception)
			{
				try
				{
					MessageBox.Show("Si è verificato un errore. Riavvia l'applicazione: 0xe671", "Avviso", ContentAlignment.MiddleCenter);
				}
				catch
				{
				}
			}
		}
	}
}
