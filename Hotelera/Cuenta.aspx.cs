using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
namespace Hotelera
{
    public partial class Cuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Mi Cuenta - Hotel Lounge";
            if(Request.QueryString.Get("o")=="ok")
            {
                mensaje.Text = "Datos Actualizados!";
                mensaje.Visible = true;
            }
            Usuario u = (Usuario)Session["usuario"];
            txtnombres.Text = u.Persona.Nombre;
            txtapellidos.Text = u.Persona.Apellidos;
            txtrut.Text = u.Persona.Rut.ToString() + "-" + u.Persona.Dv;
            calNac.SelectedDate = u.Persona.FechaNac;
            calNac.VisibleDate = u.Persona.FechaNac;
        }

        protected void btnActualiza_Click(object sender, EventArgs e)
        {
            string nombre = txtnombres.Text;
            string apellidos = txtapellidos.Text;
            DateTime fechanac = calNac.SelectedDate;
            Usuario u = (Usuario)Session["usuario"];
            u.Persona.Nombre = nombre;
            u.Persona.Apellidos = apellidos;
            u.Persona.FechaNac = fechanac;
            Response.Redirect("Cuenta.aspx?o=ok");
        }

        protected void btnclave_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambiaClave.aspx");
        }
    }
}