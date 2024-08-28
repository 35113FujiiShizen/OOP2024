using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1_1("employee.xml");

            // これは確認用
            Console.WriteLine(File.ReadAllText("employee.xml"));
            Console.WriteLine();

            Exercise1_2("employees.xml");
            Exercise1_3("employees.xml");
            Console.WriteLine();

            Exercise1_4("employees.json");

            // これは確認用
            Console.WriteLine(File.ReadAllText("employees.json"));
        }
        private static void Exercise1_1(string outfile) {
            var employee = new Employee {
                Id = 0001,
                Name = "星を継ぐもの",
                HireDate = new DateTime(2005, 11, 23),
            };

            using (var writer = XmlWriter.Create(outfile)) {
                var serializer = new XmlSerializer(employee.GetType());
                serializer.Serialize(writer, employee);
            }
            using (var reader = XmlReader.Create(outfile)) {
                var serializer = new XmlSerializer(typeof(Employee));
                var novel = serializer.Deserialize(reader) as Employee;
                Console.WriteLine(novel);
            }


        }

        private static void Exercise1_2(string outfile) {
            var emps = new Employee[] {
                new Employee {
                    Id = 0001,
                    Name = "竹田",
                    HireDate = new DateTime(2024,10,7)
                },
                new Employee {
                    Id = 0002,
                    Name = "下田",
                    HireDate = new DateTime(2011,3,21)
                },
            };
            using (var writer = XmlWriter.Create(outfile)) {
                var serializer = new DataContractSerializer(emps.GetType());
                serializer.WriteObject(writer, emps);
            }
        }

        private static void Exercise1_3(string file) {
            using (var reader = XmlReader.Create(file)) {
                var serializer = new DataContractSerializer(typeof(Employee[]));
                var emps = serializer.ReadObject(reader) as Employee[];
                foreach (var emp in emps) {
                    Console.WriteLine("{0},{1},{2}", emp.Id, emp.Name, emp.HireDate);
                }
            }
        }

        private static void Exercise1_4(string file) {
            var emps = new Employee[] {
                new Employee {
                    Id = 0001,
                    Name = "竹田",
                    HireDate = new DateTime(2024,10,7)
                },
                new Employee {
                    Id = 0002,
                    Name = "下田",
                    HireDate = new DateTime(2011,3,21)
                },
            };
            var options = new JsonSerializerOptions {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true,
            };
            var jsonString = JsonSerializer.Serialize(emps, options);
            File.WriteAllText(file, jsonString);
            Console.WriteLine(jsonString);
        }
    }
}
