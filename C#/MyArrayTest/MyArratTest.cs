using DS_MyArray;
using System;
using Xunit;

namespace DS_MyArrayTest
{
    public class MyArrayTest
    {
        [Fact]
        public void TestAdd()
        {
            MyArray2<int> array2 = new MyArray2<int>();
            int[] excepted = new int[] { 2, 1, 3, 4, 0, 0, 0, 0, 0, 0 };

            //Act
            array2.AddFirst(1);
            array2.AddFirst(2);
            array2.AddLast(3);
            array2.AddLast(4);

            //Assert
            Assert.Equal(excepted, array2.GetData());
            Assert.Equal(4, array2.GetSize());
        }

        [Fact]
        public void TestRemove()
        {
            MyArray2<int> array2 = new MyArray2<int>(new int[] { 2, 1, 3, 4, 5, 0, 0, 0, 0, 0 });
            int[] excepted = new int[] { 4, 0 };

            //Act
            array2.RemoveFirst();
            array2.RemoveFirst();
            array2.RemoveFirst();
            array2.RemoveLast();

            //Assert
            Assert.Equal(excepted, array2.GetData());
            Assert.Equal(1, array2.GetSize());
        }

        [Fact]
        public void TestSet()
        {
            MyArray2<int> array2 = new MyArray2<int>(new int[] { 2, 1, 3, 4, 5, 0, 0, 0, 0, 0 });
            int[] excepted = new int[] { 8, 8, 3, 8, 8, 0, 0, 0, 0, 0 };

            //Act
            array2.Set(1, 8);
            array2.Set(3, 8);
            array2.Set(0, 8);
            array2.Set(4, 8);

            //Assert
            Assert.Equal(excepted, array2.GetData());
            Assert.Equal(5, array2.GetSize());
        }
    }
}
