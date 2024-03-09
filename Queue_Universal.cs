using ClassLibraryLab10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    public class Queue_Universal : IEnumerable<MusicalInstrument>
    {
        Queue<MusicalInstrument> queue;
        int length;
        int capacity;

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Ошибка! Значение для поля Capacity не должно быть меньше 0");
                }
                else
                    capacity = value;
            }
        }

        public int Length { get => length; }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Queue_Universal()
        {
            queue = new Queue<MusicalInstrument>();
        }

        /// <summary>
        /// Конструктор с параметром (емкость очереди)
        /// </summary>
        /// <param name="Capacity"></param>
        public Queue_Universal(int Capacity)
        {
            queue = new Queue<MusicalInstrument>(Capacity);
        }

        /// <summary>
        /// Конструктор с параметрами (массив)
        /// </summary>
        /// <param name="list"></param>
        public Queue_Universal(params MusicalInstrument[] list)
        {
            Capacity = list.Length;
            length = 0;
            this.queue = new Queue<MusicalInstrument>(Capacity);
            for (int i = 0; i < Capacity; i++)
            {
                this.queue.Enqueue(list[i]);
                length++;
            }
        }

        /// <summary>
        /// Функция добавления элемента в очередь
        /// </summary>
        /// <param name="element"></param>
        /// <exception cref="ArgumentException"></exception>
        public void Add(MusicalInstrument element)
        {
            if (element == null) // проверка на пустоту
                throw new ArgumentException();
            if (Length < Capacity)
            {
                queue.Enqueue(element);
                length++;
            }
            else // если длина очереди больше или равна емкости, увеличивается емкость вдвое
            {
                Capacity *= 2;
                Queue<MusicalInstrument> temp = new Queue<MusicalInstrument>();
                foreach (MusicalInstrument item in queue)
                {
                    temp.Enqueue(item);
                }
                temp.Enqueue(element);
                queue.Clear();
                foreach (MusicalInstrument item in temp)
                {
                    queue.Enqueue(item);
                }
                length++;
            }        
        }

        /// <summary>
        /// Функция удаления первого в очереди элемента
        /// </summary>
        /// <returns></returns>
        public MusicalInstrument Delete()
        {                    
            length--;
            return queue.Dequeue();
        }

        /// <summary>
        /// Среднее количество струн в гитарах
        /// </summary>
        /// <returns></returns>
        public double GetAvarageStringsNumber()
        {
            double sum = 0;
            double count = 0;
            foreach (MusicalInstrument item in queue)
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
            foreach (MusicalInstrument item in queue)
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
            foreach (MusicalInstrument item in queue)
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
        /// Функция клонирования очереди
        /// </summary>
        /// <returns></returns>
        public Queue_Universal CloneQueue()
        {
            Queue_Universal clonedQueue = new Queue_Universal();

            foreach (MusicalInstrument item in queue)
            {
                clonedQueue.Add(item);
            }
            return clonedQueue;
        }

        /// <summary>
        /// Функция сортировки очереди
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public Queue_Universal SortQueue(Queue_Universal q)
        {
            MusicalInstrument[] array = q.ToArray();
            Array.Sort(array);
            Queue_Universal sortedQueue = new Queue_Universal(array);
            return sortedQueue;
        }

        /// <summary>
        /// Функция поиска в очереди 
        /// </summary>
        /// <param name="q"></param>
        /// <param name="elemetToSearch"></param>
        /// <returns></returns>
        public int SearchElement (Queue_Universal q, MusicalInstrument elemetToSearch)
        {
            int index = 0;
            bool exist = false;

            foreach (var item in q)
            {
                if (item == elemetToSearch)
                {
                    exist = true;
                    break;
                }
                index++;
            }
            if (exist)
                return index;
            else return -1;
        }

        /// <summary>
        /// Печать очереди
        /// </summary>
        public void PrintQueue()
        {
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }

        public IEnumerator<MusicalInstrument> GetEnumerator()
        {
            return ((IEnumerable<MusicalInstrument>)queue).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)queue).GetEnumerator();
        }
    }
}
