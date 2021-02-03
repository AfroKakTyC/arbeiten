using System;
using System.IO;

namespace task2
{
	class Quad
	{
		public Point A { get; private set; }
		public Point B { get; private set; }
		public Point C { get; private set; }
		public Point D { get; private set; }

		public Quad ()
		{
			A = new Point();
			B = new Point();
			C = new Point();
			D = new Point();
		}
	}

	class Point
	{
		public double X { get; set; }
		public double Y { get; set; }

		public Point() { }

		public Point(double x, double y)
		{
			X = x;
			Y = y;
		}
	}

	class Program
	{
		static bool isOnPeak(Quad quad, Point point)
		{
			if ((point.X == quad.A.X && point.Y == quad.A.Y) ||
			(point.X == quad.B.X && point.Y == quad.B.Y) ||
			(point.X == quad.C.X && point.Y == quad.C.Y) ||
			(point.X == quad.D.X && point.Y == quad.D.Y))
				return (true);
			else
				return (false);
		}

		static bool isOnSide(Quad quad, Point point)
		{
			if ((pointOnVectorPosition(quad.A, quad.B, point) == 0) ||
			(pointOnVectorPosition(quad.B, quad.C, point) == 0) ||
			(pointOnVectorPosition(quad.C, quad.D, point) == 0) ||
			(pointOnVectorPosition(quad.D, quad.A, point) == 0))
				return (true);
			else
				return (false);
		}

		static bool isOnSameSide(Point quadA, Point quadB, Point quadC, Point point)
		{
			return (pointOnVectorPosition(quadA, quadB, quadC) * pointOnVectorPosition(quadA, quadB, point) >= 0);
		}

		static bool isInside(Quad quad, Point point)
		{
			if ((isOnSameSide(quad.A, quad.B, quad.C, point) && isOnSameSide(quad.B, quad.C, quad.A, point) && isOnSameSide(quad.C, quad.A, quad.B, point))
			|| (isOnSameSide(quad.A, quad.C, quad.D, point) && isOnSameSide(quad.C, quad.D, quad.A, point) && isOnSameSide(quad.D, quad.A, quad.C, point)))
				return (true);
			else
				return (false);
		}

		static double pointOnVectorPosition(Point quadA, Point quadB, Point point)
		{
			return ((point.X - quadA.X) * (quadB.Y - quadA.Y) - (point.Y - quadA.Y) * (quadB.X - quadA.X));
		}

		static void Main(string[] args)
		{
			if (args.Length == 2)
			{
				StreamReader reader1 = new StreamReader(args[0]);
				StreamReader reader2 = new StreamReader(args[1]);

				Quad quad = new Quad();
				string[] line = reader1.ReadLine().Split(" ");
				quad.A.X = Double.Parse(line[0]);
				quad.A.Y = Double.Parse(line[1]);
				line = reader1.ReadLine().Split(" ");
				quad.B.X = Double.Parse(line[0]);
				quad.B.Y = Double.Parse(line[1]);
				line = reader1.ReadLine().Split(" ");
				quad.C.X = Double.Parse(line[0]);
				quad.C.Y = Double.Parse(line[1]);
				line = reader1.ReadLine().Split(" ");
				quad.D.X = Double.Parse(line[0]);
				quad.D.Y = Double.Parse(line[1]);

				string line2;
				while ((line2 = reader2.ReadLine()) != null)
				{
					line = line2.Split(" ");
					Point point = new Point(Double.Parse(line[0]), Double.Parse(line[1]));

					if (isOnPeak(quad, point))
						Console.WriteLine("0");
					else if (isOnSide(quad, point))
						Console.WriteLine("1");
					else if (isInside(quad, point))
						Console.WriteLine("2");
					else
						Console.WriteLine("3");
				}
			}
		}
	}
}
