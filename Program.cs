using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace DotNetLab7
{
    public class Department
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public Department(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return $"{Id,2}), {Name,11}";
        }

    }

    public enum Gender
    {
        Female,
        Male
    }

    public class StudentWithTopics
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public bool Active { get; set; }
        public int DepartmentId { get; set; }

        public List<string> Topics { get; set; }
        public StudentWithTopics(int id, int index, string name, Gender gender, bool active,
            int departmentId, List<string> topics)
        {
            this.Id = id;
            this.Index = index;
            this.Name = name;
            this.Gender = gender;
            this.Active = active;
            this.DepartmentId = departmentId;
            this.Topics = topics;
        }

        public override string ToString()
        {
            var result = $"{Id,2}) {Index,5}, {Name,11}, {Gender,6},{(Active ? "active" : "no active"),9},{DepartmentId,2}, topics: ";
            foreach (var str in Topics)
                result += str + ", ";
            return result;
        }
    }

    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Topic(int id, string title)
        {
            this.Id = id;
            this.Title = title;
        }

        public override string ToString()
        {
            return $"({Id}, {Title})";
        }

    }

    public class Student
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public bool Active { get; set; }
        public int DepartmentId { get; set; }

        public List<int> TopicsIds { get; set; }
        public Student(int id, int index, string name, Gender gender, bool active,
            int departmentId, List<int> topicsIds)
        {
            this.Id = id;
            this.Index = index;
            this.Name = name;
            this.Gender = gender;
            this.Active = active;
            this.DepartmentId = departmentId;
            this.TopicsIds = topicsIds;
        }

        public override string ToString()
        {
            var result = $"{Id,2}) {Index,5}, {Name,11}, {Gender,6},{(Active ? "active" : "no active"),9},{DepartmentId,2}, topics: ";
            foreach (var str in TopicsIds)
                result += str + ", ";
            return result;
        }
    }

    public static class Generator
    {
        public static int[] GenerateIntsEasy()
        {
            return new int[] { 5, 3, 9, 7, 1, 2, 6, 7, 8 };
        }

        public static int[] GenerateIntsMany()
        {
            var result = new int[10000];
            Random random = new Random();
            for (int i = 0; i < result.Length; i++)
                result[i] = random.Next(1000);
            return result;
        }

        public static List<string> GenerateNamesEasy()
        {
            return new List<string>() {
                "Nowak",
                "Kowalski",
                "Schmidt",
                "Newman",
                "Bandingo",
                "Miniwiliger"
            };
        }
        public static List<StudentWithTopics> GenerateStudentsWithTopicsEasy()
        {
            return new List<StudentWithTopics>() {
            new StudentWithTopics(1,12345,"Nowak", Gender.Female,true,1,
                    new List<string>{"C#","PHP","algorithms"}),
            new StudentWithTopics(2, 13235, "Kowalski", Gender.Male, true,1,
                    new List<string>{"C#","C++","fuzzy logic"}),
            new StudentWithTopics(3, 13444, "Schmidt", Gender.Male, false,2,
                    new List<string>{"Basic","Java"}),
            new StudentWithTopics(4, 14000, "Newman", Gender.Female, false,3,
                    new List<string>{"JavaScript","neural networks"}),
            new StudentWithTopics(5, 14001, "Bandingo", Gender.Male, true,3,
                    new List<string>{"Java","C#"}),
            new StudentWithTopics(6, 14100, "Miniwiliger", Gender.Male, true,2,
                    new List<string>{"algorithms","web programming"}),
            new StudentWithTopics(11,22345,"Nowak", Gender.Female,true,2,
                    new List<string>{"C#","PHP","algorithms"}),
            new StudentWithTopics(12, 23235, "Nowak", Gender.Male, true,1,
                    new List<string>{"C#","C++","fuzzy logic"}),
            new StudentWithTopics(13, 23444, "Schmidt", Gender.Male, false,1,
                    new List<string>{"Basic","Java"}),
            new StudentWithTopics(14, 24000, "Newman", Gender.Female, false,1,
                    new List<string>{"JavaScript","neural networks"}),
            new StudentWithTopics(15, 24001, "Bandingo", Gender.Male, true,3,
                    new List<string>{"Java","C#"}),
            new StudentWithTopics(16, 24100, "Bandingo", Gender.Male, true,2,
                    new List<string>{"algorithms","web programming"}),
            };
        }

        public static List<StudentWithTopics> GenerateStudentsWithTopicsEasy2()
        {
            return new List<StudentWithTopics>() {
            new StudentWithTopics(1,12345,"Nowak", Gender.Female,true,1,
                    new List<string>{"C#","PHP","algorithms"}),
            new StudentWithTopics(2, 13235, "Kowalski", Gender.Male, true,1,
                    new List<string>{"C#","C++","fuzzy logic"}),
            new StudentWithTopics(3, 13444, "Schmidt", Gender.Male, false,2,
                    new List<string>{"Basic","Java"}),
            new StudentWithTopics(4, 14000, "Newman", Gender.Female, false,3,
                    new List<string>{"JavaScript","neural networks"}),
            new StudentWithTopics(4, 15900, "Lorenz", Gender.Female, false,3,
                    new List<string>{"JavaScript","neural networks", "C#"}),
            new StudentWithTopics(5, 14001, "Bandingo", Gender.Male, true,3,
                    new List<string>{"Java","C#"}),
            new StudentWithTopics(6, 14100, "Miniwiliger", Gender.Male, true,2,
                    new List<string>{"algorithms","web programming"}),
            new StudentWithTopics(11,22345,"Nowak", Gender.Female,true,2,
                    new List<string>{"C#","PHP","algorithms"}),
            new StudentWithTopics(12, 23235, "Nowak", Gender.Male, true,1,
                    new List<string>{"C#","C++","fuzzy logic"}),
            new StudentWithTopics(13, 23444, "Schmidt", Gender.Male, false,1,
                    new List<string>{"Basic","Java"}),
            new StudentWithTopics(14, 24000, "Newman", Gender.Female, false,1,
                    new List<string>{"JavaScript","neural networks"}),
            new StudentWithTopics(15, 24001, "Bandingo", Gender.Male, true,3,
                    new List<string>{"Java","C#"}),
            new StudentWithTopics(16, 24100, "Bandingo", Gender.Male, true,2,
                    new List<string>{"algorithms","web programming"}),
            new StudentWithTopics(16, 28300, "Bandingo", Gender.Male, true,2,
                    new List<string>{"algorithms","web programming", "JavaScript"}),
            };
        }

        public static List<Department> GenerateDepartmentsEasy()
        {
            return new List<Department>() {
            new Department(1,"Computer Science"),
            new Department(2,"Electronics"),
            new Department(3,"Mathematics"),
            new Department(4,"Mechanics")
            };
        }

        // Basic;C++;fuzzy logic;JavaScript;neural networks;PHP;web programming;algorithms;Java;C#;
        // Could write query for it 
        public static List<Topic> GenerateTopics()
        {
            return new List<Topic>() {
                new Topic(1, "Basic"),
                new Topic(2, "C++"),
                new Topic(3, "fuzzy logic"),
                new Topic(4, "JavaScript"),
                new Topic(5, "neural networks"),
                new Topic(6, "web programming"),
                new Topic(7, "algorithms"),
                new Topic(8, "Java"),
                new Topic(9, "C#"), 
                new Topic(10, "PHP")
            };
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------- 1 ------------");
            ShowGroupsOfN();
            Console.WriteLine("--------- 2 ------------");
            showSortTopicsByPopularity();
            Console.WriteLine("--------- 3 ------------");
            ShowConvertedStudents();
            Console.WriteLine("--------- 4 ------------");
            DemonstrateReflection();

        }

        public static void ShowAllCollections()
        {
            Generator.GenerateIntsEasy().ToList().ForEach(Console.WriteLine);
            Generator.GenerateDepartmentsEasy().ForEach(Console.WriteLine);
            Generator.GenerateStudentsWithTopicsEasy().ForEach(Console.WriteLine);
        }

        static void ShowGroupsOfN()
        {
            IEnumerable<(int GroupNum, IGrouping<int, StudentWithTopics> Students)>  groupOfN = CreateGroupsOfN(4);

            foreach ((int GroupNum, IGrouping<int, StudentWithTopics> Students) g in groupOfN)
            {
                Console.WriteLine("Group = " + g.GroupNum);
                g.Students.ToList().ForEach(s => Console.WriteLine(" " + s));
            }
        }

        // Make it lambda
        static int GroupNumber((StudentWithTopics s, int num) t, int n)
        {
            return t.num / n;
        }

        // IEnumerable<IGrouping<int, StudentWithTopics>>
        public static IEnumerable<(int GroupNum, IGrouping<int, StudentWithTopics> Students)> CreateGroupsOfN(int n)
        {
            int i = 0;

            IEnumerable<(int, IGrouping<int, StudentWithTopics>)> group = from s in
                (from s in Generator.GenerateStudentsWithTopicsEasy()
                 orderby s.Name, s.Index
                 select s)
                        let num = i++
                        let groupNum = Program.GroupNumber((s, num), n)
                        group s by groupNum into sGroup
                        select ( 
                            groupNum : sGroup.Key,
                            Students :  sGroup 
                        );

            return group;
        }

        public static void showSortTopicsByPopularity()
        {
            IEnumerable<string> topics = SortTopicsByPopularity();
            Console.WriteLine("Sort by Popularity");
            topics.ToList().ForEach(x => Console.Write(x + ";"));
            Console.WriteLine();
            IEnumerable <(Gender Gender, IEnumerable<string> Topics)> topicsGender = SortTopicsByPopularityWithinGender();
            Console.WriteLine("Sort by Gender then Popularity");
            foreach (var group in topicsGender)
            {
                Console.WriteLine(group.Gender + ": ");
                group.Topics.ToList().ForEach(x => Console.Write(x + ";"));
                Console.WriteLine();
            }

        }

        // IEnumerable<string>
        public static IEnumerable<string> SortTopicsByPopularity()
        {
            IEnumerable<string> topicsWithCounts = Generator.GenerateStudentsWithTopicsEasy()
                .SelectMany(s => s.Topics)
                .GroupBy(t => t)
                .Select(group => (Key: group.Key, Count: group.Count()))
                .OrderBy(x => x.Count)
                .ThenBy(x => x)   // alphabetically ?
                .Select(x => x.Key);
                
            /* 
            var withCounts = Generator.GenerateStudentsWithTopicsEasy()
                .SelectMany(s => s.Topics)
                .GroupBy(t => t)
                .Select(group => (Key: group.Key, Count: group.Count()))
                .OrderBy(x => x.Count)
                .ThenBy(x => x);

            foreach (var group in withCounts)
            {
                Console.WriteLine(group.Key + " " + group.Count);
            } */

            return topicsWithCounts;
        }

        public static IEnumerable<(Gender Gender, IEnumerable<string> Topics)> SortTopicsByPopularityWithinGender()
        {
            IEnumerable<(Gender Gender, IEnumerable<string> Topics)> topics = Generator.GenerateStudentsWithTopicsEasy2()
                .GroupBy(s => s.Gender)
                .Select(group => (Gender: group.Key, 
                Topics: group.SelectMany(s => s.Topics)
                    .GroupBy(t => t)
                    .Select(group => (Key: group.Key, Count: group.Count()))
                    .OrderBy(x => x.Count)
                    .ThenBy(x => x)   // alphabetically ?
                    .Select(x => x.Key))
                );

            /* 
            var topicsWithCounts = Generator.GenerateStudentsWithTopicsEasy2()
                .GroupBy(s => s.Gender)
                .Select(group => (Gender: group.Key,
                Topics: group.SelectMany(s => s.Topics)
                    .GroupBy(t => t)
                    .Select(group => (Key: group.Key, Count: group.Count()))
                    .OrderBy(x => x.Count)
                    .ThenBy(x => x))
                );

            foreach (var group in topicsWithCounts)
            {
                Console.WriteLine(group.Gender + ": ");
                group.Topics.ToList().ForEach(x => Console.Write(x + ";"));
                Console.WriteLine();
            }*/

            return topics;
        }

        public static void ShowConvertedStudents()
        {
            var topics = Generator.GenerateTopics();
            foreach ( var topic in topics )
            {
                Console.Write(topic + ";");
            }
            IEnumerable<StudentWithTopics> studentsBefore = Generator.GenerateStudentsWithTopicsEasy().OrderBy(s => s.Index);
            IEnumerable<Student> studentsAfter = ConvertStudentWithTopicsToStudent().OrderBy(s => s.Index);
            
            for (var i = 0; i < studentsBefore.Count(); i++)
            {
                Console.WriteLine($"Student {i} conversion");
                Console.WriteLine(studentsBefore.ElementAt(i));
                Console.WriteLine(studentsAfter.ElementAt(i));
            }
        
        }

        public static IEnumerable<Student> ConvertStudentWithTopicsToStudent()
        {
            IEnumerable<Student> students = Generator.GenerateStudentsWithTopicsEasy()
            .Select(s => new Student(s.Id, s.Index, s.Name, s.Gender, s.Active,
            s.DepartmentId, 
                s.Topics.
                Join(Generator.GenerateTopics(), 
                        topicName => topicName, 
                        topic => topic.Title, 
                        (topicName, topic) => 
                            topic.Id
                    ).ToList()
            ));

            return students;
        }

        public static void DemonstrateReflection()
        {
            List<String> strings = new List<String>() { "Uno", "Cuatro", "Dos", "Tres", "Cinco", "Dos" };

            MethodInfo info = strings.GetType().GetMethod("IndexOf", 
                new Type[] {typeof(String), typeof(int), typeof(int)});

            Console.WriteLine(info.Name);
            foreach (var param in info.GetParameters())
            {
                Console.WriteLine(param);
            }

            string arg = "Dos";
            int index = (int)info.Invoke(strings, new object[] { arg, 1, 3 });
            Console.WriteLine($"Index of {arg} = " + index);

        }

    }
}
