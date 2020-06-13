using Microsoft.Xna.Framework;

namespace MarioBros
{
    public class Block : GameObject
    {
        private static readonly Dimensions BlockDimensions = new Dimensions(0.5f);

        public Block(float x, float y) : this(new Vector2(x, y)) { }
        public Block(Vector2 position) : base(BlockDimensions, BlockDimensions)
        {
            Position = position;
        }

        public override void UpdateCore(GameRound round, float elapsedSeconds) { }
    }
}
