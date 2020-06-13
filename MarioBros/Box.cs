using System;
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

        public Box(float left, float right, float top, float bottom)
        {
            Left = left;
            Right = right;
            Top = top;
            Bottom = bottom;
        }

        internal bool Intersects(Box other)
        {
            if (Left > other.Right) return false;
            if (Right < other.Left) return false;
            if (Top < other.Bottom) return false;
            if (Bottom > other.Top) return false;
            return true;
        }

        public Box Shift(Vector2 amount)
        {
            return new Box(Left + amount.X, Right + amount.X, Top + amount.Y, Bottom + amount.Y);
        }
    }
}
