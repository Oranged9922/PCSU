namespace PCSU.MainApplication
{
	using System.Windows;
	using PCSU.Controllers;
	using PCSU.Models;

	/// <summary>
	/// Interaction logic for OnDeleteWindow.xaml
	/// </summary>
	public partial class OnDeleteWindow : Window
	{
		private readonly PhotoController _photoController;

		public OnDeleteWindow(PhotoController photoController)
		{
			InitializeComponent();
			_photoController = photoController;
			_photoController.GetAllPhotos().ForEach(x => this.ListBox.Items.Add(x));
		}

		private void ButtonCancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void ButtonRemove_Click(object sender, RoutedEventArgs e)
		{
			foreach (Photo item in this.ListBox.SelectedItems)
			{
				_photoController.RemovePhoto(item);
			}
			this.Close();
		}
	}
}
