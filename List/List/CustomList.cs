using System.Collections;

namespace List
{
    public class CustomList<T> : IList<T>
    {
        private int _positionCounter = 0;
        private T[] _arr = new T[4];
        public bool IsReadOnly => throw new NotImplementedException();
        public int Count
        {
            get
            {
                return _positionCounter;
            }
        }

        private int Capacity
        {
            get
            {
                return _arr.Length;
            }
        }

        public T this[int i]
        {
            get
            {
                if (i <= Count)
                {
                    return _arr[i];
                }

                throw new IndexOutOfRangeException();
            }
            set
            {
                if (i <= Count)
                {
                    _arr[i] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public void Add(T item)
        {
            if (Count >= Capacity)
            {
                T[] arr1 = new T[Capacity * 2];
                _arr.CopyTo(arr1, 0);
                _arr = arr1;
            }

            _arr[Count] = item;
            _positionCounter++;
        }

        public void AddRange(IList<T> coll)
        {
            if (coll.Count >= Capacity)
            {
                T[] arr1 = new T[Capacity * 2];
                _arr.CopyTo(arr1, 0);
                _arr = arr1;
            }

            for (var i = Count; i < coll.Count; i++)
            {
                _arr[i] = coll[i - Count];
            }

            _positionCounter += coll.Count;
        }

        public void AddRange(T[] coll)
        {
            if (coll.Length >= Capacity)
            {
                T[] arr1 = new T[Capacity * 2];
                _arr.CopyTo(arr1, 0);
                _arr = arr1;
            }

            for (var i = Count; i < coll.Length; i++)
            {
                _arr[i] = coll[i - Count];
            }

            _positionCounter += coll.Length;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            /*if (!_arr.Contains(item))
            {
                return false;
            }

            for (var i = 0; i < _positionCounter; i++)
            {
                if (!_arr[i].Equals(default(T)) && !item.Equals(default(T)))
                {
                }
            }*/
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            for (var i = index; i < Count - 1; i++)
            {
                _arr[i] = _arr[i + 1];
            }

            _positionCounter--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Sort(IComparer<T> com)
        {
            Array.Sort(_arr, com);
        }
    }
}