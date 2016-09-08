using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Persona(int _rut,char _dv,string _nombres, string _apellidos,DateTime _fechaNac)
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
    }
}
