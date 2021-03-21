using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SharedKernel.Rules
{
    public class InvalidFormatChecker : IBusinessRule
    {
        private readonly string _variableName;
        private readonly string _input;
        private readonly string _regexPattern;
        private readonly string _message;


        public InvalidFormatChecker(string variableName, 
            string input, 
            string regexPattern
            )
        {
            _variableName = variableName;
            _input = input;
            _regexPattern = regexPattern;
            _message = String.Concat("The value ", input, "is invalid ",
                _variableName , " did not match with a regex pattern of " ,
                regexPattern,".");
        }

        public InvalidFormatChecker(string variableName,
            string input,
            string regexPattern,
            string message
        )
        {
            _variableName = variableName;
            _input = input;
            _regexPattern = regexPattern;
            _message = message;
        }

        public bool IsBroken() => Regex.IsMatch(_input, _regexPattern);

        public string Message => _message;
    }
}
