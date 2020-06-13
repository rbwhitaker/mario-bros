using Microsoft.Xna.Framework;

namespace MarioBros
{
    public class PlayerCharacterVsBlockCollisionHandler : CollisionHandler<PlayerCharacter, Block>
    {
        public override void Handle(PlayerCharacter p, Block b)
        {
            if (p.PhysicsBox.Bottom <= b.PhysicsBox.Top && p.PreviousPhysicsBox.Bottom > b.PhysicsBox.Top)
            {
                p.Position = new Vector2(p.Position.X, b.PhysicsBox.Top + 0.02f);
                p.Velocity = new Vector2(p.Velocity.X, 0);
            }
            if (p.PhysicsBox.Top >= b.PhysicsBox.Bottom && p.PreviousPhysicsBox.Top < b.PhysicsBox.Bottom)
            {
                p.Position = new Vector2(p.Position.X, b.PhysicsBox.Bottom - p.PhysicsDimensions.Height - 0.02f);
                p.Velocity = new Vector2(p.Velocity.X, 0);
            }
            if (p.PhysicsBox.Left <= b.PhysicsBox.Right && p.PreviousPhysicsBox.Left > b.PhysicsBox.Right)
            {
                p.Position = new Vector2(b.PhysicsBox.Right + p.PhysicsDimensions.Left + 0.02f, p.Position.Y);
                p.Velocity = new Vector2(0, p.Velocity.Y);
            }
            if (p.PhysicsBox.Right >= b.PhysicsBox.Left && p.PreviousPhysicsBox.Right < b.PhysicsBox.Left)
            {
                p.Position = new Vector2(b.PhysicsBox.Left - p.PhysicsDimensions.Right - 0.02f, p.Position.Y);
                p.Velocity = new Vector2(0, p.Velocity.Y);
            }
        }
    }
}
