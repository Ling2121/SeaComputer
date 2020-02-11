using System;
using Godot;
namespace Sea.Programs
{
    public class mv : Program
    {
        public mv()
        {
            name = "mv";
        }

         public FileTreeNode _GetNode(Computer computer,Shell shell,String path)
        {
            if(path == "/")
            {
                return computer.filetree.root;
            }
            if(path == "..")
            {
                if(shell.filenode != computer.filetree.root)
                {
                    return shell.filenode.parent;
                }
            }
            if(path[0] == '/')
            {
                FileTreeNode node = computer.filetree.root;
                String[] paths = path.Split('/');
                int i = 1;
                while(i<paths.Length)
                {
                    FileTreeNode c = node.GetChild(paths[i]);
                    if(!(c is Folder)){return null;}
                    if(c != null)
                    {
                        node = c;
                    }
                    else
                    {
                        return null;
                    }
                    i++;
                }
                
                return node;
            }
            return shell.filenode.GetChild(path);
        }

        public override System.Object Exec(Computer computer,Shell shell,String[] args)
        {
            if(args.Length > 2)
            {
                if(args[1] == "/")
                {
                    return null;
                }
                FileTreeNode file = _GetNode(computer,shell,args[1]);
                Folder to = (Folder)_GetNode(computer,shell,args[2]);
                if((file == null) || (to == null)){return null;}
                if(to is Folder)
                {
                    if(!to.HasChild(file.name))
                    {
                        var parent = ((Folder)file.parent);
                        parent.RemoveChild(file.name);
                        to.AddChild(file);
                    }
                    else
                    {
                        shell.PushMsg("无法移动，已有同名文件");
                    }
                }
            }

            return null;
        }
    }
}