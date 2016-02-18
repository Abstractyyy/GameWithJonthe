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

        public Monster(Texture2D monsterTexture)
        {
            spriteSheet = monsterTexture;

            sourceRectangle = new Rectangle(0, 120, 50, 60);
        }

        public void update()
        {
            
        }

        
    }
}
