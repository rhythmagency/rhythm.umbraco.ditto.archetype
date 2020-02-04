namespace Rhythm.Umbraco.Ditto.Archetype.Tests
{

    // Namespaces.
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Tests for DittoArchetypeAttribute.
    /// </summary>
    [TestClass]
    public class DittoArchetypeAttributeTest
    {

        #region Test Methods

        /// <summary>
        /// Ensure nulls can be processed.
        /// </summary>
        [TestMethod]
        public void ProcessNullTest()
        {
            var attr = new DittoArchetypeAttribute();
            var result = attr.ProcessSpecifiedValue(null);
            Assert.IsNull(result);
        }

        /// <summary>
        /// Ensure lists can be processed.
        /// </summary>
        [TestMethod]
        public void ProcessListTest()
        {
            var attr = new DittoArchetypeAttribute();
            var list = new List<object>();
            list.Add("Hello");
            list.Add("World");
            var result = attr.ProcessSpecifiedValue(list);
            Assert.IsTrue(result is List<object>);
        }

        /// <summary>
        /// Ensure empty arrays can be processed.
        /// </summary>
        [TestMethod]
        public void ProcessEmptyArrayTest()
        {
            var attr = new DittoArchetypeAttribute();
            var list = GetArray(new { });
            var result = attr.ProcessSpecifiedValue(list);
            Assert.AreNotEqual(list, result);
        }

        /// <summary>
        /// Ensure empty arrays can be processed.
        /// </summary>
        [TestMethod]
        public void NullIsNotEnumerableTest()
        {
            var item = default(IEnumerable<object>);
            var isEnumerable = item is IEnumerable;
            Assert.IsFalse(isEnumerable);
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Returns an array for type of the specified item.
        /// </summary>
        /// <typeparam name="T">
        /// The type of item.
        /// </typeparam>
        /// <param name="item">
        /// The item with the type to create an array for.
        /// </param>
        /// <returns>
        /// An empty array.
        /// </returns>
        private object GetArray<T>(T item)
        {
            return new T[0];
        }

        #endregion

    }

}