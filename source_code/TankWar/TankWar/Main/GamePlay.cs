﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.IO;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.GamerServices;


namespace TankVN
{
    class GamePlay : Microsoft.Xna.Framework.DrawableGameComponent
    {
       
        SpriteBatch spritebatch;

        public VictoryMenu _VictoryMenu;
        PauseMenu _PauseMenu;
        public int Level;
        public static Vector2 forcespeed;
        public static Rectangle gameZone;
        StreamReader map;
        int[,] maparray;
        public const int numrow = 26;
        public const int numcollumn = 26;
        int[] NumTank,NumTankSave;
        Vector2[] PosXuatHienTank;
        int NumTankXuatHien;
        int randommusic;
        int TankHasItemIndex=0;
        bool IsWin = false;
        bool IsPause = false;
        double TimeApperItem=0;
        double _delay = 0;
        bool flagWinningSound = true;
        bool flagGameOverSound = true;
        
        //static List<Xobject> listX;
        //static List<wall> listwall;
        //static List<grass> listgrass;
        //static List<buicay> listbuicay;
        public static List<cell> LstCell;



        public GamePlay(Game game,int Level)
            : base(game)
        {
            this.IsWin = false;
            this.Level = Level;
            _VictoryMenu = new VictoryMenu();
            _PauseMenu = new PauseMenu();
            maparray = new int[27, 27];

            // TODO: Construct any child components here
        }
        public void readmap(int num)
        {
            int dong = 0;
            string lineOfText;

            NumTankSave[1] = int.Parse(GLOBAL.MapTxt[num-1][0]);
            NumTankSave[2] = int.Parse(GLOBAL.MapTxt[num - 1][1]);
            NumTankSave[3] = int.Parse(GLOBAL.MapTxt[num - 1][2]);
            NumTankSave[4] = int.Parse(GLOBAL.MapTxt[num - 1][3]);

            for (int x = 4; x < GLOBAL.MapTxt[num - 1].Count;x++ )
            {
                dong++;
                lineOfText = GLOBAL.MapTxt[num - 1][x];
                for (int i = 0; i < lineOfText.Length; i++)
                {
                    if (i % 2 == 0)
                        maparray[dong, (i / 2) + 1] = int.Parse(lineOfText[i].ToString());
                }
            }
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            spritebatch = new SpriteBatch(this.Game.GraphicsDevice);
            //background = this.Game.Content.Load<Texture2D>(@"GamePlay/background");
            gameZone = new Rectangle(0, 0, this.Game.Window.ClientBounds.Width-224, this.Game.Window.ClientBounds.Height);
            MediaPlayer.Stop();
            Random rd=new Random();
            randommusic = rd.Next(0, GLOBAL.music.Count);
            if ((GLOBAL.gType == GameType.Level1))
            {
                MediaPlayer.Play(GLOBAL.music[randommusic]);
                GLOBAL.StartGameSound.Play();
            }
           
            base.Initialize();
        }
        protected override void LoadContent()
        {
            
            // Create a new SpriteBatch, which can be used to draw textures.    
            PosXuatHienTank = new Vector2[5];
            PosXuatHienTank[1]= new Vector2(650, 0);
            PosXuatHienTank[2] = new Vector2(208, 0);
            PosXuatHienTank[3] = new Vector2(338, 0);
            PosXuatHienTank[4]= new Vector2(0,0);
            NumTank = new int[5];
            NumTankSave = new int[5];
            readmap(Level);
            for (int i = 1; i < NumTankSave.Count(); i++)
                NumTank[i] = NumTankSave[i];
            GLOBAL.enermy = new List<enermy>();
            if (Level==1)
                GLOBAL.xe = new player(new Force(1, new Vector2(0, 0), 3), new Rectangle(26 * 16, 26 * 25, 26, 26),3);
            else
                GLOBAL.xe = new player(new Force(1, new Vector2(0, 0), 3), new Rectangle(26 * 16, 26 * 25, 26, 26), GLOBAL.XeLivePoint);
              
            GLOBAL.item = new Item();
           
            
            LstCell = new List<cell>();

            for (int i = 1; i <= numrow; i++)
            {
                for (int j = 1; j <= numcollumn; j++)
                {
                    //LstCell.Add(new cell(new Vector2(26 * (j - 1), 26 * (i - 1)), CellType.Co));
                   if (maparray[i, j] == 5)
                        LstCell.Add(new cell(new Vector2(26 * (j - 1), 26 * (i - 1)), CellType.Cell));
                   if (maparray[i, j] == 4)
                       LstCell.Add(new cell(new Vector2(26 * (j - 1), 26 * (i - 1)), CellType.Nuoc));
                    if (maparray[i, j] == 2)
                        LstCell.Add(new cell(new Vector2(26 * (j - 1), 26 * (i - 1)), CellType.Gach));
                    if (maparray[i, j] == 3)
                        LstCell.Add(new cell(new Vector2(26 * (j - 1), 26 * (i - 1)), CellType.BeTong));                     
                }
            }
            LstCell.Add(new cell(new Vector2(26 * 12, 26 * 24), CellType.protect));
            GLOBAL.PosObjectProtect = LstCell[LstCell.Count - 1].Model.Position;
            for (int i = 1; i <= 4;i++ )
                GLOBAL.xe.NumEnermyDestroy[i] = 0;
        }
       
        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// 
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
         public static MySprite2D test = new MySprite2D(new TextureMultiFrame(GLOBAL.EnermyHasItemTt, 80, 80), 100);

