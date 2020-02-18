using System;
using System.Collections.Generic;
using System.Text;

namespace DS_MyArray
{
    public class MyArray2<T>
    {
        private T[] _data;
        private int _size;

        public MyArray2(int capacity)
        {
            this._data = new T[capacity];
            this._size = 0;
        }

        public MyArray2() : this(10)
        {

        }

        public MyArray2(T[] array)
        {
            this._data = new T[array.Length];
            this._size = 0;
            for (int i = 0; i <array.Length; i++)
            {
                this._data[i] = array[i];
                if (!this._data[i].Equals(default(T))) {
                    this._size++;
                }
            }
        }

        public int GetSize()
        {

            return this._size;
        }

        public int GetCapacity()
        {
            return this._data.Length;
        }

        public  bool IsEmpty()
        {
            return _size == 0;
        }

        public T[] GetData()
        {
            return this._data;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= _size)
            {
                throw new Exception("Get failed. Index is illegal");
            }
            return _data[index];
        }

        public T GetFirst()
        {
            return Get(0);
        }

        public T GetLast()
        {
            return Get(this._size - 1);
        }

        public void Set(int index, T e)
        {
            if (index < 0 || index >= _size)
            {
                throw new Exception("Get failed. Index is illegal");
            }
            this._data[index] = e;
        }

        // 在index位置上添加一个新的元素
        public void Add(int index, T e)
        {
            if (index < 0 || index > this._size)
            {
                throw new Exception("Index is should be greate than 0 and less or equal than size");
            }
            if (this._size == this._data.Length)
            {
                Resize(2 * this._data.Length);
            }

            for (int i = this._size - 1; i >=  index; i-- )
            {
                _data[i + 1] = _data[i];
            }
            this._data[index] = e;
            this._size++;
        }

        public void AddFirst(T e)
        {
            Add(0, e);
        }

        public void AddLast(T e)
        {
            Add(_size, e);
        }

        public bool Contains(T e)
        {
            for(int i = 0; i < _size; i++)
            {
                return this._data[i].Equals(e);
            }
            return false;
        }

        public int Find(T e)
        {
            for (int i = 0; i <_size; i++)
            {
                if (this._data[i].Equals(e))
                {
                    return i;
                }
            }
            return -1;
        }

        public IList<int> FindAll(T e)
        {
            IList<int> res = new List<int>();
            for (int i = 0; i < _size; i++)
            {
                if (this._data[i].Equals(e))
                {
                    res.Add(i);
                }
            }
            return res;
        }

        public T Remove(int index)
        {
            if (index < 0 || index >= this._size)
            {
                throw new Exception("Remove failed. The index is illegal.");
            }
            T res = this._data[index];
            for (int i = index + 1; i < this._size; i++)
            {
                this._data[i - 1] = this._data[i];
            }
            this._size--;
            this._data[_size] = default(T);  // lotering object

            if (this._size == this._data.Length / 4  && this._data.Length / 2 != 0)
            {
                Resize(this._data.Length / 2);
            }

            return res;
        } 
        public T RemoveFirst()
        {
            return Remove(0);
        }
        public T RemoveLast()
        {
            return Remove(this._size - 1);
        }
        public bool RemoveElement(T e)
        {
            int index = Find(e);
            bool res = index != -1;
            if(index != -1)
            {
                try
                {
                    Remove(index);
                }
                catch { res = false; }
            }
            return res;
        }

        public bool RemoveAllElement(T e)
        {
            List<int> indexs = (List<int>)FindAll(e);
            bool res = indexs.Count > 0;
            int counter = 0;
            foreach (int index in indexs)
            {
                int newIndex = index;
                if (counter > 0)
                {
                    newIndex = newIndex - 1;
                }
                try
                {
                    Remove(newIndex);
                }
                catch { res = false; }
                counter++;
            }
            return res;
        }
       
        private void Resize(int newCapacity)
        {
            T[] newData = new T[newCapacity];
            for(int i =0; i < this._size; i++)
            {
                newData[i] = this._data[i];
            }
            this._data = newData;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format("Array size is {0}, capacity is {1}. \n", this._size, this._data.Length));
            sb.Append(" [ ");
            for (int i = 0; i < this._size; i++)
            {
                sb.Append($" {this._data[i]}, ");
            }
            sb.Append(" ] ");
            return sb.ToString();
        }


    }
}
