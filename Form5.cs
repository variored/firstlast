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
    public partial class Form5 : Form
    {
        String winnerName = "";
        public Form5()
        {
            InitializeComponent();
        }
        public void SetLoser(int _loserId)
        {
            if (_loserId == 1)
            {
                winnerName = "Компьютер";
            }
            else
            {
                winnerName = "Человек";
            }
            UpdateWindowInfo();
        }
        private void UpdateWindowInfo()
        {
            labelUsername.Text = winnerName;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
