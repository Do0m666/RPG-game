

namespace CGAME
{
    [System.Serializable]
    public class Enemy : Character
    {
        public Vector2 Direction { get; private set; }


        private Player player;


        private double distanceToPlayer;
        private int frequencyAttack;
        private int distanceAttack;

        public double Speed { get; private set; }

        public Enemy(string _name, Vector2 _position, Collider _collider, Sprite _sprite, float _health, float _demage) : base(_name, _position, _collider, _sprite, _health, _demage)
        {
            gameObjectType = GameObjectType.ENEMY;
            frequencyAttack = 1;
            distanceAttack = 64;
            Speed = 50;
        }

        public void Move(Vector2 _velocity)
        {
            SetPosition(m_Position + _velocity * Time.deltaTime);
        }

        public override void SetPlayer(Player _player)
        {
            player = _player;

            player.AddEnemie(this);
        }

        double _timer = 0.0;

        public override void Update()
        {
            base.Update();

            if (isDead) return;

            CalculateDirection();

            if (distanceToPlayer < 128)
                Move(Direction * Speed);

            if (player == null) return;

            ComputeDistanceToPlayer();

            if (distanceToPlayer < distanceAttack)
            {
                _timer += Time.deltaTime;

                if (_timer >= frequencyAttack)
                {
                    _timer = 0.0;

                    Attack(player);
                }
            }
        }

        Vector2 dir;

        private void CalculateDirection()
        {
            if (player == null)
            {
                dir = Direction;
                dir.x = 0;
                dir.y = 0;
                Direction = dir;
            }
            else
            {
                Direction = (player.m_Position - m_Position).Normalize();
            }
        }

        private void ComputeDistanceToPlayer()
        {
            distanceToPlayer = Vector2.distance(player.m_Position, m_Position);
        }

        protected override void Die()
        {
            base.Die();

            player.RemoveEnemie(this);
        }
    }
}