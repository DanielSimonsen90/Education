using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MyWebserver
{
    class Program
    {
        static void Main()
        {
            new DanhoServer().ListenTo("http://localhost:6969/");
        }
    }
}
