using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CsvHelper;
using Newtonsoft;
using Newtonsoft.Json;

namespace SampleApp1
{
    class Person
    {
        public string Name { get; set; }
        public string Genre { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Deployment Activity 1.3");
            Console.WriteLine("--- Welcome to Ari's Custom Application! --- ");

            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter your favourite genre of music: ");
            string genre = Console.ReadLine();

            var person = new Person
            {
                Name = name,
                Genre = genre
            };

            // json 
            string json = JsonConvert.SerializeObject(person, Formatting.Indented);
            Console.WriteLine("\nJSON output:");
            Console.WriteLine(json);

            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "output.csv"
                );

            using (var writer = new StreamWriter(path)) 
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecord(person);
            }

            Console.WriteLine("\nCSV file written to documents/output.csv");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
