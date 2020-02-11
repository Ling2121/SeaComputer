using System.Runtime.InteropServices;
using Godot;
using System;

namespace Sea
{
    public class Computer : Node
    {
        public Shell shell = new Shell();
        public FileTree filetree = new FileTree();
        public LuaScriptTools lua_tools = new LuaScriptTools();
        public RichTextLabel display;
        public LineEdit input;
        public TextEdit text_edit;
        public Label text_edit_open_file_label;
        public Button save_button;
        public Button quit_button;
        public File edit_file = null;

        public override void _Ready()
        {
            display = (RichTextLabel)GetNode("Panel/HSplitContainer/Panel/VSplitContainer/Display");
            input = (LineEdit)GetNode("Panel/HSplitContainer/Panel/VSplitContainer/Input");
            text_edit = (TextEdit)GetNode("Panel/HSplitContainer/VSplitContainer/TextEdit");
            text_edit_open_file_label = (Label)GetNode("Panel/HSplitContainer/VSplitContainer/Panel/OpenFileName");
            save_button = (Button)GetNode("Panel/HSplitContainer/VSplitContainer/HBoxContainer/Save");
            quit_button = (Button)GetNode("Panel/HSplitContainer/VSplitContainer/HBoxContainer/Quit");

            input.Connect("text_entered",this,"__TextEntered__");
            shell.Connect("s_PushMsg",this,"__PushMsg__");
            save_button.Connect("button_down",this,"__Save__");
            quit_button.Connect("button_down",this,"__Quit__");
        }

        public Computer()
        {
            shell.filenode = filetree.root;
            shell.computer = this;

            var bin = new Folder("bin");
            var user = new Folder("user");

            bin.AddChild(new Programs.ls());
            bin.AddChild(new Programs.cd());
            bin.AddChild(new Programs.mv());
            bin.AddChild(new Programs.pwd());
            bin.AddChild(new Programs.rm());
            bin.AddChild(new Programs.touch());
            bin.AddChild(new Programs.mkdir());
            bin.AddChild(new Programs.edit());
            bin.AddChild(new Programs.lua());
            bin.AddChild(new Programs.help());
            bin.AddChild(new Programs.prog());
            bin.AddChild(new Programs.cls());

            filetree.root.AddChild(bin);
            filetree.root.AddChild(user);
        }

        public void __PushMsg__(String str)
        {
            display.Text += str;
        }

        public void __TextEntered__(String str)
        {
            shell.Input(str);
            input.Text = "";
        }

        public void __Save__()
        {
            if(edit_file != null)
            {
                edit_file.text = text_edit.Text;
            }
        }

        public void __Quit__()
        {
            text_edit_open_file_label.Text = "";
            text_edit.Text = "";
        }
    }

}
