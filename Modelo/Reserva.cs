using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Reserva
    {
        private DateTime _fechaIngreso;
        private DateTime _fechaRetiro;
        private Habitacion _habitacion;
        private double _costoReserva;

        public DateTime FechaIngreso
        {
            get { return _fechaIngreso; }
            set { _fechaIngreso = value; }
        }

        public DateTime FechaRetiro
        {
            get { return _fechaRetiro; }
            set { _fechaRetiro = value; }
        }

        public Habitacion Habitacion
        {
            get { return _habitacion; }
            set { _habitacion = value; }
        }

        public double CostoReserva
        {
            get { return _costoReserva; }
        }

        public Reserva(DateTime _fechaIngreso, DateTime _fechaRetiro,Habitacion _habitacion)
        {
            this._fechaIngreso = _fechaIngreso;
            this._fechaRetiro = _fechaRetiro;
            this._habitacion = _habitacion;
            int dias = 0;
            TimeSpan ts = FechaIngreso - FechaRetiro;
            dias = ts.Days;
            _costoReserva = dias * Habitacion.CostoDiario;
        }
    }
}
