using Microsoft.Xna.Framework;

namespace MarioBros
{
    public class Brick : Block
    {
        private static readonly Dimensions BrickDimensions = new Dimensions(0.5f);

        public Brick(float x, float y) : this(new Vector2(x, y)) { }
        public Brick(Vector2 position) : base(position)
        {
            Position = position;
        }

        public override void UpdateCore(GameRound round, float elapsedSeconds) { }
    }
}
