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
        Vector2 position, velocity;
        Texture2D spriteBatch;
        Rectangle sourceRectangle;

        public Monster()
        {
            position = new Vector2(50, 50);
            velocity = new Vector2(0, 0);
            sourceRectangle = new Rectangle(0, 120, 50, 60);
        }

        public void update()
        {
            position += velocity;
        }


    }
}
