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
        Texture2D playerWithSwordTexture;
        Texture2D playerWithWandTexture;

        Texture2D arrowTexture;

        List<Projektil> projektiler;

        Rectangle playerHitbox;

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
            playerTexture =  Content.Load<Texture2D>("playerBow");

            monster = new Monster(monsterTexture);
            player  = new Player(playerTexture);
            projektiler = new List<Projektil>();

            foreach (Projektil item in projektiler)
            {
                arrowTexture = Content.Load<Texture2D>("Arrow");
            }

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

            //uppdaterar varje pil så att de känner av player hitbox
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

            //Ritar ut texturen för varje pil
            foreach (Projektil item in projektiler)
            {
                item.draw(gameTime, spriteBatch);
            }


            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void changeWeapon(string type,string callerType)
        {
             

            if (type == callerType)
                return;

            if (type == "bow")
                player = new Player(playerTexture);
            else if (type == "sword")
                playerWithSword = new PlayerWithSword(playerWithSwordTexture);
               
            
        }
    }
}
