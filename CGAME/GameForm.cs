
using System.Windows.Forms;

namespace CGAME
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            PaintEventHandler paintEvent = new PaintEventHandler(this.OnPaint);

            this.Paint += new PaintEventHandler(this.OnPaint);
        }

        public void SetScene(Scene _scene)
        {
            currentScene = _scene;
        }

        public void SetCamera(Camera _camera)
        {
            currentCamera = _camera;
        }

        private Scene currentScene;
        private Camera currentCamera;

        public void CGUpdate()
        {
            if (!Focused) return;

            if (currentScene != null)
                currentScene.Update();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            if (e.Graphics.SmoothingMode != System.Drawing.Drawing2D.SmoothingMode.AntiAlias)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            }

            currentCamera.Update(e.Graphics);

            if (currentScene != null)
                currentScene.UpdateGFX(e.Graphics);
        }
    }
}
