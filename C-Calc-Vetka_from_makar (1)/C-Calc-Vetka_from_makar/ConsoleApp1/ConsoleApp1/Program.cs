using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("введите пример");
            Console.WriteLine("*n1 (действие) n2*"); // лучше сделать систему ввода как написано левее чтобы пользователю было понятно
            var deystvie = Console.ReadLine();
            string[]? mathDate = deystvie.Split(' ');
            mathDate = mathDate ?? new string[] {"0","+","0"};
            try
            {
                if (mathDate.Length > 3 || mathDate.Length < 3) throw new Exception("Ошибка ввода!");
            }
            catch (Exception ex) { Console.WriteLine($"Возникла ошибка! - {ex}");
                mathDate[0] = "0"; mathDate[1] = "+"; mathDate[2] = "0";
            }
            ;
            switch (mathDate[1]) //Сделал через case, так удобнее
            {
                case "-":
                    {
                        Calculator.Minus(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                        break;
                    }
                case "/":
                    {
                        Calculator.Delit(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                        break;
                    }
            }

        }

    }
    public class Calculator
    {
        private static void Save(string strToSave)
        {
            try
            {
                using (var sw = new StreamWriter(_path, true))//Добавил сохронение в файл
                {
                    sw.WriteLine(strToSave);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static string _path = "Calc.txt";
        public static void Minus(double FirstNumber, double SecondNumber)
        {
            var res = FirstNumber - SecondNumber;
            Console.WriteLine($"{FirstNumber} - {SecondNumber} = {res}");
            Save($"{FirstNumber} - {SecondNumber} = {res}");
        }
        public static void Delit(double FirstNumber, double SecondNumber)
        {
            var res = FirstNumber / SecondNumber;
            Console.WriteLine($"{FirstNumber} - {SecondNumber} = {res}");
            Save($"{FirstNumber} / {SecondNumber} = {res}");
        }
    }
}
