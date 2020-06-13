using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MarioBros
{
    public class MonsterVsBlockBumpHandler : CollisionHandler<Monster, BlockBump>
    {
        private List<Monster> handled = new List<Monster>(); // This isn't going to work forever, but it will work for now.
        public override void Handle(Monster a, BlockBump b, CollisionDirections directions)
        {
            if (handled.Contains(a)) return;

            handled.Add(a);
            a.Hit();
            a.Velocity = new Vector2(0, 24);
            a.Direction = a.Direction.Opposite();
        }
    }
}
