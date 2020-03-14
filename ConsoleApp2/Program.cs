using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ConsoleApp2
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string path = args[0];
            string arg1 = args[1];
            string format = args[2];

            OwnComparer ownComparer = new OwnComparer();
            HashSet<Student> hashStudent = new HashSet<Student>(ownComparer);
            StreamWriter writer = new StreamWriter(@"log.txt");

            var lines = File.ReadLines(path);
            try
            {
                foreach (var line in lines)
                {
                    string[] arrStr = line.Split(',');
                    if (arrStr.Length == 9)
                    {
                        if (!Array.Exists(line.Split(','), element => element == ""))
                        {
                            Student temp = new Student();

                            temp.firstName = arrStr[0];
                            temp.lastName = arrStr[1];
                            temp.studies = arrStr[2];
                            temp.tryb = arrStr[3];
                            temp.index = arrStr[4];
                            temp.dataUrodzienia = arrStr[5];
                            temp.mail = arrStr[6];
                            temp.momName = arrStr[7];
                            temp.dadName = arrStr[8];

                            hashStudent.Add(temp);

                        }
                        else
                        {
                            writer.WriteLine("Student id: " + arrStr[4] + " ma puste pole");
                        }


                    }
                    else
                    {
                        writer.WriteLine("Student id: " + arrStr[4] + "nie poprawna ilosc kolumn");
                    }
                }

                Dictionary<string, int> countStudies = new Dictionary<string, int>();
                foreach (var student in hashStudent)
                {
                    if (!countStudies.ContainsKey(student.firstName)) countStudies.Add(student.firstName, 1);
                    else countStudies[student.firstName]++;
                }

                if (format.Equals("xml"))
                {
                    XDocument Xdocument = new XDocument(new XElement("uczelnia",
                        new XAttribute("createdAt", "08.03.2020"),
                        new XAttribute("author", "Jan Kowalski"),
                        new XElement("studenci",
                            from student in hashStudent
                            select new XElement("student",
                            new XAttribute("indexNumber", student.index),
                            new XElement("fname", student.firstName),
                            new XElement("lname", student.lastName),
                            new XElement("birthdate", student.dataUrodzienia),
                            new XElement("email", student.mail),
                            new XElement("mothersName", student.momName),
                            new XElement("fathersName", student.dadName),
                            new XElement("studies",
                                new XElement("name", student.firstName),
                                new XElement("mode", student.tryb)
                       ))),
                        new XElement("activeStudies",
                            from tmp in countStudies
                            select new XElement("studies",
                                new XAttribute("name", tmp.Key),
                                new XAttribute("numberOfStudents", tmp.Value)
                                )
                        )));
                    Xdocument.Save(arg1);
                }
                else Console.WriteLine("Zly typ formatu");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Podana sciezka jest niepoprawna");
                throw;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not Found");
                throw;
            }
        }

    } 
}


/*

                int counttest = 0;
                for (int q = 0; q < hashStudent.Count; q++)
                {
                    for (int j = q + 1; j < hashStudent.Count; j++)
                    {
                        if (hashStudent.ElementAt(q).index == hashStudent.ElementAt(j).index &&
                            hashStudent.ElementAt(q).firstName == hashStudent.ElementAt(j).firstName &&
                            hashStudent.ElementAt(q).lastName == hashStudent.ElementAt(j).lastName)
                        {

                            writer.WriteLine(counttest + " Duplikat Student o id: s" + hashStudent.ElementAt(j));
                            counttest++;

                        }
                    }
                }

                int i = 0;
                foreach (Student q in hashStudent)
                {


                    i++;
                    Console.WriteLine(q);
                }
                Console.WriteLine(i);

                Console.WriteLine("COUNT " + hashStudent.Count);
*/



