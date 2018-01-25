using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Services
{
    public class FileWatcher
    {
        static string path = @"C:\Users\Balazs\Test\TestTask\proba\files";
        public static void Watch()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = path;
            watcher.Filter = "*.csv";
            watcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.LastAccess | NotifyFilters.LastWrite;
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            System.Diagnostics.Debug.Write("file:");
            foreach (string file in Directory.EnumerateFiles(path, "*.csv"))
            {
                string contents = File.ReadAllText(file);
            }
        }
    }
}
