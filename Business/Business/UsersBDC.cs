using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business
{
    class UsersBDC : BDCBase, IUsersBDC
    {
        public UsersBDC() : base(BDCType.UsersBDC)
        {
                
        }

        //Get Users to invite them
        public List<UserDTO> GetUsers()
        {
            IUsersDAC usersDAC = (IUsersDAC)DACFactory.Instance.Create(DACType.UsersDAC);
            return usersDAC.GetUsers();
        }
    }
}
