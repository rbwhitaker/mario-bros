namespace MarioBros
{
    public interface IPlayerControls
    {
        void Update(float elapsedSeconds);
        float HorizontalSpeed { get; }
        bool IsAttemptingToJump { get; }
    }
}
