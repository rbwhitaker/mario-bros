﻿using Microsoft.Xna.Framework;
using System;
using System.Linq;

namespace MarioBros
{
    public abstract class SimpleObject : GameObject
    {
        public Vector2 Velocity { get; set; }
        public bool Direction = true;

        public SimpleObject(Dimensions visualDimensions, Dimensions physicsDimensions) : base(visualDimensions, physicsDimensions) { }

        public override void UpdateCore(GameRound round, float elapsedSeconds)
        {
            // Gravity
            Velocity -= new Vector2(0, 62f) * elapsedSeconds;
            Position += Velocity * elapsedSeconds;
            if (Position.X < 0) Position += new Vector2(round.WorldSize.X, 0);
            if (Position.X > round.WorldSize.X) Position -= new Vector2(round.WorldSize.X, 0);
        }
    }

    public class PlayerCharacter : SimpleObject
    {
        private static readonly Dimensions CharacterPhysicsDimensions = new Dimensions(1, 1, 2, 0);
        private static readonly Dimensions CharacterVisualDimensions = new Dimensions(1, 1, 2, 0);
        private static readonly Dimensions JumpArea = new Dimensions(1, 1, -0.01f, 0.25f);

        private readonly IPlayerControls controls;
        public int Lives { get; private set; }

        public void Kill()
        {
            Lives--;
            if (Lives == 0) Environment.Exit(0);

            Position = new Vector2(16, 22);
            Velocity = new Vector2(0, 0);
        }

        public PlayerCharacter(IPlayerControls controls) : base(CharacterVisualDimensions, CharacterPhysicsDimensions)
        {
            this.controls = controls;
            Lives = 5;
        }

        public override void UpdateCore(GameRound round, float elapsedSeconds)
        {
            base.UpdateCore(round, elapsedSeconds);

            controls.Update(elapsedSeconds);
            Position += new Vector2(controls.HorizontalSpeed * 20f, 0) * elapsedSeconds;
            if (controls.HorizontalSpeed > 0) Direction = true;
            if (controls.HorizontalSpeed < 0) Direction = false;
            if (controls.IsAttemptingToJump)
                if (round.ObjectsIn(new Box(Position, JumpArea)).Any())
                    Velocity = new Vector2(Velocity.X, 30);
        }
    }
}
