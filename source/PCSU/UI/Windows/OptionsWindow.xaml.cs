namespace PCSU.UI.Windowing
{
	using System.Windows;
	using System.Windows.Controls;
	using PCSU.Interfaces;

	/// <summary>
	/// Interaction logic for OptionsWindow.xaml
	/// </summary>
	public partial class OptionsWindow : Window
	{
		private readonly IOptionsWindowController optionsWindowController;
		public OptionsWindow(IOptionsWindowController owc)
		{
			InitializeComponent();
			optionsWindowController = owc;
		}

		private void ButtonDefault_Click(object sender, RoutedEventArgs e) { try {  optionsWindowController.ButtonDefault(); } catch (Exception ex) { MessageBox.Show(ex.Message); } }
		private void ListBoxDestinationOptions_SelectionChanged(object sender, SelectionChangedEventArgs e) { try {  optionsWindowController.ListBoxDestinationOptionsSelectionChanged(); } catch (Exception ex) { MessageBox.Show(ex.Message); } }
	}
}
