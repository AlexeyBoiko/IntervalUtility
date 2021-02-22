using IntervalUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IntervalUtilityUnitTest {
    [TestClass]
    public class OverlapTests {
        void True<T>(Interval<T> a, Interval<T> b) where T : struct, IComparable {
            var intervalUtil = new IntervalUtil();
            var res = intervalUtil.Overlaps(a, b);
            Assert.IsTrue(res, $"Overlaps {a} {b}");
        }

        void False(Interval<int> a, Interval<int> b) {
            var intervalUtil = new IntervalUtil();
            var res = intervalUtil.Overlaps(a, b);
            Assert.IsFalse(res, $"Overlaps {a} {b}");
        }

        //
        // closed interval

        // overlap

        [TestMethod]
        public void Overlaps_Close1() => True(new Interval<int>(3, 6), new Interval<int>(2, null));

        [TestMethod]
        public void Overlaps_Close1_Date() {
            var now = DateTime.Now;
            True(new Interval<DateTime>(now.AddDays(3), now.AddDays(6)), new Interval<DateTime>(now.AddDays(2), null));
        }


        [TestMethod]
        public void Overlaps_Close2() => True(new Interval<int>(3, 6), new Interval<int>(4, null));

        [TestMethod]
        public void Overlaps_Close3() => True(new Interval<int>(3, 6), new Interval<int>(null, null));

        [TestMethod]
        public void Overlaps_Close4() => True(new Interval<int>(3, 6), new Interval<int>(4, 5));

        [TestMethod]
        public void Overlaps_Close5() => True(new Interval<int>(3, 6), new Interval<int>(3, 6));

        [TestMethod]
        public void Overlaps_Close6() => True(new Interval<int>(3, 6), new Interval<int>(5, 7));

        [TestMethod]
        public void Overlaps_Close7() => True(new Interval<int>(3, 6), new Interval<int>(5, 6));

        [TestMethod]
        public void Overlaps_Close8() => True(new Interval<int>(3, 6), new Interval<int>(2, 4));

        [TestMethod]
        public void Overlaps_Close9() => True(new Interval<int>(3, 6), new Interval<int>(3, 4));

        [TestMethod]
        public void Overlaps_Close10() => True(new Interval<int>(3, 6), new Interval<int>(null, 4));

        [TestMethod]
        public void Overlaps_Close11() => True(new Interval<int>(3, 6), new Interval<int>(null, 7));
        [TestMethod]
        public void Overlaps_Close12() => True(new Interval<int>(3, 6), new Interval<int>(null, 6));
        [TestMethod]
        public void Overlaps_Close13() => True(new Interval<int>(3, 6), new Interval<int>(3, null));


        // do not overlap

        [TestMethod]
        public void Overlaps_Close14() => False(new Interval<int>(3, 6), new Interval<int>(null, 3));
        [TestMethod]
        public void Overlaps_Close15() => False(new Interval<int>(3, 6), new Interval<int>(6, null));
        [TestMethod]
        public void Overlaps_Close16() => False(new Interval<int>(3, 6), new Interval<int>(0, 2));
        [TestMethod]
        public void Overlaps_Close17() => False(new Interval<int>(3, 6), new Interval<int>(7, 9));
        [TestMethod]
        public void Overlaps_Close18() => False(new Interval<int>(3, 6), new Interval<int>(1, 3));
        [TestMethod]
        public void Overlaps_Close19() => False(new Interval<int>(3, 6), new Interval<int>(6, 8));


        //
        // intreval [3, null]

        // overlap

        [TestMethod]
        public void Overlaps_OpenRight1() => True(new Interval<int>(3, null), new Interval<int>(3, 6));

        [TestMethod]
        public void Overlaps_OpenRight2() => True(new Interval<int>(3, null), new Interval<int>(2, null));
        [TestMethod]
        public void Overlaps_OpenRight3() => True(new Interval<int>(3, null), new Interval<int>(4, null));
        [TestMethod]
        public void Overlaps_OpenRight4() => True(new Interval<int>(3, null), new Interval<int>(null, null));
        [TestMethod]
        public void Overlaps_OpenRight5() => True(new Interval<int>(3, null), new Interval<int>(4, 5));
        [TestMethod]
        public void Overlaps_OpenRight6() => True(new Interval<int>(3, null), new Interval<int>(3, 6));
        [TestMethod]
        public void Overlaps_OpenRight7() => True(new Interval<int>(3, null), new Interval<int>(2, 4));
        [TestMethod]
        public void Overlaps_OpenRight8() => True(new Interval<int>(3, null), new Interval<int>(null, 4));

        [TestMethod]
        public void Overlaps_OpenRight9() => True(new Interval<int>(3, null), new Interval<int>(3, null));


        // do not overlap

        [TestMethod]
        public void Overlaps_OpenRight10() => False(new Interval<int>(3, null), new Interval<int>(null, 3));
        [TestMethod]
        public void Overlaps_OpenRight11() => False(new Interval<int>(3, null), new Interval<int>(1, 3));
        [TestMethod]
        public void Overlaps_OpenRight12() => False(new Interval<int>(3, null), new Interval<int>(0, 2));
        [TestMethod]
        public void Overlaps_OpenRight13() => False(new Interval<int>(3, null), new Interval<int>(3, 3));
        [TestMethod]
        public void Overlaps_OpenRight14() => False(new Interval<int>(3, null), new Interval<int>(null, 2));


        //
        // interval [null, 6]

        // overlap

        [TestMethod]
        public void Overlaps_OpenLeft1() => True(new Interval<int>(null, 6), new Interval<int>(3, 6));
        [TestMethod]
        public void Overlaps_OpenLeft2() => True(new Interval<int>(null, 6), new Interval<int>(2, null));
        [TestMethod]
        public void Overlaps_OpenLeft3() => True(new Interval<int>(null, 6), new Interval<int>(null, null));
        [TestMethod]
        public void Overlaps_OpenLeft4() => True(new Interval<int>(null, 6), new Interval<int>(4, 5));
        [TestMethod]
        public void Overlaps_OpenLeft5() => True(new Interval<int>(null, 6), new Interval<int>(5, 7));
        [TestMethod]
        public void Overlaps_OpenLeft6() => True(new Interval<int>(null, 6), new Interval<int>(null, 4));
        [TestMethod]
        public void Overlaps_OpenLeft7() => True(new Interval<int>(null, 6), new Interval<int>(null, 7));
        [TestMethod]
        public void Overlaps_OpenLeft8() => True(new Interval<int>(null, 6), new Interval<int>(3, null));
        [TestMethod]
        public void Overlaps_OpenLeft9() => True(new Interval<int>(null, 6), new Interval<int>(null, 6));


        // do not overlap

        [TestMethod]
        public void Overlaps_OpenLeft10() => False(new Interval<int>(null, 6), new Interval<int>(6, null));
        [TestMethod]
        public void Overlaps_OpenLeft11() => False(new Interval<int>(null, 6), new Interval<int>(6, 8));
        [TestMethod]
        public void Overlaps_OpenLeft12() => False(new Interval<int>(null, 6), new Interval<int>(7, 9));
        [TestMethod]
        public void Overlaps_OpenLeft13() => False(new Interval<int>(null, 6), new Interval<int>(6, 6));
        [TestMethod]
        public void Overlaps_OpenLeft14() => False(new Interval<int>(null, 6), new Interval<int>(7, null));


        //
        // interval [null, null]

        // overlap

        [TestMethod]
        public void Overlaps_Open1() => True(new Interval<int>(null, null), new Interval<int>(null, 6));
        [TestMethod]
        public void Overlaps_Open2() => True(new Interval<int>(null, null), new Interval<int>(3, null));
        [TestMethod]
        public void Overlaps_Open3() => True(new Interval<int>(null, null), new Interval<int>(3, 6));
        [TestMethod]
        public void Overlaps_Open4() => True(new Interval<int>(null, null), new Interval<int>(null, null));
    }
}
