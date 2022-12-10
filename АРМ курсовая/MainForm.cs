using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using АРМ_курсовая.Resources;

namespace АРМ_курсовая
{
    public partial class MainForm : Form
    {
        //public MainFormViewModel ViewModel;
        public Waiter CurrentWaiter;
        public MainForm(Waiter CurrentWaiter)
        {
            InitializeComponent();
            //this.lbName = $"{ViewModel.currentSession.CurrentWorker.Surname} {ViewModel.currentSession.CurrentWorker.Name}";
        }

        private void btAddQuest_Click(object sender, EventArgs e)
        {
            

        }
    }
}
