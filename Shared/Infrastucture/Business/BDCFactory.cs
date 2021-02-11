namespace Shared
{
    public class BDCFactory : FactoryBase, IBDCFactory
    {
        //The variable is declared to be volatile to ensure that assignment to the 
        //_instance variable completes before the instance variable can be accessed.
        private static volatile BDCFactory _instance;
        private static object _syncObject = new object();

        #region Ctor
        /// <summary>
        /// Constructor definition
        /// </summary>
        private BDCFactory()
        {
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Instance is private static property to return the same Instance of the class everytime.
        /// Note: Double - checked serialized initialization of class pattern is used.
        /// </summary>
        public static BDCFactory Instance
        {
            get
            {
                #region Single Instance Logic
                //Check for null before acquiring the lock.
                if (_instance == null)
                {
                    //Use a _syncObject to lock on, to avoid deadlocks among multiple threads.
                    lock (_syncObject)
                    {
                        //Again check if _instance has been initialized, 
                        //since some other thread may have acquired the lock first and constructed the object.
                        if (_instance == null)
                        {
                            _instance = new BDCFactory();
                        }
                    }
                }
                #endregion

                return _instance;
            }
        }

        #endregion

        #region IBDCFactory Members

        /// <summary>
        /// Creates the specified BDC type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public IBusinessDomainComponent Create(BDCType type, params object[] args)
        {
            // get attribute value
            QualifiedTypeNameAttribute QualifiedNameAttr = EnumAttributeUtility<BDCType, QualifiedTypeNameAttribute>.GetEnumAttribute(type.ToString());

            // create instance
            return (IBusinessDomainComponent)this.CreateObjectInstance(QualifiedNameAttr.AssemblyFileName, QualifiedNameAttr.QualifiedTypeName, args);
        }

        
        #endregion
    }
}
