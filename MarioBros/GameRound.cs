using System.Collections.Generic;

namespace MarioBros
{
    public class GameRound
    {
        private readonly List<GameObject> objects = new List<GameObject>();

        public IEnumerable<GameObject> Objects => objects;

        public void Update(double elapsedSeconds)
        {
            foreach (GameObject gameObject in objects)
                gameObject.Update(elapsedSeconds);
        }
    }
}
