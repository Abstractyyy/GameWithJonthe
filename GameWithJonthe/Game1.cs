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

        Texture2D arrowTexture;

        List<Projektiler> projektilen;

        Player player;

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
            playerTexture =  Content.Load<Texture2D>("playerBow");

            projektilen = new List<Projektiler>();

            for (int i = 0; i < projektilen.Count; i++)
            {
                arrowTexture = projektilen[i].arrowSprite = Content.Load<Texture2D>("LinkArrow");//Loads the texture for each LinkArrow   
            }

            monster = new Monster(monsterTexture);
            player  = new Player(playerTexture);

            spriteBatch = new SpriteBatch(GraphicsDevice);

            
        }

        
        protected override void UnloadContent()
        {
            
        }

        
        protected override void Update(GameTime gameTime)
        {
            
            


            KeyboardState pressedKeys = Keyboard.GetState();



            Vector2 playerPostition = player.update(pressedKeys);
            monster.update(playerPostition);
            

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            
            monster.draw(gameTime, spriteBatch);
             player.draw(gameTime, spriteBatch);

            foreach (Projektiler projektilen in projektilen)
            {
                spriteBatch.Draw(projektilen.arrowSprite, monster.position , Color.White);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
