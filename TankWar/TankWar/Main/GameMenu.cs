using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankWar
{
    class GameMenu : Microsoft.Xna.Framework.DrawableGameComponent
    {
        #region Cấu trúc
        SpriteBatch spritebatch;
        int _delay = 0;

        #region Menutable
        GameButton _menutable;
        GameButton _btnplay;
        GameButton _btnLoad;
        GameButton _btnOption;
        GameButton _btnScore;
        GameButton _btnExit;
        List<GameButton> listButton = new List<GameButton>();
        public bool NewGameClick = false;
        #endregion

        GameButton _Title;

        int selectedButton = 0;
        //int co = 0;
        //nhac nen

        #endregion

        #region Hàm

        public GameMenu(Game game)
            : base(game)
        {
           

        }
        public override void Initialize()
        {
            spritebatch = new SpriteBatch(this.Game.GraphicsDevice);
            
            base.Initialize();
        }
        protected override void UnloadContent()
        {
            base.UnloadContent();
        }
        protected override void LoadContent()
        {
            _menutable = new GameButton(GLOBAL.Menutabletexture, GLOBAL.Menutabletexture,
                this.Game.GraphicsDevice.PresentationParameters.BackBufferWidth -
                GLOBAL.Menutabletexture.Width, -106);
            //menutableSound.Play();
            _btnplay = new GameButton(GLOBAL.Playtexture, GLOBAL.Playtexture2, 
                _menutable.Model.Position.X + 63, _menutable.Model.Position.Y + 160);
            _btnLoad = new GameButton(GLOBAL.Loadtexture, GLOBAL.Loadtexture2, _menutable.Model.Position.X + 63,
                _menutable.Model.Position.Y + 238);
            //_btnOption = new GameButton(GLOBAL.Opotiontexture, GLOBAL.Opotiontexture2, 
            //    _menutable.Model.Position.X + 63, _menutable.Model.Position.Y + 309);
            _btnScore = new GameButton(GLOBAL.Scoretexture, GLOBAL.Scoretexture2, 
                _menutable.Model.Position.X + 63, _menutable.Model.Position.Y + 387);
            _btnExit = new GameButton(GLOBAL.Exittexture, GLOBAL.Exittexture2,
                _menutable.Model.Position.X + 63, _menutable.Model.Position.Y + 465);
            listButton.Add(_btnplay);
            listButton.Add(_btnLoad);
            //listButton.Add(_btnOption);
            listButton.Add(_btnScore);
            listButton.Add(_btnExit);

            _Title = new GameButton( GLOBAL.TitleTexture, GLOBAL.TitleTexture, -106, 20);//title
            //_Title = new GameButton(new Bound2D(420, 17,
            //    Global.TitleTexture.Height, Global.TitleTexture.Width), Global.TitleTexture
            //    , Global.TitleTexture, Itexture.khong_chon);//title2
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            #region chuyen button
            _delay += gameTime.ElapsedGameTime.Milliseconds;
            KeyboardState kbs = Keyboard.GetState();

            if (kbs.IsKeyDown(Keys.Down) && _delay >= 200)
            {
                GLOBAL.changeButtonSound.Play();
                if (selectedButton == listButton.Count - 1)
                    selectedButton = 0;
                else
                {
                    selectedButton++;
                }
                _delay = 0;
            }
            if (kbs.IsKeyUp(Keys.Up) == false && _delay >= 200)
            {
                GLOBAL.changeButtonSound.Play();
                if (selectedButton == 0)
                    selectedButton = listButton.Count - 1;
                else
                {
                    selectedButton--;
                }
                _delay = 0;
            }
            if (kbs.IsKeyDown(Keys.Enter) && _delay >= 200)
            {
                GLOBAL.enterGameSound.Play();
                if (selectedButton == 0)
                {
                    //this.UnloadContent();
                    NewGameClick = true;

                }
            }
            for (int d = 0; d < listButton.Count; d++)
            {
                if (d == selectedButton)
                {
                    listButton[d].Model.MouseHere = true;
                }
                else
                {
                    listButton[d].Model.MouseHere= false;
                }
            }

            #endregion
            if (_menutable.Model.Position.Y < 0)
            {
                if (_menutable.Model.Position.Y == -24)
                {
                    GLOBAL.menutableSound.Play();
                    //co++;
                }
                float temp = _menutable.Model.Position.Y;
                _menutable.Model.Position = new Vector2(_menutable.Model.Position.X, temp += 2);
                for (int i = 0; i < listButton.Count; i++)
                {
                    temp = listButton[i].Model.Position.Y;
                    listButton[i].Model.Position = new Vector2(listButton[i].Model.Position.X, temp += 2);
                    //co++;
                }
            }

            if (_Title.Model.Position.X < 50)
            {
                float temp = _Title.Model.Position.X;
                _Title.Model.Position = new Vector2(temp += 2, _Title.Model.Position.Y);
            }
            _menutable.Update(gameTime);
            _btnplay.Update(gameTime);
            _btnLoad.Update(gameTime);
            _btnScore.Update(gameTime);
            _btnExit.Update(gameTime);
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spritebatch.Begin();
            //background
            spritebatch.Draw(GLOBAL.MenuBackground, new Rectangle(0, 0, 700, 600), Color.White);
            //menutable

            _menutable.Draw(0, 0, spritebatch, Vector2.Zero, Color.White, 0, Vector2.Zero, 0, 0);
            for (int i = 0; i < listButton.Count; i++)
            {
                listButton[i].Draw(0, 0, spritebatch, Vector2.Zero, Color.White, 0, Vector2.Zero, 0, 0);
            }
            _Title.Draw(0, 0, spritebatch, Vector2.Zero, Color.White, 0, Vector2.Zero, 0, 0);
            spritebatch.End();

            base.Draw(gameTime);
        }
        #endregion

    }
}
