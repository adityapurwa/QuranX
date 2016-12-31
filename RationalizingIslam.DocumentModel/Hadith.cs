using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RationalizingIslam.DocumentModel
{
	public class Hadith
	{
		public readonly MultiPartReference Reference;
		public readonly ReadOnlyCollection<KeyValuePair<string, string>> OtherReferences;
		public readonly ReadOnlyCollection<string> ArabicText;
		public readonly ReadOnlyCollection<string> EnglishText;
		public readonly VerseRangeReference[] VerseReferences;
        public readonly ReadOnlyCollection<HadithReference> References;

		public Hadith(
			MultiPartReference reference,
			IEnumerable<KeyValuePair<string, string>> otherReferences,
			IEnumerable<string> arabicText,
			IEnumerable<string> englishText,
			IEnumerable<VerseRangeReference> verseReferences,
            IEnumerable<HadithReference> references)
		{
			this.Reference = reference;
            this.OtherReferences = new ReadOnlyCollection<KeyValuePair<string, string>>(otherReferences.ToArray());
            this.ArabicText = new ReadOnlyCollection<string>(arabicText.ToArray());
            this.EnglishText = new ReadOnlyCollection<string>(englishText.ToArray());
			this.VerseReferences = verseReferences.Distinct().OrderBy(x => x).ToArray();
            this.References = new ReadOnlyCollection<HadithReference>(references.OrderBy(x => x).ToArray());
		}
	}
}
