﻿using System;
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
        Vector2 velocity;
        Vector2 agilityAccel;

        Rectangle sourceRectangle;

        Texture2D spriteSheet;

        int HP;
        float Agility;
        int Mana;

        const int walkUp = 512;
        const int walkDown = 640;
        const int walkLeft = 576;
        const int walkRight = 704;
        const int walkAnimationWidth = 8;
        const int playerHitbox = 64;

        int lastDirection;





        double elapsed = 0;

        public Player(Texture2D playerTexture)
        {
            spriteSheet = playerTexture;


            position = new Vector2(50, 50);
            velocity = new Vector2(0, 0);
            sourceRectangle = new Rectangle(0, 0, 64, 64);
        }

        public void draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            KeyboardState pressedKeys = Keyboard.GetState();  //Checks what key is pressed


            elapsed += gameTime.ElapsedGameTime.TotalMilliseconds;




            //movement animation
            if (pressedKeys.IsKeyDown(Keys.W))  //up
            {
                sourceRectangle.Y = walkUp;
                lastDirection = walkUp;
                #region
               
                    sourceRectangle.X += playerHitbox; // moves the animation forward (the source point)


                if (sourceRectangle.X > walkAnimationWidth * playerHitbox)     //resets the animation box
                {
                    sourceRectangle.X = 0;
                }
                if (elapsed > 150)    //the animation speed
                {
                    elapsed = 0;
                }

             
                #endregion


            }
            if (pressedKeys.IsKeyDown(Keys.S))  //down
            {
                sourceRectangle.Y = walkDown;
                lastDirection = walkDown;
                #region
                if (elapsed > 150)    //the animation speed
                {
                    elapsed = 0;
                    sourceRectangle.X += playerHitbox; // moves the animation forward (the source point)


                    if (sourceRectangle.X > walkAnimationWidth * playerHitbox)     //resets the animation box
                    {
                        sourceRectangle.X = 0;
                    }
                }
                #endregion
            }
            if (pressedKeys.IsKeyDown(Keys.A))  //left
            {
                sourceRectangle.Y = walkLeft;
                lastDirection = walkLeft;
                #region 
                if (elapsed > 150)    //the animation speed
                {
                    elapsed = 0;
                    sourceRectangle.X += playerHitbox; // moves the animation forward (the source point)


                    if (sourceRectangle.X > walkAnimationWidth * playerHitbox)     //resets the animation box
                    {
                        sourceRectangle.X = 0;
                    }
                }
                #endregion 
                
            }

            if (pressedKeys.IsKeyDown(Keys.D))  //right
            {
                sourceRectangle.Y = walkRight;
                lastDirection = walkRight;
                #region
                if (elapsed > 150)    //the animation speed
                {
                    elapsed = 0;
                    sourceRectangle.X += playerHitbox; // moves the animation forward (the source point)


                    if (sourceRectangle.X > walkAnimationWidth * playerHitbox)     //resets the animation box
                    {
                        sourceRectangle.X = 0;
                    }
                }
                #endregion
            }
            //end of movement

            




            //End of the keycheck
            spriteBatch.Draw(spriteSheet, position, sourceRectangle, Color.White); //draws the player sprite whith white background
        }




    

    public void update(KeyboardState pressedKeys)
    {
        // om w och eller a,d är nertryck kan man gå snett. Kan springa max agility velocity. agilityAccel är hur snabbt man kan springa till max hastigheten agility
        if (pressedKeys.IsKeyDown(Keys.W))
        {
            while (velocity.X < Agility)
            {
                position.Y = position.Y += velocity.Y;
                velocity.Y += (Agility / 10);

            }
            position.Y = position.Y += velocity.Y;
        }

        if (pressedKeys.IsKeyDown(Keys.A))
        {
            while (velocity.X < Agility)
            {
                position.X = position.X -= velocity.X;
                velocity.X += (Agility / 10);

            }
            position.X = position.X += velocity.X;

        }

        if (pressedKeys.IsKeyDown(Keys.S))
        {
            while (velocity.X < Agility)
            {
                position.Y -= velocity.Y;
                velocity.Y += (Agility / 10);

            }
            position.Y -= velocity.Y;

        }

        if (pressedKeys.IsKeyDown(Keys.D))
        {
            while (velocity.X < Agility)
            {
                position.X = position.X += velocity.X;
                velocity.X += (Agility / 10);

            }
            position.X = position.X += velocity.X;

        }
        velocity.X = 0;
        velocity.Y = 0;
    }

}
}

