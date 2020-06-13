namespace MarioBros
{
    public class Sidestepper : Monster
    {
        private const float SidestepperSpeed = 8;

        private static readonly Dimensions SidestepperPhysicsDimensions = new Dimensions(0.8f, 0.8f, 1.8f, 0);

        private static readonly Dimensions SidestepperVisualDimensions = new Dimensions(1, 1, 2, 0);

        public bool IsAngry { get; private set; }

        public override void Hit()
        {
            if (!IsAngry) IsAngry = true;
            else IsStunned = !IsStunned;
        }

        public Sidestepper() : base(SidestepperVisualDimensions, SidestepperPhysicsDimensions)
        {
            speed = SidestepperSpeed;
        }
    }
}
