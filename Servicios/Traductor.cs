using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Entidades;
using DAL;

namespace Servicios
{
    public static class Traductor
    {
     
        public static List<Traduccion> GetTraducciones(int IdIdioma)
        {
            TraductorDAL traductorDAL = new TraductorDAL();

            return traductorDAL.GetTraducciones(IdIdioma);
        } 
        
        public static Traduccion GetTraduccion(int id)
        {
            TraductorDAL traductorDAL = new TraductorDAL();

            return traductorDAL.GetTraduccion(id);
        }

        public static List<Idioma> GetIdiomas()
        {
            TraductorDAL traductorDAL=new TraductorDAL();

            return traductorDAL.GetIdiomas();
        }

        public static Idioma CambiarIdioma(int idIdioma)
        {
            TraductorDAL traductorDAL = new TraductorDAL();

            List<Idioma> idiomas = traductorDAL.GetIdiomas();

            return (Idioma)idiomas.Where(x => x.Id == idIdioma).FirstOrDefault();

        }

        public static void EditarTraduccion(int id, string valor)
        {
            TraductorDAL traductorDAL = new TraductorDAL();
            traductorDAL.EditarTraduccion(id, valor);
        }
    }
}
