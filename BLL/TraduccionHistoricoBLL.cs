using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;

namespace BLL
{
    public class TraduccionHistoricoBLL
    {
        public void CrearHistorico(string valorViejo, string valorNuevo, int idTraduccion)
        {
            try
            {
                TraduccionHistorico traduccion = new TraduccionHistorico();
                traduccion.Id = 0;
                traduccion.ValorViejo = valorViejo;
                traduccion.ValorNuevo = valorNuevo;
                traduccion.IdTraduccion = idTraduccion;


                TraduccionHistoricoDAL dal = new TraduccionHistoricoDAL();

                dal.CrearHistorico(traduccion);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<TraduccionHistorico> GetHistoricos()
        {
            TraduccionHistoricoDAL dal = new TraduccionHistoricoDAL();

            return dal.GetHistoricos();
        }

    }
}
