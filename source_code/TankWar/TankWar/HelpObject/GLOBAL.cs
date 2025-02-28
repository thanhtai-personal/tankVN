﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using System.Xml.Serialization;
using System.IO;
namespace TankVN
{
    public struct GameData
    {
        public int maxlevel;
        public List<int> livepoint;
    }
    class GLOBAL
    {
        public static Song nhacnenGame;

        public static List<Song> music;
#region soundeffects
        public static SoundEffect changeButtonSound;
        public static SoundEffect menutableSound;
        public static SoundEffect enterGameSound;
        public static SoundEffect Firesound;
        public static SoundEffect ExplosionGachsound;
        public static SoundEffect ExplosionTanksound;
        public static SoundEffect ItemAppearSound;
        public static SoundEffect WinningSound;
        public static SoundEffect GameOverSound;
        public static SoundEffect StartGameSound;
        public static SoundEffect KillAllItemSound;
        public static SoundEffect FreezeItemSound;
        public static SoundEffect HeartItemSound;
        public static SoundEffect ShieldItemSound;
        public static SoundEffect SpeedItemSound;
        public static SoundEffect HouseItemSound;
        public static SoundEffect UpdateItemSound;
        public static SoundEffect TeleportItemSound;
#endregion

        public static GameType gType;
        #region gameMenu
        public static Texture2D Playtexture;
        public static Texture2D Loadtexture;
        public static Texture2D Opotiontexture;
        public static Texture2D Scoretexture;
        public static Texture2D Exittexture;
        public static Texture2D Menutabletexture;
        public static Texture2D Playtexture2;
        public static Texture2D Loadtexture2;
        public static Texture2D Opotiontexture2;
        public static Texture2D Scoretexture2;
        public static Texture2D Exittexture2;
        public static Texture2D TitleTexture;
        public static Texture2D GameOverBG;
        public static Texture2D sideBG;
    
        public static Texture2D MenuBackground;
        public static Texture2D SelectMapMenuBG;
        public static Texture2D BtnMapUp;
        public static Texture2D BtnMapDown;
        public static Texture2D BtnMapLock;
        public static Texture2D VictoryMenuBG;
        public static Texture2D BtnOkUp;
        public static Texture2D BtnOkDown;
        public static Texture2D BtnBackMenuUp;
        public static Texture2D BtnBackMenuDown;

        public static Texture2D PauseMenuBG;
        public static Texture2D BtnPlayDown;
        public static Texture2D BtnPlayUp;
        public static Texture2D BtnMusicOn;
        public static Texture2D BtnMusicOff;
        public static Texture2D BtnMusicOnDown;
        public static Texture2D BtnMusicOffDown;
        public static Texture2D BtnExitUp;
        public static Texture2D BtnExitDown;
        public static Texture2D BtnAboutUp;
        public static Texture2D BtnAboutDown;
        #endregion

        #region GamePlay
        public static SoundEffect bulletSound;
        public static Texture2D BulletTexture;
        public static Texture2D Gachtexture;
        public static Texture2D ProtectTexture;
        public static Texture2D walltexture;
        public static Texture2D bgtexture;
        public static Texture2D buicaytexture;
        public static Texture2D waterTt;
        public static Texture2D tankEnermy1Tt;
        public static Texture2D tankEnermy2Tt;
        public static Texture2D tankEnermy3Tt;
        public static Texture2D tankEnermy4Tt;
        public static Texture2D tankPlayerTt;
        public static Texture2D explosionGachTt;
        public static Texture2D explosionTankTt;
        public static Texture2D explosionBulletTt;
        public static Texture2D FireTt;

        public static Texture2D EnermyHasItemTt;
        public static Texture2D KillAllItemTt;
        public static Texture2D ItemEf;
        public static Texture2D KillAllEfTt;
        public static Texture2D FreezeTimeItemTt;
        public static Texture2D FreezeEffectGamezoneTt;
        public static Texture2D ShieldItemTt;
        public static Texture2D ShieldItemEfTt;
        public static Texture2D HeartItemTt;
        public static Texture2D HeartItemEfTt;
        public static Texture2D SpeedItemTt;
        public static Texture2D SpeedItemEfTt;
        public static Texture2D UpdateItemTt;
        public static Texture2D HouseItemTt;
        public static Texture2D HouseItemEfTt;
        public static Texture2D TeleportItemTt;
        public static Texture2D TeleportItemEfTt;
        public static List<MySprite2D> explosionGach;
        public static List<MySprite2D> explosionTank;
        public static List<MySprite2D> explosionBullet;
        public static List<MySprite2D> Fire;        
        public static player xe;
        public static player xeSave;
        public static Item item;
        public static List<bullet> Bullet { get; set; }
        public static List<enermy> enermy;
        public static SpriteFont font;
        public static SpriteFont font2;

