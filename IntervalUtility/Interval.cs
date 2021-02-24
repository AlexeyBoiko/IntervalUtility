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

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((Interval<T>)obj);
        }

        public bool Equals(Interval<T> other) {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Nullable.Equals(Start, other.Start) && Nullable.Equals(End, other.End);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Start, End);
        }

        public static bool operator ==(Interval<T> a, Interval<T> b) {
            return Equals(a, b);
        }

        public static bool operator !=(Interval<T> a, Interval<T> b) {
            return !Equals(a, b);
        }
    }
}
