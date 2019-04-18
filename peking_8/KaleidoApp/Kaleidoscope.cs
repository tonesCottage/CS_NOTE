using System;
using System.Collections;
using System.Drawing;

namespace KaleidoApp
{
	/// <summary>
	/// Kaleidoscope 的摘要说明。
	/// </summary>
	public class Kaleidoscope
	{
		public ArrayList mirrors=new ArrayList();
		public ArrayList picObjects=new ArrayList ();
		public ArrayList picInMirrorSerial=new ArrayList ();
	
		public void clear()
		{
			//mirrors.removeAllElements ();
			picObjects.Clear ();
			picInMirrorSerial.Clear ();
		}
	
		public void addMirror( Mirror m )
		{
			mirrors.Add (m);
		}
	
		public void addPicObject( PicObject po )
		{
			picObjects.Add ( po );
		}
	
		public ArrayList getPicInMirrors( int step )
		{
			if( step<=0 ) return null;
			//int n=picInMirrorSerial.Count;
			//if( step<=n ) return (ArrayList)picInMirrorSerial[ step];  //????
			picInMirrorSerial.Clear ();
			if( picObjects==null ) return null;
			picInMirrorSerial.Add ( picObjects );  //picObjects as the first serial
			ArrayList lastStep=picObjects;
			for( int i=1; i<=step; i++ )
			{
				ArrayList thisStep=new ArrayList();
				for( int j=0; j<lastStep.Count; j++ )
				{
					PicObject pic=(PicObject)lastStep[j];
					for( int k=0; k<mirrors.Count; k++ )
					{
						Mirror mir=(Mirror)(mirrors[k]);
						if( pic.mirror!=mir)
						{
							thisStep.Add ( mir.picObjectMirrorSymmetry (pic) );
						}
					}
				}
				picInMirrorSerial.Add (thisStep);
				lastStep=thisStep;
			}
			return lastStep;
		}
	
		public void drawPicInMirrors(  Graphics g, int x0, int y0 )
		{
			int step=picInMirrorSerial.Count;    
			for( int i=step-1; i>=0; i-- )
			{     //including original object, i--, more later, more draw first
				ArrayList se =(ArrayList)picInMirrorSerial[i];
				for( int j=0; j<se.Count; j++ )
				{
					PicObject pic=(PicObject)se[j];
					pic.draw( g, x0, y0 );
				}
			}
		}
	
		public void drawMirrors (  Graphics g, Color color,int x0, int y0 )
		{
			for( int i=0; i<mirrors.Count; i++ )
			{
				Mirror mir = (Mirror) mirrors[ i ];
				mir.draw( g, color, x0, y0 );
			}
		}	
	}
}
