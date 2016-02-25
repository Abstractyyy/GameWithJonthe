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
        Vector2 agilityAccel;

        Rectangle sourceRectangle;

        Texture2D spriteSheet;

        int HP;
        float Agility;
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

        public void update(KeyboardState pressedKeys)
        {
            // om w och eller a,d är nertryck kan man gå snett. Kan springa max agility speed. agilityAccel är hur snabbt man kan springa till max hastigheten agility
            if (pressedKeys.IsKeyDown(Keys.W))
            {
                while (speed.X < Agility)
                {
                    position.Y = position.Y += speed.Y;
                    speed.Y += (Agility / 10);

                }
                position.Y = position.Y += speed.Y;
            }

            if (pressedKeys.IsKeyDown(Keys.A))
            {
                while (speed.X < Agility)
                {
                    position.X = position.X -= speed.X;
                    speed.X += (Agility / 10);

                }
                position.X = position.X += speed.X;
                
            }

            if (pressedKeys.IsKeyDown(Keys.S))
            {
                while (speed.X < Agility)
                {
                    position.Y -= speed.Y;
                    speed.Y += (Agility / 10);

                }
                position.Y -= speed.Y;

            }

            if (pressedKeys.IsKeyDown(Keys.D))
            {
                while (speed.X < Agility)
                {
                    position.X = position.X += speed.X;
                    speed.X += (Agility / 10);

                }
                position.X = position.X += speed.X;

            }
            speed.X = 0;
            speed.Y = 0;
        }
    }
}
