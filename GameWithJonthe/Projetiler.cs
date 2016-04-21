using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameWithJonthe
{
    class Projektil
    {
        private Texture2D spriteSheet;
        public Vector2 position, velocity;
        public Texture2D arrowSprite;

        Rectangle projektil;
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

        public Projektil(Texture2D arrowTexture, Vector2 position)
        {
            this.position = new Vector2(position.X, position.Y);
            velocity = new Vector2(0, 0);
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
                if (pressedKeys.IsKeyDown(Keys.Up))
                {
                    Projektiler projectiler = new Projektiler(50, 50);
                    projektilen.Add(projectiler);
                    foreach (Projektiler projektilen in projektilen)
                    {
                        projectiler.velocity.Y = -2;
                        projektilen.update();
                    }
                }


                spriteBatch.Draw(spriteSheet, position, sourceRectangle, Color.White);
            }
        }
    }
}
