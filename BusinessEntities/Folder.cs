using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class Folder
    {
        public string FolderName { set; get; }

        public Folder(string name)
        {
            FolderName = name;
        }
    }
}
