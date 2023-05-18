using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomExplorer
{
    public class TreeViewWriter : ExplorerItemHandler
    {
        private readonly TreeView _treeView;
        private Dictionary<Guid, TreeNode> _nodes;

        public TreeViewWriter(TreeView treeView)
        {
            _treeView = treeView;
            _nodes = new Dictionary<Guid, TreeNode>();
        }

        public override void Handle(CancellationTokenSource tokenSource)
        {
            try
            { 
                while (GetItemsCount() > 0 || !tokenSource.Token.IsCancellationRequested)
                {
                    if (GetItemsCount() == 0)
                    {
                        Task.Delay(10);
                        continue;
                    }

                    var item = GetIncomingItem();


                    var node = new TreeNode(item.Name);
                    if (_treeView.Nodes.Count == 0)
                    {
                        _treeView.Invoke(new Action(() => { _treeView.Nodes.Add(node); }));
                    }
                    else
                    {
                        _treeView.Invoke(new Action(() => { _nodes[item.ParentId].Nodes.Add(node); }));
                    }

                    if (item.Type.Equals(ExplorerItemType.Directory))
                    {
                        _nodes.Add(item.Id, node);
                    }
                }
            }
            catch
            {
                tokenSource.Cancel();
                throw;
            }
        }
    }
}
