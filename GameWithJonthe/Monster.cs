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
        private Rectangle sourceRectangle, hitbox;
        private Vector2 position, velocity;
        
        //Variables
        int HPmonster = 200;
        private double Elapsed = 0;
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


        public Monster(Texture2D monsterTexture)
        {
            hitbox = new Rectangle(sourceRectangle.X, sourceRectangle.Y, WaH, WaH);
            spriteSheet = monsterTexture;
            position = new Vector2(200, 200);
            velocity = new Vector2(0, 0);
            sourceRectangle = new Rectangle(sourceRectangle.X, sourceRectangle.Y, WaH, WaH);
        }

        public void update()
        {
            position += velocity;   
        }

        string pressed;

        public void draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
          

            //If statement showing what animation should be showing and when
            
                //Checks what key is pressed and sets sprite to match
                #region Movement
                KeyboardState pressedKeys = Keyboard.GetState();

                if (pressedKeys.IsKeyDown(Keys.W))
                {
                    Elapsed += gameTime.ElapsedGameTime.TotalMilliseconds;
                    if (Elapsed > 150)
                    {
                        Elapsed = 0;
                        sourceRectangle.X += WaH;
                        if (sourceRectangle.X > 512)
                        {
                            sourceRectangle.X = 0;
                        }
                    }
                    Elapsed = ElapsedZero;
                    sourceRectangle.Y = WalkUp;
                    pressed = "W";
                }
                if (pressedKeys.IsKeyDown(Keys.S))
                {
                    Elapsed += gameTime.ElapsedGameTime.TotalMilliseconds;
                    if (Elapsed > 150)
                    {
                        Elapsed = 0;
                        sourceRectangle.X += WaH;
                        if (sourceRectangle.X > 512)
                        {
                            sourceRectangle.X = 0;
                        }
                    }
                    Elapsed = ElapsedZero;
                    sourceRectangle.Y = WalkDown;
                    pressed = "S";
                }
                if (pressedKeys.IsKeyDown(Keys.A))
                {
                    Elapsed += gameTime.ElapsedGameTime.TotalMilliseconds;
                    if (Elapsed > 150)
                    {
                        Elapsed = 0;
                        sourceRectangle.X += WaH;
                        if (sourceRectangle.X > 512)
                        {
                            sourceRectangle.X = 0;
                        }
                    }
                    Elapsed = ElapsedZero;
                    sourceRectangle.Y = WalkLeft;
                    pressed = "A";
                }
                if (pressedKeys.IsKeyDown(Keys.D))
                {
                    Elapsed += gameTime.ElapsedGameTime.TotalMilliseconds;
                    if (Elapsed > 150)
                    {
                        Elapsed = 0;
                        sourceRectangle.X += WaH;
                        if (sourceRectangle.X > 512)
                        {
                            sourceRectangle.X = 0;
                        }
                    }
                    Elapsed = ElapsedZero;
                    sourceRectangle.Y = WalkRight;
                    pressed = "D";
                }
                else
#endregion

                #region ShootingKeys
                if (pressed == "D" && pressedKeys.IsKeyDown(Keys.K))
                {
                    Elapsed = ElapsedZero;
                    sourceRectangle.Y = ShootRight;
                }
                if(pressed == "A" && pressedKeys.IsKeyDown(Keys.K))
                {
                    Elapsed = ElapsedZero;
                    sourceRectangle.Y = ShootLeft;
                }
                if (pressed == "W" && pressedKeys.IsKeyDown(Keys.K))
                {
                    Elapsed = ElapsedZero;
                    sourceRectangle.Y = ShootUp;
                }
                if (pressed == "S" && pressedKeys.IsKeyDown(Keys.K))
                {
                    Elapsed = ElapsedZero;
                    sourceRectangle.Y = ShootDown;
                }
                #endregion
                //End of the keycheck
            spriteBatch.Draw(spriteSheet, position, sourceRectangle, Color.White);
        }
    }
}
