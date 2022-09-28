namespace PCSU.MainApplication
{
	using System.Windows;
	using PCSU.Controllers;

	/// <summary>
	/// Interaction logic for OptionsWindow.xaml
	/// </summary>
	public partial class OptionsWindow : Window
	{
		private readonly SorterController _sorterController;
		private readonly CompressionController _compressionController;
		public OptionsWindow(SorterController sorterController, CompressionController compressionController)
		{
			InitializeComponent();
			_sorterController = sorterController;
			_compressionController = compressionController;

			_sorterController.GetAllDestinationOptions().ForEach(x => this.ListBoxDestinationOptions.Items.Add(x));
			// if Listbox contains items select first, else leave blank
			if (this.ListBoxDestinationOptions.Items.Count > 0)
			{
				this.ListBoxDestinationOptions.SelectedIndex = 0;
			}

			// if ListBox has selected same place, disable button 
			this.ButtonSelectFolder.IsEnabled = _sorterController.IsSaveInSameLocationSelected(this.ListBoxDestinationOptions.SelectedItem?.ToString()) ? false : true;
			if (this.ButtonSelectFolder.IsEnabled)
			{
				this.TextBlockSelectedFolder.Text = _sorterController.GetSelectedFolder();
			}
			else
			{
				this.TextBlockSelectedFolder.Text = string.Empty;
			}
		}

		private void ButtonDefault_Click(object sender, RoutedEventArgs e)
		{
			UpdateWindow();
		}

		private void UpdateWindow()
		{
			;
		}

		private void ListBoxDestinationOptions_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			var isSameLocationSelected = _sorterController.IsSaveInSameLocationSelected(this.ListBoxDestinationOptions.SelectedItem?.ToString()) ? true : false;

			if (this.ButtonSelectFolder.IsEnabled == false && isSameLocationSelected)
			{
				return;
			}

			if (this.ButtonSelectFolder.IsEnabled == false && !isSameLocationSelected)
			{
				this.ButtonSelectFolder.IsEnabled = true;
				this.TextBlockSelectedFolder.Text = _sorterController.GetSelectedFolder();
			}

			if (this.ButtonSelectFolder.IsEnabled == true && isSameLocationSelected)
			{
				this.ButtonSelectFolder.IsEnabled = false;
				this.TextBlockSelectedFolder.Text = string.Empty;
			}
			if (this.ButtonSelectFolder.IsEnabled == true && !isSameLocationSelected)
			{
				return;
			}
		}
	}
}
