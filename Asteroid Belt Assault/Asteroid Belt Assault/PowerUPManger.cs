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
         private Texture2D texture;
         private Rectangle initialFrame;
         public List<Power> Speedy = new List<Power>();
         public List<Power> Shield = new List<Power>();
         public List<Power> Shooty = new List<Power>();
         protected Vector2 location = Vector2.Zero;
         protected Vector2 velocity = Vector2.Zero;
         public ShotManager PowShotManager;
         public PlayerManager playManager;

         private Rectangle screenBounds;

         private Random rand = new Random((int)DateTime.UtcNow.Ticks);

             public PowerUPManger(Vector2 location, Texture2D texture, Rectangle initialFrame, Vector2 velocity, ref Rectangle screenBounds)
             {
                 this.texture = texture;
                 this.initialFrame = initialFrame;
                 this.location = location;
                 this.velocity = velocity;
                 this.screenBounds = screenBounds;

                 PowShotManager = new ShotManager(texture, new Rectangle(0, 300, 5, 5), 4, 2, 150f, screenBounds);
             }

             public void SpawnSpeedy()
             {
                 Power Fast = new Power(location, texture, new Rectangle(106, 51, 107, 196), new Vector2(0, 30));
                 Speedy.Add(Fast);
             }
             public void SpawnShield()
             {
                 Power Protect = new Power(location, texture, new Rectangle(0, 0, 200, 191), new Vector2(0, 30));
                 Shield.Add(Protect);
             }
             public void SpawnShooty()
             {
                 Power Shoot = new Power(location, texture, new Rectangle(262, 163, 136, 141), new Vector2(0, 30));
                 Shooty.Add(Shoot);
             }

        
             public void Update(GameTime gameTime)
             {
                if(playManager.PlayerScore == 500)
                  {
                      int selection = rand.Next(1, 3);
                      switch (selection)
                       {
                          case 1: SpawnSpeedy();
                               break;

                          case 2: SpawnShield();
                               break;

                          case 3: SpawnShield();
                               break;
                       }
                  } 
             }

             public void Draw(SpriteBatch spriteBatch)
             {
                 PowShotManager.Draw(spriteBatch);

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
