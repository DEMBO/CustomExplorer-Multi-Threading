using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CustomExplorer
{
    public abstract class ExplorerItemHandler : IObserver
    {
        private Queue<ExplorerItem> IncomingItems = new Queue<ExplorerItem>();
        private object _lockObject = new object();

        public void Update(ExplorerItem item)
        {
            lock (_lockObject)
            {
                IncomingItems.Enqueue(item);
            }
        }

        protected ExplorerItem GetIncomingItem()
        {
            lock (_lockObject)
            {
                return IncomingItems.Dequeue();
            }
        }

        protected int GetItemsCount()
        {
            lock (_lockObject)
            {
                return IncomingItems.Count;
            }
        }

        public abstract void Handle(CancellationTokenSource tokenSource);
    }
}
