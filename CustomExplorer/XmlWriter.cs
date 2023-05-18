using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace CustomExplorer
{
    public class XmlWriter : ExplorerItemHandler
    {
        private Dictionary<Guid, XmlElement> _nodes;
        private const int WriteChunkSize = 100;

        public XmlWriter(string historyPath, string directoryName)
        {
            HistoryPath = historyPath;
            DirectoryName = directoryName;

            var fileName = DirectoryName + ".xml";
            FilePath = Path.Combine(HistoryPath, fileName);
            XDocument = new XmlDocument();
            _nodes = new Dictionary<Guid, XmlElement>();
        }

        
        public string HistoryPath { get; set; }
        public string DirectoryName { get; set; }
        public string FilePath { get; set; }
        public XmlDocument XDocument { get; set; }

        public override void Handle(CancellationTokenSource tokenSource)
        {
            try
            {
                InitXmlFile(FilePath);

                using (var reader = XmlReader.Create(FilePath))
                {
                    XDocument.Load(reader);
                }
                var xRoot = XDocument.DocumentElement;

                var currentChunkSize = 0;

                while (GetItemsCount() > 0 || !tokenSource.Token.IsCancellationRequested)
                {
                    if (GetItemsCount() == 0)
                    {
                        Task.Delay(10);
                        continue;
                    }

                    var item = GetIncomingItem();


                    var element = CreateElementWithAttributes(item);
                    if (!xRoot.HasChildNodes)
                    {
                    
                        xRoot.AppendChild(element);
                    }
                    else
                    {
                        _nodes[item.ParentId].AppendChild(element);
                    }

                    if (item.Type.Equals(ExplorerItemType.Directory))
                    {
                        _nodes.Add(item.Id, element);
                    }

                    currentChunkSize++;
                    if(currentChunkSize == WriteChunkSize)
                    {
                        XDocument.Save(FilePath);
                        currentChunkSize = 0;
                    }

                }

            }
            catch
            {
                tokenSource.Cancel();
                throw;
            }
        }

        private XmlElement CreateElementWithAttributes(ExplorerItem item)
        {
            var element = XDocument.CreateElement(item.Type.ToString());
            foreach (var attribute in item.Info)
            {
                element.SetAttribute(attribute.Key, attribute.Value);
            }
            return element;
        }

        private static void InitXmlFile(string filePath)
        {
            File.WriteAllText(filePath, "");
            XmlTextWriter textWritter = new XmlTextWriter(filePath, Encoding.UTF8);
            textWritter.WriteStartDocument();
            textWritter.WriteStartElement("FolderStructure");
            textWritter.WriteEndElement();
            textWritter.Close();
        }
    }
}
