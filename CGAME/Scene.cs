
using System.Collections.Generic;
using System.Drawing;

namespace CGAME
{
    [System.Serializable]
    public class Scene
    {
        private string name;

        public List<GameObject> GameObjects { get; private set; }

        private bool newSccene = false;

        public int GridSizeX { get; private set; }

        public int GridSizeY { get; private set; }

        public Scene(string _sceneName, Grid _grid = null, bool _new = false)
        {
            name = _sceneName;

            Scene s = SceneManager.LoadScene(_sceneName);

            if (s == null || _new)
            {
                if (GameObjects == null || _new)
                {
                    newSccene = true;

                    if (_grid != null)
                    {
                        SetGridSize(_grid.rows, _grid.cols);
                    }

                    GameObjects = new List<GameObject>();
                }
            }
            else
            {
                GameObjects = s.GameObjects;

                GridSizeX = s.GridSizeX;
                GridSizeY = s.GridSizeY;

                if (GameObjects != null && _grid != null)
                {
                    _grid = new Grid(GridSizeX, GridSizeY, 30);

                    for (int i = 0; i < GameObjects.Count; i++)
                    {
                        _grid.AddObjectonPosition(GameObjects[i], (int)GameObjects[i].m_Position.x, (int)GameObjects[i].m_Position.y); // установка сохр объект вставляем в новую сетку
                    }
                }

            }
        }

        public void SetGridSize(int _sizeX, int _sizeY)
        {
            GridSizeX = _sizeX;
            GridSizeY = _sizeY;
        }

        public void SetName(string _name)
        {
            name = _name;
        }

        public void AddGameObject(GameObject _gameObject)
        {
            GameObjects.Add(_gameObject);
        }

        public void Activate()
        {
            for (int i = 0; i < GameObjects.Count; i++)
            {
                GameObjects[i].SetIteractable(true);
            }
        }

        public string GetName()
        {
            return name;
        }

        public void Update()
        {
            for (int i = 0; i < GameObjects.Count; i++)
            {
                GameObjects[i].Update();
            }
        }

        public void UpdateGFX(Graphics _graphics)
        {
            for (int i = 0; i < GameObjects.Count; i++)
            {
                GameObjects[i].UpdateGFX(_graphics);
            }
        }
    }
}
