using System;
using System.Drawing;

namespace BlackSpammerXS
{
	// Token: 0x02000084 RID: 132
	public class MessageBox
	{
		// Token: 0x0600022B RID: 555 RVA: 0x0002904C File Offset: 0x0002724C
		public static void Show(string alert, string title = "Avviso", ContentAlignment align = ContentAlignment.MiddleCenter)
		{
			try
			{
				AlertFM alertFM = new AlertFM(alert, title, align);
				alertFM.ShowDialog();
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00029084 File Offset: 0x00027284
		public static void Show(Action<int, int> callback, string alert, string title = "Avviso", ContentAlignment align = ContentAlignment.MiddleCenter)
		{
			try
			{
				AlertFM alertFM = new AlertFM(callback, alert, title, align);
				alertFM.ShowDialog();
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600022D RID: 557 RVA: 0x000290BC File Offset: 0x000272BC
		public static void ShowLight(string alert, string title = "Avviso", ContentAlignment align = ContentAlignment.MiddleCenter)
		{
			try
			{
				AlertFM alertFM = new AlertFM(0, alert, title, align);
				alertFM.ShowDialog();
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600022E RID: 558 RVA: 0x000290F4 File Offset: 0x000272F4
		public static void ShowDark(string alert, string title = "Avviso", ContentAlignment align = ContentAlignment.MiddleCenter)
		{
			try
			{
				AlertFM alertFM = new AlertFM(1, alert, title, align);
				alertFM.ShowDialog();
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600022F RID: 559 RVA: 0x0002912C File Offset: 0x0002732C
		public static void ShowWhite(string alert, string title = "Avviso", ContentAlignment align = ContentAlignment.MiddleCenter)
		{
			try
			{
				AlertFM alertFM = new AlertFM(2, alert, title, align);
				alertFM.ShowDialog();
			}
			catch (Exception)
			{
			}
		}
	}
}
