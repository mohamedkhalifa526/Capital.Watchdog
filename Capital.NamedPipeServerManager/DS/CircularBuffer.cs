namespace Capital.NamedPipeServer.DS
{
    public class CircularBuffer<T> : List<T>
    {
        //to sets the total number of elements that can be carried without resizing,
        //we called the base constrctor that takes the capacity
        public int Size { get; private set; }

        public CircularBuffer(int size)
        {
            Size = size;
        }

        public void Insert(T element)
        {
            Add(element);
            lock (this)
                while (Count > Size)
                    RemoveAt(0);
        }
    }
}