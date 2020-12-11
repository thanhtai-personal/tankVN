using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankWar
{
    public class TextureMultiFrame
    {
        public Texture2D texture;
        private int width;
        private int height;
        private int xwidth;
        public Color[] datacolor;
        public Rectangle currentrectangle;
        private int yheight;
        public Rectangle[] framelist;
        public int Width { set { width = value; } get { return width; } }
        public int Height { set { height = value; } get { return height; } }
        public int length { get { return framelist.Length; } }
        public int Xwidth { get { return xwidth; } }
        public int Yheight { get { return yheight; } }
        public TextureMultiFrame(Texture2D texture, int widthframe, int heightfarme)
        {
            this.texture = texture;
            this.width = widthframe;
            this.height = heightfarme;
            xwidth = (int)Math.Round((decimal)texture.Width / widthframe, 0);
            yheight = (int)Math.Round((decimal)texture.Height / heightfarme, 0);
            this.framelist = new Rectangle[xwidth * yheight];
            int index = 0;
            for (int i = 0; i < yheight; i++)
                for (int j = 0; j < xwidth; j++)
                {
                    framelist[index++] = new Rectangle(widthframe * j, heightfarme * i, widthframe, heightfarme);
                }



        }
        public TextureMultiFrame(Texture2D texture, Rectangle[] FrameList)
        {
            this.texture = texture;
            framelist = new Rectangle[FrameList.Length];
            framelist = FrameList;
        }
        public void Draw(int index, SpriteBatch spriteBatch, Vector2 position, Color color, float rotation, Vector2 origin, float scale, float layerDepth)
        {
            datacolor = new Color[framelist[index % framelist.Length].Width * framelist[index % framelist.Length].Height];

            currentrectangle = this.framelist[index % framelist.Length];
            texture.GetData<Color>(0, currentrectangle, datacolor, 0, currentrectangle.Width * currentrectangle.Height);

            spriteBatch.Draw(texture, position, this.framelist[index % framelist.Length], color, rotation, origin, scale, SpriteEffects.None, layerDepth);

        }
    }
}
