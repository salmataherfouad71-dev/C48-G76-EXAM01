using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam01
{
    public abstract class Question
    {
        public string Header { protected set; get; }
        public string Body { protected set; get; }
        public decimal Mark { protected set; get; }
        public Answer[] AnswerList { protected set; get; }
        public Answer RightAnswer { protected set; get; }
        public static int count = 1;
        public Question(string body, decimal mark,Answer rightAnswer)
        {
            Header = $"Question {count++}";
            Body= body;
            Mark= mark;
            RightAnswer= rightAnswer;
        }
        public string TextAnswerOfQuestion(Answer answer)
        {
            return $"{Header}: {Body}\nYour Answer => {answer.AnswerText}\nCorrect Answer => {RightAnswer.AnswerText}";
        }
        public decimal AnswerOfQuestion(Answer id)
        {
            if (id.AnswerId<1||id.AnswerId>AnswerList.Length)
            {
                throw new InvalidOperationException("Invalid Id!");
            }
            else if (id.AnswerId == RightAnswer.AnswerId)
            {
                return Mark;
            }
            else
            {
                return 0;
            }
        }
    }
}
