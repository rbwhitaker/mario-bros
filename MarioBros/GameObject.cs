﻿using Microsoft.Xna.Framework;

namespace MarioBros
{
    public abstract class GameObject
    {
        public Vector2 Position { get; set; }
        public Dimensions PhysicsDimensions { get; }
        public Dimensions VisualDimensions { get; }
        public Box VisualBox => new Box(Position, VisualDimensions);
        public Box PhysicsBox => new Box(Position, PhysicsDimensions);
        public Box PreviousPhysicsBox { get; private set; }

        public GameObject(Dimensions visualDimensions, Dimensions physicsDimensions)
        {
            PhysicsDimensions = physicsDimensions;
            VisualDimensions = visualDimensions;
        }
        
        public void Update(float elapsedSeconds)
        {
            PreviousPhysicsBox = PhysicsBox;
            UpdateCore(elapsedSeconds);
        }

        public abstract void UpdateCore(float elapsedSeconds);
    }
}
