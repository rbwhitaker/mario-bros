namespace MarioBros
{
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
