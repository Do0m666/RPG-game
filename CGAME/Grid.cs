

using System.Drawing;
using System.Windows.Forms;

namespace CGAME
{
    public class Grid
    {
        public int rows { get; private set; }
        public int cols { get; private set; }
        public int size { get; private set; }
        public Cell[,] cell { get; private set; }

        public Grid (int  _rows ,int _cols, int _size)
        {
            rows = _rows;
            cols = _cols;
            size = _size;

            createCell();
        }

        private Vector2 _position;

        private void createCell()
        {
            cell = new Cell[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    _position.x = i * size + size / 2;
                    _position.y = j * size + size / 2;
                    cell[i, j] = new Cell(_position, size);
                }
            }
     
        }
        public void UpdateGFX(Graphics _g)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    cell[i, j].UpdateGFX(_g);
                }
            }
        }

        public void AddGameObject(Player _player)
        {
            cell[0, 0].AddGameObject(_player);
        }

        public void AddObjectonPosition(GameObject _gameObject, int x , int y)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
            
                    

                    if (cell[i, j].Position.x == x && cell[i, j].Position.y == y)
                    {
                        System.Console.WriteLine("Found and add to cel1l");

                        cell[i, j].ChildGameObject.Add(_gameObject);
                    }
                }
            }
        }

        public void AddGameObject(GameObject _gameObject)
        {
            if (_cell == null) return;

            _cell.AddGameObject(_gameObject);
        }

        Cell _cell;

        public void UpdateGameObjectPosition(GameObject _gameObject, Point _point, Vector2 _pivot, int _sizeX, int _sizeY)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (cell[i, j].IsInside(_point.X + _pivot.x - _sizeX, _point.Y + _pivot.y - _sizeY))
                    {

                        if (cell[i, j].ChildGameObject.Contains(_gameObject))
                        {
                            return;
                        }

                        _cell = FindCell(_gameObject);
                        
                        if (_cell != null)
                        {
                            _cell.RemoveGameObject(_gameObject);
                        }

                        cell[i, j].AddGameObject(_gameObject);

                        _cell = cell[i, j];

                        return;
                    }
                }
            }
        }

        public void RemoveObjectsOnCell(Scene _scene, Point _point, Vector2 _pivot, int _sizeX, int _sizeY)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (cell[i, j].IsInside(_point.X + _pivot.x - _sizeX, _point.Y + _pivot.y - _sizeY))
                    {

                        for (int z = 0; z < cell[i, j].ChildGameObject.Count; z++)
                        {
                            _scene.GameObjects.Remove(cell[i, j].ChildGameObject[z]);
                        }

                        cell[i, j].ChildGameObject.Clear();

                        return;
                    }
                }
            }
        }

        private Cell FindCell(GameObject _gameObject)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (cell[i, j].ChildGameObject.Contains(_gameObject))
                    {
                        return cell[i, j];
                    }
                }
            }

            return null;
        }
    }
}
