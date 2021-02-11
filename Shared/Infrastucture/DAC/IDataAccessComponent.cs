namespace Shared
{
    /// <summary>
    /// Defines a contract for data access component,
    /// Author		: Nagarro
    /// </summary>
    public interface IDataAccessComponent
    {
        /// <summary>
        /// private gets the type of the DAC.
        /// </summary>
        /// <value>The type of the DAC.</value>
        DACType Type { get; }

    }
}
