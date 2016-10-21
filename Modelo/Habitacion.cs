using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Habitacion
    {
        private int _numero;
        private TipoHabitacion _tipo;
        private double _costoDiario;

        public int Numero
        {
            get { return _numero; }
        }

        public TipoHabitacion Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public double CostoDiario
        {
            get { return _costoDiario; }
            set { _costoDiario = value; }
        }

        public Habitacion()
        {

        }

        public Habitacion(int numero,TipoHabitacion tipo,double costoDiario)
        {
            _numero = numero;
            _tipo = tipo;
            _costoDiario = costoDiario;
        }

        public override string ToString()
        {
            return Numero + " : " + (Tipo == TipoHabitacion.Single ? "Single" : (Tipo == TipoHabitacion.Doble ? "Doble" : "Suite"));
        }
    }
    public enum TipoHabitacion
    {
        Single=1,Doble=2,Suite=3
    }
}
