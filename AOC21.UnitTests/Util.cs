using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC21.UnitTests
{
    public class Util
    {
        public static string GetInput(string path)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var file = new StreamReader($"{currentDirectory}/Inputs/{path}");

            return file.ReadToEnd();
        }

        internal static string GetInput()
        {
            throw new NotImplementedException();
        }
    }
}
