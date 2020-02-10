using System.Runtime.InteropServices;
using Godot;
using System;

namespace Sea
{
    public class Computer : Node
    {
        public Shell shell = new Shell();
        public FileTree filetree = new FileTree();

        public RichTextLabel display;
        public LineEdit input;

        public override void _Ready()
        {
            display = (RichTextLabel)GetNode("Panel/VSplitContainer/Display");
            input = (LineEdit)GetNode("Panel/VSplitContainer/Input");

            input.Connect("text_entered",this,"__TextEntered__");
            shell.Connect("s_PushMsg",this,"__PushMsg__");
        }

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

        public void __PushMsg__(String str)
        {
            display.Text += str + "\n";
        }

        public void __TextEntered__(String str)
        {
            shell.Input(str);
            input.Text = "";
        }
    }

}
