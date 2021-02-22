using IntervalUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntervalUtilityUnitTest {
    [TestClass]
    public class InRangeTests {
        void True(Interval<int> a, int val, bool includeEnds = false) {
            var intervalUtil = new IntervalUtil();
            var res = intervalUtil.InRange(a, val, includeEnds);
            Assert.IsTrue(res, $"InRange {a} {val}");
        }

        void False(Interval<int> a, int val, bool includeEnds = false) {
            var intervalUtil = new IntervalUtil();
            var res = intervalUtil.InRange(a, val, includeEnds);
            Assert.IsTrue(!res, $"InRange {a} {val}");
        }

        [TestMethod]
        public void InRange1() => True(new Interval<int>(3, 6), 4);
        [TestMethod]
        public void InRange2() => True(new Interval<int>(3, 6), 4, true);
        [TestMethod]
        public void InRange3() => True(new Interval<int>(3, 6), 3, true);
        [TestMethod]
        public void InRange4() => True(new Interval<int>(3, 6), 6, true);
        [TestMethod]
        public void InRange5() => True(new Interval<int>(3, null), 6);
        [TestMethod]
        public void InRange6() => True(new Interval<int>(null, 6), 3);
        [TestMethod]
        public void InRange7() => True(new Interval<int>(null, null), 3);
        [TestMethod]
        public void InRange8() => True(new Interval<int>(null, null), 3, true);
        [TestMethod]
        public void InRange16() => True(new Interval<int>(3, null), 3, true);
        [TestMethod]
        public void InRange17() => True(new Interval<int>(null, 6), 6, true);

        [TestMethod]
        public void InRange9() => False(new Interval<int>(3, 6), 3);
        [TestMethod]
        public void InRange10() => False(new Interval<int>(3, 6), 6);
        [TestMethod]
        public void InRange11() => False(new Interval<int>(3, 6), 7);
        [TestMethod]
        public void InRange12() => False(new Interval<int>(3, 6), 2);

        [TestMethod]
        public void InRange13() => False(new Interval<int>(3, null), 2);
        [TestMethod]
        public void InRange13_2() => False(new Interval<int>(3, null), 3);
        [TestMethod]
        public void InRange14() => False(new Interval<int>(null, 6), 7);
        [TestMethod]
        public void InRange15() => False(new Interval<int>(null, 6), 6);
    }
}
