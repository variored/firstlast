
using System.Windows.Forms;
using System.Diagnostics;

namespace tusur_informatika_kursovaya
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void labelWebSite_Click(object sender, System.EventArgs e)
        {
            Process.Start(labelWebSite.Text);
        }
    }
}
