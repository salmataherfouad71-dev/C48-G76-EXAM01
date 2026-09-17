using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam01
{
    public class FinalExam:Exam
    {
        public FinalExam(int numberOfQuestions, double time) : base(numberOfQuestions,time)
        {
               
        }
        public override void AddQuestions()
        {
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                int choice;
                Console.WriteLine($"Enter details for question {Questions.Count + 1}:");
                do
                {
                    Console.WriteLine("Choose question type: 1 for MCQ, 2 for True/False:");
                }
                while (int.TryParse(Console.ReadLine(), out choice) == false || choice < 1 || choice > 2);
                if (Questions.Count < NumberOfQuestions && choice == 1)
                {
                    Questions.Add(MCQ.CreateMCQQuestion());
                }
                else if (Questions.Count < NumberOfQuestions && choice == 2)
                {
                    Questions.Add(TrueOrFalse.CreateTrueOrFalseQuestion());
                }
                else
                {
                    throw new IndexOutOfRangeException("Cannot Add More Questions!");
                }
                Console.Clear();
            }
        }
        public override string ShowExamName()
        {
            return "Final Exam";
        }
    }
}
