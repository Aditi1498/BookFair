using System;
using System.Runtime.Serialization;

namespace Shared
{
    /// <summary>
    /// Represent an attribute not defined exception,
    /// Author : Nagarro
    /// </summary>
    [Serializable]
    public class AttributeNotDefinedException : ExceptionBase
    {
        private const string MessageHeader = "Attribute Exception: ";

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeNotDefinedException"/> class.
        /// </summary>
        public AttributeNotDefinedException()
            : base(MessageHeader, null)
        {
            //this.DefaultExceptionPolicyType = ExceptionPolicyType.Basic;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeNotDefinedException"/> class.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        public AttributeNotDefinedException(int errorCode)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeNotDefinedException"/> class.
        /// </summary>
        /// <param name="enumField">The enum field.</param>
        public AttributeNotDefinedException(string enumField)
            : base(MessageHeader + string.Format("Attribute not defined on {0}", enumField))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeNotDefinedException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public AttributeNotDefinedException(string message, Exception innerException)
            : base(MessageHeader + message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeNotDefinedException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        protected AttributeNotDefinedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
