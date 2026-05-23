using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

namespace FileSearch
{
   
    public class File {
        public delegate void DisplayFileName(string file);
        public event DisplayFileName sendFileName;
        public void Search(string dirName){
           string[] strfiles =  Directory.GetFiles(dirName);

            foreach (string dir in Directory.GetDirectories(dirName))
            {
                foreach (string file in strfiles)
                {
                    sendFileName(file);
                    Thread.Sleep(1000);

                }
                Search(dir);
            }
        }
    }
}