using System.Collections.Generic;

namespace MarioBros
{
    public class GameRound
    {
        private readonly List<GameObject> objects = new List<GameObject>();

        public IEnumerable<GameObject> Objects => objects;

        public void Add(GameObject newObject)
        {
            objects.Add(newObject);
        }

        public void Update(float elapsedSeconds)
        {
            foreach (GameObject gameObject in objects)
                gameObject.Update(elapsedSeconds);
        }
    }
}
