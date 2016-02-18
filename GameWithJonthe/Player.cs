using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameWithJonthe
{
    class Player
    {
        Vector2 position;
        Vector2 speed;

        Rectangle sourceRectangle;

        Texture2D spriteBatch;

        int HP;
        int Agility;
        int Mana;



        double elapsed = 0;

        public void draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            elapsed += gameTime.ElapsedGameTime.TotalMilliseconds;

            if (elapsed > 150)
            {
                elapsed = 0;
                sourceRectangle.X += 50;
                if (sourceRectangle.X > 100)
                {
                    sourceRectangle.X = 0;
                }

                //Checks what key is pressed and sets sprite to match
                KeyboardState pressedKeys = Keyboard.GetState();

                if (pressedKeys.IsKeyDown(Keys.W))
                    sourceRectangle.Y = 0;
                if (pressedKeys.IsKeyDown(Keys.S))
                    sourceRectangle.Y = 120;
                if (pressedKeys.IsKeyDown(Keys.A))
                    sourceRectangle.Y = 180;
                if (pressedKeys.IsKeyDown(Keys.D))
                    sourceRectangle.Y = 60;
                //End of the keycheck
            }
            spriteBatch.Draw(spriteSheet, position, sourceRectangle, Color.White);
        }

        



    }
}
