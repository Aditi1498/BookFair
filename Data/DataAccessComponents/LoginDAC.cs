using EntityDataModel.Converter;
using EntityDataModel.EntityModel;
using Shared;
using System;
using System.Linq;

namespace Data.DataAccessComponents
{
    class LoginDAC : DACBase, IloginDAC
    {
        public LoginDAC() : base(DACType.LoginDAC)
        {

        }

        public UserDTO Login(UserDTO userDTO)
        {
            UserDTO retVal = null;
            //System.Diagnostics.Debug.WriteLine("***********************************************************");
            try
            {
                using (BookContext db = new BookContext())
                {
                    var userInfo = db.Users.FirstOrDefault(e => e.EmailId == userDTO.EmailID && e.Password == userDTO.Password);
                    if (userInfo != null)
                    {
                        EntityConverter.FillDTOFromEntity(userInfo, userDTO);
                        retVal = userDTO;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }
            return retVal;
        }


        public UserDTO SignUp(UserDTO userDTO)
        {
            User user = new User();
            BookContext db = new BookContext();
            string emailID = userDTO.EmailID;
            if (db.Users.Any(e => e.EmailId == emailID))
            {
                return null;
            }
            else
            {
                UserDTO result = new UserDTO();
                EntityConverter.FillEntityFromDTO(userDTO, user);
                db.Users.Add(user);
                db.SaveChanges();
                return userDTO;
            }
        }
    }
}
