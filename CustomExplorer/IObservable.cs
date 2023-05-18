using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomExplorer
{
    public interface IObservable
    {
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers(ExplorerItem item);
    }
}
