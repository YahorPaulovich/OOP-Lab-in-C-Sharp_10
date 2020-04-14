using System;
using System.Linq;
using System.Collections;

namespace LINQtoObject//Вариант 14
{/*№ 11 LINQ to Object*/
    class Program
    {/*Задание
1). Задайте массив типа string, содержащий 12 месяцев (June, July, May,
December, January ….). Используя LINQ to Object напишите запрос выбирающий
последовательность месяцев с длиной строки равной n, запрос возвращающий
только летние и зимние месяцы, запрос вывода месяцев в алфавитном порядке,
запрос посчитывающий месяцы содержащие букву «u» и длиной имени не менее
4-х..
2). Создайте коллекцию List<T> и параметризируйте ее типом (классом)
из лабораторной №3 (при необходимости реализуйте нужные интерфейсы).
3). На основе LINQ сформируйте следующие запросы*/

        /*множества только с четными/нечетными элементами;
        множества, содержащие отрицательные элементы.
        Количество пустых множеств
        Список множеств длины которых принадлежат заданному
        диапазону
        Минимальное множество*/

        /*Краткие теоретические сведения*/
        static void Main(string[] args)
        {
            var Months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            Console.WriteLine("Массив типа string, содержащий 12 месяцев \n");
            foreach (string s in Months)
                Console.WriteLine(s);
            Console.WriteLine(new string('-',20));

            //запрос выбирающий последовательность месяцев с длиной строки равной n
            var LengthFive = Months.Where(x => x.Length == 5);
            Console.WriteLine("запрос выбирающий последовательность месяцев с длиной строки равной n \n");
            foreach (string str in LengthFive)
                Console.WriteLine(str);
            Console.WriteLine(new string('-', 20));

            //запрос возвращающий только летние и зимние месяцы
            Console.WriteLine("запрос возвращающий только летние и зимние месяцы \n");
            var SummerAndWintersOnly = Months.Where(x => x.Contains("January") | x.Contains("February") | x.Contains("June") | x.Contains("July") | x.Contains("August") | x.Contains("December"));
            foreach (string s in SummerAndWintersOnly)
                Console.WriteLine(s);//January February June July August December
            Console.WriteLine(new string('-', 20));   

            //запрос вывода месяцев в алфавитном порядке
            System.Collections.Generic.IEnumerable<string> InAlphabetOrder = Months.OrderBy(s => s);
            Console.WriteLine("запрос вывода месяцев в алфавитном порядке \n");
            foreach (string s in InAlphabetOrder)
                Console.WriteLine(s);
            Console.WriteLine(new string('-', 20));

            //запрос посчитывающий месяцы содержащие букву «u» и длиной имени не менее 4-х..        
            var query4 = Months.Where(x => x.Contains('u') && x.Length > 4);
            Console.WriteLine("запрос посчитывающий месяцы содержащие букву «u» и длиной имени не менее 4-х..  \n");
            foreach (string s in query4)
                Console.WriteLine(s);
            Console.WriteLine(new string('-', 20));


            ///////////////////////////////////////////////////////////////////


            var QueueList = new System.Collections.Generic.HashSet<Queue<int>>();
            for (int i = -5; i < 10; i++)
            {
                QueueList.Add(i);
            }

            Console.WriteLine("Коллекция List<T> параметризированная типом (классом) из лабораторной №3");
            foreach (int item in QueueList)
            {
                Console.Write($" {item}");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 20));

            //запрос множества только с четными/нечетными элементами;                       
            Console.WriteLine("запрос множества только с четными/нечетными элементами;");
            var selectedEven = QueueList.Where(i => i.doubleValue % 2 == 0);
            foreach (int s in selectedEven)
                Console.Write($" {s}");
            Console.WriteLine();

            var selectedNotEven = QueueList.Where(i => i.doubleValue % 2 != 0);
            foreach (int s in selectedNotEven)
                Console.Write($" {s}");

            Console.WriteLine();
            Console.WriteLine(new string('-', 20));

            //запрос множества, содержащие отрицательные элементы;
            Console.WriteLine("запрос множества, содержащие отрицательные элементы;");
            var negativeElements = QueueList.Where(i => i.doubleValue < 0);
            foreach (int s in negativeElements)
                Console.Write($" {s}");
            Console.WriteLine();
            Console.WriteLine(new string('-', 20));

