namespace PCSU.UI.Controllers
{
	using System.Windows;
	using PCSU.Interfaces;
	using PCSU.UI.Windowing;

	public class MainWindowController : IMainWindowController
	{
		public void ButtonExit() => Application.Current.Shutdown();
		public void ButtonOptions()
		{
			var OptionsWindowController = new OptionsWindowController();
			var optionsWindow = new OptionsWindow(OptionsWindowController);
			optionsWindow.ShowDialog();
		}
		public void ButtonPhotosLoad()
		{
			throw new System.NotImplementedException();
		}
		public void ButtonPhotosRemove()
		{
			var OnDeleteWindowController = new OnDeleteWindowController();
			var onDeleteWindow = new OnDeleteWindow(OnDeleteWindowController);
			onDeleteWindow.ShowDialog();
		}
		public void ButtonRun() => throw new NotImplementedException();
		public void ListBoxFileSelectionChanged() => throw new NotImplementedException();
	}
}
