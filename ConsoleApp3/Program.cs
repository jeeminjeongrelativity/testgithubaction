using System;

namespace Sample
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("ClientId: {0}", Environment.GetEnvironmentVariable("ClientId"));
		}
	}
}