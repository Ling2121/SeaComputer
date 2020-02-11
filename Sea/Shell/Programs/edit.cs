using System;
using Godot;
namespace Sea.Programs
{
    public class edit : Program
    {
        public edit()
        {
            name = "edit";
        }

        public override System.Object Exec(Computer computer, Shell shell,String[] args)
        {
            if(args.Length > 1)
            {
                FileTreeNode file = shell.filenode.GetChild(args[1]);
                if(file == null)
                {
                    var touchprog = new touch();
                    String[] _args = {"touch",args[1]};
                    String name = (String)touchprog.Exec(computer,shell,_args);
                }
                file = shell.filenode.GetChild(args[1]);
                if(file is File)
                {
                    computer.edit_file = (File)file;
                    computer.text_edit.Text = ((File)file).text;
                    computer.text_edit_open_file_label.Text = file.name;
                }
            }
            return null;
        }
    }
    
}