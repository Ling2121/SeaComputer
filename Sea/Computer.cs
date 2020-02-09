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
            shell.computer = this;

            var bin = new Folder("bin");
            var user = new Folder("user");

            bin.AddChild(new Programs.ls());

            filetree.root.AddChild(bin);
            filetree.root.AddChild(user);
        }

        public void _on_LineEdit_text_entered(String str)
        {
            shell.Input(str);
            ((LineEdit)GetNode("LineEdit")).Text = "";
        }
    }

}
