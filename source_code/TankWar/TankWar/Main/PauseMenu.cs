using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
namespace TankVN
{
    class PauseMenu : VisibleGameEntity
    {
        int _delay = 0;
        double _delay2 = 0;
        public bool Visible;
        public bool Enable;
        #region Menutable

        List<GameButton> listButton = new List<GameButton>();
        public bool btn_click = false;

        #endregion
        public int selectedButton = 0;

        public PauseMenu()
        {
            GLOBAL.xeSave = GLOBAL.xe;
            this.Visible = false;
            this.Enable = false;
            this.Model = new MySprite2D(new TextureMultiFrame(GLOBAL.PauseMenuBG, GLOBAL.PauseMenuBG.Width, GLOBAL.PauseMenuBG.Height), 1000);
            //this.Model.Position = new Vector2(900 / 2 - GLOBAL.VictoryMenuBG.Width / 2, 676 / 2 - GLOBAL.VictoryMenuBG.Height / 2);
            this.Model.Position = Vector2.Zero;

            //listButton.Add(new GameButton(GLOBAL.BtnOkUp, GLOBAL.BtnOkDown,
            //this.Model.Position.X + 50, this.Model.Position.Y + this.Model.Height - 40));

            //listButton.Add(new GameButton(GLOBAL.BtnBackMenuUp, GLOBAL.BtnBackMenuDown,
            //this.Model.Position.X+this.Model.Width-130, this.Model.Position.Y+this.Model.Height-40));
            

            listButton.Add(new GameButton(GLOBAL.BtnBackMenuUp, GLOBAL.BtnBackMenuDown,
            900 / 2 - 300, 676 / 2));

            listButton.Add(new GameButton(GLOBAL.BtnPlayUp, GLOBAL.BtnPlayDown,
                900 / 2-50, 676 / 2));

            listButton.Add(new GameButton(GLOBAL.BtnMusicOn, GLOBAL.BtnMusicOnDown,
            900 / 2 + 200, 676 / 2));

        }
        public override void Update(GameTime gametime)
        {
            #region chuyen button
            _delay += gametime.ElapsedGameTime.Milliseconds;
            _delay2 += gametime.ElapsedGameTime.TotalMilliseconds;
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
                    listButton[d].Model.MouseHere = false;
                }

                listButton[d].Update(gametime);
            }

            #endregion
            if ((MediaPlayer.Volume > 0) || (SoundEffect.MasterVolume > 0))
            {
                listButton[2].temp.Texture1 = GLOBAL.BtnMusicOn;
                listButton[2].temp.Texture2 = GLOBAL.BtnMusicOnDown;
            }
            else
            {
                listButton[2].temp.Texture1 = GLOBAL.BtnMusicOff;
                listButton[2].temp.Texture2 = GLOBAL.BtnMusicOffDown;
            }
            base.Update(gametime);
        }
        public override void Draw(int firstframe, int lastframe, object obj, Vector2 position, Color color, float rotation, Vector2 origin, float scale, float layerDepth)
        {
            SpriteBatch spritebatch = (SpriteBatch)obj;
            //spritebatch.Draw(GLOBAL.VictoryMenuBG, new Rectangle(0, 0, GLOBAL.VictoryMenuBG.Width, GLOBAL.VictoryMenuBG.Height), Color.White);




            base.Draw(firstframe, lastframe, obj, this.Model.Position, color, rotation, origin, scale, layerDepth);

            for (int i = 0; i < listButton.Count; i++)
            {
                listButton[i].Draw(0, 0, spritebatch, listButton[i].temp.Position, Color.White, 0, Vector2.Zero, 1f, 0);
            }
           
           
        }
    }

}
