using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFacades.Facades
{
    class UsersFacade : FacadeBase, IUsersFacade
    {
        public UsersFacade() : base(FacadeType.UsersFacade)
        {

        }

        public List<UserDTO> GetUsers()
        {
            IUsersBDC usersBDC = (IUsersBDC)BDCFactory.Instance.Create(BDCType.UsersBDC);
            return usersBDC.GetUsers();
        }
    }
}
