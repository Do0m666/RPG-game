

using System.Drawing;

namespace CGAME
{
    public enum GameObjectType
    {
        DEFAULT,
        ENEMY,
        PLAYER
    }

    [System.Serializable]
    public class GameObject
    {
        public string m_Name { get; private set; }
        public Vector2 m_Position { get; private set; }
        public Collider m_Collider { get; private set; }
        public Sprite m_Sprite { get; private set; }
        public Animation[] m_Animations { get; private set; }

        public GameObjectType gameObjectType { get; protected set; }

        public bool IsDinamic { get; private set; }

        public bool Iteractable { get; private set; }  

        public bool IsActive { get; private set; }

        public GameObject(GameObject gameObject)
        {
            m_Name = gameObject.m_Name;
            m_Position = gameObject.m_Position;

            m_Collider = gameObject.m_Collider;

            if (m_Collider != null)
                m_Collider.SetParrent(gameObject);

            m_Sprite = new Sprite(gameObject.m_Sprite);

            if (m_Sprite != null)
                m_Sprite.SetParrent(gameObject);

            Iteractable = false;
            IsDinamic = gameObject.IsDinamic;

            gameObjectType = GameObjectType.DEFAULT;

            IsActive = true;
        }

        public GameObject(string _name, Vector2 _position,
                          Collider _collider = null, Sprite _sprite = null, bool _dynamic = false)
        {
            m_Name = _name;
            m_Position = _position;
            m_Collider = _collider;
            m_Sprite = _sprite;

            Iteractable = false;
            IsDinamic = _dynamic;

            gameObjectType = GameObjectType.DEFAULT;

            IsActive = true;
        }

        // SET 

        public void SetActive(bool _active)
        {
            IsActive = _active;
        }

        public void SetIteractable(bool _iteractable)
        {
            Iteractable = _iteractable;
        }

        public void SetPosition(Vector2 _position)
        {
            m_Position = _position;
        }

        public void SetName(string _name)
        {
            m_Name = _name;
        }

        public void SetCollider(Collider _collider)
        {
            m_Collider = _collider;
        }

        public void SetSprite(Sprite _sprite)
        {
            m_Sprite = _sprite;
        }

        public void SetAnimations(Animation[] _animations)
        {
            m_Animations = _animations;
        }

        //


        // FUNCTIONS

        public virtual void SetPlayer(Player _player)
        {

        }

        public virtual void Update()
        {
            if (!IsActive) return;
            if (!Iteractable) return;
            //

            if (m_Animations != null)
            {
                for (int i = 0; i < m_Animations.Length; i++)
                {
                    m_Animations[i].Update();
                }
            }

            if (m_Collider != null)
            {
                m_Collider.Compute();
            }
        }

        public void UpdateGFX(Graphics g)
        {
            if (!IsActive) return;

            m_Sprite.Draw(g);
        }

    }
}
