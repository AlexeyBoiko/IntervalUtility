using IntervalUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IntervalUtilityUnitTest {
    [TestClass]
    public class IntersectionTests {
        void True<T>(Interval<T> a, Interval<T> b, Interval<T> intersection) where T : struct, IComparable {
            var intervalUtil = new IntervalUtil();
            var res = intervalUtil.Intersection(a, b);
            Assert.IsTrue(intersection == res, $"{a} intersection {b} = {res}");
        }

        [TestMethod]
        public void Intersection1() => True(new Interval<int>(3, 6), new Interval<int>(2, null), new Interval<int>(3, 6));

        [TestMethod]
        public void Intersection1_Date() {
            var now = DateTime.Now;
            True(new Interval<DateTime>(now.AddDays(3), now.AddDays(6)), new Interval<DateTime>(now.AddDays(2), null),
                new Interval<DateTime>(now.AddDays(3), now.AddDays(6)));
        }

        [TestMethod]
        public void Intersection2() => True(new Interval<int>(3, 6), new Interval<int>(null, 7), new Interval<int>(3, 6));

        [TestMethod]
        public void Intersection3() => True(new Interval<int>(3, 6), new Interval<int>(null, 6), new Interval<int>(3, 6));

        [TestMethod]
        public void Intersection4() => True(new Interval<int>(3, 6), new Interval<int>(4, null), new Interval<int>(4, 6));

        [TestMethod]
        public void Intersection5() => True(new Interval<int>(3, 6), new Interval<int>(null, 5), new Interval<int>(3, 5));
        [TestMethod]
        public void Intersection6() => True(new Interval<int>(3, 6), new Interval<int>(3, 6), new Interval<int>(3, 6));

        [TestMethod]
        public void Intersection6_Date() {
            var now = DateTime.Now;
            True(new Interval<DateTime>(now.AddDays(3), now.AddDays(6)), new Interval<DateTime>(now.AddDays(3), now.AddDays(6)),
                new Interval<DateTime>(now.AddDays(3), now.AddDays(6)));
        }

        [TestMethod]
        public void Intersection7() => True(new Interval<int>(3, 6), new Interval<int>(3, 5), new Interval<int>(3, 5));
        [TestMethod]
        public void Intersection8() => True(new Interval<int>(3, 6), new Interval<int>(4, 6), new Interval<int>(4, 6));
        [TestMethod]
        public void Intersection9() => True(new Interval<int>(3, 6), new Interval<int>(4, 7), new Interval<int>(4, 6));
        [TestMethod]
        public void Intersection10() => True(new Interval<int>(3, 6), new Interval<int>(2, 5), new Interval<int>(3, 5));
        [TestMethod]
        public void Intersection11() => True(new Interval<int>(3, 6), new Interval<int>(2, 7), new Interval<int>(3, 6));
        [TestMethod]
        public void Intersection16() => True(new Interval<int>(3, 6), new Interval<int>(null, null), new Interval<int>(3, 6));
        [TestMethod]
        public void Intersection16_2() => True(new Interval<int>(null, null), new Interval<int>(3, 6), new Interval<int>(3, 6));

        [TestMethod]
        public void Intersection17() => True(new Interval<int>(3, null), new Interval<int>(2, null), new Interval<int>(3, null));
        [TestMethod]
        public void Intersection18() => True(new Interval<int>(3, null), new Interval<int>(3, null), new Interval<int>(3, null));
        [TestMethod]
        public void Intersection19() => True(new Interval<int>(3, null), new Interval<int>(3, 4), new Interval<int>(3, 4));


        // do not intersect

        [TestMethod]
        public void Intersection12() => True(new Interval<int>(3, 6), new Interval<int>(1, 2), null);
        [TestMethod]
        public void Intersection13() => True(new Interval<int>(3, 6), new Interval<int>(7, 8), null);
        [TestMethod]
        public void Intersection14() => True(new Interval<int>(3, 6), new Interval<int>(1, 3), null);
        [TestMethod]
        public void Intersection15() => True(new Interval<int>(3, 6), new Interval<int>(6, 8), null);
    }
}
