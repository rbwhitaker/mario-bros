namespace MarioBros
{
    public class PlayerCharacterVsCoinHandler : CollisionHandler<PlayerCharacter, Coin>
    {
        public override void Handle(PlayerCharacter a, Coin b, CollisionDirections directions)
        {
            b.Collect();
        }
    }
    public class PlayerCharacterVsMonsterHandler : CollisionHandler<PlayerCharacter, Monster>
    {
        public override void Handle(PlayerCharacter character, Monster monster, CollisionDirections directions)
        {
            if (monster.IsStunned)
                monster.Kill();
            else
                character.Kill();
        }
    }
}
