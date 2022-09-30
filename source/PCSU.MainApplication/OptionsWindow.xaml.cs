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

		public OptionsWindow(SorterController sorterController)
		{
			InitializeComponent();
			_sorterController = sorterController;

			SorterController.GetAllDestinationOptions().ForEach(x => this.ListBoxDestinationOptions.Items.Add(x));
			SorterController.GetAllFileExtensionsOptions().ForEach(x => this.ComboBoxFileExtension.Items.Add(x));
			SorterController.GetAllSortSubfoldersOptions().ForEach(x => this.ListBoxSortOptions.Items.Add(x));
			SorterController.GetAllFileNamingOptions().ForEach(x =>
				{
					this.ComboBoxFileNaming1.Items.Add(x);
					this.ComboBoxFileNaming2.Items.Add(x);
					this.ComboBoxFileNaming3.Items.Add(x);
					this.ComboBoxFileNaming4.Items.Add(x);
				});
			// if Listbox contains items select first, else leave blank
			if (this.ListBoxDestinationOptions.Items.Count > 0)
			{
				this.ListBoxDestinationOptions.SelectedIndex = 0;
			}

			if (this.ListBoxSortOptions.Items.Count > 0)
			{
				this.ListBoxSortOptions.SelectedIndex = 0;
			}

			// if ListBox has selected same place, disable button 
			this.ButtonSelectFolder.IsEnabled = !SorterController.IsSaveInSameLocationSelected(this.ListBoxDestinationOptions.SelectedItem?.ToString());
			this.TextBlockSelectedFolder.Text = this.ButtonSelectFolder.IsEnabled ? _sorterController.StoredSelectedFolderDestination : string.Empty;
			this.ComboBoxFileExtension.SelectedIndex = 0;
		}

		private void ButtonDefault_Click(object sender, RoutedEventArgs e)
		{

		}

		private void ListBoxDestinationOptions_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			bool isSameLocationSelected = SorterController.IsSaveInSameLocationSelected(this.ListBoxDestinationOptions.SelectedItem?.ToString());

			if (this.ButtonSelectFolder.IsEnabled == false && isSameLocationSelected)
			{
				return;
			}

			if (this.ButtonSelectFolder.IsEnabled == false && !isSameLocationSelected)
			{
				this.ButtonSelectFolder.IsEnabled = true;
				this.TextBlockSelectedFolder.Text = _sorterController.StoredSelectedFolderDestination;
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

		private void ButtonSelectFolder_Click(object sender, RoutedEventArgs e)
		{
			var dialog = new Microsoft.Win32.SaveFileDialog
			{
				Title = "Select a Directory",
				Filter = "Directory|*.this.directory",
				FileName = "select"
			};

			if (dialog.ShowDialog() == true)
			{
				string path = dialog.FileName;

				path = path.Replace("\\select.this.directory", "");
				path = path.Replace(".this.directory", "");

				if (!System.IO.Directory.Exists(path))
				{
					System.IO.Directory.CreateDirectory(path);
				}
				// Our final value is in path
				this.TextBlockSelectedFolder.Text = path;
			}
		}

		private void ListBoxSortOptions_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{

		}

		private void RadioButtonNoSubfolders_Click(object sender, RoutedEventArgs e)
		{
			ListBoxSortOptions.IsEnabled = false;
		}

		private void RadioButtonSubfolders_Click(object sender, RoutedEventArgs e)
		{
			ListBoxSortOptions.IsEnabled = true;
		}

		private void RecalculateFileExampleName()
		{
			string fileExampleName = string.Empty;

			if (this.ComboBoxFileNaming1.SelectedItem != null)
			{
				fileExampleName += GetExamplePropertyAsString(this.ComboBoxFileNaming1.SelectedItem);
			}

			if (this.ComboBoxFileNaming2.SelectedItem != null)
			{
				fileExampleName += GetExamplePropertyAsString(this.ComboBoxFileNaming2.SelectedItem);
			}

			if (this.ComboBoxFileNaming3.SelectedItem != null)
			{
				fileExampleName += GetExamplePropertyAsString(this.ComboBoxFileNaming3.SelectedItem);
			}

			if (this.ComboBoxFileNaming4.SelectedItem != null)
			{
				fileExampleName += GetExamplePropertyAsString(this.ComboBoxFileNaming4.SelectedItem);
			}

			fileExampleName += this.ComboBoxFileExtension.SelectedItem;
			this.TextBlockExample.Text = fileExampleName;
		}

		private string GetExamplePropertyAsString(object selectedItem)
		{
			Models.Options.FileNamingOptionsEnum e = SorterController.GetFileNamingOptionsEnum((string)selectedItem);
			return _sorterController.ExampleFileNamingOptions[e];

		}
		private void ComboBoxFileNaming1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) => RecalculateFileExampleName();

		private void ComboBoxFileNaming2_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) => RecalculateFileExampleName();

		private void ComboBoxFileNaming3_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) => RecalculateFileExampleName();

		private void ComboBoxFileNaming4_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) => RecalculateFileExampleName();

		private void TextBoxBeginNumbering_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
			if (int.TryParse(this.TextBoxBeginNumbering.Text, out int res))
			{
				this._sorterController.BeginNumbering = res;
				this._sorterController.ExampleFileNamingOptions[Models.Options.FileNamingOptionsEnum.SerialNumber1] = res.ToString("0");
				this._sorterController.ExampleFileNamingOptions[Models.Options.FileNamingOptionsEnum.SerialNumber2] = res.ToString("00");
				this._sorterController.ExampleFileNamingOptions[Models.Options.FileNamingOptionsEnum.SerialNumber3] = res.ToString("000");
				this._sorterController.ExampleFileNamingOptions[Models.Options.FileNamingOptionsEnum.SerialNumber4] = res.ToString("0000");
				this._sorterController.ExampleFileNamingOptions[Models.Options.FileNamingOptionsEnum.SerialNumber5] = res.ToString("00000");
				this._sorterController.ExampleFileNamingOptions[Models.Options.FileNamingOptionsEnum.SerialNumber6] = res.ToString("000000");
				RecalculateFileExampleName();
			}
		}
	}
}
