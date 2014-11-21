﻿using System;
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
        private float speed = 20f;
        public bool IsOn;
        private int powerRadius = 20;
        private float PowTimer = 0.0f;
        private float PowTMax = 8.5f;
        private Vector2 previousLocation = Vector2.Zero;

        public Power(Vector2 location, Texture2D texture, Rectangle initialFrame, Vector2 velocity)
        {
            PowSprite = new Sprite(location, texture, initialFrame, Vector2.Zero);
            
            PowSprite.CollisionRadius = powerRadius;
        }

        public void Update(GameTime gameTime)
        {
            PowSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            PowSprite.Draw(spriteBatch);
        }
         
            
    }
}