using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Shared
{
    /// <summary>
    /// Provides static utility methods for data validation purposes,
    /// Author : Nagarro
    /// </summary>
    public static class ValidatorUtility
    {
        #region Custom Validation

        #region IsValidName
        /// <summary>
        /// Validates a name. 
        /// -Allow only alphabets, spaces and dot.
        /// -Must start and end with alphabet
        /// -Length must be between 3 and 50
        /// </summary>
        /// <param name="name">string variable to be validated</param>
        /// <returns></returns>
        public static bool IsValidName(string name)
        {
            //@"^[a-zA-Z'.\s]{3,50}$"))
            if (Regex.IsMatch(name, @"^[a-zA-Z][a-zA-Z'.\s]+[a-zA-Z]{1,48}$"))
                return true;
            else
                return false;
        }
        #endregion

        #region IsValidPhoneNumber
        /// <summary>
        /// Validates a phone number for 10 numeric digits.
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool IsValidPhoneNumber(string phone)
        {
            if (Regex.IsMatch(phone, @"^\d{10}$"))
                return true;
            else
                return false;
        }
        #endregion

        #region IsValidURL

        /// <summary>
        /// Determines whether the specified string is a valid URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>
        /// 	<c>true</c> if [string URL] [is well formed]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidUrl(string url)
        {
            return IsValidUrl(new Uri(url));
            //if (Regex.IsMatch(url, @"^(?:http|https|ftp)://[a-zA-Z0-9\.\-]+(?:\:\d{1,5})?(?:[A-Za-z0-9\.\;\:\@\&\=\+\$\,\?/]|%u[0-9A-Fa-f]{4}|%[0-9A-Fa-f]{2})*$"))//^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$
            //    return true;
            //else
            //    return false;
        }

        /// <summary>
        /// Determines whether the specified URI is valid.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns>
        /// 	<c>true</c> if [URL] [is well formed]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidUrl(Uri uri)
        {
            return uri.IsWellFormedOriginalString();
        }
        #endregion

        #region IsValidEmail
        /// <summary>
        /// Validates an e-mail address.
        /// </summary>
        /// <param name="email">Email address to be validated</param>
        /// <returns>returns true if the passed email address is valid otherwise false</returns>
        public static bool IsValidEmail(string email)
        {
            if (Regex.IsMatch(email, @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
                return true;
            else
                return false;
        }
        #endregion

        #region IsValidPassword
        /// <summary>
        /// Validates a strong password. 
        /// It must be between 6 and 10 characters, 
        /// contain at least one digit and one alphabetic character, 
        /// and must not contain special characters.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool IsValidPassword(string password)
        {
            if (Regex.IsMatch(password, "(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,10})$"))
                return true;
            else
                return false;
        }
        #endregion

        #region IsValidPositiveCurrency
        /// <summary>
        /// Validates a positive currency amount. If there is a decimal point, it requires 2 numeric characters after the decimal point. For example, 3.00 is valid but 3.1 is not.
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        public static bool IsValidPositiveCurrency(string currency)
        {
            if (Regex.IsMatch(currency, @"^\d+(\.\d\d)?$"))
                return true;
            else
                return false;
        }
        #endregion

        #region IsValidCurrency
        /// <summary>
        /// Validates for a positive or negative currency amount. If there is a decimal point, it requires 2 numeric characters after the decimal point.
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        public static bool IsValidCurrency(string currency)
        {
            if (Regex.IsMatch(currency, @"^(-)?\d+(\.\d\d)?$"))
                return true;
            else
                return false;
        }
        #endregion

        #region IsDataMalicious
        /// <summary>
        /// This function is used for validating data against SQL Injection
        /// </summary>
        /// <param name="data"></param>
        /// <returns>boolean value True/False</returns>
        public static bool IsDataMalicious(string data)
        {
            string dataLowerCase = data.ToUpperInvariant();
            if ((data.Contains("'")) || ((data.Contains("'")) && (data.Contains("="))) ||
                (dataLowerCase.Contains(";")) || (dataLowerCase.Contains("insert") &&
                dataLowerCase.Contains("into")) || (dataLowerCase.Contains("delete") &&
                dataLowerCase.Contains("from")) || (dataLowerCase.Contains("update") &&
                dataLowerCase.Contains("private set")) || (dataLowerCase.Contains("drop") &&
                dataLowerCase.Contains("table")) || (dataLowerCase.Contains("drop") &&
                dataLowerCase.Contains("procedure")) || (dataLowerCase.Contains("drop") &&
                dataLowerCase.Contains("view")) || (dataLowerCase.Contains("create") &&
                dataLowerCase.Contains("table")) || (dataLowerCase.Contains("create") &&
                dataLowerCase.Contains("view")) || (dataLowerCase.Contains("create") &&
                dataLowerCase.Contains("procedure")))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region TrimIfNotNull
        /// <summary>
        /// This function is used for trim the string
        /// </summary>
        /// <param name="data"></param>
        /// <returns>trim string</returns>
        public static string TrimIfNotNull(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                data = data.Trim();
            }
            return data;
        }
        #endregion

        #endregion

        #region Value Type Validation

        #region IsNull

        /// <summary>
        /// Determines whether the specified value is null.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified value is null; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNull(Int64 value)
        {
            if (value == default(Int64) || value == Int64.MinValue || value == Int64.MaxValue)
                return true;
            else
                return false;
        }
        public static bool IsNull(Int32 value)
        {
            if (value == default(Int32) || value == Int32.MinValue || value == Int32.MaxValue)
                return true;
            else
                return false;
        }
        public static bool IsNull(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Trim().Length == 0)
                return true;
            else
                return false;
        }
        public static bool IsNullOrEmpty(string value)
        {
            // forward
            return ValidatorUtility.IsNull(value);
        }
        public static bool IsNull(Decimal value)
        {
            if (value == default(decimal) || value == decimal.MinValue || value == decimal.MaxValue)
                return true;
            else
                return false;
        }
        public static bool IsNull(DateTime value)
        {
            if (value == null || value == DateTime.MaxValue || value == DateTime.MinValue)
                return true;
            else
                return false;
        }
        public static bool IsNull(double value)
        {
            if (value == default(double) || value == double.MinValue || value == double.MaxValue)
                return true;
            else
                return false;
        }
        #endregion

        #region IsInt32
        /// <summary>
        /// Validates that the string value is an integer.
        /// </summary>
        /// <param name="integer"></param>
        /// <returns></returns>
        public static bool IsInt32(string value)
        {
            Int32 i;
            if (Int32.TryParse(value, out i) == false)
                return false;
            else
                return true;
        }
        #endregion

        #endregion

        /// <summary>
        /// Gets the min value or struct.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The obj data.</param>
        /// <returns></returns>
        public static T GetMinValueOrStruct<T>(object data) where T : IConvertible
        {
            var dataType = typeof(T);
            if (data == null || data == DBNull.Value)
            {
                FieldInfo propertyToUse = null;
                if (typeof(T) == typeof(String))
                {
                    propertyToUse = dataType.GetField("Empty");
                }
                else if (typeof(T) == typeof(bool))
                {
                    propertyToUse = dataType.GetField("false");
                }
                else
                {

                    propertyToUse = dataType.GetField("MinValue");

                }
                return (T)propertyToUse.GetValue(dataType);
            }
            else
            {
                MethodInfo methodToCall = null;
                if (data.GetType() == typeof(String))
                {
                    methodToCall = dataType.GetMethods().Where(c => c.Name == "ToString" && c.GetParameters().Length == 0).First();
                    return (T)methodToCall.Invoke(data, new Object[] { });
                }
                else
                {
                    methodToCall = dataType.GetMethods().Where(c => c.Name == "Parse" && c.GetParameters().Length == 1).First();
                    return (T)methodToCall.Invoke(dataType, new Object[] { data.ToString() });
                }
            }
        }

        #region Data Validation Method

        /// <summary>
        /// Validate Data Object
        /// </summary>
        /// <param name="iObject"></param>
        /// <returns></returns>
        static public object ValidateDataObject(object iObject)
        {
            string _typeName = string.Empty;

            try
            {
                if (iObject != null)
                {
                    _typeName = iObject.GetType().FullName;

                    switch (_typeName.ToUpper())
                    {
                        case "SYSTEM.STRING":
                            if (iObject.ToString() == string.Empty)
                                iObject = DBNull.Value;
                            break;
                        case "SYSTEM.INT32":
                            if (Int32.Parse(iObject.ToString()) == Int32.MinValue)
                                iObject = DBNull.Value;
                            break;
                        case "SYSTEM.INT64":
                            if (Int64.Parse(iObject.ToString()) == Int64.MinValue)
                                iObject = DBNull.Value;
                            break;
                        case "SYSTEM.DATETIME":
                            if (DateTime.Parse(iObject.ToString()) == DateTime.MinValue)
                                iObject = DBNull.Value;
                            break;
                        case "SYSTEM.DECIMAL":
                            if (Decimal.Parse(iObject.ToString()) == Decimal.MinValue)
                                iObject = DBNull.Value;
                            break;
                    }
                }
                else
                    iObject = DBNull.Value;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException("An exception occurred while Validating Data Object.", ex);
            }

            return iObject;
        }
        #endregion
    }
}

    