using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice13
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

        }
        static void Task1()
        {
            List<int> list = InputList<int>();
            int max1 = list[0];
            int max2 = list[0];
            int index1 = 0;
            int index2 = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == max1)
                {
                    max2 = max1;
                    max1 = list[i];

                    index2 = index1;
                    index1 = i;
                }
            }
            Console.WriteLine($"");

            for (int i = 0; i < list.Count; i++)
            {

            }

        }
        static List<T> InputList<T>()
        {
            List<T> list = new List<T>();
            Random rnd = new Random();

            for (int i = 0; i < rnd.Next(10, 20); i++)
            {
                var val = (T)Convert.ChangeType(i, typeof(T));
                list.Add(val);
            }
            return list;
        }

        static void Task2()
        {
            List<double> list = InputList<double>();

            double average = list.Average();

            List<double> result = list.Where(x => x > average).ToList();

            foreach (var i in result)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        static void Task3()
        {
            string[] lines = File.ReadAllLines("input.txt");

            Array.Reverse(lines);
            File.WriteAllLines("output.txt", lines);
        }
        static void Task4()
        {
            string[] employeeData = File.ReadAllLines("employees.txt");

            var lowSalaryEmployees = employeeData.Where(line => GetSalary(line) < 10000);
            var highSalaryEmployees = employeeData.Where(line => GetSalary(line) >= 10000);

            foreach (var employee in lowSalaryEmployees)
            {
                Console.WriteLine(employee);
            }

            foreach (var employee in highSalaryEmployees)
            {
                Console.WriteLine(employee);
            }

            int GetSalary(string line)
            {
                string[] parts = line.Split(' ');
                string salaryString = parts[parts.Length - 1];

                if (int.TryParse(salaryString, out int salary))
                {
                    return salary;
                }

                return 0;
            }
        }
        static void Task5()
        {
            Hashtable catalog = new Hashtable();

            catalog.Add("Disk1", new List<string> { "Song1", "Song2" });
            catalog.Add("Disk2", new List<string> { "Song3", "Song4" });

            foreach (DictionaryEntry entry in catalog)
            {
                Console.WriteLine($"Disk: {entry.Key}");
                foreach (var song in (List<string>)entry.Value)
                {
                    Console.WriteLine($"  Song: {song}");
                }
            }

            catalog.Remove("Disk1");

            string artistToFind = "Artist1";
            foreach (DictionaryEntry entry in catalog)
            {
                var songs = (List<string>)entry.Value;
                if (songs.Contains(artistToFind))
                {
                    Console.WriteLine($"Disk: {entry.Key}, Song: {artistToFind}");
                }
            }

        }
    }
}
