using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using Modelo;

namespace Hotelera
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (dpmes.Items.Count == 0)
            {
                ListItem[] ls = { new ListItem("Enero","1"),
                              new ListItem("Febrero","2"),
                              new ListItem("Marzo","3"),
                              new ListItem("Abril","4"),
                              new ListItem("Mayo","5"),
                              new ListItem("Junio","6"),
                              new ListItem("Julio","7"),
                              new ListItem("Agosto","8"),
                              new ListItem("Septiembre","9"),
                              new ListItem("Octubre","10"),
                              new ListItem("Noviembre","11"),
                              new ListItem("Diciembre","12") };
                dpmes.Items.AddRange(ls);
                int hasta = DateTime.Today.Year - 85;
                for (int i = hasta; i <= DateTime.Today.Year; i++)
                    dpano.Items.Add(i.ToString());
            }
            if(Request.Form.Get("txtpwd")!=null)
            {
                txtContra.Text = Request.Form.Get("txtpwd");
                txtRut.Text = Request.Form.Get("txtrut");
                Request.Form.Remove("txtpwd");
            }
        }



        /*no cacho muy bien que deberia ir en este evento*/
        protected void btnRegistra_Click(object sender, EventArgs e)
        {
            if(txtRut.Text!=""&& txtNom.Text != "" && txtApe.Text != "" && txtContra.Text != "" && txtContraConf.Text != "")
            {
                if(txtContra.Text==txtContraConf.Text)
                {
                    string[] rut = txtRut.Text.Split('-');
                    Persona p = new Persona(int.Parse(rut[0]), rut[1][0], txtNom.Text, txtApe.Text, calNac.SelectedDate);
                    Usuario u = new Usuario(p, encryption(txtContra.Text));
                    List<Usuario> usuarios = (List<Usuario>)Session["usuarios"];
                    usuarios.Add(u);
                }
            }
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

        protected void dpmes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ano = int.Parse(dpano.SelectedValue);
            int mes = int.Parse(dpmes.SelectedValue);
            int dia = calNac.SelectedDate.Day;
            DateTime fecha = new DateTime(ano, mes, dia);
            calNac.SelectedDate = fecha;
            calNac.VisibleDate = fecha;
        }

        protected void dpano_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ano = int.Parse(dpano.SelectedValue);
            int mes = int.Parse(dpmes.SelectedValue);
            int dia = calNac.SelectedDate.Day;
            DateTime fecha = new DateTime(ano, mes, dia);
            calNac.SelectedDate = fecha;
            calNac.VisibleDate = fecha;
        }
    }
}