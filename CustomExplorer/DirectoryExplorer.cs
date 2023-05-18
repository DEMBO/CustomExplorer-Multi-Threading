using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading;

namespace CustomExplorer
{
    public class DirectoryExplorer : IObservable
    {
        private List<IObserver> observers;
        public DirectoryExplorer()
        {
            observers = new List<IObserver>();
        }
        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers(ExplorerItem item)
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(item);
            }
        }

        public void StartExplore(string path, CancellationTokenSource tokenSource)
        {
            try
            {
                var mainDir = new DirectoryInfo(path);
                var mainDirInfo = ToDictionary(mainDir, ExplorerItemType.Directory);
                var mainDirId = Guid.NewGuid();
                NotifyObservers(new ExplorerItem(mainDirId, Guid.Empty, mainDirInfo, ExplorerItemType.Directory));

                Explore(mainDirId, mainDir, tokenSource.Token);
            }
            catch
            {
                throw;
            }
            finally
            {
                tokenSource.Cancel();
            }
        }

        public void Explore(Guid parentId,DirectoryInfo mainDir, CancellationToken token)
        {
            var files = mainDir.GetFiles();
            foreach (var file in files)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }
                var fileInfo = ToDictionary(file, ExplorerItemType.File);
                NotifyObservers(new ExplorerItem(Guid.NewGuid(), parentId, fileInfo, ExplorerItemType.File));
            }

            var directories = mainDir.GetDirectories();
            foreach (var directory in directories)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }
                var directoryInfo = ToDictionary(directory, ExplorerItemType.Directory);
                var directoryId = Guid.NewGuid();
                NotifyObservers(new ExplorerItem(directoryId, parentId, directoryInfo, ExplorerItemType.Directory));
                Explore(directoryId, directory, token);
            }
        }

        public Dictionary<string, string> ToDictionary(FileSystemInfo item, ExplorerItemType type)
        {
            var info = new Dictionary<string,string>();

            info.Add("Name", item.Name);
            info.Add("CreationTime", item.CreationTime.ToString(CultureInfo.CurrentUICulture));

            FileSystemSecurity security;
            if (type.Equals(ExplorerItemType.Directory))
            {
                security = ((DirectoryInfo)item).GetAccessControl();
            }
            else
            {
                var fileItem = (FileInfo)item;

                info.Add("Size", fileItem.Length.ToString());
                security = fileItem.GetAccessControl();
            }

            var sid = security.GetOwner(typeof(SecurityIdentifier));
            NTAccount ntAccount = (NTAccount)sid.Translate(typeof(NTAccount));
            info.Add("Owner", ntAccount.Value);

            var currentUserId = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
            var accessRules = security.GetAccessRules(true, true, typeof(SecurityIdentifier));

            var rights = "";

            foreach (FileSystemAccessRule rule in accessRules)
            {
                if (rule.IdentityReference.Value.Equals(currentUserId))
                {
                    rights = rule.FileSystemRights.ToString();
                    break;
                }
            }

            info.Add("AccessRules", rights);

            return info;
        }
    }
}
