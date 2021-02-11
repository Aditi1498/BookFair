using System;
using System.Text;

namespace Shared
{
    /// <summary>
    /// Represents manager class to handle exceptions,
    /// Author: Nagarro
    /// </summary>
    public static class ExceptionManager
    {
        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <param name="sendNotification">if set to <c>true</c> [send mail].</param>
        public static void HandleException(Exception ex, bool sendNotification)
        {
            string formattedMessage = ExceptionManager.FormatException(ex);
            //Logger.Instance.LogError(formattedMessage);
            if (sendNotification)
            {
                SendExceptionEmail(formattedMessage);
            }
        }

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public static void HandleException(Exception ex)
        {
            HandleException(ex, false);
        }


        /// <summary>
        /// Formats the exception.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <returns></returns>
        public static string FormatException(Exception ex)
        {
            StringBuilder message = new StringBuilder();
            while (ex != null)
            {
                message.AppendLine(ex.Message);
                message.AppendLine(ex.StackTrace);
                ex = ex.InnerException;
            }
            return message.ToString();
        }

        /// <summary>
        /// Sends the exception email.
        /// </summary>
        /// <param name="message">The message.</param>
        private static void SendExceptionEmail(string message)
        {
            //TODO: Send mail
            throw new NotImplementedException(string.Format("Send Exception email is not implemented ! Message: {0}", message));
        }
    }
}
