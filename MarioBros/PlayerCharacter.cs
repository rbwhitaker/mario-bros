using Microsoft.Xna.Framework;
using System.Linq;

namespace MarioBros
{
    public class PlayerCharacter : GameObject
    {
        private static readonly Dimensions CharacterPhysicsDimensions = new Dimensions(1, 1, 2, 0);
        private static readonly Dimensions CharacterVisualDimensions = new Dimensions(1, 1, 2, 0);
        private static readonly Dimensions JumpArea = new Dimensions(1, 1, -0.01f, 0.25f);

        public Vector2 Velocity { get; set; }

        private readonly IPlayerControls controls;

        public PlayerCharacter(IPlayerControls controls) : base(CharacterPhysicsDimensions, CharacterVisualDimensions)
        {
            this.controls = controls;
        }

        public override void UpdateCore(GameRound round, float elapsedSeconds)
        {
            // Gravity
            Velocity -= new Vector2(0, 62f) * elapsedSeconds;
            Position += Velocity * elapsedSeconds;

            controls.Update(elapsedSeconds);
            Position += new Vector2(controls.HorizontalSpeed * 20f, 0) * elapsedSeconds;
            if (controls.IsAttemptingToJump)
                if(round.ObjectsIn(new Box(Position, JumpArea)).Any())
                    Velocity = new Vector2(Velocity.X, 30);
        }
    }
}
