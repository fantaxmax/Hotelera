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
        private int _costoDiario;

        public int Numero
        {
            get { return _numero; }
        }

        public TipoHabitacion Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public int CostoDiario
        {
            get { return _costoDiario; }
            set { _costoDiario = value; }
        }

        public Habitacion()
        {

        }

        public Habitacion(int numero,TipoHabitacion tipo,int costoDiario)
        {
            _numero = numero;
            _tipo = tipo;
            _costoDiario = costoDiario;
        }

        public override string ToString()
        {
            return Numero + " : " + (Tipo == TipoHabitacion.Single ? "Single" : (Tipo == TipoHabitacion.Doble ? "Doble" : "Suite"));
        }

        public bool Insertar()
        {
            try
            {
                EDM.Habitacion h = new EDM.Habitacion();
                h.numero = Numero;
                h.tipo = (int)Tipo;
                h.costoDiario = CostoDiario;
                Conector.HotelEntities.Habitacions.Add(h);
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
                EDM.Habitacion h = Conector.HotelEntities.Habitacions.Find(Numero);
                Conector.HotelEntities.Habitacions.Remove(h);
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
                EDM.Habitacion h = Conector.HotelEntities.Habitacions.Find(Numero);
                h.numero = Numero;
                h.tipo = (int)Tipo;
                h.costoDiario = CostoDiario;
                Conector.HotelEntities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
    public enum TipoHabitacion
    {
        Single=1,Doble=2,Suite=3
    }
}
