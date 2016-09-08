using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotelera
{
    public partial class master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            navmenu.Items.Clear();
            navmenu.Items.Add(new MenuItem("Inicio", "ini"));
            if (((String)(Session["usuario"])) != null)
            {
                navmenu.Items.Add(new MenuItem("Mi Cuenta", "acc"));
                navmenu.Items.Add(new MenuItem("Reservas", "res"));
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
            if(navmenu.SelectedValue == "ses")
            {
                Server.Transfer("Login.aspx");
            }
        }

    }
}