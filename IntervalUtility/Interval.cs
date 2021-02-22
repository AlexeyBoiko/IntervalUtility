using System;
using System.Diagnostics;

namespace IntervalUtility {
    [DebuggerDisplay("[{Start},{End}]")]
    public class Interval<T> : IEquatable<Interval<T>> where T : struct, IComparable {
        public T? Start { get; }
        public T? End { get; }

        public Interval(T? start, T? end) {
            if (start.HasValue && end.HasValue && start.Value.CompareTo(end.Value) > 0)
                throw new ArgumentException($"{nameof(start)} must be <= {nameof(end)}");

            Start = start;
            End = end;
        }

        public override string ToString() {
            return $"[{Start},{End}]";
        }

        public override bool Equals(object other) {
            return Equals(other as Interval<T>);
        }

        public bool Equals(Interval<T> other) {
            // If parameter is null, return false.
            if (other is null)
                return false;

            // Optimization for a common success case.
            if (ReferenceEquals(this, other))
                return true;

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != other.GetType())
                return false;

            return IsEq(Start, other.Start) && IsEq(End, other.End);
        }

        static bool IsEq(T? a, T? b) {
            if (!a.HasValue && !b.HasValue)
                return true;

            if ((a.HasValue && !b.HasValue) || (!a.HasValue && b.HasValue))
                return false;

            return a.Value.CompareTo(b.Value) == 0;
        }

        public override int GetHashCode() {
            return Tuple.Create(Start, End).GetHashCode();
        }

        public static bool operator ==(Interval<T> a, Interval<T> b) {
            // Check for null on left side.
            if (a is null) {
                if (b is null) {
                    // null == null = true.
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return a.Equals(b);
        }

        public static bool operator !=(Interval<T> a, Interval<T> b) {
            return !(a == b);
        }
    }
}
