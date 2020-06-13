using Microsoft.Xna.Framework;
using System;

namespace MarioBros
{
    public class Coin : SimpleObject
    {
        public Direction Direction { get; set; }
        private const float CoinSpeed = 6f;
        private static readonly Dimensions CoinDimensions = new Dimensions(0.75f, 0.75f, 1.5f, 0f);

        internal void Collect()
        {
            IsAlive = false;
        }

        public Coin(float x, float y) : this(new Vector2(x, y)) { }
        public Coin(Vector2 position) : base(CoinDimensions, CoinDimensions)
        {
            Position = position;
        }

        public override void UpdateCore(GameRound round, float elapsedSeconds)
        {
            base.UpdateCore(round, elapsedSeconds);
            totalTime += elapsedSeconds;
            Position += new Vector2((Direction == Direction.Left ? -1 : +1) * CoinSpeed * elapsedSeconds, 0);
        }

        double totalTime = 0;

        public override Dimensions VisualDimensions => base.VisualDimensions * new Vector2(Math.Abs((float)Math.Cos(totalTime * 10)), 1);
    }
}
