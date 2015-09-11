using System;
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
            PhoneBook.Node phoneBook = new PhoneBook.Node(String.Empty);
            string answer = null;

            for (int j = 0; j < numberOfPhoneNumbers; j++)
            {
                var no = scanner.Next();
                if (answer != null)
                    continue;

                var current = phoneBook;
                var lastDigit = no[no.Length - 1];
                foreach (var digit in no)
                {
                    if (current.Nodes[digit - '0'] == null)
                        current.Nodes[digit - '0'] = new PhoneBook.Node(current.id + digit);
                    else if (digit == lastDigit)
                    {
                        // number already exists
                        answer = "NO";
                        break;
                    }
                    current = current.Nodes[digit - '0'];
                }
            }
            return answer ?? "YES";
        }

        public class PhoneBook
        {
            public class Node
            {
                public override string ToString()
                {
                    return id;
                }

                public Node(String id)
                {
                    this.id = id;
                }

                public string id;
                public Node[] Nodes = new Node[10];
            }
        }
    }
}
