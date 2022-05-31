﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Entidades;
using Entidades.Exceptions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibreriaForm
{
    public partial class DarDeBajaCliente : Form
    {
        Vinoteca bacos;
        public DarDeBajaCliente(Vinoteca bacos)
        {
            this.bacos = bacos;
            InitializeComponent();
        }

        private void DarDeBajaCliente_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_buscarPorDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se admiten datos numéricos", "validación Dni", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_buscarPorDni.Text))
                {
                    throw new EstaVacioException("No se introducion ningun valor!");
                }
;
                Cliente c = bacos.buscarCliente(int.Parse(this.txt_buscarPorDni.Text));

                this.rtb_Cliente.Text = c.ToString();
            }
            catch (NoExisteException ex)
            {

                MessageBox.Show(ex.Message, "Cliente No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (EstaVacioException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(rtb_Cliente.Text)))
            {
                DialogResult dialogo = MessageBox.Show("¿esta seguro que desea dar de baja el cliente?",
             "Confirmacion de baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                try
                {
                    if (dialogo == DialogResult.Yes)
                    {
                        this.bacos.clientes.Remove(bacos.buscarCliente(int.Parse(this.txt_buscarPorDni.Text)));
                    }
                }
                catch (EstaOnoEnlalista ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                catch (Exception)
                {

                    MessageBox.Show("Algo fallo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }




            }


        }
    }
}
