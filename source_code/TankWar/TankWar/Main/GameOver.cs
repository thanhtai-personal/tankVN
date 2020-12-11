﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankVN
{
    class GameOver : Microsoft.Xna.Framework.DrawableGameComponent
    {
        #region Cấu trúc
        SpriteBatch spritebatch;
        int _delay = 0;

        #region Menutable
        GameButton _btnReplay;
        GameButton _btnExit;

        List<GameButton> listButton = new List<GameButton>();
        public bool btn_Replay_click = false;
        public bool btn_back_click = false;
        #endregion



        int selectedButton = 0;
        
        #endregion

        #region Hàm

        public GameOver(Game game)
            : base(game)
        {
            
            this.Visible = false;
            this.Enabled = false;

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

            _btnExit = new GameButton(GLOBAL.BtnBackMenuUp, GLOBAL.BtnBackMenuDown,
                GamePlay.gameZone.Width / 2 + 200, GamePlay.gameZone.Height / 2+170);
            _btnReplay = new GameButton(GLOBAL.BtnPlayUp, GLOBAL.BtnPlayDown,
               GamePlay.gameZone.Width / 2, GamePlay.gameZone.Height / 2+170);
            listButton.Add(_btnReplay);
            listButton.Add(_btnExit);

            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            #region chuyen button
            _delay += gameTime.ElapsedGameTime.Milliseconds;
            KeyboardState kbs = Keyboard.GetState();

            if (kbs.IsKeyDown(Keys.Right) && _delay >= 200)
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
            if (kbs.IsKeyUp(Keys.Left) == false && _delay >= 200)
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
                    btn_Replay_click = true;

                }
                if (selectedButton == 1)
                {
                    //this.UnloadContent();
                    btn_back_click = true;
                    

                }
                _delay = 0;
            }
            for (int d = 0; d < listButton.Count; d++)
            {
                if (d == selectedButton)
                {
                    listButton[d].Model.MouseHere = true;
                }
                else
                {
                    listButton[d].Model.MouseHere = false;
                }
            }

            #endregion

            _btnReplay.Update(gameTime);
            _btnExit.Update(gameTime);
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spritebatch.Begin();
            //background
            spritebatch.Draw(GLOBAL.GameOverBG, new Rectangle(0, 0, 900, 676), Color.White);
            //menutable

            
            for (int i = 0; i < listButton.Count; i++)
            {
                listButton[i].Draw(0, 0, spritebatch, Vector2.Zero, Color.White, 0, Vector2.Zero, 1f, 0);
            }
           
            spritebatch.End();

            base.Draw(gameTime);
        }
        #endregion

    }
}
