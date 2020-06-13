using Microsoft.Xna.Framework;

namespace MarioBros
{
    public struct AxisAlignedBoundingBox
    {
        public float Left { get; }
        public float Right { get; }
        public float Top { get; }
        public float Bottom { get; }

        public AxisAlignedBoundingBox(Dimensions dimensions, Vector2 location)
        {
            Left = location.X - dimensions.Left;
            Right = location.X + dimensions.Right;
            Top = location.Y + dimensions.Top;
            Bottom = location.Y - dimensions.Bottom;
        }
    }
}
