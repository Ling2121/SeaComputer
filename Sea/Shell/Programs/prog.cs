using System;
using Godot;

namespace Sea.Programs
{
    public class prog : Program
    {
        public prog()
        {
            name = "prog";
        }

        public override System.Object Exec(Computer computer, Shell shell,String[] args)
        {
            if(args.Length > 1)
            {
                FileTreeNode file = shell.filenode.GetChild(args[1]);
                if(file != null && file is File)
                {
                    String name = file.name;
                    if(args.Length > 2)
                    {
                        name = args[2];
                    }
                    Sea.Program p = new Sea.Program(((File)file).text);
                    p.name = name;
                    shell.filenode.RemoveChild(file.name);
                    shell.filenode.AddChild(p);
                }
            }
            return null;
        }
    }
}