namespace MarioBros
{
    public class HeadHitBlockHandler : CollisionHandler<PlayerCharacter, Block>
    {
        private readonly GameRound round;

        public HeadHitBlockHandler(GameRound round)
        {
            this.round = round;
        }

        public override void Handle(PlayerCharacter p, Block b, CollisionDirections directions)
        {
            if (directions.Bottom)
            {
                round.Add(new BlockBump(b.Position));
            }
        }
    }
}
