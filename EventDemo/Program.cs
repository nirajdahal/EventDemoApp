using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace EventDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CollegeClassModel history = new CollegeClassModel("History101", 2);
            CollegeClassModel math = new CollegeClassModel("Calculs 203", 3);

            
            history.EnrollmentFull += Class_EnrollmentFull;
            history.SignUpStudents("Tulasi").PrintMessage();
            history.SignUpStudents("Puran").PrintMessage();
            history.SignUpStudents("Pujan").PrintMessage();
            history.SignUpStudents("Nirjala").PrintMessage();
            history.SignUpStudents("Saraswoti").PrintMessage();

            "--------------------------------------------------------------".PrintMessage();
            math.EnrollmentFull += Class_EnrollmentFull;
            math.SignUpStudents("Adish").PrintMessage();
            math.SignUpStudents("Kendrit").PrintMessage();
            math.SignUpStudents("Samundra").PrintMessage();
            math.SignUpStudents("Sudarshan").PrintMessage();
            math.SignUpStudents("Prastab").PrintMessage();
        }

        

        private static void Class_EnrollmentFull(object sender, string e)
        {
            Console.WriteLine(e );
            
        }
    }

    public static class ConsoleHelpers
    {
        public static void PrintMessage(this string message)
        {
            Console.WriteLine(message);
        }
    }
    public class CollegeClassModel
    {
        public event EventHandler<string> EnrollmentFull;

        private List<string> enrolledStudents = new List<string>();

        private List<string> waitingLists = new List<string>();
        public string CourseTitle { get; private set; }

        public int MaximumStudents { get; private set; }
        public CollegeClassModel(string title, int maximumStudents)
        {
            CourseTitle = title;
            MaximumStudents = maximumStudents;
        }

        public string SignUpStudents(string studentName)
        {
            string output = "";
            if(enrolledStudents.Count <= MaximumStudents)
            {

                if (enrolledStudents.Count == MaximumStudents)
                {
                    EnrollmentFull?.Invoke(this, $"The enrollment has been full for {CourseTitle}");
                }

                enrolledStudents.Add(studentName);
                output = $"{studentName} was addedd to enrolled list for {CourseTitle} course";
            }

            else
            {
                waitingLists.Add(studentName);
                output = $"{studentName} was addedd to watiing list for {CourseTitle} course";

                
            }

            return output;
         }
      
       
    }
}
