﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace secpolo {
    public partial class LoginDlg : Form {
        public LoginDlg() {
            InitializeComponent();
        }

        public WebBrowser WebBrowser{
            get { return webBrowser; }
        }

    }
}
