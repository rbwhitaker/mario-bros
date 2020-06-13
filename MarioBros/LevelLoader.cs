using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;
using IronPython.Runtime;

namespace MarioBros
{
    class LevelLoader
    {
        private Dictionary<int, string> TileExpressions { get; }
        private string levelSource;
        private Microsoft.Scripting.Hosting.ScriptEngine scriptEngine;

        private const float TILE_SIZE = 1.0f;
        private const float X_OFFSET = 0.5f;
        private const float Y_OFFSET = 0.5f;


        public LevelLoader(string levelSource)
        {
            TileExpressions = new Dictionary<int, string>();
            this.levelSource = levelSource;

            scriptEngine = Python.CreateEngine();
            scriptEngine.Runtime.LoadAssembly(Assembly.GetExecutingAssembly());
            scriptEngine.Runtime.LoadAssembly(Assembly.GetAssembly(typeof(Microsoft.Xna.Framework.Vector2)));

            ParseTiles();
        }

        public void LoadLevel(GameRound gameRound)
        {
            if (!levelSource.Contains("LEVEL"))
            {
                throw new ContentLoadException("Level does not contain LEVEL section.");
            }

            int xCounter = -1;
            int yCounter = -1;

            for (int index = levelSource.IndexOf("LEVEL") + 5; index < levelSource.Length; index++)
            {
                char curChar = levelSource[index];

                if(curChar == '\n')
                {
                    yCounter++;
                    xCounter = -1;
                    continue;
                }

                if (char.IsWhiteSpace(curChar))
                {
                    continue;
                }

                if (char.IsNumber(curChar))
                {
                    xCounter++;
                    int currentId = int.Parse(curChar.ToString());
                    if(TileExpressions.TryGetValue(currentId, out var expression))
                    {
                        float x = TILE_SIZE * (xCounter + X_OFFSET);
                        float y = TILE_SIZE * (yCounter + Y_OFFSET);

                        //x = 32 - x;
                        y = 25 - y;

                        gameRound.Add(CreateObject(expression, x, y));
                    }
                }
            }
        }

        private void ParseTiles()
        {
            if(!levelSource.Contains("TILES"))
            {
                throw new ContentLoadException("Level does not contain TILES section.");
            }

            int currentId = -1;
            bool parsingExpression = false;
            string expression = "";
            int endIndex = levelSource.IndexOf("LEVEL");

            for (int index = levelSource.IndexOf("TILES") + 5; index < levelSource.Length && index != endIndex; index++)
            {
                char curChar = levelSource[index];
                if(currentId == -1 && char.IsNumber(curChar))
                {
                    currentId = int.Parse(curChar.ToString());
                }
                else if(currentId == -1)
                {
                    continue;
                }

                if (curChar == '{')
                {
                    parsingExpression = true;
                }
                else if(curChar == '}')
                {
                    parsingExpression = false;
                    TileExpressions.Add(currentId, expression);
                    currentId = -1;
                    expression = "";
                }
                else if(parsingExpression)
                {
                    expression += curChar;
                }
            }
        }

        private GameObject CreateObject(string expression, float x, float y)
        {
            expression = "from MarioBros import *\r\nfrom Microsoft.Xna.Framework import *\r\n" + expression;

            var source = scriptEngine.CreateScriptSourceFromString(expression);
            var scope = scriptEngine.CreateScope();

            scope.SetVariable("x", x);
            scope.SetVariable("y", y);

            source.Execute(scope);

            if(!scope.ContainsVariable("tile"))
            {
                throw new InvalidOperationException("Tile script does not set the 'tile' variable appropriately.");
            }

            return scope.GetVariable("tile");
        }
    }
}
