using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameWithJonthe
{
    class Monster
    {
        Texture2D spriteSheet;
        Rectangle sourceRectangle;
        Vector2 position, velocity;
        //Variables
        int Health = 200;
        double Elapsed = 0;

        public Monster(Texture2D monsterTexture)
        {
            spriteSheet = monsterTexture;
            position = new Vector2(50, 50);
            velocity = new Vector2(0, 0);
            sourceRectangle = new Rectangle(0, 0, 50, 50);

           
        }

        public void update()
        {
            position += velocity;   
        }

        public void draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Elapsed += gameTime.ElapsedGameTime.TotalMilliseconds;

            if (Elapsed > 150)
            {
                Elapsed = 0;
                sourceRectangle.Y += 50;
                if (sourceRectangle.Y > 150)
                {
                    sourceRectangle.Y = 0;
                }
                //Checks what key is pressed and sets sprite to match
                KeyboardState pressedKeys = Keyboard.GetState();

                if (pressedKeys.IsKeyDown(Keys.W))
                {
                    Elapsed = 0;
                    sourceRectangle.X = 150;
                }
                if (pressedKeys.IsKeyDown(Keys.S))
                {
                    Elapsed = 0;
                    sourceRectangle.X = 50;
                }
                if (pressedKeys.IsKeyDown(Keys.A))
                {
                    Elapsed = 0;
                    sourceRectangle.X = 0;
                }
                if (pressedKeys.IsKeyDown(Keys.D))
                {
                    Elapsed = 0;
                    sourceRectangle.X = 100;
                }


               
                //End of the keycheck
            }
            spriteBatch.Draw(spriteSheet, position, sourceRectangle, Color.White);
        }
    }
}
