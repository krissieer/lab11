using ClassLibraryLab10;
using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace lab11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicalInstrument m1 = new MusicalInstrument("Арфа", 45);
            MusicalInstrument m2 = new MusicalInstrument("Виолончель", 85);
            MusicalInstrument m3 = new MusicalInstrument("Скрипка", 44);
            MusicalInstrument m4 = new MusicalInstrument("Барабан", 85);

            Guitar g1 = new Guitar();
            g1.IRandomInit();
            Guitar g2 = new Guitar();
            g2.IRandomInit();

            ElectricGuitar e1 = new ElectricGuitar();
            e1.IRandomInit();
            ElectricGuitar e2 = new ElectricGuitar();
            e2.IRandomInit();

            Piano p1 = new Piano();
            p1.IRandomInit();
            Piano p2 = new Piano();
            p2.IRandomInit();

            Console.WriteLine(" Создание очереди из элементов иерархии ");
            Queue_Universal queue1 = new Queue_Universal(new MusicalInstrument[] { m1, m2, g1, g2, e1, e2, p1, p2 });
            queue1.PrintQueue();
            Console.WriteLine();

            Console.WriteLine("Добавление объекта");
            Piano p3 = new Piano();
            p1.IRandomInit();
            queue1.Add(p3);
            queue1.PrintQueue();
            Console.WriteLine();

            Console.WriteLine("Удаление объекта");
            Console.WriteLine($"Удаленный элемент: {queue1.Delete()}");
            Console.WriteLine();
            queue1.PrintQueue();
            Console.WriteLine();

            Console.WriteLine("Запросы");

            Console.Write("Среднее количество струн всех гитар: ");
            double avarageStringsNumber = queue1.GetAvarageStringsNumber();
            Console.WriteLine(avarageStringsNumber);
            Console.WriteLine();

            Console.Write("Количество струн всех электрогитар c фиксированным источником питания: ");
            int stringsNumberSum = queue1.GetStringsNumberSum();
            Console.WriteLine(stringsNumberSum);
            Console.WriteLine();

            Console.WriteLine("Максимальное количество клавиш на фортепиано с октавной раскладко");
            int maxKeysNumber = queue1.GetMaxKeysNumber();
            Console.WriteLine(maxKeysNumber);
            Console.WriteLine();

            Console.WriteLine(" Клонирование очереди ");
            Queue_Universal clonedQueue = queue1.CloneQueue();
            clonedQueue.PrintQueue();
            Console.WriteLine();

            Console.WriteLine(" Cортировка ");
            Queue_Universal sortedQueue = new Queue_Universal(queue1.Length);
            sortedQueue = queue1.SortQueue(queue1);
            sortedQueue.PrintQueue();
            Console.WriteLine();

            Console.WriteLine(" Поиск ");
            MusicalInstrument elemetToSearch = g1;
            int resultSearch = sortedQueue.SearchElement(sortedQueue, elemetToSearch);
            if (resultSearch >= 0)
            {
                Console.WriteLine($"Объект ' {elemetToSearch} ' находится на {resultSearch + 1} месте");
            }
            else
                Console.WriteLine($"Объекта ' {elemetToSearch} ' не существует в очереди");

            Console.WriteLine();
            Console.WriteLine($"Count: {queue1.Length}");
            Console.WriteLine($"Capacity: {queue1.Capacity}");
            Console.WriteLine();


            Console.WriteLine("==== Создание отсортированного множества из элементов иерархии =====");
            MySortedSet<MusicalInstrument> set = new MySortedSet<MusicalInstrument> { m1, m2, m3, m4, g1, e1, p1 };
            set.PrintSet();
            Console.WriteLine($"Count: {set.Length}");
            Console.WriteLine();

            Console.WriteLine("Добавление объекта");
            MusicalInstrument m5 = new MusicalInstrument("Флейта", 23);
            set.Add(m5);
            set.PrintSet();
            Console.WriteLine($"Count: {set.Length}");
            Console.WriteLine();

            Console.WriteLine("Удаление объекта");
            Console.WriteLine("Введите элемент для удаления: ");
            MusicalInstrument m = new MusicalInstrument();
            m.Init();
            set.Delete(m);
            set.PrintSet();
            Console.WriteLine($"Count: {set.Length}");
            Console.WriteLine();

            Console.WriteLine("Запросы");

            Console.Write("Среднее количество струн всех гитар: ");
            double avarageStringsNumberSet = set.GetAvarageStringsNumber();
            Console.WriteLine(avarageStringsNumberSet);
            Console.WriteLine();

            Console.Write("Количество струн всех электрогитар c фиксированным источником питания: ");
            int stringsNumberSumSet = set.GetStringsNumberSum();
            Console.WriteLine(avarageStringsNumberSet);
            Console.WriteLine();

            Console.WriteLine("Максимальное количество клавиш на фортепиано с октавной раскладко");
            int maxKeysNumberSet = set.GetMaxKeysNumber();
            Console.WriteLine(avarageStringsNumberSet);
            Console.WriteLine();

            Console.WriteLine(" Клонирование очереди ");
            MySortedSet<MusicalInstrument> clonedSet = set.CloneSet();
            clonedSet.PrintSet();
            Console.WriteLine();

            Console.WriteLine(" Поиск ");
            MusicalInstrument elementToSearch = e1;
            set.PrintSet();
            int resultSearchSet = set.SearchElement(set, elementToSearch);
            if (resultSearchSet >= 0)
            {
                Console.WriteLine($"Объект ' {elementToSearch} ' находится на {resultSearchSet + 1} месте");
            }
            else
                Console.WriteLine($"Объекта ' {elementToSearch} ' не существует в множестве");
            Console.WriteLine();

            Console.WriteLine($"Count: {set.Length}");

            Console.WriteLine();
            Console.WriteLine("=== Измерение времени выполнения ===");
            TestCollectoins test1 = new TestCollectoins(1000);
            test1.MeasureTime();
        }
    }
}

