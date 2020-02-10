
using System.Drawing;
using System.Windows.Forms;

namespace CGAME
{
    public class Camera
    {
        private GameObject target;

        private Form parrentForm;

        public Camera(GameObject _target, Form _form)
        {
            target = _target;
            parrentForm = _form;
        }

        public void Update(Graphics _graphics)
        {
            _graphics.TranslateTransform(-(float)target.m_Position.x + parrentForm.Width / 2, -(float)target.m_Position.y + parrentForm.Height / 2);
        }
    }
}
