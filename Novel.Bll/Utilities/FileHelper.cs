using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Bll.Utilities
{
    public class FileHelper
    {
        private string FilePath { get; set; }
        public FileHelper(string path)
        {
            this.FilePath = path;

            //if (File.Exists(FilePath)==false)
            //{
            //    File.Create(FilePath);
            //}
        }
        public static string NovelBaseDirectory
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Novels");
            }
        }


        public void WriteAllLines(string[] contents)
        {
            if (File.Exists(FilePath) == false)
            {
                File.Delete(FilePath);
            }
            File.WriteAllLines(FilePath, contents);
        }

        public string ReadAllText()
        {
            return File.ReadAllText(FilePath);
        }
    }
}
