using System;

namespace Shared
{
    /// <summary>
    /// Represents the factory for facades,
    /// Author : Nagarro     
    /// </summary>
    public class FacadeFactory : FactoryBase, IFacadeFactory
    {
        //The variable is declared to be volatile to ensure that assignment to the 
        //_instance variable completes before the instance variable can be accessed.
        [ThreadStatic]
        private static volatile FacadeFactory _instance;
        private static object _syncObject = new object();

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="FacadeFactory"/> class.
        /// </summary>
        private FacadeFactory()
        {
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Instance is public static property to return the same Instance of the class everytime.
        /// Note: Double - checked serialized initialization of Class pattern is used.
        /// </summary>
        public static FacadeFactory Instance
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
                            _instance = new FacadeFactory();
                        }
                    }
                }
                #endregion

                return _instance;
            }
        }

        #endregion

        #region IFacadeFactory Members

        /// <summary>
        /// Creates the specified facade type.
        /// </summary>
        /// <param name="facadeType">The type.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public IFacade Create(FacadeType facadeType, params object[] args)
        {
            // get atrribute value
            QualifiedTypeNameAttribute QualifiedNameAttr = EnumAttributeUtility<FacadeType, QualifiedTypeNameAttribute>.GetEnumAttribute(facadeType.ToString());

            // create instance
            return (IFacade)this.CreateObjectInstance(QualifiedNameAttr.AssemblyFileName, QualifiedNameAttr.QualifiedTypeName, args);
        }

        

        #endregion
    }
}
