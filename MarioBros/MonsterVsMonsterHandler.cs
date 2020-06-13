using Microsoft.Xna.Framework;

namespace MarioBros
{
    public class MonsterVsMonsterHandler : CollisionHandler<Monster, Monster>
    {
        public override void Handle(Monster a, Monster b, CollisionDirections directions)
        {
            a.Direction = a.Direction.Opposite();
            if (a.Position.X < b.Position.X) a.Position -= new Vector2(0.02f, 0);
            if (a.Position.X >= b.Position.X) a.Position += new Vector2(0.02f, 0);
        }
    }
}
