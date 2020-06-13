using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MarioBros
{
    public class MonsterVsBlockBumpHandler : CollisionHandler<Shellcreeper, BlockBump>
    {
        private List<Shellcreeper> handled = new List<Shellcreeper>(); // This isn't going to work forever, but it will work for now.
        public override void Handle(Shellcreeper a, BlockBump b, CollisionDirections directions)
        {
            if (handled.Contains(a)) return;

            handled.Add(a);
            a.IsStunned = !a.IsStunned;
            a.Velocity = new Vector2(0, 24);
            a.Direction = a.Direction.Opposite();
        }
    }
}
