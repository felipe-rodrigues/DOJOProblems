using CSharpSolutions.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSolutions.Easy.ReverteNumero
{
    public class ReverteNumero : ExerciseBase<int, int>
    {
        public override bool CompareTestCases(int expected, int founds)
        {
            return expected == founds;
        }

        public override int Execute(int input)
        {
            return Solution2(input);
        }

        public override IEnumerable<TestCase<int, int>> GetTestCases()
        {
            yield return new TestCase<int, int>(123, 321);
            yield return new TestCase<int, int>(-123, -321);
            yield return new TestCase<int, int>(1534236469, 0);
        }


        private int Solution1(int x)
        {
            var res = 0;

            while(x != 0)
            {
                var lastDigit = x % 10;
                x /= 10;
                res = res * 10 + lastDigit;
            }

            return res;
        }

        private int Solution2(int x)
        {
            var res = 0;

            while(x != 0)
            {
                var lastDigit = x % 10;
                x /= 10;
                if (res > int.MaxValue / 10 || res == int.MaxValue / 10 && lastDigit > 7) return 0;
                if (res < int.MinValue / 10 || res == int.MinValue / 10 && lastDigit < -8) return 0;

                res = res * 10 + lastDigit;
            }

            return res;
        }
    }
}
