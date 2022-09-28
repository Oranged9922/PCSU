
namespace PCSU.MainApplication
{
	using System.Collections.Generic;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Media.Imaging;
	using PCSU.Controllers;
	using PCSU.Models;

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly PhotoController _photoController = new();
		private readonly SorterController _sorterController = new();
		private readonly CompressionController _compressionController = new();

		public MainWindow()
		{
			InitializeComponent();
			///TODO 
			///FIX SOMETIMES LATER IN FUTURE
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
			Closing += MainWindow_Closing;
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
		}

		private void ButtonPhotosLoad_Click(object sender, RoutedEventArgs e)
		{
			// open file dialog
			var dialog = new Microsoft.Win32.OpenFileDialog
			{
				Multiselect = true,
				Filter = "Raw photos (*.cr2) | *.cr2"
			};
			if (dialog.ShowDialog() == true)
			{
				// load photos
				_photoController.LoadPhotos(dialog.FileNames, out List<string> errMsg, out bool isErr);
				// show window based on isErr
				if (isErr)
				{
					string messageBoxText = "Some photos were unable to load:\n\n";
					foreach (string? msg in errMsg)
					{
						messageBoxText += msg + "\n";
					}

					string caption = "PCSU";
					MessageBoxButton button = MessageBoxButton.OK;
					MessageBoxImage icon = MessageBoxImage.Warning;

					_ = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);

				}
			}
			UpdateListBoxFile();
		}

		private void UpdateListBoxFile()
		{
			// clear listbox
			ListBoxFile.Items.Clear();
			_photoController.GetAllPhotos().ForEach(x => ListBoxFile.Items.Add(x.Path));

		}

		private void ListBoxFile_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (ListBoxFile.Items.Count == 0)
			{
				this.PhotoImageBox.Source = null;
				this.StackPanelFileInformation.Children.Clear();
				return;
			}
			Photo? image = _photoController.GetPhoto(ListBoxFile.SelectedIndex);

			this.PhotoImageBox.Source = new BitmapImage(new(image.Path));
			this.StackPanelFileInformation.Children.Clear();
			foreach ((string name, object value) in image.GetPropertiesList())
			{
				this.StackPanelFileInformation.Children.Add(
				 new TextBlock
				 {
					 Text = name + ": " + value,
					 Margin = new Thickness(5, 0, 0, 0)
				 });
			}
		}

		private void ButtonPhotosRemove_Click(object sender, RoutedEventArgs e)
		{
			// open OnDeleteWindow
			OnDeleteWindow onDeleteWindow = new(_photoController);
			onDeleteWindow.ShowDialog();
			this.UpdateListBoxFile();
		}

		private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = MessageBox.Show("Are you sure you want to exit?", "", MessageBoxButton.YesNo) != MessageBoxResult.Yes;
		}

		//private void CheckBoxSortBy_Unchecked(object sender, RoutedEventArgs e)
		//{
		//	ComboBoxSortOptions.IsEnabled = false;
		//}

		//private void CheckBoxSortBy_Checked(object sender, RoutedEventArgs e)
		//{
		//	ComboBoxSortOptions.IsEnabled = true;

		//}

		//private void CheckBoxCompressWith_Checked(object sender, RoutedEventArgs e)
		//{
		//	ComboBoxCompressOptions.IsEnabled = true;

		//}
		//private void CheckBoxCompressWith_Unchecked(object sender, RoutedEventArgs e)
		//{
		//	ComboBoxCompressOptions.IsEnabled = false;
		//}

		//private void ButtonChoosePath_Click(object sender, RoutedEventArgs e)
		//{
		//	var dialog = new Microsoft.Win32.SaveFileDialog
		//	{
		//		Title = "Select a Directory",
		//		Filter = "Directory|*.this.directory",
		//		FileName = "select"
		//	};

		//	if (dialog.ShowDialog() == true)
		//	{
		//		string path = dialog.FileName;

		//		path = path.Replace("\\select.this.directory", "");
		//		path = path.Replace(".this.directory", "");

		//		if (!System.IO.Directory.Exists(path))
		//		{
		//			System.IO.Directory.CreateDirectory(path);
		//		}
		//		// Our final value is in path
		//		DestinationPath.Text = path;
		//	}
		//}

		private void ButtonRun_Click(object sender, RoutedEventArgs e)
		{

		}

		private void ButtonOptions_Click(object sender, RoutedEventArgs e)
		{
			OptionsWindow optionsWindow = new(_sorterController, _compressionController);
			optionsWindow.ShowDialog();
		}

		private void ButtonExit_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}
	}
}
