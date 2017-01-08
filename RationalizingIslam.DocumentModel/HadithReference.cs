using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RationalizingIslam.DocumentModel
{
    public class HadithReference :
        IComparable,
        IComparable<HadithReference>,
        IEnumerable<string>
    {
        public readonly string Code;
        public readonly string[] Values;
        public readonly string Suffix;

        public HadithReference(string code, IEnumerable<string> values, string suffix)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentNullException(nameof(code));
            if (values == null || values.Count() == 0 || values.Any(x => string.IsNullOrWhiteSpace(x)))
                throw new ArgumentException(nameof(values), "Must be an array of non-empty values");

            this.Code = code;
            this.Values = values.ToArray();
            this.Suffix = suffix;
        }

        public int Length
        {
            get { return Values.Length; }
        }

        public string this[int index]
        {
            get { return Values[index]; }
        }

        public string GetCaption(IEnumerable<string> referencePartNames)
        {
            var captionParts = referencePartNames.ToArray();
            int index = -1;
            foreach (string referencePartName in referencePartNames)
            {
                index++;
                captionParts[index] = string.Format(
                        "{0} {1}",
                        referencePartName,
                        Values[index]
                    );
            }
            return string.Join(", ", captionParts) + Suffix;
        }

        public int CompareTo(HadithReference other)
        {
            return (this as IComparable).CompareTo(other);
        }

        public override string ToString()
        {
            return string.Join(
                    separator: ".",
                    values: (IEnumerable<string>)Values
                ) + Suffix;
        }

        int IComparable.CompareTo(object obj)
        {
            var other = (HadithReference)obj;

            int codeCompare = string.Compare(Code, other.Code, true);
            if (codeCompare != 0)
                return codeCompare;

            int length = this.Length < other.Length
                ? this.Length
                : other.Length;

            for (int index = 0; index < length; index++)
            {
                string left = this[index];
                string right = other[index];
                int leftInt;
                int rightInt;
                if (int.TryParse(left, out leftInt) && int.TryParse(right, out rightInt))
                {
                    if (leftInt != rightInt)
                        return leftInt.CompareTo(rightInt);
                }
                else
                {
                    left = left.PadRight(right.Length, '0');
                    right = right.PadRight(left.Length, '0');
                    if (left != right)
                        return left.CompareTo(right);
                }
            }
            if (this.Length < other.Length)
                return -1;
            if (this.Length > other.Length)
                return 1;
            return string.Compare(this.Suffix, other.Suffix, true);
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            foreach (string value in Values)
                yield return value;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (this as IEnumerable<string>).GetEnumerator();
        }

        public static bool operator ==(HadithReference first, HadithReference second)
        {
            if (Object.ReferenceEquals(first, null) && Object.ReferenceEquals(second, null))
                return true;
            if (Object.ReferenceEquals(first, null) || Object.ReferenceEquals(second, null))
                return false;
            return first.CompareTo(second) == 0;
        }

        public static bool operator !=(HadithReference first, HadithReference second)
        {
            return !(first == second);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is HadithReference))
                return false;
            return ((HadithReference)obj).CompareTo(this) == 0;
        }

        public override int GetHashCode()
        {
            return (Code + ToString()).GetHashCode();
        }


    }
}
