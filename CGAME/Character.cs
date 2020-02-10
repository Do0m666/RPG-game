

namespace CGAME
{
    [System.Serializable]
    public abstract class Character : GameObject
    {
        private float health;
        public float demage { get; private set; }
        public bool isDead { get; private set; }

        public Character(string _name, Vector2 _position, Collider _collider, Sprite _sprite, float _health , float _demage ) : base (_name, _position, _collider, _sprite, true)
        {
            health = _health;
            demage = _demage;
            isDead = false;
        }

        public void Attack(Character _character)
        {
            _character.Demage(demage);
        }

        public void Attack(Character[] _characters)
        {
            for (int i = 0; i < _characters.Length; i++)
            {
                _characters[i].Demage(demage);
            }
        }

        public void Demage(float _dmg)
        {
            if (isDead) return;

            health -= _dmg;

            if (health <= 0)
            {
                health = 0;

                Die();
            }
        }

        public override void Update()
        {
            if (isDead) return;

            base.Update();
        }

        protected virtual void Die()
        {
            SetActive(false);

            isDead = true;
        }
    }
}
