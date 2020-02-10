

using System.Collections.Generic;
using System.Drawing;

namespace CGAME
{
    public class Cell
    {
        public Vector2 Position { get; private set; }
        int size;
        private List<GameObject> childGameObject = new List<GameObject>();
        
        public List<GameObject> ChildGameObject
        {
            get { return  childGameObject; }
        }

        public void AddGameObject(GameObject _gameObject)
        {
            _gameObject.SetPosition(Position);

            childGameObject.Add(_gameObject);
        }

        public void RemoveGameObject(GameObject _gameObject)
        {
            childGameObject.Remove(_gameObject);
        }

        public Cell (Vector2 _position, int _size)
        {
            Position = _position;
            size = _size;
        }

        public void UpdateGFX(Graphics _g)
        {
            _g.DrawRectangle(Pens.Black, (float)Position.x - size / 2, (float)Position.y - size / 2, size, size);
        }

        public bool IsInside(double _x, double _y) 
        {
            return _x > Position.x - size / 2 && _x < Position.x + size / 2
                && _y > Position.y - size / 2 && _y < Position.y + size / 2;
        }
    }
}
