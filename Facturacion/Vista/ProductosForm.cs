﻿using Entidades;
using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class ProductosForm : Syncfusion.Windows.Forms.Office2010Form
    {
        public ProductosForm()
        {
            InitializeComponent();
        }
        string operacion;
        Producto producto;



        private void Nuevobutton_Click(object sender, System.EventArgs e)
        {

            operacion = "Nuevo";
            HabilitarControles();
        }
        private void HabilitarControles()
        {
            CodigotextBox.Enabled = true;
            DescripciontextBox.Enabled = true;
            ExistenciatextBox.Enabled = true;
            PreciotextBox.Enabled = true;
            AdjuntarImagenbutton.Enabled = true;
            Guardarbutton.Enabled = true;
            Cancelarbutton.Enabled = true;
            Nuevobutton.Enabled = false;
        }
        private void LimpiarControles()
        {
            CodigotextBox.Clear();
            DescripciontextBox.Clear();
            ExistenciatextBox.Clear();
            PreciotextBox.Clear();
            ImagenpictureBox.Image = null;
            producto = null;
        }
        private void DeshabilitarControles()
        {
            CodigotextBox.Enabled = false;
            DescripciontextBox.Enabled = false;
            ExistenciatextBox.Enabled = false;
            PreciotextBox.Enabled = false;
            AdjuntarImagenbutton.Enabled = false;
            Guardarbutton.Enabled = false;
            Cancelarbutton.Enabled = false;
            Nuevobutton.Enabled = true;
        }
        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            DeshabilitarControles();
        }

        private void Modificarbutton_Click(object sender, System.EventArgs e)
        {
            operacion = "Modificar";
            if (ProductosdataGridView.SelectedRows.Count > 0)
            {
                CodigotextBox.Text = ProductosdataGridView.CurrentRow.Cells["Codigo"].Value.ToString();
                DescripciontextBox.Text = ProductosdataGridView.CurrentRow.Cells["Descripcion"].Value.ToString();
                ExistenciatextBox.Text = ProductosdataGridView.CurrentRow.Cells["Existencia"].Value.ToString();
                PreciotextBox.Text = ProductosdataGridView.CurrentRow.Cells["Precio"].Value.ToString();


                // byte[] img = productoDB.DevolverFoto(ProductosdataGridView.CurrentRow.Cells["Codigo"].Value.ToString());
            }
        }



        private void Guardarbutton_Click(object sender, EventArgs e)
        {

            //producto = new Producto();
            //producto.Codigo = CodigotextBox.Text;
            //producto.Descripcion = DescripciontextBox.Text;
            // producto.Precio = Convert.ToDecimal(PreciotextBox.Text);
            // producto.Existencia = Convert.ToInt32(ExistenciatextBox.Text);
            //producto.EstaActivo = EstaActivoCheckBox.Checked;
            if (operacion == "Nuevo")
            {
                if (string.IsNullOrEmpty(CodigotextBox.Text))
                {
                    errorProvider1.SetError(CodigotextBox, "Ingrese un código");
                    CodigotextBox.Focus();
                    return;
                }
                errorProvider1.Clear();

                if (string.IsNullOrEmpty(DescripciontextBox.Text))
                {
                    errorProvider1.SetError(DescripciontextBox, "Ingrese una descripción");
                    DescripciontextBox.Focus();
                    return;
                }
                errorProvider1.Clear();

                if (string.IsNullOrEmpty(ExistenciatextBox.Text))
                {
                    errorProvider1.SetError(ExistenciatextBox, "Ingrese una existencia");
                    ExistenciatextBox.Focus();
                    return;
                }
                errorProvider1.Clear();

                if (string.IsNullOrEmpty(PreciotextBox.Text))
                {
                    errorProvider1.SetError(PreciotextBox, "Ingrese un precio");
                    PreciotextBox.Focus();
                    return;
                }
                errorProvider1.Clear();



            }
        }
        private void ExistenciaTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void PreciotextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

        }
    }
}
