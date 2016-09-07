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
            navmenu.MenuItemClick += Navmenu_MenuItemClick;
            navmenu.Items.Add(new MenuItem("menu prueba","p"));
            navmenu.Items.Add(new MenuItem("menu prueba 2", "p2"));
        }

        private void Navmenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            
        }
    }
}