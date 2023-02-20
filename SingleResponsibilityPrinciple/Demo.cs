using System;
namespace SingleResponsibilityPrinciple
{
	/// <summary>
	/// Journal class keep tracks of 
	/// </summary>
	public class Journal
	{

		private readonly List<string> entries = new List<string>();

		private static int count = 0;

		public Journal()
		{
		}

		public int AddEntry(string text)
		{
			entries.Add($"{++count}: {text}");
			return count; // memento pattern
		}

		public void RemoveEntry(int index)
		{
			entries.RemoveAt(index);
		}

        public override string ToString()
        {
			return string.Join(Environment.NewLine, entries);
        }

		// as we grow, we might want to presist some stuff:
		// however, we're adding too much responsibility to a class.
		// this class is responsible for keeping track of entries,
		// as well as keeping persistence, so now we have two reasons to change
		// 
		// AVOID THIS:
		//public void Save(string filename)
		//{
		//	File.WriteAllText(filename, ToString());
		//}

		//public static Journal Load(string filename)
		//{
		//	throw new NotImplementedException();
		//}

		//public void Load(Uri uri)
		//{
		//	throw new NotImplementedException();
		//}
    }


	/// <summary>
	/// Persistence class is responsible for saving Journal into datastore.
	/// </summary>
	public class Persistence
	{
		public void SaveToFile(Journal j, string filename, bool overwrite = false)
		{
			if (overwrite || !File.Exists(filename))
			{
				File.WriteAllText(filename, j.ToString()); // serialization
			}
		}
	}

}

