using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TankWar
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    enum GameType
    {
        gamenu,
        Level1
    }
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameType gType = GameType.gamenu;
       
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //Global.bulletSound = this.Content.Load<SoundEffect>(@"GamePlay/bulletSound");

            this.graphics.PreferredBackBufferWidth = 900;
            this.graphics.PreferredBackBufferHeight = 676;
        }

        GameMenu menu;
        GamePlay lv1;
        GameOver gameover;
        protected override void Initialize()
        {
            GLOBAL.nhacnenGame = this.Content.Load<Song>(@"GameMenu/NhacNenMenu");
            #region Menu
            #region MenuTable
            GLOBAL.Playtexture = Content.Load<Texture2D>(@"GameMenu/btnPlay");
            GLOBAL.Loadtexture = Content.Load<Texture2D>(@"GameMenu/btnLoad");
            GLOBAL.Opotiontexture = Content.Load<Texture2D>(@"GameMenu/btnOpotion");
            GLOBAL.Scoretexture = Content.Load<Texture2D>(@"GameMenu/btnScore");
            GLOBAL.Exittexture = Content.Load<Texture2D>(@"GameMenu/btnExit");
            GLOBAL.Menutabletexture = Content.Load<Texture2D>(@"GameMenu/MenuTable3");
            GLOBAL.Playtexture2 = Content.Load<Texture2D>(@"GameMenu/btnPlay1");
            GLOBAL.Loadtexture2 = Content.Load<Texture2D>(@"GameMenu/btnLoad1");
            GLOBAL.Opotiontexture2 = Content.Load<Texture2D>(@"GameMenu/btnOpotion1");
            GLOBAL.Scoretexture2 = Content.Load<Texture2D>(@"GameMenu/btnScore1");
            GLOBAL.Exittexture2 = Content.Load<Texture2D>(@"GameMenu/btnExit1");
            
            #endregion
            GLOBAL.sideBG = Content.Load<Texture2D>(@"GameMenu/sidebackground");
            GLOBAL.TitleTexture = Content.Load<Texture2D>(@"GameMenu/TitleGame");
            GLOBAL.MenuBackground = Content.Load<Texture2D>(@"GameMenu/menubackground5");

            #region sound effect
            GLOBAL.changeButtonSound = Content.Load<SoundEffect>(@"GameMenu/changeButton");
            GLOBAL.menutableSound = Content.Load<SoundEffect>(@"GameMenu/Menutablesound3");
            GLOBAL.enterGameSound = Content.Load<SoundEffect>(@"GameMenu/entergamesound");
            #endregion

            

            #endregion

            #region GamePlay
            GLOBAL.BulletTexture = Content.Load<Texture2D>(@"GamePlay/bullet");
            GLOBAL.Gachtexture = Content.Load<Texture2D>(@"GamePlay/TuongGach");
            GLOBAL.walltexture = Content.Load<Texture2D>(@"GamePlay/wall");
            GLOBAL.bgtexture = Content.Load<Texture2D>(@"GamePlay/bg");
            GLOBAL.ProtectTexture = Content.Load<Texture2D>(@"GamePlay/protect");
            GLOBAL.buicaytexture = Content.Load<Texture2D>(@"GamePlay/buicay");
            GLOBAL.map_filepath = Content.RootDirectory + "//map01.txt";
            GLOBAL.font = Content.Load<SpriteFont>("sprf");
            GLOBAL.font2 = Content.Load<SpriteFont>("font2");
            GLOBAL.tankEnermy1Tt = Content.Load<Texture2D>(@"GamePlay/tank1");
            GLOBAL.tankEnermy2Tt = Content.Load<Texture2D>(@"GamePlay/tank2");
            GLOBAL.tankEnermy3Tt = Content.Load<Texture2D>(@"GamePlay/tank3");
            GLOBAL.tankEnermy4Tt = Content.Load<Texture2D>(@"GamePlay/tank4");
            GLOBAL.tankPlayerTt = Content.Load<Texture2D>(@"GamePlay/tank0");
            GLOBAL.GameOverBG = Content.Load<Texture2D>(@"GameMenu/GameOverBG");
            GLOBAL.explosionGachTt = Content.Load<Texture2D>(@"GamePlay/ExplosionGach");
            GLOBAL.explosionTankTt = Content.Load<Texture2D>(@"GamePlay/ExplosionTank");
            GLOBAL.explosionBulletTt = Content.Load<Texture2D>(@"GamePlay/vachamBullet");
            GLOBAL.FireTt = Content.Load<Texture2D>(@"GamePlay/fire");
            #endregion
            
            menu = new GameMenu(this);
            menu.Enabled = true;
            this.Components.Add(menu);

            #region lv1
            lv1 = new GamePlay(this,1);
            this.Components.Add(lv1);
            #endregion

            #region gameover
            gameover = new GameOver(this);
            this.Components.Add(gameover);
            #endregion
            base.Initialize();
        }
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            GLOBAL.Bullet = new List<bullet>();
            GLOBAL.explosionGach = new List<MySprite2D>();
            GLOBAL.explosionTank = new List<MySprite2D>();
            GLOBAL.explosionBullet = new List<MySprite2D>();
            GLOBAL.Fire = new List<MySprite2D>();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            this.Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            //if (MediaPlayer.State == MediaState.Stopped)
            //{
            //    MediaPlayer.Play(Global.nhacnenGame);
            //}
            if (menu.NewGameClick == true)
            {
                this.gType = GameType.Level1;
                menu.NewGameClick = false;
                GLOBAL.GameOver = false;
            }
            if (gameover.btn_Replay_click == true)
            {
                this.gType = GameType.Level1;
                gameover.btn_Replay_click = false;
                gameover.Enabled = false;
                gameover.Visible = false;
                this.Components.Remove(lv1);
                lv1 = new GamePlay(this,1);                
                this.Components.Add(lv1);
                GLOBAL.GameOver = false;
            }
            switch (gType)
            {
                case GameType.gamenu:
                    {
                        lv1.Visible = false;
                        lv1.Enabled = false;
                        //co = 0;
                        menu.Enabled = true;
                        menu.Visible = true;
                        break;
                    }
                case GameType.Level1:
                    {
                        //this.UnloadContent();
                        menu.Visible = false;
                        menu.Enabled = false;

                        if (GLOBAL.GameOver == false)
                        {
                            lv1.Enabled = true;
                            lv1.Visible = true;
                        }
                        else
                        {
                            lv1.Enabled = false;
                            lv1.Visible = false;
                            gameover.Enabled = true;
                            gameover.Visible = true;
                        }               

                        break;
                    }
            }
            // TODO: Add your update logic here
            for (int i = 0; i < GLOBAL.Bullet.Count; i++)
                GLOBAL.Bullet[i].update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            
               
            
            base.Draw(gameTime);
        }
    }
}