using Xunit;
using LaYumba.Functional.Data.LinkedList;
using static LaYumba.Functional.Data.LinkedList.LinkedList;


namespace Tests.Chapter9
{
    public class ImmutableObjectsTests
    {
        // Implement functions to work with the singly linked List defined in this chapter:
        // Tip: start by writing the function signature in arrow-notation

        // InsertAt inserts an item at the given index
        // InsertAt: (List<T>, int index, T value) => List<T>
        [Fact]
        public void InsertAt_ShouldTakeAnIndexAndInsertAnItemAtIt()
        {
            //Arrange
            var list = List(1, 2, 4);
            //Act
            var result = Functions.Chapter9.ImmutableObjects.InsertAt(list, index: 2, value: 3);
            //Assert
            Assert.Equal(expected: List(1, 2, 3, 4).ToString(), actual: result.ToString());
        }

        // RemoveAt removes the item at the given index
        // RemoveAt: (List<T>, int index) => List<T>
        [Fact]
        public void RemoveAt_ShouldTakeAnIndexAndRemoveTheItemAtIt()
        {
            //Arrange
            var list = List(1, 2, 3, 4);
            //Act
            var result = Functions.Chapter9.ImmutableObjects.RemoveAt(list, index: 2);
            //Assert
            Assert.Equal(expected: List(1, 2, 4).ToString(), actual: result.ToString());
        }
    }
}