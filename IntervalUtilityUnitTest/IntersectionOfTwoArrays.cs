using IntervalUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace IntervalUtilityUnitTest {
    [TestClass]
    public class IntersectionOfTwoArrays {

        void True(Interval<int>[] a, Interval<int>[] b, Interval<int>[] result) {
            var intervalUtil = new IntervalUtil();
            var res = intervalUtil.Intersections(a, b).ToArray();
            Assert.IsTrue(res.Eq(result), $"{a.ToStr()} Intersections {b.ToStr()} = {res.ToStr()}");
        }

        [TestMethod]
        public void IntersectionOfTwo1() => True(
            new[] { new Interval<int>(3, 6), new Interval<int>(8, 10), new Interval<int>(11, 15), new Interval<int>(16, null) },
            new[] { new Interval<int>(2, 4), new Interval<int>(6, 7), new Interval<int>(7, 11), new Interval<int>(12, 13), new Interval<int>(15, 16), new Interval<int>(17, 18) },
            new[] { new Interval<int>(3, 4), new Interval<int>(8, 10), new Interval<int>(12, 13), new Interval<int>(17, 18) });
    }
}
