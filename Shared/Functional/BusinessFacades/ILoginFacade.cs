namespace Shared
{
    public interface ILoginFacade : IFacade
    {
        OperationResult<UserDTO> SignUp(UserDTO userDTO);

        OperationResult<UserDTO> Login(UserDTO userDTO);

    }
}
