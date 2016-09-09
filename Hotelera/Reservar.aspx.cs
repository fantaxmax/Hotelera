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
            if (lstHabitaciones.Items.Count == 0)
                inicializarHabitaciones();
            List<Reserva> reservas = (List<Reserva>)(Session["reservas"]);
            cdFechaIngreso.SelectedDate = DateTime.Now;
            cdFechaSalida.SelectedDate = DateTime.Now;
            if (reservas == null)
            {
               List <Reserva> res = new List<Reserva>(); ;
               Session["reservas"] = res;
             }
            txtCosto.Text = "0";
                    
        }
        
        protected void cambioFecIni(Object sender, EventArgs e) 
        {
            if (cdFechaIngreso.SelectedDate < cdFechaSalida.SelectedDate)
            {
                List<Reserva> reservas = (List<Reserva>)(Session["reservas"]);
                List<Habitacion> habitaciones = (List<Habitacion>)(Session["habitaciones"]);
                List<DateTime> seleccionActual = new List<DateTime>();
                List<Habitacion> ocupadas = new List<Habitacion>();
                Habitacion seleccionada = null;
                for (DateTime ing = cdFechaIngreso.SelectedDate; ing < cdFechaSalida.SelectedDate; ing.AddDays(1.0))
                {
                    seleccionActual.Add(ing);
                }
                foreach (Reserva r in reservas)
                {
                    List<DateTime> estadia = new List<DateTime>();
                    for (DateTime f = r.FechaIngreso; f < r.FechaRetiro; f.AddDays(1.0))
                    {
                        estadia.Add(f);
                    }

                    for (int i = 0; i < estadia.Count; i++)
                    {
                        foreach (DateTime fecha in seleccionActual)
                        {
                            if (estadia.ElementAt(i) == fecha)
                            {
                                ocupadas.Add(r.Habitacion);
                                txtError.Text = "Fecha no disponible";
                                txtError.Visible = true;
                                break;
                            }
                            else
                            {
                                foreach (Habitacion h in habitaciones)
                                {
                                    if (lstHabitaciones.SelectedValue.Equals(h.Numero.ToString()))
                                    {
                                        seleccionada = h;
                                        txtCosto.Text = (new Reserva(cdFechaIngreso.SelectedDate, cdFechaSalida.SelectedDate, seleccionada)).CostoReserva.ToString();
                                    }
                                }
                            }
                        }
                    }
                }
                Session["Ocupadas"] = ocupadas;
            }
        } 


        protected void cambioFecSal(Object sender, EventArgs e)
        {
            if (cdFechaIngreso.SelectedDate < cdFechaSalida.SelectedDate)
            {
                List<Reserva> reservas = (List<Reserva>)(Session["reservas"]);
                List<Habitacion> habitaciones = (List<Habitacion>)(Session["habitaciones"]);
                List<DateTime> seleccionActual = new List<DateTime>();
                List<Habitacion> ocupadas = new List<Habitacion>();
                Habitacion seleccionada = null;
                for (DateTime ing = cdFechaIngreso.SelectedDate; ing < cdFechaSalida.SelectedDate; ing.AddDays(1.0))
                {
                    seleccionActual.Add(ing);
                }
                foreach (Reserva r in reservas)
                {
                    List<DateTime> estadia = new List<DateTime>();
                    for (DateTime f = r.FechaIngreso; f < r.FechaRetiro; f.AddDays(1.0))
                    {
                        estadia.Add(f);
                    }

                    for (int i = 0; i < estadia.Count; i++)
                    {
                        foreach (DateTime fecha in seleccionActual)
                        {
                            if (estadia.ElementAt(i) == fecha)
                            {
                                ocupadas.Add(r.Habitacion);
                                txtError.Text = "Fecha no disponible";
                                txtError.Visible = true;
                                break;
                            }
                            else
                            {
                                foreach (Habitacion h in habitaciones)
                                {
                                    if (lstHabitaciones.SelectedValue.Equals(h.Numero.ToString()))
                                    {
                                        seleccionada = h;
                                        txtCosto.Text = (new Reserva(cdFechaIngreso.SelectedDate, cdFechaSalida.SelectedDate, seleccionada)).CostoReserva.ToString();
                                    }
                                }
                            }
                        }
                    }
                }
                Session["Ocupadas"] = ocupadas;
            }
        }
        
        protected void ingresarReserva()
        {
            List<Reserva> reservas = (List<Reserva>)(Session["reservas"]);
            List<Habitacion> habitaciones = (List<Habitacion>)(Session["habitaciones"]);
            Habitacion seleccionada = null;
            foreach (Habitacion h in habitaciones)
	        {
		        if (lstHabitaciones.SelectedValue.Equals(h.Numero.ToString()))
	            {
		            seleccionada = h;
	            }
	        }
            Reserva r = new Reserva(cdFechaIngreso.SelectedDate, cdFechaSalida.SelectedDate, seleccionada);  
            reservas.Add(r);            
        }

        protected void inicializarHabitaciones() /*habitaciones para usar como ejemplo C.Y*/
        {
            Habitacion Hab101 = new Habitacion(101, TipoHabitacion.Single, 20000);
            Habitacion Hab201 = new Habitacion(201, TipoHabitacion.Doble, 40000);
            Habitacion Hab301 = new Habitacion(301, TipoHabitacion.Suite, 60000);         
            List<Habitacion> habitaciones = (List<Habitacion>)(Session["habitaciones"]);
            if( habitaciones == null)  
            {
                habitaciones = new List<Habitacion>()
                {
                  Hab101,
                  Hab201,
                  Hab301
                };
            }
            List<Habitacion> ocupadas = (List<Habitacion>)(Session["ocupadas"]);
            if (ocupadas != null)
            {
                foreach (Habitacion h in habitaciones)
                {
                    foreach (Habitacion o in ocupadas)
                    {
                        if (h == o)
                        {
                            habitaciones.Remove(h);
                        }
                    }
                }
            }
            Session["habitaciones"] = habitaciones;  
            foreach (Habitacion h in habitaciones)
            {
                lstHabitaciones.ClearSelection();
                lstHabitaciones.Items.Add(new ListItem(h.Numero.ToString()));
            }
           
        }


        
        protected void clickReservar(Object sender, EventArgs e)
        {
            ingresarReserva();
            Response.Redirect("Inicio.aspx");
        }
    }
}