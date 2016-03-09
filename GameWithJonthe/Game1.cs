using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameWithJonthe
{
    
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;

        Texture2D monsterTexture;
        Texture2D playerTexture;

        Player player;

        Monster monster;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            



            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            monsterTexture = Content.Load<Texture2D>("Skelleton");
            playerTexture =  Content.Load<Texture2D>("player");

            monster = new Monster(monsterTexture);
            player  = new Player(playerTexture);

            

            spriteBatch = new SpriteBatch(GraphicsDevice);

            
        }

        
        protected override void UnloadContent()
        {
            
        }

        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState pressedKeys = Keyboard.GetState();

            player.update(pressedKeys);

            

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            
            monster.draw(gameTime, spriteBatch);
            player.draw(gameTime, spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
