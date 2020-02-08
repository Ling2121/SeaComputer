using System;
using System.Collections;

namespace Sea
{
    public class Folder : FileTreeNode
    {
        override public bool AddChild(FileTreeNode node)
        {
            childs[node.name] = node;
            node.parent = this;
            return true;
        }

        override public FileTreeNode RemoveChild(String name)
        {
            if(HasChild(name))
            {
                var child = (FileTreeNode)childs[name];
                child.parent = null;
                childs.Remove(name);
                return child;
            }
            return null;
        }

        override public bool HasChild(String name)
        {
            return childs.Contains(name);
        }

        override public Hashtable GetChilds()
        {
            return childs;
        }
    }
}