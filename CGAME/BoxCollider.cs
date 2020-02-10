
using System.Drawing;

namespace CGAME
{
    [System.Serializable]
    class BoxCollider : Collider
    {
        public Vector2 min { get; private set; }
        public Vector2 max { get; private set; }
        public Vector2 size { get; private set; }

        public BoxCollider(GameObject _parrent) : base(_parrent)
        {
            setType(ColliderType.BOX);
            size = new Vector2(28, 28);

            ComputePoints();
        }

        private Vector2 v;

        public override void Compute()
        {
            ComputePoints();
        }

        private void ComputePoints()
        {
            v = min;

            v.x = m_Parrent.m_Position.x - (size.x);
            v.y = m_Parrent.m_Position.y - (size.y);

            min = v;

            v = max;

            v.x = min.x + size.x;
            v.y = min.y + size.y;

            max = v;
        }

      

        private BoxCollider boxColliderTemp;
        private CircleCollider circleColliderTemp;
        public override bool IsIntersect(Collider _collider)
        {
            ComputePoints();

            if (_collider.m_Type == ColliderType.BOX)
            {
                boxColliderTemp = (BoxCollider)_collider;

                return (this.max.x > boxColliderTemp.min.x &&
                        this.min.x < boxColliderTemp.max.x &&
                        this.max.y > boxColliderTemp.min.y &&
                        this.min.y < boxColliderTemp.max.y);
            }
            else if (_collider.m_Type == ColliderType.CIRCLE)
            {
                circleColliderTemp = (CircleCollider)_collider;
                double distanceMin = Vector2.distance(this.min, circleColliderTemp.getParrent().m_Position);
                double distanceMax = Vector2.distance(this.max, circleColliderTemp.getParrent().m_Position);
                return distanceMin >= circleColliderTemp.radius * circleColliderTemp.radius && distanceMax <= circleColliderTemp.radius * circleColliderTemp.radius; 
              
            }

            return false;
        }
    }
}
