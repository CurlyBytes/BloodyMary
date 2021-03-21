using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Rules
{
    public class OutOfRangeChecker : IBusinessRule
    {
        private readonly string _variableName;
        private readonly int _input;
        private readonly int _from;
        private readonly int _to;
        private readonly string _message;
        
        public OutOfRangeChecker(string variableName,
            int input,
            int from,
            int to
            )
        {
            _input = input;
            _from = from;
            _to = to;
            _message = String.Concat("The value of", variableName,
                " was ", _input ,  "should between ",
                 from, " and ", to,
                variableName, ".");
        }

        public OutOfRangeChecker(string variableName,
            int input,
            int from,
            int to,
            string message
        )
        {
            _variableName = variableName;
            _input = input;
            _from = from;
            _to = to;
            _message = message;
        }

        public bool IsBroken() =>  _input >= _from && _input <= _to;

        public string Message => _message;
    }
}
