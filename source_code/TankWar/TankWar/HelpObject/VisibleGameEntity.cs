using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TankVN
{
    class VisibleGameEntity
    {

        protected MyAbstractModel _Model;

        public MyAbstractModel Model
        {
            get { return _Model; }
            set { _Model = value; }
        }
        public virtual void Update(GameTime gametime)
        {
            _Model.Update(gametime);
        }

        public virtual void Draw(int firstframe, int lastframe, object obj, Vector2 position, Color color, float rotation, Vector2 origin, float scale, float layerDepth)
        {
            _Model.Draw(firstframe, lastframe, obj, position, color, rotation, origin, scale, layerDepth);
        }
    }
}
