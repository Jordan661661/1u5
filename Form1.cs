using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _07_05_25
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        { 
            lstLista.Items.Insert(0, txtNombre.Text);
            txtNombre.Clear();
            txtNombre.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lstLista.View = View.Details;
            lstLista.LabelEdit = true;
            lstLista.FullRowSelect = true;
            lstLista.GridLines = true;
            lstLista.Columns.Add("Nombre", -2, HorizontalAlignment.Left);
            string ruta = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo dir = new DirectoryInfo(ruta);
            foreach (var fil in dir.GetFiles())
            {
                lstLista.Items.Add(fil.Name);
            }
            foreach (var fil in dir.GetFiles("*.txt"))
            {
                MessageBox.Show(fil.Name);
            }
            foreach (var fil in dir.GetFiles("h?.*"))
            {
                MessageBox.Show(fil.Name);
            }
            foreach (var fil in dir.GetDirectories())
            {
                MessageBox.Show(fil.Name);
            }
        }

        private void lstLista_DoubleClick(object sender, EventArgs e)
        {
            lblLectura.Text = lstLista.SelectedItems[0].Text;
            txtLectura.Clear();
            string lectura = "";
            StreamReader fichero;
            fichero = File.OpenText(lstLista.SelectedItems[0].Text);
            while (!fichero.EndOfStream)
            {
                lectura = fichero.ReadLine();
                txtLectura.Text += lectura+ "\r \n";
                lblLectura.Text += lectura + "\r \n";
            }
            fichero.Close();
        }
    }
}
