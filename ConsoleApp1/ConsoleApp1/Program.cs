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
            if (Znak == "+")
            {
                Calculator.Adding(FirstNumber, SecondNumber);
            }
            if (Znak == "*")
            {
                Console.WriteLine(Calculator.Mult(FirstNumber, SecondNumber));
                Console.WriteLine(Calculator.Delit(FirstNumber, SecondNumber));

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
        public static double Adding(double num1,double num2) => num1 + num2; 
        public static double Mult(double num1, double num2) => num1 * num2;
        public void PrintOkruglenii(int num,int NumOfF)
        {
            switch (num) 
            {
                case 1:
                    {
                        Console.WriteLine($"{num:1F}");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine($"{num:2F}");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine($"{num:3F}");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine($"{num:4F}");
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine($"{num:5F}");
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine($"{num:6F}");
                        break;
                    }
            }

        }
        public double OstatokOtDeleniya(double num1 , double num2)  => num1 % num2;
    }
}
