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
        private Rectangle frame;

        public List<PowerUp> Powers = new List<PowerUp>();
        private int Speed = 40;


        private PlayerManager playerManager;
        private ShotManager shotManager;
        private EnemyManager enemyManager;
        private ExplosionManager explosionManager;
        private AsteroidManager asteroidManager;

        private String powerName;
        private int Selection;

        private Random rand;

        public PowerManager(
            Texture2D texture,
            AsteroidManager asteroidManager,
            PlayerManager playerManager,
            EnemyManager enemyManager,
            ShotManager shotManager,
            ExplosionManager explosionManager)
        {
            this.asteroidManager = asteroidManager;
            this.playerManager = playerManager;
            this.enemyManager = enemyManager;
            this.explosionManager = explosionManager;
            this.shotManager = shotManager;
            this.texture = texture;

        }

        
        public void AddPower()
        {
            PowerUp newPower = new PowerUp(
                texture,
                new Vector2(rand.Next(10, 700), 10),
                frame,
                0);
            newPower.powerupRadius = 30;
            Powers.Add(newPower);
        }

        private void GivePower()
        {
            if(texture.Name == @"Textures\\jaelpowerup.png")
                Selection = 1;

            if (Selection == 1) //Super fast fire rate.
            {
                shotManager.shotSpeed += (.79f * shotManager.shotSpeed);
                
            }
        }

        private void Start()
        {
            if (!playerManager.Destroyed)
            {
                AddPower();
                if (consumed == true)
                {
                    GivePower();
                    consumed = false;
                }
            }
        }

    }
}
