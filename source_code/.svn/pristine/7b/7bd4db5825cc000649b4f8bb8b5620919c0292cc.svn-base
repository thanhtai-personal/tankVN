using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace TankVN
{
    class player : tank
    {
        public int[] NumEnermyDestroy=new int[5];
        public bool NotDead = false;
        public int MaxBullet = 1;
        double TimePerFire = 0;
        int speedBullet = 4;
        double _delay=0;
        public int SpeedBullet { get { return speedBullet; } set { this.speedBullet = value; } }
        public player(Force force, Rectangle bound, int livepoint)
            : base(force, bound)
        {

            Rectangle[] ListRectanglePlayer = new Rectangle[4];

            ListRectanglePlayer[0] = new Rectangle(0, 0, 25, 25);
            ListRectanglePlayer[1] = new Rectangle(25, 0, 26, 26);
            ListRectanglePlayer[2] = new Rectangle(0, 26, 25, 27);
            ListRectanglePlayer[3] = new Rectangle(25, 26, 25, 26);

            speedBullet = 4;

           
            TextureMultiFrame framelistPlayer = new TextureMultiFrame(GLOBAL.tankPlayerTt, ListRectanglePlayer);

            this.Model = new MySprite2D(framelistPlayer, 100);
            this.livepoint = livepoint;

        }
        public override void update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            _delay += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (keyboardState.IsKeyDown(Keys.Down))
            {
               
               
                moving = true;
                force.Direction = new Vector2(0, 1);
                this.Model.FristFrame = 2;
                this.Model.LastFrame = 2;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                moving = true;
                force.Direction = new Vector2(0, -1);
                Model.FristFrame = 0;
                Model.LastFrame = 0;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                moving = true;
                force.Direction = new Vector2(1, 0);
                Model.FristFrame = 1;
                Model.LastFrame = 1;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                moving = true;
                force.Direction = new Vector2(-1, 0);
                Model.FristFrame = 3;
                Model.LastFrame = 3;
            }



            if (keyboardState.IsKeyDown(Keys.F))
            {
                Vector2 _Direction = new Vector2(0, 0);
                int X = 0, Y = 0;
                if (Model.FristFrame == 0)
                {
                    X = this.bound.X+4;
                    Y = this.bound.Y-10;
                    _Direction = new Vector2(0, -1);
                }
                else if (Model.FristFrame == 1)
                {
                    X = this.bound.X+13;
                    Y = this.bound.Y + 5;
                    _Direction = new Vector2(1, 0);
                }
                else if (Model.FristFrame == 2)
                {
                    X = this.bound.X + 3;
                    Y = this.bound.Y+15;
                    _Direction = new Vector2(0, 1);
                }
                else if (Model.FristFrame == 3)
                {
                    X = this.bound.X - 8;
                    Y = this.bound.Y + 5;
                    _Direction = new Vector2(-1, 0);
                }
                if ((TimePerFire == 0) && (GLOBAL.NumPlayerBullet() < MaxBullet))
                {
                    GLOBAL.Bullet.Add(new bullet(new Rectangle(X, Y, 11, 11), bullet.loaidan.player, new Force(speedBullet, _Direction, 1)));
                    GLOBAL.Firesound.Play();
                }

                TimePerFire = 1;

            }
            if (keyboardState.IsKeyUp(Keys.F)) TimePerFire = 0;
            if ((!keyboardState.IsKeyDown(Keys.Up)) && (!keyboardState.IsKeyDown(Keys.Down)) && (!keyboardState.IsKeyDown(Keys.Left)) && (!keyboardState.IsKeyDown(Keys.Right)))
                moving = false;
           
            for (int i = 0; i < GLOBAL.Bullet.Count; i++)
            {

                if (GLOBAL.vachampixel(this.bound, this.Model.MultiFramelist.datacolor, GLOBAL.Bullet[i].Position, GLOBAL.Bullet[i].Model.MultiFramelist.datacolor))
                {
                    if (GLOBAL.Bullet[i].Type == bullet.loaidan.enermy)
                    {
                        if (!NotDead)
                        {
                            this.livepoint--;
                            this.bound = new Rectangle(26 * 16, 26 * 25, 26, 26);
                            this.force.Speed = 1;
                            this.MaxBullet = 1;
                            this.speedBullet = 4;
                            GLOBAL.explosionTank.Add(new MySprite2D(new TextureMultiFrame(GLOBAL.explosionTankTt, 64, 64), 20));
                            GLOBAL.explosionTank[GLOBAL.explosionTank.Count - 1].Position = new Vector2(this.Position.X - 52, this.Position.Y - 52);

                        }
                        else
                            {
                                 GLOBAL.explosionBullet.Add(new MySprite2D(new TextureMultiFrame(GLOBAL.explosionBulletTt, 64, 64), 20));
                                 GLOBAL.explosionBullet[GLOBAL.explosionBullet.Count - 1].Position = new Vector2(GLOBAL.Bullet[i].Position.X - 39, GLOBAL.Bullet[i].Position.Y - 39);



                            }
                        //GLOBAL.Bullet[i].isrun = false;
                        GLOBAL.Bullet.Remove(GLOBAL.Bullet[i]);
                    }
                    break;
                }

            }
            
           
           

            if (livepoint <= 0) this.visible = false;
           
                
            base.update(gameTime);
        }
        public void Draw(int firstframe, int lastframe, object obj, Vector2 position, Color color, float rotation, Vector2 origin, float scale, float layerDepth)
        {

            base.Draw(firstframe, lastframe, obj, position, color, rotation, origin, scale, layerDepth);
           
        }
    }
}
