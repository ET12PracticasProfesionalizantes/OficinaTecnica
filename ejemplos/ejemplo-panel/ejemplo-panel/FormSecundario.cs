using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejemplo_panel
{
    public partial class FormSecundario : Form
    {
        public FormSecundario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Close();
            this.panelFormSecundario.Controls.Clear();
        }
    }
}
