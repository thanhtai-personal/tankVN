﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankWar
{
    class enermy : tank
    {

        
        double TimeFire = 0;
        double LastTimeFire = 0;
        double TimeNormalChangeMove = 0;
        double TimeRandomTypeMoving=0;
        int IsStupid;
        public bool BiKet;
        Vector2 LastPosition;
        public List<Vector2> CellBiKet;
        List<Vector2> open;
        public List<Vector2> close;
        enum tankstate
        {
            up,
            down,
            left,
            right,
            stop
        }
        public enum typemoving
        {
            Ngang,
            Doc
        }
        public enum TankType
        {
            intelligent,
            normal,
            normal2livepoint,
            normalspeed
        }
        tankstate State;
        typemoving TypeMoving;
        TankType Type;
        TextureMultiFrame framelistEnermy;
        public enermy(TankType Type,Force force, Rectangle bound, int livepoint)
            :base(force,bound)
        {
            Rectangle[] ListRectangleEnermy = new Rectangle[4];
            this.Type = Type;

            ListRectangleEnermy[0] = new Rectangle(0, 0, 25, 25);
            ListRectangleEnermy[1] = new Rectangle(25, 0, 26, 26);
            ListRectangleEnermy[2] = new Rectangle(0, 26, 25, 27);
            ListRectangleEnermy[3] = new Rectangle(25, 26, 25, 26);


           
            if (this.Type == enermy.TankType.intelligent)
            {
                IsStupid = 0;
                framelistEnermy = new TextureMultiFrame(GLOBAL.tankEnermy1Tt, ListRectangleEnermy);
                this.Model = new MySprite2D(framelistEnermy, 100);
              

            }
            if (this.Type == enermy.TankType.normal)
            {
                IsStupid = 1;
                TextureMultiFrame framelistEnermy = new TextureMultiFrame(GLOBAL.tankEnermy2Tt, ListRectangleEnermy);
                this.Model = new MySprite2D(framelistEnermy, 100);

            }
            if (this.Type == enermy.TankType.normal2livepoint)
            {
                IsStupid = 2;
                TextureMultiFrame framelistEnermy = new TextureMultiFrame(GLOBAL.tankEnermy3Tt, ListRectangleEnermy);
                this.Model = new MySprite2D(framelistEnermy, 100);
                livepoint = 2;

            }
            if (this.Type == enermy.TankType.normalspeed)
            {
                IsStupid = 3;
                TextureMultiFrame framelistEnermy = new TextureMultiFrame(GLOBAL.tankEnermy4Tt, ListRectangleEnermy);
                this.Model = new MySprite2D(framelistEnermy, 100);
                Force.Speed = 2;

            }


            this.livepoint = livepoint;
            this.BiKet = false;                   
            open = new List<Vector2>();
            close = new List<Vector2>();
            CellBiKet = new List<Vector2>();
            
        }
        public void Down()
        {
            //if (!moving)
            //{
            //moving = true;
            LastPosition = this.Model.Position;
            force.Direction = new Vector2(0, 1);
            Model.FristFrame = 2;
            Model.LastFrame = 2;
            State = tankstate.down;


            //}            
        }
        public void Up()
        {
            // if (!moving)
            //{
            //  moving = true;
            LastPosition = this.Model.Position;
            force.Direction = new Vector2(0, -1);
            Model.FristFrame = 0;
            Model.LastFrame = 0;
            State = tankstate.up;

            // moving = false;
            //}
        }
        public void Right()
        {
            //if (!moving)
            // {
            // moving = true;
            LastPosition = this.Model.Position;
            force.Direction = new Vector2(1, 0);
            Model.FristFrame = 1;
            Model.LastFrame = 1;
            State = tankstate.right;

            // moving = false;
            //}
        }
        public void Left()
        {
            //if (!moving)
            //{
            // moving = true;
            LastPosition = this.Model.Position;
            force.Direction = new Vector2(-1, 0);
            Model.FristFrame = 3;
            Model.LastFrame = 3;
            State = tankstate.left;

            //  moving = false;
            // }
        }
        public void Fire()
        {
            
            Vector2 _Direction = new Vector2(0,0);
            int X = 0, Y = 0;
            if (Model.FristFrame == 0)
            {
                X = this.bound.X + 4;
                Y = this.bound.Y - 10;
                _Direction = new Vector2(0, -1);
            }
            else if (Model.FristFrame == 1)
            {
                X = this.bound.X + 13;
                Y = this.bound.Y + 5;
                _Direction = new Vector2(1, 0);
            }
            else if (Model.FristFrame == 2)
            {
                X = this.bound.X + 3;
                Y = this.bound.Y + 15;
                _Direction = new Vector2(0, 1);
            }
            else if (Model.FristFrame == 3)
            {
                X = this.bound.X - 8;
                Y = this.bound.Y + 5;
                _Direction = new Vector2(-1, 0);
            }


            if (TimeFire - LastTimeFire > 1)
            {

                GLOBAL.Bullet.Add(new bullet(new Rectangle(X, Y, 10, 10), bullet.loaidan.enermy, new Force(4, _Direction, 1)));
                LastTimeFire = TimeFire;
            }

        }
        float DanhGia1(Vector2 Position1, Vector2 Position2)
        {
            float X, Y;
            if (Position2.X >= Position1.X) X = Position2.X - Position1.X;
            else X = Position1.X - Position2.X;
            if (Position2.Y >= Position1.Y) Y = Position2.Y - Position1.Y;
            else Y = Position1.Y - Position2.Y;
            float temp = X + Y;

            return temp;
        }
        float DanhGia2(Vector2 Position1, Vector2 Position2)
        {
            return (float)Math.Sqrt((Position2.X - Position1.X) * (Position2.X - Position1.X) + ((Position2.Y - Position1.Y) * (Position2.Y - Position1.Y)));
        }
        void sapxep(List<Vector2> open, Vector2 Position2)
        {
            Vector2 temp;
            Position2.X = (int)Math.Round((decimal)Position2.X / 26) * 26;
            Position2.Y = (int)Math.Round((decimal)Position2.Y / 26) * 26;
            for (int i = 0; i < open.Count - 1; i++)
            {
                for (int j = i + 1; j < open.Count; j++)
                {
                    if (!BiKet)
                    {
                        if ((TypeMoving == typemoving.Ngang))
                        {

                            if (DanhGia1(open[i], Position2) >= DanhGia1(open[j], Position2))
                            {
                                temp = open[i];
                                open[i] = open[j];
                                open[j] = temp;
                            }
                        }
                        if ((TypeMoving == typemoving.Doc))
                        {

                            if (DanhGia1(open[i], Position2) > DanhGia1(open[j], Position2))
                            {
                                temp = open[i];
                                open[i] = open[j];
                                open[j] = temp;
                            }
                        }
                    }
                    else
                    {
                        if (DanhGia1(open[i], Position2) > DanhGia1(open[j], Position2))
                        {
                            temp = open[i];
                            open[i] = open[j];
                            open[j] = temp;
                        }
                        else if (DanhGia1(open[i], Position2) == DanhGia1(open[j], Position2))
                        {
                            if (DanhGia2(open[i], Position2) > DanhGia2(open[j], Position2))
                            {
                                temp = open[i];
                                open[i] = open[j];
                                open[j] = temp;
                            }
                        }
                    }


                }

            }
        }

        void DiChuyen(Vector2 Position)
        {
            //open.Add(this.Position);
            
            if ((this.Position.X % 26 == 0) && (this.Position.Y % 26 == 0))
            {
                

                open.RemoveAll(item => item != null);
                Vector2 tren = new Vector2(this.Position.X, this.Position.Y - 26);
                Vector2 duoi = new Vector2(this.Position.X, this.Position.Y + 26);
                Vector2 trai = new Vector2(this.Position.X - 26, this.Position.Y);
                Vector2 phai = new Vector2(this.Position.X + 26, this.Position.Y);

                if (!GLOBAL.IsInsideList(this.Position, close))
                    close.Add(this.Position);

                open.Add(tren);

                open.Add(duoi);

                open.Add(trai);

                open.Add(phai);


                sapxep(open,Position);

                while ((GLOBAL.IsInsideList(open[0], close)) || (GLOBAL.IsInsideList(open[0], CellBiKet)))
                {
                    open.Remove(open[0]);

                    if (open.Count == 0) break;
                }


                if (open.Count > 0)
                {

                    if (open[0] == tren)
                    {
                        Up();

                    }
                    else if (open[0] == duoi)
                    {
                        Down();

                    }
                    else if (open[0] == trai)
                    {
                        Left();

                    }
                    else if (open[0] == phai)
                    {
                        Right();

                    }


                }


            }

        }
        bool IsMeetObject()
        {
            bool MeetPlayer=false;
            bool MeetProtect=false;
            if (
                (((State == tankstate.up) && (GLOBAL.xe.Position.Y < Position.Y) && (GLOBAL.xe.Position.X > Position.X - 26) && (GLOBAL.xe.Position.X < Position.X + 26)))
                || (((State == tankstate.down) && (GLOBAL.xe.Position.Y > Position.Y) && (GLOBAL.xe.Position.X > Position.X - 26) && (GLOBAL.xe.Position.X < Position.X + 26)))
                || (((State == tankstate.left) && (GLOBAL.xe.Position.X < Position.X) && (GLOBAL.xe.Position.Y > Position.Y - 26) && (GLOBAL.xe.Position.Y < Position.Y + 26)))
                || (((State == tankstate.right) && (GLOBAL.xe.Position.X > Position.X) && (GLOBAL.xe.Position.Y > Position.Y - 26) && (GLOBAL.xe.Position.Y < Position.Y + 26)))
                )
                MeetPlayer = true;
            if ((((State == tankstate.up) && (GLOBAL.PosObjectProtect.Y < Position.Y) && (GLOBAL.PosObjectProtect.X > Position.X - 26) && (GLOBAL.PosObjectProtect.X < Position.X + 26)))
                || (((State == tankstate.down) && (GLOBAL.PosObjectProtect.Y > Position.Y) && (GLOBAL.PosObjectProtect.X > Position.X - 26) && (GLOBAL.PosObjectProtect.X < Position.X + 26)))
                || (((State == tankstate.left) && (GLOBAL.PosObjectProtect.X < Position.X) && (GLOBAL.PosObjectProtect.Y > Position.Y - 26) && (GLOBAL.PosObjectProtect.Y < Position.Y + 26)))
                || (((State == tankstate.right) && (GLOBAL.PosObjectProtect.X > Position.X) && (GLOBAL.PosObjectProtect.Y > Position.Y - 26) && (GLOBAL.PosObjectProtect.Y < Position.Y + 26))))
                MeetProtect = true;

            if ((MeetProtect == true) || (MeetPlayer == true)) return true;
            return false;
        }
        bool IsNearObject()
        {
            return ((DanhGia2(Position, GLOBAL.xe.Position) < 26*6) || (DanhGia2(Position, GLOBAL.PosObjectProtect) < 26*6));
        }
        void ChangeTypeMoving()
        {
            if (this.TypeMoving==typemoving.Ngang) this.TypeMoving = typemoving.Doc;
            else this.TypeMoving = typemoving.Ngang;
        }
        public override void update(GameTime gameTime)
        {
            TimeFire += gameTime.ElapsedGameTime.TotalSeconds;
            Random rd = new Random();
            if (IsMeetObject())
            {
                Fire();
            }
            if (IsNearObject()) Type = TankType.intelligent;
            else
            {
                if (IsStupid == 1) Type = TankType.normal;
                if (IsStupid == 2) Type = TankType.normal2livepoint;
                if (IsStupid == 3) Type = TankType.normalspeed;
            }
            if ((livepoint == 1)&&(IsStupid==2))
                Model.MultiFramelist.texture = GLOBAL.tankEnermy2Tt;
#region Intelligent

            if (this.Type == enermy.TankType.intelligent)
            {
                
                TimeRandomTypeMoving += gameTime.ElapsedGameTime.TotalSeconds;
               

                if (close.Count > 6)
                {
                    close.RemoveAll(item => item != null);

                }

                if (DanhGia2(this.Position, GLOBAL.xe.Position) < DanhGia2(this.Position, GLOBAL.PosObjectProtect))
                    DiChuyen(GLOBAL.xe.Position);
                else
                    DiChuyen(GLOBAL.PosObjectProtect);

                if (TimeRandomTypeMoving > 1)
                {
                    
                    //if (rd.Next(0,10)+((Position.X+Position.Y)%5)<5)
                    if (rd.Next(0, 10) < 5)
                        ChangeTypeMoving();
                    TimeRandomTypeMoving = 0;
                }

            }
#endregion
#region Normal
            if ((this.Type == enermy.TankType.normal) || (this.Type == enermy.TankType.normal2livepoint) || (this.Type == enermy.TankType.normalspeed))
            {
                Fire();
                TimeNormalChangeMove += gameTime.ElapsedGameTime.TotalSeconds;
                if ((this.Position.X % 26 == 0) && (this.Position.Y % 26 == 0)&&(TimeNormalChangeMove>0.2))
                {
                    
                    int a = rd.Next(1,10);
                    if (a < 5)
                    {
                        int b = rd.Next(1, 10);
                        if (b < 5)
                            Left();
                        else
                            Right();
                    }
                    else
                    {
                        int b = rd.Next(1, 10);
                        if (b < 5)
                            Down();
                        else
                            Up();
                    }
                }
                if (TimeNormalChangeMove > 0.2) TimeNormalChangeMove = 0;
                
            }
#endregion
            
            for (int i = 0; i < GLOBAL.Bullet.Count; i++)
            {
                              
                if (GLOBAL.vachampixel(this.bound, this.Model.MultiFramelist.datacolor, GLOBAL.Bullet[i].Position, GLOBAL.Bullet[i].Model.MultiFramelist.datacolor))
                {
                    if (GLOBAL.Bullet[i].Type == bullet.loaidan.player)
                    {
                        this.livepoint--;
                        //GLOBAL.Bullet[i].isrun = false;
                        GLOBAL.Bullet.Remove(GLOBAL.Bullet[i]);
                    }
                    break;
                }


            }



            if (livepoint <= 0)
            {
                GLOBAL.explosionTank.Add(new MySprite2D(new TextureMultiFrame(GLOBAL.explosionTankTt, 64, 64), 20));                
                GLOBAL.explosionTank[GLOBAL.explosionTank.Count - 1].Position = new Vector2(this.Position.X-52,this.Position.Y-52);
                GLOBAL.Fire.Add(new MySprite2D(new TextureMultiFrame(GLOBAL.FireTt, 64, 106), 70));
                GLOBAL.Fire[GLOBAL.Fire.Count - 1].Position = new Vector2(this.Position.X-26, this.Position.Y-70);
                GLOBAL.enermy.Remove(this);
            }

            base.update(gameTime);
        }
        public void Draw(int firstframe, int lastframe, object obj, Vector2 position, Color color, float rotation, Vector2 origin, float scale, float layerDepth)
        {
            base.Draw(firstframe, lastframe, obj, position, color, rotation, origin, scale, layerDepth);
            // if (close.Count>=4)
            SpriteBatch temp = (SpriteBatch)obj;
            //for (int i=GamePlay.)
            //temp.DrawString(GLOBAL.font,this.Type.ToString(), new Vector2(60, 20), Color.White);

        
        }
    }
}
