using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MarioBros
{
    public class CoinVsBlockBumpHandler : CollisionHandler<Coin, BlockBump>
    {
        private List<Coin> handled = new List<Coin>(); // This isn't going to work forever, but it will work for now.
        public override void Handle(Coin a, BlockBump b, CollisionDirections directions)
        {
            if (handled.Contains(a)) return;

            handled.Add(a);
            a.Collect();
            a.Velocity = new Vector2(0, 24);
            a.Position += new Vector2(0, 0.1f);
        }
    }
}
