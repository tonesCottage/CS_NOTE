using System;
using System.Drawing;

namespace KaleidoApp
{
	/// <summary>
	/// PointCoord 的摘要说明。
	/// </summary>
	public class PointCoord
	{
		public double x,y;
		public PointCoord()
		{
			x=0; y=0;
		}
		public PointCoord( double x, double y )
		{
			this.x=x; this.y=y;
		}
		public Point toScrPoint( int x0, int y0 )
		{
			return new Point( (int)(x+x0), (int)(y+y0) );
		}
		public static Point toScrPoint( double x, double y, int x0, int y0 )
		{
			return new Point( (int)(x+x0), (int)(y+y0) );
		}
	}
}
