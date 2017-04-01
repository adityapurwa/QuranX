using System.Data.Entity.Migrations;
using QuranX.DomainLayer.ServicesImpl;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using QuranX.DomainLayer.DataModel;
using System.Data.Entity.Migrations.Infrastructure;

namespace QuranX.DomainLayer.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<QuranX.DomainLayer.ServicesImpl.ObjectSpace>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(QuranX.DomainLayer.ServicesImpl.ObjectSpace context)
		{
			CreateTafsirVerses(context);
		}

		void CreateTafsirVerses(ObjectSpace context)
		{
			var tafsirContents = new List<string>
			{
				Properties.Resources.Tafsir_Abbas,
				Properties.Resources.Tafsir_Asrar,
				Properties.Resources.Tafsir_Jalal,
				Properties.Resources.Tafsir_Kashani,
				Properties.Resources.Tafsir_Kathir,
				Properties.Resources.Tafsir_Maududi,
				Properties.Resources.Tafsir_Qushairi,
				Properties.Resources.Tafsir_Tustari,
				Properties.Resources.Tafsir_Wahidi
			};
			foreach (string xml in tafsirContents)
				ImportTafsirVerses(context, xml);
		}

		void ImportTafsirVerses(ObjectSpace context, string xml)
		{
			var xmlDoc = XDocument.Parse(xml);
			var tafsirElement = xmlDoc.Document.Root;
			string tafsirCode = tafsirElement.Element("code").Value;
			if (context.TafsirVerses.Any(x => x.TafsirCode == tafsirCode))
				return;

			foreach(XElement chapterNode in xmlDoc.Descendants("chapter"))
			{
				int chapter = int.Parse(chapterNode.Attribute("index").Value);
				foreach(XElement commentaryNode in chapterNode.Descendants("commentary"))
				{
					var textNodes = commentaryNode.Elements("text");
					string commentaryText =
						string.Join("\r\n", textNodes.Select(x => x.Value));
					var tafsirVerse = new TafsirVerse(
						tafsirCode: tafsirCode,
						chapter: chapter,
						firstVerse: int.Parse(commentaryNode.Element("firstVerse").Value),
						lastVerse: int.Parse(commentaryNode.Element("lastVerse").Value),
						commentary: commentaryText);

					context.TafsirVerses.AddOrUpdate(x => new { x.TafsirCode, x.Chapter, x.FirstVerse }, tafsirVerse);
					context.SaveChanges();
				}
			}

		}
	}
}
