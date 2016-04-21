﻿using System;
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

        List<Projektil> projektiler;

        Rectangle playerHitbox;

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
            arrowTexture = Content.Load<Texture2D>("Arrow");

            monster = new Monster(monsterTexture);
            player  = new Player(playerTexture);

           
            projektiler.Add(new Projektil(arrowTexture, monster.position));

            spriteBatch = new SpriteBatch(GraphicsDevice);

            
        }

        
        protected override void UnloadContent()
        {
               
        }

        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            


            KeyboardState pressedKeys = Keyboard.GetState();

            

            Vector2 playerPostition = player.update(pressedKeys);
            monster.update(playerPostition);
            foreach (Projektil item in projektiler)
            {
                item.update(playerHitbox);
            }
            

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            
            monster.draw(gameTime, spriteBatch);
             player.draw(gameTime, spriteBatch);
            foreach(Projektil item in projektiler)
            {
                item.draw(gameTime, spriteBatch);
            }
            

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
