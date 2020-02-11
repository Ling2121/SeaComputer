using System;
using Godot;
using System.Collections;

namespace Sea
{
    public class Folder : FileTreeNode
    {
        public Folder(){}
        public Folder(String name){this.name = name;}

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
    }
}