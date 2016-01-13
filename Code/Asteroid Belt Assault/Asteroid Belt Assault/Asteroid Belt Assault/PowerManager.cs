using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroid_Belt_Assault
{
    class PowerManager
    {
        private int screenWidth = 800;
        private int screenHeight = 600;
        private int screenPadding = 10;
        public bool consumed = true;

        private Texture2D texture;
        private Rectangle initialFrame;
        private int frameCount;

        public List<PowerUp> Powers = new List<PowerUp>();
        private int Speed = 40;


        private PlayerManager playerManager;
        private int Selection;

        private Random rand;

        public PowerManager(
            Texture2D texture,
            Rectangle initialFrame, // new Rectangle(0,313,56,54)
            int frameCount,
            PlayerManager playerManager)
        {
            this.playerManager = playerManager;
            this.texture = texture;
            this.initialFrame = initialFrame;
            this.frameCount = frameCount;

            rand = new Random(System.Environment.TickCount);
        }

        
        public void AddPower()
        {
            PowerUp newPower = new PowerUp(
                texture,
                new Vector2(rand.Next(10, 700), 10),
                initialFrame,
                0);
            newPower.PowerSprite.CollisionRadius = 30;
            Powers.Add(newPower);
        }

        public void GivePower()
        {
                playerManager.PlayerShotManager.shotSpeed += (.79f * playerManager.PlayerShotManager.shotSpeed);
        }

        public void Start()
        {
            if (!playerManager.Destroyed)
            {
                if (consumed == true)
                {
                    GivePower();
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            for (int x = 0; x < Powers.Count; x++)
            {
                Powers[x].Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (PowerUp power in Powers)
            {
                power.Draw(spriteBatch);
            }
        }

    }
}
