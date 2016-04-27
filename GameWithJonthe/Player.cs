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
        Game1 game1;
        Player player;
        

        Vector2 position;
        Vector2 velocity;
        Vector2 agilityAccel;

        string thisType;
        string type;


        public Rectangle sourceRectangle, hitbox;

        Dictionary<string, Texture2D> playerTexture = new Dictionary<string, Texture2D>();

        public int playersIndex = 0;

        Texture2D spriteSheet;

        int HP = 50000;
        float Agility;
        int Mana;
              
      public  const int walkUp = 512;
      public  const int walkDown = 640;
      public  const int walkLeft = 576;
      public  const int walkRight = 704;
        const int walkAnimationWidth = 8;
        const int playerHitbox = 64;
        const int animationSpeed = 40;

        int lastDirection;

        public Player(Dictionary<string,Texture2D> playerTextureFromGame)
        {
            playerTexture = playerTextureFromGame;

            hitbox = new Rectangle();
            position = new Vector2(50, 50);
            velocity = new Vector2(0, 0);
            sourceRectangle = new Rectangle(0, 0, 64, 64);

            spriteSheet = playerTexture["playerTexture"];

            thisType = "bow";

        }

        public Rectangle Hitbox
        {
            get
            {
                hitbox.X = (int)position.X;
                hitbox.Y = (int)position.Y;
                hitbox.Width = sourceRectangle.Width;
                hitbox.Height = sourceRectangle.Height;
                return hitbox;
            }
        }


        double elapsed = 0;

        

        public void draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            KeyboardState pressedKeys = Keyboard.GetState();  //Checks what key is pressed


            elapsed += gameTime.ElapsedGameTime.TotalMilliseconds;



            

          
            #region Movement animation
            
            if (pressedKeys.IsKeyDown(Keys.W))  //up
            {
                sourceRectangle.Y = walkUp;
                lastDirection = walkUp; // visar att det sista hållet som spelaren gick åt ska vara det hållet som spelaren står åt
                #region

                //  sourceRectangle.X += playerHitbox; // moves the animation forward (the source point)

                if (elapsed > animationSpeed)    //the animation speed
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
            if (pressedKeys.IsKeyDown(Keys.S))  //down
            {
                sourceRectangle.Y = walkDown;
                lastDirection = walkDown;
                #region
                if (elapsed > animationSpeed)    //the animation speed
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
                if (elapsed > animationSpeed)    //the animation speed
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
                if (elapsed > animationSpeed)    //the animation speed
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
            #endregion

            #region AttackMovement
            if (pressedKeys.IsKeyDown(Keys.Space))
            {
                if (lastDirection == walkUp)
                {
                    sourceRectangle.Y = 1024;
                }

                if (lastDirection == walkDown)
                {
                    sourceRectangle.Y = 1152;
                }

                if (lastDirection == walkLeft)
                {
                    sourceRectangle.Y = 1088;
                }

                if (lastDirection == walkRight)
                {
                    sourceRectangle.Y = 1216;
                }
            }
            #endregion





            //draws the character
            spriteBatch.Draw(spriteSheet, position, sourceRectangle, Color.White); //draws the player sprite whith white background
        }  // Gå animeringen hos spelaren

    public Vector2 update(KeyboardState pressedKeys)
    {
            velocity.Y = 2;
            velocity.X = 2;
            
            #region movement
        // om w och eller a,d är nertryck kan man gå snett. Kan springa max agility velocity. agilityAccel är hur snabbt man kan springa till max hastigheten agility
        if (pressedKeys.IsKeyDown(Keys.W))
        {
                position.Y = position.Y -= velocity.Y;
        }

        if (pressedKeys.IsKeyDown(Keys.S))
        {
                position.Y = position.Y += velocity.Y;

        }

        if (pressedKeys.IsKeyDown(Keys.A))
        {
                position.X = position.X -= velocity.X;

        }

        if (pressedKeys.IsKeyDown(Keys.D))
        {
                position.X = position.X += velocity.X;

        }
        velocity.X = 0;
        velocity.Y = 0;
            #endregion


            if (pressedKeys.IsKeyDown(Keys.D1))
            {
                spriteSheet = playerTexture["playerTexture"];
            }
            if (pressedKeys.IsKeyDown(Keys.D2))
            {
                spriteSheet = playerTexture["playerWithSwordTexture"];
            }
            if (pressedKeys.IsKeyDown(Keys.D3))
            {
                spriteSheet = playerTexture["playerWithSpearTexture"];
            }


            return position;
    }
    
    
    
    

       
}
    
}

