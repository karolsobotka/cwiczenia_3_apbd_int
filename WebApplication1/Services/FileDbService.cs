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

            stream.Close();
            
            
        }
       
        private Student student;

        public void AddStudent(Student st)
        {
            if (st == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                studentsList.Add(new Student
                {
                    IndexNumber = st.IndexNumber,
                    FirstName = st.FirstName,
                    LastName = st.LastName,
                    dateOfBirth = st.dateOfBirth,
                    studies = new WebApplication1.Studies(st.studies.studiesMode, st.studies.studiesName),
                    email = st.email,
                    fathersName = st.fathersName,
                    mothersName = st.mothersName
                });

                writeToFileFromList();
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

        public void UpdateStudent(Student st)
        {
            student = studentsList.Find(e => e.IndexNumber == st.IndexNumber);
            


            if (student != null)
            {

                student.IndexNumber = st.IndexNumber;
                student.FirstName = st.FirstName;
                student.LastName = st.LastName;
                student.dateOfBirth = st.dateOfBirth;
                student.studies = new WebApplication1.Studies(st.studies.studiesMode, st.studies.studiesName);
                student.email = st.email;
                student.fathersName = st.fathersName;
                student.mothersName = st.mothersName;

            }
            else
            {
                throw new Exception("Nie ma takiego studenta do zaktualizowania");
            }
            writeToFileFromList();

           

        }
    }
}
