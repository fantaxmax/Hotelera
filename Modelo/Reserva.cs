using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Reserva
    {
        private int _id;
        private DateTime _fechaIngreso;
        private DateTime _fechaRetiro;
        private Habitacion _habitacion;
        private double _costoReserva;
        private int _rut;

        public int ID
        {
            get { return _id; }
        }

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

        public int Rut
        {
            get { return _rut; }
        }

        public Reserva(DateTime _fechaIngreso, DateTime _fechaRetiro, Habitacion _habitacion)
        {
            this._fechaIngreso = _fechaIngreso;
            this._fechaRetiro = _fechaRetiro;
            this._habitacion = _habitacion;
            double dias = 0;
            TimeSpan ts = FechaRetiro - FechaIngreso;
            dias = ts.Days + 1;
            _costoReserva = dias * Habitacion.CostoDiario;
        }

        public Reserva(int _id,DateTime _fechaIngreso, DateTime _fechaRetiro,Habitacion _habitacion,int _rut)
        {
            this._id = _id;
            this._fechaIngreso = _fechaIngreso;
            this._fechaRetiro = _fechaRetiro;
            this._habitacion = _habitacion;
            double dias = 0;
            TimeSpan ts = FechaRetiro - FechaIngreso;
            dias = ts.Days + 1;
            _costoReserva = dias * Habitacion.CostoDiario;
            this._rut = _rut;
        }
    }
}
