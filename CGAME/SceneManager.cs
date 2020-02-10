
using System.Collections.Generic;

namespace CGAME
{
    static class SceneManager
    {
        private static List<Scene> scenes = new List<Scene>();

        public static Scene GetScene(int _index) 
        {
            if (_index >= 0 && _index < scenes.Count)
                return scenes[_index];
            else
                return null;
        }

        public static Scene CreateNewScene(string _name)
        {
            return new Scene(_name);
        }

        public static Scene LoadScene(string _name)
        {
            Scene scene = null;

            scene = Tools.ReadFromBinaryFile<Scene>(_name);

            if (scene == null)
            {
                return null;
            }
            else
            {
                return scene;
            }
        }

        public static void SaveScene(Scene _scene)
        {
            Tools.WriteToBinaryFile(_scene.GetName(), _scene);
        }
    }
}
