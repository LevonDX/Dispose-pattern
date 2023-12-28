using GCTest_October;
using System.Runtime.InteropServices;
namespace GCTest_October
{
	class Person : IDisposable
	{
		private bool isDisposed = false;
		public string Name { get; set; }
		public int Age { get; set; }
		public Person(string name, int age)
		{
			Name = name;
			Age = age;
		}

		public void Dispose() // called manually (NOT automatically)
		{
			if (!isDisposed)
			{
				Dispose(true);
				GC.SuppressFinalize(this); // prevent calling destructor
			}
			isDisposed = true;
		}

		~Person() // called AUTOMATICALLY when GC collects object
		{
			Dispose(false);
		}

		private void Dispose(bool disposing)
		{
			if (disposing)
			{
				// clean managed resources
			}
			// clean unmanaged resources
		}
	}

	class MyFile : IDisposable
	{
		private bool disposedValue;

		private void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects)
				}

				// TODO: free unmanaged resources (unmanaged objects) and override finalizer
				// TODO: set large fields to null
				disposedValue = true;
			}
		}

		// TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
		~MyFile()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}

	internal class Program
	{
		Person GetPersonByName(string name)
		{
			Person person = new Person(name, 20);
			return person;
		}

		static void Main(string[] args)
		{
			using StreamWriter writer = new StreamWriter("log.txt");
			writer.WriteLine("Hello World!");

			writer.Close();
		}
	}
}