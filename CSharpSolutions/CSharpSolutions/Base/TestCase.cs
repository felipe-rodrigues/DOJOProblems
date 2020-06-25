using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSolutions.Base
{
    public class TestCase<TInput,TResultExpected>
    {
        public TInput Input { get; set; }
        public TResultExpected ResultExpected { get; set; }

        public TestCase(TInput input, TResultExpected expected)
        {
            Input = input;
            ResultExpected = expected;
        }
    }
}
