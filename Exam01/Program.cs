namespace Exam01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject sub1 = new Subject();
            int choice=sub1.StartExam();
            Exam ex =sub1.SelectExam(choice);
            sub1.Exam=ex;
            ex.AddQuestions();
            sub1.AskToStartExam();
            Console.WriteLine("Thank you");
        }
    }
}
