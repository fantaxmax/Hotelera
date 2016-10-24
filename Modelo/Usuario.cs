using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public static string encripta(string clave) //Obtenido desde internet
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            //encrypt the given password string into Encrypted data  
            encrypt = md5.ComputeHash(encode.GetBytes(clave));
            StringBuilder encryptdata = new StringBuilder();
            //Create a new string by using the encrypted data  
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }

        public void cambiaClave(string clave)
        {
            _pwd = encripta(clave);
        }

        public bool Insertar()
        {
            try
            {
                EDM.Usuario u = new EDM.Usuario();
                u.rut = Persona.Rut;
                u.pwd = Pwd;
                Conector.HotelEntities.Usuarios.Add(u);
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
                EDM.Usuario u = Conector.HotelEntities.Usuarios.Find(Persona.Rut);
                Conector.HotelEntities.Usuarios.Remove(u);
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
                EDM.Usuario u = Conector.HotelEntities.Usuarios.Find(Persona.Rut);
                u.pwd = Pwd;
                Conector.HotelEntities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
