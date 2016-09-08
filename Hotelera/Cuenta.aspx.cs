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
            Usuario u = (Usuario)Session["usuario"];
            txtnombres.Text = u.Persona.Nombre;
            txtapellidos.Text = u.Persona.Apellidos;
            txtrut.Text = u.Persona.Rut.ToString() + u.Persona.Dv;
            calNac.SelectedDate = u.Persona.FechaNac;
            calNac.VisibleDate = u.Persona.FechaNac;
        }
    }
}