using System;


namespace Shared
{
    /// <summary>
    /// Represents the abstract base class for all Business Domain Components,
    /// Author : Nagarro     
    /// </summary>
    public abstract class BDCBase : IBusinessDomainComponent
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="BDCBase"/> class.
        /// </summary>
        /// <param name="bdcType">Type of the BDC.</param>
        /// <param name="securityToken">The security token.</param>
        protected BDCBase(BDCType bdcType)
        {
            BDCType = bdcType;
        }

        #endregion

        #region IBusinessDomainComponent Members

        /// <summary>
        /// Gets the type of the BDC.
        /// </summary>
        /// <value>The type of the BDC.</value>
        public BDCType BDCType { get; private set; }

        BDCType IBusinessDomainComponent.BDCType => throw new NotImplementedException();

        #endregion
    }
}
