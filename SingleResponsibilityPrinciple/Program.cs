using System;
namespace SingleResponsibilityPrinciple
{
	public class Program
	{
		public Program(){}

		public static void Main(String[] args)
		{
            var j = new Journal();
			j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            Console.WriteLine(j);

			var p = new Persistence();
			var filename = "/Users/diegocanizales/Projects/DesignPatternsDotnet/SingleResponsibilityPrinciple/journal.txt";
			p.SaveToFile(j, filename, true);
        }
	}
}

