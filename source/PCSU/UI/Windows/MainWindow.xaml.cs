namespace PCSU.UI.Windowing
{
	using System.Windows;
	using System.Windows.Controls;
	using PCSU.Interfaces;

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly IMainWindowController mainWindowController;

		public MainWindow(IMainWindowController mwc)
		{
			InitializeComponent();
			this.mainWindowController = mwc;
		}

		private void ButtonExit_Click(object sender, RoutedEventArgs e) { try { mainWindowController.ButtonExit(); } catch (Exception ex) { MessageBox.Show(ex.Message); } }
		private void ButtonRun_Click(object sender, RoutedEventArgs e) { try { mainWindowController.ButtonRun(); } catch (Exception ex) { MessageBox.Show(ex.Message); } }
		private void ButtonOptions_Click(object sender, RoutedEventArgs e) { try { mainWindowController.ButtonOptions(); } catch (Exception ex) { MessageBox.Show(ex.Message); } }
		private void ListBoxFile_SelectionChanged(object sender, SelectionChangedEventArgs e) { try { mainWindowController.ListBoxFileSelectionChanged(); } catch (Exception ex) { MessageBox.Show(ex.Message); } }
		private void ButtonPhotosRemove_Click(object sender, RoutedEventArgs e) { try { mainWindowController.ButtonPhotosRemove(); } catch (Exception ex) { MessageBox.Show(ex.Message); } }
		private void ButtonPhotosLoad_Click(object sender, RoutedEventArgs e) { try { mainWindowController.ButtonPhotosLoad(); } catch (Exception ex) { MessageBox.Show(ex.Message); } }
	}
}
