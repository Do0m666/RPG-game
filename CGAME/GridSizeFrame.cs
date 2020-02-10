using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CGAME
{
    public partial class GridSizeFrame : Form
    {
        private EditorForm parrent;

        public GridSizeFrame()
        {
            InitializeComponent();
        }

        public void SetForm(EditorForm _form)
        {
            parrent = _form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rows = Convert.ToInt32( numericUpDown1.Value);
            int columns = Convert.ToInt32(numericUpDown2.Value);

            parrent.CreateGrid(rows, columns);

            this.Close();
        }
    }
}