using System;

namespace Shared
{
    /// <summary>
    /// Represents the factory for data access components,
    /// Author		: Nagarro
    /// </summary>
    public class DACFactory : FactoryBase, IDACFactory
    {
        //The variable is declared to be volatile to ensure that assignment to the 
        //mInstance variable completes before the instance variable can be accessed.
        [ThreadStatic]
        private static volatile DACFactory _Instance;
        private static object _SyncObject = new object();

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="DACFactory"/> class.
        /// </summary>
        private DACFactory()
        {
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Instance is private static property to return the same Instance of the class everytime.
        /// Note: Double - checked serialized initialization of Class pattern is used.
        /// </summary>
        public static DACFactory Instance
        {
            get
            {
                #region Single Instance Logic
                //Check for null before acquiring the lock.
                if (_Instance == null)
                {
                    //Use a mSyncObject to lock on, to avoid deadlocks among multiple threads.
                    lock (_SyncObject)
                    {
                        //Again check if mInstance has been initialized, 
                        //since some other thread may have acquired the lock first and constructed the object.
                        if (_Instance == null)
                        {
                            _Instance = new DACFactory();
                        }
                    }
                }
                #endregion

                return _Instance;
            }
        }
        #endregion

        #region IDACFactory Members

        /// <summary>
        /// Creates the specified DAC type.
        /// </summary>
        /// <param name="type">The DAC type.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public IDataAccessComponent Create(DACType type, params object[] args)
        {
            // get attribuye value
            QualifiedTypeNameAttribute QualifiedNameAttr = EnumAttributeUtility<DACType, QualifiedTypeNameAttribute>.GetEnumAttribute(type.ToString());

            // create instance
            return (IDataAccessComponent)this.CreateObjectInstance(QualifiedNameAttr.AssemblyFileName, QualifiedNameAttr.QualifiedTypeName, args);
        }

        
        #endregion
    }
}

