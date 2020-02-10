
using System.Drawing;
using System.Windows.Forms;

namespace CGAME
{
    class Game
    {
        public bool isPlaying { get; private set; }

        private Scene scene;

        private GameForm gameForm;

        private EditorForm parrent;

        private Camera gameCamera;

        private GameObject cameraPivot;

        private CollisionMeneger collisionMeneger;

        public Game(Scene _scene, EditorForm _parrent)
        {
            scene = new Scene(_scene.GetName());

            gameForm = new GameForm();

            gameForm.SetScene(scene);

            parrent = _parrent;

            gameForm.FormClosing += Form1_FormClosing;

            for (int i = 0; i < scene.GameObjects.Count; i++)
            {
                if (scene.GameObjects[i].gameObjectType == GameObjectType.PLAYER)
                {
                    cameraPivot = scene.GameObjects[i];
                }
            }

            Enemy e;
            Player p = (Player)cameraPivot;

            for (int i = 0; i < scene.GameObjects.Count; i++)
            {
                if (scene.GameObjects[i].gameObjectType == GameObjectType.ENEMY)
                {
                    e = (Enemy)scene.GameObjects[i];

                    e.SetPlayer(p);
                }
            }

            gameCamera = new Camera(cameraPivot, gameForm);

            gameForm.SetCamera(gameCamera);

            isPlaying = false;

            collisionMeneger = new CollisionMeneger(scene);
        }

        public void Start()
        {
            isPlaying = true;

            MusicManager.PlayMusic(MusicManager.backgroundMusic);

            scene.Activate();

            gameForm.Show();
        }

        public void Stop()
        {
            isPlaying = false;
        }

        public void Update()
        {
            if (!isPlaying) return;

            collisionMeneger.Collision();

            InputManager.Update();

            gameForm.CGUpdate();
            gameForm.Refresh();

            if (!CheckPlayerExist())
            {

                DialogResult dr = MessageBox.Show("Dead", "You lose!", MessageBoxButtons.OK);

                if (dr == DialogResult.OK)
                {
                    System.Console.WriteLine("CloSE");

                    MusicManager.StopMusic();

                    Stop();

                    parrent.GameClosed();

                    gameForm.Close();
                }
            }
        }

        private bool CheckPlayerExist()
        {
            for (int i = 0; i < scene.GameObjects.Count; i++)
            {
                if (scene.GameObjects[i].gameObjectType == GameObjectType.PLAYER)
                {
                    return scene.GameObjects[i].IsActive;
                }
            }

            return false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MusicManager.StopMusic();

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            if (e.CloseReason == CloseReason.UserClosing)
            {
                Stop();
                parrent.GameClosed();
            }
        }
    }
}
