using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioBros
{
    class PlayerCharacterVsPOWBlockHandler : CollisionHandler<SimpleObject, POWBlock>
    {
        IEnumerable<Monster> monstersToHit;
        public PlayerCharacterVsPOWBlockHandler(IEnumerable<Monster> monstersToHit)
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
        public override void Handle(SimpleObject p, POWBlock b, CollisionDirections directions)
        {

            if (directions.Top)
            {
                p.Position = new Vector2(p.Position.X, b.PhysicsBox.Top + 0.001f);
                p.Velocity = new Vector2(p.Velocity.X, 0);
            }
            if (directions.Bottom)
            {
                p.Position = new Vector2(p.Position.X, b.PhysicsBox.Bottom - p.PhysicsDimensions.Height - 0.02f);
                p.Velocity = new Vector2(p.Velocity.X, 0);
                if (p is PlayerCharacter)
                {
                    b.TimesHit++;
                    if (b.TimesHit > 3)
                        return;
                    foreach (Monster monster in monstersToHit)
                        if (!monster.IsStunned)
                            monster.Hit();
                }
            }
            if (directions.Left)
            {
                p.Position = new Vector2(b.PhysicsBox.Right + p.PhysicsDimensions.Left + 0.02f, p.Position.Y);
                p.Velocity = new Vector2(0, p.Velocity.Y);
            }
            if (directions.Right)
            {
                p.Position = new Vector2(b.PhysicsBox.Left - p.PhysicsDimensions.Right - 0.02f, p.Position.Y);
                p.Velocity = new Vector2(0, p.Velocity.Y);
            }

        }
    }
}
