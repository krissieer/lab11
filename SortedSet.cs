using ClassLibraryLab10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    internal class MySortedSet<T>: IEnumerable<T>
    {
        SortedSet<T> set;

        int length;

        public int Length { get => length; }

        /// <summary>
        /// конструктор без параметров
        /// </summary>
        public MySortedSet()
        {
            set = new SortedSet<T>();
        }

        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="col"></param>
        public MySortedSet(IEnumerable<T> col)
        {
            set = new SortedSet<T>();
            foreach (T item in col)
            {
                this.set.Add(item);
                length++;
            }
        }

        /// <summary>
        /// Функция добавления элементов
        /// </summary>
        /// <param name="element"></param>
        /// <exception cref="ArgumentException"></exception>
        public void Add(T element)
        {
            if (element == null) // проверка на пустоту элемента
                throw new ArgumentException();
            if (!set.Contains(element)) // Проверка существовая элемента в множестве  
            {
                set.Add(element);
                length++;
            }
            else
            {
                Console.WriteLine($"Элемент {element} уже существует в множестве");
            }   
        }

        public MySortedSet<T> Delete(T item)
        {
            if (!set.Contains(item)) // проверка на существования элемента в множестве
            {
                Console.WriteLine("Элемент не найден");
            }
            else
            {
                Console.WriteLine($"Удаленный элемент: {item}");
                set.Remove(item);
                length--;
            }
            return this;
        }

        /// <summary>
        /// Печать множества
        /// </summary>
        public void PrintSet()
        {
            foreach (T item in set)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Среднее количество струн в гитарах
        /// </summary>
        /// <returns></returns>
        public double GetAvarageStringsNumber()
        {
            double sum = 0;
            double count = 0;
            foreach (T item in set)
            {
                if (item is Guitar g)
                {
                    sum += g.StringsNumber;
                    count++;
                }
            }
            return sum / count;
        }

        /// <summary>
        /// Сумма струн в электрогитарах с фиксированным источником питания
        /// </summary>
        /// <returns></returns>
        public int GetStringsNumberSum()
        {
            int sum = 0;
            foreach (T item in set)
            {
                ElectricGuitar e = item as ElectricGuitar;
                if ((e != null) && (e.PowerSupply == "Фиксированный источник питания"))
                {
                    sum += e.StringsNumber;
                }
            }
            return sum;
        }

        /// <summary>
        /// Максимальное количество клавиш в фортепиаоно с октавной раскладкой
        /// </summary>
        /// <returns></returns>
        public int GetMaxKeysNumber()
        {
            int max = 0;
            foreach (T item in set)
            {
                if (typeof(Piano) == item.GetType())
                {
                    Piano p = item as Piano;
                    if (p.KeyLayout == "Октавная")
                    {
                        if (p.KeysNumber > max)
                            max = p.KeysNumber;
                    }
                }
            }
            return max;
        }

        /// <summary>
        /// Функция клонирования множества
        /// </summary>
        /// <returns></returns>
        public MySortedSet<T> CloneSet()
        {
            MySortedSet<T> clonedSet = new MySortedSet<T>();

            foreach (T item in set)
            {
                clonedSet.Add(item);
            }
            return clonedSet;
        }

        /// <summary>
        /// Функция поиска элемента в множестве
        /// </summary>
        /// <param name="s"></param>
        /// <param name="elemetToSearch"></param>
        /// <returns></returns>
        public int SearchElement(MySortedSet<T> s, T elemetToSearch)
        {
            T[] array = s.ToArray();
            return Array.BinarySearch(array, elemetToSearch);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)set).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)set).GetEnumerator();
        }
    }
}
