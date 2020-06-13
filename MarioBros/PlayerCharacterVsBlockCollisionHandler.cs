using Microsoft.Xna.Framework;

namespace MarioBros
{
    public class SimpleObjectVsBlockCollisionHandler : CollisionHandler<SimpleObject, Block>
    {
        public override void Handle(SimpleObject p, Block b, CollisionDirections directions)
        {
            if(directions.Top)
            {
                p.Position = new Vector2(p.Position.X, b.PhysicsBox.Top + 0.02f);
                p.Velocity = new Vector2(p.Velocity.X, 0);
            }
            if (directions.Bottom)
            {
                p.Position = new Vector2(p.Position.X, b.PhysicsBox.Bottom - p.PhysicsDimensions.Height - 0.02f);
                p.Velocity = new Vector2(p.Velocity.X, 0);
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
