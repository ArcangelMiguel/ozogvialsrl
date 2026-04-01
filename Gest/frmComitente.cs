using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clase;
using Clases;

namespace Gest
{
    public partial class frmComitente : Form
    {
        public frmComitente()
        {
            InitializeComponent();
        }

        private void frmRecibos_Load(object sender, EventArgs e)
        {
            //Size = new Size(877, 316);
            DateTime hoy = DateTime.Now;
            lblFecha.Text = hoy.ToShortDateString();
            apertura();
            cargaDataGridComitentes();

        }

        //============================== ALGORITMOS DE LIMPIEZA Y PRESENTACION =============================

        private void apertura()
        {
            btnAgregar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnBuscar.Enabled = true;
            btnActualizar.Enabled = false;
            btnSalir.Enabled = true;
            pnlEncabezado.Enabled = false;
           
        }
        public void alAgregar()
        {
            btnAgregar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnBuscar.Enabled = false;
            btnActualizar.Enabled = false;
            btnSalir.Enabled = false;
            pnlEncabezado.Enabled = true;
        }
        public void alModificar()
        {
            btnAgregar.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = true;
            btnBuscar.Enabled = false;
            btnActualizar.Enabled = true;
            btnSalir.Enabled = false;
            pnlEncabezado.Enabled = true;
        }

        public void cargaDataGridComitentes()
        {
            DataTable dt = new DataTable();
            dt = Comitente.extraeComitente();
            dgvComitentes.DataSource = dt;
            dgvComitentes.ReadOnly = true;

        }
        

        //============================== Algoritmos Eventuales =============================================

      // // private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
      // // {
      ////      Validar.NumerosDecimales(e);
      ////  }

      // // private void txtMonto_Leave(object sender, EventArgs e)
      // // {
      //  //    try
      //  //    {
      //  //        if (txtMonto.Text == String.Empty || txtMonto.Text == "")
      //  //        {
      //              txtMonto.Text = "0.00";
      //          }
      //          Decimal refer;
      //          refer = Convert.ToDecimal(txtMonto.Text);
      //          txtMonto.Text = refer.ToString("N2");

      //          txtMontoEscrito.Text = Conversion.enletras(txtMonto.Text.ToString());
      //      }
      //      catch (Exception er)
      //      {
      //          MessageBox.Show("++ INGRESE UN VALOR NUMERICO VALIDO.\n ++ DE LO CONTRARIO INGRESE CERO (0). \n ==================== \n " + er.ToString());
      //      }

        //}

        //============================== algoritmos de  botoneras ====================================
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Size = new Size(877, 380);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
