using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;

namespace Hotelera
{
    public partial class Reservar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Get("e") != null)
            {
                Session["e"] = Request.QueryString.Get("e");
                Response.Redirect("Reservar.aspx");
            }
            string er = (string)Session["e"];
            if (er != null)
            {
                erro.Text = "La Fecha de Entrada no puede ser antes de Hoy";
                erro.Visible = true;
                erro.ForeColor = System.Drawing.Color.Red;
            }
            if (!IsPostBack)
            {
                cdFechaIngreso.SelectedDate = DateTime.Now;
                cdFechaSalida.SelectedDate = DateTime.Now.AddDays(1);
            }
        }

        protected void cambioFecIni(Object sender, EventArgs e)
        {
            TimeSpan tshoy = cdFechaIngreso.SelectedDate - DateTime.Now;
            if (tshoy.Days < 0)//si el dia de entrada es menor al dia actual
                Response.Redirect("Reservar.aspx?e=e");
            TimeSpan ts = cdFechaSalida.SelectedDate - cdFechaIngreso.SelectedDate;
            if (ts.Days < 0) //si el dia de salida es antes que el dia se entrada
            {
                cdFechaSalida.SelectedDate = cdFechaIngreso.SelectedDate.AddDays(4);
                cdFechaSalida.VisibleDate = cdFechaSalida.SelectedDate;
            }
            if ((string)Session["e"] != null)
            {
                erro.Visible = false;
                Session["e"] = null;
            }
            cambioFecSal(sender, e);
        }


        protected void cambioFecSal(Object sender, EventArgs e)
        {
            TimeSpan ts = cdFechaSalida.SelectedDate - cdFechaIngreso.SelectedDate;
            if (ts.Days < 0) //si el dia de salida es antes que el dia se entrada
            {
                cdFechaSalida.SelectedDate = cdFechaIngreso.SelectedDate.AddDays(4);
                cdFechaSalida.VisibleDate = cdFechaSalida.SelectedDate;
                cambioFecSal(sender, e);
            }
            else //si esta todo correcto con las fechas, cargamos las habitaciones
            {
                lstHabitaciones.Items.Clear();
                List<Reserva> reservas = (List<Reserva>)Session["reservas"];
                List<Habitacion> habitaciones = (List<Habitacion>)Session["habitaciones"];
                foreach (Habitacion h in habitaciones)
                {
                    bool disp = true;
                    foreach (Reserva r in reservas)
                    {
                        if ((r.Habitacion == h && !((cdFechaIngreso.SelectedDate < r.FechaIngreso && cdFechaSalida.SelectedDate < r.FechaIngreso) ||
                            (cdFechaIngreso.SelectedDate > r.FechaRetiro & cdFechaSalida.SelectedDate > r.FechaRetiro)))) //comprobamos que ambas fechas se encuentren antes o despues de las fechas de la reservacion
                        {
                            disp = false;//si tiene la dejamos como no disponible
                        }

                    }
                    if (disp)
                    {
                        lstHabitaciones.Items.Add(new ListItem(h.ToString(), h.Numero.ToString()));
                    }
                }
                if (lstHabitaciones.Items.Count >= 1)
                {
                    lstHabitaciones.SelectedIndex = 0;
                    lstHabitaciones_SelectedIndexChanged(lstHabitaciones, e);
                }
            }
        }

        protected void ingresarReserva()
        {
            List<Reserva> reservas = (List<Reserva>)(Session["reservas"]);
            Usuario u = (Usuario)Session["usuario"];
            Reserva r = (Reserva)Session["reserva"];
            reservas.Add(r);
            u.reservas.Add(r);
        }

        protected void clickReservar(Object sender, EventArgs e)
        {
            Usuario u = (Usuario)Session["usuario"];
            if (u == null)
            {
                Response.Redirect("Registro.aspx?o=reg");
            }
            else
            {
                ingresarReserva();
                Response.Redirect("Reservas.aspx");
            }
        }

        protected void lstHabitaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            //aqui obtenemos la habitacion seleccionada
            string habs = lstHabitaciones.SelectedValue;
            if (habs != "")//nos aseguramos que lsthabitaciones tenga algun dato seleccionado
            {
                List<Habitacion> habitaciones = (List<Habitacion>)(Session["habitaciones"]);
                foreach (Habitacion h in habitaciones)
                {
                    if (h.Numero.ToString() == habs)
                    {
                        Reserva r = new Reserva(cdFechaIngreso.SelectedDate, cdFechaSalida.SelectedDate, h);
                        Session["reserva"] = r;
                        txtCosto.Text = r.CostoReserva.ToString();
                        break;
                    }
                }
            }
        }
    }
}