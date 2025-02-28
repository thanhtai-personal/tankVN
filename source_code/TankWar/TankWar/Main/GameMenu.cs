﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace TankVN
{
    class GameMenu : Microsoft.Xna.Framework.DrawableGameComponent
    {
        #region Cấu trúc
        SpriteBatch spritebatch;
        int _delay = 0;
        public bool IsAbout = false;
        #region Menutable
        double _delay2 = 0;
        public int cong = 0;
        List<GameButton> listButton = new List<GameButton>();
        public bool btn_click = false;
        #endregion


        public int selectedButton = 0;
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
            MediaPlayer.Play(GLOBAL.nhacnenGame);
            base.Initialize();
        }
        protected override void UnloadContent()
        {
            base.UnloadContent();
        }
        protected override void LoadContent()
        {
            spritebatch = new SpriteBatch(this.Game.GraphicsDevice);

            listButton.Add(new GameButton(GLOBAL.BtnPlayUp, GLOBAL.BtnPlayDown,
                900 / 2-100, 676 / 2));
   
            listButton.Add(new GameButton(GLOBAL.BtnMusicOn, GLOBAL.BtnMusicOnDown,
                900 / 2 + 100 - 300, 676 / 2 + 210));

            listButton.Add(new GameButton(GLOBAL.BtnAboutUp, GLOBAL.BtnAboutDown,
                900 / 2 + 250 - 300, 676 / 2 + 210));
            listButton.Add(new GameButton(GLOBAL.BtnExitUp, GLOBAL.BtnExitDown,
                900 / 2 + 400 - 300, 676 / 2 + 210));

          
           
            base.LoadContent();
        }
        public bool flag = false;
        public override void Update(GameTime gameTime)
        {
            #region chuyen button
            _delay += gameTime.ElapsedGameTime.Milliseconds;
            _delay2 += gameTime.ElapsedGameTime.TotalMilliseconds;
            if ((_delay2 > 50)&&(cong + 2 < 400))
                
            {
                cong += 2;
                _delay2 = 0;
            }
            KeyboardState kbs = Keyboard.GetState();

            if ((kbs.IsKeyDown(Keys.Down)||kbs.IsKeyDown(Keys.Right)) && _delay >= 200)
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
            if ((kbs.IsKeyDown(Keys.Up) || kbs.IsKeyDown(Keys.Left)) && _delay >= 200)
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
                //this.UnloadContent();
                btn_click = true;                    

                
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
                    listButton[d].Model.MouseHere= false;
                }
                listButton[d].Update(gameTime);
            }

            #endregion

            if ((MediaPlayer.Volume > 0) || (SoundEffect.MasterVolume > 0))
            {
                listButton[1].temp.Texture1 = GLOBAL.BtnMusicOn;
                listButton[1].temp.Texture2 = GLOBAL.BtnMusicOnDown;
            }
            else
            {
                listButton[1].temp.Texture1 = GLOBAL.BtnMusicOff;
                listButton[1].temp.Texture2 = GLOBAL.BtnMusicOffDown;
            }
           
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spritebatch.Begin();
            //background
            spritebatch.Draw(GLOBAL.MenuBackground, new Rectangle(0, 0, 900, 676), Color.White);
            //menutable
            listButton[0].Draw(0, 0, spritebatch, Vector2.Zero, Color.White, 0, Vector2.Zero, 2f, 0);
            for (int i = 1; i < listButton.Count; i++)
            {
                listButton[i].Draw(0, 0, spritebatch, Vector2.Zero, Color.White, 0, Vector2.Zero,1f,0);
            }
            
            if (IsAbout == true)
            {
                
                    spritebatch.DrawString(GLOBAL.font, "          Author       ", new Vector2(400, 200 + 430 - cong), Color.White);
                    spritebatch.DrawString(GLOBAL.font2, "Bui Quoc Ty", new Vector2(610, 300 + 430 - cong), Color.White);
                    spritebatch.DrawString(GLOBAL.font2, "Vo Hoai Phong", new Vector2(610, 350 + 430 - cong), Color.White);
                    spritebatch.DrawString(GLOBAL.font2, "Le Thi Bit Nhi", new Vector2(610, 400 + 430 - cong), Color.White);
               
              
            }
           
            spritebatch.End();

            base.Draw(gameTime);
        }
        #endregion

    }
}
