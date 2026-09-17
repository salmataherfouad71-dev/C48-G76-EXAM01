using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam01
{
    public class MCQ:Question
    {
        public MCQ(string body, decimal mark,Answer rightAnswer, Answer[] answers) : base(body,mark,rightAnswer)
        {
            AnswerList = answers;
        }
        public static MCQ CreateMCQQuestion()
        {
            string body;
            decimal mark;
            Answer[] answers = new Answer[4];
            int id;
            do
            {
                Console.WriteLine("Please enter the question body:");
                body = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(body));
            do
            {
                Console.WriteLine("Please enter the question mark:");
            }
            while (decimal.TryParse(Console.ReadLine(),out mark)==false||mark<0);
            for (int i = 0; i < 4; i++)
            {
                string ans;
                do
                {
                    Console.WriteLine($"Please enter choice number {i+1}:");
                    ans= Console.ReadLine();
                }
                while (string.IsNullOrWhiteSpace(ans));
                answers[i] = new Answer(ans,i+1);
            }
            do
            {
                Console.WriteLine("Please enter the ID of the correct answer (1 to 4):");
            }
            while (int .TryParse(Console.ReadLine(),out id)==false||id<1||id>4);
            Answer correct= answers[id-1];
            Console.Clear();
            return new MCQ(body,mark,correct,answers);
        }
        public override string ToString()
        {
            string answers = "";
            foreach (Answer answer in AnswerList)
            { 
                answers=answers + answer.ToString() + "\n";
            }
            return $"{Header}:{Body}\nMCQ Question:\tMark {Mark}\n{answers}";
        }
    }
}
