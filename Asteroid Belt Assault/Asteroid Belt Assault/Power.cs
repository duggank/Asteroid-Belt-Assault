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
        private int powerRadius = 36;
        private bool isDestroyed = false;
        private Vector2 previousLocation = Vector2.Zero;
        private PlayerManager PlayManger;

        public Power(Vector2 location, Texture2D texture, Rectangle initialFrame, Vector2 velocity)
        {
            PowSprite = new Sprite(location, texture, initialFrame, Vector2.Zero);
            
            PowSprite.CollisionRadius = powerRadius;
        }

        public bool Activated
        {
            get {
                return !isDestroyed;
            }

        }

        public void Destroy()
        {
            isDestroyed = true;
        }

        public void SpeedUp()
        {
            PlayManger.playerSpeed = 240.0f;
        }

        public void Update(GameTime gameTime)
        {
            if (Activated)
            {
                PowSprite.Update(gameTime);
            }
            
        }

        

        public void Draw(SpriteBatch spriteBatch)
        {
            if(Activated)
                PowSprite.Draw(spriteBatch);
        }
         
            
    }
}
