using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageProcessor
{
	/// <summary>
	/// Filter 的摘要说明。
	/// </summary>
	public class Filters
	{

		public static bool Invert(Bitmap b)
		{
			BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), 
				ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
			int stride = bmData.Stride;
			System.IntPtr Scan0 = bmData.Scan0;
			unsafe
			{
				byte * p = (byte *)(void *)Scan0;
				int nOffset = stride - b.Width*3;
				int nWidth = b.Width * 3;
				for(int y=0;y<b.Height;++y)
				{
					for(int x=0; x < nWidth; ++x )
					{
						p[0] = (byte)(255-p[0]);
						++p;
					}
					p += nOffset;
				}
			}
			b.UnlockBits(bmData);
			return true;
		}

		public static bool Gray(Bitmap b)
		{
			BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), 
				ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
			int stride = bmData.Stride;
			System.IntPtr Scan0 = bmData.Scan0;
			unsafe
			{
				byte * p = (byte *)(void *)Scan0;
				int nOffset = stride - b.Width*3;
				byte red, green, blue;
				for(int y=0;y<b.Height;++y)
				{
					for(int x=0; x < b.Width; ++x )
					{
						blue = p[0];
						green = p[1];
						red = p[2];
						p[0] = p[1] = p[2] = (byte)(.299 * red + .587 * green + .114 * blue);
						p += 3;
					}
					p += nOffset;
				}
			}
			b.UnlockBits(bmData);
			return true;
		}

		public static bool Brightness(Bitmap b, int nBrightness)
		{
			if (nBrightness < -255 || nBrightness > 255)
				return false;
			BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width,
				b.Height), ImageLockMode.ReadWrite, 
				PixelFormat.Format24bppRgb);
			int stride = bmData.Stride;
			System.IntPtr Scan0 = bmData.Scan0;
			int nVal = 0;
			unsafe
			{
				byte * p = (byte *)(void *)Scan0;
				int nOffset = stride - b.Width*3;
				int nWidth = b.Width * 3;
				for(int y=0;y<b.Height;++y)
				{
					for(int x=0; x < nWidth; ++x )
					{
						nVal = (int) (p[0] + nBrightness);
						if (nVal < 0) nVal = 0;
						if (nVal > 255) nVal = 255;
						p[0] = (byte)nVal;
						++p;
					}
					p += nOffset;
				}
			}
			b.UnlockBits(bmData);
			return true;
		} 


	}
}
