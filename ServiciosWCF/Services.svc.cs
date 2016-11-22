using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Modelo;

namespace ServiciosWCF
{
    public class Services : HoteleraWCF
    {
        Usuario HoteleraWCF.Login(string user, string pass)
        {
            Usuario u = Conector.getUsuario(getRut(user));
            if (u != null & pass == u.Pwd)
                return u;
            return null;
        }

        protected int getRut(string rut)
        {
            if (validaRut(rut))
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));
                return rutAux;
            }
            return 0;
        }

        protected bool validaRut(string rut) //codigo prestado desde http://www.qualityinfosolutions.com/validador-de-rut-chileno-en-c/
        {
            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }
    }
}
