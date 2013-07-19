using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace secpolo {
    public partial class FindDlg : Form {
        public FindDlg() {
            InitializeComponent();
        }

        public String Str{
            get{
                return textBox1.Text;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter){
                DialogResult = DialogResult.OK;
                return;
            }
        }
    }
}
