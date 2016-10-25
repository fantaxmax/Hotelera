using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDM;
namespace Modelo
{
    public class Persona
    {
        private int _rut;
        private char _dv;
        private string _nombres;
        private string _apellidos;
        private DateTime _fechaNac;
        /*  prodriamos agregar la fecha desde que es cliente, para hacer algun descuento por antiguedad
         *  private DateTime _fechaReg;
         *  public DateTime FechaReg{
         *      get { return _fechReg; }
         *  }
         * 
         *
         */
        public Persona(int _rut, char _dv, string _nombres, string _apellidos, DateTime _fechaNac)
        {
            Rut = _rut;
            Dv = _dv;
            Nombre = _nombres;
            Apellidos = _apellidos;
            FechaNac = _fechaNac;
        }

        public int Rut
        {
            //creo que el set deberia ser solo a nivel de clase
            get
            {
                return _rut;
            }
            protected set
            {
                _rut = value;
            }
        }

        public char Dv
        {
            get { return _dv; }
            protected set { _dv = value; }
        }

        public string Nombre
        {
            get { return _nombres; }
            set { _nombres = value; }
        }

        public string Apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; }
        }

        public DateTime FechaNac
        {
            get { return _fechaNac; }
            set { _fechaNac = value; }
        }

        public bool Insertar()
        {
            try
            {
                EDM.Persona persona = new EDM.Persona();
                persona.rut = this.Rut;
                persona.dv = this.Dv.ToString();
                persona.nombre = this.Nombre;
                persona.apellido = this.Apellidos;
                persona.fechaNac = this.FechaNac;
                Conector.HotelEntities.Personas.Add(persona);
                Conector.HotelEntities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Eliminar()
        {
            try
            {
                    EDM.Persona p = Conector.HotelEntities.Personas.ToList().Find(per => per.rut == Rut);
                Conector.HotelEntities.Personas.Remove(p);
                Conector.HotelEntities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool Modificar()
        {
            try
            {
                EDM.Persona p = Conector.HotelEntities.Personas.ToList().Find(per => per.rut == Rut);
                p.dv = Dv.ToString();
                p.nombre = Nombre;
                p.apellido = Apellidos;
                p.fechaNac = FechaNac;
                Conector.HotelEntities.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
