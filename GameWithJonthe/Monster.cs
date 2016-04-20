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
        //Properties
        private Texture2D spriteSheet;
        public Rectangle sourceRectangle, hitbox, wholeScreen;
        public Vector2 position, velocity, PlayerPosition;
        
        
        
        //Variables
        
        int HPmonster = 200;
        private double Elapsed = 0;
        

        #region Constants
        //sourceRectangle.Y
        const int WaH = 64; //WaH = Width and Height
        const int ShootRight = 1216;
        const int ShootLeft = 1088;
        const int ShootUp = 1024;
        const int ShootDown = 1152;
        const int WalkUp = 512;
        const int WalkLeft = 576;
        const int WalkDown = 640;
        const int WalkRight = 704;
        //To reset the animation
        const int ElapsedZero = 0;
        #endregion


        public Monster(Texture2D monsterTexture)
        {
            hitbox = new Rectangle(sourceRectangle.X, sourceRectangle.Y, WaH, WaH);
            spriteSheet = monsterTexture;
            position = new Vector2(200, 200);
            velocity = new Vector2(0, 0);
            wholeScreen = new Rectangle(0, 0, 500, 500);
            sourceRectangle = new Rectangle(sourceRectangle.X, sourceRectangle.Y, WaH, WaH);
        }

        public void update(Vector2 playerPosition)
        {
            PlayerPosition = playerPosition;
            position += velocity;   
        }
        

        public void draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Elapsed += gameTime.ElapsedGameTime.TotalMilliseconds;
            //Checks what key is pressed and sets sprite to match
            #region Movement
            KeyboardState pressedKeys = Keyboard.GetState();

            if (position.Y-PlayerPosition.Y > Math.Abs(position.X-PlayerPosition.X))
                {
                velocity.Y = -1;
                if (Elapsed > 50)
                    {
                        Elapsed = 0;
                        sourceRectangle.X += WaH;
                        if (sourceRectangle.X > 512
                                )
                        {
                            sourceRectangle.X = 0;
                        }
                    }
                    sourceRectangle.Y = WalkUp;
                          
                }
                
                if (position.Y - PlayerPosition.Y < -Math.Abs(position.X - PlayerPosition.X))
                {
                velocity.Y = 1;
                    if (Elapsed > 50)
                    {
                        Elapsed = 0;
                        sourceRectangle.X += WaH;
                        if (sourceRectangle.X > 512)
                        {
                            sourceRectangle.X = 0;
                        }
                    }
                    
                    sourceRectangle.Y = WalkDown;

                }
               if (position.X - PlayerPosition.X > Math.Abs(position.Y - PlayerPosition.Y))
                {
                velocity.X = -1;
                    if (Elapsed > 50)
                    {
                        Elapsed = 0;
                        sourceRectangle.X += WaH;
                        if (sourceRectangle.X > 512)
                        {
                            sourceRectangle.X = 0;
                        }
                    }
                    sourceRectangle.Y = WalkLeft;
          
                }
                if (position.X - PlayerPosition.X < -Math.Abs(position.Y - PlayerPosition.Y))
                {
                velocity.X = 1;
                    if (Elapsed > 50)
                    {
                        Elapsed = 0;
                        sourceRectangle.X += WaH;
                        if (sourceRectangle.X > 512)
                        {
                            sourceRectangle.X = 0;
                        }
                    }
                    sourceRectangle.Y = WalkRight;
                }
            if (position.Y == PlayerPosition.Y)
                velocity.Y = 0;
            if (position.X == PlayerPosition.X)
                velocity.X = 0;

            #endregion

            #region ShootingKeys
            if (PlayerPosition.X - position.X <= 50 && PlayerPosition.X - position.X > 0 && PlayerPosition.Y - position.Y <= 100 && PlayerPosition.Y - position.Y >= -100) 
            {
                
                if (Elapsed > 50)
                {
                    Elapsed = 0;
                    sourceRectangle.X += WaH;
                    if (sourceRectangle.X > 832-64)
                    {
                        sourceRectangle.X = 0;
                    }
                }
                sourceRectangle.Y = ShootRight;
            }
            if(PlayerPosition.X - position.X >= -50 && PlayerPosition.X - position.X < -0 && PlayerPosition.Y - position.Y <= 100 && PlayerPosition.Y - position.Y >= -100)
                {
               
                if (Elapsed > 50)
                {
                    Elapsed = 0;
                    sourceRectangle.X += WaH;
                    if (sourceRectangle.X > 832 - 64)
                    {
                        sourceRectangle.X = 0;
                    }
                }
                sourceRectangle.Y = ShootLeft;
            }
            if (PlayerPosition.Y - position.Y >= -50 && PlayerPosition.Y - position.Y < -0 && PlayerPosition.X - position.X <= 100 && PlayerPosition.X - position.X >= -100)
                {
                
                if (Elapsed > 50)
                {
                    Elapsed = 0;
                    sourceRectangle.X += WaH;
                    if (sourceRectangle.X > 832 - 64)
                    {
                        sourceRectangle.X = 0;
                    }
                }
                sourceRectangle.Y = ShootUp;
                }
            if (PlayerPosition.Y - position.Y <= 50 && PlayerPosition.Y - position.Y > 0 && PlayerPosition.X - position.X <= 100 && PlayerPosition.X - position.X >= -100)
            {
                
                if (Elapsed > 50)
                {
                    Elapsed = 0;
                    sourceRectangle.X += WaH;
                    if (sourceRectangle.X > 832-64)
                    {
                        sourceRectangle.X = 0;
                    }
                }
                sourceRectangle.Y = ShootDown;
            }
            
            
                
                #endregion
            //End of the keycheck
            spriteBatch.Draw(spriteSheet, position, sourceRectangle, Color.White);
        }
    }

   
}
