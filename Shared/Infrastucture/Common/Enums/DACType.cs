namespace Shared
{
    public enum DACType
    {
        Undefined = 0,

        [QualifiedTypeName("Data.dll", "Data.DataAccessComponents.EventsDAC")]
        EventsDAC = 1,

        [QualifiedTypeName("Data.dll", "Data.DataAccessComponents.LoginDAC")]
        LoginDAC = 2,

        UserEventMappingDAC = 3,

        [QualifiedTypeName("Data.dll", "Data.DataAccessComponents.CommentsDAC")]
        CommentsDAC = 4,

        [QualifiedTypeName("Data.dll", "Data.DataAccessComponents.UsersDAC")]
        UsersDAC = 5




        //[QualifiedTypeName("Data.dll", "Data.DataAccessComponents.UsersDAC")]
        //UsersDAC = 2

    }
}
