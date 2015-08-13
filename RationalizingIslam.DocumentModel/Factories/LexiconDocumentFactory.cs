using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RationalizingIslam.DocumentModel.Factories
{
    public class LexiconDocumentFactory
    {
        public LexiconDocument Create(string generatedLexiconsXmlDirectory)
        {
            //TODO: Read from files
            return new LexiconDocument();
        }
    }
}
