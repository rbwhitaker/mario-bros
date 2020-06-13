namespace MarioBros
{
    public struct Collision
    {
        public GameObject A { get; }
        public GameObject B { get; }

        public Collision(GameObject a, GameObject b) { A = a; B = b; }
    }
}
