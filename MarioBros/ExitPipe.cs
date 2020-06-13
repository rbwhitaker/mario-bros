using Microsoft.Xna.Framework;

namespace MarioBros
{
    public class ExitPipe : GameObject
    {
        private static readonly Dimensions ExitPipeDisplayDimensions = new Dimensions(0.5f, 1.5f, 0.5f, 1.5f);
        private static readonly Dimensions ExitPipePhysicsDimensions = new Dimensions(0f, 1f, 0f, 1f);

        public ExitPipe(float x, float y) : this(new Vector2(x, y)) { }
        public ExitPipe(Vector2 position) : base(ExitPipeDisplayDimensions, ExitPipePhysicsDimensions)
        {
            Position = position;
        }

        public override void UpdateCore(GameRound round, float elapsedSeconds) { }
    }
}
