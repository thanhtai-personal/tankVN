using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankVN
{
    class tank : VisibleGameEntity
    {
        
        public int livepoint;
        protected Force force;
        public Rectangle bound;
        protected Vector2 origin = Vector2.Zero;
        protected float rotation = 0f;
        protected float scale = 1f;
        protected bool enabled = true;
        public bool visible = true;
        protected bool moving = true;
        public Rectangle lastbound;

        MySprite2D TankAppearEffect;
        
        public bool Moving { set { this.moving = value; } get { return moving; } }
        public Rectangle Bound { get { return bound; } }
        public Vector2 Position { set { Position = value; } get { return new Vector2(bound.X, bound.Y); } }
        //public MySprite2D Skin { set { this.skin = value; } get { return skin; } }
        public Force Force { set { this.force = value; } get { return force; } }
        public tank(Force force, Rectangle bound)
        {
            
            this.force = force;
            this.bound = bound;
          
    
           // GLOBAL.Bullet = new List<bullet>();

        }
        public virtual void update(GameTime gameTime)
        {
            this.Model.Update(gameTime);
            if (!enabled) return;
            if (visible)
            {

               
                if (moving)
                {
                    lastbound = bound;
                    force.CurrentSpeed = (force.Speed * force.Direction);
                    bound.X += (int)force.CurrentSpeed.X;
                    bound.Y += (int)force.CurrentSpeed.Y;
                    if ((bound.X < 0 || Bound.X + 26 > GamePlay.gameZone.Width))
                    {
                        bound.X -= (int)force.CurrentSpeed.X;
                        
                    }
                    if (Bound.Y < 0 || Bound.Y + 26 > GamePlay.gameZone.Height)
                    {
                        bound.Y -= (int)force.CurrentSpeed.Y;
                    }
                }


            } 


        }
        public override void Draw(int firstframe, int lastframe, object obj, Vector2 position, Color color, float rotation, Vector2 origin, float scale, float layerDepth)
        {
            this.GameDraw((SpriteBatch)obj, color, layerDepth);
        }
        private void GameDraw(SpriteBatch spritebacth, Color color, float layerDepth)
        {
            if (!visible) return;
            if ((Math.Abs(force.CurrentSpeed.X) - 0.1 > 0) || (Math.Abs(force.CurrentSpeed.Y) - 0.1 > 0))
                this.Model.Draw(this.Model.FristFrame, this.Model.LastFrame, spritebacth, new Vector2(bound.X, bound.Y), Color.White, 0, Vector2.Zero, 1, 0f);
            else this.Model.Draw(this.Model.FristFrame, this.Model.FristFrame, spritebacth, new Vector2(bound.X, bound.Y), Color.White, 0, Vector2.Zero, 1, 0f);
            
        }
    }
}
