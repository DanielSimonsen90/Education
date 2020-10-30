using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderDetails
{
    public class Obj
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public List<Obj> Children { get; set; }
        public bool IsFile
        {
            get
            {
                return Name.Contains(".");
            }
        }

        public void SetSubDirectories()
        {
            string[] subdirectoryEntries = new string[0];
            string[] subfiles = new string[0];
            try
            { 
                subdirectoryEntries = Directory.GetDirectories(Path, "*", SearchOption.TopDirectoryOnly);
                subfiles = Directory.GetFiles(Path, "*", SearchOption.TopDirectoryOnly);
            }
            catch { }
            foreach (string s in subdirectoryEntries)
            {
                string[] pathSplit = s.Split('\\');
                Children.Add(new Obj(pathSplit[pathSplit.Length - 1], s));
                Children[Children.Count - 1].SetSubDirectories();
            }
            foreach (string s in subfiles)
            {
                string[] pathSplit = s.Split('\\');
                Children.Add(new Obj(pathSplit[pathSplit.Length - 1], s));
                Children[Children.Count - 1].SetSubDirectories();
            }
        }

        public Obj(string name, string path)
        {
            Name = name;
            Path = path;
            Children = new List<Obj>();
        }

        public override string ToString() => Name;
    }
}
