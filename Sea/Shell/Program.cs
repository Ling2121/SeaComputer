using System.Collections;
using System;
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

        virtual public Object Exec(Computer computer,Shell shell,params object[]args){
            var run = script.state.GetFunction("run");
            if(run != null)
            {
                var ret = run.Call(computer,shell,args);
                return ret;
            }
            return null;
        }
    }
}