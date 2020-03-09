using Xunit;
using LaYumba.Functional.Data.LinkedList;
using static LaYumba.Functional.Data.LinkedList.LinkedList;
using static Functions.Chapter9.ImmutableObjects;


namespace Tests.Chapter9
{
    // Space Complexity in simple terms:
    //  => Number of new objects required
    public class ImmutableObjectsTests
    {
        // Implement functions to work with the singly linked List defined in this chapter:
        // Tip: start by writing the function signature in arrow-notation

        // InsertAt inserts an item at the given index
        // InsertAt: (List<T>, int, T) => List<T>
        // Time Complexity: O(i), i < list.length
        // Spatial Complexity: i list objects
        [Fact]
        public void InsertAt_ShouldTakeAnIndexAndInsertAnItemAtIt()
        {
            //Arrange
            var list = List(1, 2, 4);
            //Act
            var result = Functions.Chapter9.ImmutableObjects.InsertAt(list, i: 2, value: 3);
            //Assert
            Assert.Equal(expected: List(1, 2, 3, 4).ToString(), actual: result.ToString());
        }

        // RemoveAt removes the item at the given index
        // RemoveAt: (List<T>, int) => List<T>
        // Time Complexity: O(i), i < list.length
        // Spatial Complexity: i list objects
        [Fact]
        public void RemoveAt_ShouldTakeAnIndexAndRemoveTheItemAtIt()
        {
            //Arrange
            var list = List(1, 2, 3, 4);
            //Act
            var result = Functions.Chapter9.ImmutableObjects.RemoveAt(list, i: 2);
            //Assert
            Assert.Equal(expected: List(1, 2, 4).ToString(), actual: result.ToString());
        }

        // TakeWhile takes a predicate, and traverses the list yielding all items until it find one that fails the predicate
        // TakeWhile: (List<T>, Func<T,bool>) => List<T>
        // Time Complexity: O(i), i < list.length
        // Spatial Complexity: i list objects
        [Fact]
        public void TakeWhile_ShouldTakeItemsUntilThePredicateGetsInvalid()
        {
            //Arrange
            var list = List(2, 6, 3, 4);
            //Act
            var result = list.TakeWhile(i => i % 2 == 0);
            //Assert
            Assert.Equal(expected: List(2, 6).ToString(), actual: result.ToString());
        }

        // DropWhile works similarly, but excludes all items at the front of the list
        // DropWhile: (List<T>, Func<T,bool>) => List<T>
        // Time Complexity: O(i), i < list.length
        // Spatial Complexity: 0
        [Fact]
        public void DropWhile_ShouldDropItemsUntilThePredicateGetsInvalid()
        {
            //Arrange
            var list = List(2, 6, 3, 4);
            //Act
            var result = list.DropWhile(i => i % 2 == 0);
            //Assert
            Assert.Equal(expected: List(3, 4).ToString(), actual: result.ToString());
        }
    }
}