
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

					MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);

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

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			// messagebox are you sure you want to exit yes/cancel
			string messageBoxText = "Are you sure you want to exit?";
			string caption = "PCSU";
			MessageBoxButton button = MessageBoxButton.OKCancel;
			MessageBoxImage icon = MessageBoxImage.Warning;
			MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
			if (result == MessageBoxResult.Cancel)
			{
				return;
			}
			else
			{
				// exit
				Application.Current.Shutdown();
			}
		}

		private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = (MessageBox.Show("Do you want to exit?", "", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes) ?
				 true : false;
		}

	}
}

