namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("введите пример");
            Console.WriteLine("*n1 (действие) n2*");
            double FirstNumber = Convert.ToInt32(Console.ReadLine());
            double SecondNumber = Convert.ToInt32(Console.ReadLine());
            string Znak = Console.ReadLine();
            if (Znak == "-")
            {
                Calculator.Minus(FirstNumber, SecondNumber);
            }
            if (Znak == "/")
            {
                Calculator.Delit(FirstNumber, SecondNumber);
            }
        }

    }
    public class Calculator
    {
        public static void Minus(double FirstNumber, double SecondNumber)
        {
            Console.WriteLine($"{FirstNumber} - {SecondNumber} = {FirstNumber - SecondNumber}");
            
        }
        public static void Delit(double FirstNumber, double SecondNumber)
        {
            Console.WriteLine($"{FirstNumber} / {SecondNumber} = {FirstNumber / SecondNumber}");
        }
    }
}
