namespace Shared
{
    public interface IloginDAC : IDataAccessComponent
    {
        UserDTO SignUp(UserDTO userDTO);

        UserDTO Login(UserDTO userDTO);

    }
}
