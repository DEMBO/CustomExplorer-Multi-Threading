using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomExplorer
{
    public class ExplorerItem
    {

        public ExplorerItem(Guid id, Guid parentId, Dictionary<string, string> info, ExplorerItemType type)
        {
            Id = id;
            ParentId = parentId;
            Info = info;
            Type = type;
        }

        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public Dictionary<string, string> Info { get; set; }
        public ExplorerItemType Type { get; set; }

        public string Name
        {
            get { return Info["Name"]; }
        }
    }
}
