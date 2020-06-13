using Microsoft.Xna.Framework;
using System.Linq;

namespace MarioBros
{
    public abstract class Monster : SimpleObject
    {
        private static readonly Dimensions GroundArea = new Dimensions(1, 1, -0.01f, 0.25f);
        public bool IsStunned { get; protected set; }
        public Direction Direction { get; set; }
        protected float speed;

        public Monster(Dimensions visualDimensions, Dimensions physicsDimensions) : base(visualDimensions, physicsDimensions) { }


        internal void Kill()
        {
            IsAlive = false;
        }

        public abstract void Hit();

        public override void UpdateCore(GameRound round, float elapsedSeconds)
        {
            base.UpdateCore(round, elapsedSeconds);

            if (!IsStunned || !round.ObjectsIn(new Box(Position, GroundArea)).OfType<Block>().Any())
                Position += new Vector2((Direction == Direction.Left ? -1 : +1) * speed * elapsedSeconds, 0);
        }
    }
}
