using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Введите путь к файлу:");
            string path = Console.ReadLine();

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Ошибка: файл не найден");
            }

            string[] lines = File.ReadAllLines(path);

            if (lines.Length != 3)
            {
                throw new Exception("Ошибка: неправильный формат данных в файле");
            }

            double a = double.Parse(lines[0]);
            double b = double.Parse(lines[1]);
            double c = double.Parse(lines[2]);

            double discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
            {
                throw new Exception("Ошибка: дискриминант меньше 0");
            }
            else if (discriminant == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine("Решение: один корень x = " + x);
            }
            else
            {
                double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                Console.WriteLine("Решение: два корня x1 = " + x1 + ", x2 = " + x2);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: неправильный формат данных");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.ReadLine();
    }
}
