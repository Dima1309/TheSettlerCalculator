using System;
using System.IO;
using System.Reflection;
using System.Windows.Media.Imaging;
using System.Xml;

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

			return decoder!=null?decoder.Frames[0]:null;
		}

		internal static void SaveToXml(XmlWriter writer, BitmapSource image)
		{
			MemoryStream stream = null;
			try
			{
				stream = ImageToStream(image);
				writer.WriteAttributeString("length", stream.Length.ToString());
				writer.WriteBase64(stream.GetBuffer(), 0, (int) stream.Length);
			}
			finally
			{
				if (stream != null)
				{
					stream.Dispose();
				}
			}
		}

		internal static BitmapSource LoadFromXml(XmlReader reader)
		{
			string lengthStr = reader.GetAttribute("length");
			int length = int.Parse(lengthStr);
			byte[] buffer = new byte[length];
			reader.ReadElementContentAsBase64(buffer, 0, length);
			MemoryStream stream = null;
			try
			{
				stream = new MemoryStream(buffer);
				return LoadImage(stream, ".jpg");
			}
			finally
			{
				if (stream != null)
				{
					stream.Dispose();
				}
			}
		}

		private static MemoryStream ImageToStream(BitmapSource image)
		{
			JpegBitmapEncoder encoder = new JpegBitmapEncoder();
			encoder.Frames.Add(BitmapFrame.Create(image));
			MemoryStream result = new MemoryStream();
			encoder.Save(result);
			return result;
		}
	}
}
