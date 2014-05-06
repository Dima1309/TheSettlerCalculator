using System;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TheSettlersCalculator.Helper
{
	internal static class ImageHelper
	{
		internal static BitmapSource LoadFromResources(string fileName)
		{
			Stream stream = null;
			try
			{
				Assembly assembly = Assembly.GetExecutingAssembly();
				stream = assembly.GetManifestResourceStream(fileName);
				return LoadImage(stream, fileName, -1);

			}
			catch(Exception)
			{
			}
			finally
			{
				if (stream != null)
				{
					stream.Close();
				}
			}
			return null;
		}

		internal static BitmapSource LoadFromFile(string fileName, int dpi=-1)
		{
			Stream stream = null;
			try
			{
				stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
				return LoadImage(stream, fileName, dpi);
			}
			catch(Exception)
			{
			}
			finally
			{
				if (stream != null)
				{
					//stream.Close();
				}
			}

			return null;
		}

		private static BitmapSource LoadImage(Stream stream, string filename, int dpi)
		{
			filename = filename.ToUpperInvariant();
			BitmapDecoder decoder = null;
			if (filename.EndsWith(".PNG"))
			{
				decoder = new PngBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
			}
			else if (filename.EndsWith(".JPG") || filename.EndsWith(".JPEG"))
			{
				decoder = new JpegBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);				
			}

			if (dpi < 0)
			{
				return decoder != null ? decoder.Frames[0] : null;
			}
			else
			{
				int stride = decoder.Frames[0].PixelWidth * 4; 
				byte[] pixelData = new byte[stride * decoder.Frames[0].PixelHeight];
				decoder.Frames[0].CopyPixels(pixelData, stride, 0);
				return BitmapSource.Create(decoder.Frames[0].PixelWidth, decoder.Frames[0].PixelHeight,
					dpi, dpi, PixelFormats.Bgra32, decoder.Frames[0].Palette, pixelData, stride);
			}
		}
	}
}
