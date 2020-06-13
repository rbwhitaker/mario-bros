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
        private Texture2D simpleRectangle, Mario_Idle, Creeper, Block;

        public BasicRenderer(ContentManager Content)
        {
            content = Content;
            simpleRectangle = Content.Load<Texture2D>("Rectangle16");
            Mario_Idle = Content.Load<Texture2D>("M1");
            Creeper = Content.Load<Texture2D>("Creeper");
            Block = Content.Load<Texture2D>("Block");
        }

        public void Render(GameRound gameRound, SpriteBatch SpriteBatch)
        {            
            spriteBatch = SpriteBatch;

            foreach (GameObject gameObject in gameRound.Objects)
            {
                
                if (gameObject is Block b) DrawBlock(b);
                if (gameObject is PlayerCharacter c) DrawPlayerCharacter(c);
                if (gameObject is Shellcreeper s) DrawShellCreeper(s);
            }
        }

        private void DrawPlayerCharacter(PlayerCharacter c)
        {
            Box visualBox = c.VisualBox;
            Rectangle bounds = ToPixels(visualBox);
            bounds.Y -= 16;
            spriteBatch.Draw(Mario_Idle, bounds, Color.White);
        }

        private void DrawShellCreeper(Shellcreeper shellcreeper)
        {
            Box visualBox = shellcreeper.VisualBox;
            Rectangle bounds = ToPixels(visualBox);
            bounds.Y -= 16;
            spriteBatch.Draw(Creeper, bounds, Color.White);
        }

        private const float PixelsPerUnit = 16;

        private void DrawBlock(Block b)
        {
            Box visualBox = b.VisualBox;
            Rectangle bounds = ToPixels(visualBox);
            spriteBatch.Draw(Block, bounds, Color.White);
        }

        private Rectangle ToPixels(Box box)
        {            
            return new Rectangle((int)(box.Left * PixelsPerUnit), (((int)(box.Bottom * PixelsPerUnit))*-1)+384, (int)(box.Width * PixelsPerUnit), (int)(box.Height * PixelsPerUnit));
        }
    }
}
