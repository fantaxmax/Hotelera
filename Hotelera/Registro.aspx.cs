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
            
        }
        ///*la idea es que se despliegue el calendario con el boton*/
        //protected void btnMuestraCalendario_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (calendario1.Visible)
        //    {
        //        calendario1.Visible = false;
        //    }
        //    else
        //    {
        //        calendario1.Visible = true;
        //    }
        //}  Elimino el boton para dejarlo visible siempre, dando la opcion de elejir mes y año en combobox

        //protected void calendario1_SelectionChanged(object sender, EventArgs e)
        //{
        //    txtFec.Text = calendario1.SelectedDate.ToLongDateString();
        //    calendario1.Visible = false;
        //}

        /*no cacho muy bien que deberia ir en este evento*/
        protected void btnRegistra_Click(object sender, EventArgs e)
        {
            Server.Transfer("Login.aspx");
        }

    }
}