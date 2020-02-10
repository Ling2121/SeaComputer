using System.Collections;
using System;
using Godot;

namespace Sea
{
    public class Program : File
    {
        LuaScript script = null;

        public Program(){}
        public Program(String code)
        {
           SetScript(code);
        }

        void SetScript(String code)
        {
            if(script == null)
            {
                script = new LuaScript(code);
            }
            else
            {
                script.code = code;
            }
        }

        virtual public System.Object Exec(Computer computer,Shell shell,object[] args){
            script.state.DoString(script.code);
            var run = script.state.GetFunction("run");
            if(run != null)
            {
                var ret = run.Call(script.state,(Computer)computer,(Shell)shell,args);
                return ret;
            }
            return null;
        }
    }
}