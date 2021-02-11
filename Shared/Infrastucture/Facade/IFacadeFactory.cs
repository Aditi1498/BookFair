namespace Shared
{
    /// <summary>
    /// Defines a contract for factory facade,
    /// Author : Nagarro
    /// </summary>
    public interface IFacadeFactory
    {
        /// <summary>
        /// Creates the specified facade type.
        /// </summary>
        /// <param name="facadeType">Type of the facade.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        IFacade Create(FacadeType facadeType, params object[] args);
    }
}
