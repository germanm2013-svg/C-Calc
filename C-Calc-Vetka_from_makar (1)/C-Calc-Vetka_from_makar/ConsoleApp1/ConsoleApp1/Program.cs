using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("введите пример");
            Console.WriteLine("*n1 (действие/команда) n2*"); // лучше сделать систему ввода как написано левее чтобы пользователю было понятно
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
                        Calculator.Minus(int.Parse(mathDate[0]), int.Parse(mathDate[2]));
                        break;
                    }
                case "/":
                    {
                        Calculator.Delit(int.Parse(mathDate[0]), int.Parse(mathDate[2]));
                        break;
                    }
                case "read":
                    {
                        Calculator.Read();
                        break;
                    }
                case "okrug":
                    {
                        Console.WriteLine(Calculator.Okruglenie(int.Parse(mathDate[2]), int.Parse(mathDate[0])));
                        break;
                    }
                case "+":
                    {
                        Calculator.Plus(int.Parse(mathDate[0]), int.Parse(mathDate[2]));
                        break;
                    }
                case "*":
                    {
                        Calculator.Mult(int.Parse(mathDate[0]), int.Parse(mathDate[2]));
                        break;
                    }
                case "%":
                    {
                        Calculator.OstatokOtDeleniya(int.Parse(mathDate[0]), int.Parse(mathDate[2]));
                        break;
                    }
                case "generation":
                    {
                        foreach (var item in Calculator.Generation())
                        {
                            Console.WriteLine($"{item}");
                        } 
                        Console.WriteLine("Успешная генерация");
                        break;
                    }
                case "clear":
                    {
                        Calculator.ClearTxt();
                        break;
                    }
            }

        }

    }
    public class Calculator
    {
        public static void ClearTxt()
        {
            try
            {
                using (var sw = new StreamWriter(_path))
                {
                    sw.WriteLine("*Obsolutly cleared txt*");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static List<int> Generation() { var rnd = new Random();var generaitedList = Enumerable.Range(1, 20).Select(i => rnd.Next(1, 10000)).ToList(); foreach (var i in generaitedList) Save($"{i}"); return generaitedList; }

        public static double Okruglenie(int okrugNum, double num) => Math.Round(num,okrugNum);
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
        public static void Read()
        {
            try
            {
                Console.WriteLine("------------------------");
                using (var sr = new StreamReader(_path))//Добавил чтение файла
                {
                    string line;
                    while((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
                Console.WriteLine("------------------------");
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
        public static void Plus(double FirstNumber, double SecondNumber)
        {
            var res = FirstNumber + SecondNumber;
            Console.WriteLine($"{FirstNumber} + {SecondNumber} = {res}");
            Save($"{FirstNumber} + {SecondNumber} = {res}");
        }
        public static void Mult(double FirstNumber, double SecondNumber)
        {
            var res = FirstNumber * SecondNumber;
            Console.WriteLine($"{FirstNumber} * {SecondNumber} = {res}");
            Save($"{FirstNumber} * {SecondNumber} = {res}");
        }
        public static void OstatokOtDeleniya(double FirstNumber, double SecondNumber)
        {
            var res = FirstNumber % SecondNumber;
            Console.WriteLine($"{FirstNumber} % {SecondNumber} = {res}");
            Save($"{FirstNumber} % {SecondNumber} = {res}");
        }
    }
}
