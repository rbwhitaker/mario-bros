namespace MarioBros
{
    public class PlayerCharacterVsMonsterHandler : CollisionHandler<PlayerCharacter, Shellcreeper>
    {
        public override void Handle(PlayerCharacter character, Shellcreeper monster, CollisionDirections directions)
        {
            character.Kill();
        }
    }
}
