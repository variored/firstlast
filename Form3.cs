using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tusur_informatika_kursovaya
{
    public partial class Form3 : Form
    {
        int gameType = 1;

        public Form3()
        {
            InitializeComponent();
        }
        public int GetGameType()
        {
            return gameType;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Form1 parentForm = (this.Parent as Form1);
            parentForm.SetNewGameType(3);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
