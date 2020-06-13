namespace MarioBros
{
    public abstract class CollisionHandler<TA, TB> : ICollisionHandler where TA : GameObject where TB: GameObject
    {
        public virtual bool ShouldHandle(Collision collision) => collision.A is TA && collision.B is TB;
        public void Handle(GameObject a, GameObject b) => Handle((TA)a, (TB)b);

        public abstract void Handle(TA a, TB b);
    }
}
