using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EDM;

namespace Modelo
{
    public class Conector
    {
        
        public hotelEntities _hotelEntities;
        public hotelEntities HotelEntities
        {
            get
            {
                if (_hotelEntities == null)
                {
                    _hotelEntities = new hotelEntities();
                }
                return _hotelEntities;
            }
        }

        private List<Persona> getPersonas()
        {
            List<EDM.Persona> lista = HotelEntities.Personas.ToList();
            List<Persona> ret = new List<Persona>();
            lista.ForEach((EDM.Persona p) => ret.Add(new Persona(p.rut, p.dv[0], p.nombre, p.apellido, p.fechaNac)));
            return ret;
        }

        public Persona getPersona(int rut)
        {
            return getPersonas().Find(persona => persona.Rut == rut);
        }

        private List<Usuario> getUsuarios()
        {
            List<EDM.Usuario> lista = HotelEntities.Usuarios.ToList();
            List<Usuario> ret = new List<Usuario>();
            lista.ForEach(usuario => ret.Add(new Usuario(getPersona(usuario.rut), usuario.pwd)));
            return ret;
        }

        public Usuario getUsuario(int rut)
        {
            return getUsuarios().Find(usuario => usuario.Persona.Rut == rut);
        }

        public List<Habitacion> getHabitaciones()
        {
            List<EDM.Habitacion> lista = HotelEntities.Habitacions.ToList();
            List<Habitacion> ret = new List<Habitacion>();
            lista.ForEach(habtacion => ret.Add(new Habitacion(habtacion.numero, (TipoHabitacion)habtacion.tipo, habtacion.costoDiario)));
            return ret;
        }

        public Habitacion getHabitacion(int numero)
        {
            return getHabitaciones().Find(hab => hab.Numero == numero);
        }

        public List<Reserva> getReservas()
        {
            List<EDM.Reserva> lista = HotelEntities.Reservas.ToList();
            List<Reserva> ret = new List<Reserva>();
            lista.ForEach(reserva => ret.Add(new Reserva(reserva.id, reserva.fechaIng, reserva.fechaRet, getHabitacion(reserva.habitacion), reserva.rut)));
            return ret;
        }

        public List<Reserva> getReservasUsuario(int rut)
        {
            return getReservas().FindAll(reserva => reserva.Rut == rut);
        }

        public Reserva getReserva(int id)
        {
            return getReservas().Find(reserva => reserva.ID == id);
        }
    }
}
