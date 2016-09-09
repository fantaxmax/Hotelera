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
            inicializarCampos();
        }

        private void inicializarCampos()
        {
            List<Reserva> reservas = (List<Reserva>)(Session["reservas"]);
            cdFechaIngreso.SelectedDate = DateTime.Now.AddDays(1);
            cdFechaSalida.SelectedDate = DateTime.Now.AddDays(6);
            cdFechaIngreso.VisibleDate = cdFechaIngreso.SelectedDate;
            cdFechaSalida.VisibleDate = cdFechaSalida.SelectedDate;
            //movida inicializacion de reservas a masterpage
            txtCosto.Text = "0";

        }

        protected void cambioFecIni(Object sender, EventArgs e)
        {
            TimeSpan ts = cdFechaSalida.SelectedDate - cdFechaIngreso.SelectedDate;
            if (ts.Days < 0)
            {
                //agregar rutina de aviso de error por ahora cambia la fecha de salida a un dia mas -Ismael
                cdFechaSalida.SelectedDate.AddDays(1);
                cdFechaSalida.VisibleDate = cdFechaSalida.SelectedDate;
            }
            else
            {
                //agregamos automaticamente 5 dias a la fecha de salida
                cdFechaSalida.SelectedDate.AddDays(5);
                cdFechaSalida.VisibleDate = cdFechaSalida.SelectedDate;
            }
        }


        protected void cambioFecSal(Object sender, EventArgs e)
        {
            TimeSpan ts = cdFechaSalida.SelectedDate - cdFechaIngreso.SelectedDate;
            if (ts.Days < 0) //si el dia de salida es antes que el dia se entrada
            {
                //agregar rutina que notifique error -Ismael
                cdFechaIngreso.SelectedDate.AddDays(-1);
                cdFechaIngreso.VisibleDate = cdFechaIngreso.SelectedDate;
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
                        if ((r.Habitacion == h && (r.FechaIngreso == cdFechaIngreso.SelectedDate || r.FechaRetiro == cdFechaSalida.SelectedDate)))//revisamos si la habitacion tiene reserva ese dia
                        {
                            disp = false;//si tiene la dejamos como no disponible
                        }
                    }
                    if (disp)
                    {
                        lstHabitaciones.Items.Add(new ListItem(h.ToString(), h.Numero.ToString()));
                    }
                }
                if (lstHabitaciones.Items.Count == 1)
                {
                    lstHabitaciones.SelectedValue = lstHabitaciones.Items[0].Value;
                }
            }
        }

        protected void ingresarReserva()
        {
            List<Reserva> reservas = (List<Reserva>)(Session["reservas"]);
            Reserva r = (Reserva)Session["reserva"];
            reservas.Add(r);
        }

        //movida inicializacion de habitaciones a masterpage -Ismael



        protected void clickReservar(Object sender, EventArgs e)
        {
            Usuario u = (Usuario)Session["usuario"];
            if(u==null)
            {
                Response.Redirect("Registro.aspx?o=reg");
            }
            else
            {
                ingresarReserva();
                Response.Redirect("Inicio.aspx");
            }
        }

        protected void lstHabitaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            //aqui obtenemos la habitacion seleccionada
            string habs = lstHabitaciones.SelectedValue;
            if(habs!="")//nos aseguramos que lsthabitaciones tenga algun dato seleccionado
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