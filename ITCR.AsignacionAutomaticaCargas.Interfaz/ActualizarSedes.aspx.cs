using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ITCR.AsignacionAutomaticaCargas.Negocios;

namespace ITCR.AsignacionAutomaticaCargas.Interfaz
{
    public partial class ActualizarSedes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDatosSede();
            }
        }

        private void cargarDatosSede()
        {
            Int16 IdSede = Int16.Parse(Session["IdSede"].ToString());

            cSedeNegocios Sede = new cSedeNegocios(1, "A", 2, "B");

            Sede.IdSede = IdSede;

            DataTable TablaSedes = Sede.Buscar();

            if (TablaSedes.Rows.Count > 0)
            {
                txtCodigo.Text = TablaSedes.Rows[0]["codigo"].ToString();
                txtNombre.Text = TablaSedes.Rows[0]["sede"].ToString();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            cSedeNegocios Sede = new cSedeNegocios(1, "A", 2, "B");
            Sede.IdSede = Int16.Parse(Session["IdSede"].ToString());
            Sede.Codigo = txtCodigo.Text;
            Sede.Sede = txtNombre.Text;

            Sede.Actualizar();

            Response.Redirect("ConsultarSedes.aspx");
        }
    }
}