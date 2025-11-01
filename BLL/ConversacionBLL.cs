using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Servicios;

namespace BLL
{
    public class ConversacionBLL
    {
            private readonly ConversacionDAL dal;

            public ConversacionBLL()
            {
                dal = new ConversacionDAL();
            }

            public int CrearConversacion()
            {
                return dal.CrearConversacion(SessionManager.GetInstance.Usuario.Id);
            }

        public List<Conversacion> GetConversacionesByUsuario(int idUsuario)
            {
                var conversaciones = dal.GetConversacionesByUsuario(idUsuario);

                foreach (var c in conversaciones)
                {
                    c.Mensajes = dal.GetMensajesByConversacion(c.Id);
                }

                return conversaciones;
            }

            public List<Mensaje> GetMensajesByConversacion(int idConversacion)
            {
                return dal.GetMensajesByConversacion(idConversacion);
            }

            public int EnviarMensaje(Mensaje mensaje)
            {
                if (string.IsNullOrWhiteSpace(mensaje.Texto))
                    throw new Exception("El mensaje no puede estar vacío.");

                if (mensaje.IdConversacion <= 0 || mensaje.IdEmisor <= 0)
                    throw new Exception("Datos de conversación o emisor inválidos.");

                return dal.InsertarMensaje(mensaje);
            }
        }
}