        public static bool GameOver;
        public static bool Win;
        public static Vector2 PosObjectProtect;
        #region function
        public static int NumPlayerBullet()
        {
            int dem = 0;
            for (int i = 0; i < GLOBAL.Bullet.Count; i++)
                if (GLOBAL.Bullet[i].Type == bullet.loaidan.player) dem++;
            return dem;
        }
        public static int NumEnemyBullet()
        {
            int dem = 0;
            for (int i = 0; i < GLOBAL.Bullet.Count - 1; i++)
                if (GLOBAL.Bullet[i].Type == bullet.loaidan.enermy) dem++;
            return dem;
        }
        public static bool IsInside(Rectangle A, Rectangle B)
        {

            return

                (A.X >= B.X && B.X + B.Width >= A.X + A.Width) &&

                (A.Y >= B.Y && B.Y + B.Height >= A.Y + A.Height);

        }



        public static bool IsOutside(Rectangle A, Rectangle B)
        {
            return

               (A.X + A.Width <= B.X || A.X >= B.X + B.Width) ||

               (A.Y + A.Height <= B.Y || A.Y >= B.Y + B.Height);

        }

        public static bool IsInsideList(Vector2 X, List<Vector2> Mang)
        {
            if (Mang.Count == 0) return false;
            for (int i = 0; i < Mang.Count - 1; i++)
                if (X == Mang[i]) return true;
            return false;
        }

        public static bool IsCut(Rectangle A, Rectangle B)
        {

            return (!IsInside(A, B) && (!IsOutside(A, B)));


        }
        public static bool vachampixel(Rectangle A, Color[] dataA, Rectangle B, Color[] dataB)
        {
            int top = Math.Max(A.Top, B.Top);

            int bottom = Math.Min(A.Bottom, B.Bottom);

            int left = Math.Max(A.Left, B.Left);

            int right = Math.Min(A.Right, B.Right);
            Color colorA = new Color(0, 0, 0, 0);
            Color colorB = new Color(0, 0, 0, 0);
            if (dataA == null || dataB == null) return false;
            for (int y = top; y < bottom; y++)
            {

                for (int x = left; x < right; x++)
                {

                    // Lấy màu của 2 điểm ảnh tại một điểm
                    int temp;
                    //if (dataA != null)
                    // {
                    temp = (x - A.Left) + (y - A.Top) * A.Width;
                    if ((temp >= 0) && (temp < dataA.Length))
                        colorA = dataA[temp];
                    temp = (x - B.Left) + (y - B.Top) * B.Width;
                    if ((temp >= 0) && (temp < dataB.Length))
                        colorB = dataB[temp];

                    // Nếu cả 2 điểm đều có độ trong suốt khác không

                    if (colorA.A != 0 && colorB.A != 0)
                    {

                        // then an intersection has been found

                        return true;

                    }
                    // }


                }

            }

            // Va chạm không xảy ra

            return false;

        }

     
        public static void SaveGame()
        {
            //tiến hành save ở đây:
            
            
            string fileName = Path.Combine(Environment.CurrentDirectory, "save0001.sav");

            FileStream saveFile = File.Open(fileName, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GameData));

            xmlSerializer.Serialize(saveFile, gamedata);
            saveFile.Close();            

 
            operationPending = false;
        }

        public static void LoadGame()
        {
            //thư mục đc tạo ra sẽ nằm trong my documents

            string fileName = Path.Combine(Environment.CurrentDirectory, "save0001.sav");
            if (File.Exists(fileName))
            {
                FileStream saveFile = File.Open(fileName, FileMode.Open);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(GameData));

                gamedata = (GameData)xmlSerializer.Deserialize(saveFile);
                saveFile.Close();

               
                operationPending = false;
            }
            else
            {
                gamedata.maxlevel = 1;
                gamedata.livepoint = new List<int>();
                gamedata.livepoint.Add(3);
            }
           
        }

        #endregion
        
        #endregion
#region save_load
        public static bool operationPending = false;
        public static int XeLivePoint;
        public static GameData gamedata;
#endregion
        public static List<List<string>> MapTxt;
        
    }
}
