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
            List<Usuario> usuarios = (List<Usuario>)(Session["usuarios"]);
            Usuario u = (Usuario)Session["usuario"];
            if (usuarios == null)
            {
                usuarios = crearUsuarios();
                Session["usuarios"] = usuarios;
            }
            navmenu.Items.Clear();
            navmenu.Items.Add(new MenuItem("Inicio", "ini"));
            navmenu.Items.Add(new MenuItem("Reservar Habitacion", "res"));
            if (u != null)
            {
                navmenu.Items.Add(new MenuItem(String.Format("Mi Cuenta - {0}",u.Persona.Nombre), "acc"));
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
            if(navmenu.SelectedValue == "ses")
            {
                Server.Transfer("Login.aspx");
            }
            if(navmenu.SelectedValue == "clo")
            {
                Session["usuario"] = null;
                Response.Redirect("Inicio.aspx");
            }
            if(navmenu.SelectedValue == "acc")
            {
                Response.Redirect("Cuenta.aspx");
            }
            if(navmenu.SelectedValue == "reg")
            {
                Response.Redirect("Registro.aspx");
            }
            if(navmenu.SelectedValue == "re")
            {
                Response.Redirect("Reservas.aspx");
            }
        }

        protected List<Usuario> crearUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            Persona p = new Persona(123, 'a', "asdf", "qwerty", new DateTime(2000, 12, 12));
            Usuario u = new Usuario(p, encryption("asdf"));
            Reserva r = new Reserva(new DateTime(2015, 12, 21), new DateTime(2015, 12, 25), new Habitacion(999, TipoHabitacion.Single, 5630.4));
            u.reservas.Add(r);
            usuarios.Add(u);
            return usuarios;
        }

        public string encryption(String password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            //encrypt the given password string into Encrypted data  
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            //Create a new string by using the encrypted data  
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }
    }
}