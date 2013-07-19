using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace secpolo {
    public enum ConfirmDlgMode{
        OK_CANCEL=0,
        OK=1
    }
    public partial class ConfirmDlg : Form {
        public ConfirmDlg(String str,Image image,ConfirmDlgMode mode) {
            InitializeComponent();

            pictureBox.Image = image;
            label.Text = str;

            if (mode == ConfirmDlgMode.OK){
                buttonCancel.Visible = false;
                buttonOk.Left += 50;
            }
        }
    }
}
