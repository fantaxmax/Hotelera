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
            navmenu.Items.Add(new MenuItem("Inicio", "ini"));
            if(((String)(Session["usuario"]))!=null)
            {
                navmenu.Items.Add(new MenuItem("Reservas", "res"));
            } else
            {

            }
        }

        private void Navmenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            
        }
    }
}