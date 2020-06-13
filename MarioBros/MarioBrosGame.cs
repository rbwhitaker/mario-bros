using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MarioBros
{
    public class MarioBrosGame : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private GameRound gameRound;
        private BasicRenderer renderer;
        Song backgroundMusic;
        
        private const float PixelsPerUnit = 16;

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
            renderer = new BasicRenderer(Content);
            backgroundMusic = Content.Load<Song>("Ragtime");
            MediaPlayer.Play(backgroundMusic);
        }

        private GameRound GenerateGameRound()
        {
            GameRound gameRound = new GameRound();

            /*
            gameRound.Add(new PlayerCharacter(KeyboardControls.Player1) { Position = new Vector2(1, 10) });
            //gameRound.Add(new Shellcreeper() { Position = new Vector2(20, 10), Direction = Direction.Left });
            //gameRound.Add(new Shellcreeper() { Position = new Vector2(20, 10), Direction = Direction.Right });

            for(int column = 0; column < 32; column++)
            {
                gameRound.Add(new Block(0.5f + column, 0.5f));
                gameRound.Add(new Block(0.5f + column, 1.5f));
            }
            
            gameRound.Add(new Block(0.5f, 7.5f));
            gameRound.Add(new Block(1.5f, 7.5f));
            gameRound.Add(new Block(2.5f, 7.5f));
            */

            LevelLoader loader = new LevelLoader(File.ReadAllText("level.txt"));
            loader.LoadLevel(gameRound);

            //gameRound.Add(new Block(11.5f, 7.5f));
            //gameRound.Add(new Block(12.5f, 7.5f));
            //gameRound.Add(new Block(13.5f, 7.5f));
            //gameRound.Add(new Block(14.5f, 7.5f));
            //gameRound.Add(new Block(15.5f, 7.5f));

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
            if (Keyboard.GetState().IsKeyDown(Keys.F11)) graphics.ToggleFullScreen();

            gameRound.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

            if (MediaPlayer.State == MediaState.Stopped) MediaPlayer.Play(backgroundMusic);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
                renderer.Render(gameRound, spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}
