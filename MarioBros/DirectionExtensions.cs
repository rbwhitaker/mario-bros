namespace MarioBros
{
    public static class DirectionExtensions
    {
        public static Direction Opposite(this Direction original) => original == Direction.Left ? Direction.Right : Direction.Left;
    }
}
