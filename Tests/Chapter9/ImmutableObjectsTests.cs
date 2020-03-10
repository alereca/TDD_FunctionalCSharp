using Xunit;
using LaYumba.Functional.Data.LinkedList;
using static LaYumba.Functional.Data.LinkedList.LinkedList;
using static Functions.Chapter9.ImmutableObjects;
using LaYumba.Functional.Data.BinaryTree;
using static LaYumba.Functional.Data.BinaryTree.Tree;


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
        // TakeWhile: (List<T>, T => bool) => List<T>
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
        // DropWhile: (List<T>, T => bool) => List<T>
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

        // TakeWhile and DropWhile are useful when working with a list that is sorted 
        // and you’d like to get all items greater/smaller than some value; write implementations 
        // that take an IEnumerable rather than a List

        // Note: yield return, collects elements but in a lazy manner 
        // since it will only retrieve the data when it's requested by some client code
        // https://stackoverflow.com/questions/2652656/method-not-called-when-using-yield-return
        [Fact]
        public void TakeWhile_WithIEnumerable_ShouldTakeItemsUntilThePredicateGetsInvalid()
        {
            //Arrange
            var list = new System.Collections.Generic.List<int> { 1, 2, 3, 4, 5 };
            //Act
            var result = list.TakeWhile(i => i < 4);
            //Assert
            Assert.Equal(
                expected: new System.Collections.Generic.List<int> { 1, 2, 3 },
                actual: result);
        }

        [Fact]
        public void DropWhile_WithIEnumerable_ShouldDropItemsUntilThePredicateGetsInvalid()
        {
            //Arrange
            var list = new System.Collections.Generic.List<int> { 1, 2, 3, 4, 5 };
            //Act
            var result = list.DropWhile(i => i < 4);
            //Assert
            Assert.Equal(
                expected: new System.Collections.Generic.List<int> { 4, 5 },
                actual: result);
        }


        // Is it possible to define `Bind` for the binary tree implementation shown in this
        // chapter? If so, implement `Bind`, else explain why it’s not possible (hint: start by writing
        // the signature; then sketch binary tree and how you could apply a tree-returning function to
        // each value in the tree).
        // Bind: (Tree<T>, T => Tree<R>) => Tree<R>
        [Fact]
        public void Bind_OnImmutableTree_ShouldTakeATreeReturningFunctionAndApplyItOnAllOfItsElements()
        {
            //Arrange
            var tree = Branch(Leaf(1), Branch(Leaf(2), Leaf(3)));
            //Act
            var result = tree.Bind(t => Branch(Leaf(t), Leaf(2)));
            //Assert
            Assert.Equal(
                expected: Branch(Branch(Leaf(1), Leaf(2)), Branch(Branch(Leaf(2), Leaf(2)), Branch(Leaf(3), Leaf(2)))),
                actual: result
            );
        }
    }
}