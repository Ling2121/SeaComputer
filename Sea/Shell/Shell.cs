using System.Collections;
using Godot;
using System;
using NLua;

namespace Sea
{
    public class Shell : Godot.Object
    {
        public FileTreeNode filenode;
        public Queue msg = new Queue(512);

        public void PushMsg(String str)
        {
            msg.Enqueue(str);
        }
    }
}
