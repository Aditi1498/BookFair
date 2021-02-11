namespace Shared
{
    public interface ILoginBDC : IBusinessDomainComponent
    {
        OperationResult<UserDTO> SignUp(UserDTO userDTO);

        OperationResult<UserDTO> Login(UserDTO userDTO);

    }
}
