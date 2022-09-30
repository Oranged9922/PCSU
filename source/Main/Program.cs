namespace PCSU
{
	using System;
	using PCSU.UI.Controllers;
	using PCSU.UI.Windowing;

	public class Program
	{
		[STAThread]
		public static void Main()
		{
			var app = new App();
			var mwc = new MainWindowController();
			app.Run(new MainWindow(mwc));
		}
	}
}