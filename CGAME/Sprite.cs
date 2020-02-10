using System.Drawing;

namespace CGAME
{
    [System.Serializable]
    public class Sprite
    {
        public Image m_Image { get; private set; }

        private Vector2 m_Size;
        private GameObject m_ParrentObject; //

        public bool revertX = false;
        private bool prev_revertX = false;

        public Sprite(Sprite sprite)
        {
            m_ParrentObject = sprite.m_ParrentObject;
            m_Size = sprite.m_Size;
            m_Image = sprite.m_Image;
        }

        public Sprite(GameObject _parrent, Vector2 _size, Image _image)
        {
            m_ParrentObject = _parrent;
            m_Size = _size;
            m_Image = _image;
        }

        public void SetParrent(GameObject _parrent)
        {
            m_ParrentObject = _parrent;
        }

        public void Draw(Graphics g)
        {
            if (revertX != prev_revertX)
            {
                m_Image.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipY);

                prev_revertX = revertX;
            }

            g.DrawImage(m_Image, (float)(m_ParrentObject.m_Position.x - m_Size.x/2), (float)(m_ParrentObject.m_Position.y - m_Size.y / 2),
                                          (float)m_Size.x, (float)m_Size.y);
        }

        public void UpdateImage(Image _image)
        {
            m_Image = _image;
        }

        public static Sprite CreateSprite(GameObject _parrent, Image _image, Vector2 _size)
        {
            return new Sprite(_parrent, _size, _image);
        }
    }
}
