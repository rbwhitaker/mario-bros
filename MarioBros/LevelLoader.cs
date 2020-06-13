using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MarioBros
{
    class LevelLoader
    {
        private Dictionary<int, ObjectCreator> ObjectCreators { get; }
        private string levelSource;

        public LevelLoader(string levelSource)
        {
            ObjectCreators = new Dictionary<int, ObjectCreator>();
            this.levelSource = levelSource;
            ParseTiles();
        }

        public void LoadLevel(GameRound gameRound)
        {
            if (!levelSource.Contains("LEVEL"))
            {
                throw new ContentLoadException("Level does not contain LEVEL section.");
            }


        }

        private void ParseTiles()
        {
            if(!levelSource.Contains("TILES"))
            {
                throw new ContentLoadException("Level does not contain TILES section.");
            }

            for (int index = levelSource.IndexOf("TILES") + 5; index < levelSource.Length; index++)
            {
                char curChar = levelSource[index];
                if(char.IsWhiteSpace(curChar))
                {
                    continue;
                }
            }
        }

        private class ObjectCreator
        {
            public Dictionary<string, string> Arguments { get; }
            public Type GameObjectType { get; }

            public ObjectCreator(Type gameObjectType)
            {
                Arguments = new Dictionary<string, string>();
                GameObjectType = gameObjectType;
            }

            public GameObject Create()
            {
                var result = InstantiateObject();

                foreach (var property in GameObjectType.GetProperties())
                {
                    if(!property.CanWrite)
                    {
                        continue;
                    }
                    if(Arguments.TryGetValue(property.Name, out var expression))
                    {
                        property.SetValue(result, Eval(expression, property.PropertyType));
                    }
                }

                return result;
            }

            private GameObject InstantiateObject()
            {
                var ctors = GameObjectType.GetConstructors();

                var defaultCtor = GameObjectType.GetConstructor(Type.EmptyTypes);
                if (defaultCtor != null)
                {
                    return (GameObject)Activator.CreateInstance(GameObjectType);
                }

                object[] ctorParameters = new object[0];
                foreach (var item in ctors)
                {
                    var parameterDefinitions = item.GetParameters();
                    ctorParameters = new object[parameterDefinitions.Length];

                    for (int i = 0; i < parameterDefinitions.Length; i++)
                    {
                        var param = parameterDefinitions[i];
                        if (Arguments.TryGetValue(param.Name, out var expression))
                        {
                            ctorParameters[i] = Eval(expression, param.ParameterType);
                        }
                        else
                        {
                            ctorParameters = new object[0];
                            break;
                        }
                    }
                }

                return (GameObject)Activator.CreateInstance(GameObjectType, ctorParameters);
            }

            private object Eval(string expression, Type targetType)
            {
                return null;
            }
        }
    }
}
