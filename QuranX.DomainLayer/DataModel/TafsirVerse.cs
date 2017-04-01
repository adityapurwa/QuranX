using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuranX.DomainLayer.DataModel
{
	public class TafsirVerse
	{
		[Key, Column(Order = 0)]
		public string TafsirCode { get; private set; }
		[Key, Column(Order = 1)]
		public int Chapter { get; private set; }
		[Key, Column(Order = 2)]
		public int FirstVerse { get; private set; }
		public int LastVerse { get; private set; }
		public string Commentary { get; private set; }

		public TafsirVerse() { }

		public TafsirVerse(string tafsirCode, int chapter, int firstVerse, int lastVerse, string commentary)
		{
			this.TafsirCode = tafsirCode;
			this.Chapter = chapter;
			this.FirstVerse = firstVerse;
			this.LastVerse = lastVerse;
			this.Commentary = commentary;
		}
	}
}
