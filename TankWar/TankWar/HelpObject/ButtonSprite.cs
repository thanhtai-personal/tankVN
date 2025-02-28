﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TankWar
{
    class ButtonSprite:MyAbstractModel
    {
        Texture2D texture, texture1, texture2;

        public Texture2D Texture2
        {
            get { return texture2; }
            set { texture2 = value; }
        }

        public Texture2D Texture1
        {
            get { return texture1; }
            set { texture1 = value; }
        }

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }
        float _Left, _Top;
        int _Width, _Height;

        float _Depth;

        public float Depth
        {
            get { return _Depth; }
            set { _Depth = value; }
        }



        public int Height
        {
            get { return _Height; }
            set { _Height = value; }
        }

        public int Width
        {
            get { return _Width; }
            set { _Width = value; }
        }
        public float Top
        {
            get { return _Top; }
            set { _Top = value; }
        }

        public float Left
        {
            get { return _Left; }
            set { _Left = value; }
        }
        public ButtonSprite(Texture2D unselect, Texture2D select, float left, float top)
        {

            this.texture1 = unselect;
            this.texture2 = select;
            this._Left = left;
            this._Top = top;
            this.Position = new Vector2(this.Left, this.Top);
            this.Width = unselect.Width;
            this.Height = unselect.Height;

        }
        public override void Update(Microsoft.Xna.Framework.GameTime gametime)
        {

            if (this.MouseHere == false)
            {
                this.texture = texture1;
            }
            else
            {
                this.texture = texture2;
            }
        }
        //public override void SetMouseHereTrue()
        //{
        //    this.MouseHere = true;
        //}
        //public override void SetMouseHereFalse()
        //{
        //    this.MouseHere = false;
        //}
        //public override bool IsSelected(Object obj)
        //{
        //    Vector2 pos = (Vector2)obj;
        //    if (pos.X >= this._Left && pos.X <= this._Left + this._Width &&
        //        pos.Y >= this._Top && pos.Y <= this._Top + this._Height)
        //        return true;
        //    return false;
        //}
        public override void  Draw(int firstframe, int lastframe, object spriteBatch, Vector2 position, Color color, float rotation, Vector2 origin, float scale, float layerDepth)
        {
 	         this.GameDraw(firstframe, lastframe, (SpriteBatch)spriteBatch, position, color, rotation, origin, scale, layerDepth);
        }
        private void GameDraw(int firstframe, int lastframe, SpriteBatch spriteBatch, Vector2 position, Color color, float rotation, Vector2 origin, float scale, float layerDepth)
        {
            //spritebatch.Draw(this.Texture, new Vector2(_Left, _Top), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, _Depth);
           if (this.texture!=null)
            spriteBatch.Draw(this.texture, new Vector2(this.Left, this.Top), Color.White);
        }
    }
}
