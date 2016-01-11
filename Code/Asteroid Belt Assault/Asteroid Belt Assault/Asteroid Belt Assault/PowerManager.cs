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

        private Texture2D texture;
        private Rectangle frame;

        public List<Sprite> Powers = new List<Sprite>();
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
            Sprite newPower = new Sprite(
                new Vector2(rand.Next(10, 700), 0),
                texture,
                frame,
                Vector2.Zero);
            newPower.CollisionRadius = 30;
            Powers.Add(newPower);
        }

        private void GivePower()
        {
            Selection = rand.Next(0, 4);

            if (Selection == 1) //Super fast fire rate.
            {
                shotManager.shotSpeed += (.15f * shotManager.shotSpeed);
                
            }
        }

        private void Start()
        {
            if (!playerManager.Destroyed)
            {
                AddPower();
                GivePower();
            }
        }

    }
}
