using System;
using System.IO;
using System.Reflection;
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
				return LoadImage(stream, fileName);

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

		internal static BitmapSource LoadFromFile(string fileName)
		{
			Stream stream = null;
			try
			{
				stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
				return LoadImage(stream, fileName);
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

		private static BitmapSource LoadImage(Stream stream, string filename)
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

			if (filename.ToLowerInvariant().Contains("assassine"))
			{
				
			}

			return decoder!=null?decoder.Frames[0]:null;
		}
	}
}
