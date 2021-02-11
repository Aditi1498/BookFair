using Shared;

namespace BusinessFacades.Facades
{
    public class LoginFacade : FacadeBase, ILoginFacade
    {
        public LoginFacade() : base(FacadeType.LoginFacade)
        {

        }

        public OperationResult<UserDTO> Login(UserDTO userDTO)
        {
            ILoginBDC loginBDC = (ILoginBDC)BDCFactory.Instance.Create(BDCType.LoginBDC);
            return loginBDC.Login(userDTO);
        }


        public OperationResult<UserDTO> SignUp(UserDTO userDTO)
        {
            ILoginBDC signUpBDC = (ILoginBDC)BDCFactory.Instance.Create(BDCType.LoginBDC);
            return signUpBDC.SignUp(userDTO);
        }
    }
}
