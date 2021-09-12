using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _053505_Mazurenko_Lab5.Interfaces;

namespace _053505_Mazurenko_Lab5.Collections
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string message)
        : base(message)
        {
        }
    }
    public class Item<T>
    {
        public Item(T item) => data = item;

        public T data;

        public Item<T> Next { get; set; }
    }
    public class MyCustomCollection<T> : ICustomCollection<T>
    {
        public Item<T> Head = null;
        public Item<T> Tail = null;
        public T this[int index] { 
            get {
                if(index > Count)
                {
                    throw new IndexOutOfRangeException();
                }
                Item<T> current = Head;
                for (int i = 0; i < index; i++)
                    current = current.Next;
                pos = index;
                return current.data;
            }
            set {
                if (index <= Count)
                {
                    Item<T> current = Head;
                    for (int i = 0; i < index; i++)
                        current = current.Next;
                    current.data = value;
                }  //TODO          
            }
        }
      //  int index;

        public void Add(T item)
        {
            Item<T> item_ = new Item<T>(item);
            item_.Next = null;
            if(Head == null)
            {
                Head = item_;
            } 
            else
            {
                if (Tail == null)
                {
                    Head.Next = item_;
                    Tail = item_;
                }
                else
                {
                    Tail.Next = item_;
                    Tail = item_;
                }
            }
           // Count++;
        }

        public void Remove(T item)
        {
            Item<T> current = Head;

            while(!current.Next.data.Equals(item))
            {
                if (current.Next.Next == null && !current.Next.data.Equals(item))
                {
                    throw new ItemNotFoundException("Item wasn't found in the current collection!");
                }
                current = current.Next;
            }
            if(current.Equals(Tail))
            {
                Tail = current;
            }
            current.Next = current.Next.Next;
          //  Count--;
        }

        private int pos = 0;
        public void Reset() => pos = 0;
        public void Next() => pos++;
        public T Current() {
            Item<T> current = Head;
            for (int i = 0; i != pos; i++)
                current = current.Next;
            return current.data;
        }

        public T RemoveCurrent() {
            Item<T> current = Head;

            for (int i = 0; i < pos - 1; i++)
                current = current.Next;

            if (current.Equals(Tail))
            {
                Tail = current;
            }
            current.Next = current.Next.Next;
          //  Count--;

            return current.data;
        }
        public int Count { get {
                Item<T> current = Head;
                int size = 1;
                while (current.Next != null)
                {
                    current = current.Next;
                    size++;
                }
                return size;
            }
        }
    }
}
