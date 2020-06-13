using Microsoft.Xna.Framework;

namespace MarioBros
{
    public abstract class GameObject
    {
        public Vector2 Position { get; protected set; }
        public Dimensions PhysicsDimensions { get; }
        public Dimensions VisualDimensions { get; }

        public GameObject(Dimensions visualDimensions, Dimensions physicsDimensions)
        {
            PhysicsDimensions = physicsDimensions;
            VisualDimensions = visualDimensions;
        }
        
        public abstract void Update(double elapsedSeconds);
    }
}
