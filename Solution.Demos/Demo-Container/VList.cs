using System.Collections;

public class VList<T>
{
    private T[] items = new T[5];

    public int Count { get; set; }

    public void Add(T item)
    {
        if (Count == items.Length)
        {
            Array.Resize(ref items, items.Length * 2);
        }
        items[Count++] = item;
    }

    public IEnumerator<T> GetEnuerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return items[i];
        }
    }

    class VEnumerator : IEnumerator<T>
    {
        public T Current
        {
            get
            {
                if (index < 0 || VList.Count <= index)
                {
                    return default(T);
                }

                return VList.items[index];
            }
        }

        object IEnumerator.Current => Current;

        public int index { get; set; } = -1;

        public VList<T> VList { get; set; }

        public VEnumerator(VList<T> list)
        {
            VList = list;
        }

        public bool MoveNext()
        {
            return ++index < VList.Count;
        }

        public void Reset()
        {
            index = -1;
        }

        public void Dispose()
        {
            Console.WriteLine("I am disposing of myself");
        }
    }
}
