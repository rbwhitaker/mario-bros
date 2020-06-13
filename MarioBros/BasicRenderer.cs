using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MarioBros
{
    class BasicRenderer
    {
        ContentManager content;
        SpriteBatch spriteBatch;
        SpriteFont font;
        private Texture2D simpleRectangle, Mario_Left, Mario_Right, Creeper, Block, Brick, TurtleBack;
        private Texture2D StraightPipe, CurvedPipe, Stepper;

        private const float PixelsPerUnit = 16;

        public BasicRenderer(ContentManager Content)
        {
            content = Content;
            simpleRectangle = Content.Load<Texture2D>("Rectangle16");
            Mario_Left = Content.Load<Texture2D>("M1L");
            Mario_Right = Content.Load<Texture2D>("M1R");
            Creeper = Content.Load<Texture2D>("Creeper");
            Block = Content.Load<Texture2D>("SmallBlock");
            Brick = Content.Load<Texture2D>("Brick");
            TurtleBack = Content.Load<Texture2D>("turtleback");
            StraightPipe = Content.Load<Texture2D>("StraightPipe");
            CurvedPipe = Content.Load<Texture2D>("CurvedPipe");
            Stepper = Content.Load<Texture2D>("sidestepper");
            font = Content.Load<SpriteFont>("Font");
        }

        public void Render(GameRound gameRound, SpriteBatch SpriteBatch)
        {            
            spriteBatch = SpriteBatch;

            foreach (GameObject gameObject in gameRound.Objects)
            {
                
                if (gameObject is Brick brick) DrawBrick(brick);
                else if (gameObject is Block b) DrawBlock(b);
                if (gameObject is BlockBump bump) DrawBlockBump(bump);
                if (gameObject is PlayerCharacter c) DrawPlayerCharacter(c);
                if (gameObject is Shellcreeper s) DrawShellCreeper(s);
                //else if (gameObject is Monster m) DrawGenericMonster(m);
                if (gameObject is ExitPipe p) DrawExitPipe(p);
                if (gameObject is Sidestepper stepper) DrawSideStepper(stepper);
                spriteBatch.DrawString(font, "Score: " + gameRound.score, new Vector2(0, 0), Color.White);
            }
        }

        private void DrawSideStepper(Sidestepper stepper)
        {
            Box visualBox = stepper.VisualBox;
            Rectangle bounds = ToPixels(visualBox);
            bounds.Y -= 16;
            spriteBatch.Draw(Stepper, bounds, null, Color.White, 0, new Vector2(0.5f, 0.5f), stepper.IsStunned ? SpriteEffects.FlipVertically : SpriteEffects.None, 0f);
        }

        private void DrawPlayerCharacter(PlayerCharacter c)
        {
            spriteBatch.DrawString(font, "Lives: " + c.Lives, new Vector2(300, 0), Color.White);
            Box visualBox = c.VisualBox;
            Rectangle bounds = ToPixels(visualBox);
            bounds.Y -= 16;
            
            if (c.Direction) { spriteBatch.Draw(Mario_Right, bounds, Color.White); }
            if (!c.Direction) { spriteBatch.Draw(Mario_Left, bounds, Color.White); }
       }

        private void DrawGenericMonster(Monster monster)
        {
            Box visualBox = monster.VisualBox;
            Rectangle bounds = ToPixels(visualBox);
            bounds.Y -= 16;
            spriteBatch.Draw(simpleRectangle, bounds, null, Color.Red, 0, new Vector2(0.5f, 0.5f), monster.IsStunned ? SpriteEffects.FlipVertically : SpriteEffects.None, 0f);
        }

        private void DrawShellCreeper(Shellcreeper shellcreeper)
        {
            Box visualBox = shellcreeper.VisualBox;
            Rectangle bounds = ToPixels(visualBox);
            bounds.Y -= 16;
            spriteBatch.Draw(Creeper, bounds, null, Color.White, 0, new Vector2(0.5f, 0.5f), shellcreeper.IsStunned ? SpriteEffects.FlipVertically : SpriteEffects.None, 0f);
        }

        private void DrawBrick(Brick b)
        {
            Box visualBox = b.VisualBox;
            Rectangle bounds = ToPixels(visualBox);
            spriteBatch.Draw(Brick, bounds, Color.White);
        }

        private void DrawBlock(Block b)
        {
            Box visualBox = b.VisualBox;
            Rectangle bounds = ToPixels(visualBox);
            spriteBatch.Draw(Block, bounds, Color.White);
        }

        private void DrawExitPipe(ExitPipe pipe)
        {
            Box visualBox = pipe.VisualBox;
            Rectangle bounds = ToPixels(visualBox);
            if (bounds.X == 0) { spriteBatch.Draw(StraightPipe, bounds, null, Color.LightGreen, 0.0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0.0f); } else { spriteBatch.Draw(StraightPipe, bounds, Color.LightGreen); }
        }

        private void DrawBlockBump(BlockBump b)
        {
            Box visualBox = b.VisualBox;
            Rectangle bounds = ToPixels(visualBox);
            spriteBatch.Draw(simpleRectangle, bounds, Color.White);
        }

        private Rectangle ToPixels(Box box)
        {            
            return new Rectangle((int)(box.Left * PixelsPerUnit), (((int)(box.Bottom * PixelsPerUnit))*-1)+384, (int)(box.Width * PixelsPerUnit), (int)(box.Height * PixelsPerUnit));
        }
    }
}
