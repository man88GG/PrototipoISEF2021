﻿using CapaControladorSeguridad;
using CapaVistaEncriptar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVistaSeguridad
{
    public partial class frmCambioContraseña : Form
    {
        string Usuario = "";
        clsRecepcion Encriptar = new clsRecepcion();
        public frmCambioContraseña(string User)
        {
            InitializeComponent();
            Usuario = User;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            clsControladorPerfil controladorPerfil = new clsControladorPerfil();
            if (txtNuevaContraseña.Text == "" || txtConfirmarContraseña.Text == "")
            {
                MessageBox.Show("Los Campos no Deben de Estar Vacios");
            }
            else
            {
                if(txtNuevaContraseña.Text == txtConfirmarContraseña.Text)
                {
                    string password = Encriptar.funcEncryp(txtConfirmarContraseña.Text);
                    controladorPerfil.funcModificar_Contraseña(Usuario, password);
                    MessageBox.Show("Contraseña Actualizada Exitozamente");
                    txtNuevaContraseña.Text = "";
                    txtConfirmarContraseña.Text = "";
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Las Contraseñas No Coinciden");
                    txtNuevaContraseña.Text = "";
                    txtConfirmarContraseña.Text = "";
                }
            }
        }

        private void cbkVer_CheckedChanged(object sender, EventArgs e)
        {
            if(cbkVer.Checked == true)
            {
                txtConfirmarContraseña.PasswordChar= '\0';
                txtNuevaContraseña.PasswordChar = '\0';
            }
            else
            {
                txtConfirmarContraseña.PasswordChar = '*';
                txtNuevaContraseña.PasswordChar = '*';
            }
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "AyudasSeguridad/AyudaContrasena/Ayuda.chm", "Cambio-de-Contraseña.html");
        }
    }
}
