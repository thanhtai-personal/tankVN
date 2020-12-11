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
using Microsoft.Xna.Framework.GamerServices;
namespace TankVN
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    enum GameType
    {
        gamenu,
        selectmap,
        Level1
    }
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
       
        public Game1()
        {
            MediaPlayer.Volume = 0.5f;
            SoundEffect.MasterVolume = 0.5f;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //Global.bulletSound = this.Content.Load<SoundEffect>(@"GamePlay/bulletSound");
            GLOBAL.gType = GameType.gamenu;
            this.graphics.PreferredBackBufferWidth = 900;            
            this.graphics.PreferredBackBufferHeight = 676;
            
            //this.Components.Add(this.graphics);
            
        }

        GameMenu menu;
        GamePlay lvl;
        GameOver gameover;
        const int NUM_MUSIC = 9;
        SelectMapMenu _SelectMapMenu;
        protected override void Initialize()
        {

           
            GLOBAL.Bullet = new List<bullet>();
            GLOBAL.explosionGach = new List<MySprite2D>();
            GLOBAL.explosionTank = new List<MySprite2D>();
            GLOBAL.explosionBullet = new List<MySprite2D>();
            GLOBAL.Fire = new List<MySprite2D>();

            this.UnloadContent();
            this.LoadContent();

            menu = new GameMenu(this);
            menu.Enabled = true;
            this.Components.Add(menu);

            #region lvl
            lvl = new GamePlay(this, 1);
            this.Components.Add(lvl);
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
          
            // TODO: use this.Content to load your game content here

            spriteBatch = new SpriteBatch(GraphicsDevice);
            GLOBAL.nhacnenGame = this.Content.Load<Song>(@"GameMenu/NhacNenMenu");
            GLOBAL.music = new List<Song>();
            for (int i = 0; i < NUM_MUSIC; i++)
            {

                GLOBAL.music.Add(this.Content.Load<Song>(@"music/m" + (i + 1).ToString()));
            }

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

            GLOBAL.VictoryMenuBG = Content.Load<Texture2D>(@"GameMenu/VictoryMenuBG");
            GLOBAL.BtnOkUp = Content.Load<Texture2D>(@"GameMenu/BtnOkUp");
            GLOBAL.BtnOkDown = Content.Load<Texture2D>(@"GameMenu/BtnOkDown");
            GLOBAL.BtnBackMenuUp = Content.Load<Texture2D>(@"GameMenu/BtnBackMenuUp");
            GLOBAL.BtnBackMenuDown = Content.Load<Texture2D>(@"GameMenu/BtnBackMenuDown");

            GLOBAL.PauseMenuBG = Content.Load<Texture2D>(@"GameMenu/PauseMenuBG");
            GLOBAL.BtnPlayUp = Content.Load<Texture2D>(@"GameMenu/BtnPlayUp");
            GLOBAL.BtnPlayDown = Content.Load<Texture2D>(@"GameMenu/BtnPlayDown");
            GLOBAL.BtnMusicOn = Content.Load<Texture2D>(@"GameMenu/BtnMusicOn");
            GLOBAL.BtnMusicOff = Content.Load<Texture2D>(@"GameMenu/BtnMusicOff");
            GLOBAL.BtnMusicOnDown = Content.Load<Texture2D>(@"GameMenu/BtnMusicOnDown");
            GLOBAL.BtnMusicOffDown = Content.Load<Texture2D>(@"GameMenu/BtnMusicOffDown");
            GLOBAL.BtnExitUp = Content.Load<Texture2D>(@"GameMenu/BtnExitUp");
            GLOBAL.BtnExitDown = Content.Load<Texture2D>(@"GameMenu/BtnExitDown");
            GLOBAL.BtnAboutUp = Content.Load<Texture2D>(@"GameMenu/BtnAboutUp");
            GLOBAL.BtnAboutDown = Content.Load<Texture2D>(@"GameMenu/BtnAboutDown");

            #region sound effect
            GLOBAL.changeButtonSound = Content.Load<SoundEffect>(@"GameMenu/changeButton");
            GLOBAL.menutableSound = Content.Load<SoundEffect>(@"GameMenu/Menutablesound3");
            GLOBAL.enterGameSound = Content.Load<SoundEffect>(@"GameMenu/entergamesound");
            GLOBAL.Firesound = Content.Load<SoundEffect>(@"music/Fire");
            GLOBAL.ExplosionGachsound = Content.Load<SoundEffect>(@"music/ExplosionGach");
            GLOBAL.ExplosionTanksound = Content.Load<SoundEffect>(@"music/ExplosionTank");
            GLOBAL.ItemAppearSound = Content.Load<SoundEffect>(@"music/ItemAppear");
            GLOBAL.WinningSound = Content.Load<SoundEffect>(@"music/WINNING");
            GLOBAL.GameOverSound = Content.Load<SoundEffect>(@"music/GameOver");
            GLOBAL.StartGameSound = Content.Load<SoundEffect>(@"music/StartGame");

            GLOBAL.KillAllItemSound = Content.Load<SoundEffect>(@"music/KillAllItem");
            GLOBAL.UpdateItemSound = Content.Load<SoundEffect>(@"music/UpdateItem");
            GLOBAL.SpeedItemSound = Content.Load<SoundEffect>(@"music/SpeedItem");
            GLOBAL.HouseItemSound = Content.Load<SoundEffect>(@"music/HouseItem");
            GLOBAL.HeartItemSound = Content.Load<SoundEffect>(@"music/HeartItem");
            GLOBAL.FreezeItemSound = Content.Load<SoundEffect>(@"music/FreezeItem");
            GLOBAL.ShieldItemSound = Content.Load<SoundEffect>(@"music/ShieldItem");
            GLOBAL.TeleportItemSound = Content.Load<SoundEffect>(@"music/TeleportItem");
            #endregion



            #endregion

            #region GamePlay
            GLOBAL.BulletTexture = Content.Load<Texture2D>(@"GamePlay/bullet");
            GLOBAL.Gachtexture = Content.Load<Texture2D>(@"GamePlay/TuongGach");
            GLOBAL.walltexture = Content.Load<Texture2D>(@"GamePlay/wall");
            GLOBAL.bgtexture = Content.Load<Texture2D>(@"GamePlay/bg");
            GLOBAL.ProtectTexture = Content.Load<Texture2D>(@"GamePlay/protect");
            GLOBAL.buicaytexture = Content.Load<Texture2D>(@"GamePlay/buicay");
            GLOBAL.waterTt = Content.Load<Texture2D>(@"GamePlay/water");


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

            GLOBAL.EnermyHasItemTt = Content.Load<Texture2D>(@"GamePlay/EnermyHasItemEf");
            GLOBAL.KillAllItemTt = Content.Load<Texture2D>(@"GamePlay/KillAllItem");
            GLOBAL.KillAllEfTt = Content.Load<Texture2D>(@"GamePlay/KillAllEf");
            GLOBAL.ItemEf = Content.Load<Texture2D>(@"GamePlay/ItemEf");
            GLOBAL.FreezeTimeItemTt = Content.Load<Texture2D>(@"GamePlay/FreezeTimeItem");
            GLOBAL.FreezeEffectGamezoneTt = Content.Load<Texture2D>(@"GamePlay/FreezeEffectGameZone");
            GLOBAL.ShieldItemTt = Content.Load<Texture2D>(@"GamePlay/ShieldItem");
            GLOBAL.ShieldItemEfTt = Content.Load<Texture2D>(@"GamePlay/ShieldItemEf");
            GLOBAL.HeartItemTt = Content.Load<Texture2D>(@"GamePlay/HeartItem");
            GLOBAL.HeartItemEfTt = Content.Load<Texture2D>(@"GamePlay/HeartItemEf");
            GLOBAL.SpeedItemTt = Content.Load<Texture2D>(@"GamePlay/SpeedItem");
            GLOBAL.SpeedItemEfTt = Content.Load<Texture2D>(@"GamePlay/SpeedItemEf");
            GLOBAL.UpdateItemTt = Content.Load<Texture2D>(@"GamePlay/UpdateItem");
            GLOBAL.HouseItemTt = Content.Load<Texture2D>(@"GamePlay/HouseItem");
            GLOBAL.HouseItemEfTt = Content.Load<Texture2D>(@"GamePlay/HouseItemEf");
            GLOBAL.TeleportItemTt = Content.Load<Texture2D>(@"GamePlay/TeleportItem");
            GLOBAL.TeleportItemEfTt = Content.Load<Texture2D>(@"GamePlay/TeleportItemEf");

            #endregion
            #region MapResource
            GLOBAL.MapTxt = new List<List<string>>();
            GLOBAL.MapTxt.Add(new List<string>(0));
            GLOBAL.MapTxt[0].Add("10");
            GLOBAL.MapTxt[0].Add("6");
            GLOBAL.MapTxt[0].Add("2");
            GLOBAL.MapTxt[0].Add("2");
            GLOBAL.MapTxt[0].Add("1,1,1,1,1,1,3,3,1,1,1,1,1,1,3,3,1,1,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[0].Add("1,1,1,1,1,1,3,3,1,1,1,1,1,1,3,3,1,1,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[0].Add("1,1,2,2,1,1,3,3,1,1,1,1,1,1,2,2,1,1,2,2,1,1,2,2,1,1,");
            GLOBAL.MapTxt[0].Add("1,1,2,2,1,1,3,3,1,1,1,1,1,1,2,2,1,1,2,2,1,1,2,2,1,1,");
            GLOBAL.MapTxt[0].Add("1,1,2,2,1,1,1,1,1,1,1,1,2,2,2,2,1,1,2,2,3,3,2,2,1,1,");
            GLOBAL.MapTxt[0].Add("1,1,2,2,1,1,1,1,1,1,1,1,2,2,2,2,1,1,2,2,3,3,2,2,1,1,");
            GLOBAL.MapTxt[0].Add("1,1,1,1,1,1,2,2,1,1,1,1,1,1,1,1,1,1,3,3,1,1,1,1,1,1,");
            GLOBAL.MapTxt[0].Add("1,1,1,1,1,1,2,2,1,1,1,1,1,1,1,1,1,1,3,3,1,1,1,1,1,1,");
            GLOBAL.MapTxt[0].Add("5,5,1,1,1,1,2,2,1,1,1,1,3,3,1,1,1,1,2,2,5,5,2,2,3,3,");
            GLOBAL.MapTxt[0].Add("5,5,1,1,1,1,2,2,1,1,1,1,3,3,1,1,1,1,2,2,5,5,2,2,3,3,");
            GLOBAL.MapTxt[0].Add("5,5,5,5,1,1,1,1,1,1,2,2,1,1,1,1,3,3,1,1,5,5,1,1,1,1,");
            GLOBAL.MapTxt[0].Add("5,5,5,5,1,1,1,1,1,1,2,2,1,1,1,1,3,3,1,1,5,5,1,1,1,1,");
            GLOBAL.MapTxt[0].Add("1,1,1,1,1,1,1,1,5,5,5,5,5,5,3,3,1,1,1,1,5,5,2,2,1,1,");
            GLOBAL.MapTxt[0].Add("1,1,1,1,1,1,1,1,5,5,5,5,5,5,3,3,1,1,1,1,5,5,2,2,1,1,");
            GLOBAL.MapTxt[0].Add("1,1,1,1,1,1,3,3,5,5,2,2,1,1,2,2,1,1,2,2,1,1,2,2,1,1,");
            GLOBAL.MapTxt[0].Add("1,1,1,1,1,1,3,3,5,5,2,2,1,1,2,2,1,1,2,2,1,1,2,2,1,1,");
            GLOBAL.MapTxt[0].Add("3,3,2,2,1,1,3,3,1,1,2,2,1,1,2,2,1,1,1,1,1,1,2,2,1,1,");
            GLOBAL.MapTxt[0].Add("3,3,2,2,1,1,3,3,1,1,2,2,1,1,2,2,1,1,1,1,1,1,2,2,1,1,");
            GLOBAL.MapTxt[0].Add("1,1,2,2,1,1,2,2,1,1,2,2,2,2,2,2,1,1,2,2,3,3,2,2,1,1,");
            GLOBAL.MapTxt[0].Add("1,1,2,2,1,1,2,2,1,1,2,2,2,2,2,2,1,1,2,2,3,3,2,2,1,1,");
            GLOBAL.MapTxt[0].Add("1,1,2,2,1,1,2,2,1,1,2,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[0].Add("1,1,2,2,1,1,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[0].Add("1,1,2,2,1,1,1,1,1,1,2,2,2,2,2,2,1,1,2,2,1,1,2,2,1,1,");
            GLOBAL.MapTxt[0].Add("1,1,2,2,1,1,1,1,1,1,2,2,2,2,2,2,1,1,2,2,1,1,2,2,1,1,");
            GLOBAL.MapTxt[0].Add("1,1,2,2,1,1,2,2,1,1,2,2,1,1,2,2,1,1,2,2,2,2,2,2,1,1,");
            GLOBAL.MapTxt[0].Add("1,1,2,2,1,1,2,2,1,1,2,2,1,1,2,2,1,1,2,2,2,2,2,2,1,1");
            ////////////map 2
            GLOBAL.MapTxt.Add(new List<string>(0));
            GLOBAL.MapTxt[1].Add("10");
            GLOBAL.MapTxt[1].Add("6");
            GLOBAL.MapTxt[1].Add("2");
            GLOBAL.MapTxt[1].Add("2");
            GLOBAL.MapTxt[1].Add("1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[1].Add("1,1,3,3,3,3,3,1,1,1,1,2,2,2,2,1,1,1,1,3,3,3,3,3,1,1,");
            GLOBAL.MapTxt[1].Add("1,1,3,3,3,3,3,1,1,1,1,2,2,2,2,1,1,1,1,3,3,3,3,3,1,1,");
            GLOBAL.MapTxt[1].Add("5,5,5,1,1,1,2,2,2,2,2,1,1,1,1,2,2,2,2,2,1,1,1,5,5,5,");
            GLOBAL.MapTxt[1].Add("5,5,5,1,1,1,2,2,2,2,2,1,1,1,1,2,2,2,2,2,1,1,1,5,5,5,");
            GLOBAL.MapTxt[1].Add("1,1,1,1,1,1,1,1,1,1,1,4,4,4,4,1,1,1,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[1].Add("1,1,1,1,1,1,1,1,1,1,1,4,4,4,4,1,1,1,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[1].Add("2,2,2,1,1,1,1,1,1,1,5,5,5,5,5,5,1,1,1,1,1,1,2,2,2,2,");
            GLOBAL.MapTxt[1].Add("2,2,2,1,1,1,1,1,1,1,5,5,5,5,5,5,1,1,1,1,1,1,2,2,2,2,");
            GLOBAL.MapTxt[1].Add("1,4,4,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,4,4,1,");
            GLOBAL.MapTxt[1].Add("1,4,4,1,1,1,1,1,1,2,2,1,1,1,1,2,2,1,1,1,1,1,1,4,4,1,");
            GLOBAL.MapTxt[1].Add("1,4,4,1,1,1,1,1,1,3,2,1,1,1,1,2,3,1,1,1,1,1,1,4,4,1,");
            GLOBAL.MapTxt[1].Add("1,4,4,1,1,1,1,1,1,3,2,1,1,1,1,2,3,1,1,1,1,1,1,4,4,1,");
            GLOBAL.MapTxt[1].Add("1,1,1,1,1,1,1,1,1,3,2,1,1,1,1,2,3,1,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[1].Add("1,1,1,1,1,1,1,1,1,2,2,1,1,1,1,2,2,1,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[1].Add("3,3,1,1,1,4,4,5,5,1,1,1,1,1,1,1,1,5,5,4,4,1,1,1,3,3,");
            GLOBAL.MapTxt[1].Add("1,1,1,2,2,4,4,5,5,1,1,1,1,1,1,1,1,5,5,4,4,2,2,1,1,1,");
            GLOBAL.MapTxt[1].Add("1,1,1,2,2,5,5,1,1,1,1,1,2,2,1,1,1,1,1,5,5,2,2,1,1,1,");
            GLOBAL.MapTxt[1].Add("1,1,1,2,2,5,5,1,1,1,1,1,2,2,1,1,1,1,1,5,5,2,2,1,1,1,");
            GLOBAL.MapTxt[1].Add("1,1,1,2,2,5,5,1,1,1,1,1,2,2,1,1,1,1,1,5,5,2,2,1,1,1,");
            GLOBAL.MapTxt[1].Add("5,5,5,3,3,3,3,1,1,1,1,1,1,1,1,1,1,1,1,3,3,3,3,5,5,5,");
            GLOBAL.MapTxt[1].Add("5,5,5,3,3,3,3,1,1,5,5,5,5,5,5,5,5,1,1,3,3,3,3,5,5,5,");
            GLOBAL.MapTxt[1].Add("1,1,1,1,1,1,1,1,1,5,5,5,5,5,5,5,5,1,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[1].Add("1,1,1,1,1,1,1,1,1,5,5,2,2,2,2,5,5,1,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[1].Add("1,1,1,2,2,1,1,1,1,5,5,2,1,1,2,5,5,1,1,1,1,2,2,1,1,1,");
            GLOBAL.MapTxt[1].Add("1,1,1,2,2,1,1,1,1,5,5,2,1,1,2,5,5,1,1,1,1,2,2,1,1,1");

            ///////map 3
            GLOBAL.MapTxt.Add(new List<string>(0));
            GLOBAL.MapTxt[2].Add("10");
            GLOBAL.MapTxt[2].Add("6");
            GLOBAL.MapTxt[2].Add("2");
            GLOBAL.MapTxt[2].Add("2");
            GLOBAL.MapTxt[2].Add("1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[2].Add("1,1,2,2,2,2,1,1,1,1,2,2,2,2,2,1,1,1,1,2,2,2,2,1,1,1,");
            GLOBAL.MapTxt[2].Add("1,1,2,2,2,2,1,1,1,1,2,2,2,2,2,1,1,1,1,2,2,2,2,1,1,1,");
            GLOBAL.MapTxt[2].Add("1,1,5,5,3,3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3,3,5,5,1,1,");
            GLOBAL.MapTxt[2].Add("1,1,5,5,3,3,1,1,3,3,5,5,1,1,5,5,3,3,1,1,3,3,5,5,1,1,");
            GLOBAL.MapTxt[2].Add("1,1,1,1,1,2,2,2,3,3,5,5,1,1,5,5,3,3,2,2,2,1,1,1,1,1,");
            GLOBAL.MapTxt[2].Add("5,5,5,5,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,5,5,5,5,");
            GLOBAL.MapTxt[2].Add("5,5,5,5,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,5,5,5,5,");
            GLOBAL.MapTxt[2].Add("4,4,5,5,1,2,1,1,2,2,1,1,2,2,1,1,2,2,1,1,2,1,5,5,4,4,");
            GLOBAL.MapTxt[2].Add("4,4,5,5,1,2,1,1,2,2,1,1,2,2,1,1,2,2,1,1,2,1,5,5,4,4,");
            GLOBAL.MapTxt[2].Add("5,5,5,5,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,5,5,5,5,");
            GLOBAL.MapTxt[2].Add("5,5,5,5,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,5,5,5,5,");
            GLOBAL.MapTxt[2].Add("1,1,1,1,1,2,2,2,1,1,1,1,1,1,1,1,1,1,2,2,2,1,1,1,1,1,");
            GLOBAL.MapTxt[2].Add("1,1,1,1,1,1,1,1,1,1,1,5,5,5,5,1,1,1,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[2].Add("1,1,1,1,1,1,1,1,3,3,1,5,5,5,5,1,3,3,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[2].Add("1,1,1,1,1,1,1,1,3,3,1,1,1,1,1,1,3,3,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[2].Add("1,1,1,1,3,3,1,1,1,1,4,4,4,4,4,4,1,1,1,1,3,3,1,1,1,1,");
            GLOBAL.MapTxt[2].Add("1,1,1,1,3,3,1,1,1,1,4,4,4,4,4,4,1,1,1,1,3,3,1,1,1,1,");
            GLOBAL.MapTxt[2].Add("1,1,5,5,5,5,1,1,1,1,3,3,3,3,3,3,1,1,1,5,5,5,5,1,1,1,");
            GLOBAL.MapTxt[2].Add("1,1,2,2,2,2,1,1,1,1,2,2,5,5,2,2,1,1,1,2,2,2,2,1,1,1,");
            GLOBAL.MapTxt[2].Add("1,1,2,2,2,2,1,1,1,1,2,2,5,5,2,2,1,1,1,2,2,2,2,1,1,1,");
            GLOBAL.MapTxt[2].Add("1,1,1,1,1,1,1,1,5,5,5,5,5,5,5,5,5,5,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[2].Add("1,1,1,1,1,1,1,1,5,5,2,2,2,2,2,2,5,5,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[2].Add("1,1,1,1,1,1,1,1,5,5,2,2,2,2,2,2,5,5,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[2].Add("1,1,1,1,1,1,1,1,5,5,2,2,1,1,2,2,5,5,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[2].Add("1,1,1,1,1,1,1,1,5,5,2,2,1,1,2,2,5,5,1,1,1,1,1,1,1,1");

            //// map 4
            GLOBAL.MapTxt.Add(new List<string>(0));
            GLOBAL.MapTxt[3].Add("10");
            GLOBAL.MapTxt[3].Add("6");
            GLOBAL.MapTxt[3].Add("2");
            GLOBAL.MapTxt[3].Add("2");
            GLOBAL.MapTxt[3].Add("1,1,1,5,5,5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,5,5,5,1,1,1,");
            GLOBAL.MapTxt[3].Add("1,1,1,5,5,5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,5,5,5,1,1,1,");
            GLOBAL.MapTxt[3].Add("1,2,2,1,1,1,1,1,1,4,4,2,2,2,2,4,4,1,1,1,1,1,1,2,2,1,");
            GLOBAL.MapTxt[3].Add("2,2,3,1,1,1,2,2,2,4,4,2,2,2,2,4,4,2,2,2,1,1,1,3,2,2,");
            GLOBAL.MapTxt[3].Add("1,1,1,1,1,1,2,2,1,1,1,1,2,2,1,1,1,1,2,2,1,1,1,1,1,1,");
            GLOBAL.MapTxt[3].Add("1,1,1,1,1,1,2,2,1,1,1,1,2,2,1,1,1,1,2,2,1,1,1,1,1,1,");
            GLOBAL.MapTxt[3].Add("1,1,1,1,1,1,2,2,1,1,1,1,3,3,1,1,1,1,2,2,1,1,1,1,1,1,");
            GLOBAL.MapTxt[3].Add("1,1,1,3,3,1,2,2,2,1,1,1,3,3,1,1,1,2,2,2,1,3,3,1,1,1,");
            GLOBAL.MapTxt[3].Add("5,5,5,3,3,1,1,1,5,5,5,1,1,1,1,5,5,5,1,1,1,3,3,5,5,5,");
            GLOBAL.MapTxt[3].Add("2,2,2,5,1,1,1,1,5,5,5,1,1,1,1,5,5,5,1,1,1,1,5,2,2,2,");
            GLOBAL.MapTxt[3].Add("5,2,2,5,1,1,1,1,1,1,1,1,2,2,1,1,1,1,1,1,1,1,5,2,2,5,");
            GLOBAL.MapTxt[3].Add("5,2,2,5,1,1,1,1,1,1,1,2,2,2,2,1,1,1,1,1,1,1,5,2,2,5,");
            GLOBAL.MapTxt[3].Add("5,2,2,5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,5,2,2,5,");
            GLOBAL.MapTxt[3].Add("2,2,2,5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,5,2,2,2,");
            GLOBAL.MapTxt[3].Add("5,5,5,3,3,1,1,1,1,1,1,5,5,5,5,5,1,1,1,1,1,3,3,5,5,5,");
            GLOBAL.MapTxt[3].Add("1,1,1,3,3,1,1,1,1,1,1,5,5,5,5,5,1,1,1,1,1,3,3,1,1,1,");
            GLOBAL.MapTxt[3].Add("1,1,1,1,1,1,1,1,2,2,2,4,4,4,4,4,2,2,2,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[3].Add("1,3,3,3,1,1,1,1,2,2,2,4,4,4,4,4,2,2,2,1,1,1,3,3,3,1,");
            GLOBAL.MapTxt[3].Add("3,3,1,1,1,1,1,1,2,2,2,4,4,4,4,4,2,2,2,1,1,1,1,1,3,3,");
            GLOBAL.MapTxt[3].Add("1,1,1,1,1,1,1,1,1,1,1,5,5,5,5,5,1,1,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[3].Add("1,2,2,1,2,2,1,1,1,1,1,5,5,5,5,5,1,1,1,1,2,2,1,2,2,1,");
            GLOBAL.MapTxt[3].Add("2,2,1,1,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,1,1,2,2,");
            GLOBAL.MapTxt[3].Add("1,1,1,1,2,2,1,1,1,2,2,2,2,2,2,2,2,1,1,1,2,2,1,1,1,1,");
            GLOBAL.MapTxt[3].Add("5,5,1,1,2,2,1,1,1,5,4,2,2,2,2,5,4,1,1,1,2,2,1,1,5,5,");
            GLOBAL.MapTxt[3].Add("5,5,1,1,2,2,1,1,1,5,4,2,1,1,2,5,4,1,1,1,2,2,1,1,5,5,");
            GLOBAL.MapTxt[3].Add("5,5,1,1,2,2,1,1,1,5,4,2,1,1,2,5,1,1,1,1,2,2,1,1,5,5");

            //// map 5
            GLOBAL.MapTxt.Add(new List<string>(0));
            GLOBAL.MapTxt[4].Add("10");
            GLOBAL.MapTxt[4].Add("6");
            GLOBAL.MapTxt[4].Add("2");
            GLOBAL.MapTxt[4].Add("2");
            GLOBAL.MapTxt[4].Add("1,1,1,5,5,1,1,3,1,1,1,1,1,1,1,1,1,1,3,1,1,5,5,1,1,1,");
            GLOBAL.MapTxt[4].Add("1,1,1,5,5,1,3,3,1,1,1,1,1,1,1,1,1,1,3,3,1,5,5,1,1,1,");
            GLOBAL.MapTxt[4].Add("2,2,2,2,2,5,5,1,1,1,1,2,1,1,2,1,1,1,1,5,5,2,2,2,2,2,");
            GLOBAL.MapTxt[4].Add("2,2,2,2,2,5,5,1,1,1,1,2,2,2,2,1,1,1,1,5,5,2,2,2,2,2,");
            GLOBAL.MapTxt[4].Add("1,1,1,1,1,1,1,1,1,3,3,1,1,1,1,3,3,1,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[4].Add("1,1,1,1,1,1,1,1,1,3,3,1,1,1,1,3,3,1,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[4].Add("1,1,1,1,1,1,1,1,2,4,4,2,1,1,2,4,4,2,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[4].Add("5,5,1,1,1,1,1,1,2,2,2,2,1,1,2,2,2,2,1,1,1,1,1,1,5,5,");
            GLOBAL.MapTxt[4].Add("4,5,1,1,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,5,4,");
            GLOBAL.MapTxt[4].Add("4,5,1,1,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,1,1,5,4,");
            GLOBAL.MapTxt[4].Add("5,5,1,1,2,1,1,1,1,1,1,1,5,5,1,1,1,1,1,1,1,2,1,1,5,5,");
            GLOBAL.MapTxt[4].Add("1,1,1,1,1,1,1,1,1,1,1,1,5,5,1,1,1,1,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[4].Add("1,1,1,1,1,1,1,1,2,2,2,2,5,5,2,2,2,2,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[4].Add("1,1,1,1,1,1,1,1,2,1,1,2,5,5,2,1,1,2,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[4].Add("1,1,1,3,3,3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3,3,3,1,1,1,");
            GLOBAL.MapTxt[4].Add("1,1,1,3,3,3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3,3,3,1,1,1,");
            GLOBAL.MapTxt[4].Add("2,1,1,1,1,5,5,5,5,1,1,2,2,2,2,1,1,5,5,5,5,1,1,1,1,2,");
            GLOBAL.MapTxt[4].Add("2,1,1,1,1,5,5,5,5,1,1,2,1,1,2,1,1,5,5,5,5,1,1,1,1,2,");
            GLOBAL.MapTxt[4].Add("2,1,1,1,1,4,4,5,2,2,1,1,1,1,1,1,2,2,5,4,4,1,1,1,1,2,");
            GLOBAL.MapTxt[4].Add("2,1,1,1,1,4,4,5,2,2,1,1,1,1,1,1,2,2,5,4,4,1,1,1,1,2,");
            GLOBAL.MapTxt[4].Add("1,3,3,1,1,1,1,5,5,5,5,1,1,1,1,5,5,5,5,1,1,1,1,3,3,1,");
            GLOBAL.MapTxt[4].Add("1,3,3,1,1,1,1,5,5,5,5,3,3,3,3,5,5,5,5,1,1,1,1,3,3,1,");
            GLOBAL.MapTxt[4].Add("1,3,3,1,1,1,1,1,1,1,2,2,2,2,2,2,1,1,1,1,1,1,1,3,3,1,");
            GLOBAL.MapTxt[4].Add("1,3,3,1,2,2,1,1,1,1,2,2,2,2,2,2,1,1,1,1,2,2,1,3,3,1,");
            GLOBAL.MapTxt[4].Add("1,1,1,1,1,2,2,1,1,1,2,2,1,1,2,2,1,1,1,2,2,1,1,1,1,1,");
            GLOBAL.MapTxt[4].Add("5,5,5,5,5,5,5,5,5,5,2,2,1,1,2,2,5,5,5,5,5,5,5,5,5,5");


            //// map 6
            GLOBAL.MapTxt.Add(new List<string>(0));
            GLOBAL.MapTxt[5].Add("10");
            GLOBAL.MapTxt[5].Add("6");
            GLOBAL.MapTxt[5].Add("2");
            GLOBAL.MapTxt[5].Add("2");
            GLOBAL.MapTxt[5].Add("1,1,1,1,3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3,1,1,1,1,");
            GLOBAL.MapTxt[5].Add("2,1,1,1,1,3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3,1,1,1,1,2,");
            GLOBAL.MapTxt[5].Add("2,1,1,1,1,1,1,1,1,1,1,1,2,2,1,1,1,1,1,1,1,1,1,1,1,2,");
            GLOBAL.MapTxt[5].Add("2,2,5,5,4,4,4,4,5,5,1,1,2,2,1,1,5,5,4,4,4,4,5,5,2,2,");
            GLOBAL.MapTxt[5].Add("1,2,5,5,4,2,2,4,5,5,1,1,2,2,1,1,5,5,4,2,2,4,5,5,2,1,");
            GLOBAL.MapTxt[5].Add("1,2,1,1,2,2,2,2,1,2,2,2,2,2,2,2,2,1,2,2,2,2,1,1,2,1,");
            GLOBAL.MapTxt[5].Add("3,3,1,1,1,1,1,1,1,2,3,3,3,3,3,3,2,1,1,1,1,1,1,1,3,3,");
            GLOBAL.MapTxt[5].Add("3,3,1,1,1,1,1,1,1,2,1,1,3,3,1,1,2,1,1,1,1,1,1,1,3,3,");
            GLOBAL.MapTxt[5].Add("1,1,1,1,1,1,1,1,1,1,1,1,3,3,1,1,1,1,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[5].Add("2,2,2,2,5,5,5,1,1,1,1,1,1,1,1,1,1,1,1,5,5,5,2,2,2,2,");
            GLOBAL.MapTxt[5].Add("1,1,1,2,5,5,5,1,1,1,1,4,4,4,4,1,1,1,1,5,5,5,2,1,1,1,");
            GLOBAL.MapTxt[5].Add("1,1,1,2,2,2,2,1,1,1,1,4,4,4,4,1,1,1,1,2,2,2,2,1,1,1,");
            GLOBAL.MapTxt[5].Add("1,1,1,1,1,1,1,2,2,5,5,5,5,5,5,5,5,2,2,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[5].Add("1,1,1,1,1,1,1,2,2,5,5,5,5,5,5,5,5,2,2,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[5].Add("3,3,3,3,3,3,3,1,1,1,1,1,1,1,1,1,1,1,1,3,3,3,3,3,3,3,");
            GLOBAL.MapTxt[5].Add("3,3,2,2,3,3,3,1,1,1,1,3,1,1,3,1,1,1,1,3,3,3,2,2,3,3,");
            GLOBAL.MapTxt[5].Add("1,1,2,2,1,1,1,1,1,1,1,1,2,2,1,1,1,1,1,1,1,1,2,2,1,1,");
            GLOBAL.MapTxt[5].Add("5,5,1,1,1,1,1,2,2,2,1,1,2,2,1,1,2,2,2,1,1,1,1,1,5,5,");
            GLOBAL.MapTxt[5].Add("5,5,5,1,1,1,1,1,2,2,1,1,2,2,1,1,2,2,1,1,1,1,1,5,5,5,");
            GLOBAL.MapTxt[5].Add("1,1,5,1,1,1,1,2,2,2,1,3,1,1,3,1,2,2,2,1,1,1,1,5,1,1,");
            GLOBAL.MapTxt[5].Add("1,2,5,3,3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3,3,5,2,1,");
            GLOBAL.MapTxt[5].Add("1,2,5,3,3,1,1,1,1,1,1,1,2,2,1,1,1,1,1,1,1,3,3,5,2,1,");
            GLOBAL.MapTxt[5].Add("2,2,1,1,1,1,5,5,5,3,2,2,2,2,2,2,3,5,5,5,1,1,1,1,2,2,");
            GLOBAL.MapTxt[5].Add("2,1,1,1,1,1,5,5,5,3,2,2,2,2,2,2,3,5,5,5,1,1,1,1,1,2,");
            GLOBAL.MapTxt[5].Add("2,1,1,5,5,5,5,4,4,4,2,2,1,1,2,2,1,1,4,5,5,5,1,1,1,2,");
            GLOBAL.MapTxt[5].Add("1,1,1,5,5,5,5,4,4,4,2,2,1,1,2,2,1,1,4,5,5,5,1,1,1,1");

            //// map 7
            GLOBAL.MapTxt.Add(new List<string>(0));
            GLOBAL.MapTxt[6].Add("10");
            GLOBAL.MapTxt[6].Add("6");
            GLOBAL.MapTxt[6].Add("2");
            GLOBAL.MapTxt[6].Add("2");
            GLOBAL.MapTxt[6].Add("1,1,1,3,3,3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[6].Add("1,1,1,5,5,5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,5,5,5,1,1,1,");
            GLOBAL.MapTxt[6].Add("1,1,1,1,2,2,1,3,1,2,2,1,1,3,1,1,2,2,1,3,5,2,2,1,1,1,");
            GLOBAL.MapTxt[6].Add("1,1,1,1,2,2,1,3,1,2,2,1,1,3,1,1,2,2,1,3,5,2,2,1,1,1,");
            GLOBAL.MapTxt[6].Add("5,5,5,1,2,2,3,3,3,2,2,1,3,3,3,1,2,2,3,3,3,2,2,5,5,5,");
            GLOBAL.MapTxt[6].Add("5,5,5,1,1,1,1,1,1,3,1,1,1,2,1,1,3,1,1,1,1,1,1,5,5,5,");
            GLOBAL.MapTxt[6].Add("2,5,5,1,1,1,1,3,3,3,1,4,4,2,1,1,3,3,3,1,1,1,1,5,5,2,");
            GLOBAL.MapTxt[6].Add("2,5,5,1,1,2,2,2,2,3,1,4,4,2,1,1,3,2,2,2,2,1,1,5,5,2,");
            GLOBAL.MapTxt[6].Add("2,5,5,1,1,2,1,1,1,4,4,5,5,2,1,1,1,1,1,1,2,1,1,5,5,2,");
            GLOBAL.MapTxt[6].Add("2,5,5,1,1,1,1,1,1,4,4,5,5,2,1,1,1,1,1,1,1,1,1,5,5,2,");
            GLOBAL.MapTxt[6].Add("2,5,5,2,1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,1,1,2,1,5,5,2,");
            GLOBAL.MapTxt[6].Add("2,5,5,2,2,1,3,3,1,1,1,3,3,2,5,5,1,1,1,1,1,2,2,5,5,2,");
            GLOBAL.MapTxt[6].Add("2,5,5,2,2,1,3,3,1,1,1,1,3,2,5,5,1,1,1,1,1,2,2,5,5,2,");
            GLOBAL.MapTxt[6].Add("2,5,5,2,2,1,1,2,2,2,2,1,1,2,5,5,2,2,2,2,1,2,2,5,5,2,");
            GLOBAL.MapTxt[6].Add("5,5,5,4,4,1,1,2,1,1,2,5,5,2,1,1,2,1,1,2,1,4,4,5,5,5,");
            GLOBAL.MapTxt[6].Add("5,5,5,4,4,1,1,1,1,1,1,5,5,2,1,1,1,1,1,1,1,4,4,5,5,5,");
            GLOBAL.MapTxt[6].Add("2,2,2,1,1,1,1,1,1,2,2,5,5,2,1,1,2,2,1,1,1,1,1,2,2,2,");
            GLOBAL.MapTxt[6].Add("1,2,1,1,1,3,3,3,1,1,2,2,1,1,1,2,2,1,3,3,3,1,1,1,2,1,");
            GLOBAL.MapTxt[6].Add("1,1,5,5,5,3,3,3,1,1,1,1,1,1,1,1,1,1,3,3,3,5,5,5,1,1,");
            GLOBAL.MapTxt[6].Add("2,1,1,5,1,3,1,3,1,1,1,1,2,2,1,1,1,1,3,1,3,1,5,1,1,2,");
            GLOBAL.MapTxt[6].Add("2,1,5,5,5,3,1,3,1,2,2,1,2,2,1,2,2,1,3,1,3,5,5,5,1,2,");
            GLOBAL.MapTxt[6].Add("2,2,1,1,1,1,1,1,1,2,3,4,4,4,4,3,2,1,1,1,1,1,1,1,2,2,");
            GLOBAL.MapTxt[6].Add("4,2,1,1,2,2,2,1,3,1,4,4,4,4,4,4,1,3,1,2,2,2,1,1,2,4,");
            GLOBAL.MapTxt[6].Add("4,2,2,1,1,2,1,1,1,5,2,2,2,2,2,2,5,1,1,1,2,1,1,2,2,4,");
            GLOBAL.MapTxt[6].Add("4,4,2,1,3,3,3,1,5,5,2,2,1,1,2,2,5,5,1,3,3,3,1,2,4,4,");
            GLOBAL.MapTxt[6].Add("4,4,2,1,3,1,3,5,5,5,2,2,1,1,2,2,5,5,5,3,1,3,1,2,4,4");

            //// map 8
            GLOBAL.MapTxt.Add(new List<string>(0));
            GLOBAL.MapTxt[7].Add("10");
            GLOBAL.MapTxt[7].Add("6");
            GLOBAL.MapTxt[7].Add("2");
            GLOBAL.MapTxt[7].Add("2");
            GLOBAL.MapTxt[7].Add("1,1,5,5,1,1,1,1,1,3,3,3,1,1,1,1,1,1,5,5,1,2,2,2,1,1,");
            GLOBAL.MapTxt[7].Add("1,1,5,5,1,2,1,1,1,3,1,3,1,1,1,1,1,1,5,5,1,1,1,1,1,1,");
            GLOBAL.MapTxt[7].Add("1,1,1,1,2,2,2,1,1,1,1,2,2,2,1,1,1,2,1,2,2,2,1,2,1,1,");
            GLOBAL.MapTxt[7].Add("3,3,1,1,1,2,1,1,1,1,1,1,1,1,1,5,5,2,2,2,3,2,2,2,1,1,");
            GLOBAL.MapTxt[7].Add("3,2,2,1,1,1,4,4,3,3,3,3,3,1,1,5,5,1,3,3,3,3,3,1,4,4,");
            GLOBAL.MapTxt[7].Add("3,2,2,1,1,1,4,4,2,2,2,2,2,5,5,5,5,1,1,1,1,1,1,1,4,4,");
            GLOBAL.MapTxt[7].Add("3,3,1,1,1,1,1,1,2,1,1,1,1,5,5,5,5,1,1,2,1,2,1,4,4,2,");
            GLOBAL.MapTxt[7].Add("5,5,5,5,3,3,1,1,1,1,1,2,1,5,5,1,1,1,1,2,1,2,1,4,4,2,");
            GLOBAL.MapTxt[7].Add("5,5,5,5,3,3,1,1,1,2,1,2,1,5,5,1,1,5,2,2,1,2,2,1,1,2,");
            GLOBAL.MapTxt[7].Add("1,1,3,3,1,1,1,1,1,2,1,2,1,1,1,1,1,5,2,1,1,1,2,1,1,2,");
            GLOBAL.MapTxt[7].Add("1,1,3,3,1,1,1,1,1,2,1,1,1,1,1,1,1,5,2,2,1,2,2,1,1,2,");
            GLOBAL.MapTxt[7].Add("2,2,3,3,1,2,1,2,1,1,1,2,2,1,2,2,1,1,1,2,1,2,1,1,1,2,");
            GLOBAL.MapTxt[7].Add("1,1,3,3,1,2,1,2,1,5,5,2,2,1,2,2,1,1,1,2,1,2,1,3,3,2,");
            GLOBAL.MapTxt[7].Add("4,4,3,3,2,2,1,2,2,5,5,2,2,1,2,2,1,1,1,1,1,1,1,3,3,2,");
            GLOBAL.MapTxt[7].Add("4,4,3,3,2,1,1,1,2,5,5,2,2,1,2,2,1,1,1,1,1,1,1,3,2,2,");
            GLOBAL.MapTxt[7].Add("4,4,1,1,2,2,1,2,2,5,5,2,2,1,2,2,1,1,3,1,1,2,1,3,2,2,");
            GLOBAL.MapTxt[7].Add("4,4,1,1,1,2,1,2,1,2,1,1,1,5,5,5,5,3,3,3,1,2,1,3,5,5,");
            GLOBAL.MapTxt[7].Add("4,4,1,1,1,2,1,2,1,2,1,1,3,5,5,5,5,1,3,1,1,2,1,3,5,5,");
            GLOBAL.MapTxt[7].Add("4,4,1,1,1,1,3,1,1,2,1,3,3,3,1,1,2,1,1,1,1,2,1,3,5,5,");
            GLOBAL.MapTxt[7].Add("5,5,1,3,3,3,3,1,2,2,1,3,1,3,1,1,2,1,2,1,1,2,1,3,5,5,");
            GLOBAL.MapTxt[7].Add("5,5,1,3,3,3,3,1,2,2,1,1,1,1,1,1,2,1,2,1,1,1,1,3,5,5,");
            GLOBAL.MapTxt[7].Add("4,4,1,1,2,1,1,1,2,1,1,1,1,1,1,1,1,1,2,1,2,1,1,1,1,2,");
            GLOBAL.MapTxt[7].Add("4,4,1,2,2,2,1,1,2,1,4,4,3,3,4,4,1,1,1,2,2,2,1,2,2,2,");
            GLOBAL.MapTxt[7].Add("4,4,1,1,2,1,1,1,2,5,4,2,2,2,2,4,5,1,1,1,2,1,1,2,4,4,");
            GLOBAL.MapTxt[7].Add("4,4,1,1,3,3,1,1,5,5,5,2,1,1,2,1,5,5,1,1,3,3,1,5,4,4,");
            GLOBAL.MapTxt[7].Add("4,4,1,1,3,3,1,1,5,2,5,2,1,1,2,1,1,5,1,1,3,3,1,5,4,4");

            //// map 9
            GLOBAL.MapTxt.Add(new List<string>(0));
            GLOBAL.MapTxt[8].Add("10");
            GLOBAL.MapTxt[8].Add("6");
            GLOBAL.MapTxt[8].Add("2");
            GLOBAL.MapTxt[8].Add("2");
            GLOBAL.MapTxt[8].Add("1,1,1,1,3,3,3,1,1,1,1,5,5,1,1,1,5,5,1,1,4,4,4,1,1,1,");
            GLOBAL.MapTxt[8].Add("1,1,1,1,3,3,3,1,1,3,3,5,3,3,1,1,5,5,1,1,4,4,4,1,1,1,");
            GLOBAL.MapTxt[8].Add("2,2,4,4,1,3,1,1,1,3,4,5,5,3,1,1,2,1,5,5,3,4,3,1,2,2,");
            GLOBAL.MapTxt[8].Add("5,2,4,4,1,1,5,5,3,3,4,4,2,3,3,2,2,2,5,5,3,3,3,1,2,5,");
            GLOBAL.MapTxt[8].Add("5,2,1,1,1,1,5,5,1,1,5,5,2,5,5,1,2,1,5,5,1,1,1,1,2,5,");
            GLOBAL.MapTxt[8].Add("5,2,1,1,2,1,1,1,1,1,5,5,2,5,5,5,5,5,1,1,1,2,1,1,2,5,");
            GLOBAL.MapTxt[8].Add("4,4,3,1,2,1,1,3,3,2,2,2,2,2,2,2,3,3,1,1,1,2,3,5,4,4,");
            GLOBAL.MapTxt[8].Add("4,4,3,1,2,2,1,3,3,1,1,1,2,1,1,1,3,3,1,1,2,2,3,5,4,4,");
            GLOBAL.MapTxt[8].Add("4,4,3,1,2,2,1,3,3,1,2,1,2,1,1,1,3,3,1,1,2,2,3,5,4,4,");
            GLOBAL.MapTxt[8].Add("4,4,3,1,2,2,1,1,1,1,1,1,2,1,1,1,1,1,1,1,2,1,3,5,4,4,");
            GLOBAL.MapTxt[8].Add("4,4,3,1,1,2,1,1,1,2,4,4,4,4,4,2,1,3,1,1,2,1,3,5,4,4,");
            GLOBAL.MapTxt[8].Add("4,4,3,1,1,1,1,1,2,2,4,4,4,4,4,2,2,3,3,3,1,1,3,5,4,4,");
            GLOBAL.MapTxt[8].Add("2,5,1,2,1,1,2,1,2,2,1,2,1,2,1,2,2,1,1,3,3,1,2,1,3,2,");
            GLOBAL.MapTxt[8].Add("2,5,1,2,1,1,2,1,1,2,1,2,1,2,1,2,1,1,1,2,2,1,2,1,3,2,");
            GLOBAL.MapTxt[8].Add("2,5,2,2,1,3,2,3,1,5,5,2,2,2,1,5,5,1,3,2,3,1,2,2,3,2,");
            GLOBAL.MapTxt[8].Add("2,5,2,1,1,3,2,3,5,5,5,2,2,2,1,5,5,1,3,2,3,1,1,2,3,2,");
            GLOBAL.MapTxt[8].Add("2,5,2,2,1,3,3,3,5,5,1,2,4,2,5,5,5,5,3,3,3,1,2,2,3,2,");
            GLOBAL.MapTxt[8].Add("2,5,1,2,1,1,2,1,1,1,1,2,4,2,1,1,1,1,1,1,1,1,2,1,3,2,");
            GLOBAL.MapTxt[8].Add("2,5,1,2,3,1,2,1,1,2,4,4,4,4,4,2,2,1,2,1,1,1,2,1,3,2,");
            GLOBAL.MapTxt[8].Add("1,1,1,1,3,1,1,1,2,1,2,2,4,2,2,2,1,1,3,2,1,1,1,2,5,5,");
            GLOBAL.MapTxt[8].Add("1,1,1,3,3,3,1,2,3,1,3,5,5,1,1,5,5,3,3,3,2,1,2,2,2,5,");
            GLOBAL.MapTxt[8].Add("2,5,5,2,3,1,2,1,3,3,3,5,5,3,3,5,5,1,3,1,1,2,1,2,5,5,");
            GLOBAL.MapTxt[8].Add("2,5,5,2,3,2,1,1,1,5,5,2,2,2,2,2,2,5,5,1,1,1,2,1,2,2,");
            GLOBAL.MapTxt[8].Add("2,2,2,2,1,1,5,2,2,5,5,3,4,4,4,4,3,5,5,2,3,1,1,2,2,2,");
            GLOBAL.MapTxt[8].Add("3,3,1,3,3,3,5,2,2,5,5,3,4,1,1,4,3,5,5,2,3,3,1,2,3,3,");
            GLOBAL.MapTxt[8].Add("3,3,1,1,3,5,5,2,2,5,5,3,4,1,1,4,1,5,5,2,2,3,1,2,3,3");

            //// map 10
            GLOBAL.MapTxt.Add(new List<string>(0));
            GLOBAL.MapTxt[9].Add("10");
            GLOBAL.MapTxt[9].Add("6");
            GLOBAL.MapTxt[9].Add("2");
            GLOBAL.MapTxt[9].Add("2");
            GLOBAL.MapTxt[9].Add("1,1,1,1,3,1,1,1,1,1,5,5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[9].Add("1,1,1,3,3,3,1,1,1,1,5,5,1,1,1,1,2,1,1,1,1,1,5,5,3,3,");
            GLOBAL.MapTxt[9].Add("1,1,1,2,3,2,1,2,2,1,5,5,1,1,3,3,2,2,2,2,5,5,5,5,3,3,");
            GLOBAL.MapTxt[9].Add("1,1,1,2,3,2,1,5,2,2,5,5,1,2,3,3,2,4,4,4,5,5,2,3,3,3,");
            GLOBAL.MapTxt[9].Add("3,3,1,5,5,5,1,5,5,5,5,5,1,2,2,4,4,4,1,1,2,2,2,3,3,3,");
            GLOBAL.MapTxt[9].Add("4,3,1,2,5,2,1,1,1,1,2,2,2,2,2,1,1,1,1,1,1,1,1,2,2,2,");
            GLOBAL.MapTxt[9].Add("4,3,1,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,");
            GLOBAL.MapTxt[9].Add("3,3,1,5,5,5,1,3,1,1,1,1,1,1,1,3,3,3,3,3,1,1,5,5,5,2,");
            GLOBAL.MapTxt[9].Add("1,1,1,1,1,1,1,3,5,5,2,1,1,1,2,3,3,3,3,3,1,1,5,5,5,2,");
            GLOBAL.MapTxt[9].Add("1,1,1,1,1,1,3,3,3,5,2,2,1,2,2,3,3,1,1,1,1,2,3,5,3,2,");
            GLOBAL.MapTxt[9].Add("2,2,2,1,5,5,5,3,1,1,2,2,2,2,2,3,3,1,1,1,1,2,3,5,3,2,");
            GLOBAL.MapTxt[9].Add("1,2,2,2,5,5,5,3,1,1,1,1,1,1,1,1,1,2,2,1,1,2,4,4,4,4,");
            GLOBAL.MapTxt[9].Add("5,5,5,5,5,2,2,2,1,1,2,5,5,2,1,1,1,2,2,3,1,2,4,4,4,4,");
            GLOBAL.MapTxt[9].Add("5,5,5,5,5,1,2,2,2,1,2,2,2,2,1,1,1,2,4,3,2,2,2,1,1,1,");
            GLOBAL.MapTxt[9].Add("4,4,1,1,1,1,1,1,1,1,3,3,3,3,1,2,2,2,4,3,3,3,3,1,1,1,");
            GLOBAL.MapTxt[9].Add("4,4,1,1,1,1,1,1,1,1,3,2,2,3,1,1,1,2,4,5,5,5,5,1,2,2,");
            GLOBAL.MapTxt[9].Add("4,4,2,3,1,5,5,1,1,3,3,2,2,3,3,1,1,2,2,5,5,5,5,1,2,5,");
            GLOBAL.MapTxt[9].Add("2,2,2,3,1,5,5,1,2,2,2,5,5,2,2,2,3,2,2,5,5,4,4,1,2,5,");
            GLOBAL.MapTxt[9].Add("2,3,3,3,1,5,5,1,2,1,2,5,5,2,1,2,3,1,1,2,2,4,4,1,2,2,");
            GLOBAL.MapTxt[9].Add("2,3,3,3,2,2,1,1,1,1,1,1,1,1,1,3,3,3,1,2,2,3,3,1,1,1,");
            GLOBAL.MapTxt[9].Add("5,5,4,4,4,2,1,1,1,1,5,5,5,5,5,5,3,2,2,1,1,3,3,3,3,3,");
            GLOBAL.MapTxt[9].Add("5,5,2,2,2,2,1,1,1,1,5,3,3,3,3,5,1,2,2,1,1,3,3,3,3,3,");
            GLOBAL.MapTxt[9].Add("3,3,3,3,3,1,1,1,1,1,5,3,2,2,3,5,1,1,1,1,1,1,1,1,1,1,");
            GLOBAL.MapTxt[9].Add("3,3,1,1,1,2,2,1,1,1,5,2,2,2,2,5,1,1,1,2,2,3,3,2,2,2,");
            GLOBAL.MapTxt[9].Add("3,3,1,1,1,1,2,1,5,5,5,2,1,1,2,5,5,5,1,2,4,4,4,5,5,2,");
            GLOBAL.MapTxt[9].Add("3,3,1,1,1,1,2,2,5,5,5,2,1,1,2,5,5,5,2,2,4,4,4,5,5,2");



            #endregion

           

            #region SelectMap
            GLOBAL.SelectMapMenuBG = Content.Load<Texture2D>(@"GameMenu/SelectMapMenuBG");
            GLOBAL.BtnMapDown = Content.Load<Texture2D>(@"GameMenu/BtnMapDown");
            GLOBAL.BtnMapUp = Content.Load<Texture2D>(@"GameMenu/BtnMapUp");
            GLOBAL.BtnMapLock = Content.Load<Texture2D>(@"GameMenu/BtnMapLock");
            _SelectMapMenu = new SelectMapMenu(this);
            this.Components.Add(_SelectMapMenu);

            #endregion
        

            

            base.LoadContent();

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            this.Content.Unload();
            base.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        ///
       
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (!this.IsActive)
            {

                //this.EndDraw();
                this.EndRun();
                //MediaPlayer.Stop();
                return;
            }
            

            //if (MediaPlayer.State == MediaState.Stopped)
            //{
            //    MediaPlayer.Play(GLOBAL.nhacnenGame);
            //}
            if (menu.btn_click == true)
            {
               if (menu.selectedButton==0)
                    GLOBAL.gType = GameType.selectmap;
               if (menu.selectedButton == 1)
               {

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
               if (menu.selectedButton == 3)
               {
                   
                   this.Exit();

               }
               if (menu.selectedButton == 2)
               {
                   if (menu.IsAbout == false)
                   {
                       menu.IsAbout = true;                     
                       menu.cong = 0;
                   }

                   else
                   {
                       menu.IsAbout = false;
      

                   }

               }
                
                menu.btn_click = false;
                GLOBAL.GameOver = false;
                
            }
            if (_SelectMapMenu.btn_click == true)
            {

                GLOBAL.gType = GameType.Level1;
                _SelectMapMenu.btn_click = true;
                GLOBAL.XeLivePoint = GLOBAL.gamedata.livepoint[_SelectMapMenu.selectedButton];
                this.Components.Remove(lvl);              
                lvl = new GamePlay(this, _SelectMapMenu.selectedButton+1);
                this.Components.Add(lvl);
                _SelectMapMenu.btn_click = false;
                


            }
            if (gameover.btn_Replay_click == true)
            {
                GLOBAL.LoadGame();
                GLOBAL.gType = GameType.Level1;
                gameover.btn_Replay_click = false;
                gameover.Enabled = false;
                gameover.Visible = false;
                this.Components.Remove(lvl);
                lvl = new GamePlay(this,lvl.Level);
                if (lvl.Level == 1) GLOBAL.XeLivePoint = 3;
                else if (GLOBAL.gamedata.livepoint.Count >= lvl.Level)
                    GLOBAL.XeLivePoint = GLOBAL.gamedata.livepoint[lvl.Level - 1];
                else if (GLOBAL.gamedata.livepoint.Count < lvl.Level)
                    GLOBAL.XeLivePoint = GLOBAL.gamedata.livepoint[lvl.Level - 2];
                for (int i = 1; i <= 4; i++)
                    GLOBAL.xe.NumEnermyDestroy[i] = 0;
                this.Components.Add(lvl);
                GLOBAL.GameOver = false;
                
            }
            if (gameover.btn_back_click == true)
            {
                GLOBAL.gType = GameType.selectmap;
                GLOBAL.GameOver = false;
                gameover.btn_back_click = false;
            }
            switch (GLOBAL.gType)
            {
                case GameType.gamenu:
                    {
                        
                        MediaPlayer.MediaStateChanged += new EventHandler<EventArgs>(MediaPlayer_MediaStateChanged);
                        lvl.Visible = false;
                        lvl.Enabled = false;
                        //co = 0;
                        _SelectMapMenu.Visible = false;
                        _SelectMapMenu.Enabled = false;

                        menu.Enabled = true;
                        menu.Visible = true;
                        break;
                    }
                case GameType.selectmap:
                    {
                        MediaPlayer.MediaStateChanged += new EventHandler<EventArgs>(MediaPlayer_MediaStateChanged);
                
                        menu.Enabled = false;
                        menu.Visible = false;

                        //lvl.Visible = false;
                        //lvl.Enabled = false;
                        //co = 0;

                        gameover.Enabled = false;
                        gameover.Visible = false;
                        _SelectMapMenu.Enabled = true;
                        _SelectMapMenu.Visible = true;
                       
                        break;
                    }
                case GameType.Level1:
                    {
                       
                        //this.UnloadContent();
                        menu.Visible = false;
                        menu.Enabled = false;
                        _SelectMapMenu.Enabled = false;
                        _SelectMapMenu.Visible = false;
                        if (GLOBAL.GameOver == false)
                        {
                            lvl.Enabled = true;
                            lvl.Visible = true;
                        }
                        else
                        {
                            lvl.Enabled = false;
                            lvl.Visible = false;
                            gameover.Enabled = true;
                            gameover.Visible = true;
                        }
                        if (GLOBAL.Win == true)
                        {
                            GLOBAL.XeLivePoint=GLOBAL.xe.livepoint;
                            GLOBAL.xeSave = GLOBAL.xe;
                            this.Components.Remove(lvl);
                            if (lvl.Level + 1 <= GLOBAL.MapTxt.Count)
                            {
                                lvl = new GamePlay(this, lvl.Level + 1);
                            }
                            else
                                lvl = new GamePlay(this,1);
                            this.Components.Add(lvl);
                            GLOBAL.Win = false;
                            GLOBAL.SaveGame();
                            GLOBAL.xe = GLOBAL.xeSave;
                            GLOBAL.xe.bound = new Rectangle(26 * 16, 26 * 25, 26, 26);
                        }

                        break;
                    }
            }
            // TODO: Add your update logic here
            for (int i = 0; i < GLOBAL.Bullet.Count; i++)
                GLOBAL.Bullet[i].update(gameTime);

    
            base.Update(gameTime);
        }
        void MediaPlayer_MediaStateChanged(object sender, EventArgs e)
        {
            if ((MediaPlayer.State == MediaState.Stopped)&&(GLOBAL.gType!=GameType.Level1))
            {
                MediaPlayer.Play(GLOBAL.nhacnenGame);
            }

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