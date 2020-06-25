using CSharpSolutions.Base;
using CSharpSolutions.Easy.Soma2ValoresDeUmVetorPraRetornarK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpSolutions.Easy
{
    public class Soma2ValoresEsperandoK : ExerciseBase<Input,int[]>
    {

        public Soma2ValoresEsperandoK()
        {

        }

        public override bool CompareTestCases(int[] expected, int[] founds)
        {
            return expected.SequenceEqual(founds);
        }

        public override int[] Execute(Input input)
        {
            return TwoSum(input.Array, input.Target);
        }

        public override IEnumerable<TestCase<Input, int[]>> GetTestCases()
        {

            yield return new TestCase<Input, int[]>(new Input
            {
                Array = new int[] { 2, 7, 11, 15 },
                Target = 9
            },new int[] { 0 , 1});
        }

        public int[] TwoSum(int[] nums, int target)
        {

            Dictionary<int, int> expected = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var index = 0;
                var valueINeed = target - nums[i];

                if (expected.TryGetValue(nums[i], out index))
                {
                    return new int[] { index, i };
                }
                else
                {
                    expected.TryAdd(valueINeed, i);
                }
            }

            throw new Exception();
        }


        public int[] BruteForce(int[] nums, int target)
        {

            for(int i = 0; i < nums.Length; i++)
            {
                for(int j = i +1; j< nums.Length; j++)
                {
                    if(nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }

            throw new ArgumentException();
        }


        


    }
}
