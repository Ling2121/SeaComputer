using Godot;
using System;
namespace Sea.Programs
{
    public class ls : Program
    {
        public ls(){
            name = "ls";
        }

        public override System.Object Exec(Computer computer, Shell shell, params object[] args)
        {
            foreach(FileTreeNode child in shell.filenode.childs.Values)
            {
                if(child is Folder)
                {
                    shell.PushMsg("/"+child.name);
                }
                else
                {
                    shell.PushMsg(child.name);
                }
            }
            return null;
        }
    }
}