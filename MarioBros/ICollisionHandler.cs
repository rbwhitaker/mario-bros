namespace MarioBros
{
    public interface ICollisionHandler
    {
        bool ShouldHandle(Collision collision);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="directions">Indicates if `a` entered into `b` from any of the four directions specified by `directions`.</param>
        void Handle(GameObject a, GameObject b, CollisionDirections directions);
    }
}
