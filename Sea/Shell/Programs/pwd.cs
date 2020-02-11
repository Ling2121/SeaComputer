using System;
using Godot;
namespace Sea.Programs
{
    public class pwd : Program
    {
        public pwd()
        {
            name = "pwd";
        }

        public String GetPath(FileTreeNode node)
        {
            if(node.parent == null)
            {
                return "/";
            }
            String str = "";
            while(node.parent != null)
            {
                str = str + "/" + node.name;
                node = node.parent;
            }

            return str;
        }

        public override System.Object Exec(Computer computer, Shell shell,String[] args)
        {
            shell.PushMsg(GetPath(shell.filenode) +"\n");
            return null;
        }
    }
    
}