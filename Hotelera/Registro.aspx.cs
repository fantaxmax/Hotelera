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
            if (Request.Form.Get("txtpwd") != null)
            {
                txtContra.Text = Request.Form.Get("txtpwd");
                txtRut.Text = Request.Form.Get("txtrut");
                Request.Form.Remove("txtpwd");
            }
            string reg = Request.QueryString.Get("o");
            if(reg!=null)
            {
                if(reg=="reg")
                {
                    titulo.Text = "Registrate para Reservar";
                }
            }
        }



        /*no cacho muy bien que deberia ir en este evento*/
        protected void btnRegistra_Click(object sender, EventArgs e)
        {
            if (validaRut(txtRut.Text))
            {
                if (txtRut.Text != "" && txtNom.Text != "" && txtApe.Text != "" && txtContra.Text != "" && txtContraConf.Text != "")
                {
                    if (txtContra.Text == txtContraConf.Text)
                    {
                        string[] rut = txtRut.Text.Split('-');
                        Persona p = new Persona(int.Parse(rut[0].Replace(".","")), rut[1][0], txtNom.Text, txtApe.Text, calNac.SelectedDate);
                        Usuario u = new Usuario(p, encryption(txtContra.Text));
                        List<Usuario> usuarios = (List<Usuario>)Session["usuarios"];
                        if(Request.QueryString.Get("o")=="reg")
                        {
                            Reserva r = (Reserva)Session["reserva"];
                            List<Reserva> res = (List<Reserva>)Session["reservas"];
                            u.reservas.Add(r);
                            res.Add(r);
                        }
                        usuarios.Add(u);
                        Session["usuario"] = u;
                        Response.Redirect("Reservas.aspx?o=ok");
                    }
                    else
                    {
                        erro.Text = "Contraseñas no coinciden, reintente...";
                        erro.Visible = true;
                    }
                }
                else
                {
                    erro.Text = "No has ingresado todos los campos";
                    erro.Visible = true;
                }
            }
            else
            {
                erro.Visible = true;
                erro.Text = "Rut no valido, reingrese";
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

        protected bool validaRut(string rut) //codigo prestado desde http://www.qualityinfosolutions.com/validador-de-rut-chileno-en-c/
        {
            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                if (!rut.Contains('-'))
                    return false;
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }

        protected void txtNom_TextChanged(object sender, EventArgs e)
        {
            erro.Visible = false;
            erro.Text = "";
        }

        protected void txtContra_TextChanged(object sender, EventArgs e)
        {
            erro.Text = "";
            erro.Visible = false;
        }
    }
}