using IntervalUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntervalUtilityUnitTest {
    [TestClass]
    public class ExcludeTests {

        void True(Interval<int> a, Interval<int> b, Interval<int>[] result) {
            var intervalUtil = new IntervalUtil();
            var res = intervalUtil.Exclude(a, b);
            Assert.IsTrue(res.Eq(result), $"{a} exclude {b} = {res.ToStr()}");
        }

        [TestMethod]
        public void Exclude1() => True(new Interval<int>(3, 6), new Interval<int>(1, 4), new[] { new Interval<int>(4, 6) });

        [TestMethod]
        public void Exclude2() => True(new Interval<int>(3, 6), new Interval<int>(5, 7), new[] { new Interval<int>(3, 5) });
        [TestMethod]
        public void Exclude3() => True(new Interval<int>(3, 6), new Interval<int>(null, 4), new[] { new Interval<int>(4, 6) });
        [TestMethod]
        public void Exclude4() => True(new Interval<int>(3, 6), new Interval<int>(5, null), new[] { new Interval<int>(3, 5) });
        [TestMethod]
        public void Exclude5() => True(new Interval<int>(3, 6), new Interval<int>(3, null), new Interval<int>[] { });
        [TestMethod]
        public void Exclude6() => True(new Interval<int>(3, 6), new Interval<int>(null, 6), new Interval<int>[] { });
        [TestMethod]
        public void Exclude7() => True(new Interval<int>(3, 6), new Interval<int>(null, null), new Interval<int>[] { });
        [TestMethod]
        public void Exclude8() => True(new Interval<int>(3, 6), new Interval<int>(1, 3), new[] { new Interval<int>(3, 6) });
        [TestMethod]
        public void Exclude9() => True(new Interval<int>(3, 6), new Interval<int>(6, 8), new[] { new Interval<int>(3, 6) });

        [TestMethod]
        public void Exclude10() => True(new Interval<int>(3, 6), new Interval<int>(4, 5), new[] { new Interval<int>(3, 4), new Interval<int>(5, 6) });
        [TestMethod]
        public void Exclude11() => True(new Interval<int>(3, null), new Interval<int>(4, 5), new[] { new Interval<int>(3, 4), new Interval<int>(5, null) });
        [TestMethod]
        public void Exclude12() => True(new Interval<int>(3, null), new Interval<int>(4, null), new[] { new Interval<int>(3, 4) });
        [TestMethod]
        public void Exclude13() => True(new Interval<int>(3, null), new Interval<int>(3, null), new Interval<int>[] { });
        [TestMethod]
        public void Exclude14() => True(new Interval<int>(3, null), new Interval<int>(2, null), new Interval<int>[] { });

        [TestMethod]
        public void Exclude15() => True(new Interval<int>(3, null), new Interval<int>(null, null), new Interval<int>[] { });
        [TestMethod]
        public void Exclude16() => True(new Interval<int>(null, null), new Interval<int>(null, null), new Interval<int>[] { });
        [TestMethod]
        public void Exclude17() => True(new Interval<int>(null, null), new Interval<int>(1, 4), new Interval<int>[] { new Interval<int>(null, 1), new Interval<int>(4, null) });
        [TestMethod]
        public void Exclude18() => True(new Interval<int>(null, null), new Interval<int>(null, 3), new Interval<int>[] { new Interval<int>(3, null) });
        [TestMethod]
        public void Exclude19() => True(new Interval<int>(null, 6), new Interval<int>(null, 4), new Interval<int>[] { new Interval<int>(4, 6) });
    }
}
