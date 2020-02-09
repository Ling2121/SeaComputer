using System;
using NLua;

namespace Sea
{
    public class LuaScript : Godot.Object
    {
        public String code = "";
        public Lua state = new Lua();
        
        public LuaScript(){}
        public LuaScript(String code)
        {
            this.code = code;
        }
        public void exec()
        {
            state.DoString(code);
        }
    }
}