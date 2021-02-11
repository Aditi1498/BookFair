using System;
using System.Diagnostics.CodeAnalysis;

namespace Shared
{

    /// <summary>
    /// Represents a result of an business operation (method call),
    /// Author : Nagarro     
    /// </summary>
    /// <typeparam name="T">Represent the actual return type of the operation/method.</typeparam>
    [Serializable]
    public sealed class OperationResult<T>
    {
        private bool checkedForValidity = false;

        private T data;

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public T Data
        {
            get
            {
                if (!checkedForValidity)
                {
                    throw new NotSupportedException("You must check for data validity by calling IsValid() first!");
                }

                return data;
            }

            private set
            {
                data = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of the result.
        /// </summary>
        /// <value>The type of the result.</value>
        public OperationResultType ResultType { get; private set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; private set; }

        /// <summary>
        /// Gets or sets the stack trace.
        /// </summary>
        /// <value>The stack trace.</value>
        public string StackTrace { get; private set; }

        /// <summary>
        /// Gets or sets the validation result.
        /// </summary>
        /// <value>The JCC validation result.</value>
        public CustomValidationResult customValidationResult { get; private set; }

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationResult&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="message">The message.</param>
        /// <param name="stackTrace">The stack trace.</param>
        private OperationResult(T data, OperationResultType resultType, string message, string stackTrace,CustomValidationResult customValidationResult)
        {
            this.Data = data;
            this.ResultType = resultType;
            this.Message = message;
            this.StackTrace = stackTrace;
            this.customValidationResult = customValidationResult;
        }

        #endregion

        #region Validation Methods

        /// <summary>
        /// Determines whether this instance is valid.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </returns>
        public bool IsValid()
        {
            bool result = checkedForValidity = true;

            if (this.Data == null || HasValidationFailed() || HasExceptionOccurred())
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Determines whether exception has occurred.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if [has exception occurred]; otherwise, <c>false</c>.
        /// </returns>
        public bool HasExceptionOccurred()
        {
            bool result = false;

            if (this.ResultType == OperationResultType.Error)
            {
                if (!String.IsNullOrWhiteSpace(this.Message))
                {
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Determines whether validation has failed.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if [has validation failed]; otherwise, <c>false</c>.
        /// </returns>
        public bool HasValidationFailed()
        {
            bool result = false;

            if (this.ResultType == OperationResultType.Failure)
            {
                if (!String.IsNullOrWhiteSpace(this.Message))
                {
                    result = true;
                }
            }

            return result;
        }
        #endregion

        #region Factory Methods

        /// <summary>
        /// Creates the success result.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>        
        [SuppressMessage(SuppressMessageConstants.DesignCategory, SuppressMessageConstants.DoNotDeclareStaticMembersOnGenericTypes)]
        public static OperationResult<T> CreateSuccessResult(T data)
        {
            return new OperationResult<T>(data, OperationResultType.Success, string.Empty, string.Empty,null);
        }

        /// <summary>
        /// Creates the success result.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>        
        [SuppressMessage(SuppressMessageConstants.DesignCategory, SuppressMessageConstants.DoNotDeclareStaticMembersOnGenericTypes)]
        public static OperationResult<T> CreateSuccessResult(T data, string successMessage)
        {
            return new OperationResult<T>(data, OperationResultType.Success, successMessage, string.Empty,null);
        }

        /// <summary>
        /// Creates the failure result.
        /// </summary>
        /// <param name="failureMessage">The failure message.</param>
        /// <returns></returns>
        [SuppressMessage(SuppressMessageConstants.DesignCategory, SuppressMessageConstants.DoNotDeclareStaticMembersOnGenericTypes)]
        public static OperationResult<T> CreateFailureResult(string failureMessage)
        {
            return new OperationResult<T>(default(T), OperationResultType.Failure, failureMessage, string.Empty,null);
        }

        /// <summary>
        /// Creates the failure result.
        /// </summary>
        /// <param name="errorCode">The validation error code.</param>
        /// <returns></returns>
        //[SuppressMessage(SuppressMessageConstants.DesignCategory, SuppressMessageConstants.DoNotDeclareStaticMembersOnGenericTypes)]
        public static OperationResult<T> CreateFailureResult(CustomValidationResult validationResult)
        {
            return new OperationResult<T>(default(T), OperationResultType.Failure, string.Empty, string.Empty, validationResult);
        }

        /// <summary>
        /// Creates the error result.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="stackTrace">The stack trace.</param>
        /// <returns></returns>
        [SuppressMessage(SuppressMessageConstants.DesignCategory, SuppressMessageConstants.DoNotDeclareStaticMembersOnGenericTypes)]
        public static OperationResult<T> CreateErrorResult(string errorMessage, string stackTrace)
        {
            return new OperationResult<T>(default(T), OperationResultType.Error, errorMessage, stackTrace,null);
        }

        /// <summary>
        /// Creates the success result.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>        
        [SuppressMessage(SuppressMessageConstants.DesignCategory, SuppressMessageConstants.DoNotDeclareStaticMembersOnGenericTypes)]
        public static OperationResult<string> CreateSessionTimedOutResult(string data)
        {
            return new OperationResult<string>(data, OperationResultType.SessionTimedOut, string.Empty, string.Empty,null);
        }

        /// <summary>
        /// Creates the success result.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>        
        [SuppressMessage(SuppressMessageConstants.DesignCategory, SuppressMessageConstants.DoNotDeclareStaticMembersOnGenericTypes)]
        public static OperationResult<string> CreateRedirectResult(string data)
        {
            return new OperationResult<string>(data, OperationResultType.Redirect, string.Empty, string.Empty,null);
        }

        [SuppressMessage(SuppressMessageConstants.DesignCategory, SuppressMessageConstants.DoNotDeclareStaticMembersOnGenericTypes)]
        public static OperationResult<T> CreateHttpRequestValidationResult(string errorMessage, string stackTrace)
        {
            return new OperationResult<T>(default(T), OperationResultType.HttpRequestValidation, errorMessage, stackTrace,null);
        }

        #endregion
    }
}
