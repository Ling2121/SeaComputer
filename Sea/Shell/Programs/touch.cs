using System;
using Godot;
namespace Sea.Programs
{
    public class touch : Program
    {
        public touch()
        {
            name = "touch";
        }

        public static String GetFileName(FileTreeNode node,String name)
        {
            if(!node.HasChild(name)){return name;}
            int count = 0;
            String _name = name;
            while(node.HasChild(_name))
            {
                _name = name + count;
                count ++;
            }

            name = _name;
            return name;
        }

        

        public override System.Object Exec(Computer computer, Shell shell,String[] args)
        {
            if(args.Length > 1)
            {
                String name = GetFileName(shell.filenode,args[1].Replace(' ','_'));
                File file = new File(name);
                shell.filenode.AddChild(file);
                return name;
            }
            return null;
        }
    }
    
}