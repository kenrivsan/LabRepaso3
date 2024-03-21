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


namespace LabRepaso3
{
    public partial class Form1 : Form
    {
        List<clsPropiedades> propiedades = new List<clsPropiedades>();
        List<clsPropietarios> propietarios = new List<clsPropietarios>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargarPropiedades();
            cargarPropietarios();
            mostrarPropietarios();
            mostrarPropiedades();

        }
        void cargarPropietarios()
        {
            if (propietarios.Count == 0)
            {
                string fileName = "Propietarios.txt";
                FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                while (reader.Peek() > -1)
                {
                    clsPropietarios propietario = new clsPropietarios();
                    propietario.Dpi = int.Parse(reader.ReadLine());
                    propietario.Nombre = reader.ReadLine();
                    propietario.Apellido = reader.ReadLine();

                    propietarios.Add(propietario);

                }
                reader.Close();
            }
        }
        void mostrarPropietarios()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = propietarios;
            dataGridView1.Refresh();
        }
        void mostrarPropiedades()
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = propiedades;
            dataGridView2.Refresh();
        }
        void cargarPropiedades()
        {
            if (propiedades.Count == 0)
            {
                string fileName = "Propiedades.txt";
                FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                while (reader.Peek() > -1)
                {
                    clsPropiedades propiedad = new clsPropiedades();
                    propiedad.NoCasa = Convert.ToInt32(reader.ReadLine());
                    propiedad.Dpi = Convert.ToInt32(reader.ReadLine());
                    propiedad.Cuota = decimal.Parse(reader.ReadLine());

                    propiedades.Add(propiedad);

                }
                reader.Close();
            }
        }
    }
}
