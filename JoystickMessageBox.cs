using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motion_Sim
{
    public partial class JoystickMessageBox : Form
    {
        public JoystickMessageBox()
        {
            InitializeComponent();
        }
        public void SetMessage(string message)
        {
            messageLabel.Text = message;
        }
    }
}
