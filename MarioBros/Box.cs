using Microsoft.Xna.Framework;

namespace MarioBros
{
    public struct Box
    {
        public float Left { get; }
        public float Right { get; }
        public float Top { get; }
        public float Bottom { get; }
        public float Width => Right - Left;
        public float Height => Top - Bottom;


        public Box(Vector2 position, Dimensions dimensions)
        {
            Left = position.X - dimensions.Left;
            Right = position.X + dimensions.Right;
            Top = position.Y + dimensions.Top;
            Bottom = position.Y - dimensions.Bottom;
        }
    }
}
