using System;
using System.Diagnostics;
using System.IO;
using KattisSolution.IO;

namespace KattisSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Solve(Console.OpenStandardInput(), Console.OpenStandardOutput());
        }

        public static void Solve(Stream stdin, Stream stdout)
        {
            IScanner scanner = new OptimizedPositiveIntReader(stdin);
            // uncomment when you need more advanced reader
            // scanner = new Scanner(stdin);
            scanner = new LineReader(stdin);
            BufferedStdoutWriter writer = new BufferedStdoutWriter(stdout);

            var numberOfTestCases = scanner.NextInt();

            for (int i = 0; i < numberOfTestCases; i++)
            {

                var result = Solve(scanner);
                writer.Write(result);
                writer.Write("\n");
            }

            writer.Flush();
        }

        private static string Solve(IScanner scanner)
        {
            int numberOfPhoneNumbers = scanner.NextInt();
            Program.PhoneNode phoneBook = new Program.PhoneNode(String.Empty, false);
            string answer = null;

            for (int j = 0; j < numberOfPhoneNumbers; j++)
            {
                var no = scanner.Next();
                Debug.WriteLine("Processing: " + no);

                if (answer != null)
                    continue;

                var current = phoneBook;

                for (int index = 0; index < no.Length; index++)
                {
                    var digit = no[index] - '0';
                    if (current.Nodes[digit] == null)
                        current.Nodes[digit] = new PhoneNode(current.Id + digit, index == no.Length - 1);
                    else if (index == no.Length - 1 || current.Nodes[digit].IsStop)
                    {
                        // if this is my last digit and number already used - 'NO'
                        // if some other number finished here - 'NO'

                        // number already exists
                        answer = "NO";
                        break;
                    }
                    current = current.Nodes[digit];
                }
            }
            return answer ?? "YES";
        }

        public class PhoneNode
        {
            public override string ToString()
            {
                return Id;
            }

            public PhoneNode(string id, bool isStop)
            {
                Id = id;
                IsStop = isStop;
            }

            public string Id;
            public PhoneNode[] Nodes = new PhoneNode[10];
            public bool IsStop;
        }
    }
}
