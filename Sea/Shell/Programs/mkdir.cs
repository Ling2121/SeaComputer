using System;
using Godot;
namespace Sea.Programs
{
    public class mkdir : Program
    {
        public mkdir()
        {
            name = "mkdir";
        }

        public override System.Object Exec(Computer computer, Shell shell,String[] args)
        {
            if(args.Length > 1)
            {
                String name = touch.GetFileName(shell.filenode,args[1].Replace(' ','_'));
                Folder dir = new Folder(name);
                shell.filenode.AddChild(dir);
            }
            return null;
        }
    }
    
}