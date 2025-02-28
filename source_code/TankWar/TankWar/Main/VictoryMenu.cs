﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.GamerServices;
namespace TankVN
{
    class VictoryMenu : VisibleGameEntity
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

        public VictoryMenu()
        {
            GLOBAL.xeSave = GLOBAL.xe;
            this.Visible = false;
            this.Enable = false;
            this.Model = new MySprite2D(new TextureMultiFrame(GLOBAL.VictoryMenuBG, GLOBAL.VictoryMenuBG.Width, GLOBAL.VictoryMenuBG.Height), 1000);
            //this.Model.Position = new Vector2(900 / 2 - GLOBAL.VictoryMenuBG.Width / 2, 676 / 2 - GLOBAL.VictoryMenuBG.Height / 2);
            this.Model.Position = new Vector2(900 / 2 - GLOBAL.VictoryMenuBG.Width / 2, 400);

            //listButton.Add(new GameButton(GLOBAL.BtnOkUp, GLOBAL.BtnOkDown,
            //this.Model.Position.X + 50, this.Model.Position.Y + this.Model.Height - 40));
                    
            //listButton.Add(new GameButton(GLOBAL.BtnBackMenuUp, GLOBAL.BtnBackMenuDown,
            //this.Model.Position.X+this.Model.Width-130, this.Model.Position.Y+this.Model.Height-40));
            listButton.Add(new GameButton(GLOBAL.BtnOkUp, GLOBAL.BtnOkDown,
                0, 0));

            listButton.Add(new GameButton(GLOBAL.BtnBackMenuUp, GLOBAL.BtnBackMenuDown,
            0,0));
            
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
                if (selectedButton == listButton.Count-1)
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
                    selectedButton = listButton.Count-1;
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
            if (_delay2 > 10)
            {
                _delay2 = 0;
                if (this.Model.Position.Y > (676 / 2 - GLOBAL.VictoryMenuBG.Height / 2))
                {
                    this.Model.Position = new Vector2(900 / 2 - GLOBAL.VictoryMenuBG.Width / 2, this.Model.Position.Y - 4);
                    listButton[0].temp.Position = new Vector2(this.Model.Position.X + 50, this.Model.Position.Y + this.Model.Height - 40);
                    listButton[1].temp.Position = new Vector2(this.Model.Position.X + this.Model.Width - 130, this.Model.Position.Y + this.Model.Height - 40);
                
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
                    listButton[d].Model.MouseHere = false;
                }

                listButton[d].Update(gametime);                
            }

            #endregion

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
            for (int i = 1; i <= 4; i++)
            {
                spritebatch.DrawString(GLOBAL.font2, "x" + GLOBAL.xe.NumEnermyDestroy[i].ToString(), new Vector2(this.Model.Position.X+270,this.Model.Position.Y+125+(i-1)*25), Color.White);
            }
            int temp=GLOBAL.xe.NumEnermyDestroy[1]*150 + GLOBAL.xe.NumEnermyDestroy[2] *250 + GLOBAL.xe.NumEnermyDestroy[3]*200 + GLOBAL.xe.NumEnermyDestroy[4]*300;
            spritebatch.DrawString(GLOBAL.font, temp.ToString(), new Vector2(this.Model.Position.X + 450, this.Model.Position.Y + 150), Color.White);
        }
    }
    
}
