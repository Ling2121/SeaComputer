using System.Collections;
using Godot;
using System;
using NLua;

namespace Sea
{
    public class Shell : Godot.Object
    {
        [Signal]
        delegate void s_PushMsg(String msg);

        public Computer computer = null;
        public FileTreeNode filenode = null;
        public Queue msg = new Queue(512);

        public Shell()
        {
            Connect(nameof(s_PushMsg),this,"__PushMsg__");
        }

        public void PushMsg(String str)
        {
            msg.Enqueue(str);
            EmitSignal(nameof(s_PushMsg),str);
        }

        public void __PushMsg__(String msg)
        {
            GD.Print(msg);
        }

        public Program FindProgram(String name)
        {
            if(filenode.childs.Contains(name))
            {
                FileTreeNode prog = (FileTreeNode)filenode.childs[name];
                if(prog is Program)
                {
                    return (Program)prog;
                }
            }

            if(computer.filetree.root.childs.Contains("bin"))
            {
                Folder bin = (Folder)computer.filetree.root.childs["bin"];
                if(bin.childs.Contains(name))
                {
                    FileTreeNode prog = (FileTreeNode)bin.childs[name];
                    if(prog is Program)
                    {
                        return (Program)prog;
                    }
                }
            }
            return null;
        }

        public void Input(String input)
        {
            string[] args = input.Split(' ');
            if(args.Length > 0)
            {
                string prog_name = args[0];
                Program prog = FindProgram(prog_name);
                if(prog != null)
                {
                    prog.Exec(computer,this,args);
                }
                else
                {
                    GD.Print("找不到指令:",prog_name);
                }
            }
        }
    }
}
