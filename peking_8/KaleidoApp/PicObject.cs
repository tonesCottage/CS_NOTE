using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;

namespace KaleidoApp
{



	public class PicObject
	{

		public int type=TYPE_POLYGON;
		public Color color=Color.Black;
		public bool filled=false;
		public ArrayList polygon=null;
	
		public Mirror mirror;  // which mirror
		public PicObject srcPicObject;  //which object to make the picObject, it can be PicObject or a PicInMirrorObject
		public PicObject originalPicObject;  //the actual object outside the mirror

	
		public const int TYPE_POLYGON=0;
		public const int TYPE_POINT=1;
		public const int TYPE_CIRCLE=2;
	
		public PicObject ( Color color )
		{
			this.color=color;
			polygon=new ArrayList();
		}
		public PicObject ( int type ,Color color):this( color)
		{
			
			this.type = type;
		}
		public PicObject( int type, Color color, bool filled):this(type ,color)
		{
			this.filled=filled;
		}
		public void addPoint( double x, double y )
		{
			polygon.Add( new PointCoord(x,y) );
		}
		public void addPoint( PointCoord p )
		{
			addPoint( p.x, p.y );
		}
		public void clear()
		{
			polygon.Clear ();
		}
		public bool isEmpty()
		{
			return polygon.Count==0;
		}
	
		public PointCoord getPoint( int index )
		{
			return (PointCoord) polygon[ index ];
		}
		public double getPointX( int index )
		{
			return getPoint( index).x;
		}
		public double getPointY( int index )
		{
			return getPoint( index).y;
		}
		public int countPoint( )
		{
			return polygon.Count;
		}
	
		public Polygon toScrPolygon( int x0, int y0 )
		{
			if( type == TYPE_POLYGON ) 
			{
				int n=countPoint();
				int[] x=new int[n], y=new int[n];
				for( int i=0;i<n;i++)
				{
					Point p=PointCoord.toScrPoint (getPoint(i).x, getPoint(i).y, x0,y0 );
					x[i]=p.X; y[i]=p.Y;
				}
				return new Polygon( x, y, n);
			}
			else
			{
				return null;  //?????
			}
		}
		
		public bool contains( PointCoord p )
		{
			return toScrPolygon(0,0).contains (p.toScrPoint (0,0));
		}
	
		public bool contains( double x, double y )
		{
			return contains( new PointCoord ( x, y ) );
		}
		public void move( double dx, double dy )
		{
			int n=countPoint();
			for( int i=0; i<n; i++ )
			{
				PointCoord p=(PointCoord)this.polygon[i];
				p.x += dx; p.y += dy;
			}
		}
	
		public void draw( Graphics g, int x0, int y0 )
		{
			using(Brush brush = new SolidBrush(color) )
			using (Pen pen = new Pen( color, 1))
			{
				if( type==TYPE_POLYGON)
				{
					//g.setColor( color );
					int n=countPoint();
					if( n==0 ) return;
					if( n== 1)
					{
						int x= getPoint(0).toScrPoint (x0,y0).X;
						int y= getPoint(0).toScrPoint (x0,y0).Y;
						g.DrawLine( pen, x-1,y-1,x+1,y+1);  //??? draw a cross, more easy to see
						g.DrawLine( pen, x-1,y+1,x+1,y-1);
						return;
					}
					if( n==2)
					{
						int x1= getPoint(0).toScrPoint (x0,y0).X;
						int y1= getPoint(0).toScrPoint (x0,y0).Y;
						int x2= getPoint(1).toScrPoint (x0,y0).X;
						int y2= getPoint(1).toScrPoint (x0,y0).Y;
						g.DrawLine( pen, x1,y1,x2,y2);  //??? whether needed for drawing a circle
						return;
					}
					if( n>2 )
					{
						Polygon poly= toScrPolygon(x0,y0);
						int[] x= poly.xpoints ;
						int[] y= poly.ypoints ;
						System.Drawing.Point[] points = poly.toPoints();
						if( filled ) g.FillPolygon (brush, points);
						else g.DrawPolygon(pen, points);
					}
				}
			}
			return;		
		
		}
	
	
	}
}
