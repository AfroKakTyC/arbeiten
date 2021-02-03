using System;
using System.IO;
using System.Collections.Generic;

namespace task1
{
	class Program
	{
		static double percentile(List<double> nums, double perc)
		{
			double n = perc / 100 * (nums.Count - 1) + 1;
			int index = (int)Math.Ceiling(n) - 2;
			double remainder = n - Math.Floor(n);
			return (nums[index] + remainder * (nums[index + 1] - nums[index]));
		}

		static double average(List<double> nums)
		{
			double sum = 0;
			for (int i = 0; i < nums.Count; i++)
			{
				sum += nums[i];
			}
			return (sum / nums.Count);
		}

		static void Main(string[] args)
		{
			if (args.Length == 1)
			{
				List<double> nums = new List<double>();
				string filePath = args[0];
				StreamReader reader = new StreamReader(filePath);
				string line;

				while ((line = reader.ReadLine()) != null)
				{
					nums.Add(double.Parse(line));
				}
				nums.Sort();
				Console.WriteLine(percentile(nums, 90).ToString("0.00"));
				Console.WriteLine(percentile(nums, 50).ToString("0.00"));
				Console.WriteLine(nums[nums.Count - 1].ToString("0.00"));
				Console.WriteLine(nums[0].ToString("0.00"));
				Console.WriteLine(average(nums).ToString("0.00"));
			}
		}
	}
}
