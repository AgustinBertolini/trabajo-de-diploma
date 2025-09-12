using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;

namespace BLL
{
    public class RolBLL
    {
        public List<Rol> GetRoles()
        {
            try
            {
                RolDAL rolDAL = new RolDAL();

                List<Rol> roles = rolDAL.GetRoles();

                return roles;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
