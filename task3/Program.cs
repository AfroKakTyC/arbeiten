using System;
using System.IO;

namespace task3
{
	class Program
	{
		static double sumCashes(double[,] cashes, int index)
		{
			double sum = 0;

			for (int i = 0; i < 5; i++)
			{
				sum += cashes[i, index];
			}
			return (sum);
		}
		static void Main(string[] args)
		{
			if (args.Length == 1)
			{
				double[,] cashes = new double[5, 16];
				for (int i = 0; i < 5; i++)
				{
					string path = args[0] + "\\" +"Cash" + (i + 1).ToString() + ".txt";
					StreamReader reader = new StreamReader(path);
					for (int j = 0; j < 16; j++)
					{
						cashes[i, j] = Double.Parse(reader.ReadLine());
					}
				}
				double maxSum = 0;
				int maxIndex = 0;
				for (int i = 0; i < 16; i++)
				{
					if (sumCashes(cashes, i) > maxSum)
					{
						maxSum = sumCashes(cashes, i);
						maxIndex = i;
					}
				}
				Console.WriteLine(maxIndex + 1);
			}
		}
	}
}
