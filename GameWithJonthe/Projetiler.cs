using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameWithJonthe
{
    class Projektiler
    {
        private Texture2D spriteSheet;
        public Vector2 position, velocity;
        int WaH = 30;
        int test = 10;

        Rectangle projektil, sourceRectangle;

        public Rectangle TheArrow
        {
            get
            {
                projektil.X = (int)position.X;
                projektil.Y = (int)position.Y;
                projektil.Width = spriteSheet.Width;
                projektil.Height = spriteSheet.Height;
                return projektil;
            }
        }

        public Projektiler(Texture2D arrowTexture)
        {
            position = new Vector2(50, 500);
            velocity = new Vector2(0, 2);
            projektil = new Rectangle();
            sourceRectangle = new Rectangle(sourceRectangle.X, sourceRectangle.Y, WaH, WaH);
            spriteSheet = arrowTexture;
        }

        public void update(Rectangle playerHitbox)
        {
           
            position += velocity;
            if (playerHitbox.Intersects(projektil))
            {
                test = 0;
                
            }
        }

        public void draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            KeyboardState pressedKeys = Keyboard.GetState();

            if (pressedKeys.IsKeyDown(Keys.Right))
            {
                velocity.Y = 0;
                velocity.X = 1;
                sourceRectangle.X = 60;
            }
            if (pressedKeys.IsKeyDown(Keys.Left))
            {
                velocity.Y = -0;
                velocity.X = -1;
                sourceRectangle.X = 30;
            }
            if (pressedKeys.IsKeyDown(Keys.Up))
            {
                velocity.Y = -1;
                velocity.X = 0;
                sourceRectangle.X = 0;
            }
            if (pressedKeys.IsKeyDown(Keys.Down))
            {
                velocity.Y = 1;
                velocity.X = 0;
                sourceRectangle.X = 90;
            }


            spriteBatch.Draw(spriteSheet, position, sourceRectangle, Color.White);
        }
    }
}
