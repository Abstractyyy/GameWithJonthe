﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameWithJonthe
{
    
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;

        Texture2D monsterTexture;

        Player player;

        Monster monster;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            player = new Player();

            monster = new Monster(monsterTexture);
            
            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            monsterTexture = Content.Load<Texture2D>("Werewolf");


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

            player.update(pressedKeys);

            

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            

            base.Draw(gameTime);
        }
    }
}
