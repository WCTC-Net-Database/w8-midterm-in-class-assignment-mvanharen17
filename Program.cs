using System;
using System.IO;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace CharacterConsole;

class Program
{
    static void Main()
    {
        var manager = new CharacterManager();
        manager.Run();
    }
}