using BenchmarkDotNet.Attributes;

namespace DemoProject.Experiments;

public class Lists
{
    [MemoryDiagnoser]
    public class Append
    {
        private const int N = 10_000;
        private readonly List<int> _list = new();
        private readonly LinkedList<int> _linkedList = new();

        [Benchmark]
        public List<int> ToArrayList()
        {
            for (var i = 0; i < N; i++)
            {
                _list.Add(i);
            }

            return _list;
        }

        [Benchmark]
        public LinkedList<int> ToLinkedList()
        {
            for (var i = 0; i < N; i++)
            {
                _linkedList.AddLast(i);
            }

            return _linkedList;
        }
    }


    [MemoryDiagnoser]
    public class RemoveLast
    {
        private readonly List<int> _arrayList;
        private readonly LinkedList<int> _linkedList;

        public RemoveLast()
        {
            Append append = new();

            _arrayList = append.ToArrayList();
            _linkedList = append.ToLinkedList();
        }

        [Benchmark]
        public void FromArrayList()
        {
            while (_arrayList.Any())
            {
                _arrayList.RemoveAt(_arrayList.Count - 1);
            }
        }

        [Benchmark]
        public void FromLinkedList()
        {
            while (_linkedList.Any())
            {
                _linkedList.RemoveLast();
            }
        }
    }

    [MemoryDiagnoser]
    public class InsertFirst
    {
        const int N = 200_000;

        [Benchmark]
        public List<int> ToArrayList()
        {
            List<int> arrayList = new();

            for (int i = 0; i < N; i++)
            {
                arrayList.Insert(0, i);
            }

            return arrayList;
        }

        [Benchmark]
        public LinkedList<int> ToLinkedList()
        {
            LinkedList<int> linkedList = new();

            for (int i = 0; i < N; i++)
            {
                linkedList.AddFirst(i);
            }

            return linkedList;
        }
    }

    [MemoryDiagnoser]
    public class RemoveFirst
    {
        private readonly List<int> _arrayList;
        private readonly LinkedList<int> _linkedList;

        public RemoveFirst()
        {
            InsertFirst insertFirst = new();

            _arrayList = insertFirst.ToArrayList();
            _linkedList = insertFirst.ToLinkedList();
        }

        [Benchmark]
        public void FromArrayList()
        {
            while (_arrayList.Any())
            {
                _arrayList.RemoveAt(0);
            }
        }

        [Benchmark]
        public void FromLinkedList()
        {
            while (_linkedList.Any())
            {
                _linkedList.RemoveFirst();
            }
        }
    }
}
