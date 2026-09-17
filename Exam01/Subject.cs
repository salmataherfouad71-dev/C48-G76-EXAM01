using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam01
{
    public class Subject
    {
        public string Id { get; private set; }
        public string Name {  get; private set; }
        public Exam Exam { get; set; }
        public DateOnly TimeOfStart { set; get; }
        //public Subject(string id, string name, Exam exam)
        //{
        //    Id = id;
        //    Name = name;
        //    Exam = exam;
        //}
        public int StartExam()
        {
            int choice;
            do
            {
                Console.WriteLine("Enter the type of the exam (1 for Practical, 2 for Final):");
            }
            while (int.TryParse(Console.ReadLine(),out choice)==false||choice<1||choice>2);
            return choice;
        }
        public Exam SelectExam(int choice)
        {
            double time;
            int numberOfQuestions;
            do
            {
                Console.WriteLine("Please enter the time for the exam (30 to 180 minutes):");
            }
            while (double.TryParse(Console.ReadLine(), out time)==false||time<30||time>180);
            do
            {
                Console.WriteLine("Please enter the number of the questions:");
            }
            while (int.TryParse(Console.ReadLine(), out numberOfQuestions) == false || numberOfQuestions < 0);

            if (choice == 1)
            {
                Console.Clear();
                return new PracticalExam(numberOfQuestions, time);
            }
            else if (choice == 2)
            {
                Console.Clear();
                return new FinalExam(numberOfQuestions, time);
            }
            else
            {
                throw new InvalidOperationException("Invalid Choice!");
            }
        }
        public List<Answer> ShowQuestions()
        {
            Exam.ShowExamName();
            List<Answer> ids = new List<Answer>();
            for (int i = 0; i < Exam.NumberOfQuestions; i++)
            {
                int id;
                Console.WriteLine(Exam.Questions[i]);
                do
                {
                    Console.WriteLine("Enter your answer ID:");
                }
                while (int.TryParse(Console.ReadLine(), out id) == false || id < 0 || id > Exam.Questions[i].AnswerList.Length);
                ids.Add(Exam.Questions[i].AnswerList[id-1]);
            }
            Exam.CalculateStudentMarks(ids);
            Console.Clear();
            ShowResults(ids);
            Console.WriteLine($"Your Grade is {Exam.CalculateStudentMarks(ids)} from {Exam.CalculateTotalMarks()}");
            return ids;
        }
        public void AskToStartExam()
        {
            string ans;
            do
            {
                Console.WriteLine("Do You Want To Start Exam (Y | N)");
                TimeOfStart=DateOnly.FromDateTime(DateTime.Now);
                ans = Console.ReadLine().ToUpper();
            } while (string.IsNullOrWhiteSpace(ans)||ans!="Y"&&ans!="N");
            if (ans == "Y")
            {
                ShowQuestions();
            }
            else if (ans == "N")
            {
                return;
            }
            else 
            {
                throw new InvalidOperationException("Not Found!");
            }
        }
        public void ShowResults(List <Answer> results)
        {
            int count = 0;
            Console.WriteLine($"{Exam.ShowExamName()} Results:");
            foreach(Answer ans in results)
            {
                Console.WriteLine(Exam.Questions[count].TextAnswerOfQuestion(ans));
                Console.WriteLine();
                count++;
            }
        }
    }
}