         void MediaPlayer_MediaStateChanged(object sender, EventArgs e)
         {
             if (MediaPlayer.State == MediaState.Stopped)
             {                
                 MediaPlayer.Play(GLOBAL.music[randommusic]);
             }

         }
        public override void Update(GameTime gameTime)
        {
            if ((GLOBAL.gType == GameType.Level1))
            {
                MediaPlayer.MediaStateChanged += new EventHandler<EventArgs>(MediaPlayer_MediaStateChanged);                
            }
                    
            if (!IsPause)
            {                
                if (!IsWin)
                {

                    // TODO: Add your update code here
                    KeyboardState keyboardState = Keyboard.GetState();
                    if (keyboardState.IsKeyDown(Keys.Escape))
                    {
                        IsPause = true;
                    }
            
                    // TODO: Add your update logic here
                    if ((NumTank[1] + NumTank[2] + NumTank[3] + NumTank[4] + GLOBAL.enermy.Count) == 0)
                    {

                        if (GLOBAL.gamedata.maxlevel >= this.Level)
                        {
                            GLOBAL.gamedata.livepoint[Level - 1] = GLOBAL.xe.livepoint;
                        }
                        if (GLOBAL.gamedata.maxlevel < this.Level)
                        {
                            GLOBAL.gamedata.maxlevel = this.Level;
                            GLOBAL.gamedata.livepoint.Add(GLOBAL.xe.livepoint);
                        }

                        IsWin = true;

                    }
                    bool DaXuatHienTankItem = false;
                    for (int i = 0; i < GLOBAL.enermy.Count - 1; i++)
                        if (GLOBAL.enermy[i].HasItem == true)
                        {
                            DaXuatHienTankItem = true;
                            break;
                        }
                    if (DaXuatHienTankItem == false)
                        TimeApperItem += gameTime.ElapsedGameTime.TotalSeconds;
                    test.Update(gameTime);
                    if (GLOBAL.enermy.Count < 4)
                    {

                        Random num = new Random();
                        int temp = num.Next(1, 5);
                        if (NumTank[temp] > 0)
                        {
                            int pos = (temp + NumTank[1] + NumTank[2] + NumTank[3] + NumTank[4]) % 4 + 1;
                            switch (temp)
                            {
                                case 1:
                                    GLOBAL.enermy.Add(new enermy(enermy.TankType.normal, new Force(1, new Vector2(0, 0), 3), new Rectangle((int)PosXuatHienTank[pos].X, 0, 26, 26), 1));
                                    NumTank[1]--;
                                    break;

                                case 2:
                                    GLOBAL.enermy.Add(new enermy(enermy.TankType.intelligent, new Force(1, new Vector2(0, 0), 3), new Rectangle((int)PosXuatHienTank[pos].X, 0, 26, 26), 1));
                                    NumTank[2]--;
                                    break;

                                case 3:
                                    GLOBAL.enermy.Add(new enermy(enermy.TankType.normal2livepoint, new Force(1, new Vector2(0, 0), 3), new Rectangle((int)PosXuatHienTank[pos].X, 0, 26, 26), 1));
                                    NumTank[3]--;
                                    break;


                                case 4:
                                    GLOBAL.enermy.Add(new enermy(enermy.TankType.normalspeed, new Force(1, new Vector2(0, 0), 3), new Rectangle((int)PosXuatHienTank[pos].X, 0, 26, 26), 1));
                                    NumTank[4]--;
                                    break;

                            }

                            if ((GLOBAL.enermy.Count > 0) && (TimeApperItem > 7) && (DaXuatHienTankItem == false))
                            {
                                GLOBAL.enermy[GLOBAL.enermy.Count - 1].HasItem = true;
                                TimeApperItem = 0;
                            }
                        }


                    }

                    for (int i = 0; i < LstCell.Count; i++)
                    {
                        if (LstCell[i].type == CellType.BeTong || LstCell[i].type == CellType.Gach || LstCell[i].type == CellType.protect || LstCell[i].type == CellType.Nuoc)
                        {
                            //if (Bound2D.vachampixel(new Rectangle(Global.xe.bound.X + (int)Global.xe.Force.CurrentSpeed.X, Global.xe.bound.Y + (int)Global.xe.Force.CurrentSpeed.Y, Global.xe.Skin.framelist.currentrectangle.Width, Global.xe.Skin.framelist.currentrectangle.Height), Global.xe.Skin.framelist.datacolor, LstCell[i].Position, LstCell[i].datacolor))
                            if (GLOBAL.IsCut(GLOBAL.xe.bound, new Rectangle((int)LstCell[i].Model.Position.X, (int)LstCell[i].Model.Position.Y, LstCell[i].Model.Width, LstCell[i].Model.Height)))
                            {
                                GLOBAL.xe.bound = GLOBAL.xe.lastbound;
                            }

                            LstCell[i].Update(gameTime);

                        }

                    }
                    for (int i = 0; i < GLOBAL.enermy.Count; i++)
                    {
                        GLOBAL.enermy[i].BiKet = false;
                        for (int j = 0; j < LstCell.Count; j++)
                        {


                            if (LstCell[j].type == CellType.BeTong || LstCell[j].type == CellType.Gach || LstCell[j].type == CellType.protect || LstCell[j].type == CellType.Nuoc)
                            {
                                if ((GLOBAL.IsCut(GLOBAL.enermy[i].bound, new Rectangle((int)LstCell[j].Model.Position.X, (int)LstCell[j].Model.Position.Y, LstCell[j].Model.Width, LstCell[j].Model.Height))))
                                {
                                    GLOBAL.enermy[i].bound = GLOBAL.enermy[i].lastbound;
                                    //Global.enermy[i].Moving = false;  
                                    if (LstCell[j].type == CellType.BeTong || LstCell[j].type == CellType.Nuoc)
                                    {
                                        GLOBAL.enermy[i].BiKet = true;
                                        Vector2 pos = new Vector2(LstCell[j].Model.Position.X, LstCell[j].Model.Position.Y);
                                        if (!GLOBAL.IsInsideList(pos, GLOBAL.enermy[i].CellBiKet))
                                            GLOBAL.enermy[i].CellBiKet.Add(pos);
                                    }
                                    if (LstCell[j].type == CellType.Gach)
                                    {
                                        GLOBAL.enermy[i].Fire();
                                        //Global.enermy[i].BiKet = false;
                                    }
                                }
                            }
                        }

                    }
                    for (int i = 0; i < GLOBAL.Bullet.Count; i++)
                    {
                        if (GLOBAL.IsOutside(GLOBAL.Bullet[i].Position, gameZone))
                        {
                            GLOBAL.Bullet.Remove(GLOBAL.Bullet[i]);
                        }
                        for (int j = i; j < GLOBAL.Bullet.Count; j++)
                        {
                            if ((j != i) && (GLOBAL.vachampixel(GLOBAL.Bullet[i].Position, GLOBAL.Bullet[i].Model.MultiFramelist.datacolor, GLOBAL.Bullet[j].Position, GLOBAL.Bullet[j].Model.MultiFramelist.datacolor)))
                            {
                                GLOBAL.explosionBullet.Add(new MySprite2D(new TextureMultiFrame(GLOBAL.explosionBulletTt, 64, 64), 20));
                                GLOBAL.explosionBullet[GLOBAL.explosionBullet.Count - 1].Position = new Vector2(GLOBAL.Bullet[i].Position.X - 39, GLOBAL.Bullet[i].Position.Y - 39);
                                GLOBAL.Bullet[i].isrun = false;
                                GLOBAL.Bullet[j].isrun = false;
                            }
                        }
                    }

                    GLOBAL.xe.update(gameTime);
                    for (int i = 0; i < GLOBAL.enermy.Count; i++)
                        GLOBAL.enermy[i].update(gameTime);

                    if (GLOBAL.xe.livepoint <= 0)
                    {
                        GLOBAL.GameOver = true;
                        if (flagGameOverSound = true)
                        {
                            GLOBAL.GameOverSound.Play();
                            flagGameOverSound = false;
                            MediaPlayer.Stop();
                        }

                    }
                    for (int i = 0; i < GLOBAL.explosionGach.Count; i++)
                    {
                        GLOBAL.explosionGach[i].Update(gameTime);
                        if (GLOBAL.explosionGach[i].index == 64) GLOBAL.explosionGach.Remove(GLOBAL.explosionGach[i]);
                    }
                    for (int i = 0; i < GLOBAL.explosionTank.Count; i++)
                    {
                        GLOBAL.explosionTank[i].Update(gameTime);
                        if (GLOBAL.explosionTank[i].index == 48) GLOBAL.explosionTank.Remove(GLOBAL.explosionTank[i]);
                    }
                    for (int i = 0; i < GLOBAL.explosionBullet.Count; i++)
                    {
                        GLOBAL.explosionBullet[i].Update(gameTime);
                        if (GLOBAL.explosionBullet[i].index == 19) GLOBAL.explosionBullet.Remove(GLOBAL.explosionBullet[i]);
                    }

                    for (int i = 0; i < GLOBAL.Fire.Count; i++)
                    {
                        GLOBAL.Fire[i].Update(gameTime);
                        if (GLOBAL.Fire[i].numloop / 16 == 5)

                            GLOBAL.Fire.Remove(GLOBAL.Fire[i]);

                    }

                    GLOBAL.item.Update(gameTime);
                }

                if (IsWin)
                {

                    if (flagWinningSound)
                    {
                        GLOBAL.WinningSound.Play();

                        flagWinningSound = false;
                    }


                    _VictoryMenu.Update(gameTime);
                    if (_VictoryMenu.btn_click == true)
                    {
                        if (_VictoryMenu.selectedButton == 0)
                        {
                            GLOBAL.Win = true;
                            IsWin = false;
                        }
                        else if (_VictoryMenu.selectedButton == 1)
                        {
                            GLOBAL.Win = false;
                            IsWin = false;
                            GLOBAL.gType = GameType.gamenu;
                            MediaPlayer.Stop();
                        }
                    }
                }
            }
            else if (IsPause)
            {
                _PauseMenu.Update(gameTime);

                if (_PauseMenu.btn_click == true)
                {
                    if (_PauseMenu.selectedButton == 1)
                    {
                        IsPause = false;
                        _PauseMenu.btn_click = false;
                    }
                    else if (_PauseMenu.selectedButton == 0)
                    {                        
                        IsPause = false;
                        GLOBAL.gType = GameType.gamenu;
                        _PauseMenu.btn_click = false;
                        MediaPlayer.Stop();
                    }
                    else if (_PauseMenu.selectedButton == 2)
                    {                        
                        _PauseMenu.btn_click = false;
                        if ((MediaPlayer.Volume > 0) || (SoundEffect.MasterVolume > 0))
                        {
                            MediaPlayer.Volume = 0;
                            SoundEffect.MasterVolume = 0;
                        }
                        else
                        {
                            MediaPlayer.Volume = 0.5f;
                            SoundEffect.MasterVolume = 0.5f;
                        }
                    }
                }
            }
           
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spritebatch.Begin();
            // TODO: Add your drawing code here    

            // spritebatch.Draw(background, new Rectangle(0, 0, 700, 600), Color.White);



            //for (int i = 0; i < listgrass.Count; i++)
            //    listgrass[i].Draw(spritebatch);
            //for (int i = 0; i < listX.Count; i++)
            //    listX[i].Draw(spritebatch);
            //for (int i = 0; i < listwall.Count; i++)
            //    listwall[i].Draw(spritebatch);

            spritebatch.Draw(GLOBAL.bgtexture, new Rectangle(0, 0, 26 * 26, 26 * 26), Color.White);
#region sideBG
            spritebatch.Draw(GLOBAL.sideBG, new Rectangle(26 * 26, 0, 224, 26 * 26), Color.White);
            spritebatch.DrawString(GLOBAL.font, this.Level.ToString(), new Vector2(790, 20), Color.White);
            spritebatch.DrawString(GLOBAL.font, GLOBAL.xe.livepoint.ToString(), new Vector2(810, 293), Color.White);
            spritebatch.DrawString(GLOBAL.font2,NumTank[1].ToString() + "/" +NumTankSave[1].ToString(), new Vector2(770, 440), Color.White);
            spritebatch.DrawString(GLOBAL.font2, NumTank[3].ToString() + "/" + NumTankSave[3].ToString(), new Vector2(770, 472), Color.White);
            spritebatch.DrawString(GLOBAL.font2, NumTank[4].ToString() + "/" + NumTankSave[4].ToString(), new Vector2(770, 504), Color.White);
            spritebatch.DrawString(GLOBAL.font2, NumTank[2].ToString() + "/" + NumTankSave[2].ToString(), new Vector2(770, 536), Color.White);
#endregion
            
            GLOBAL.xe.Draw(0, 0, spritebatch, GLOBAL.xe.Model.Position, Color.White, 0f, Vector2.Zero, 0f, 0f);
            for (int i = 0; i < GLOBAL.enermy.Count; i++)
                GLOBAL.enermy[i].Draw(0, 0, spritebatch, GLOBAL.enermy[i].Model.Position, Color.White, 0f, Vector2.Zero, 0f, 0f);
            for (int i = 0; i < LstCell.Count; i++)
            {
                if (LstCell[i].type == CellType.Nuoc)
                    LstCell[i].Draw(0, 0, spritebatch, LstCell[i].Model.Position, Color.White, 0f, Vector2.Zero, 0f, 0f);
            }
            for (int i = 0; i < GLOBAL.Bullet.Count; i++)
            {
                GLOBAL.Bullet[i].Draw(0, 3, spritebatch,Vector2.Zero, Color.White, 0f, Vector2.Zero, 0f, 0f);
            }
            for (int i = 0; i < LstCell.Count; i++)
            {
                if (LstCell[i].type != CellType.Nuoc)
                    LstCell[i].Draw(0, 0, spritebatch, LstCell[i].Model.Position, Color.White, 0f, Vector2.Zero, 0f, 0f);
            }

            GLOBAL.item.Draw(0, 0, spritebatch, GLOBAL.item.Model.Position, Color.White, 0f, Vector2.Zero, 1f, 0f);
            for (int i = 0; i < GLOBAL.Fire.Count; i++)
            {
                GLOBAL.Fire[i].Draw(1, 64, spritebatch, GLOBAL.Fire[i].Position, Color.White, 0f, Vector2.Zero, 1f, 0f);
            }
           
           //for (int i = 0; i < listbuicay.Count; i++)
               // listbuicay[i].Draw(spritebatch);
            for (int i = 0; i < GLOBAL.explosionGach.Count; i++)
            {
                GLOBAL.explosionGach[i].Draw(1,64,spritebatch,GLOBAL.explosionGach[i].Position,Color.White,0f,Vector2.Zero,1f,0f);
            }
            for (int i = 0; i < GLOBAL.explosionTank.Count; i++)
            {
                GLOBAL.explosionTank[i].Draw(1, 64, spritebatch, GLOBAL.explosionTank[i].Position, Color.White, 0f, Vector2.Zero, 2f, 0f);
            }
            for (int i = 0; i < GLOBAL.explosionBullet.Count; i++)
            {
                GLOBAL.explosionBullet[i].Draw(1, 64, spritebatch, GLOBAL.explosionBullet[i].Position, Color.White, 0f, Vector2.Zero, 1.5f, 0f);
            }

            //SpriteBatch temp = (SpriteBatch)obj;
            if (IsWin)
                _VictoryMenu.Draw(1,1,spritebatch,Vector2.Zero,Color.White,0f,Vector2.Zero,1f,0f);
            if (IsPause)
                _PauseMenu.Draw(1, 1, spritebatch, Vector2.Zero, Color.White, 0f, Vector2.Zero, 1f, 0f);

           // test.Draw(1, 10, spritebatch, Vector2.Zero, Color.White, 0f, Vector2.Zero, 1f, 0f);
            spritebatch.End();
            base.Draw(gameTime);
        }
        

    }
}
