namespace MarioBros
{
    public struct CollisionDirections
    {
        public bool Left { get; }
        public bool Right { get; }
        public bool Top { get; }
        public bool Bottom { get; }

        public CollisionDirections(bool left, bool right, bool top, bool bottom) { Left = left; Right = right; Top = top; Bottom = bottom; }
    }

    public struct Collision
    {
        public GameObject A { get; }
        public GameObject B { get; }
        public CollisionDirections Directions { get; }

        public Collision(GameObject a, GameObject b, CollisionDirections directions) { A = a; B = b; Directions = directions; }
    }
}
