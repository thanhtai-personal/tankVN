using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TankWar
{
    public abstract class MyAbstractModel
    {
        private TextureMultiFrame framelist;

        public TextureMultiFrame MultiFramelist
        {
            get { return framelist; }
            set { framelist = value; }
        }
        public int Height { get { return this.MultiFramelist.Height; } }
        public int Width { get { return this.MultiFramelist.Width; } }

        protected bool _MouseHere = false;
        protected int counter = 0;
        protected int milisecondperframe;
        public int index;
        public int numloop;
        protected int firstframe = 0;
        protected int lastframe = 0;
        public bool isrun = true;

        public int Index { get { return index; } set { index = value; } }
        public int FristFrame { set { firstframe = value; } get { return firstframe; } }
        public int LastFrame { set { lastframe = value; } get { return lastframe; } }
        Vector2 _Position;

        public Vector2 Position
        {
            get { return _Position; }
            set { _Position = value; }
        }
        public bool MouseHere
        {
            get { return _MouseHere; }
            set { _MouseHere = value; }
        }

        public virtual void Update(GameTime gametime)
        { }

        public virtual void Draw(int firstframe, int lastframe, object spriteBatch, Vector2 position,
            Color color, float rotation, Vector2 origin, float scale, float layerDepth)
        { }

        
    }
}
