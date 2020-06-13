using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace MarioBros
{
    public class GameRound
    {
        private readonly List<GameObject> objects = new List<GameObject>();

        public IEnumerable<GameObject> Objects => objects;

        public void Add(GameObject newObject)
        {
            objects.Add(newObject);
        }

        public void Update(float elapsedSeconds)
        {
            foreach (GameObject gameObject in objects)
                gameObject.Update(this, elapsedSeconds);

            List<Collision> collisions = DetermineCollisions();
            foreach (Collision collision in collisions)
                HandleCollision(collision);
        }

        public Vector2 WorldSize => new Vector2(32, 25);

        public IEnumerable<GameObject> ObjectsIn(Box box)
        {
            return objects.Where(o => o.PhysicsBox.Intersects(box));
        }

        private void HandleCollision(Collision collision)
        {
            List<ICollisionHandler> handlers = new List<ICollisionHandler>
            {
                new SimpleObjectVsBlockCollisionHandler(),
                new PlayerCharacterVsMonsterHandler(),
                new MonsterVsMonsterHandler()
            };

            foreach(ICollisionHandler handler in handlers.Where(h => h.ShouldHandle(collision)))
                handler.Handle(collision.A, collision.B);
        }

        private List<Collision> DetermineCollisions()
        {
            List<Collision> collisions = new List<Collision>();
            foreach (GameObject a in objects.OfType<SimpleObject>())
            {
                foreach (GameObject b in objects)
                {
                    if (a == b) continue;

                    if (a.PhysicsBox.Intersects(b.PhysicsBox))
                        collisions.Add(new Collision(a, b));
                }
            }
            return collisions;
        }
    }
}
