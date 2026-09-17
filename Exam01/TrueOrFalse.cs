using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam01
{
    public class TrueOrFalse:Question
    {
        public TrueOrFalse(string body, decimal mark, Answer rightAnswer) : base(body, mark, rightAnswer)
        {
            AnswerList = new Answer[]
            { 
                new Answer("True",1),
                new Answer("False",2),
            };
        }
        public override string ToString()
        {
            string answers = "";
            foreach (Answer answer in AnswerList)
            {
                answers = answers + answer.ToString() + "\n";
            }
            return $"{Header}:{Body}\nTrue | False Question:\tMark {Mark}\n{answers}";
        }
        public static TrueOrFalse CreateTrueOrFalseQuestion()
        {
            string body;
            decimal mark;
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
            while (decimal.TryParse(Console.ReadLine(), out mark) == false || mark < 0);
            do
            {
                Console.WriteLine("Please enter the ID of the correct answer (1 for True, 2 for False):");
            }
            while (int.TryParse(Console.ReadLine(), out id) == false || id < 1 || id > 2);
            string text;
            if (id == 1)
                text = "True";
            else
                text = "False";
            Answer correct = new Answer(text,id);
            return new TrueOrFalse(body, mark, correct);
        }
    }
}
