namespace MarioBros
{
    public interface ICollisionHandler
    {
        bool ShouldHandle(Collision collision);
        void Handle(GameObject a, GameObject b);
    }
}
