using System;
using Godot;
namespace Sea.Programs
{
    public class rm : Program
    {
        public rm()
        {
            name = "rm";
        }

        public override System.Object Exec(Computer computer, Shell shell,String[] args)
        {
            if(args.Length > 1)
            {
                if(shell.filenode.HasChild(args[1]))
                {
                    shell.filenode.RemoveChild(args[1]);
                }
            }
            return null;
        }
    }
    
}