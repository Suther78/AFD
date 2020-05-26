using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FSM_Simple
{
    public partial class Dibujo : Form
    {
        public Button button1;
        public Dibujo()
        {
            button1 = new Button();
            button1.Size = new Size(40, 40);
            button1.Location = new Point(30, 60);
            button1.Text = "Click me";
            this.Controls.Add(button1);
            button1.Click += new EventHandler(button1_Click);
            


            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            

        }

    }
}
