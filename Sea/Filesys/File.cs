using System;
using System.Collections;

namespace Sea
{
    public class File : FileTreeNode
    {
        public File():base(){}
        public File(String name):base(name){}
        public String text;
    }

}