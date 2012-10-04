
using System.Reflection;
using System.Windows.Media.Imaging;

namespace TheSettlersCalculator.Helper
{
	internal static class ImageHelper
	{
		internal static BitmapSource LoadPng(string fileName)
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			PngBitmapDecoder pngBitmapDecoder = new PngBitmapDecoder(
				assembly.GetManifestResourceStream(fileName),
				BitmapCreateOptions.PreservePixelFormat,
				BitmapCacheOption.Default);
			return pngBitmapDecoder.Frames[0];
		}

		internal static BitmapSource LoadJpg(string fileName)
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			JpegBitmapDecoder jpegBitmapDecoder = new JpegBitmapDecoder(
				assembly.GetManifestResourceStream(fileName),
				BitmapCreateOptions.PreservePixelFormat,
				BitmapCacheOption.Default);
			return jpegBitmapDecoder.Frames[0];
		}
	}
}
