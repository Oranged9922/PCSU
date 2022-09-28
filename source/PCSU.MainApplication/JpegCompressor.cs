namespace PCSU.MainApplication
{
	using System.Linq;
	using System.Drawing;
	using System.Drawing.Imaging;
	public static class JpegCompressor
	{
		public static void Compress(string imagePath, string outputFolder, int quality, string postfix = "")
		{
			string name = imagePath[(imagePath.LastIndexOf('\\') + 1)..];
			name = name.Replace(".jpg", postfix + ".jpg");
			// Load the JPEG image using Image class
			using var image = Image.FromFile(imagePath);
			ImageCodecInfo? jpegCodec = ImageCodecInfo.GetImageEncoders().First(enc => enc.FormatID == ImageFormat.Jpeg.Guid);
			var jpegParams = new EncoderParameters(1)
			{
				Param = new[] { new EncoderParameter(Encoder.Quality, quality) }
			};
			image.Save(outputFolder + "\\" + name, jpegCodec, jpegParams);
		}
	}
}
