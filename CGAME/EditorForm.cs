
using System.Windows.Forms;

namespace CGAME
{
    public partial class EditorForm : Form
    {

        private Scene currentScene;

        private Game currentGame;

        private Camera editorCamera;

        private GameObject cameraPivot;

        private Grid grid;

        private GameObject currentGameObject;

        public EditorForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            PaintEventHandler paintEvent = new PaintEventHandler(this.OnPaint);

            this.Paint += new PaintEventHandler(this.OnPaint);

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            grid = new Grid(10, 10, 30);

            currentScene = new Scene("newScene", grid);

            cameraPivot = new GameObject("cameraPivot", new Vector2(0, 0), null);

            editorCamera = new Camera(cameraPivot, this);

            CreatorManager.FillLoyOutPanel(gameObjectsLayoutPanel, this);
        }

        public void GameClosed()
        {
            playToolStripMenuItem.Enabled = true;
        }

        Vector2 pos;

        public void CGUpdate()
        {
            if (currentGame != null)
                currentGame.Update();

            if (currentGame != null && currentGame.isPlaying && !Focused) return;

            if (currentScene != null)
                currentScene.Update();

            pos = cameraPivot.m_Position;

            if (InputManager.GetButtonTest(Action.MOVE_RIGHT))
            {
                pos.x += 80.0 * Time.deltaTime;
            }

            if (InputManager.GetButtonTest(Action.MOVE_LEFT))
            {
                pos.x -= 80.0 * Time.deltaTime;
            }

            if (InputManager.GetButtonTest(Action.MOVE_UP))
            {
                pos.y -= 80.0 * Time.deltaTime;
            }

            if (InputManager.GetButtonTest(Action.MOVE_DOWN))
            {
                pos.y += 80.0 * Time.deltaTime;
            }

            cameraPivot.SetPosition(pos);

            if (currentGameObject != null)
            {
                currentGameObject.Update();
            }

            if (currentGameObject != null)
                grid.UpdateGameObjectPosition(currentGameObject, this.PointToClient(Cursor.Position), cameraPivot.m_Position, this.Width/2, this.Height/2);

            
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            if (e.Graphics.SmoothingMode != System.Drawing.Drawing2D.SmoothingMode.AntiAlias)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            }

            editorCamera.Update(e.Graphics);

            if (currentGameObject != null)
            {
                currentGameObject.UpdateGFX(e.Graphics);
            }
                
            if (currentScene != null)
                currentScene.UpdateGFX(e.Graphics);

            if (grid != null)
                grid.UpdateGFX(e.Graphics);
        }

        public void CreateGrid(int _rows, int _col)
        {

            grid = new Grid(_rows, _col, 30);
            currentScene.SetGridSize(_rows, _col);
        }

        private void playToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            SceneManager.SaveScene(currentScene);
           
            currentGame = new Game(currentScene, this);

            currentGame.Start();


            playToolStripMenuItem.Enabled = false;
        }

        private void saveAsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileOk += SaveFileDialog1_FileOk;
            saveFileDialog1.ShowDialog();
        }

        private void SaveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            currentScene.SetName(saveFileDialog1.FileName);
            SceneManager.SaveScene(currentScene);
        }

        private void loadToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            openFileDialog1.FileOk += OpenFileDialog1_FileOk;
            openFileDialog1.ShowDialog();
        }

        private void OpenFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            currentScene = new Scene(openFileDialog1.FileName);
        }

        private void saveToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            SceneManager.SaveScene(currentScene);
        }

     
        private void changeSizeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            GridSizeFrame gridSizeFrame = new GridSizeFrame();
            gridSizeFrame.SetForm(this);
          

            gridSizeFrame.Show();
 
        }

        private void PlayerToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            currentGameObject = new Player("player", new Vector2(100, 100), null, null, 100, 10, 100);

            Sprite _sprite = Sprite.CreateSprite(currentGameObject, Images.knight_f_idle_anim_f1, new Vector2(32, 32));
            currentGameObject.SetSprite(_sprite);
            Collider _collider = new BoxCollider(currentGameObject);
            currentGameObject.SetCollider(_collider);
        }

        private void CreateNewObject(int index)
        {
            currentGameObject = new GameObject(CreatorManager.GameObjects[index].m_Name, CreatorManager.GameObjects[index].m_Position, null, null, CreatorManager.GameObjects[index].IsDinamic);

            Sprite s = new Sprite(currentGameObject, new Vector2(32, 32), CreatorManager.GameObjects[index].m_Sprite.m_Image);
            currentGameObject.SetSprite(s);

            if (CreatorManager.GameObjects[index].m_Collider == null) return;

            Collider c = new BoxCollider(currentGameObject);
            currentGameObject.SetCollider(c);

        }

        public void B_Click(object sender, System.EventArgs e)
        {
            Button b = (Button)sender;

            CreateNewObject(b.TabIndex);

            prevCreatedObjectIndex = b.TabIndex;
        }

        private int prevCreatedObjectIndex = 0;


        private void createToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            currentScene = new Scene("newScene", grid ,true);
        }

        private void EditorForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (currentGameObject == null) return;

                grid.AddGameObject(currentGameObject);

                currentScene.AddGameObject(currentGameObject);

                if (currentGameObject.gameObjectType == GameObjectType.PLAYER)
                {
                    currentGameObject = null;
                }
                else if (currentGameObject.gameObjectType == GameObjectType.DEFAULT)
                {
                    currentGameObject = null;
                    CreateNewObject(prevCreatedObjectIndex);
                }
                else if (currentGameObject.gameObjectType == GameObjectType.ENEMY)
                {
                    currentGameObject = null;

                    currentGameObject = new Enemy("enemy", new Vector2(100, 100), null, null, 100, 10);

                    if (currentPlayer != null)
                    {
                        currentGameObject.SetPlayer(currentPlayer);
                    }

                    Sprite _sprite = Sprite.CreateSprite(currentGameObject, Images.big_demon_idle_anim_f1, new Vector2(32, 32));
                    currentGameObject.SetSprite(_sprite);
                    Collider _collider = new BoxCollider(currentGameObject);
                    currentGameObject.SetCollider(_collider);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (currentGameObject != null)
                {
                    currentGameObject = null;
                }
                else
                {
                    grid.RemoveObjectsOnCell(currentScene,this.PointToClient(Cursor.Position), cameraPivot.m_Position, this.Width / 2, this.Height / 2);
                }
            }
        }

        public Player currentPlayer;

        private void EnemyToolStripMenuItem_Click(object sender, System.EventArgs e)
        {


            currentGameObject = new Enemy("enemy", new Vector2(100, 100), null, null, 100, 10);

            if (currentPlayer !=null)
            {
                currentGameObject.SetPlayer(currentPlayer);
            }

            Sprite _sprite = Sprite.CreateSprite(currentGameObject, Images.big_demon_idle_anim_f1, new Vector2(32, 32));
            currentGameObject.SetSprite(_sprite);
            Collider _collider = new BoxCollider(currentGameObject);
            currentGameObject.SetCollider(_collider);
        }


    }
}
