namespace MarioBros
{
    public class MonsterVsMonsterHandler : CollisionHandler<Shellcreeper, Shellcreeper>
    {
        public override void Handle(Shellcreeper a, Shellcreeper b, CollisionDirections directions)
        {
            a.Direction = FlipDirection(a.Direction);
            b.Direction = FlipDirection(b.Direction);
        }

        private Direction FlipDirection(Direction original) => original == Direction.Left ? Direction.Right : Direction.Left;
    }
}
