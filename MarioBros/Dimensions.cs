using Microsoft.Xna.Framework;

namespace MarioBros
{
    public struct Dimensions
    {
        /// <summary>
        /// An amount leftward from the center of the object (should generally be positive).
        /// </summary>
        public float Left { get; }

        /// <summary>
        /// An amount rightward from the center of the object (should generally be positive).
        /// </summary>
        public float Right { get; }

        /// <summary>
        /// An amount upward from the center of the object (should generally be positive).
        /// </summary>
        public float Top { get; }

        /// <summary>
        /// An amount downward from the center of the object (should generally be positive).
        /// </summary>
        public float Bottom { get; }

        public float Height => Bottom + Top;
        public float Widht => Left + Right;

        public Dimensions(float left, float right, float top, float bottom)
        {
            Left = left;
            Right = right;
            Top = top;
            Bottom = bottom;
        }

        public static Dimensions operator *(Dimensions dimensions, float scalar)
        {
            return new Dimensions(dimensions.Left * scalar, dimensions.Right * scalar, dimensions.Top * scalar, dimensions.Bottom * scalar);
        }

        public static Dimensions operator *(Dimensions dimensions, Vector2 amount)
        {
            return new Dimensions(dimensions.Left * amount.X, dimensions.Right * amount.X, dimensions.Top * amount.Y, dimensions.Bottom * amount.Y);
        }

        public Dimensions(float allDirections) : this(allDirections, allDirections, allDirections, allDirections) { }
    }
}
