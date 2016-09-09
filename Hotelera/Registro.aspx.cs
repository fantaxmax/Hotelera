using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            if(Request.QueryString.Get("hpwd") != null)
            {

            }
        }



        /*no cacho muy bien que deberia ir en este evento*/
        protected void btnRegistra_Click(object sender, EventArgs e)
        {
            Server.Transfer("Login.aspx");
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