
using System.Drawing;

namespace CGAME
{
    public enum ColliderType
    {
        BOX,
        CIRCLE
    }

    [System.Serializable]
    public abstract class Collider
    {
        protected GameObject m_Parrent;
        public ColliderType m_Type { get; private set; }

        public Collider(GameObject _parrent)
        {
            m_Parrent = _parrent;
        }

        public virtual void Draw(Graphics g)
        {

        }

        public void SetParrent(GameObject _parrent)
        {
            m_Parrent = _parrent;
        }

        public virtual bool IsIntersect(Collider _collider)
        {
            return false;
        }

        public virtual void Compute()
        {

        }

        protected void setType(ColliderType _type)
        {
            m_Type = _type;
        }
        public GameObject getParrent()
        {
            return m_Parrent;
        }
    }
}
