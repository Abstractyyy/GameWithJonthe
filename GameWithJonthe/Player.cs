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
        

        public Vector2 position;
        Vector2 velocity;
        Vector2 agilityAccel;

        Rectangle MonsterHitbox;

        string thisType;
        string type;

        double elapsed2;


        public Rectangle sourceRectangle, hitbox;

        Dictionary<string, Texture2D> playerTexture = new Dictionary<string, Texture2D>();

        public int playersIndex = 0;

        Texture2D spriteSheet;

        public int HP = 100;
        float Agility;
        int Mana;
              
      public  const int walkUp = 512;
      public  const int walkDown = 640;
      public  const int walkLeft = 576;
      public  const int walkRight = 704;
        int walkAnimationWidth = 8;
        int playerHitbox = 64;
        int animationSpeed = 40;

        int lastDirection;

        public Player(Dictionary<string,Texture2D> playerTextureFromGame)
        {
            playerTexture = playerTextureFromGame;

            hitbox = new Rectangle();
            position = new Vector2(50, 50);
            velocity = new Vector2(0, 0);
            sourceRectangle = new Rectangle(0, 0, 64, 64);

            spriteSheet = playerTexture["playerWithSwordTexture"];

            thisType = "bow";

        }

        public Rectangle Hitbox
        {
            get
            {
                hitbox.X = (int)position.X + 15;
                hitbox.Y = (int)position.Y + 10;
                hitbox.Width = sourceRectangle.Width - 30;
                hitbox.Height = sourceRectangle.Height - 20;
                return hitbox;
            }
        }


        double elapsed = 0;

        

        public void draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            KeyboardState pressedKeys = Keyboard.GetState();  //Checks what key is pressed


            elapsed += gameTime.ElapsedGameTime.TotalMilliseconds;

            elapsed2 += gameTime.ElapsedGameTime.TotalMilliseconds;


            

          
            #region Movement animation
            if (pressedKeys.IsKeyDown(Keys.W)|| pressedKeys.IsKeyDown(Keys.A)|| pressedKeys.IsKeyDown(Keys.S)|| pressedKeys.IsKeyDown(Keys.D))
            {
             //   sourceRectangle.Width = 64;
             //   sourceRectangle.Height = 64;
            
            }

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
                sourceRectangle.Width = 192;
                sourceRectangle.Height = 192;
                walkAnimationWidth = 8;

                if (lastDirection == walkUp)
                {
                    sourceRectangle.Y = 1344;   // tjockleck 192

                }

                if (lastDirection == walkDown)
                {
                    sourceRectangle.Y = 1728;
                  
                }

                if (lastDirection == walkLeft)
                {
                    sourceRectangle.Y = 1536;
                    
                }

                if (lastDirection == walkRight)
                {
                    sourceRectangle.Y = 1920;
                 

                }
               
            }
            #endregion





            //draws the character
            spriteBatch.Draw(spriteSheet, position, sourceRectangle, Color.White); //draws the player sprite whith white background
        }  // Gå animeringen hos spelaren

    public Vector2 update(KeyboardState pressedKeys, Rectangle monsterHitbox)
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

            MonsterHitbox = monsterHitbox;

            if (HP > 0)
            {
                if (Hitbox.Intersects(MonsterHitbox))
                {
                    if(elapsed2 > 1000)
                    {
                        elapsed2 = 0;
                    HP -= 10;
                }
            }
            }
            
            else if(HP <= 0)
            {
                sourceRectangle.Y = 64 * 20;
                if (elapsed > 100)
                {
                    elapsed = 0;
                    sourceRectangle.X += 64;
                    if (sourceRectangle.X > 64*5)
                    {
                        sourceRectangle.X = 64 * 5;
                        elapsed = 0;
                    }
                }
                //position.X = 0;
            }
            


            return position;
    }
       
}
    
}

