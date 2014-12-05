using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroid_Belt_Assault
{
    public delegate void Finish();

    class Power
    {
        
        public Sprite PowSprite;
        private int powerRadius = 36;
        private bool isDestroyed = false;
        private Vector2 previousLocation = Vector2.Zero;
        private PlayerManager PlayManger;
        public float Timer = 0.0f;
        public float TimerMax = 5.0f * 1000f;
        public Finish OnFinish;
       

        public Power(Vector2 location, Texture2D texture, Rectangle initialFrame, Vector2 velocity, float Timer)
        {
            PowSprite = new Sprite(location, texture, initialFrame, Vector2.Zero);
            this.Timer = Timer;
            
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

            if (OnFinish != null)
            {
                OnFinish();
            }
        }

        public void Update(GameTime gameTime)
        {
            if (Activated)
            {
                PowSprite.Update(gameTime);
                Timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (Timer > TimerMax)
                    Destroy();
            }
                
            
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            if(Activated)
                PowSprite.Draw(spriteBatch);
        }
         
            
    }
}
