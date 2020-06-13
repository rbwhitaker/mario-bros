namespace MarioBros
{
    public class MonsterVsMonsterHandler : CollisionHandler<Monster, Monster>
    {
        public override void Handle(Monster a, Monster b, CollisionDirections directions)
        {
            a.Direction = a.Direction.Opposite();
            b.Direction = b.Direction.Opposite();
        }
    }
}
