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

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Server.Transfer("Registro.aspx", true);
        }

        protected void btnInicioSesion_Click(object sender, EventArgs e)
        {
            List<Usuario> usuarios = (List<Usuario>)Session["usuarios"];
            string[] rut = txtrut.Text.Split('-');
            int rrut = int.Parse(rut[0]);
            char dv = rut[1][0];
            var u = from usu in usuarios
                    where usu.Persona.Rut == rrut && usu.Persona.Dv == dv && usu.Pwd == encryption(txtpwd.Text)
                    select usu;
            foreach(var v in u)
            {
                Session["usuario"] = (Usuario)v;
            }
            Response.Redirect("Inicio.aspx");
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