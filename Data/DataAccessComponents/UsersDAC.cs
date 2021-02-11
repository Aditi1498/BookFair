using EntityDataModel.Converter;
using EntityDataModel.EntityModel;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.DataAccessComponents
{
    class UsersDAC : DACBase, IUsersDAC
    {
        public UsersDAC() : base(DACType.UsersDAC)
        {

        }

        public List<UserDTO> GetUsers()
        {
            List<UserDTO> userDTOs = new List<UserDTO>();
            try
            {
                using (BookContext db = new BookContext())
                {
                    var users = (from u in db.Users
                                        select new {u.Name,u.EmailId}).ToList();
                    List<User> userList = new List<User>();
                    foreach(var user in users)
                    {
                        User userobj = new User();
                        userobj.Name = user.Name;
                        userobj.EmailId = user.EmailId;
                        userList.Add(userobj);
                    }
                    foreach (var user in userList)
                    {
                        UserDTO userDTO = new UserDTO();
                        EntityConverter.FillDTOFromEntity(user, userDTO);
                        userDTOs.Add(userDTO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }
            return userDTOs;
        }
         
    }
}
