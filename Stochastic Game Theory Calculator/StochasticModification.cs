using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stochastic_Game_Theory_Calculator
{
    public partial class StochasticModification : Form
    {
        public int itterations = 25;
        public StochasticModification()
        {
            InitializeComponent();
        }

        private void SaveItterations_Click(object sender, EventArgs e)
        {
            itterations = (int)ittarations_input.Value;
            Close();
        }
   
        private void ittarations_input_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
