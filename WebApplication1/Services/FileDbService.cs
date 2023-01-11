using Cw3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Cw3.Services
{
    public class FileDbService : IFileDbService
    {
        public static List<Student> studentsList = new List<Student>();
       
     
        public static void readFromFileToList()
        {
            StreamReader _reader = new StreamReader("data.csv");
            string line;
            var lineCount = File.ReadLines("data.csv").Count();


            while ((line = _reader.ReadLine()) != null)
            {
                var values = line.Split(',');

                if (values.Length < 9)
                {
                    throw new Exception("Not enough values to describe student");
                }
                else if(studentsList.Count() == lineCount)
                {
                    Console.WriteLine("Student list already imported.");
                }
                else
                {
                    studentsList.Add(new Student
                    {
                        IndexNumber = values[2],
                        FirstName = values[0],
                        LastName = values[1],
                        dateOfBirth = values[3],
                        studies = new WebApplication1.Studies(values[5], values[4]),
                        email = values[6],
                        fathersName = values[7],
                        mothersName = values[8],
                    }
                    );
                   
                }
            }
            _reader.Close();
        }

        public static void writeToFileFromList()
        {

            FileStream stream = new FileStream("data.csv", FileMode.OpenOrCreate);

            
            using(StreamWriter streamWriter = new StreamWriter(stream, Encoding.UTF8))
            {
                foreach (Student student in studentsList)
                {
                    streamWriter.WriteLine(student);
                }
               
            }
            
            
        }
       
        private Student student;

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                
            }
           
        }

        public void DeleteStudent(string indexNumber)
        {
                     
            var studentToRemove = studentsList.Single(student => student.IndexNumber == indexNumber);

            if (studentToRemove != null)
            {
                studentsList.Remove(studentToRemove);
                writeToFileFromList();
            }
            else
            {
                throw new Exception("Nie ma takiego studenta do usunięcia");
            }
            
        }

        public Student GetStudent(string indexNumber)
        {
           return  student = studentsList.Find(e => e.IndexNumber == indexNumber);
        }

        public IEnumerable<Student> GetStudents()
        {
            return studentsList;
        }

        public void UpdateStudent(string indexNumber)
        {
            throw new NotImplementedException();
        }
    }
}
