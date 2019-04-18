using System;

namespace KaleidoApp
{
	/// <summary>
	/// Polygon 的摘要说明。
	/// </summary>
	public class Polygon
	{

		public int [] xpoints;
		public int [] ypoints;

		public Polygon( int [] xpoints, int [] ypoints, int n)
		{
			this.xpoints = xpoints;
			this.ypoints = ypoints;
		}
		
		public System.Drawing.Point[] toPoints()
		{
			if(xpoints==null) return null;
			System.Drawing.Point[] ary = new System.Drawing.Point[xpoints.Length];
			for(int i=0; i<xpoints.Length; i++)
			{
				ary[i] = new System.Drawing.Point(xpoints[i], ypoints[i]);
			}
			return ary;
		}

		public bool contains( System.Drawing.Point p )
		{
			System.Drawing.Drawing2D.GraphicsPath   myGraphicsPath=new System.Drawing.Drawing2D.GraphicsPath();                
			//Region myRegion=new Region();
			myGraphicsPath.Reset();   
			myGraphicsPath.AddPolygon( toPoints() );
			return myGraphicsPath.IsVisible( p );

		}
	}
}
