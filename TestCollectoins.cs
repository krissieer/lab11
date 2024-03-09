using ClassLibraryLab10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab11
{
    public class TestCollectoins
    {
        Queue<Guitar> collection1 = new Queue<Guitar>();
        Queue<string> collection2 = new Queue<string>();
        SortedSet<MusicalInstrument> collection3 = new SortedSet<MusicalInstrument>();
        SortedSet<string> collection4 = new SortedSet<string>();    

        Stopwatch sw = Stopwatch.StartNew();
        Guitar? first, middle, last;
        Guitar noExist = new Guitar();

        public TestCollectoins(int length)
        {
            for (int i = 0; i < length; i++)
            {
                try
                {
                    Guitar g = new Guitar();
                    g.IRandomInit();
                    g.Name += i.ToString();
                    collection1.Enqueue(g);
                    collection2.Enqueue(g.ToString());
                    collection3.Add(g.GetBase);
                    collection4.Add(g.GetBase.ToString());

                    if (i == 0)
                        first = (Guitar)g.Clone(); // Первый элемент в коллекции
                    if (i == length / 2)
                        middle = (Guitar)g.Clone(); // Серединный элемент коллекции
                    if (i == length - 1)
                        last = (Guitar)g.Clone(); //Последний элемент коллекции
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void MeasureTime()
        {
            Console.WriteLine("=== Поиск первого элемента ===");   
            sw.Restart();
            bool isFindFirstCol1 = collection1.Contains(first);
            sw.Stop();
            if (isFindFirstCol1)
                Console.WriteLine($"Элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"Элемент не найден за {sw.ElapsedTicks}");

            sw.Restart();
            bool isFindFirstCol2 = collection2.Contains(first.ToString());
            sw.Stop();
            if (isFindFirstCol2)
                Console.WriteLine($"Элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"Элемент не найден за {sw.ElapsedTicks}");

            sw.Restart();
            bool isFindFirstCol3 = collection3.Contains(first.GetBase);
            sw.Stop();
            if (isFindFirstCol3)
                Console.WriteLine($"Элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"Элемент не найден за {sw.ElapsedTicks}");

            sw.Restart();
            bool isFindFirstCol4 = collection4.Contains(first.GetBase.ToString());
            sw.Stop();
            if (isFindFirstCol4)
                Console.WriteLine($"Элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"Элемент не найден за {sw.ElapsedTicks}");


            Console.WriteLine("=== Поиск среднего элемента ===");
            sw.Restart();
            bool isFindMiddlCol1 = collection1.Contains(middle);
            sw.Stop();
            if (isFindMiddlCol1)
                Console.WriteLine($"Элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"Элемент не найден за {sw.ElapsedTicks}");

            sw.Restart();
            bool isFindMiddleCol2 = collection2.Contains(middle.ToString());
            sw.Stop();
            if (isFindMiddleCol2)
                Console.WriteLine($"Элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"Элемент не найден за {sw.ElapsedTicks}");

            sw.Restart();
            bool isFindMiddleCol3 = collection3.Contains(middle.GetBase);
            sw.Stop();
            if (isFindMiddleCol3)
                Console.WriteLine($"Элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"Элемент не найден за {sw.ElapsedTicks}");

            sw.Restart();
            bool isFindMiddlseCol4 = collection4.Contains(middle.GetBase.ToString());
            sw.Stop();
            if (isFindMiddlseCol4)
                Console.WriteLine($"Элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"Элемент не найден за {sw.ElapsedTicks}");


            Console.WriteLine("=== Поиск последнего элемента ===");
            sw.Restart();
            bool isFindLastCol1 = collection1.Contains(last);
            sw.Stop();
            if (isFindLastCol1)
                Console.WriteLine($"Элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"Элемент не найден за {sw.ElapsedTicks}");

            sw.Restart();
            bool isFindLastCol2 = collection2.Contains(last.ToString());
            sw.Stop();
            if (isFindLastCol2)
                Console.WriteLine($"Элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"Элемент не найден за {sw.ElapsedTicks}");

            sw.Restart();
            bool isFindLastCol3 = collection3.Contains(last.GetBase);
            sw.Stop();
            if (isFindLastCol3)
                Console.WriteLine($"Элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"Элемент не найден за {sw.ElapsedTicks}");

            sw.Restart();
            bool isFindLastCol4 = collection4.Contains(last.GetBase.ToString());
            sw.Stop();
            if (isFindLastCol4)
                Console.WriteLine($"Элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"Элемент не найден за {sw.ElapsedTicks}");


            Console.WriteLine("=== Поиск несуществующего элемента ===");
            sw.Restart();
            bool isFindNoExistCol1 = collection1.Contains(noExist);
            sw.Stop();
            if (isFindNoExistCol1)
                Console.WriteLine($"Элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"Элемент не найден за {sw.ElapsedTicks}");

            sw.Restart();
            bool isFindNoExistCol2 = collection2.Contains(noExist.ToString());
            sw.Stop();
            if (isFindNoExistCol2)
                Console.WriteLine($"Элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"Элемент не найден за {sw.ElapsedTicks}");

            sw.Restart();
            bool isFindNoExistCol3 = collection3.Contains(noExist.GetBase);
            sw.Stop();
            if (isFindNoExistCol3)
                Console.WriteLine($"Элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"Элемент не найден за {sw.ElapsedTicks}");

            sw.Restart();
            bool isFindNoExistCol4 = collection4.Contains(noExist.GetBase.ToString());
            sw.Stop();
            if (isFindNoExistCol4)
                Console.WriteLine($"Элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"Элемент не найден за {sw.ElapsedTicks}");
        }
    }
}
