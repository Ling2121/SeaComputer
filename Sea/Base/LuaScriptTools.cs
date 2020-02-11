using NLua;

namespace Sea
{
    public class LuaScriptTools
    {
        public bool IsFolder(FileTreeNode node)
        {
            return node is Folder;
        }

        public bool IsFile(FileTreeNode node)
        {
            return node is File;
        }

        public LuaTable GetNodeChilds(Lua state,FileTreeNode node)
        {
            state.NewTable("__a__");
            LuaTable table = state.GetTable("__a__");
            foreach(FileTreeNode child in node.childs.Values)
            {
                table[child.name] = child;
            }
            return table;
        }
    }
}