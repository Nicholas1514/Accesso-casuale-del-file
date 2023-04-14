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
        int recordLenght;
        String line;
        byte[] br;
        public Form1()
        {
            InitializeComponent();
            nfile = @"random.csv";
            recordLenght = 64;
        }

        public struct Prod
        {
            public string nprod;
            public float prezzo;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //bottone aggiunta
        private void button1_Click(object sender, EventArgs e)
        {
            Aggiunta(textBox1.Text, textBox2.Text, nfile);
        }
        //bottone ricerca
        private void button2_Click(object sender, EventArgs e)
        {
            bool ricerca = Ricerca(nfile);
            if (ricerca == true)
            {
                MessageBox.Show("Il prodotto è presente nel file");
            }
            else
            {
                MessageBox.Show("Prodotto non trovato");
            }
        }
        public void Aggiunta(string nprod, string prezzo, string filename)
        {
            var oStream = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(oStream);
            sw.WriteLine(nprod + " " + prezzo);
            sw.Close();
        }

        public bool Ricerca(string nfile)
        {
            bool ricerca = false;
            var f = new FileStream(nfile, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(f);
            f.Seek(0, SeekOrigin.Begin);
            while(f.Position < f.Length)
            {
                br = reader.ReadBytes(recordLenght);
                line = Encoding.ASCII.GetString(br, 0, br.Length);
                MessageBox.Show(line);
                if(line.Contains(textBox3.Text))
                {
                    ricerca = true;
                }
                
            }
            return ricerca;
        }

       
    }
}
