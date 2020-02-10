
using System.Collections.Generic;

namespace CGAME
{
    [System.Serializable]
    public class Player : Character
    {
        public Vector2 Velocity { get; private set; }

        public Vector2 Direction { get; private set; }

        public double Speed { get; private set; }

        private List<Enemy> enemies = new List<Enemy>(); 

        private int distanceAttack;

        public Player(string _name, Vector2 _position, Collider _collider, Sprite _sprite, float _health, float _demage, double _speed) : base(_name, _position, _collider, _sprite, _health, _demage)
        {

            Speed = _speed;
            distanceAttack = 64;

            gameObjectType = GameObjectType.PLAYER;
        }

        public void AddEnemie(Enemy _enemie)
        {
            enemies.Add(_enemie);
        }

        public void RemoveEnemie(Enemy _enemie)
        {
            enemies.Remove(_enemie);
        }

        public override void Update()
        {
            if (isDead) return;

            base.Update();

            if (!Iteractable) return; 

            InputHandler();

            Velocity = Direction * Speed;

            pos = m_Position;

            pos += Velocity * Time.deltaTime;

            SetPosition(pos);
        }

        private Vector2 dir, pos;

        private void InputHandler()
        {
            dir = Direction;

            dir.x = InputManager.GetButton(Action.MOVE_LEFT) ? -1 : InputManager.GetButton(Action.MOVE_RIGHT) ? 1 : 0;
            dir.y = InputManager.GetButton(Action.MOVE_DOWN) ? 1 : InputManager.GetButton(Action.MOVE_UP) ? -1 : 0;

            if (InputManager.GetButtonDown(Action.MOVE_LEFT))
            {
                m_Sprite.revertX = true;
            }
            else
            if(InputManager.GetButtonDown(Action.MOVE_RIGHT))
            {
                m_Sprite.revertX = false;
            }

            Direction = dir;

            if (InputManager.GetButtonDown(Action.ATTACK))
            {
                for(int i = 0; i < enemies.Count; i++)
                {

                    if (Vector2.distance(enemies[i].m_Position, m_Position) < distanceAttack)
                    {
                        Attack(enemies[i]);
                    }
                }
            }

        }
      
    }
}
