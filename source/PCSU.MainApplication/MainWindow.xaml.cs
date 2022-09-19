
﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

using PCSU.Controllers;
using PCSU.Models;

namespace PCSU.MainApplication
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly PhotoController _photoController = new();

		public MainWindow()
		{
			InitializeComponent();
		}

		private void ButtonPhotosLoad_Click(object sender, RoutedEventArgs e)
		{
			// open file dialog
			var dialog = new Microsoft.Win32.OpenFileDialog
			{
				Multiselect = true,
				Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png"
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
			ListBoxFile.Items.Clear();
			List<Photo> photos = photoController.GetAllPhotos();
			photos.ForEach(x => ListBoxFile.Items.Add(x));
		}

		private void ListBoxFile_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var image = photoController.GetPhoto(ListBoxFile.SelectedIndex);
			this.PhotoImageBox.Source = new BitmapImage(new(image.Path));
		}
	}
}
