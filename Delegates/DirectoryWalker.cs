using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class DirectoryWalker
    {
        public event EventHandler<FileArgs> FileFound;

        public void Walk(string path)
        {
            if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
                return;

            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                OnFileFound(new FileArgs { FileName = Path.GetFileName(file) });
            }

            // Рекурсивно обходим подпапки
            var directories = Directory.GetDirectories(path);
            foreach (var directory in directories)
            {
                Walk(directory);
            }
        }

        protected virtual void OnFileFound(FileArgs e)
        {
            FileFound?.Invoke(this, e);
        }
    }

    public class FileArgs : EventArgs
    {
        public string FileName { get; set; }
    }
}
