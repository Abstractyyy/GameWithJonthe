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
        int WaH = 30;

        int test = 1;

        int shootDirection;

        public Rectangle projektil, sourceRectangle, PlayerHitbox;

        public Rectangle Hitbox
        {
            get
            {
                projektil.X = (int)position.X;
                projektil.Y = (int)position.Y;
                projektil.Width = sourceRectangle.Width;
                projektil.Height =  sourceRectangle.Height;
                return projektil;
            }
        }

        public Projektil(Texture2D arrowTexture, Vector2 position, int ShootDirection)
        {
            this.position = new Vector2(position.X, position.Y);
            velocity = new Vector2(0, 2);
            projektil = new Rectangle();
            sourceRectangle = new Rectangle(sourceRectangle.X, sourceRectangle.Y, WaH, WaH);
            spriteSheet = arrowTexture;
            shootDirection = ShootDirection;
        }

        public void update(Rectangle playerHitbox)
        {
            PlayerHitbox = playerHitbox;

            position += velocity;
        }

        public void draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            KeyboardState pressedKeys = Keyboard.GetState();

            if (shootDirection == 2)
            {
                velocity.Y = 0;
                velocity.X = 3;
                sourceRectangle.X = 60;
            }
            if (shootDirection == 1)
            {
                velocity.Y = -0;
                velocity.X = -3;
                sourceRectangle.X = 30;
            }
            if (shootDirection == 3)
            {
                velocity.Y = -3;
                velocity.X = 0;
                sourceRectangle.X = 0;
            }
            if (shootDirection == 4)
            {
                velocity.Y = 3;
                velocity.X = 0;
                sourceRectangle.X = 90;
            }


            spriteBatch.Draw(spriteSheet, position, sourceRectangle, Color.White);
        }
    }
}