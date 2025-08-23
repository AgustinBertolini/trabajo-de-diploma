using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;

namespace Servicios
{
    public static class Bitacoras
    {
        public static List<Bitacora> GetBitacoras()
        {
                BitacoraDAL bitacoraDAL = new BitacoraDAL();

                return bitacoraDAL.GetBitacoras();

        }

        public static void AltaBitacora(string mensaje, TipoEvento tipoEvento, int idUsuario)
        {
            try
            {
                Bitacora bitacora = new Bitacora();
                bitacora.Mensaje = mensaje;
                bitacora.TipoEvento = tipoEvento;
                bitacora.IdUsuario = idUsuario;

                BitacoraDAL bitacoraDAL = new BitacoraDAL();
                bitacoraDAL.AltaBitacora(bitacora);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
