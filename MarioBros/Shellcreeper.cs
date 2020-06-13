using Microsoft.Xna.Framework;

namespace MarioBros
{
    public enum Direction { Left, Right }

    public class Shellcreeper : SimpleObject
    {
        private const float ShellcreeperSpeed = 8;

        private static readonly Dimensions ShellcreeperPhysicsDimensions = new Dimensions(0.8f, 0.8f, 1.8f, 0);
        private static readonly Dimensions ShellcreeperVisualDimensions = new Dimensions(1, 1, 2, 0);
        public Direction Direction { get; set; }

        public Shellcreeper() : base(ShellcreeperVisualDimensions, ShellcreeperPhysicsDimensions) { }

        public override void UpdateCore(GameRound round, float elapsedSeconds)
        {
            base.UpdateCore(round, elapsedSeconds);

            Position += new Vector2((Direction == Direction.Left ? -1 : +1) * ShellcreeperSpeed * elapsedSeconds, 0);
        }
    }
}
