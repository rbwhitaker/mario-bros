namespace MarioBros
{
    public class PlayerCharacterVsMonsterHandler : CollisionHandler<PlayerCharacter, Shellcreeper>
    {
        public override void Handle(PlayerCharacter character, Shellcreeper monster, CollisionDirections directions)
        {
            if (monster.IsStunned)
                monster.Kill();
            else
                character.Kill();
        }
    }
}
