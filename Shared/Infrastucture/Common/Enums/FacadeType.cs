namespace Shared
{
    public enum FacadeType
    {
        /// <summary>
        /// Undefined Facade Type (Default)
        /// </summary>
        Undefined = 0,


        [QualifiedTypeName("BusinessFacades.dll", "BusinessFacades.Facades.EventsFacades")]
        EventsFacade = 1,

        [QualifiedTypeName("BusinessFacades.dll", "BusinessFacades.Facades.LoginFacade")]
        LoginFacade = 2,

        UserEventMappingFacade = 3,


        [QualifiedTypeName("BusinessFacades.dll", "BusinessFacades.Facades.CommentsFacade")]
        CommentsFacade = 4,

        [QualifiedTypeName("BusinessFacades.dll", "BusinessFacades.Facades.UsersFacade")]
        UsersFacade = 5




    }
}
