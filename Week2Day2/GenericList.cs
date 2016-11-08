using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Day2
{
    public class GenericList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IList, ICollection, IEnumerable
    {
        private T[] collection;

        private int capacity = 2;

        private int nextIndex = 0;

        private event Action<T> OnAdd;

        private event Action<T> OnDelete;

        private event Action<int, int> OnResize;

        public void ResizeHandler(int oldCapacity, int newCapacity)
        {
            Console.WriteLine($"ResizeHandler: old: {oldCapacity} new {newCapacity}");
        }

        public void AddHandler(T item)
        {
            Console.WriteLine($"AddHandler: old: {item}");

        }

        public void DeleteHandler(T item)
        {
            Console.WriteLine($"Delete Handler: {item}");
            Console.WriteLine(string.Join(",", collection));

        }

        public GenericList()
        {
            collection = new T[capacity];
            InitHandlers();
        }

        private void InitHandlers()
        {
            OnResize += ResizeHandler;
            OnAdd += AddHandler;
            OnDelete += DeleteHandler;
        }

        public int Count
        {
            get
            {
                return nextIndex;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        public object SyncRoot
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsSynchronized
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        object IList.this[int index]
        {
            get
            {
                if(index > nextIndex || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                return collection[index];
            }

            set
            {
                if (index > nextIndex || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                collection[index] = (T)value;
            }
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);

                return collection[index];
            }

            set
            {
                ValidateIndex(index);

                collection[index] = (T)value;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index >= nextIndex || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(collection, item);
        }

        public void Insert(int index, T item)
        {
            if (index > nextIndex || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (capacity == Count)
            {
                Resize();
            }

            for (int i = nextIndex; i > index; i--)
            {
                collection[i] = collection[i - 1];
            }

            collection[index] = item;

            nextIndex++;
        }

        public void RemoveAt(int index)
        {
            if(index >= nextIndex)
            {
                throw new IndexOutOfRangeException();
            }

            DoRemove(index);
        }

        public void Add(T item)
        {
            Console.WriteLine($"Add -- {item} -- {nextIndex}");
            if(nextIndex >= capacity)
            {
                Resize();
            }

            collection[nextIndex] = item;
            nextIndex++;
        }

        private void Resize()
        {
            var newCapacity = capacity * 2;
            OnResize(capacity, newCapacity);
            capacity = newCapacity;
            Array.Resize(ref collection, newCapacity); 
        }

        public void Clear()
        {
            if(nextIndex != 0)
            {
                collection = new T[capacity];
            }
        }

        public bool Contains(T item)
        {
            return Array.IndexOf(collection, item) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            collection.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            var index = Array.IndexOf(collection, item);
            if(index != -1)
            {
                DoRemove(index);
                OnDelete(item);
                return true;
            }

            return false;
        }

        private void DoRemove(int index)
        {  
            for(var i = index; i + 1 < nextIndex; i++)
            {
                collection[i] = collection[i+1];
            }
            collection[nextIndex - 1] = default(T);
            nextIndex--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < nextIndex; i++)
            {
                yield return collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Add(object value)
        {
            if (capacity < nextIndex)
            {
                collection[nextIndex] = (T)value;
                nextIndex++;

                return (nextIndex - 1);
            }
            else
            {
                return -1;
            }
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }
    }
}
