using System.Runtime.InteropServices;
using Godot;
using System;

namespace Sea
{
    public class Computer : Node
    {
        public Shell shell = new Shell();
        public FileTree filetree = new FileTree();

        public Computer()
        {
            shell.filenode = filetree.root;

            var bin = new Folder("bin");
            var user = new Folder("user");
            filetree.root.AddChild(bin);
            filetree.root.AddChild(user);
        }
    }

}
