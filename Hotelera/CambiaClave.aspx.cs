using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;

namespace Hotelera
{
    public partial class CambiaClave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Cambio de Clave - Hotel Lounge";
        }

        protected void btncambia_Click(object sender, EventArgs e)
        {
            if(txtclave.Text==txtconfclave.Text)
            {
                Usuario u = (Usuario)Session["usuario"];
                u.cambiaClave(txtclave.Text);
                u.Modificar();
                Response.Redirect("Cuenta.aspx?o=ok");
            }
        }
    }
}