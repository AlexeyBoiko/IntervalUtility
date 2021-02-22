using IntervalUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IntervalUtilityUnitTest {
    [TestClass]
    public class HashCodeTests {

        void HashCodeEq<T1, T2>(Interval<T1> a, Interval<T2> b)
            where T1 : struct, IComparable
            where T2 : struct, IComparable {

            var eq = a.GetHashCode() == b.GetHashCode();
            Assert.IsTrue(eq, $"HashCode {a} eq {b}");
        }

        void HashCodeNotEq<T1, T2>(Interval<T1> a, Interval<T2> b)
            where T1 : struct, IComparable
            where T2 : struct, IComparable {

            var eq = a.GetHashCode() == b.GetHashCode();
            Assert.IsFalse(eq, $"HashCode {a} eq {b}");
        }

        [TestMethod]
        public void HashCodeEq1() => HashCodeEq(new Interval<int>(1, 4), new Interval<int>(1, 4));

        [TestMethod]
        public void HashCodeEq2() => HashCodeEq(new Interval<int>(1, null), new Interval<int>(1, null));

        [TestMethod]
        public void HashCodeEq3() => HashCodeEq(new Interval<int>(null, 4), new Interval<int>(null, 4));

        [TestMethod]
        public void HashCodeEq4() => HashCodeEq(new Interval<int>(null, null), new Interval<int>(null, null));
        [TestMethod]
        public void HashCodeEq4_2() => HashCodeEq(new Interval<int>(null, null), new Interval<DateTime>(null, null));

        [TestMethod]
        public void HashCodeEq5() {
            var now = DateTime.Now;
            HashCodeEq(new Interval<DateTime>(now, now.AddDays(2)), new Interval<DateTime>(now, now.AddDays(2)));
        }

        [TestMethod]
        public void HashCodeEq6() => HashCodeEq(new Interval<int>(1, 4), new Interval<decimal>(1, 4));

        [TestMethod]
        public void HashCodeNotEq1() => HashCodeNotEq(new Interval<int>(1, 4), new Interval<int>(1, 5));
        [TestMethod]
        public void HashCodeNotEq2() => HashCodeNotEq(new Interval<int>(1, 4), new Interval<DateTime>(DateTime.Now, DateTime.Now.AddDays(1)));
    }
}
