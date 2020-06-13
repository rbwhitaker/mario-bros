using Microsoft.Xna.Framework;

namespace MarioBros
{
    public class PlayerCharacter : GameObject
    {
        private static readonly Dimensions CharacterPhysicsDimensions = new Dimensions(1, 1, 2, 0);
        private static readonly Dimensions CharacterVisualDimensions = new Dimensions(1, 1, 2, 0);

        public PlayerCharacter() : base(CharacterPhysicsDimensions, CharacterVisualDimensions) { }

        public override void UpdateCore(float elapsedSeconds)
        {
            // Gravity
            Position += new Vector2(0, -8f) * elapsedSeconds;
        }
    }
}
