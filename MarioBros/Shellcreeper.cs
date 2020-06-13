using System;

namespace MarioBros
{
    public class Shellcreeper : Monster
    {
        private const float ShellcreeperSpeed = 8;

        private static readonly Dimensions ShellcreeperPhysicsDimensions = new Dimensions(0.8f, 0.8f, 1.8f, 0);

        private static readonly Dimensions ShellcreeperVisualDimensions = new Dimensions(1, 1, 2, 0);

        public override void Hit()
        {
            IsStunned = !IsStunned;
        }

        public Shellcreeper() : base(ShellcreeperVisualDimensions, ShellcreeperPhysicsDimensions)
        {
            speed = ShellcreeperSpeed;
        }
    }
}
