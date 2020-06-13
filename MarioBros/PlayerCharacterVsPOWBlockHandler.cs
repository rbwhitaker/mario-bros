using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioBros
{
    class PlayerCharacterVsPOWBlockHandler : CollisionHandler<PlayerCharacter, POWBlock>
    {
        List<Monster> monstersToHit = new List<Monster>();
        public PlayerCharacterVsPOWBlockHandler(List<Monster> monstersToHit)
        {
            this.monstersToHit = monstersToHit;
        }
        //private List<Monster> handled = new List<Monster>();
        //public override void Handle(PlayerCharacter a, POWBlock b, CollisionDirections directions)
        //{
        //    if (handled.Contains(a)) return;

        //    handled.Add(a);
        //    a.Hit();
        //    a.Velocity = new Vector2(0, 24);
        //    a.Direction = a.Direction.Opposite();
        //}
        public override void Handle(PlayerCharacter a, POWBlock b, CollisionDirections directions)
        {
            b.TimesHit++;
            if (b.TimesHit > 3)
                return;
            foreach (Monster monster in monstersToHit)
                if (!monster.IsStunned)
                    monster.Hit();
        }
    }
}
