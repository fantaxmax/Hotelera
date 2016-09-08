using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
namespace Hotelera
{
    public partial class master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Usuario> usuarios = (List<Usuario>)(Session["usuarios"]);
            Usuario u = (Usuario)Session["usuario"];
            if (usuarios == null)
            {
                usuarios = crearUsuarios();
                Session["usuarios"] = usuarios;
            }
            navmenu.Items.Clear();
            navmenu.Items.Add(new MenuItem("Inicio", "ini"));
            if (u != null)
            {
                navmenu.Items.Add(new MenuItem(String.Format("Mi Cuenta - {0}",u.Persona.Nombre), "acc"));
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
            if(navmenu.SelectedValue == "clo")
            {
                Session.Abandon();
                Response.Redirect("Inicio.aspx");
            }
            if(navmenu.SelectedValue == "acc")
            {
                Response.Redirect("Cuenta.aspx");
            }
        }

        protected List<Usuario> crearUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            Persona p = new Persona(123, 'a', "asdf", "qwerty", new DateTime(2000, 12, 12));
            Usuario u = new Usuario(p, "asdf");
            usuarios.Add(u);
            return usuarios;
        }

    }
}