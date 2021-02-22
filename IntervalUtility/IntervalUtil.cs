using System;
using System.Collections.Generic;
using System.Linq;

namespace IntervalUtility {
    public class IntervalUtil {
        /// <summary>
        /// Find intersections of arrays of intervals
        /// [[2,5], [7,9]] & [[0,3], [4,6], [7,10]] & [[1,4], [5,8]] -> [[2,3], [7,8]]
        /// </summary>
        public IEnumerable<Interval<T>> Intersections<T>(IEnumerable<IEnumerable<Interval<T>>> intervalCollection)
            where T : struct, IComparable {
            IEnumerable<Interval<T>> res = null;
            foreach (var interval in intervalCollection)
                res = Intersections(res, interval);

            return res;
        }

        /// <summary>
        /// Find intersections of 2 arrays of intervals
        /// [[2,5], [7,9]] & [[0,3], [4,6], [7,10]] -> [[2,3], [4,5], [7,9]]
        /// </summary>
        public IEnumerable<Interval<T>> Intersections<T>(IEnumerable<Interval<T>> intervals1, IEnumerable<Interval<T>> intervals2) where T : struct, IComparable {
            if (intervals1 == null || intervals2 == null) {
                var notNullInteral = intervals1 ?? intervals2;
                if (notNullInteral == null)
                    yield break;

                foreach (var a in notNullInteral)
                    yield return a;

                yield break;
            }

            foreach (var a in intervals1) {
                foreach (var b in intervals2) {
                    var intersection = Intersection(a, b);
                    if (intersection != null)
                        yield return intersection;
                }
            }
        }

        /// <summary>
        /// Find intersections
        /// [0, 3] & [2, 4] -> [2, 3]
        /// [-1, 34] & [0, 4] -> [0, 4]
        /// [0, 3] & [4, 4] -> null
        /// </summary>
        public Interval<T> Intersection<T>(Interval<T> a, Interval<T> b) where T : struct, IComparable {
            if (!Overlaps(a, b))
                return null;

            return new Interval<T>(
                Max(a.Start, b.Start),
                MinNullIsBigger(a.End, b.End));
        }

        /// <summary>
        /// Exclude from intervals intervals1 intervals intervals2
        /// [[1,5], [7,10]] - [[0,2], [3,5], [8,9]] -> [[2,3], [4,5], [7,8], [9,10]]
        /// </summary>
        public IEnumerable<Interval<T>> Exclude<T>(IEnumerable<Interval<T>> intervals1, IEnumerable<Interval<T>> intervals2) where T : struct, IComparable {
            if (intervals1 == null)
                return new Interval<T>[] { };

            if (intervals2 == null)
                return intervals1;

            return intervals1.SelectMany(a => Exclude(a, intervals2));
        }

        /// <summary>
        /// Exclude from interval "a" array of intervals
        /// [1,6] - [[0,2], [3,5]] -> [[2,3], [5,6]]
        /// </summary>
        public IEnumerable<Interval<T>> Exclude<T>(Interval<T> a, IEnumerable<Interval<T>> intervals) where T : struct, IComparable {
            if (intervals == null)
                return new[] { a };

            return intervals
                .Aggregate(new[] { a } as IEnumerable<Interval<T>>,
                    (res, b) => res.SelectMany(r => Exclude(r, b)));
        }

        /// <summary>
        /// Exclude from interval "a" interval "b"
        /// [1,5] - [0,2] -> [2,5]
        /// [1,5] - [3,4] -> [[1,3], [4,5]]
        /// </summary>
        public IEnumerable<Interval<T>> Exclude<T>(Interval<T> a, Interval<T> b) where T : struct, IComparable {
            if (!Overlaps(a, b))
                return new[] { a };

            bool aStartInB = (a.Start.HasValue && InRange(b, a.Start.Value, true))
                || (!a.Start.HasValue && !b.Start.HasValue);

            bool aEndInB = (a.End.HasValue && InRange(b, a.End.Value, true))
                || (!a.End.HasValue && !b.End.HasValue);

            // start and end of "a" in "b"
            if (aStartInB && aEndInB)
                return new Interval<T>[] { };

            if (aStartInB)
                return new[] { new Interval<T>(b.End, a.End) };

            if (aEndInB)
                return new[] { new Interval<T>(a.Start, b.Start) };

            // whole "b" into "a"
            return new[] { new Interval<T>(a.Start, b.Start), new Interval<T>(b.End, a.End) };
        }

        /// <summary>
        /// Whether intervals intersect or not
        /// </summary>
        public bool Overlaps<T>(Interval<T> a, Interval<T> b) where T : struct, IComparable {
            if (a.Start.Equals(b.Start) && a.End.Equals(b.End))
                return true;

            if (a.Start.HasValue && InRange(b, a.Start.Value))
                return true;

            if (a.End.HasValue && InRange(b, a.End.Value))
                return true;

            if (b.Start.HasValue && InRange(a, b.Start.Value))
                return true;

            if (b.End.HasValue && InRange(a, b.End.Value))
                return true;

            return false;
        }

        /// <summary>
        /// Whether the value is included in an interval (by default, ends are not included)
        /// </summary>
        public bool InRange<T>(Interval<T> interval, T val, bool includeEnds = false) where T : struct, IComparable {
            if (!includeEnds)
                return (!interval.Start.HasValue || val.CompareTo(interval.Start.Value) > 0) &&
                        (!interval.End.HasValue || interval.End.Value.CompareTo(val) > 0);

            return (!interval.Start.HasValue || val.CompareTo(interval.Start.Value) >= 0) &&
                        (!interval.End.HasValue || interval.End.Value.CompareTo(val) >= 0);
        }

        /// <summary>
        /// Find less,
        /// null is considered large
        /// </summary>
        static T? MinNullIsBigger<T>(T? a, T? b) where T : struct, IComparable {
            if (!a.HasValue && !b.HasValue)
                return null;

            if (!a.HasValue && b.HasValue)
                return b;

            if (a.HasValue && !b.HasValue)
                return a;

            return new[] { a, b }.Min();
        }

        /// <summary>
        /// Find more
        /// </summary>
        static T? Max<T>(T? a, T? b) where T : struct, IComparable {
            return new[] { a, b }.Max();
        }
    }
}
