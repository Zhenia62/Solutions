using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            List<Round> roundList = new List<Round>();
            List<Circle> circaleList = new List<Circle>();
            List<Ring> ringList = new List<Ring>();
            List<Line> lineList = new List<Line>();
            List<Rectangle> rectangleList = new List<Rectangle>();

            ConsoleKey ki;


            do
            {
                Console.WriteLine("Выберите фигуру: \n Напишите название желаемой фигуры");
                Console.Write("-Окружность\n -Круг\n -Кольцо\n -Линия\n -Прямоугольник\n Вводите:");
                var choosing = Console.ReadLine();


                switch (choosing.ToLower())
                {
                    case "окружность":

                        Console.Clear();
                        var round = new Round();

                        Console.Write("Введите координату х: ");
                        var str = Console.ReadLine();
                        round.X = CheckDot(str);

                        Console.Write("Введите координату y: ");
                        str = Console.ReadLine();
                        round.Y = CheckDot(str);

                        Console.Write("Введите радиус: ");
                        str = Console.ReadLine();
                        round.R = CheckRadus(str);

                        Console.Write("Введите цвет: ");
                        round.Color = Console.ReadLine();

                        round = new Round(round.X, round.Y, round.R, round.Color);
                        roundList.Add(round);
                        Console.WriteLine("Если вы хотите выйти, то нажмите на (Esc), если продолжить, то (N)");
                        ki = Console.ReadKey().Key;
                        Console.WriteLine();

                        break;
                    case "круг":

                        Console.Clear();
                        var circle = new Circle();

                        Console.Write("Введите координату х: ");
                        str = Console.ReadLine();
                        circle.X = CheckDot(str);

                        Console.Write("Введите координату y: ");
                        str = Console.ReadLine();
                        circle.Y = CheckDot(str);

                        Console.Write("Введите радиус: ");
                        str = Console.ReadLine();
                        circle.R = CheckRadus(str);

                        Console.Write("Введите цвет: ");
                        circle.Color = Console.ReadLine();

                        circle = new Circle(circle.X, circle.Y, circle.R, circle.Color);
                        circaleList.Add(circle);
                        Console.WriteLine("Если вы хотите выйти, то нажмите на (Esc), если продолжить, то (N)");
                        ki = Console.ReadKey().Key;
                        Console.WriteLine();

                        break;
                    case "кольцо":

                        Console.Clear();
                        var ring = new Ring();

                        Console.Write("Введите координату х: ");
                        str = Console.ReadLine();
                        ring.X = CheckDot(str);

                        Console.Write("Введите координату y: ");
                        str = Console.ReadLine();
                        ring.Y = CheckDot(str);

                        Console.Write("Введите радиус: ");
                        str = Console.ReadLine();
                        ring.R = CheckRadus(str);

                        Console.Write("Введите дополнительный радиус: ");
                        str = Console.ReadLine();
                        ring.DopRadius = CheckRadus(str);

                        Console.Write("Введите цвет: ");
                        ring.Color = Console.ReadLine();

                        ring = new Ring(ring.X, ring.Y, ring.R, ring.DopRadius, ring.Color);
                        ringList.Add(ring);
                        Console.WriteLine("Если вы хотите выйти, то нажмите на (Esc), если продолжить, то (N)");
                        ki = Console.ReadKey().Key;
                        Console.WriteLine();

                        break;
                    case "линия":

                        Console.Clear();
                        var line = new Line();

                        Console.Write("Первая точка. Введите координату х: ");
                        str = Console.ReadLine();
                        line.X = CheckDot(str);

                        Console.Write("Первая точка. Введите координату y: ");
                        str = Console.ReadLine();
                        line.Y = CheckDot(str);

                        Console.Write("Вторая точка. Введите координату х: ");
                        str = Console.ReadLine();
                        line.X2 = CheckDot(str);

                        Console.Write("Втораяя точка. Введите координату y: ");
                        str = Console.ReadLine();
                        line.Y2 = CheckDot(str);

                        line = new Line(line.X, line.Y, line.X2, line.Y2);
                        lineList.Add(line);
                        Console.WriteLine("Если вы хотите выйти, то нажмите на (Esc), если продолжить, то (N)");
                        ki = Console.ReadKey().Key;
                        Console.WriteLine();

                        break;

                    case "прямоугольник":
                        Console.Clear();
                        var rectangle = new Rectangle();

                        Console.Write("Первая точка. Введите координату х: ");
                        str = Console.ReadLine();
                        rectangle.X = CheckDot(str);

                        Console.Write("Первая точка. Введите координату y: ");
                        str = Console.ReadLine();
                        rectangle.Y = CheckDot(str);

                        Console.Write("Вторая точка. Введите координату х: ");
                        str = Console.ReadLine();
                        rectangle.X2 = CheckDot(str);

                        Console.Write("Втораяя точка. Введите координату y: ");
                        str = Console.ReadLine();
                        rectangle.Y2 = CheckDot(str);

                        rectangle = new Rectangle(rectangle.X, rectangle.Y, rectangle.X2, rectangle.Y2);
                        lineList.Add(rectangle);
                        Console.WriteLine("Если вы хотите выйти, то нажмите на (Esc), если продолжить, то (N)");
                        ki = Console.ReadKey().Key; ;
                        break;
                    default:
                        Console.WriteLine("неккоректный ввод!");
                        Console.WriteLine("Если вы хотите выйти, то нажмите на (Esc), если продолжить, то (N)");
                        ki = Console.ReadKey().Key;
                        Console.WriteLine();
                        break;
                }
            } while (ki != ConsoleKey.Escape);
        }

        static int CheckDot(string str)
        {
            bool success = double.TryParse(str, out double number);
            while ((string.IsNullOrEmpty(str)) || (success == false))
            {
                Console.WriteLine("Incorrect input!");
                str = Console.ReadLine();
            }
            return int.Parse(str);
        }

        static double CheckRadus(string str)
        {
            bool success = double.TryParse(str, out double number);
            while ((string.IsNullOrEmpty(str)) || (success == false) || (double.Parse(str) <= 0))
            {
                Console.WriteLine("Incorrect input!");
                str = Console.ReadLine();
            }
            return double.Parse(str);
        }
    }
}

