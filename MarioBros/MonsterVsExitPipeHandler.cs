using Microsoft.Xna.Framework;

namespace MarioBros
{
    public class MonsterVsExitPipeHandler : CollisionHandler<Shellcreeper, ExitPipe>
    {
        public override void Handle(Shellcreeper a, ExitPipe b, CollisionDirections directions)
        {
            a.Position = new Vector2(1f, 23.5f);
            a.Direction = a.Direction.Opposite();
        }
    }
}
