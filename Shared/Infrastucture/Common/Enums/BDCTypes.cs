namespace Shared
{
    public enum BDCType
    {
        Undefined = 0,

        [QualifiedTypeName("Business.dll", "Business.Business.EventsBDC")]
        EventsBDC = 1,


        [QualifiedTypeName("Business.dll", "Business.Business.LoginBDC")]
        LoginBDC = 2,


        UserEventMappingBDC = 3,

        [QualifiedTypeName("Business.dll", "Business.Business.CommentsBDC")]
        CommentsBDC = 4,

        [QualifiedTypeName("Business.dll", "Business.Business.UsersBDC")]
        UsersBDC = 5


        //[QualifiedTypeName("Data.dll", "Data.DataAccessComponents.UsersDAC")]
        //UsersDAC = 2

    }
}
