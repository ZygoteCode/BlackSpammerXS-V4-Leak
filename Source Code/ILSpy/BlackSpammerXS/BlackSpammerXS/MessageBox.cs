using System;
using System.Drawing;

namespace BlackSpammerXS;

public class MessageBox
{
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
