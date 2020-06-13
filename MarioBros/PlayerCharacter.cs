namespace MarioBros
{
    public class PlayerCharacter : GameObject
    {
        private static readonly Dimensions CharacterPhysicsDimensions = new Dimensions(1, 1, 2, 0);
        private static readonly Dimensions CharacterVisualDimensions = new Dimensions(1, 1, 2, 0);

        public PlayerCharacter() : base(CharacterPhysicsDimensions, CharacterVisualDimensions) { }

        public override void Update(float elapsedSeconds)
        {

        }
    }
}
