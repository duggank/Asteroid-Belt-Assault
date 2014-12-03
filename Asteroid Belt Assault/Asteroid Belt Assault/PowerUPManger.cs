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

             public void SpawnSpeedy()
             {
                 Power Fast = new Power(location, textureSpeedy, new Rectangle(106, 51, 107, 196), new Vector2(0, 30));
                 Speedy.Add(Fast);
             }
             public void SpawnShield()
             {
                 Power Protect = new Power(location, textureShield, new Rectangle(0, 0, 200, 191), new Vector2(0, 30));
                 Shield.Add(Protect);
             }
             public void SpawnShooty()
             {
                 Power Shoot = new Power(location, textureShooty, new Rectangle(262, 163, 136, 141), new Vector2(0, 30));
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
                 if ((playerManager.PlayerScore == 500 && level == 0)  ||
                     (playerManager.PlayerScore == 1000 && level == 1)
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
