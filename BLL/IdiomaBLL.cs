using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;

namespace BLL
{
    public class IdiomaBLL
    {
        public int AltaIdioma(string nombre)
        {
            try
            {
                Idioma idioma = new Idioma();
                idioma.Id = 0;
                idioma.Nombre = nombre;

                IdiomaDAL idiomaDAL = new IdiomaDAL();

                int idiomaId = idiomaDAL.CrearIdioma(idioma);

                return idiomaId;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool BorrarIdioma(int id)
        {
            try
            {
                IdiomaDAL idiomaDAL = new IdiomaDAL();

                idiomaDAL.BorrarIdioma(id);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool EditarIdioma(int id, string nombre)
        {
            try
            {
                Idioma idioma = new Idioma();
                idioma.Id = id;
                idioma.Nombre = nombre;

                IdiomaDAL idiomaDAL = new IdiomaDAL();
                idiomaDAL.EditarIdioma(idioma);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Idioma> GetIdiomas()
        {
            IdiomaDAL idiomaDAL = new IdiomaDAL();

            return idiomaDAL.GetIdiomas();
        }
        
        public Idioma GetIdioma(int id)
        {
            IdiomaDAL idiomaDAL = new IdiomaDAL();

            return idiomaDAL.GetIdioma(id);
        }



    }
}
