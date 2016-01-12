using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroid_Belt_Assault
{
    class PowerUp
    {
        public Sprite PowerSprite;
        private float speed = 120f;
        public bool Consumed = false;
        public int powerupRadius;

        public PowerUp(
            Texture2D texture,
            Vector2 location,
            Rectangle initialFrame,
            int frameCount)
        {
            PowerSprite = new Sprite(
                location,
                texture,
                initialFrame,
                Vector2.Zero);

            PowerSprite.CollisionRadius = powerupRadius;
        }

        public bool IsActive()
        {
            if (Consumed)
            {
                return false;
            }

            return true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsActive())
            {
                PowerSprite.Draw(spriteBatch);
            }
        }
    }
}
