using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;


namespace TankWar
{
    class GLOBAL
    {
        public static Song nhacnenGame;
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
        public static SoundEffect changeButtonSound;
        public static SoundEffect menutableSound;
        public static SoundEffect enterGameSound;
        public static Texture2D MenuBackground;
        #endregion

        #region GamePlay
        public static SoundEffect bulletSound;
        public static Texture2D BulletTexture;
        public static Texture2D Gachtexture;
        public static Texture2D ProtectTexture;
        public static Texture2D walltexture;
        public static Texture2D bgtexture;
        public static Texture2D buicaytexture;
        public static Texture2D tankEnermy1Tt;
        public static Texture2D tankEnermy2Tt;
        public static Texture2D tankEnermy3Tt;
        public static Texture2D tankEnermy4Tt;
        public static Texture2D tankPlayerTt;
        public static Texture2D explosionGachTt;
        public static Texture2D explosionTankTt;
        public static Texture2D explosionBulletTt;
        public static Texture2D FireTt;
        public static List<MySprite2D> explosionGach;
        public static List<MySprite2D> explosionTank;
        public static List<MySprite2D> explosionBullet;
        public static List<MySprite2D> Fire;
        public static player xe;
        public static List<bullet> Bullet { get; set; }
        public static List<enermy> enermy;
        public static SpriteFont font;
        public static SpriteFont font2;
        public static String map_filepath;
        public static bool GameOver;
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
        #endregion

        #endregion
    }
}
