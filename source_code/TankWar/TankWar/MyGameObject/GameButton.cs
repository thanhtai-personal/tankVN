﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankVN
{
    class GameButton : VisibleGameEntity
    {
      
        public ButtonSprite temp;
        public GameButton(Texture2D unselect, Texture2D select, float left, float top)
        {            
             temp = new ButtonSprite(unselect, select, left, top);
             this.Model = temp;
           
        }
        public override void Update(GameTime gametime)
        {
            this.Model = temp;
            base.Update(gametime);
        }
    } 
}
