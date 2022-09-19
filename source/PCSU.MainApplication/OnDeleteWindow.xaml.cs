namespace PCSU.MainApplication
{
	using System.Windows;
	using PCSU.Controllers;

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
	}
}
