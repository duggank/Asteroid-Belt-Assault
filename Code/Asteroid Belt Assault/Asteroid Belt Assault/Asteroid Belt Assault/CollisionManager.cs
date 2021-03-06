﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Asteroid_Belt_Assault
{
    class CollisionManager
    {
        private PowerManager powerManager;
        private AsteroidManager asteroidManager;
        private PlayerManager playerManager;
        private EnemyManager enemyManager;
        private ExplosionManager explosionManager;
        private Vector2 offScreen = new Vector2(-500, -500);
        private Vector2 shotToAsteroidImpact = new Vector2(0, -20);
        private int enemyPointValue = 100;

        public CollisionManager(
           // PowerManager powerManager,
            AsteroidManager asteroidManager,
            PlayerManager playerManager,
            EnemyManager enemyManager,
            ExplosionManager explosionManager)
        {
            this.powerManager = powerManager;
            this.asteroidManager = asteroidManager;
            this.playerManager = playerManager;
            this.enemyManager = enemyManager;
            this.explosionManager = explosionManager;
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

        private void checkShotToPowerUpCollisions()
        {
            foreach (Sprite shot in playerManager.PlayerShotManager.Shots)
            {
                foreach (PowerUp powerUp in powerManager.Powers)
                {
                    if (shot.IsCircleColliding(
                        powerUp.PowerSprite.Center,
                        powerUp.PowerSprite.CollisionRadius))
                    {
                        shot.Location = offScreen;
                        powerManager.consumed = true;
                        explosionManager.AddExplosion(
                            powerUp.PowerSprite.Center,
                            powerUp.PowerSprite.Velocity / 10);
                    }
                }
            }
        }

        private int hitpoints = 3;
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
                        hitpoints--;
                        shot.Location = offScreen;
                        asteroid.Velocity += shotToAsteroidImpact;
                        if (hitpoints == 0)
                        {
                            explosionManager.AddExplosion(asteroid.Center, asteroid.Velocity / 10);
                            asteroid.Location = offScreen;
                            playerManager.PlayerScore += 25;
                            hitpoints = 3;
                        }
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
        private void checkAsteroidToEnemyCollisions()
        {
            foreach (Sprite asteroid in asteroidManager.Asteroids)
            {
                foreach (Enemy enemy in enemyManager.Enemies)
                {
                    if (asteroid.IsCircleColliding(
                        enemy.EnemySprite.Center,
                        enemy.EnemySprite.CollisionRadius))
                    {
                        explosionManager.AddExplosion(
                            asteroid.Center,
                            asteroid.Velocity / 10);
                        asteroid.Location = offScreen;

                        enemy.Destroyed = true;
                        explosionManager.AddExplosion(
                            enemy.EnemySprite.Center,
                            enemy.EnemySprite.Velocity / 10);
                    }
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
                checkEnemyToPlayerCollisions();
                checkAsteroidToPlayerCollisions();
                checkAsteroidToEnemyCollisions();
            }
        }

    }
}
