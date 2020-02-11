using System.Runtime.InteropServices.ComTypes;
using Godot;
using System;
namespace Sea.Programs
{
    public class ls : Program
    {
        // public ls():base(@"
        //     function run(state,computer,shell)
        //         local table = tools:GetNodeChilds(state,shell.filenode)
        //         for k,child in pairs(table) do
        //             if tools:IsFolder(child) then
        //                 shell:PushMsg('/'..k..'\n')
        //             else
        //                 shell:PushMsg(k..'\n')
        //             end
        //         end
        //         shell:PushMsg('\n')
        //     end
        // "){
        //     name = "ls";
        // }

        public ls(){
            name = "ls";
        }

        public override System.Object Exec(Computer computer, Shell shell,String[] args)
        {
            foreach(FileTreeNode child in shell.filenode.childs.Values)
            {
                if(child is Folder)
                {
                    shell.PushMsg("/"+child.name+"\n");
                }
                else if(child is File)
                {
                    shell.PushMsg(child.name+"\n");
                }
                else if(child is Program)
                {
                    shell.PushMsg("$"+child.name+"\n");
                }
            }
            shell.PushMsg("\n");
            return null;
        }
    }
}