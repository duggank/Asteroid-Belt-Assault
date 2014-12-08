using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroid_Belt_Assault
{
    public delegate void Handler();

    class Power
    {
        
        public Sprite PowSprite;
        private int powerRadius = 36;
        private bool isDestroyed = false;
        private bool isStarted = false;  // True if user gets the powerup
        private Vector2 previousLocation = Vector2.Zero;
        private PlayerManager PlayManger;
        public float Timer = 0.0f;
        public float TimerMax = 1.0f * 1000f;
        public Handler OnFinish;
        public Handler OnStart; 
       

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

        public void Start()
        {
            if (OnStart != null)
                OnStart();

            this.isStarted = true;
        }

        public void Destroy()
        {
            isDestroyed = true;
        }

        public void Update(GameTime gameTime)
        {
            if (Activated)
            {
                PowSprite.Update(gameTime);
            }


            if (isStarted)
            {
                Timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (Timer > TimerMax)
                {
                    OnFinish();
                }
            }    
            
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            if(Activated)
                PowSprite.Draw(spriteBatch);
        }
         
            
    }
}
