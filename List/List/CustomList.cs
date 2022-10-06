using System;
using System.Collections;

namespace List
{
    public class CustomList<T> : ICollection<T>
    {
        private readonly int _multiplierInCaseTheInnerArrayIsFullButNeedsToBecomeWider = 2;
        private int _positionCounter = 0;
        private T[] _innerArray = new T[4];
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
                return _innerArray.Length;
            }
        }

        public void Add(T item)
        {
            if (Count >= Capacity)
            {
                IncreaseArrayCapacity();
            }

            _innerArray[Count] = item;
            _positionCounter++;
        }

        public void AddRange(ICollection<T> collection)
        {
            while (Count + collection.Count >= Capacity)
            {
                IncreaseArrayCapacity();
            }

            for (var i = Count; i < Count + collection.Count; i++)
            {
                _innerArray[i] = collection.ElementAt(i - Count);
            }

            _positionCounter += collection.Count;
        }

        public void AddRange(T[] array)
        {
            if (array.Length >= Capacity)
            {
                IncreaseArrayCapacity();
            }

            for (var i = Count; i < array.Length; i++)
            {
                _innerArray[i] = array[i - Count];
            }

            _positionCounter += array.Length;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _innerArray.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
            {
                yield return _innerArray[i];
            }
        }

        public bool Remove(T item)
        {
            if (!_innerArray.Contains(item))
            {
                return false;
            }

            for (var i = 0; i < _positionCounter; i++)
            {
                if (_innerArray[i] !.Equals(item))
                {
                    for (var j = i; j < Count - 1; j++)
                    {
                        _innerArray[j] = _innerArray[j + 1];
                    }

                    break;
                }
            }

            _positionCounter--;
            return true;
        }

        public void RemoveAt(int index)
        {
            for (var i = index; i < Count - 1; i++)
            {
                _innerArray[i] = _innerArray[i + 1];
            }

            _positionCounter--;
        }

        public void Sort(IComparer<T> comparer)
        {
            Array.Sort(_innerArray, comparer);
        }

        public void Clear()
        {
            _innerArray = new T[4];
        }

        public bool Contains(T item)
        {
            if (!_innerArray.Contains(item))
            {
                return false;
            }

            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _innerArray.GetEnumerator();
        }

        private void IncreaseArrayCapacity()
        {
            T[] innerArray1 = new T[Capacity * _multiplierInCaseTheInnerArrayIsFullButNeedsToBecomeWider];
            _innerArray.CopyTo(innerArray1, 0);
            _innerArray = innerArray1;
        }
    }
}