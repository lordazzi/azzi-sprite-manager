using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//Eu add
using System.Diagnostics;

namespace Azzi_Sprite_Manager
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void donation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("javascript:alert('ops')");
        }
    }
}
