using System.Collections;
using static CS_Lab3.ICollection;

namespace CS_Lab3
{
    /*
    public interface IEnumerator
    {
        object Current { get; }
        bool MoveNext();
        void Reset();
    }
    */
    public interface IENumerable
    {
        IEnumerator GetEnumerator();
    }
    public interface ICollection : IENumerable
    {
        public delegate void ElementAdded();


        public delegate void ElementChanged();


        public delegate void ElementRemoved();

    }
    public interface IList : ICollection
    {
        public void Add(Object elem);
        public void Change(int i, Object elem);
        public void Remove(int i);
    }
    public interface IDictionary : ICollection
    {
        public void Add(Object elem1, Object elem2);
        public void Change(int i, Object elem1, Object elem2);
        public void Remove(int i);
    }
    public class List : IList
    {
        public Object[] list;

        public IEnumerator GetEnumerator() => list.GetEnumerator();

        public event ElementAdded elemAddedToListEvent;
        public event ElementChanged elemChangedFromListEvent;
        public event ElementRemoved elemRemovedFromListEvent;


        static int count = 0, count1 = 0, count2 = 0;
        public List(int n)
        {

            list = new Object[n];
        }
        public void addedToList()
        {
            for (int i = 0; i < count; i++)
            {
                if (elemAddedToListEvent != null)
                {
                    elemAddedToListEvent();
                }
            }
        }
        public void changedFromList()
        {
            for (int i = 0; i < count1; i++)
            {
                if (elemChangedFromListEvent != null)
                {
                    elemChangedFromListEvent();
                }
            }
        }
        public void removedFromList()
        {
            for (int i = 0; i < count2; i++)
            {
                if (elemRemovedFromListEvent != null)
                {
                    elemRemovedFromListEvent();
                }

            }
        }

        public void Add(Object elem)
        {
            list[count] = elem;
            count++;
        }

        public void Change(int i, Object elem)
        {
            list[i] = elem;
            count1++;
        }
        public void Remove(int i)
        {
            list[i] = null;
            count2++;
        }
        public void addedResult()
        {
            Console.WriteLine("Element added to List");
        }
        public void changedResult()
        {
            Console.WriteLine("Element from List changed");
        }
        public void removedResult()
        {
            Console.WriteLine("Element from List removed");
        }
    }

    public class Queue : ICollection
    {
        public Object[] queue;

        static int count = 0, count1 = 0, count2 = 0;
        public IEnumerator GetEnumerator() => queue.GetEnumerator();

        public event ElementAdded elemAddedToQueueEvent;
        public event ElementChanged elemChangedFromQueueEvent;
        public event ElementRemoved elemRemovedFromQueueEvent;

        public Queue(int n)
        {
            queue = new Object[n];
        }
        public void addedToQueue()
        {
            for (int i = 0; i < count; i++)
            {
                if (elemAddedToQueueEvent != null)
                {
                    elemAddedToQueueEvent();
                }
            }
        }
        public void changedFromQueue()
        {
            for (int i = 0; i < count1; i++)
            {
                if (elemChangedFromQueueEvent != null)
                {
                    elemChangedFromQueueEvent();
                }
            }
        }
        public void removedFromQueue()
        {
            for (int i = 0; i < count2; i++)
            {
                if (elemRemovedFromQueueEvent != null)
                {
                    elemRemovedFromQueueEvent();
                }

            }
        }

        public void Push(Object elem)
        {
            queue[count] = elem;
            count++;
        }

        public void Front(Object elem)
        {
            queue[0] = elem;
            count1++;
        }
        public void Pop()
        {
            queue[0] = null;
            count2++;
        }
        public void addedResult()
        {
            Console.WriteLine("Element added to Queue");
        }
        public void changedResult()
        {
            Console.WriteLine("First Element from Queue changed");
        }
        public void removedResult()
        {
            Console.WriteLine("First Element from Queue removed");
        }
    }
    public class Dictionary : IDictionary
    {
        public Dictionary<Object, Object> map;


        static int count = 0, count1 = 0, count2 = 0;

        public IEnumerator GetEnumerator() => map.GetEnumerator();

        public event ElementAdded elemAddedToDictionaryEvent;
        public event ElementChanged elemChangedFromDictionaryEvent;
        public event ElementRemoved elemRemovedFromDictionaryEvent;

        public Dictionary()
        {
            map = new Dictionary<Object, Object>();
        }
        public void addedToDictionary()
        {
            for (int i = 0; i < count; i++)
            {
                if (elemAddedToDictionaryEvent != null)
                {
                    elemAddedToDictionaryEvent();
                }
            }
        }
        public void changedFromDictionary()
        {
            for (int i = 0; i < count1; i++)
            {
                if (elemChangedFromDictionaryEvent != null)
                {
                    elemChangedFromDictionaryEvent();
                }
            }
        }
        public void removedFromDictionary()
        {
            for (int i = 0; i < count2; i++)
            {
                if (elemRemovedFromDictionaryEvent != null)
                {
                    elemRemovedFromDictionaryEvent();
                }

            }
        }
        public void Add(Object elem1, Object elem2)
        {

            map.Add(elem1, elem2);
            count++;
        }
        public void Change(int i, Object elem1, Object elem2)
        {
            map[i] = new Dictionary<Object, Object>() { { elem1, elem2 } };
            count1++;
        }
        public void Remove(int i)
        {
            map[i] = 9999;
            map.Remove(9999);
            count2++;
        }

        public void addedResult()
        {
            Console.WriteLine("Element added to Dictionary");
        }
        public void changedResult()
        {
            Console.WriteLine("Element from Dictionary changed");
        }
        public void removedResult()
        {
            Console.WriteLine("Element from Dictionary removed");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List\n");

            List list = new List(10);
            list.elemAddedToListEvent += list.addedResult;
            list.elemChangedFromListEvent += list.changedResult;
            list.elemRemovedFromListEvent += list.removedResult;

            list.Add(1);
            list.Add(1);
            list.Add(1);

            list.Change(1, "5");
            list.Change(2, 10);
            list.Remove(0);

            list.addedToList();
            list.changedFromList();
            list.removedFromList();


            Console.WriteLine();

            Console.WriteLine("Dictionary\n");

            Dictionary dict = new Dictionary();
            dict.elemAddedToDictionaryEvent += dict.addedResult;
            dict.elemChangedFromDictionaryEvent += dict.changedResult;
            dict.elemRemovedFromDictionaryEvent += dict.removedResult;

            dict.Add(7, 8);
            dict.Add(9, "5");


            dict.Change(0, 1, "5");
            dict.Change(0, "5", false);
            dict.Change(1, "d", "g");
            dict.Remove(0);

            dict.addedToDictionary();
            dict.changedFromDictionary();
            dict.removedFromDictionary();

            Console.WriteLine();

            Console.WriteLine("Queue\n");

            Queue queue = new Queue(10);
            queue.elemAddedToQueueEvent += queue.addedResult;
            queue.elemChangedFromQueueEvent += queue.changedResult;
            queue.elemRemovedFromQueueEvent += queue.removedResult;

            queue.Push(8);
            queue.Push("5");

            queue.Front(0);
            queue.Front(false);
            queue.Front("g");
            queue.Pop();

            queue.addedToQueue();
            queue.changedFromQueue();
            queue.removedFromQueue();
        }
    }
}