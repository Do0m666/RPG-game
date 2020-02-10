
using System.Collections.Generic;

namespace CGAME
{
    class CollisionMeneger
    {
        public Scene scene;
        
        //public List<GameObject> tempObject;
        //public GameObject g;

        //private int dynamicGameObjectsCount = 0;

        public CollisionMeneger(Scene _scene)
        {
            scene = _scene;


            for (int i = 0; i < scene.GameObjects.Count; i++)
            {
                if (scene.GameObjects[i].IsDinamic)
                {
                    gamebjectsDynamic.Add(i, scene.GameObjects[i]);
                    gamebjectsSavedPosiotion.Add(i, scene.GameObjects[i].m_Position);
                }
            }
        }
        

        private Dictionary<int, GameObject> gamebjectsDynamic = new Dictionary<int, GameObject>();

        private Dictionary<int, Vector2> gamebjectsSavedPosiotion = new Dictionary<int, Vector2>();


        public void Collision()
        {

            foreach (var item in gamebjectsDynamic)
            {

                for (int i = 0; i < scene.GameObjects.Count; i++)
                {

                    if (i == item.Key) continue;
                    if (scene.GameObjects[i].m_Collider == null) continue;

                    if (item.Value.gameObjectType == GameObjectType.PLAYER && scene.GameObjects[i].gameObjectType == GameObjectType.ENEMY) continue;
                   
                    if (item.Value.m_Collider.IsIntersect(scene.GameObjects[i].m_Collider))
                    {
                        RevertPostion(item.Key);
                    }
                }

                gamebjectsSavedPosiotion[item.Key] = item.Value.m_Position;
            }
        }

        private void RevertPostion(int _index)
        {
            gamebjectsDynamic[_index].SetPosition(gamebjectsSavedPosiotion[_index]);
        }
    }
}
