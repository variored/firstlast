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
    }
}
