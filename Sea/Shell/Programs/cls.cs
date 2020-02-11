using System;
using Godot;
namespace Sea.Programs
{
    public class cls : Program
    {
        public cls()
        {
            name = "cls";
        }

        public override System.Object Exec(Computer computer, Shell shell,String[] args)
        {
            computer.display.Text = "";
            return null;
        }
    }
}