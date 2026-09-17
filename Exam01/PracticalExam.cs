using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam01
{
    public class PracticalExam : Exam
    {
        public PracticalExam(int numberOfQuestions, double time) : base(numberOfQuestions, time)
        {

        }
        public override void AddQuestions()
        {
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                if (Questions.Count < NumberOfQuestions)
                {
                    Questions.Add(MCQ.CreateMCQQuestion());
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
            return "Practical Exam";
        }
    }
}
