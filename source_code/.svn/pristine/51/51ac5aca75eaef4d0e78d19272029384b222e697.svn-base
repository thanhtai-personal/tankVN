using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TankVN
{
    class Force
    {
        private int speed;
        private Vector2 direction;
        private int power;
        private Vector2 currentspeed;
        public int Speed { set { this.speed = value; } get { return speed; } }
        public Vector2 Direction { set { this.direction = value; } get { return direction; } }
        public int Power { set { this.power = value; } get { return power; } }
        public Vector2 CurrentSpeed
        {
            set
            {
                this.currentspeed = value;
            }
            get { return currentspeed; }
        }
        public Force(int speed, Vector2 direction, int power)
        {
            this.speed = speed;
            this.direction = direction;
            this.power = power;
            this.currentspeed = Vector2.Zero;
        }
    }
}
