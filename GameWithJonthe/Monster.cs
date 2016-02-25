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
        //Variables
        int Health = 200;
        double Elapsed = 0;

        public Monster(Texture2D monsterTexture)
        {
            spriteSheet = monsterTexture;

            sourceRectangle = new Rectangle(0, 120, 50, 60);
        }

        public void update()
        {
            
        }

        public void draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Elapsed += gameTime.ElapsedGameTime.TotalMilliseconds;

            if (Elapsed > 150)
            {
                Elapsed = 0;
                sourceRectangle.X
            }
        }
    }
}
