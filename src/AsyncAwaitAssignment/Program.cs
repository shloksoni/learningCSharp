using System;
using System.IO;
using System.Threading.Tasks;

namespace AsyncAwaitAssignment
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await ReadAndWriteAsync();
        }
        public static async Task ReadAndWriteAsync()
        {
            string ReadFilePath = "A.txt";
            string text = await File.ReadAllTextAsync(ReadFilePath);
            string WriteFilePath = "B.txt";
            await File.WriteAllTextAsync(WriteFilePath, text);

        }

    }
}
