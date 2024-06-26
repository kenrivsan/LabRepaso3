﻿using System;
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
        List<clsDatos> datos = new List<clsDatos>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsPropietarios propietario = new clsPropietarios();
            propietario.Dpi = int.Parse(txtDpi.Text);
            propietario.Nombre = txtNombre.Text;
            propietario.Apellido = txtApellido.Text;

            propietarios.Add(propietario);

            clsPropiedades propiedad = new clsPropiedades();
            propiedad.NoCasa = int.Parse(txtNocasa.Text);
            propiedad.Dpi = int.Parse(txtDpi.Text);
            propiedad.Cuota = decimal.Parse(txtCuota.Text);
            propiedades.Add(propiedad);


            //cargarPropiedades();
            //cargarPropietarios();
            //mostrarPropietarios();
            //mostrarPropiedades();

        }
        public void guardarPropiedades()
        {
            using (FileStream stream = new FileStream("Propiedades.txt", FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    foreach (clsPropiedades propiedadess in propiedades)
                    {
                        writer.WriteLine(propiedadess.NoCasa);
                        writer.WriteLine(propiedadess.Dpi);
                        writer.WriteLine(propiedadess.Cuota);
                    }
                    writer.Close();
                }
            }
        }
        public void guardarPropietarios()
        {
            using (FileStream stream = new FileStream("Propietarios.txt", FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    foreach (clsPropietarios propietarios in propietarios)
                    {
                        writer.WriteLine(propietarios.Dpi);
                        writer.WriteLine(propietarios.Nombre);
                        writer.WriteLine(propietarios.Apellido);
                    }
                    writer.Close();
                }
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (clsPropietarios propietario in propietarios)
            {
                clsPropiedades propiedad = propiedades.FirstOrDefault(p => p.Dpi == propietario.Dpi);

                if (propiedades != null)
                {
                    clsDatos reporte = new clsDatos
                    {
                        Nombre = propietario.Nombre,
                        Apellidos = propietario.Apellido,
                        Numero = propiedad.NoCasa,
                        Cuota = propiedad.Cuota,
                    };
                    datos.Add(reporte);
                }
            }
            dtvDatos.DataSource = null;
            dtvDatos.DataSource = datos;
            dtvDatos.Refresh();
        }
            
    }
}
