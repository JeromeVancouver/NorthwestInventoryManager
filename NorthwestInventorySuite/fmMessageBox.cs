using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NorthwestInventoryManager
{
    public partial class fmMessageBox : Form
    {

        private string message;
        private Point position;

        public fmMessageBox()
        {
            InitializeComponent();
        }

        public fmMessageBox(string m)
        {
            InitializeComponent();
            message = m;
        }

        public fmMessageBox(string m, Point startPos)
        {
            InitializeComponent();
            message = m;
            position = startPos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fmMessageBox_Load(object sender, EventArgs e)
        {
            lbMessage.Text = message;
            Globals.FM_MESSAGEBOX.Location = position;
        }

    }
}
