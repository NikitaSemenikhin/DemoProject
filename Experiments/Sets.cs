using BenchmarkDotNet.Attributes;

namespace DemoProject.Experiments;

public static class Sets
{
	[MemoryDiagnoser]
	public class Add
	{
		private const int N = 5_000_000;

		[Benchmark]
		public List<int> ToArrayList()
		{
			List<int> arrayList = new();

			for (var i = 0; i < N; i++)
			{
				arrayList.Add(i);
			}

			return arrayList;
		}

		[Benchmark]
		public HashSet<int> ToHashSet()
		{
			HashSet<int> hashSet = new();

			for (var i = 0; i < N; i++)
			{
				hashSet.Add(i);
			}

			return hashSet;
		}
	}

	[MemoryDiagnoser]
	public class Contains
	{
		private const int N = 50_000;

		private readonly List<int> _arrayList;
		private readonly HashSet<int> _hashSet;

		public Contains()
		{
			Add add = new();

			_arrayList = add.ToArrayList();
			_hashSet = add.ToHashSet();
		}

		[Benchmark]
		public void InArrayList()
		{
			for (var i = 0; i < N; i++)
			{
				_arrayList.Contains(i);
			}
		}

		[Benchmark]
		public void InHashSet()
		{
			for (var i = 0; i < N; i++)
			{
				_hashSet.Contains(i);
			}
		}
	}

	[MemoryDiagnoser]
	public class AddWithDifferentHashing
	{
		private const int N = 10_000;

		[Benchmark]
		public HashSet<PoorlyHashedObject> AddPoorlyHashedObjects()
		{
			HashSet<PoorlyHashedObject> hashSet = new();

			for (int i = 0; i < N; i++)
			{
				PoorlyHashedObject poorlyHashedObject = new(i);
				hashSet.Add(poorlyHashedObject);
			}

			return hashSet;
		}

		[Benchmark]
		public HashSet<ProperlyHashedObject> AddProperlyHashedObjects()
		{
			HashSet<ProperlyHashedObject> hashSet = new();

			for (var i = 0; i < N; i++)
			{
				ProperlyHashedObject properlyHashedObject = new(i);
				hashSet.Add(properlyHashedObject);
			}

			return hashSet;
		}
	}

	[MemoryDiagnoser]
	public class ContainsWithDifferentHashing
	{
		private const int N = 10_000;

		private readonly HashSet<PoorlyHashedObject> _poorlyHashedObjects;
		private readonly HashSet<ProperlyHashedObject> _properlyHashedObjects;

		public ContainsWithDifferentHashing()
		{
			AddWithDifferentHashing addWithDifferentHashing = new();

			_poorlyHashedObjects   = addWithDifferentHashing.AddPoorlyHashedObjects();
			_properlyHashedObjects = addWithDifferentHashing.AddProperlyHashedObjects();
		}

		[Benchmark]
		public void SearchPoorlyHashedObjects()
		{
			for (var i = 0; i < N; i++)
			{
				PoorlyHashedObject poorlyHashedObject = new(i);
				_poorlyHashedObjects.Contains(poorlyHashedObject);
			}
		}

		[Benchmark]
		public void SearchProperlyHashedObjects()
		{
			for (var i = 0; i < N; i++)
			{
				ProperlyHashedObject properlyHashedObject = new(i);
				_properlyHashedObjects.Contains(properlyHashedObject);
			}
		}
	}
}
