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
            Usuario u = Conector.getUsuario(getRut(txtrut.Text));
            if (Usuario.encripta(txtpwd.Text) == u.Pwd)
            {
                Session["usuario"] = u;
                Response.Redirect("Inicio.aspx");
            }
            else
            {
                erro.Text = "Usuario o Clave incorrecto/a";
            }
        }

        protected int getRut(String rut)
        {
            if(Registro.validaRut(rut))
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));
                return rutAux;
            }
            return 0;
        }

        protected void txtrut_TextChanged(object sender, EventArgs e)
        {
            erro.Text = "";
        }
    }
}