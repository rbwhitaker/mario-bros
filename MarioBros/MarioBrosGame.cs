using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MarioBros
{
    public class MarioBrosGame : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private GameRound gameRound;
        private Texture2D simpleRectangle;
        
        public MarioBrosGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = (int)(32 * PixelsPerUnit);
            graphics.PreferredBackBufferHeight = (int)(25 * PixelsPerUnit);
        }

        protected override void Initialize()
        {
            base.Initialize();
            gameRound = GenerateGameRound();
        }

        private GameRound GenerateGameRound()
        {
            GameRound gameRound = new GameRound();

            gameRound.Add(new PlayerCharacter() { Position = new Vector2(1, 10) });

            gameRound.Add(new Block(0.5f, 0.5f));
            gameRound.Add(new Block(1.5f, 0.5f));
            gameRound.Add(new Block(2.5f, 0.5f));
            gameRound.Add(new Block(3.5f, 0.5f));
            gameRound.Add(new Block(4.5f, 0.5f));

            gameRound.Add(new Block(0.5f, 7.5f));
            gameRound.Add(new Block(1.5f, 7.5f));
            gameRound.Add(new Block(2.5f, 7.5f));

            return gameRound;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            simpleRectangle = Content.Load<Texture2D>("Rectangle16");
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            gameRound.Update(gameTime.ElapsedGameTime.TotalSeconds);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            foreach(GameObject gameObject in gameRound.Objects)
            {
                if (gameObject is Block b) DrawBlock(b);
                if (gameObject is PlayerCharacter c) DrawPlayerCharacter(c);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawPlayerCharacter(PlayerCharacter c)
        {
            Box visualBox = c.VisualBox;
            Rectangle bounds = ToPixels(visualBox);
            spriteBatch.Draw(simpleRectangle, bounds, Color.White);
        }


        private const float PixelsPerUnit = 16;

        private void DrawBlock(Block b)
        {
            Box visualBox = b.VisualBox;
            Rectangle bounds = ToPixels(visualBox);
            spriteBatch.Draw(simpleRectangle, bounds, Color.Blue);
        }

        private Rectangle ToPixels(Box box)
        {
            return new Rectangle((int)(box.Left * PixelsPerUnit), (int)(box.Bottom * PixelsPerUnit), (int)(box.Width * PixelsPerUnit), (int)(box.Height * PixelsPerUnit));
        }
    }
}
