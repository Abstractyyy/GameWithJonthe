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

        Texture2D playerTexture;
        Texture2D playerWithSwordTexture;
        Texture2D playerWithWandTexture;
        Texture2D playerWithSpearTexture;
        Texture2D playerWithTreuddTexture;

        List<Texture2D> playerTextures;
        int playersIndex = 0;

        Texture2D arrowTexture;

        Rectangle playerHitbox;

        List<Projektil> projektiler;
        


        Player player;
        PlayerWithSword playerWithSword;
        PlayerWithWand playerWithWand;

        Monster monster;

        




        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {

            base.Initialize();
        }

        
        protected override void LoadContent()
        {
               
            monsterTexture = Content.Load<Texture2D>("Skelly");

        playerTextures[0]     = Content.Load<Texture2D>("playerBow");                                  // playerTexture          
        playerTextures[1]     = Content.Load<Texture2D>("playerWithSword");                             // playerWithSwordTexture 
        playerTextures[2]     = Content.Load<Texture2D>("playerWithSpear");                             // playerWithSpearTexture 
        playerTextures[3]     = Content.Load<Texture2D>("playerWithWand");                              // playerWithWandTexture  
        playerTextures[4]     = Content.Load<Texture2D>("playerTreudd");                                // playerWithTreuddTexture
                
            arrowTexture = Content.Load<Texture2D>("Arrow");

           




            monster = new Monster(monsterTexture);
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




            projektiler = new List<Projektil>();



            projektiler = new List<Projektil>();

            projektiler.Add(new Projektil(arrowTexture, monster.position));

            spriteBatch = new SpriteBatch(GraphicsDevice);


          

    }

        
        protected override void UnloadContent()
        {
            
        }

        
        protected override void Update(GameTime gameTime)
        {

            KeyboardState pressedKeys = Keyboard.GetState();

            Vector2 playerPostition = player.update(pressedKeys);
            //  playerPostition = playerWithSword.update(pressedKeys);
 
            monster.update(playerPostition);

            playerHitbox = player.Hitbox;
            

            //uppdaterar varje pil så att de känner av player hitbox
            foreach (Projektil projektil in projektiler)
            {
                projektil.update(playerHitbox);
            }
            

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            
            monster.draw(gameTime, spriteBatch);
            player.draw(gameTime, spriteBatch);

            //Ritar ut texturen för varje pil
            foreach (Projektil item in projektiler)
            {
                item.draw(gameTime, spriteBatch);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }


        
        
        
            


            
        
    }
}
