using Microsoft.Xna.Framework;

namespace MarioBros
{
    public class PlayerCharacter : GameObject
    {
        private static readonly Dimensions CharacterPhysicsDimensions = new Dimensions(1, 1, 2, 0);
        private static readonly Dimensions CharacterVisualDimensions = new Dimensions(1, 1, 2, 0);

        public Vector2 Velocity { get; set; }

        private readonly IPlayerControls controls;

        public PlayerCharacter(IPlayerControls controls) : base(CharacterPhysicsDimensions, CharacterVisualDimensions)
        {
            this.controls = controls;
        }

        public override void UpdateCore(float elapsedSeconds)
        {
            // Gravity
            Velocity -= new Vector2(0, 16f) * elapsedSeconds;
            Position += Velocity * elapsedSeconds;

            controls.Update(elapsedSeconds);
            Position += new Vector2(controls.HorizontalSpeed * 12f, 0) * elapsedSeconds;
            if (controls.IsAttemptingToJump) Velocity = new Vector2(Velocity.X, 16);
        }
    }
}
