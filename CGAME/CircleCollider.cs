
namespace CGAME
{
    [System.Serializable]
    class CircleCollider : Collider
    {
        public float radius { get; private set; }

        public CircleCollider(GameObject _parrent, float _radius) : base(_parrent)
        {
            setType(ColliderType.CIRCLE);
            radius = _radius;
        }

        private CircleCollider circleColliderTemp;
        private BoxCollider boxColliderTemp;
        public override bool IsIntersect(Collider _collider)
        {
            

            if (_collider.m_Type == ColliderType.BOX)
            {
                boxColliderTemp = (BoxCollider)_collider;
                double distanceMin = Vector2.distance(boxColliderTemp.min, this.m_Parrent.m_Position);
                double distanceMax = Vector2.distance(boxColliderTemp.max, this.m_Parrent.m_Position);
                return distanceMin >= this.radius * this.radius && distanceMax <= this.radius * this.radius; 
            }
            else if (_collider.m_Type == ColliderType.CIRCLE)
            {
                circleColliderTemp = (CircleCollider)_collider;
                return Vector2.distance(this.m_Parrent.m_Position, circleColliderTemp.m_Parrent.m_Position) == this.radius + circleColliderTemp.radius; 
            }

            return false;
        }
    }
}
