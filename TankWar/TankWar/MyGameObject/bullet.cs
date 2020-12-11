using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankWar
{
    class bullet : VisibleGameEntity
    {
        protected Rectangle position;
        //public MySprite2D skin;
        public Rectangle Position { set { position = value; } get { return position; } }
        Force force=new Force(2,Vector2.Zero,1);
        public enum loaidan{player,enermy}
        public loaidan Type;
        int first = 0;
        int last = 3;
        //public Color[] datacolor;
        public bool isrun = true;
        public int First { set { first = value; } get { return first; } }
        public int Last { set { last = value; } get { return last; } }
        public bullet(Rectangle position,loaidan Type,Force force)
        {
          
            this.position = position;
            this.Type = Type;
            Rectangle[] frame = new Rectangle[4];
            frame[0] = new Rectangle(0, 1, 10, 10);
            frame[1] = new Rectangle(12, 0, 11, 10);
            frame[2] = new Rectangle(26, 0, 10, 10);
            frame[3] = new Rectangle(38, 0, 11, 10);
            
            TextureMultiFrame framelist = new TextureMultiFrame(GLOBAL.BulletTexture, frame);
            this.Model = new MySprite2D(framelist, 400);
            //datacolor = new Color[(Global.BulletTexture.Height) * (Global.BulletTexture.Width)];
            //Global.BulletTexture.GetData<Color>(datacolor);
            this.force = force;
            
        }
        public override void  Draw(int firstframe, int lastframe, object obj, Vector2 position, Color color, float rotation, Vector2 origin, float scale, float layerDepth)
        {
 	         this.GameDraw((SpriteBatch)obj, color, layerDepth);
        }
        public void GameDraw(SpriteBatch spritebacth, Color color, float layerDepth)
        {
            if (isrun == true)
            {
                this.Model.Draw(1,4,spritebacth,new Vector2(position.X,position.Y),Color.White,0f,Vector2.Zero,1.5f,0f);
                
            }
           
        }
          public virtual void update(GameTime gameTime)
          {
              this.Model.Update(gameTime);
              if (isrun == true)
              {

                  force.CurrentSpeed = force.Direction * force.Speed;
                  position.X += (int)force.CurrentSpeed.X;
                  position.Y += (int)force.CurrentSpeed.Y;
              }
              else
                  GLOBAL.Bullet.Remove(this);
         }
    }
}
