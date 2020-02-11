using System;
using Godot;
using NLua;
namespace Sea.Programs
{
    public class lua : Program
    {
        public lua()
        {
            name = "lua";
        }

        public override System.Object Exec(Computer computer, Shell shell,String[] args)
        {
            if(args.Length > 1)
            {
                FileTreeNode file = shell.filenode.GetChild(args[1]);
                Lua luastate = new Lua();
                if(file != null && file is File)
                {
                    luastate["shell"] = shell;
                    luastate["computer"] = computer;
                    luastate.DoString(@"
                        function print(str)
                            shell:PushMsg(str)
                        end
                    ");

                    try
                    {
                        luastate.DoString(((File)file).text);
                    }
                    catch (NLua.Exceptions.LuaScriptException emm)
                    {
                        shell.PushMsg(emm.Message);
                    }
                    
                }
            }
            return null;
        }
    }
}