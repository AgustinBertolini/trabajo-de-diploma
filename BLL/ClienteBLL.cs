using System.Collections.Generic;
using DAL;
using Entidades;

namespace BLL
{
    public class ClienteBLL
    {
        public List<Cliente> GetClientes()
        {
            ClienteDAL dal = new ClienteDAL();
            return dal.GetClientes();
        }

        public int AltaCliente(Cliente cliente)
        {
            ClienteDAL dal = new ClienteDAL();
            return dal.AltaCliente(cliente);
        }

        public bool EditarCliente(Cliente cliente)
        {
            ClienteDAL dal = new ClienteDAL();
            return dal.EditarCliente(cliente);
        }

        public bool BorrarCliente(int id)
        {
            ClienteDAL dal = new ClienteDAL();
            return dal.BorrarCliente(id);
        }

        public List<TipoCliente> GetTiposCliente()
        {
            ClienteDAL dal = new ClienteDAL();
            return dal.GetTiposCliente();
        }
    }
}
