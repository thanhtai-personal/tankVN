using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankWar
{
    class MySprite2D : MyAbstractModel 
    {
        //private TextureMultiFrame _MultiFramelist;

        //public TextureMultiFrame MultiFramelist
        //{
        //    get { return _MultiFramelist; }
        //    set { _MultiFramelist = value; }
        //}
        
        public MySprite2D(TextureMultiFrame framelist, int milisecondperframe)
        {
            this.MultiFramelist = framelist;
            this.milisecondperframe = milisecondperframe;
            firstframe = 0;
            lastframe = 0;
            numloop = 0;
        }
        public override void Update(GameTime gametime)
        {
            
                counter += gametime.ElapsedGameTime.Milliseconds;
                if (counter < milisecondperframe) return;
                counter -= milisecondperframe;
                numloop += 1;
                index += 1;
         
         
          
        }
        public override void Draw(int firstframe, int lastframe, object spriteBatch, Vector2 position, Color color, float rotation, Vector2 origin, float scale, float layerDepth)
        {
            this.GameDraw(firstframe, lastframe, (SpriteBatch)spriteBatch, position, color, rotation, origin, scale, layerDepth);
        }
        private void GameDraw(int firstframe, int lastframe, SpriteBatch spriteBatch, Vector2 position, Color color, float rotation, Vector2 origin, float scale, float layerDepth)
        {
            if (isrun == true)
            {
                if (index < firstframe) index = firstframe;
                if (index >= firstframe && index < lastframe)
              
                    this.MultiFramelist.Draw(index, spriteBatch, position, color, rotation, origin, scale, layerDepth);
                    

                if (index >= lastframe)
                {
                    index = firstframe;
                    
                    this.MultiFramelist.Draw(lastframe, spriteBatch, position, color, rotation, origin, scale, layerDepth);
                }
            }
            else
            {
                this.MultiFramelist.Draw(lastframe-2, spriteBatch, position, color, rotation, origin, scale, layerDepth);
            }
	             
        }
    }
}
