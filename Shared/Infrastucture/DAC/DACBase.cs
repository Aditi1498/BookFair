namespace Shared
{
    using System;

    public abstract class DACBase : IDataAccessComponent
    {

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="DACBase"/> class.
        /// </summary>
        /// <param name="dacType">Type of the dac.</param>
        protected DACBase(DACType dacType)
        {
            this.Type = dacType;
        }
        #endregion

        #region IDataAccessComponent Members

        /// <summary>
        /// private gets the type of the DAC.
        /// </summary>
        /// <value>The type of the DAC.</value>
        public DACType Type { get; private set; }

        DACType IDataAccessComponent.Type => throw new NotImplementedException();

        #endregion

    }
}
