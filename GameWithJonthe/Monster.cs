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

        int test = 400;
        //Variables
        
        int HPmonster = 200;
        private double Elapsed = 0;
        private double Elapsed2 = 0;
        

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
        #region
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
        #endregion
        public Monster(Texture2D monsterTexture)
        {
            hitbox = new Rectangle();
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
            Elapsed2 += gameTime.ElapsedGameTime.TotalMilliseconds;
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

            #region ShootingAnimation
            //if (PlayerPosition.X <- Math.Abs(position.X)) 
            //{
            //    if (Elapsed2 > 200)
            //    {
            //        Elapsed2 = 0;
            //        sourceRectangle.X += WaH;
            //        if (sourceRectangle.X > 832-64)
            //        {
            //            sourceRectangle.X = 0;
            //        }
            //    }
            //    sourceRectangle.Y = ShootRight;
            //}
            //if(test == 300)
            //    {
               
            //    if (Elapsed > 200)
            //    {
            //        Elapsed = 0;
            //        sourceRectangle.X += WaH;
            //        if (sourceRectangle.X > 832 - 64)
            //        {
            //            sourceRectangle.X = 0;
            //        }
            //    }
            //    sourceRectangle.Y = ShootLeft;
            //}
            //if (test == 200)
            //    {
                
            //    if (Elapsed > 200)
            //    {
            //        Elapsed = 0;
            //        sourceRectangle.X += WaH;
            //        if (sourceRectangle.X > 832 - 64)
            //        {
            //            sourceRectangle.X = 0;
            //        }
            //    }
            //    sourceRectangle.Y = ShootUp;
            //    }
            //if (test == 100)
            //{
                
            //    if (Elapsed > 200)
            //    {
            //        Elapsed = 0;
            //        sourceRectangle.X += WaH;
            //        if (sourceRectangle.X > 832-64)
            //        {
            //            sourceRectangle.X = 0;
            //        }
            //    }
            //    sourceRectangle.Y = ShootDown;
            //}
            
            
                
                #endregion
            //End of the keycheck
            spriteBatch.Draw(spriteSheet, position, sourceRectangle, Color.White);
        }
    }

   
}
