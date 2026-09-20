using System;
using System.Collections.Generic;
using System.IO;

namespace GeneticSearch
{
    class Program
    {
        const string AuthorName = "Daniil Mackevich";
        const string Title = "Genetic Searching";
        const int LineWidth = 74;

        struct Protein
        {
            public string name;
            public string organism;
            public string amino_acids;
        }

        struct Command
        {
            public string name;
            public string parameter1;
            public string parameter2;
        }


        /// <summary>
        /// Read commands from file
        /// </summary>
        static List<Command> ReadCommands(string filename)
        {
            List<Command> commands = new List<Command>();

            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split('\t');

                    Command command;
                    command.name = parts[0].Trim();
                    command.parameter1 = parts.Length > 1 ? parts[1] : String.Empty;
                    command.parameter2 = parts.Length > 2 ? parts[2] : String.Empty;
                    commands.Add(command);
                }
            }
            return commands;
        }

        static List<Protein> ReadData(string filename)
        {
            List<Protein> data = new List<Protein>();

            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split('\t');
                    if (parts.Length < 3) continue;

                    Protein protein;
                    protein.name = parts[0];
                    protein.organism = parts[1];
                    protein.amino_acids = parts[2].Trim();
                    data.Add(protein);
                }
            }
            return data;
        }

        ///<summary>
        ///Debug output 
        ///</summary>

        static void PrintData(List<Protein> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                Console.WriteLine("Protein " + (i + 1));
                Console.WriteLine(data[i].name);
                Console.WriteLine(data[i].organism);
                Console.WriteLine(data[i].amino_acids);
                Console.WriteLine("========================");
            }
        }

        static void PrintCommands(List<Command> commands)
        {
            for (int i = 0; i < commands.Count; i++)
            {
                Console.WriteLine("Command " + (i + 1));
                Console.WriteLine(commands[i].name);
                Console.WriteLine(commands[i].parameter1);
                Console.WriteLine(commands[i].parameter2);
                Console.WriteLine("========================");
            }
        }

        static void Main(string[] args)
        {
            try
            {
                List<Protein> data = ReadData("sequences.0.txt");
                PrintData(data);

                List<Command> commands = ReadCommands("commands.0.txt");
                PrintCommands(commands);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ОШИБКА: " + ex.Message);
            }

            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
