using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileImportService
{
    class ImportService
    {
        private FileSystemWatcher _watcher;

        public bool Start()
        {
            _watcher = new FileSystemWatcher(@"C:\Users\Cordney\Documents\FileTest");

            _watcher.Created += FileCreated;

            _watcher.IncludeSubdirectories = false;

            _watcher.EnableRaisingEvents = true;

            return true;
        }

        private void FileCreated(object sender, FileSystemEventArgs e)
        {
            string FileName = e.Name;
            Console.WriteLine(FileName);
            File.Delete(e.FullPath);    
        }

        public bool Stop()
        {
            _watcher.Dispose();

            return true;
        }
    }
}
