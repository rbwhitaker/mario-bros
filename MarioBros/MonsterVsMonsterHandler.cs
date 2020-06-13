namespace MarioBros
{
    public class MonsterVsMonsterHandler : CollisionHandler<Shellcreeper, Shellcreeper>
    {
        public override void Handle(Shellcreeper a, Shellcreeper b, CollisionDirections directions)
        {
            a.Direction = a.Direction.Opposite();
            b.Direction = b.Direction.Opposite();
        }
    }
}
