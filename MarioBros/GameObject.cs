﻿using Microsoft.Xna.Framework;

namespace MarioBros
{
    public abstract class GameObject
    {
        public Vector2 Position { get; set; }
        public virtual Dimensions PhysicsDimensions { get; }
        public virtual Dimensions VisualDimensions { get; }
        public virtual Box VisualBox => new Box(Position, VisualDimensions);
        public virtual Box PhysicsBox => new Box(Position, PhysicsDimensions);
        public Box PreviousPhysicsBox { get; private set; }
        public bool IsAlive { get; protected set; } = true;

        public GameObject(Dimensions visualDimensions, Dimensions physicsDimensions)
        {
            PhysicsDimensions = physicsDimensions;
            VisualDimensions = visualDimensions;
        }
        
        public void Update(GameRound gameRound, float elapsedSeconds)
        {
            PreviousPhysicsBox = PhysicsBox;
            UpdateCore(gameRound, elapsedSeconds);
        }

        public abstract void UpdateCore(GameRound gameRound, float elapsedSeconds);
    }
}
