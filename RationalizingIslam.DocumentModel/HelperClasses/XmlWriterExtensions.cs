using RationalizingIslam.DocumentModel.HelperClasses;
using System;
using System.Xml;

namespace RationalizingIslam.DocumentModel
{
    public static class XmlWriterExtensions
    {
        public static IDisposable WriteElement(this XmlWriter writer, string name)
        {
            writer.WriteStartElement(name);
            return new DisposableAction(() => writer.WriteEndElement());
        }
    }
}
