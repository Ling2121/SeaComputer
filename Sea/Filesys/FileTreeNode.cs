using System;
using System.Collections;
using NLua;

namespace Sea
{
    public class FileTreeNode : Godot.Object
    {
        public String name = "A";
        public Hashtable childs = new Hashtable();
        public FileTreeNode parent = null;

        public FileTreeNode()
        {

        }

        public FileTreeNode(String name)
        {
            this.name = name;
        }

        virtual public bool rename(String name)
        {
            if(parent != null)
            {
                if(!parent.HasChild(name))
                {
                    this.name = name;
                }
            }
            else
            {
                this.name = name;
                return true;
            }
            return false;
        }

        virtual public bool AddChild(FileTreeNode node){return false;}

        virtual public FileTreeNode RemoveChild(String name){return null;}

        virtual public bool HasChild(String name){return false;}

        virtual public Hashtable GetChilds()
        {
            return childs;
        }

        virtual public LuaTable GetChildsToTable(Lua state)
        {
            state.NewTable("a");
            LuaTable table = state.GetTable("a");
            foreach(FileTreeNode child in childs.Values)
            {
                table[child.name] = child;
            }
            return table;
        }
    }
}