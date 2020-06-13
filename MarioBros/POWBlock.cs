using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioBros
{
    public class POWBlock : Block
    {
        public int TimesHit = 1;
        //private static readonly Dimensions POWDimensions = new Dimensions(1f);

        public POWBlock(float x, float y) : this(new Vector2(x, y)) { }
        public POWBlock(Vector2 position) : base(position) { }
        //public POWBlock(Vector2 position) : base(POWDimensions, POWDimensions) { }

        public override void UpdateCore(GameRound gameRound, float elapsedSeconds)
        {
            //throw new NotImplementedException();
        }
    }
}
