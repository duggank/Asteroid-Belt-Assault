using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroid_Belt_Assault
{
    class PowerUPManger
    {
         private Texture2D textureShield;
         private Texture2D textureSpeedy;
         private Texture2D textureShooty;
         private Rectangle initialFrame;
         public List<Power> Speedy = new List<Power>();
         public List<Power> Shield = new List<Power>();
         public List<Power> Shooty = new List<Power>();
         protected Vector2 location = Vector2.Zero;
         protected Vector2 velocity = Vector2.Zero;
         public Power power;
         public PlayerManager playerManager;
         

         private Rectangle screenBounds;

         private int level = 0;

         private Random rand = new Random((int)DateTime.UtcNow.Ticks);

             public PowerUPManger(Vector2 location, Texture2D textureSpeedy, Texture2D textureShield, Texture2D textureShooty, Rectangle initialFrame, Vector2 velocity, Rectangle screenBounds, PlayerManager playerManager)
             {
                 this.textureShooty = textureShooty;
                 this.textureSpeedy = textureSpeedy;
                 this.textureShield = textureShield;
                 this.initialFrame = initialFrame;
                 this.location = location;
                 this.velocity = velocity;
                 this.screenBounds = screenBounds;
                 this.playerManager = playerManager;
             }

             public void StartSpeed()
             {
                 playerManager.playerSpeed += 240.0f;
             }

             public void FinishSpeed()
             {
                 playerManager.playerSpeed -= 240.0f;
             }

             public void StartShield()
             {
                 playerManager.Invincibility = true;
             }

             public void FinishShield()
             {
                 playerManager.Invincibility = false;
             }

             public void StartShooty()
             {
                 playerManager.minShotTimer -= 6;
             }

             public void FinishShooty()
             {
                 playerManager.minShotTimer += 6;
             }



             public void SpawnSpeedy()
             {
                 Power Fast = new Power(location, textureSpeedy, new Rectangle(37, 63, 31, 69), new Vector2(0, 30), 10);

                 Fast.OnStart = new Handler(this.StartSpeed); 
                 Fast.OnFinish = new Handler(this.FinishSpeed);

                 Speedy.Add(Fast);
             }
             public void SpawnShield()
             {
                 Power Protect = new Power(location, textureShield, new Rectangle(102, 142, 38, 38), new Vector2(0, 30), 30);

                 Protect.OnStart = new Handler(this.StartShield);
                 Protect.OnFinish = new Handler(this.FinishShield);

                 Shield.Add(Protect);
             }
             public void SpawnShooty()
             {
                 Power Shoot = new Power(location, textureShooty, new Rectangle(97, 134, 48, 52), new Vector2(0, 30), 15);

                 Shoot.OnStart = new Handler(this.StartShooty);
                 Shoot.OnFinish = new Handler(this.FinishShooty);

                 Shooty.Add(Shoot);
             }


             public void Clear()
             {
                 Shield.Clear();
                 Shooty.Clear();
                 Speedy.Clear();
             }

        
             public void Update(GameTime gameTime)
             {

                      if ((playerManager.PlayerScore == 300 && level == 0) ||
                         (playerManager.PlayerScore == 600 && level == 1) ||
                         (playerManager.PlayerScore == 1200 && level == 2) ||
                         (playerManager.PlayerScore == 2400 && level == 3) ||
                         (playerManager.PlayerScore == 4800 && level == 4)
                         )
                     {
                         int selection = rand.Next(1, 4);
                         level++;

                         switch (selection)
                         {
                             case 1: SpawnSpeedy();
                                 break;

                             case 2: SpawnShield();
                                 break;

                             case 3: SpawnShooty();
                                 break;
                         }

                     }
             }

             public void Draw(SpriteBatch spriteBatch)
             {

                 foreach (Power Fast in Speedy)
                 {
                     Fast.Draw(spriteBatch);
                 }
                 foreach (Power Protect in Shield)
                 {
                     Protect.Draw(spriteBatch);
                 }

                 foreach (Power Shoot in Shooty)
                 {
                     Shoot.Draw(spriteBatch);
                 }
             }

    }
}
