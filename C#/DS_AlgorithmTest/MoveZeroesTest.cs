using DS_LeetCode;
using System;
using Xunit;

namespace DS_LeetCodeTest
{
    public class MoveZeroesTest
    {
        [Fact]
        public void TestMoveZeroes()
        {

            int[] nums = new int[] { 1, 1, 0, 3, 12 };
            int[] excepted = new int[] { 1, 1, 3, 12, 0 };

            //act
            MoveZeros mz = new MoveZeros();
            mz.MoveZeroes(nums);

            //
            Assert.Equal(excepted, nums);
        }
    }
}
