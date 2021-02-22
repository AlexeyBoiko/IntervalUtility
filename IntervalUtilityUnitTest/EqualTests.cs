using IntervalUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IntervalUtilityUnitTest {
    [TestClass]
    public class EqualTests {
        void Eq<T1, T2>(Interval<T1> a, Interval<T2> b)
            where T1 : struct, IComparable
            where T2 : struct, IComparable {
            Assert.IsTrue(a.Equals(b), $"{a} eq {b}");
        }

        void EqSign<T>(Interval<T> a, Interval<T> b) where T : struct, IComparable {
            Assert.IsTrue(a == b, $"{a} == {b}");
        }

        void NotEq<T1, T2>(Interval<T1> a, Interval<T2> b)
            where T1 : struct, IComparable
            where T2 : struct, IComparable {
            Assert.IsFalse(a.Equals(b), $"{a} eq {b}");
        }

        void NotEqSign<T>(Interval<T> a, Interval<T> b) where T : struct, IComparable {
            Assert.IsTrue(a != b, $"{a} != {b}");
        }

        [TestMethod]
        public void Eq1() => Eq(new Interval<int>(1, 4), new Interval<int>(1, 4));
        [TestMethod]
        public void EqSign1() => EqSign(new Interval<int>(1, 4), new Interval<int>(1, 4));

        [TestMethod]
        public void Eq2() => Eq(new Interval<int>(1, null), new Interval<int>(1, null));
        [TestMethod]
        public void EqSign2() => EqSign(new Interval<int>(1, null), new Interval<int>(1, null));

        [TestMethod]
        public void Eq3() => Eq(new Interval<int>(null, 4), new Interval<int>(null, 4));
        [TestMethod]
        public void EqSign3() => EqSign(new Interval<int>(null, 4), new Interval<int>(null, 4));

        [TestMethod]
        public void Eq4() => Eq(new Interval<int>(null, null), new Interval<int>(null, null));
        [TestMethod]
        public void EqSign4() => EqSign(new Interval<int>(null, null), new Interval<int>(null, null));

        [TestMethod]
        public void Eq5() => Eq(new Interval<int>(null, null), new Interval<int>(null, null));
        [TestMethod]
        public void EqSign5() => EqSign(new Interval<int>(null, null), new Interval<int>(null, null));

        [TestMethod]
        public void Eq6Sign() {
            Interval<int> a = null;
            Interval<int> b = null;
            Assert.IsTrue(a == b, $"{a} eq {b}");
        }

        [TestMethod]
        public void Eq7() {
            var now = DateTime.Now;
            Interval<DateTime> a = new Interval<DateTime>(now.AddDays(-1), now.AddDays(2));
            Interval<DateTime> b = new Interval<DateTime>(now.AddDays(-1), now.AddDays(2));
            Assert.IsTrue(a.Equals(b), $"{a} eq {b}");
        }

        [TestMethod]
        public void Eq7Sign() {
            var now = DateTime.Now;
            Interval<DateTime> a = new Interval<DateTime>(now.AddDays(-1), now.AddDays(2));
            Interval<DateTime> b = new Interval<DateTime>(now.AddDays(-1), now.AddDays(2));
            Assert.IsTrue(a == b, $"{a} eq {b}");
        }



        [TestMethod]
        public void NotEq1() => NotEq(new Interval<int>(null, null), new Interval<DateTime>(null, null));

        [TestMethod]
        public void NotEq2() => NotEq(new Interval<int>(1, null), new Interval<int>(null, null));

        [TestMethod]
        public void NotEqSign2() => NotEqSign(new Interval<int>(1, null), new Interval<int>(null, null));

        [TestMethod]
        public void NotEq3() => NotEq(new Interval<int>(null, 2), new Interval<int>(2, null));
        [TestMethod]
        public void NotEqSign3() => NotEqSign(new Interval<int>(null, 2), new Interval<int>(2, null));

        [TestMethod]
        public void NotEq4() => NotEq(new Interval<int>(1, 2), new Interval<int>(3, 4));
        [TestMethod]
        public void NotEqSign4() => NotEqSign(new Interval<int>(1, 2), new Interval<int>(3, 4));

        [TestMethod]
        public void NotEq5() {
            Interval<int> a = new Interval<int>(2, 4);
            Interval<int> b = null;
            Assert.IsFalse(a.Equals(b), $"{a} eq {b}");
        }

        [TestMethod]
        public void NotEqSign5() {
            Interval<int> a = new Interval<int>(2, 4);
            Interval<int> b = null;
            Assert.IsTrue(a != b, $"{a} eq {b}");
        }

        [TestMethod]
        public void NotEqSign6() {
            Interval<int> a = new Interval<int>(2, 4);
            Interval<DateTime> b = null;
            Assert.IsFalse(a.Equals(b), $"{a} eq {b}");
        }
    }
}
