using Microsoft.Xna.Framework;
using System;

namespace MarioBros
{
    public class BlockBump : GameObject
    {
        private const float Lifespan = 0.2f;
        private static readonly Dimensions BumpDimensions = new Dimensions(0.5f);

        private float timeRemaining = Lifespan;

        public BlockBump(Vector2 position) : base(BumpDimensions, BumpDimensions)
        {
            Position = position;
        }

        public override void UpdateCore(GameRound gameRound, float elapsedSeconds)
        {
            timeRemaining -= elapsedSeconds;
            if (timeRemaining <= 0) IsAlive = false;
        }

        private float FractionOfTimeRemaining => timeRemaining / Lifespan;

        public override Box PhysicsBox => base.PhysicsBox.Shift(new Vector2(0, 1 - 2 * Math.Abs(FractionOfTimeRemaining - 0.5f)));
        public override Box VisualBox => base.VisualBox.Shift(new Vector2(0, 1 - 2 * Math.Abs(FractionOfTimeRemaining - 0.5f)));
    }
}
