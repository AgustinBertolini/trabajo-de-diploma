using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;
using DAL;
using Entidades;

namespace Servicios
{
    public static class DigitoVerificador
    {
        public static string CalcularDigitoVerificador(List<IVerificableEntity> entidades, bool guardarHorizontal)
        {
            string dvhTotal = string.Empty;

            foreach (var entidad in entidades)
            {
                string dvhEntidad = string.Empty;
                var props = entidad.GetType().GetProperties();

                foreach (var prop in props)
                {
                    if (prop.Name == "DV") continue;

                    object valor = prop.GetValue(entidad);

                    if (valor != null)
                    {
                        if (valor is DateTime fecha)
                        {
                            dvhEntidad += fecha.ToString("ddMMyyyyHHmmss");
                        }
                        else
                        {
                            dvhEntidad += valor.ToString();
                        }
                    }
                }

                entidad.DV = Encriptador.CreateHash(dvhEntidad);
                if (guardarHorizontal)
                {
                    GuardarDigitoVerificadorHorizontal(entidad.DV, entidad.Id);
                }
                dvhTotal += entidad.DV;
            }

            return Encriptador.CreateHash(dvhTotal);
        }

        public static string ObtenerDigitoGuardado()
        {
            DigitoVerificadorDAL digitoVerificadorDAL = new DigitoVerificadorDAL();
            return digitoVerificadorDAL.GetDigitoVerificador();
        }

        public static void GuardarDigitoVerificadorHorizontal(string dv,int id)
        {
            DigitoVerificadorDAL digitoVerificadorDAL = new DigitoVerificadorDAL();

            digitoVerificadorDAL.GuardarDigitoVerificadorHorizontal(dv,id);
        }

        public static void GuardarDigitoVerificador(string dv)
        {
            DigitoVerificadorDAL digitoVerificadorDAL = new DigitoVerificadorDAL();

            digitoVerificadorDAL.GuardarDigitoVerificador(dv);
        }
    }
}
