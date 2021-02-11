namespace Shared

{
    /// <summary>
    /// Represents the abstract base class for all facades,
    /// Author : Nagarro     
    /// </summary>
    public abstract class FacadeBase : IFacade
    {
        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="FacadeBase"/> class.
        /// </summary>
        /// <param name="facadeType">Type of the facade.</param>
        protected FacadeBase(FacadeType facadeType)
        {
            FacadeType = facadeType;
        }
        #endregion

        #region IFacade Members

        /// <summary>
        /// Gets the type of the facade.
        /// </summary>
        /// <value>The type of the facade.</value>
        public FacadeType FacadeType { get; private set; }

        #endregion
    }
}
