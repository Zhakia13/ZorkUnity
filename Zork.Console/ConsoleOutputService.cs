using System;

namespace Zork
{
    internal class ConsoleOutputService : IOutputService
    {
        public void Write(string value) => Console.Write(value);
        
        public void Write(object value) => Write(value.ToString());

        public void WriteLine(object value) => WriteLine(value.ToString());

        public void WriteLine(string value) => Console.WriteLine(value);
        
    }
}
