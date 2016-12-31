using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RationalizingIslam.DocumentModel
{
    public class HadithReferenceDefinition :
        IComparable,
        IComparable<HadithReferenceDefinition>
    {
        public bool IsPrimary { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public ReadOnlyCollection<string> PartNames { get; private set; }

        public HadithReferenceDefinition(bool isPrimary, string code, string name, IEnumerable<string> partNames)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentNullException(nameof(code));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if ((partNames ?? new string[0]).Count() == 0)
                throw new ArgumentException(nameof(partNames), "No part names");
            if (partNames.Any(x => string.IsNullOrWhiteSpace(x)))
                throw new ArgumentException(nameof(partNames), "One or more part names are empty");

            this.IsPrimary = isPrimary;
            this.Code = code;
            this.Name = name;
            this.PartNames = new ReadOnlyCollection<string>(partNames.ToArray());
        }

        public static bool operator==(HadithReferenceDefinition first, HadithReferenceDefinition second)
        {
            if (first == null && second == null)
                return true;
            if (first == null || second == null)
                return false;
            return first.Equals(second);
        }

        public static bool operator!=(HadithReferenceDefinition first, HadithReferenceDefinition second)
        {
            return !(first == second);
        }

        public override bool Equals(object obj)
        {
            var other = obj as HadithReferenceDefinition;
            if (other == null)
                return false;
            return ((HadithReferenceDefinition)obj).Code == other.Code;
        }

        public override int GetHashCode()
        {
            return (Code ?? "").GetHashCode();
        }

        int IComparable.CompareTo(object obj)
        {
            return (this as IComparable<HadithReferenceDefinition>).CompareTo((HadithReferenceDefinition)obj);
        }

        int IComparable<HadithReferenceDefinition>.CompareTo(HadithReferenceDefinition other)
        {
            return Code.CompareTo(other.Code);
        }
    }
}