            //запрос количество пустых множеств;           
            Console.WriteLine("запрос количество пустых множеств;");
            var emptySets = QueueList.Where(i => i.doubleValue == null);
            foreach (int s in emptySets)
                Console.Write($" {s}");
            Console.WriteLine();
            Console.WriteLine(new string('-', 20));

            //запрос список множеств длины которых принадлежат заданному диапазону;
            Console.WriteLine("запрос список множеств длины которых принадлежат заданному диапазону;");
            var belongToAGivenRange = QueueList.Where(i => i.doubleValue > 0 && i.doubleValue < 5);
            foreach (int s in belongToAGivenRange)
                Console.Write($" {s}");
            Console.WriteLine();
            Console.WriteLine(new string('-', 20));

            //запрос минимальное множество.
            Console.WriteLine("запрос минимальное множество.");
            var minimalSet = QueueList.Where(i => i.doubleValue < 0);
            foreach (int s in minimalSet)
                Console.Write($" {s}");

            Console.ReadKey();
        }
    }
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public string Name { get; set; }
    }
    public class Queue<T> : System.Collections.Generic.IEnumerable<T>
    {
        public static int Id { get; set; }

        Node<T>[] data;
        Node<T> head; // головной/первый элемент
        Node<T> tail; // последний/хвостовой элемент
        int count;

        public Queue()
        {
            data = new Node<T>[5];

            Id = Id + 1;
        }

        public Queue(T First)
        {
            data = new Node<T>[5];
            if (head != null)
            {
                head.Data = First;
            }
            Id = Id + 1;
        }

        public Queue(T First, T Last)
        {
            data = new Node<T>[5];
            head.Data = First;
            tail.Data = Last;

            Id = Id + 1;
        }

        // индексатор 1
        public Node<T> this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
        // индексатор 2
        public Node<T> this[string name]
        {
            get
            {
                Node<T> node = null;
                foreach (var n in data)
                {
                    if (n?.Name == name)
                    {
                        node = n;
                        break;
                    }
                }
                return node;
            }
        }

        public static Queue<double> operator +(Queue<T> first, Queue<T> second)
        {
            return new Queue<double> { doubleValue = first.doubleValue + second.doubleValue };
        }
        public static double operator +(Queue<T> first, double d)
        {
            return first.doubleValue + d;
        }
        public static double operator +(double d, Queue<T> second)
        {
            return d + second.doubleValue;
        }

        public static bool operator >(Queue<T> first, Queue<T> second)
        {
            if (first.intValue > second.intValue)
                return true;
            else
                return false;
        }
        public static bool operator <(Queue<T> first, Queue<T> second)
        {
            if (first.intValue < second.intValue)
                return true;
            else
                return false;
        }

        public static Queue<T> operator ++(Queue<T> d)
        {
            return new Queue<T> { doubleValue = d.doubleValue + 1, intValue = d.intValue + 1, stringValue = d.stringValue };
        }

        public static implicit operator Queue<T>(double d)//
        {
            return new Queue<T> { doubleValue = d };
        }
        public static explicit operator double(Queue<T> Q) //explicit --- int x = (int)queue1; implicit -- int x = queue1;
        {
            return Q.doubleValue;
        }

        public double doubleValue { get; set; }
        public int intValue { get; set; }
        public T stringValue { get; set; } //Обобщённый тип данных

        // добавление в очередь
        public void Enqueue(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> tempNode = tail;
            tail = node;
            if (count == 0)
                head = tail;
            else
                tempNode.Next = tail;
            count++;
        }
        // удаление из очереди
        public T Dequeue()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T output = head.Data;
            head = head.Next;
            count--;
            return output;
        }
        // получаем первый элемент
        public T First
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return head.Data;
            }
        }
        // получаем последний элемент
        public T Last
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return tail.Data;
            }
        }
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        //public void GetInfo(Queue<T> Queue)
        //{
        //    Console.WriteLine($"Айди: {person} ");
        //    //return result;
        //}     

        public Queue<T> CopySortInDescendingOrder(Queue<T> Queue)
        {/*копирование одной очереди в другую с сортировкой в убывающем порядке;*/
            Queue<T> tempqueue = new Queue<T>();
            if (count == 0)
                throw new InvalidOperationException();
            while (Queue.Count > 0)
                tempqueue.Enqueue(Queue.Dequeue());

            //queue2 = new Queue<T>(queue1);
            return tempqueue;
        }
    }
}
