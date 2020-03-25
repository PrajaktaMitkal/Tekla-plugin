using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tekla.Structures.Datatype;
using Tekla.Structures.Dialog;

namespace TeklaVSDemo1
{
    public partial class MainForm : PluginFormBase
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Apply();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Modify();
        }
    }
}
