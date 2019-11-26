using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

using System.Data;

namespace Web.Interfaces
{
    public partial class frmPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = "";
                if (string.IsNullOrEmpty(txtIdentificacion.Text)) throw new Exception("Ingrese identificacion");

                Logica.Clases.clsClientes obclsClientes = new Logica.Clases.clsClientes();
                DataSet dsConsulta = obclsClientes.stConsultarClientes(Convert.ToInt64(txtIdentificacion.Text));

                if (dsConsulta.Tables[0].Rows.Count == 0) gvwDatos.DataSource = null;
                else gvwDatos.DataSource = dsConsulta;

                gvwDatos.DataBind();
            }
            catch (Exception ex) { lblMensaje.Text = ex.Message; }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = "";
                Logica.Clases.clsClientes obclsClientes = new Logica.Clases.clsClientes();

                lblMensaje.Text = obclsClientes.stInsertarClientes(Convert.ToInt64(txtIdentificacion.Text),
                    txtNombres.Text,
                    txtApellidos.Text);
            }
            catch (Exception ex) { lblMensaje.Text = ex.Message; }
        }


        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = "";
                Logica.Clases.clsClientes obclsClientes = new Logica.Clases.clsClientes();

                lblMensaje.Text = obclsClientes.stInsertarClientes(Convert.ToInt64(txtIdentificacion.Text),
                    txtNombres.Text,
                    txtApellidos.Text);
            }
            catch (Exception ex) { lblMensaje.Text = ex.Message; }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = "";
                Logica.Clases.clsClientes obclsClientes = new Logica.Clases.clsClientes();

                lblMensaje.Text = obclsClientes.stModificarClientes(Convert.ToInt64(txtIdentificacion.Text),
                    txtNombres.Text,
                    txtApellidos.Text);
            }
            catch (Exception ex) { lblMensaje.Text = ex.Message; }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = "";
                Logica.Clases.clsClientes obclsClientes = new Logica.Clases.clsClientes();

                lblMensaje.Text = obclsClientes.stEliminarClientes(Convert.ToInt64(txtIdentificacion.Text));
            }
            catch (Exception ex) { lblMensaje.Text = ex.Message; }
        }


    }
}