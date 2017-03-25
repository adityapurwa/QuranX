using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuranX.DomainLayer.DataModel
{
	public class Chapter
	{
		[Key]
		public int Number { get; private set; }
		public string ArabicName { get; private set; }
		public string EnglishName { get; private set; }
		public int NumberOfVerses { get; private set; }

		public Chapter() { }

		public Chapter(int number, string arabicName, string englishName, int numberOfVerses)
		{
			this.Number = number;
			this.ArabicName = arabicName;
			this.EnglishName = englishName;
			this.NumberOfVerses = numberOfVerses;
		}
	}
}
