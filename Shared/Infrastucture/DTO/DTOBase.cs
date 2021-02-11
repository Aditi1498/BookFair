namespace Shared
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    /// <summary>
    /// Represents the abstract base class for all Data Transfer Objects,
    /// Author : Nagarro     
    /// </summary>
    [Serializable]
    //[DataContract(Name = "DTOBase", Namespace = "Nagarro.Sample.Shared")]
    public abstract class DTOBase
    {
        private Guid? _uniqueID;
        private ObjectStateType _objState;

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="DTOBase"/> class.
        /// </summary>
        protected DTOBase()
        {
            this._uniqueID = Guid.NewGuid();
            this.ObjectState = ObjectStateType.None;
        }
        #endregion

        #region Class Members

        /// <summary>
        /// private gets or private sets the unique ID.
        /// </summary>
        /// <value>The unique ID.</value>
        //[DataMember]
        public Guid? UniqueID
        {
            get { return _uniqueID; }
            //set { mUniqueID = value; }
        }

        /// <summary>
        /// private gets or private sets the state of the object.
        /// </summary>
        /// <value>The state of the object.</value>
        [DataMember]
        public ObjectStateType ObjectState
        {
            get { return _objState; }
            set
            {
                if (value != ObjectStateType.None &&
                        value != ObjectStateType.Added &&
                        value != ObjectStateType.Updated &&
                        value != ObjectStateType.Deleted)
                {
                    //throw new Exception("Invalid option for Object State!");
                    _objState = ObjectStateType.None;
                }
                else
                {
                    _objState = value;
                }
            }
        }

        #endregion

        #region ICloneable Members
        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>        
        public object Clone()
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, this);
            ms.Position = 0;
            object obj = bf.Deserialize(ms);
            ms.Close();
            return obj;
        }
        #endregion

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Property Changed event. It is fired after a property value has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        /// <summary>
        /// Property changing event. This event fires when a property is about to be changed. It fires before property change happens.
        /// </summary>
        public event PropertyChangingEventHandler PropertyChanging;

        protected void OnPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion
    }
}
