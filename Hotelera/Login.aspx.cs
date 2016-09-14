using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security;
using Modelo;
using System.Security.Cryptography;
using System.Text;

namespace Hotelera
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Iniciar Sesión - Hotel Lounge";
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Server.Transfer("Registro.aspx", true);
        }

        protected void btnInicioSesion_Click(object sender, EventArgs e)
        {
            List<Usuario> usuarios = (List<Usuario>)Session["usuarios"];
            string[] rut = txtrut.Text.Split('-');
            int rrut = int.Parse(rut[0].Replace(".",""));
            char dv = rut[1][0];
            var u = from usu in usuarios
                    where usu.Persona.Rut == rrut && usu.Persona.Dv == dv && usu.Pwd == Usuario.encripta(txtpwd.Text)
                    select usu;
            foreach(var v in u)
            {
                Session["usuario"] = (Usuario)v;
            }
            Response.Redirect("Inicio.aspx");
        }
    }
}