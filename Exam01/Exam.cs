using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam01
{
    public abstract class Exam
    {
        public List<Question> Questions { protected set; get; }
        public int NumberOfQuestions { private set; get; }
        public double Time { private set; get; }
        public Exam(int numberOfQuestions, double time)
        { 
            NumberOfQuestions = numberOfQuestions;
            Time = time;
            Questions= new List<Question>();
        }
        public abstract void AddQuestions();
        public decimal CalculateTotalMarks()
        {
            if ( Questions == null)
            {
                throw new NullReferenceException("The List is Empty!");
            }
            decimal total = 0;
            foreach (Question question in Questions)
            {
                total += question.Mark;
            }
            return total;
        }
        public decimal CalculateStudentMarks(List<Answer>ids)
        {
            if (ids==null||Questions==null)
            {
                throw new NullReferenceException("The List is Empty!");
            }
            int count = 0;
            decimal total = 0;
            foreach (Question question in Questions)
            {
                total += question.AnswerOfQuestion( ids[count]);
                count++;
            }
            return total;
        }
        public abstract string ShowExamName();
    }
}
