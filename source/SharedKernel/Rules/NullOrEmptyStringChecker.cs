using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Rules
{
    public class NullOrEmptyStringChecker : IBusinessRule
    {
        private readonly string _variableName;
        private readonly string _input;
        private readonly string _message;


        public NullOrEmptyStringChecker(string variableName,
            string input
            )
        {
            _variableName = variableName;
            _input = input;
            _message = String.Concat("The value ", input, "is null or empty ",
                _variableName, ".");
        }

        public NullOrEmptyStringChecker(string variableName,
            string input,
            string regexPattern,
            string message
        )
        {
            _variableName = variableName;
            _input = input;
            _message = message;
        }

        public bool IsBroken() => string.IsNullOrEmpty(_input);

        public string Message => _message;
    }
}
