using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TankWar
{
    enum CellType
    {
        Gach,
        BeTong,
        protect,    
        cell
    }
    class cell : VisibleGameEntity
    {
        public CellType type { get; set; }
        public bool visible = true;
        //protected Rectangle position;
        //public Rectangle Position { set { position = value; } get { return position; } }
        //Texture2D texture;
     
        public Color[] datacolor;
        public cell(Vector2 position, CellType type)
        {
            this.type = type;
           
      
            switch (type)
            {
                case CellType.Gach:
                    TextureMultiFrame temp = new TextureMultiFrame(GLOBAL.Gachtexture, GLOBAL.Gachtexture.Width, GLOBAL.Gachtexture.Height);
                    this.Model = new MySprite2D(temp, 10000);
                    datacolor = new Color[GLOBAL.Gachtexture.Width * GLOBAL.Gachtexture.Height];
                    GLOBAL.Gachtexture.GetData(datacolor);
                    break;
                case CellType.BeTong:
                    TextureMultiFrame temp2 = new TextureMultiFrame(GLOBAL.walltexture, GLOBAL.walltexture.Width, GLOBAL.walltexture.Height);
                    this.Model = new MySprite2D(temp2, 10000);
                    datacolor = new Color[GLOBAL.walltexture.Width * GLOBAL.walltexture.Height];
                    GLOBAL.walltexture.GetData(datacolor);
                    break;
                
                case CellType.protect:
                    TextureMultiFrame temp5 = new TextureMultiFrame(GLOBAL.ProtectTexture, GLOBAL.ProtectTexture.Width, GLOBAL.ProtectTexture.Height);
                    this.Model = new MySprite2D(temp5, 10000);
                    datacolor = new Color[GLOBAL.ProtectTexture.Width * GLOBAL.ProtectTexture.Height];
                    GLOBAL.ProtectTexture.GetData(datacolor);
                    break;
                case CellType.cell:
                    TextureMultiFrame temp4 = new TextureMultiFrame(GLOBAL.buicaytexture, GLOBAL.buicaytexture.Width, GLOBAL.buicaytexture.Height);
                    this.Model = new MySprite2D(temp4, 10000);
                    break;
               
                default:
                    break;
            }
            this.Model.Position = position;
            
        }
        public override void Update(GameTime gametime)
        {
          
            if (type == CellType.BeTong || type == CellType.Gach || type == CellType.protect)
            {
                for (int i = 0; i < GLOBAL.Bullet.Count; i++)
                {               
                 

                    if (GLOBAL.vachampixel(new Rectangle((int)this.Model.Position.X, (int)this.Model.Position.Y, (int)this.Model.Width, this.Model.Height), datacolor, GLOBAL.Bullet[i].Position, GLOBAL.Bullet[i].Model.MultiFramelist.datacolor))
                    {
                        if (type == CellType.Gach)
                            this.visible = false;
                        if (type == CellType.protect)
                        {
                            this.visible = false;
                            GLOBAL.explosionGach[GLOBAL.explosionGach.Count - 1].Position = new Vector2(GLOBAL.Bullet[i].Position.X - 52, GLOBAL.Bullet[i].Position.Y - 52);
                            GLOBAL.GameOver = true;
                        }
                        //GLOBAL.Bullet[i].isrun = false;
                        
                        GLOBAL.explosionGach.Add(new MySprite2D(new TextureMultiFrame(GLOBAL.explosionGachTt, 64, 64), 20));
                        if (this.type==CellType.BeTong)
                            GLOBAL.explosionGach[GLOBAL.explosionGach.Count - 1].Position = new Vector2(GLOBAL.Bullet[i].Position.X-26,GLOBAL.Bullet[i].Position.Y-26);
                        else if (this.type == CellType.Gach) GLOBAL.explosionGach[GLOBAL.explosionGach.Count - 1].Position = new Vector2(this.Model.Position.X - 20, Model.Position.Y - 26);
                        GLOBAL.Bullet.Remove(GLOBAL.Bullet[i]);
                        break;
                    }

                }







                if (this.visible == false) this.Model.Position = new Vector2(-100, -100);
                
                
            }
            //else 
            this.Model.Update(gametime);
            //this.position.X -= (int)Level1.forcespeed.X;
           // this.position.Y -= (int)Level1.forcespeed.Y;
        }
        public override void Draw(int firstframe, int lastframe, object obj, Vector2 position, Color color, float rotation, Vector2 origin, float scale, float layerDepth)
        {
            if (this.visible == true && this.Model != null)
                this.Model.Draw(this.Model.FristFrame, this.Model.LastFrame, obj, new Vector2(this.Model.Position.X, this.Model.Position.Y), Color.White, 0, Vector2.Zero, 1, 0f);
            
        }
    }
}
