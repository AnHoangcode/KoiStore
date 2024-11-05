using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using Repositories.Implement;
using Repositories.Interfaces;

namespace Services.Implement
{
	public class RoleService
	{

        private IRoleRepo _repo = null;
        public RoleService()
        {
            if (_repo == null)
            {
                _repo = new RoleRepo();
            }
        }
        public List<Role> GetAllRoles()
        {
            return _repo.GetAllRoles();
        }

        public Role GetRoleById(int id)
        {
            return _repo.GetRoleById(id);
        }

        public bool DeleteRole(int id)
        {
            return _repo.DeleteRole(id);
        }

        public bool UpdateRole(Role o)
        {
            return _repo.UpdateRole(o);
        }

        public bool CreateRole(Role o)
        {
            return _repo.CreateRole(o);
        }
	}
}
