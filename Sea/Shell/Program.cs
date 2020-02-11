using System.Collections;
using System;
using Godot;
using NLua;

namespace Sea
{
    public class Program : File
    {
        public Lua state = new Lua();

        public Program(){}
        public Program(String code)
        {
           SetScript(code);
        }

        public void SetScript(String code)
        {
            text = code;
        }

        public String GetSctipt()
        {
            return text;
        }

        virtual public LuaTable ArrayToLuaTable(LuaTable arr,String[] csarr)
        {
            int idx = 1;
            foreach(String i in csarr)
            {
                arr[idx] = i;
                idx++;
            }
            return arr;
        }

        virtual public System.Object Exec(Computer computer,Shell shell,String[] args)
        {
            state["tools"] = computer.lua_tools;
            state["shell"] = shell;
            state["computer"] = computer;
            state.DoString(@"
                function print(str)
                    shell:PushMsg(str)
                end
            ");
            state.NewTable("args");
            LuaTable a = state.GetTable("args");
            object[] ret = null;
            try
            {
                ret = state.DoString(text);
            }
            catch (NLua.Exceptions.LuaScriptException emm)
            {
                shell.PushMsg(emm.Message);
            }

            return ret;
        }
    }
}