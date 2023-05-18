using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomExplorer
{
    public interface IObserver
    {
        void Update(ExplorerItem item);
    }
}
