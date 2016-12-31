using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace RationalizingIslam.DocumentModel.XmlStreaming
{
    public class HadithCollectionXmlWriter
    {
        HadithCollection Collection;
        XmlWriter Xml;

        public HadithCollectionXmlWriter(HadithCollection collection)
        {
            this.Collection = collection;
        }

        public void WriteXml(string filePath)
        {
            using (Xml = XmlWriter.Create(filePath, new XmlWriterSettings { Encoding = Encoding.Unicode, Indent = true }))
            {
                Xml.WriteStartDocument();
                WriteRootElement();
                Xml.WriteEndDocument();
            }
        }

        void WriteRootElement()
        {
            using (Xml.WriteElement("hadithCollection"))
            {
                Xml.WriteElementString("code", Collection.Code);
                Xml.WriteElementString("name", Collection.Name);
                Xml.WriteElementString("copyright", Collection.Copyright);
                WritePrimaryReferenceDefinition();
                WriteHadiths();
            }
        }

        void WritePrimaryReferenceDefinition()
        {
            using (Xml.WriteElement("referenceDefinition"))
            {
                foreach (string partName in Collection.ReferencePartNames)
                    Xml.WriteElementString("definition", partName);
            }
        }

        void WriteHadiths()
        {
            using (Xml.WriteElement("hadiths"))
                foreach (Hadith hadith in Collection.Hadiths.OrderBy(x => x.Reference))
                    WriteHadith(hadith);
        }

        void WriteHadith(Hadith hadith)
        {
            using (Xml.WriteElement("hadith"))
            {
                WriteHadithReference(hadith.Reference);
                WriteHadithSecondaryReferences(hadith);
                WriteHadithText(hadith);
                WriteHadithVerseReferences(hadith);
            }
        }

        void WriteHadithReference(MultiPartReference reference)
        {
            using (Xml.WriteElement("reference"))
            {
                foreach (string partValue in reference)
                    Xml.WriteElementString("part", partValue);
            }
        }

        void WriteHadithSecondaryReferences(Hadith hadith)
        {
            using (Xml.WriteElement("secondaryReferences"))
                foreach (var secondaryReference in hadith.OtherReferences.OrderBy(x => x.Key))
                    WriteHadithSecondaryReference(secondaryReference);
        }

        void WriteHadithSecondaryReference(KeyValuePair<string, string> secondaryReference)
        {
            using (Xml.WriteElement("secondaryReference"))
            {
                Xml.WriteElementString("type", secondaryReference.Key);
                Xml.WriteElementString("value", secondaryReference.Value);
            }
        }

        void WriteHadithText(Hadith hadith)
        {
            WriteHadithParagraphs("arabic", hadith.ArabicText);
            WriteHadithParagraphs("english", hadith.EnglishText);
        }

        void WriteHadithParagraphs(string elementName, string[] paragraphs)
        {
            paragraphs = paragraphs ?? new string[0];
            using (Xml.WriteElement(elementName))
                foreach (string paragraph in paragraphs)
                    Xml.WriteElementString("text", paragraph);
        }

        void WriteHadithVerseReferences(Hadith hadith)
        {
            using (Xml.WriteElement("verseReferences"))
                foreach (var verseReference in hadith.VerseReferences)
                    WriteHadithVerseReferences(verseReference);
        }

        void WriteHadithVerseReferences(VerseRangeReference verseReference)
        {
            using (Xml.WriteElement("reference"))
            {
                Xml.WriteElementString("chapter", verseReference.Chapter + "");
                Xml.WriteElementString("firstVerse", verseReference.FirstVerse + "");
                Xml.WriteElementString("lastVerse", verseReference.LastVerse + "");
            }
        }
    }
}
