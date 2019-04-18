using System;
using System.Drawing;

namespace KaleidoApp
{

	public class Mirror
	{
		public double k,b;  
		public double a;
		public bool vertical=false;
	
		public double refl=1.0;   //reflection ratio
	
		public Mirror( double k, double b ) //a Mirror is a line:  y = kx +b
		{
			this.k=k; this.b=b;
			vertical=false;
		}
		public Mirror( double a )     // a Mirror is a vertical line :  x=a;
		{
			this.k=Double.MaxValue ; this.a = a;
			vertical=true;
		}
		public bool isVertical( )
		{
			return vertical;
		}
		public static Mirror VerticalMirror(double b)
		{
			return new Mirror(b);
		}
		public static Mirror fromTwoPoint( double x1, double y1, double x2, double y2 )
		{
			if( x1==x2 || Math.Abs(x1-x2)<1e-5) return VerticalMirror(x1);
			double k = (y1-y2)/(x1-x2);
			double b = y1 - k*x1;
			return new Mirror(k,b);
		}
	
		public void setReflection( double refl )
		{
			this.refl=refl;
		}
		public double getReflection( )
		{
			return this.refl;
	
		}
		public PointCoord pointMirrorSymmetry( PointCoord p )
		{
			if( this.isVertical() )
			{
				return new PointCoord( 2*a-p.x, p.y );
			}
			else
			{
				double x2=(2*(p.y-b)+(1/k-k)*p.x)/(k+1/k);
				double y2=p.y+(p.x-x2)/k;
				return new PointCoord ( x2, y2 );
			}
		}
		
		public static Color colorMirrorRef( Color c, double refl )
		{
			return c;
			/*
			double r,g,b,k;
			r=c.getRed (); g=c.getGreen (); b=c.getBlue ();
			k=1.0/(r+g+b);
			k/=ref;       // more brighter when ref<1  ?????
			return new Color((float)( r*k), (float)(g*k), (float)(b*k) );
			*/
		}
					 
	
		public PicObject picObjectMirrorSymmetry( PicObject pic )
		{
			if( pic.mirror == this ) return null; // a Pic In this mirror can not through the mirror itself
			Color color = colorMirrorRef( pic.color, refl );
			PicObject pic2 = new PicObject( pic.type, color, pic.filled );
			int n=pic.countPoint ();
			for( int i=0; i<n; i++ )
			{
				PointCoord p=pic.getPoint (i);
				pic2.addPoint ( pointMirrorSymmetry(p) );
			}
			pic2.mirror=this;
			pic2.originalPicObject=pic.originalPicObject;
			pic2.srcPicObject=pic;
			return pic2;
		}
	
		public void draw( Graphics g, Color color, int x0, int y0 )
		{
			int Max_Value=500;   //????
			using( Pen pen = new Pen(color,1) )
			{
				if( isVertical() )
				{
					g.DrawLine( pen, (int)(x0+a), (int)(y0-Max_Value), (int)(x0+a), (int)(y0+Max_Value));
					return;
				}

				if( k>Max_Value || k<-Max_Value)
				{
					int bb=0;  //????
					g.DrawLine( pen, x0+bb, y0-Max_Value, x0+bb, y0+Max_Value);
					return;
				}
				g.DrawLine( pen, (int)(x0-Max_Value), (int)(y0-k*Max_Value+b),
						(int)(x0+Max_Value), (int)(y0+k*Max_Value+b) );
				return;
//				if( k>0 )   //??? how about k==0?
//					g.DrawLine( pen, x0+0, (int)(y0-(k*0+b)),
//						x0+Max_Value, (int)(y0-(k*Max_Value+b)));
//				else 
//					g.DrawLine( pen, x0+0, (int)( y0-(k*0+b)),
//						x0-Max_Value, (int)(y0-(-k*Max_Value+b)));
//				return;
			}
		}
		
	}
}
