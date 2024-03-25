using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Intrinsics.Arm;

namespace module_1
{
    class Program
    {
        // 1.Задана цілочисельна квадратна матриця Арозмірності n.
        // Вивести номери тих  стрічок,  елементи  яких  утворюють  симетричну  послідовність (паліндром).
        public static void PrintPalindromeRows(int[,] A)
        {
            int n = A.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= n / 2 && n != 0; j++)
                {
                    if (A[i, j] != A[i, n - j - 1])
                    {
                        break;
                    }
                }
                Console.WriteLine($"Palindrome detected on row {i}");
            }
        }

        //2.Визначити  інтерфейс ITovar,  який  містить  властивості  доступу  до артикулу,
        //назвитовару та країни-виробника, а також метод обчислення вартості.
        //Класи Одяг та Продукти реалізують даний інтерфейс і крім того містять:
        //одяг –розмір, кількість одиниць, ціну за одиницю;
        //продукти –вартість за кг та сумарна вага.
        //Клас Супермаркет містить назву магазину та колекцію товарів і реалізує IEnumerable.
        //У текстовомуфайлі задана інформація про товари супермаркету.
        //Вивести товари, впорядковані за артикулом, використовуючи для сортування власний клас-компаратор.
        //-Вивести лише одяг заданого розміру,впорядкований за зменшенням ціни.
        //-Для кожної країни-виробника обчислити сумарну вартість товарів та зберегти у Dictionary.
        public interface ITovar
        {
            public string Articul { get; set; }
            public string Name { get; set; }
            public string Country { get; set; }

            public double CalcPrice();
        }


        public class Product : ITovar
        {
            public string Articul { get; set; }
            public string Name { get; set; }
            public string Country { get; set; }

            public int WeightKg { get; set; }
            public double PricePerKg { get; set; }

            public double CalcPrice()
            {
                return WeightKg * PricePerKg;
            }
        }


        public class Clothing : ITovar
        {
            public string Articul { get; set; }
            public string Name { get; set; }
            public string Country { get; set; }

            public string Size { get; set; }
            public int Qty { get; set; }
            public double PricePer1 { get; set; }

            public double CalcPrice()
            {
                return Qty * PricePer1;
            }
        }


        public class Supermarket<ITovar> : IEnumerable<ITovar>
        {
            public string Name { get; set; }
            private List<ITovar> tovarList = new List<ITovar>();
            public IEnumerator<ITovar> GetEnumerator() => tovarList.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            void ReadFromFile(string fn)
            {
                string dirpath = "/Users/bondarth/Desktop/fpmi/2 kurs/c# programming/class_csharp/class_csharp/";
                string[] lines = File.ReadAllLines(dirpath + "tovar.txt");

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] arguments = lines[i].Split(" ");

                    if (arguments[0] == "Product")
                    {
                        tovarList.Add(new Product()
                        {
                            Name = arguments[1],
                            Country = arguments[2],
                            Articul = arguments[3],
                            PricePerKg = Convert.ToDouble(arguments[4]),
                            WeightKg = Convert.ToInt32(arguments[5])
                        });
                    }
                    else if (arguments[0] == "Clothing")
                    {
                        tovarList.Add(new Clothing
                        {
                            Name = arguments[1],
                            Country = arguments[2],
                            Articul = arguments[3],
                            Size = arguments[4],
                            Qty = Convert.ToInt32(arguments[5]),
                            PricePer1 = Convert.ToDouble(arguments[6])
                        });
                    }
                }
            }

        }

        static void Main(string[] args)
        {
            Console.Write("n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    Console.Write($"[{i},{j}]: ");
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            PrintPalindromeRows(matrix);



        }
    }
}