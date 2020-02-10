
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CGAME
{
    public static class CreatorManager
    {
        public static List<GameObject> GameObjects { get; private set; }

        private static GameObject gameObject;
        private static Sprite sprite;
        private static Collider collider;
        private static Vector2 pos;

        private static EditorForm editorForm;

        static CreatorManager()
        {
            GameObjects = new List<GameObject>();

            CreateObject("tile_01", Images.floor_1);
            CreateObject("tile_02", Images.floor_2);
            CreateObject("tile_03", Images.floor_3);
            CreateObject("tile_04", Images.floor_4);
            CreateObject("wall_left", Images.wall_left, true);
            CreateObject("wall_right", Images.wall_right, true);
            CreateObject("wall_mid", Images.wall_mid, true);
            CreateObject("wall_side_front_left", Images.wall_side_front_left);
            CreateObject("wall_side_front_right", Images.wall_side_front_right);
            CreateObject("wall_top_left", Images.wall_top_left);
            CreateObject("wall_top_right", Images.wall_top_right);
            CreateObject("wall_top_mid", Images.wall_top_mid);


        }

        private static void CreateObject(string name, Image image, bool isCollider = false)
        {
            gameObject = new GameObject(name, pos);

            if (isCollider)
            {
                collider = new BoxCollider(gameObject);

                gameObject.SetCollider(collider);
            }

            sprite = new Sprite(gameObject, new Vector2(32, 32), image);

            gameObject.SetSprite(sprite);

            GameObjects.Add(gameObject);
        }

        public static void FillLoyOutPanel(FlowLayoutPanel _panel, EditorForm _editorForm)
        {
            _panel.AutoScroll = true;

            editorForm = _editorForm;

            for (int i = 0; i < GameObjects.Count; i++)
            {
                Button b = new Button();
                b.Name = GameObjects[i].m_Name;
                b.BackgroundImage = GameObjects[i].m_Sprite.m_Image;
                b.Size = new System.Drawing.Size(32, 32);
                b.BackgroundImageLayout = ImageLayout.Center;

                b.Click += editorForm.B_Click;

                _panel.Controls.Add(b);
            }

        
        }
    }
}
