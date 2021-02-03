using System;
using System.IO;

namespace task4
{
	class Program
	{
		static int StrTimeToInt(string time)
		{
			string[] hoursAndMinutes = time.Split(":");
			int hours = Int32.Parse(hoursAndMinutes[0]);
			int minutes = Int32.Parse(hoursAndMinutes[1]) + hours * 60;
			return (minutes);
		}

		static int MaxVisitors(int[] visitorsOnTime)
		{
			int maxVisitors = 0;
			for (int i = 0; i < visitorsOnTime.Length; i++)
			{
				if (visitorsOnTime[i] > maxVisitors)
					maxVisitors = visitorsOnTime[i];
			}
			return (maxVisitors);
		}

		static string IntTimeToStr(int time)
		{
			time += 480;
			int hours = time / 60;
			int minutes = time - (hours * 60);
			string strTime = hours.ToString() + ":";
			if (minutes < 10)
				strTime += "0" + minutes.ToString();
			else
				strTime += minutes.ToString();
			return (strTime);
		}

		static void PrintMaxIntervals(int[] visitorsOnTime)
		{
			int maxVisitors = MaxVisitors(visitorsOnTime);
			bool isOnMax = false;
			for (int i = 0; i < visitorsOnTime.Length; i++)
			{
				if (visitorsOnTime[i] == maxVisitors && !isOnMax)
				{
					Console.Write(IntTimeToStr(i) + " ");
					isOnMax = true;
				}
				else if (visitorsOnTime[i] != maxVisitors && isOnMax)
				{
					Console.WriteLine(IntTimeToStr(i));
					isOnMax = false;
				}
			}
			if (isOnMax)
				Console.WriteLine(IntTimeToStr(visitorsOnTime.Length));
		}

		static void Main(string[] args)
		{
			if (args.Length == 1)
			{
				int[] visitorsOnTime = new int[720];
				StreamReader reader = new StreamReader(args[0]);
				string line;
				while ((line = reader.ReadLine()) != null)
				{
					string[] strTimes = line.Split(" ");
					int enterTime = StrTimeToInt(strTimes[0]);
					int exitTime = StrTimeToInt(strTimes[1]);
					enterTime -= 480;
					exitTime -= 480;
					for (int i = enterTime; i < exitTime; i++)
					{
						visitorsOnTime[i]++;
					}
				}
				//for (int i = 0; i < visitorsOnTime.Length; i++)
				//{
				//	Console.WriteLine("[{0}] {1}", i, visitorsOnTime[i]);
				//}
				PrintMaxIntervals(visitorsOnTime);
			}
		}
	}
}
