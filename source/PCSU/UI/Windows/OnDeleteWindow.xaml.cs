namespace PCSU.UI.Windowing
{
	using System;
	using System.Windows;
	using PCSU.Interfaces;

	/// <summary>
	/// Interaction logic for OnDeleteWindow.xaml
	/// </summary>
	public partial class OnDeleteWindow : Window
	{
		private readonly IOnDeleteWindowController onDeleteWindowController;
		public OnDeleteWindow(IOnDeleteWindowController odwc)
		{
			InitializeComponent();
			onDeleteWindowController = odwc;
		}

		private void ButtonCancel_Click(object sender, RoutedEventArgs e) { try { onDeleteWindowController.ButtonCancel(); } catch (Exception ex) { MessageBox.Show(ex.Message); } }
		private void ButtonRemove_Click(object sender, RoutedEventArgs e) { try { onDeleteWindowController.ButtonRemove(); } catch (Exception ex) { MessageBox.Show(ex.Message); } }
	}
}
