using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OsuHelperTool.Classes.Miscellaneous
{
    public partial class InformationForm : Form
    {
        private Form form;
        private Draggable _move;
        public InformationForm(Form inputForm)
        {
            InitializeComponent();
            _move = new Draggable(this, FormBorder.Size.Height);
            _move.SetMovable(FormBorder);
            form = inputForm;
            
        }

        private void InformationForm_Load(object sender, EventArgs e)
        {

        }

        private void InformationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Enabled = true;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
