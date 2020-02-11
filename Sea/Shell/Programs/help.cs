using System;

namespace Sea.Programs
{
    public class help : Program
    {
        public help()
        {
            name = "help";
        }

        String help_text = @"
        Help-------------------------------------------------------------*
        |    help               显示当前文档                                       
        |    cd  dir            切换目录                                        
        |    ls                 显示当前目录文件   /开头表示目录  $开头表示可执行程序
        |    mv  name  path     移动文件到path位置
        |    pwd                显示当前目录
        |    touch  name        创建文件
        |    mkdir  name        创建目录
        |    rm  name           删除文件或者目录
        |    lua                执行lua脚本文件
        |    edit  name         编辑文件（找不到会自己创建）
        |    prog  name  name2  把文件转换为可执行程序，name2为输出名字(可以忽略)
        |    cls                清空屏幕
        -----------------------------------------------------------------*
        ";

        public override System.Object Exec(Computer computer, Shell shell,String[] args)
        {
            shell.PushMsg(help_text);
            return null;
        }
    }
}