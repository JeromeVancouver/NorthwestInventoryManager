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
    public partial class fmSaveDialogue : Form
    {
        public fmSaveDialogue()
        {
            InitializeComponent();
        }

        public fmSaveDialogue(string newText)
        {
            InitializeComponent();
            this.Text = newText;
        }

        public void ChangeText(string newText)
        {
            lbText.Text = newText;
            Refresh();
        }
    }
}
