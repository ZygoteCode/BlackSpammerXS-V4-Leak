using System;
using System.Windows.Forms;

namespace BlackSpammerXS;

internal static class Program
{
	[STAThread]
	private static void Main()
	{
		try
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(defaultValue: false);
			try
			{
				Application.ThreadException += delegate
				{
					SecLG.o_wr("[dbg_ex] uncaught ex thrwn");
					try
					{
						MessageBox.Show("An Unknown Error has occurred: TN_CATCH_0x16");
					}
					catch
					{
					}
				};
			}
			catch
			{
			}
			SecurityMT._c_act_secr(241, 4241256927u);
		}
		catch (Exception)
		{
			try
			{
				MessageBox.Show("Si è verificato un errore. Riavvia l'applicazione: 0xe671");
			}
			catch
			{
			}
		}
	}
}
