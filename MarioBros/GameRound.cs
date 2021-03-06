﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace MarioBros
{
    public class GameRound
    {
        private readonly List<GameObject> objects = new List<GameObject>();

        public IEnumerable<GameObject> Objects => objects;
        public int score = 0;

        public void Add(GameObject newObject)
        {
            objects.Add(newObject);
        }

        public void Update(float elapsedSeconds)
        {
            foreach (GameObject gameObject in objects)
                gameObject.Update(this, elapsedSeconds);

            List<ICollisionHandler> handlers = new List<ICollisionHandler>
            {
                new HeadHitBlockHandler(this),
                new SimpleObjectVsBlockCollisionHandler(),
                new PlayerCharacterVsMonsterHandler(),
                new MonsterVsMonsterHandler(),
                new MonsterVsBlockBumpHandler(),
                new MonsterVsExitPipeHandler(),
                new PlayerCharacterVsCoinHandler(),
                new CoinVsBlockBumpHandler(),
                new CoinVsExitPipeHandler(),
                new PlayerCharacterVsPOWBlockHandler(objects.OfType<Monster>()),

            };

            List<Collision> collisions = DetermineCollisions();
            foreach (Collision collision in collisions)
                HandleCollision(handlers, collision);


            List<GameObject> toAdd = new List<GameObject>();
            foreach (GameObject thisObject in objects)
            {
                if (thisObject is Monster && !thisObject.IsAlive)
                {
                    score += 800;
                    toAdd.Add(new Coin(2, 23));
                }
            }

            objects.AddRange(toAdd);
            objects.RemoveAll(o => !o.IsAlive);
        }

        public Vector2 WorldSize => new Vector2(32, 25);

        public IEnumerable<GameObject> ObjectsIn(Box box)
        {
            return objects.Where(o => o.PhysicsBox.Intersects(box));
        }

        private void HandleCollision(IEnumerable<ICollisionHandler> handlers, Collision collision)
        {
            foreach(ICollisionHandler handler in handlers.Where(h => h.ShouldHandle(collision)))
                handler.Handle(collision.A, collision.B, collision.Directions);
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
                    {
                        bool top = a.PhysicsBox.Bottom <= b.PhysicsBox.Top && a.PreviousPhysicsBox.Bottom > b.PhysicsBox.Top;
                        bool bottom = a.PhysicsBox.Top >= b.PhysicsBox.Bottom && a.PreviousPhysicsBox.Top < b.PhysicsBox.Bottom;
                        bool left = a.PhysicsBox.Left <= b.PhysicsBox.Right && a.PreviousPhysicsBox.Left > b.PhysicsBox.Right;
                        bool right = a.PhysicsBox.Right >= b.PhysicsBox.Left && a.PreviousPhysicsBox.Right < b.PhysicsBox.Left;

                        collisions.Add(new Collision(a, b, new CollisionDirections(left, right, top, bottom)));
                    }
                }
            }
            return collisions;
        }
    }
}
