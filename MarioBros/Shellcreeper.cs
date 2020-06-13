﻿namespace MarioBros
{
    public class Shellcreeper : SimpleObject
    {
        private static readonly Dimensions ShellcreeperPhysicsDimensions = new Dimensions(0.8f, 0.8f, 1.8f, 0);
        private static readonly Dimensions ShellcreeperVisualDimensions = new Dimensions(1, 1, 2, 0);

        public Shellcreeper() : base(ShellcreeperVisualDimensions, ShellcreeperPhysicsDimensions) { }
    }
}
