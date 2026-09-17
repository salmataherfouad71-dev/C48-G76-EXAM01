using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam01
{
    public class Answer
    {
        public static int count = 1;
        public int AnswerId {private set; get; }
        public string AnswerText { private set; get; }
        public Answer(string answerText,int answerId)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }
        public Answer(int id)
        {
            AnswerId = id;
        }
        public override string ToString()
        {
            return $"{AnswerId}- {AnswerText}";
        }
    }
}
