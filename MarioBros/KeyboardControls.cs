using Microsoft.Xna.Framework.Input;

namespace MarioBros
{
    public class KeyboardControls : IPlayerControls
    {
        public Keys Left { get; }
        public Keys Right { get; }
        public Keys Jump { get; }

        public float HorizontalSpeed { get; private set; }

        public bool IsAttemptingToJump { get; private set; }

        
        public KeyboardControls(Keys left, Keys right, Keys jump)
        {
            Left = left;
            Right = right;
            Jump = jump;
        }

        public void Update(float elapsedSeconds)
        {
            KeyboardState state = Keyboard.GetState();
            bool isLeftDown = state.IsKeyDown(Left);
            bool isRightDown = state.IsKeyDown(Right);
            bool isJumpDown = state.IsKeyDown(Jump);

            if (isLeftDown && isRightDown) HorizontalSpeed = 0;
            else if (isLeftDown) HorizontalSpeed = -1;
            else if (isRightDown) HorizontalSpeed = +1;
            else HorizontalSpeed = 0;

            IsAttemptingToJump = isJumpDown;
        }

        public static KeyboardControls Player1 { get; } = new KeyboardControls(Keys.Left, Keys.Right, Keys.Space);
    }
}
