using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FeildValidatorAPI
{
    // Creating common field delegates
    public delegate bool RequiredValidDel(string fieldVal);
    public delegate bool StringLengthValidDel(string fieldVal, int min, int max);
    public delegate bool DateValidDel(string fieldVal, out DateTime validDate);
    public delegate bool PatternMatchValidDel(string fieldVal, string pattern);
    public delegate bool CompareFieldsValidDel(string fieldVal, string fieldValCompare);


    /// <summary>
    /// This uses the singleton pattern to ensure one instance of a method is being called
    /// </summary>
    public class CommonFieldValidatorFunctions
    {
        // Backing fields of delegates
        private static RequiredValidDel _requiredValidDel = null;
        private static StringLengthValidDel _stringLengthValidDel = null;
        private static DateValidDel _dateValidDel = null;
        private static PatternMatchValidDel _patterMatchDel = null;
        private static CompareFieldsValidDel _compareFieldsValidDel = null;


        // PUBLIC READONLY PROPERTIES
        public static RequiredValidDel RequiredValidDel
        {
            get
            {
                if(_requiredValidDel == null)
                {
                    _requiredValidDel = new RequiredValidDel(RequiredFieldValid);
                }

                return _requiredValidDel;
            }
        }

        public static StringLengthValidDel StringLengthValidDel
        {
            get
            {
                if(_stringLengthValidDel == null)
                {
                    _stringLengthValidDel = new StringLengthValidDel(StringFieldLengthValid);
                }

                return _stringLengthValidDel;
            }
        }

        public static DateValidDel DateValidDel
        {
            get
            {
                if(_dateValidDel == null)
                {
                    _dateValidDel = new DateValidDel(DateFieldValid);
                }

                return _dateValidDel;
            }
        }

        public static PatternMatchValidDel PatterMatchDel
        {
            get
            {
                if(_patterMatchDel == null)
                {
                    _patterMatchDel = new PatternMatchValidDel(FieldPatternValid);
                }

                return _patterMatchDel;
            }
        }



        public static CompareFieldsValidDel CompareFieldsValidDel
        {
            get
            {
                if(_compareFieldsValidDel == null)
                {
                    _compareFieldsValidDel = new CompareFieldsValidDel(FieldComparisonValid);
                }

                return _compareFieldsValidDel;
            }
        }
        //End Public ReadOnly Properties




        // Methods that will be valled through the delegates

        /// <summary>
        /// Checks to see is string is empty is it is return false else return true.
        /// </summary>
        /// <param name="fieldVal">Text value to check</param>
        /// <returns>bool</returns>
        private static bool RequiredFieldValid(string fieldVal)
        {
            if (!string.IsNullOrEmpty(fieldVal))
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Gives the mininmum and maximum length of a string
        /// Returns true if string is within the min and max values
        /// Return false if out of range.
        /// </summary>
        /// <param name="fieldVal">The string to check the length of.</param>
        /// <param name="min">The minimum number of characters of the string.</param>
        /// <param name="max">The maximum number of characters of the string.</param>
        /// <returns></returns>
        private static bool StringFieldLengthValid(string fieldVal, int min, int max)
        {
            if (fieldVal.Length >= min && fieldVal.Length <= max)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks whether a string matches a datetime valid input
        /// The (out) parameter ensures that the datetime object being passed in is parsed from the string
        /// if the string is valid the datetime will return to the caller
        /// it will also return true if TryParse if valid
        /// and false if the TryParse fails.
        /// </summary>
        /// <param name="datetTime"></param>
        /// <param name="validDateTime"></param>
        /// <returns></returns>
        private static bool DateFieldValid(string datetTime, out DateTime validDateTime)
        {
            if (DateTime.TryParse(datetTime, out validDateTime))
            {
                return true;
            }
            return false;
        }




        /// <summary>
        /// This uses a regex object to check if the pattern used for the value being checked on matches
        /// If so it returns true otherwise it returns false
        /// </summary>
        /// <remarks>
        /// For more information see https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference
        /// Another resource is https://regexlib.com/?AspxAutoDetectCookieSupport=1
        /// </remarks>
        /// <param name="fieldVal">The string to be checked with the regex pattern</param>
        /// <param name="regularExpression">The pattern to use as the regex expression</param>
        /// <returns>bool</returns>
        private static bool FieldPatternValid(string fieldVal, string regularExpression)
        {
            Regex regex = new Regex(regularExpression);

            if (regex.IsMatch(fieldVal))
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// This method compares two strings to see if the values match
        /// </summary>
        /// <param name="field1">string value 1 in expression</param>
        /// <param name="field2">string value 2 to be compared to string value 1</param>
        /// <returns>Returns true if both values match else false</returns>
        private static bool FieldComparisonValid(string field1, string field2)
        {
            if (field1.Equals(field2))
            {
                return true;
            }

            return false;
        }
    }
}
