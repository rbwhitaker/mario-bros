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
        
        public MarioBrosGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

            

            base.Draw(gameTime);
        }
    }
}
