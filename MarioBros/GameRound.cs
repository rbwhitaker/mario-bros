using Microsoft.Xna.Framework;
using System;
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
                gameObject.Update(elapsedSeconds);

            List<Collision> collisions = DetermineCollisions();
            foreach (Collision collision in collisions)
                HandleCollision(collision);
        }

        private void HandleCollision(Collision collision)
        {
            if(collision.A is PlayerCharacter p && collision.B is Block b)
            {
                if (p.PhysicsBox.Bottom <= b.PhysicsBox.Top && p.PreviousPhysicsBox.Bottom > b.PhysicsBox.Top)
                    p.Position = new Vector2(p.Position.X, b.PhysicsBox.Top + 0.01f);
            }
        }

        private List<Collision> DetermineCollisions()
        {
            List<Collision> collisions = new List<Collision>();
            foreach (GameObject a in objects.OfType<PlayerCharacter>())
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
