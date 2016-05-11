using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameWithJonthe
{
    
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;

        Texture2D monsterTexture;
        Texture2D Ee;
        Texture2D youDead;

        Texture2D playerTexture;
        Texture2D playerWithSwordTexture;
        Texture2D playerWithWandTexture;
        Texture2D playerWithSpearTexture;
        Texture2D playerWithTreuddTexture;

        Dictionary<string,Texture2D> playerTextures = new Dictionary<string, Texture2D>();
        int playersIndex = 0;

        //Dessa Int är för att projektilerna ska veta åt vilket håll de ska skjutas
        int Left = 1;
        int Right = 2;
        int Up = 3;
        int Down = 4;
        int ShootDirection;

        double elapsed;
        double elapsed2;

        Texture2D arrowTexture;

        Rectangle playerHitbox, monsterHitbox;

        List<Projektil> projektiler;
        
        Player player;
        PlayerWithSword playerWithSword;
        PlayerWithWand playerWithWand;

        List<Monster> monsters;
        
        //En bool för easter egg
        bool EE = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 500;
            graphics.PreferredBackBufferWidth = 500;
        }

        
        protected override void Initialize()
        {

            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            KeyboardState pressedKeys = Keyboard.GetState();
         


            playerTextures["playerTexture"]             = Content.Load<Texture2D>("playerWithSword");                          
            playerTextures["playerWithSwordTexture"]    = Content.Load<Texture2D>("playerWithSpear");                          
            playerTextures["playerWithSpearTexture"]    = Content.Load<Texture2D>("playerWithWand");                           
            playerTextures["playerWithWandTexture"]     = Content.Load<Texture2D>("playerWithWand");                                
            playerTextures["playerWithTreuddTexture"]   = Content.Load<Texture2D>("playerTreudd");                             
                
            arrowTexture = Content.Load<Texture2D>("Arrow");

            monsterTexture = Content.Load<Texture2D>("Skelly");

            youDead = Content.Load<Texture2D>("YouDead");

            monsters = new List<Monster>();
            
            player  = new Player(playerTextures);


            /*
            List<Player> Players = new List<Player>(3);

            Player player = new Player(playerTexture);
            Players.Add(player);

            Player playerSword = new Player(playerWithSwordTexture);
            Players.Add(playerSword);

            Player playerWand = new Player(playerWithWandTexture);
            Players.Add(playerWand);
            */

            Ee = Content.Load<Texture2D>("EE");

            projektiler = new List<Projektil>();

            spriteBatch = new SpriteBatch(GraphicsDevice);


    }

        
        protected override void UnloadContent()
        {
            
        }

        
        protected override void Update(GameTime gameTime)
        {

            KeyboardState pressedKeys = Keyboard.GetState();
            elapsed2 += gameTime.ElapsedGameTime.TotalMilliseconds;



            Vector2 playerPostition = player.update(pressedKeys, monsterHitbox);
            //  playerPostition = playerWithSword.update(pressedKeys);
            playerHitbox = player.Hitbox;

            
                if (elapsed2 >= 3000)
                {
                    monsters.Add(new Monster(monsterTexture));
                    elapsed2 = 0;
                }
            

            foreach (Monster monsters in monsters)
            {
                monsters.update(playerPostition);
            }

            foreach(Monster monsters in monsters)
            {
                monsterHitbox = monsters.Hitbox;
            }
            
            if (pressedKeys.IsKeyDown(Keys.E))
                EE = true;
            else
                EE = false;

            //uppdaterar varje pil så att de känner av player hitbox
            foreach (Projektil projektil in projektiler)
            {
                projektil.update(playerHitbox);
            }


            for (int i = 0; i<projektiler.Count; i++)
            {
                for(int j = 0; j< monsters.Count; j++)
                {
                    if (projektiler[i].Hitbox.Intersects(monsters[j].Hitbox))
                    {
                        projektiler.RemoveAt(i);
                        monsters.RemoveAt(j);
                    }
                }
            }
            
            for(int i = 0; i<projektiler.Count; i++)
            {
                if (projektiler[i].position.X > 480 || projektiler[i].position.X < 0 || projektiler[i].position.Y < 0 || projektiler[i].position.Y > 480)
                {
                    projektiler.RemoveAt(i);  
                }
            }
            
            #region Shoot arrow
            if (pressedKeys.IsKeyDown(Keys.Left))
            {
                ShootDirection = Left;
                elapsed += gameTime.ElapsedGameTime.TotalMilliseconds;
                if (elapsed >= 500)
                {
                    projektiler.Add(new Projektil(arrowTexture, player.position, ShootDirection));
                    elapsed = 0;
                }
            }
            if (pressedKeys.IsKeyDown(Keys.Right))
            {
                ShootDirection = Right;
                elapsed += gameTime.ElapsedGameTime.TotalMilliseconds;
                if (elapsed >= 500)
                {
                    projektiler.Add(new Projektil(arrowTexture, player.position, ShootDirection));
                    elapsed = 0;
                }
            }
            if (pressedKeys.IsKeyDown(Keys.Up))
            {
                ShootDirection = Up;
                elapsed += gameTime.ElapsedGameTime.TotalMilliseconds;
                if (elapsed >= 500)
                {
                    projektiler.Add(new Projektil(arrowTexture, player.position, ShootDirection));
                    elapsed = 0;
                }
            }

            
            
                ShootDirection = Down;
                
                if (pressedKeys.IsKeyDown(Keys.Down))
                {
                    elapsed += gameTime.ElapsedGameTime.TotalMilliseconds;
                    ShootDirection = Down;
                    if(elapsed >= 500)
                    {
                        projektiler.Add(new Projektil(arrowTexture, player.position, ShootDirection));
                        elapsed = 0;
                    }
                    
                }
            

            #endregion

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            KeyboardState pressedKeys = Keyboard.GetState();


            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            player.draw(gameTime, spriteBatch);

            foreach (Monster monsters in monsters)
            {
                monsters.draw(gameTime, spriteBatch);
            }
            
            //Ritar ut texturen för varje pil
            foreach (Projektil item in projektiler)
            {
                item.draw(gameTime, spriteBatch);
            }

            #region easter egg
            if (EE == true)
            {
                spriteBatch.Draw(Ee, Vector2.Zero, Color.White);
            }
            if (player.HP <= 0)
            {
                spriteBatch.Draw(youDead, Vector2.Zero, Color.White);
            }
            #endregion

            spriteBatch.End();
            base.Draw(gameTime);
        }    
        
    }
}
