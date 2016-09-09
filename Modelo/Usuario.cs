using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Usuario
    {
        private Persona _persona;
        private string _pwd;//deberiamos guardarla hasheada
        public List<Reserva> reservas;

        public Usuario(Persona _persona,string _pwd)
        {
            Persona = _persona;
            Pwd = _pwd;
            reservas = new List<Reserva>();
        }

        public Persona Persona
        {
            get { return _persona; }
            //misma intencion que con rut, deberia ser cambiada solo dentro de la clase
            protected set { _persona = value; }
        }

        public string Pwd
        {
            get { return _pwd; }
            //igual que arriba debiese ser cambiada solo dentro de la misma clase
            protected set { _pwd = value; }
        }
    }
}
