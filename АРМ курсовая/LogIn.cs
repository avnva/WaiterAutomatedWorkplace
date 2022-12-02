using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using АРМ_курсовая.Properties;

namespace АРМ_курсовая
{
    public partial class LogIn : Form
    {
        
        public LogIn()
        {
            InitializeComponent();
        }
        

        private void btLog_Click(object sender, EventArgs e)
        {

            TitlePage Title = new TitlePage();
            Title.Show();
            this.Hide();
        }
    }
}
