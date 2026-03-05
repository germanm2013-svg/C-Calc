using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine($"\t === ЖЕСТКИЙ КРУТОЙ КАЛЬКУЛЯТОР ===");
            Console.WriteLine("\tНаш калькулятор может:");
            Console.WriteLine("\tCкладывать, ");
            Console.WriteLine("\tВычитать, ");
            Console.WriteLine("\tУмножать, ");
            Console.WriteLine("\tДелить, ");
            Console.WriteLine("\tВычислять степени, ");
            Console.WriteLine("\tСчитать факториал, ");
            Console.WriteLine("\tИ все такое. ");
            Console.WriteLine("введите пример:");
            Console.WriteLine("*n1 (действие/команда) n2*"); // лучше сделать систему ввода как написано левее чтобы пользователю было понятно
            string? deystvie = Console.ReadLine();
            deystvie = deystvie ?? "0 + 0";
            string[] mathDate = deystvie.Split(' ');
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
                case "factorial":
                    {
                        Calculator.Factorial(int.Parse(mathDate[0]));
                        break;
                    }
                case "stepen":
                    {
                        Calculator.Stepen(int.Parse(mathDate[0]), int.Parse(mathDate[2]));
                        break;
                    }
                case "IBM":
                    {
                        Calculator.CalculatorOfIBM(int.Parse(mathDate[0]), int.Parse(mathDate[2]));
                        break;
                    }
            }

        }

    }
    public class Calculator
    {
        public static void Stepen(int num,int stepen)
        {
            int res = num;
            for (int i = 0; i < stepen - 1; i++)
            {
                res *= num;
            }
        }
        public static void CalculatorOfIBM(int kg,int height)
        {
            var res = kg / height;
            Console.WriteLine(res);
            Save($"Индекс массы тела равен {res}");
        }
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
        public static void Factorial(int num)
        {
            int Facrotial = 1;
            for (int i = 1;i <= num; i++)
            {
                Facrotial *= i;
            }
            Console.WriteLine(Facrotial);
        }
    }
}
