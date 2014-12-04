using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Asteroid_Belt_Assault
{
    class CollisionManager
    {
        private AsteroidManager asteroidManager;
        private PlayerManager playerManager;
        private EnemyManager enemyManager;
        private ExplosionManager explosionManager;
        private PowerUPManger PowerManager;
        private Vector2 offScreen = new Vector2(-500, -500);
        private Vector2 shotToAsteroidImpact = new Vector2(0, -20);
        private int enemyPointValue = 100;

        public CollisionManager(
            AsteroidManager asteroidManager,
            PlayerManager playerManager,
            EnemyManager enemyManager,
            ExplosionManager explosionManager,
            PowerUPManger PowerManager)
        {
            this.asteroidManager = asteroidManager;
            this.playerManager = playerManager;
            this.enemyManager = enemyManager;
            this.explosionManager = explosionManager;
            this.PowerManager = PowerManager;
        }

        private void checkShotToEnemyCollisions()
        {
            foreach (Sprite shot in playerManager.PlayerShotManager.Shots)
            {
                foreach (Enemy enemy in enemyManager.Enemies)
                {
                    if (shot.IsCircleColliding(
                        enemy.EnemySprite.Center,
                        enemy.EnemySprite.CollisionRadius))
                    {
                        shot.Location = offScreen;
                        enemy.Destroyed = true;
                        playerManager.PlayerScore += enemyPointValue;
                        explosionManager.AddExplosion(
                            enemy.EnemySprite.Center,
                            enemy.EnemySprite.Velocity / 10);
                    }

                }
            }
        }

        private void checkShotToPowerCollisions()
        {
            foreach (Sprite shot in playerManager.PlayerShotManager.Shots)
            {
                foreach (Power Fast in PowerManager.Speedy)
                {
                    if (shot.IsCircleColliding(
                        Fast.PowSprite.Center,
                        Fast.PowSprite.CollisionRadius) && Fast.Activated)
                    {
                        shot.Location = offScreen;
                        Fast.Destroy();
                        explosionManager.AddExplosion(
                            Fast.PowSprite.Center,
                            Fast.PowSprite.Velocity / 10);
                    }
                }
                foreach (Power Protect in PowerManager.Shield)
                {
                    if (shot.IsCircleColliding(
                        Protect.PowSprite.Center,
                        Protect.PowSprite.CollisionRadius) && Protect.Activated)
                    {
                        shot.Location = offScreen;
                        Protect.Destroy();
                        explosionManager.AddExplosion(
                            Protect.PowSprite.Center,
                            Protect.PowSprite.Velocity / 10);
                    }
                }
                foreach (Power Shoot in PowerManager.Shooty)
                {
                    if (shot.IsCircleColliding(
                        Shoot.PowSprite.Center,
                        Shoot.PowSprite.CollisionRadius) && Shoot.Activated)
                    {
                        shot.Location = offScreen;
                        Shoot.Destroy();
                        explosionManager.AddExplosion(
                            Shoot.PowSprite.Center,
                            Shoot.PowSprite.Velocity / 10);
                    }
                }
            }
        }

        private void checkShotToAsteroidCollisions()
        {
            foreach (Sprite shot in playerManager.PlayerShotManager.Shots)
            {
                foreach (Sprite asteroid in asteroidManager.Asteroids)
                {
                    if (shot.IsCircleColliding(
                        asteroid.Center,
                        asteroid.CollisionRadius))
                    {
                        shot.Location = offScreen;
                        asteroid.Velocity += shotToAsteroidImpact;
                    }
                }
            }
        }

        private void checkShotToPlayerCollisions()
        {
            foreach (Sprite shot in enemyManager.EnemyShotManager.Shots)
            {
                if (shot.IsCircleColliding(
                    playerManager.playerSprite.Center,
                    playerManager.playerSprite.CollisionRadius))
                {
                    shot.Location = offScreen;
                    playerManager.Destroyed = true;
                    explosionManager.AddExplosion(
                        playerManager.playerSprite.Center,
                        Vector2.Zero);
                }
            }
        }

        private void checkEnemyToPlayerCollisions()
        {
            foreach (Enemy enemy in enemyManager.Enemies)
            {
                if (enemy.EnemySprite.IsCircleColliding(
                    playerManager.playerSprite.Center,
                    playerManager.playerSprite.CollisionRadius))
                {
                    enemy.Destroyed = true;
                    explosionManager.AddExplosion(
                        enemy.EnemySprite.Center,
                        enemy.EnemySprite.Velocity / 10);

                    playerManager.Destroyed = true;

                    explosionManager.AddExplosion(
                        playerManager.playerSprite.Center,
                        Vector2.Zero);
                }
            }
        }

        private void checkAsteroidToPlayerCollisions()
        {
            foreach (Sprite asteroid in asteroidManager.Asteroids)
            {
                if (asteroid.IsCircleColliding(
                    playerManager.playerSprite.Center,
                    playerManager.playerSprite.CollisionRadius))
                {
                    explosionManager.AddExplosion(
                        asteroid.Center,
                        asteroid.Velocity / 10);

                    asteroid.Location = offScreen;

                    playerManager.Destroyed = true;
                    explosionManager.AddExplosion(
                        playerManager.playerSprite.Center,
                        Vector2.Zero);
                }
            }
        }

        public void CheckCollisions()
        {
            checkShotToEnemyCollisions();
            checkShotToAsteroidCollisions();
            if (!playerManager.Destroyed)
            {
                checkShotToPlayerCollisions();
                checkShotToPowerCollisions();
                checkEnemyToPlayerCollisions();
                checkAsteroidToPlayerCollisions();
            }
        }

    }
}
