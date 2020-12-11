using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TankVN
{
    enum ItemType
    {
        KillAll,
        FreezeTime,
        Shield,
        Heart,
        Speed,
        Update,
        House,
        Teleport
    }
    enum ItemEfState
    {
        KillAllEffect,  
        FreezeTime,
        Shield,
        Heart,
        Speed,
        Update,
        House,
        Teleport,
        none
    }
    class Item : VisibleGameEntity
    {
        public ItemType type { get; set; }
        ItemEfState EfState=ItemEfState.none;
        public bool visible = true;
        double TimeDisappearItem=0;
        double TimeUnFreeze = 0;
        double TimeDisapperShield = 0;
        double TimeDisappearHouseProtect = 0;
        public Vector2 position;
        MySprite2D Effect=new MySprite2D(new TextureMultiFrame(GLOBAL.ItemEf,64,64),100);
        MySprite2D KillAllEffect = new MySprite2D(new TextureMultiFrame(GLOBAL.KillAllEfTt, 192, 192), 100);
        MySprite2D FreezeGlobalEffect = new MySprite2D(new TextureMultiFrame(GLOBAL.FreezeEffectGamezoneTt, 192, 192), 100);
        MySprite2D ShieldEffect = new MySprite2D(new TextureMultiFrame(GLOBAL.ShieldItemEfTt, 192, 192), 100);
        MySprite2D HeartEffect = new MySprite2D(new TextureMultiFrame(GLOBAL.HeartItemEfTt, 192, 192), 70);
        MySprite2D UpdateEffect = new MySprite2D(new TextureMultiFrame(GLOBAL.KillAllEfTt, 192, 192), 70);
        MySprite2D SpeedEffect = new MySprite2D(new TextureMultiFrame(GLOBAL.SpeedItemEfTt, 192, 192), 100);
        MySprite2D HouseEffect = new MySprite2D(new TextureMultiFrame(GLOBAL.HouseItemEfTt, 192, 192), 100);
        MySprite2D TeleportEffect = new MySprite2D(new TextureMultiFrame(GLOBAL.TeleportItemEfTt, 192, 192), 100);
        List<MySprite2D> FreezeLocalEffect = new List<MySprite2D>();
        public Color[] datacolor;
        public Item()
        {
            KillAllEffect.Position = new Vector2(GamePlay.gameZone.Width / 2 - GLOBAL.KillAllEfTt.Width  / 2, GamePlay.gameZone.Height / 2 - GLOBAL.KillAllEfTt.Height / 2-100);
            FreezeGlobalEffect.Position = new Vector2(GamePlay.gameZone.Width / 2 - GLOBAL.FreezeEffectGamezoneTt.Width / 2, GamePlay.gameZone.Height / 2 - GLOBAL.FreezeEffectGamezoneTt.Height / 2+20);
            
            this.Model = new MySprite2D(new TextureMultiFrame(GLOBAL.KillAllItemTt, GLOBAL.KillAllItemTt.Width, GLOBAL.KillAllItemTt.Height),10000);
            this.visible = false; ;            
        }
        bool flag = false;
        public override void Update(GameTime gametime)
        {
           
            if (visible == true)
            {
                TimeDisappearItem += gametime.ElapsedGameTime.TotalSeconds;
            }
            if (EfState == ItemEfState.FreezeTime)
            {
                TimeUnFreeze += gametime.ElapsedGameTime.TotalSeconds;
            }
            if (EfState == ItemEfState.House)
            {
                TimeDisappearHouseProtect += gametime.ElapsedGameTime.TotalSeconds;
            }
            if (EfState == ItemEfState.Shield)
            {
                TimeDisapperShield += gametime.ElapsedGameTime.TotalSeconds;
                ShieldEffect.Update(gametime);
                ShieldEffect.Position = new Vector2(GLOBAL.xe.Position.X-26,(int)GLOBAL.xe.Position.Y-26);
            }
            if (TimeUnFreeze >= 15)
            {
                EfState = ItemEfState.none;
                TimeUnFreeze = 0;                
                FreezeLocalEffect.RemoveAll(Item => Item!=null);
            }
            if (TimeDisappearHouseProtect >= 15)
            {
                EfState = ItemEfState.none;
                TimeDisappearHouseProtect = 0;
                for (int i = 1;i<=20 ; i++)
                    GamePlay.LstCell.Remove(GamePlay.LstCell[GamePlay.LstCell.Count-1]);
               
  
            }
            if (TimeDisapperShield >= 15)
            {
                TimeDisapperShield = 0;
                EfState = ItemEfState.none;
                ShieldEffect.isrun = false;
                GLOBAL.xe.NotDead = false;
            }
            if (TimeDisappearItem > 30)
            {
                TimeDisappearItem = 0;
                this.visible = false;
            }
            switch (type)
            {
                
                case ItemType.KillAll:
                   this.Model = new MySprite2D(new TextureMultiFrame(GLOBAL.KillAllItemTt, GLOBAL.KillAllItemTt.Width, GLOBAL.KillAllItemTt.Height),10000);
                   datacolor = new Color[GLOBAL.KillAllItemTt.Width * GLOBAL.KillAllItemTt.Height];
                   GLOBAL.KillAllItemTt.GetData(datacolor);
                    break;
                case ItemType.FreezeTime:
                    this.Model = new MySprite2D(new TextureMultiFrame(GLOBAL.FreezeTimeItemTt, GLOBAL.FreezeTimeItemTt.Width, GLOBAL.FreezeTimeItemTt.Height), 10000);
                    datacolor = new Color[GLOBAL.FreezeTimeItemTt.Width * GLOBAL.FreezeTimeItemTt.Height];
                    GLOBAL.FreezeTimeItemTt.GetData(datacolor);
                    break;
                case ItemType.Shield:
                    this.Model = new MySprite2D(new TextureMultiFrame(GLOBAL.ShieldItemTt, GLOBAL.ShieldItemTt.Width, GLOBAL.ShieldItemTt.Height), 10000);
                    datacolor = new Color[GLOBAL.ShieldItemTt.Width * GLOBAL.ShieldItemTt.Height];
                    GLOBAL.ShieldItemTt.GetData(datacolor);
                    ShieldEffect.isrun = true;
                    break;
                case ItemType.Heart:
                    this.Model = new MySprite2D(new TextureMultiFrame(GLOBAL.HeartItemTt, GLOBAL.HeartItemTt.Width, GLOBAL.HeartItemTt.Height), 10000);
                    datacolor = new Color[GLOBAL.HeartItemTt.Width * GLOBAL.HeartItemTt.Height];
                    GLOBAL.HeartItemTt.GetData(datacolor);
                    //HeartEffect.isrun = true;
                    break;
                case ItemType.Speed:
                    this.Model = new MySprite2D(new TextureMultiFrame(GLOBAL.SpeedItemTt, GLOBAL.SpeedItemTt.Width, GLOBAL.SpeedItemTt.Height), 10000);
                    datacolor = new Color[GLOBAL.SpeedItemTt.Width * GLOBAL.SpeedItemTt.Height];
                    GLOBAL.SpeedItemTt.GetData(datacolor);
                    //SpeedEffect.isrun = true;
                    break;
                case ItemType.Update:
                    this.Model = new MySprite2D(new TextureMultiFrame(GLOBAL.UpdateItemTt, GLOBAL.UpdateItemTt.Width, GLOBAL.UpdateItemTt.Height), 10000);
                    datacolor = new Color[GLOBAL.UpdateItemTt.Width * GLOBAL.UpdateItemTt.Height];
                    GLOBAL.UpdateItemTt.GetData(datacolor);
                    //SpeedEffect.isrun = true;
                    break;
                case ItemType.House:
                    this.Model = new MySprite2D(new TextureMultiFrame(GLOBAL.HouseItemTt, GLOBAL.HouseItemTt.Width, GLOBAL.HouseItemTt.Height), 10000);
                    datacolor = new Color[GLOBAL.HouseItemTt.Width * GLOBAL.HouseItemTt.Height];
                    GLOBAL.HouseItemTt.GetData(datacolor);
                    //SpeedEffect.isrun = true;
                    break;
                case ItemType.Teleport:
                    this.Model = new MySprite2D(new TextureMultiFrame(GLOBAL.TeleportItemTt, GLOBAL.TeleportItemTt.Width, GLOBAL.TeleportItemTt.Height), 10000);
                    datacolor = new Color[GLOBAL.TeleportItemTt.Width * GLOBAL.TeleportItemTt.Height];
                    GLOBAL.TeleportItemTt.GetData(datacolor);
                    //SpeedEffect.isrun = true;
                    break;

               
            }

            this.Model.Position = this.position;

            if (GLOBAL.vachampixel(new Rectangle((int)position.X, (int)position.Y, 32, 32), this.datacolor, GLOBAL.xe.bound, GLOBAL.xe.Model.MultiFramelist.datacolor))
            {
                this.visible = false;
                TimeDisappearItem = 0;
                switch (this.type)
                {
                    case ItemType.KillAll:
                        EfState = ItemEfState.KillAllEffect;  
                        for (int i = 0; i < GLOBAL.enermy.Count; i++)
                        {
                            GLOBAL.enermy[i].livepoint = 0;
                        }
                        GLOBAL.KillAllItemSound.Play();
                        break;

                    case ItemType.FreezeTime:
                        EfState = ItemEfState.FreezeTime;
                        GLOBAL.FreezeItemSound.Play();
                        break;
                    case ItemType.Shield:
                        EfState = ItemEfState.Shield;
                        GLOBAL.xe.NotDead = true;
                        GLOBAL.ShieldItemSound.Play();
                        break;
                    case ItemType.Heart:
                        EfState = ItemEfState.Heart;
                        GLOBAL.xe.livepoint +=1;
                        GLOBAL.HeartItemSound.Play();
                        break;
                    case ItemType.Speed:
                        EfState = ItemEfState.Speed;
                        if(GLOBAL.xe.Force.Speed<3)
                            GLOBAL.xe.Force.Speed += 1;
                        GLOBAL.SpeedItemSound.Play();
                        break;
                    case ItemType.Update:
                        EfState = ItemEfState.Update;
                        if (GLOBAL.xe.SpeedBullet == 4) GLOBAL.xe.SpeedBullet = 6;
                        else if (GLOBAL.xe.MaxBullet == 1) GLOBAL.xe.MaxBullet = 2;
                        GLOBAL.UpdateItemSound.Play();
                        break;
                    case ItemType.House:
                        EfState = ItemEfState.House;
                        for (int i = 23; i <= 26; i++)
                            for (int j = 11; j <= 16; j++)
                            {
                                if (((i >= 25) && (i <= 26)) && ((j >= 13) && (j <= 14))) continue;
                                else
                                GamePlay.LstCell.Add(new cell(new Vector2(26 * (j - 1), 26 * (i - 1)), CellType.BeTong));
                            }
                        GLOBAL.HouseItemSound.Play();
                     break;
                    case ItemType.Teleport:
                        EfState = ItemEfState.Teleport;
                        while (true)
                        {
                            Random randompos = new Random();
                            int X = randompos.Next(1, 26) * 26;
                            int Y = randompos.Next(1, 26) * 26;
                            bool flagtemp = true;
                            for (int i = 0; i < GamePlay.LstCell.Count; i++)
                                if ((GamePlay.LstCell[i].Model.Position.X == X) && (GamePlay.LstCell[i].Model.Position.Y == Y))
                                {
                                    flagtemp = false;
                                    break;
                                }
                            if (flagtemp == true)
                            {
                                GLOBAL.xe.bound = new Rectangle(X, Y, GLOBAL.xe.bound.Width, GLOBAL.xe.bound.Height);
                                break;
                            }
                            
                        }
                        GLOBAL.TeleportItemSound.Play();
                     break;
                }
            }

            if (EfState == ItemEfState.none)
            {
                for (int i = 0; i < GLOBAL.enermy.Count; i++)
                {
                    GLOBAL.enermy[i].Moving = true;
                }
                FreezeGlobalEffect.index = 0;
                HeartEffect.index = 0;
                SpeedEffect.index = 0;
                HouseEffect.index = 0;
                UpdateEffect.index = 0;
                TeleportEffect.index = 0;
                GLOBAL.xe.NotDead = false;
            }
            if (EfState == ItemEfState.Heart)
            {
                HeartEffect.Position = new Vector2(GLOBAL.xe.Position.X - 170/2, GLOBAL.xe.Position.Y - 170/2);
            }
            if (EfState == ItemEfState.Speed)
            {
                SpeedEffect.Position = new Vector2(GLOBAL.xe.Position.X - 170 / 2, GLOBAL.xe.Position.Y - 170 / 2);
            }
            if (EfState == ItemEfState.Teleport)
            {
                TeleportEffect.Position = new Vector2(GLOBAL.xe.Position.X - 170 / 2, GLOBAL.xe.Position.Y - 170 / 2);
            }
            if (EfState == ItemEfState.Update)
            {
                UpdateEffect.Position = new Vector2(GLOBAL.xe.Position.X - 170 / 2, GLOBAL.xe.Position.Y - 170 / 2);
            }
            if (EfState == ItemEfState.House)
            {
                HouseEffect.Position = new Vector2(243,26*20);
            }
            if (EfState == ItemEfState.FreezeTime)
            {
                for (int i = 0; i < FreezeLocalEffect.Count; i++)
                {
                    int temp = 0;
                    for (int j = 0; j < GLOBAL.enermy.Count; j++)
                    {
                        if ((FreezeLocalEffect[i].Position.X != GLOBAL.enermy[j].Position.X - 26) || (FreezeLocalEffect[i].Position.Y != GLOBAL.enermy[j].Position.Y - 26))
                            temp += 1;
                    }
                    if (temp == GLOBAL.enermy.Count) FreezeLocalEffect.Remove(FreezeLocalEffect[i]);
                }
                for (int i = 0; i < GLOBAL.enermy.Count; i++)
                {
                    GLOBAL.enermy[i].Moving = false;
                  
                    flag = true;
                    
                    for (int j = 0; j < FreezeLocalEffect.Count; j++)
                    {
                        if ((FreezeLocalEffect[j].Position.X == GLOBAL.enermy[i].Position.X - 26) && (FreezeLocalEffect[j].Position.Y == GLOBAL.enermy[i].Position.Y - 26))
                        {
                            flag = false;
                        }                      
                    }
                    
                    if (flag == true)
                    {
                        FreezeLocalEffect.Add(new MySprite2D(new TextureMultiFrame(GLOBAL.FreezeEffectGamezoneTt, 192, 192), 100));
                        FreezeLocalEffect[i].Position = new Vector2(GLOBAL.enermy[i].Position.X - 26, GLOBAL.enermy[i].Position.Y - 26);

                    }
                   


                }
                
                for (int i = 0; i < FreezeLocalEffect.Count; i++)
                {
                    FreezeLocalEffect[i].Update(gametime);
                    //GLOBAL.enermy[i].Moving = false;
                }
            }
            if (this.visible == false) this.position = new Vector2(-100, -100);
            this.Model.Update(gametime);
            Effect.Update(gametime);
            if (KillAllEffect.index <=20)
                KillAllEffect.Update(gametime);            
            FreezeGlobalEffect.Update(gametime);
            HeartEffect.Update(gametime);
            SpeedEffect.Update(gametime);
            UpdateEffect.Update(gametime);
            HouseEffect.Update(gametime);
            TeleportEffect.Update(gametime);
            
            
        }
        public override void Draw(int firstframe, int lastframe, object obj, Vector2 position, Color color, float rotation, Vector2 origin, float scale, float layerDepth)
        {
            if (this.visible == true && this.Model != null)
            {
                this.Model.Draw(this.Model.FristFrame, this.Model.LastFrame, obj, new Vector2(this.Model.Position.X, this.Model.Position.Y), Color.White, 0, Vector2.Zero, 1.3f, 0f);
                Effect.Draw(1, 20, obj, new Vector2(this.Model.Position.X-12, this.Model.Position.Y-5), Color.White, 0, Vector2.Zero, 1f, 0f);

                       
            }
             switch (EfState)
            {
             case ItemEfState.KillAllEffect:
                KillAllEffect.Draw(1, 20, obj, KillAllEffect.Position, Color.White, 0f, Vector2.Zero, 5f, 0f);
                if (KillAllEffect.index >= 19)
                    EfState = ItemEfState.none;
                break;
             case ItemEfState.FreezeTime:
                if (FreezeGlobalEffect.index <= 19)
                    FreezeGlobalEffect.Draw(1, 20, obj, FreezeGlobalEffect.Position, Color.White, 0f, Vector2.Zero, 5f, 0f);
              
                    //EfState = ItemEfState.none;
                for (int i = 0; i < FreezeLocalEffect.Count;i++ )
                    FreezeLocalEffect[i].Draw(1, 20, obj, FreezeLocalEffect[i].Position, Color.White, 0f, Vector2.Zero, 0.4f, 0f);
                break;
             case ItemEfState.Shield:
                ShieldEffect.Draw(1, 20, obj, ShieldEffect.Position, Color.White, 0f, Vector2.Zero, 0.4f, 0f);                
                break;
             case ItemEfState.Heart:
                if (HeartEffect.index <= 19)
                    HeartEffect.Draw(1, 20, obj, HeartEffect.Position, Color.White, 0f, Vector2.Zero, 1f, 0f);
                else
                    EfState = ItemEfState.none;

                break;
             case ItemEfState.Speed:
                if (SpeedEffect.index <= 19)
                    SpeedEffect.Draw(1, 20, obj, SpeedEffect.Position, Color.White, 0f, Vector2.Zero, 1f, 0f);
                else
                    EfState = ItemEfState.none;

                break;
             case ItemEfState.Update:
                if (UpdateEffect.index <= 19)
                    UpdateEffect.Draw(1, 20, obj, UpdateEffect.Position, Color.White, 0f, Vector2.Zero, 1f, 0f);
                else
                    EfState = ItemEfState.none;

                break;
             case ItemEfState.House:
                if (HouseEffect.index <= 19)
                    HouseEffect.Draw(1, 20, obj, HouseEffect.Position, Color.White, 0f, Vector2.Zero, 1f, 0f);
                

                break;
             case ItemEfState.Teleport:
                if (TeleportEffect.index <= 19)
                    TeleportEffect.Draw(1, 20, obj, TeleportEffect.Position, Color.White, 0f, Vector2.Zero, 1f, 0f);
                else
                    EfState = ItemEfState.none;

                break;
            }
               

        }
    }
}
