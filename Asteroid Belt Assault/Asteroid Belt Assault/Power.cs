using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroid_Belt_Assault
{
    class Power
    {
        
        public Sprite PowSprite;
        private Vector2 currentWaypoint = Vector2.Zero;
        private float speed = 20f;
        public bool IsOn;
        private int powRadius = 15;
        private float PowTimer = 0.0f;
        private float PowTMax = 8.5f;
        private Vector2 previousLocation = Vector2.Zero;

        public Power(Texture2D texture, Vector2 location, Rectangle initialFrame, int frameCount)
        {
            PowSprite = new Sprite(location, texture, initialFrame, Vector2.Zero);
            
            PowSprite.CollisionRadius = powRadius;
        }
         
            
    }
}
