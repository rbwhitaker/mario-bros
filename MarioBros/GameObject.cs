using Microsoft.Xna.Framework;

namespace MarioBros
{
    public abstract class GameObject
    {
        public Vector2 Position { get; set; }
        public Dimensions PhysicsDimensions { get; }
        public Dimensions VisualDimensions { get; }
        public Box VisualBox => new Box(Position, VisualDimensions);
        public Box PhysicsBox => new Box(Position, PhysicsDimensions);

        public GameObject(Dimensions visualDimensions, Dimensions physicsDimensions)
        {
            PhysicsDimensions = physicsDimensions;
            VisualDimensions = visualDimensions;
        }
        
        public abstract void Update(float elapsedSeconds);
    }
}
