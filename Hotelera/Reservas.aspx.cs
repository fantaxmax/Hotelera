using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
namespace Hotelera
{
    public partial class Reservas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Ver sus Reservar - Hotel Lounge";
            List<Reserva> act = new List<Reserva>();
            List<Reserva> ina = new List<Reserva>();
            Usuario u = (Usuario)Session["usuario"];
            foreach (Reserva r in Conector.getReservasUsuario(u.Persona.Rut))
            {
                if (r.FechaRetiro < DateTime.Now)
                    ina.Add(r);
                else act.Add(r);
            }
            creaTabla(act, tablaAct);
            creaTabla(ina, tablaAnt);
            tablaAct.BorderStyle = BorderStyle.Solid;
            tablaAnt.BorderStyle = BorderStyle.Solid;
        }

        protected void creaTabla(List<Reserva> reservas, Table t)
        {
            foreach (Reserva r in reservas)
            {
                t.Rows.Add(creaTR(r));
            }
        }

        protected TableRow creaTR(Reserva reserva)
        {
            TableRow tr = new TableRow();
            tr.Cells.Add(creaTC(reserva.FechaIngreso.ToShortDateString()));
            tr.Cells.Add(creaTC(reserva.FechaRetiro.ToShortDateString()));
            tr.Cells.Add(creaTC(reserva.Habitacion.ToString()));
            tr.Cells.Add(creaTC(reserva.CostoReserva.ToString()));
            return tr;
        }

        protected TableCell creaTC(string dato)
        {
            TableCell tc = new TableCell();
            Label l = new Label();
            l.Text = dato;
            tc.Controls.Add(l);
            return tc;
        }
    }
}