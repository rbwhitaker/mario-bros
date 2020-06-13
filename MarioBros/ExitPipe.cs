using Microsoft.Xna.Framework;

namespace MarioBros
{
    public class ExitPipe : GameObject
    {
        private static readonly Dimensions BlockDimensions = new Dimensions(0.5f, 1.5f, 0.5f, 1.5f);

        public ExitPipe(float x, float y) : this(new Vector2(x, y)) { }
        public ExitPipe(Vector2 position) : base(BlockDimensions, BlockDimensions)
        {
            Position = position;
        }

        public override void UpdateCore(GameRound round, float elapsedSeconds) { }
    }
}
