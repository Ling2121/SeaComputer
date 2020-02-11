using System;
using Godot;
namespace Sea.Programs
{
    public class cd : Program
    {
        // public cd():base(@"
        //     function run(state,computer,shell,args)
        //         if #args > 0 then
        //             local name = args[2]
        //             if name == '.' then
        //                 return nil;
        //             end
        //             if name == '..' then
        //                 if shell.filenode:HasParent() then
        //                     shell.filenode = shell.filenode.parent;
        //                 end
        //             else
        //                 local child = shell.filenode:GetChild(name);

        //                 if child then
        //                     shell.filenode = child;
        //                 end
        //             end
        //         end
        //     end
        // "){
        //     name = "cd";
        // }

        public cd()
        {
            name = "cd";
        }
        public override System.Object Exec(Computer computer, Shell shell,String[] args)
        {
            if(args.Length > 0)
            {
                String name = (String)args[1];
                if(name == "."){return null;}
                if(name == "..")
                {
                    if(shell.filenode.HasParent())
                    {
                        shell.filenode = shell.filenode.parent;
                    }
                }
                else
                {
                    var child = shell.filenode.GetChild(name);
                    if(child != null && child is Folder)
                    {
                        shell.filenode = child;
                    }
                    else
                    {
                        shell.PushMsg("没有这个文件夹");
                    }
                }

            }
            return null;
        }
    }
}