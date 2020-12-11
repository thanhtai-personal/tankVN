using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.GamerServices;

namespace TankVN
{
    class SelectMapMenu : Microsoft.Xna.Framework.DrawableGameComponent
    {
        #region Cấu trúc
        SpriteBatch spritebatch;
        double _delay = 0;

        #region Menutable

        List<GameButton> listButton = new List<GameButton>();
        public bool btn_click = false;
        #endregion



        public int selectedButton = 0;

        #endregion

        #region Hàm

        public SelectMapMenu(Game game)
            : base(game)
        {
            GLOBAL.LoadGame();
           this.Visible = false;
            this.Enabled = false;

        }
        public override void Initialize()
        {

           
            base.Initialize();
        }
        protected override void UnloadContent()
        {
            base.UnloadContent();
        }
        protected override void LoadContent()
        {
            spritebatch = new SpriteBatch(this.Game.GraphicsDevice);
            for (int j = 1; j <= 2; j++)
                for (int i = 1; i <= 5; i++)
                {
                    if (listButton.Count < GLOBAL.gamedata.maxlevel)
                        listButton.Add(new GameButton(GLOBAL.BtnMapUp, GLOBAL.BtnMapDown,
                            GamePlay.gameZone.Width / 6 + i * 100, GamePlay.gameZone.Height / 6 + j * 150 - 50));
                    else
                        listButton.Add(new GameButton(GLOBAL.BtnMapLock, GLOBAL.BtnMapLock,
                            GamePlay.gameZone.Width / 6 + i * 100, GamePlay.gameZone.Height / 6 + j * 150 - 50));
                }
            

            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            #region chuyen button
            _delay += gameTime.ElapsedGameTime.TotalMilliseconds;
            KeyboardState kbs = Keyboard.GetState();

            if (kbs.IsKeyDown(Keys.Right) && _delay >= 200)
            {
                GLOBAL.changeButtonSound.Play();
                if (selectedButton == GLOBAL.gamedata.maxlevel-1)
                    selectedButton = 0;
                else
                {
                    if (selectedButton+1<=GLOBAL.gamedata.maxlevel)
                        selectedButton++;
                }
                _delay = 0;
            }
            
            if (kbs.IsKeyDown(Keys.Left) && _delay >= 200)
            {
                GLOBAL.changeButtonSound.Play();
                if (selectedButton ==0)
                    selectedButton = GLOBAL.gamedata.maxlevel-1;
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
                _delay = 0;
                btn_click = true;
                    

                
            }
            if (kbs.IsKeyDown(Keys.Escape) && _delay >= 200)
            {
                GLOBAL.enterGameSound.Play();
                GLOBAL.gType = GameType.gamenu;
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
             
                listButton[d].Update(gameTime);
                if (d <= GLOBAL.gamedata.maxlevel - 1)
                {
                    listButton[d].temp.Texture1 = GLOBAL.BtnMapUp;
                    listButton[d].temp.Texture2 = GLOBAL.BtnMapDown;
                }
            }

            #endregion

            
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            this.Initialize();
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spritebatch.Begin();
            //background
            spritebatch.Draw(GLOBAL.SelectMapMenuBG, new Rectangle(0, 0, 900, 676), Color.White);
            //menutable


            for (int i = 0; i < listButton.Count; i++)
            {
                listButton[i].Draw(0, 0, spritebatch, listButton[i].Model.Position, Color.White, 0, Vector2.Zero,1f, 0);
                if (i < GLOBAL.gamedata.maxlevel)
                    spritebatch.DrawString(GLOBAL.font, (i + 1).ToString(), new Vector2(listButton[i].Model.Position.X + 49, listButton[i].Model.Position.Y + 20), Color.White);
            }            
            spritebatch.End();

            base.Draw(gameTime);
        }
        #endregion

    }
}
