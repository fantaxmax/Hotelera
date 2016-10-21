using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
using System.Security.Cryptography;
using System.Text;
namespace Hotelera
{
    public partial class master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Conector con = (Conector)Session["conector"];
            if (Session.Timeout != 25)
                Session.Timeout = 25;
            if(con==null)
            {
                con = new Conector();
            }
            Usuario u = (Usuario)Session["usuario"];
            List<Habitacion> habitaciones = (List<Habitacion>)Session["habitaciones"];
            List<Reserva> reservas = (List<Reserva>)(Session["reservas"]);
            if (habitaciones == null)
            {
                habitaciones = con.getHabitaciones();
            }
            if (reservas == null)
            {
                List<Reserva> res = con.getReservas();
            }
            navmenu.Items.Clear();
            navmenu.Items.Add(new MenuItem("Inicio", "ini"));
            navmenu.Items.Add(new MenuItem("Reservar Habitacion", "res"));
            if (u != null)
            {
                navmenu.Items.Add(new MenuItem(String.Format("Mi Cuenta - {0}", u.Persona.Nombre), "acc"));
                navmenu.Items.Add(new MenuItem("Reservas", "re"));
                navmenu.Items.Add(new MenuItem("Cerrar Sesión", "clo"));

            }
            else
            {
                navmenu.Items.Add(new MenuItem("Registro", "reg"));
                navmenu.Items.Add(new MenuItem("Iniciar Sesión", "ses"));
            }
        }

        protected void navmenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (navmenu.SelectedValue == "ini")
            {
                Response.Redirect("Inicio.aspx");
            }
            if (navmenu.SelectedValue == "res")
            {
                Response.Redirect("Reservar.aspx");
            }
            if (navmenu.SelectedValue == "ses")
            {
                Server.Transfer("Login.aspx");
            }
            if (navmenu.SelectedValue == "clo")
            {
                Session["usuario"] = null;
                Response.Redirect("Inicio.aspx");
            }
            if (navmenu.SelectedValue == "acc")
            {
                Response.Redirect("Cuenta.aspx");
            }
            if (navmenu.SelectedValue == "reg")
            {
                Response.Redirect("Registro.aspx");
            }
            if (navmenu.SelectedValue == "re")
            {
                Response.Redirect("Reservas.aspx");
            }
        }
    }
}