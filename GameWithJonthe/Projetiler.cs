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
        public Texture2D arrowSprite;
        Rectangle projektil;

        public Rectangle TheArrow
        {
            get
            {
                projektil.X = (int)position.X;
                projektil.Y = (int)position.Y;
                projektil.Width = arrowSprite.Width;
                projektil.Height = arrowSprite.Height;
                return projektil;
            }
        }

        public Projektiler(float velocityX, float velocityY)
        {
            position = new Vector2(position.X, position.Y);
            velocity = new Vector2(0, 2);
            projektil = new Rectangle();
        }

        public void update()
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

            position += velocity;
        }
    }
}
