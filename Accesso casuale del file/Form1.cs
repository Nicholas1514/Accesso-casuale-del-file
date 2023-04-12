using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accesso_casuale_del_file
{
    public partial class Form1 : Form
    {
        string nfile;
        public Form1()
        {
            InitializeComponent();
            nfile = @"random.txt";
        }

        public struct Prod
        {
            public string nprod;
            public float prezzo;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Aggiunta(string nprod, string prezzo, string filename)
        {
            var oStream = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(oStream);
            sw.WriteLine(nprod + " " + prezzo);
            sw.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Aggiunta(textBox1.Text, textBox2.Text, nfile);
        }
    }
}
